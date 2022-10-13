using System.Collections.Specialized;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ML.Core
{
    public class IniFile
    {
        private readonly string _fileFullPath;

        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string? section, string? key, string? val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string? section, string? key, string? def, byte[] retVal, int size, string filePath);

        public IniFile(string fileFullPath)
        {
            if (!File.Exists(fileFullPath))
            {
                try
                {
                    File.Create(fileFullPath).Close();
                }
                catch (Exception ex)
                {
                    throw new FileLoadException($"file {fileFullPath} not exist,creat fail.{ex.Message}");
                }
            }
            _fileFullPath = fileFullPath;
        }

        public void WriteString(string Section, string Ident, string Value)
        {
            if (!WritePrivateProfileString(Section, Ident, Value, _fileFullPath))
            {
                throw new ApplicationException("ini file write string type error! file name");
            }
        }

        public string ReadString(string Section, string Ident, string Default)
        {
            byte[] Buffer = new byte[65535];
            int bufLen = GetPrivateProfileString(Section, Ident, Default, Buffer, Buffer.GetUpperBound(0), _fileFullPath);
            string s = Encoding.GetEncoding(0).GetString(Buffer);
            s = s.Substring(0, bufLen);
            return s.Trim("\0".ToCharArray());
        }

        public int ReadInteger(string Section, string Ident, int Default)
        {
            string intStr = ReadString(Section, Ident, Convert.ToString(Default));
            try
            {
                return Convert.ToInt32(intStr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Default;
            }
        }

        public void WriteInteger(string Section, string Ident, int Value)
        {
            WriteString(Section, Ident, Value.ToString());
        }

        public bool ReadBool(string Section, string Ident, bool Default)
        {
            try
            {
                return Convert.ToBoolean(ReadString(Section, Ident, Convert.ToString(Default)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Default;
            }
        }

        public void WriteBool(string Section, string Ident, bool Value)
        {
            WriteString(Section, Ident, Convert.ToString(Value));
        }

        public void ReadSection(string Section, StringCollection Idents)
        {
            byte[] Buffer = new byte[16384];
            int bufLen = GetPrivateProfileString(Section, null, null, Buffer, Buffer.GetUpperBound(0), _fileFullPath);
            GetStringsFromBuffer(Buffer, bufLen, Idents);
        }

        private void GetStringsFromBuffer(byte[] Buffer, int bufLen, StringCollection Strings)
        {
            Strings.Clear();
            if (bufLen != 0)
            {
                int start = 0;
                for (int i = 0; i < bufLen; i++)
                {
                    if ((Buffer[i] == 0) && ((i - start) > 0))
                    {
                        String s = Encoding.GetEncoding(0).GetString(Buffer, start, i - start);
                        Strings.Add(s);
                        start = i + 1;
                    }
                }
            }
        }

        public void ReadSections(StringCollection SectionList)
        {
            byte[] Buffer = new byte[65535];
            int bufLen = 0;
            bufLen = GetPrivateProfileString(null, null, null, Buffer, Buffer.GetUpperBound(0), _fileFullPath);
            GetStringsFromBuffer(Buffer, bufLen, SectionList);
        }

        public void ReadSectionValues(string Section, NameValueCollection Values)
        {
            StringCollection KeyList = new StringCollection();
            ReadSection(Section, KeyList);
            Values.Clear();
            foreach (string key in KeyList)
            {
                Values.Add(key, ReadString(Section, key, ""));
            }
        }

        public void EraseSection(string Section)
        {
            if (!WritePrivateProfileString(Section, null, null, _fileFullPath))
            {
                throw new ApplicationException($"can not delect Section.<{_fileFullPath}>");
            }
        }

        public void DeleteKey(string Section, string Ident)
        {
            WritePrivateProfileString(Section, Ident, null, _fileFullPath);
        }

        public void UpdateFile()
        {
            WritePrivateProfileString(null, null, null, _fileFullPath);
        }

        public bool ValueExists(string Section, string Ident)
        {
            StringCollection Idents = new StringCollection();
            ReadSection(Section, Idents);
            return Idents.IndexOf(Ident) > -1;
        }

        ~IniFile()
        {
            UpdateFile();
        }
    }
}
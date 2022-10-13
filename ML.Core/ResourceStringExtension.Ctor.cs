using System.Windows;
using System.Windows.Data;

namespace ML.Core
{
    public partial class ResourceStringExtension
    {
        public ResourceStringExtension()
        {
            Converter = new MultiValueConverter(this);
            Args = new ArgCollection(this);
        }

        private ResourceStringExtension(ComponentResourceKey key)
            : this()
        {
            Key = key;
            Bindings.Add(new Binding(nameof(ResourceSource.Value))
            {
                Source = new ResourceSource(key),
                Mode = BindingMode.OneWay,
                Converter = ResourceConverter
            });
        }

        public ResourceStringExtension(ComponentResourceKey key, object item0)
            : this(key)
        {
            Args.Add(item0);
        }

        public ResourceStringExtension(ComponentResourceKey key, object item0, object item1)
            : this(key)
        {
            Args.Add(item0);
            Args.Add(item1);
        }

        public ResourceStringExtension(ComponentResourceKey key, object item0, object item1, object item2)
            : this(key)
        {
            Args.Add(item0);
            Args.Add(item1);
            Args.Add(item2);
        }

        public ResourceStringExtension(ComponentResourceKey key, object item0, object item1, object item2, object item3)
            : this(key)
        {
            Args.Add(item0);
            Args.Add(item1);
            Args.Add(item2);
            Args.Add(item3);
        }

        public ResourceStringExtension(ComponentResourceKey key, object item0, object item1, object item2, object item3, object item4)
            : this(key)
        {
            Args.Add(item0);
            Args.Add(item1);
            Args.Add(item2);
            Args.Add(item3);
            Args.Add(item4);
        }

        public ResourceStringExtension(ComponentResourceKey key, object item0, object item1, object item2, object item3, object item4, object item5)
            : this(key)
        {
            Args.Add(item0);
            Args.Add(item1);
            Args.Add(item2);
            Args.Add(item3);
            Args.Add(item4);
            Args.Add(item5);
        }

        public ResourceStringExtension(ComponentResourceKey key, object item0, object item1, object item2, object item3, object item4, object item5, object item6)
            : this(key)
        {
            Args.Add(item0);
            Args.Add(item1);
            Args.Add(item2);
            Args.Add(item3);
            Args.Add(item4);
            Args.Add(item5);
            Args.Add(item6);
        }

        public ResourceStringExtension(ComponentResourceKey key, object item0, object item1, object item2, object item3, object item4, object item5, object item6, object item7)
            : this(key)
        {
            Args.Add(item0);
            Args.Add(item1);
            Args.Add(item2);
            Args.Add(item3);
            Args.Add(item4);
            Args.Add(item5);
            Args.Add(item6);
            Args.Add(item7);
        }

        public ResourceStringExtension(ComponentResourceKey key, object item0, object item1, object item2, object item3, object item4, object item5, object item6, object item7, object item8)
            : this(key)
        {
            Args.Add(item0);
            Args.Add(item1);
            Args.Add(item2);
            Args.Add(item3);
            Args.Add(item4);
            Args.Add(item5);
            Args.Add(item6);
            Args.Add(item7);
            Args.Add(item8);
        }

        public ResourceStringExtension(ComponentResourceKey key, object item0, object item1, object item2, object item3, object item4, object item5, object item6, object item7, object item8, object item9)
            : this(key)
        {
            Args.Add(item0);
            Args.Add(item1);
            Args.Add(item2);
            Args.Add(item3);
            Args.Add(item4);
            Args.Add(item5);
            Args.Add(item6);
            Args.Add(item7);
            Args.Add(item8);
            Args.Add(item9);
        }

        public ResourceStringExtension(ComponentResourceKey key, object item0, object item1, object item2, object item3, object item4, object item5, object item6, object item7, object item8, object item9, object item10)
            : this(key)
        {
            Args.Add(item0);
            Args.Add(item1);
            Args.Add(item2);
            Args.Add(item3);
            Args.Add(item4);
            Args.Add(item5);
            Args.Add(item6);
            Args.Add(item7);
            Args.Add(item8);
            Args.Add(item9);
            Args.Add(item10);
        }

        public ResourceStringExtension(ComponentResourceKey key, object item0, object item1, object item2, object item3, object item4, object item5, object item6, object item7, object item8, object item9, object item10, object item11)
            : this(key)
        {
            Args.Add(item0);
            Args.Add(item1);
            Args.Add(item2);
            Args.Add(item3);
            Args.Add(item4);
            Args.Add(item5);
            Args.Add(item6);
            Args.Add(item7);
            Args.Add(item8);
            Args.Add(item9);
            Args.Add(item10);
            Args.Add(item11);
        }

        public ResourceStringExtension(ComponentResourceKey key, object item0, object item1, object item2, object item3, object item4, object item5, object item6, object item7, object item8, object item9, object item10, object item11, object item12)
            : this(key)
        {
            Args.Add(item0);
            Args.Add(item1);
            Args.Add(item2);
            Args.Add(item3);
            Args.Add(item4);
            Args.Add(item5);
            Args.Add(item6);
            Args.Add(item7);
            Args.Add(item8);
            Args.Add(item9);
            Args.Add(item10);
            Args.Add(item11);
            Args.Add(item12);
        }

        public ResourceStringExtension(ComponentResourceKey key, object item0, object item1, object item2, object item3, object item4, object item5, object item6, object item7, object item8, object item9, object item10, object item11, object item12, object item13)
            : this(key)
        {
            Args.Add(item0);
            Args.Add(item1);
            Args.Add(item2);
            Args.Add(item3);
            Args.Add(item4);
            Args.Add(item5);
            Args.Add(item6);
            Args.Add(item7);
            Args.Add(item8);
            Args.Add(item9);
            Args.Add(item10);
            Args.Add(item11);
            Args.Add(item12);
            Args.Add(item13);
        }

        public ResourceStringExtension(ComponentResourceKey key, object item0, object item1, object item2, object item3, object item4, object item5, object item6, object item7, object item8, object item9, object item10, object item11, object item12, object item13, object item14)
            : this(key)
        {
            Args.Add(item0);
            Args.Add(item1);
            Args.Add(item2);
            Args.Add(item3);
            Args.Add(item4);
            Args.Add(item5);
            Args.Add(item6);
            Args.Add(item7);
            Args.Add(item8);
            Args.Add(item9);
            Args.Add(item10);
            Args.Add(item11);
            Args.Add(item12);
            Args.Add(item13);
            Args.Add(item14);
        }

        public ResourceStringExtension(ComponentResourceKey key, object item0, object item1, object item2, object item3, object item4, object item5, object item6, object item7, object item8, object item9, object item10, object item11, object item12, object item13, object item14, object item15)
            : this(key)
        {
            Args.Add(item0);
            Args.Add(item1);
            Args.Add(item2);
            Args.Add(item3);
            Args.Add(item4);
            Args.Add(item5);
            Args.Add(item6);
            Args.Add(item7);
            Args.Add(item8);
            Args.Add(item9);
            Args.Add(item10);
            Args.Add(item11);
            Args.Add(item12);
            Args.Add(item13);
            Args.Add(item14);
            Args.Add(item15);
        }
    }
}
﻿namespace WhenFresh.Utilities.Core.Facts.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using Moq;
    using WhenFresh.Utilities.Core.Collections;

    public sealed class IEnumerableExtensionMethodsFacts
    {
        [Fact]
        public void a_definition()
        {
            Assert.True(typeof(IEnumerableExtensionMethods).IsStatic());
        }

        [Fact]
        public void op_Concat_IEnumerableStringEmpty_char()
        {
            var array = new string[]
                            {
                            };

            var expected = string.Empty;
            var actual = array.Concat(',');

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void op_Concat_IEnumerableStringEmpty_string()
        {
            var array = new string[]
                            {
                            };

            var expected = string.Empty;
            var actual = array.Concat(", ");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void op_Concat_IEnumerableStringNull_char()
        {
            var actual = (null as IEnumerable<string>).Concat(',');

            Assert.Equal(null, actual);
        }

        [Fact]
        public void op_Concat_IEnumerableStringNull_string()
        {
            var actual = (null as IEnumerable<string>).Concat(", ");

            Assert.Equal(null, actual);
        }

        [Fact]
        public void op_Concat_IEnumerableString_char()
        {
            var array = new[]
                            {
                                "a", "b", "c"
                            };

            const string expected = "a,b,c";
            var actual = array.Concat(',');

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void op_Concat_IEnumerableString_string()
        {
            var array = new[]
                            {
                                "a", "b", "c"
                            };

            const string expected = "a, b, c";
            var actual = array.Concat(", ");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void op_Concat_IEnumerableString_stringEmpty()
        {
            var array = new[]
                            {
                                "a", "b", "c"
                            };

            const string expected = "abc";
            var actual = array.Concat(string.Empty);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void op_Concat_IEnumerableString_stringNull()
        {
            var array = new[]
                            {
                                "a", "b", "c"
                            };

            Assert.Throws<ArgumentNullException>(() => IEnumerableExtensionMethods.Concat(array, null));
        }

        [Fact]
        public void op_IsEmpty_IEnumerable()
        {
            var obj = new List<string>
                          {
                              "item"
                          };

            Assert.False(obj.IsEmpty());
        }

        [Fact]
        public void op_IsEmpty_IEnumerableEmpty()
        {
            var obj = new List<string>();

            Assert.True(obj.IsEmpty());
        }

        [Fact]
        public void op_IsEmpty_IEnumerableNull()
        {
            Assert.True((null as IEnumerable).IsEmpty());
        }

        [Fact]
        public void op_IsNotEmpty_IEnumerable()
        {
            var obj = new List<string>
                          {
                              "item"
                          };

            Assert.True(obj.IsNotEmpty());
        }

        [Fact]
        public void op_IsNotEmpty_IEnumerableEmpty()
        {
            var obj = new List<string>();

            Assert.False(obj.IsNotEmpty());
        }

        [Fact]
        public void op_IsNotEmpty_IEnumerableNull()
        {
            Assert.False((null as IEnumerable).IsNotEmpty());
        }

#if !NET20 && !NET35
        [Fact]
        public void op_None_IEnumerableOfT_FuncOfT()
        {
            var obj = new List<string>
                          {
                              "example"
                          };

            Assert.False(obj.None(x => x == "example"));
            Assert.True(obj.None(string.IsNullOrEmpty));
        }
#endif

#if !NET20 && !NET35
        [Fact]
        public void op_ToConcurrentDictionary_IEnumerable()
        {
            var source = new List<KeyStringDictionary>
                             {
                                 new KeyStringDictionary
                                     {
                                         { "KEY", "1" },
                                         { "VALUE", "A" },
                                     },
                                 new KeyStringDictionary
                                     {
                                         { "KEY", "2" },
                                         { "VALUE", "B" },
                                     },
                             };

            var actual = source.ToConcurrentDictionary(entry => XmlConvert.ToInt32(entry["KEY"]), entry => entry["VALUE"]);

            Assert.Equal("A", actual[1]);
            Assert.Equal("B", actual[2]);
        }

        [Fact]
        public void op_ToConcurrentDictionary_IEnumerableEmpty()
        {
            Assert.Empty(new List<KeyStringDictionary>().ToConcurrentDictionary(entry => XmlConvert.ToInt32(entry["KEY"]), entry => entry["VALUE"]));
        }

        [Fact]
        public void op_ToConcurrentDictionary_IEnumerableNull()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<KeyStringDictionary>).ToConcurrentDictionary(entry => XmlConvert.ToInt32(entry["KEY"]), entry => entry["VALUE"]));
        }
#endif

        [Fact]
        public void op_ToHashSet_IEnumerable()
        {
            var obj = "a,z".Split(',', StringSplitOptions.RemoveEmptyEntries);

            var actual = IEnumerableExtensionMethods.ToHashSet(obj);

            Assert.Equal("a", actual.First());
            Assert.Equal("z", actual.Last());
        }

        [Fact]
        public void op_ToHashSet_IEnumerableEmpty()
        {
            Assert.Empty(IEnumerableExtensionMethods.ToHashSet(new List<string>()));
        }

        [Fact]
        public void op_ToHashSet_IEnumerableEmpty_IEqualityComparerOfT()
        {
            Assert.Empty(IEnumerableExtensionMethods.ToHashSet(new List<string>(), new Mock<IEqualityComparer<string>>().Object));
        }

        [Fact]
        public void op_ToHashSet_IEnumerableNull()
        {
            Assert.Throws<ArgumentNullException>(() => IEnumerableExtensionMethods.ToHashSet((null as IEnumerable<int>)));
        }

        [Fact]
        public void op_ToHashSet_IEnumerableNull_IEqualityComparerOfT()
        {
            Assert.Throws<ArgumentNullException>(() => IEnumerableExtensionMethods.ToHashSet((null as IEnumerable<int>), new Mock<IEqualityComparer<int>>().Object));
        }

        [Fact]
        public void op_ToHashSet_IEnumerable_IEqualityComparerOfT()
        {
            var obj = "a,z".Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();

            var comparer = new Mock<IEqualityComparer<string>>();

            var actual = IEnumerableExtensionMethods.ToHashSet(obj, comparer.Object);

            Assert.Equal("a", actual.First());
            Assert.Equal("z", actual.Last());
        }

        [Fact]
        public void op_ToQueue_IEnumerable()
        {
            var obj = "a,b,c".Split(',', StringSplitOptions.RemoveEmptyEntries);

            var actual = obj.ToQueue();

            Assert.Equal("a", actual.Dequeue());
            Assert.Equal("b", actual.Dequeue());
            Assert.Equal("c", actual.Dequeue());
        }

        [Fact]
        public void op_ToQueue_IEnumerableEmpty()
        {
            Assert.Empty(new List<string>().ToQueue());
        }

        [Fact]
        public void op_ToQueue_IEnumerableNull()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<int>).ToQueue());
        }

        [Fact]
        public void op_ToStack_IEnumerable()
        {
            var obj = "a,b,c".Split(',', StringSplitOptions.RemoveEmptyEntries);

            var actual = obj.ToStack();

            Assert.Equal("c", actual.Pop());
            Assert.Equal("b", actual.Pop());
            Assert.Equal("a", actual.Pop());
        }

        [Fact]
        public void op_ToStack_IEnumerableEmpty()
        {
            Assert.Empty(new List<string>().ToStack());
        }

        [Fact]
        public void op_ToStack_IEnumerableNull()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<int>).ToStack());
        }
    }
}
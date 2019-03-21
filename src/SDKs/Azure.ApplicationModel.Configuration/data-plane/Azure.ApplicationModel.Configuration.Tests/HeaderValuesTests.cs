using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Azure.Base.Http;
using NUnit.Framework;

namespace Azure.Configuration.Tests
{

    public class HeaderValuesTests
    {
        public static HeaderValues[] DefaultOrNullStringValues =>
            new HeaderValues[]
            {
                new HeaderValues(),
                new HeaderValues((string)null),
                new HeaderValues((string[])null),
                (string)null,
                (string[])null
            };

        public static HeaderValues[] EmptyStringValues =>
            new HeaderValues[]
            {
                HeaderValues.Empty,
                new HeaderValues(new string[0]),
                new string[0]
            };

        public static HeaderValues[] FilledStringValues =>
            new HeaderValues[]
            {
                new HeaderValues("abc"),
                new HeaderValues(new[] { "abc" }),
                new HeaderValues(new[] { "abc", "bcd" }),
                new HeaderValues(new[] { "abc", "bcd", "foo" }),
                "abc",
                new[] { "abc" },
                new[] { "abc", "bcd" },
                new[] { "abc", "bcd", "foo" }
            };

        public static object[] FilledStringValuesWithExpectedStrings =>
            new object[]
            {
                new object[] { default(HeaderValues), (string)null },
                new object[] { HeaderValues.Empty, (string)null },
                new object[] { new HeaderValues(new string[] { }), (string)null },
                new object[] { new HeaderValues(string.Empty), string.Empty },
                new object[] { new HeaderValues(new string[] { string.Empty }), string.Empty },
                new object[] { new HeaderValues("abc"), "abc" }
            };

        public static object[] FilledStringValuesWithExpectedObjects =>
            new object[]
            {
                new object[] { default(HeaderValues), (object)null },
                new object[] { HeaderValues.Empty, (object)null },
                new object[] { new HeaderValues(new string[] { }), (object)null },
                new object[] { new HeaderValues("abc"), (object)"abc" },
                new object[] { new HeaderValues("abc"), (object)new[] { "abc" } },
                new object[] { new HeaderValues(new[] { "abc" }), (object)new[] { "abc" } },
                new object[] { new HeaderValues(new[] { "abc", "bcd" }), (object)new[] { "abc", "bcd" } }
            };

        public static object[] FilledStringValuesWithExpected =>
            new object[]
            {
                new object[] { default(HeaderValues), new string[0] },
                new object[] { HeaderValues.Empty, new string[0] },
                new object[] { new HeaderValues(string.Empty), new[] { string.Empty } },
                new object[] { new HeaderValues("abc"), new[] { "abc" } },
                new object[] { new HeaderValues(new[] { "abc" }), new[] { "abc" } },
                new object[] { new HeaderValues(new[] { "abc", "bcd" }), new[] { "abc", "bcd" } },
                new object[] { new HeaderValues(new[] { "abc", "bcd", "foo" }), new[] { "abc", "bcd", "foo" } },
                new object[] { (HeaderValues)string.Empty, new[] { string.Empty } },
                new object[] { (HeaderValues)"abc", new[] { "abc" } },
                new object[] { (HeaderValues)new[] { "abc" }, new[] { "abc" } },
                new object[] { (HeaderValues)new[] { "abc", "bcd" }, new[] { "abc", "bcd" } },
                new object[] { (HeaderValues)new[] { "abc", "bcd", "foo" }, new[] { "abc", "bcd", "foo" } }
            };

        [TestCaseSource(nameof(DefaultOrNullStringValues))]
        [TestCaseSource(nameof(EmptyStringValues))]
        [TestCaseSource(nameof(FilledStringValues))]
        public void IsReadOnly_True(HeaderValues stringValues)
        {
            Assert.True(((IList<string>)stringValues).IsReadOnly);
            Assert.Throws<NotSupportedException>(() => ((IList<string>)stringValues)[0] = string.Empty);
            Assert.Throws<NotSupportedException>(() => ((ICollection<string>)stringValues).Add(string.Empty));
            Assert.Throws<NotSupportedException>(() => ((IList<string>)stringValues).Insert(0, string.Empty));
            Assert.Throws<NotSupportedException>(() => ((ICollection<string>)stringValues).Remove(string.Empty));
            Assert.Throws<NotSupportedException>(() => ((IList<string>)stringValues).RemoveAt(0));
            Assert.Throws<NotSupportedException>(() => ((ICollection<string>)stringValues).Clear());
        }

        [TestCaseSource(nameof(DefaultOrNullStringValues))]
        public void DefaultOrNull_ExpectedValues(HeaderValues stringValues)
        {
            Assert.Null((string[])stringValues);
        }

        [TestCaseSource(nameof(DefaultOrNullStringValues))]
        [TestCaseSource(nameof(EmptyStringValues))]
        public void DefaultNullOrEmpty_ExpectedValues(HeaderValues stringValues)
        {
            CollectionAssert.IsEmpty(stringValues);
            Assert.Null((string)stringValues);
            Assert.AreEqual((string)null, (string)stringValues);
            Assert.AreEqual(string.Empty, stringValues.ToString());
            Assert.AreEqual(new string[0], stringValues.ToArray());

            Assert.True(HeaderValues.IsNullOrEmpty(stringValues));
            Assert.Throws<IndexOutOfRangeException>(() => _ = stringValues[0]);
            Assert.Throws<IndexOutOfRangeException>(() => _ = ((IList<string>)stringValues)[0]);
            Assert.AreEqual(string.Empty, stringValues.ToString());
            Assert.AreEqual(-1, ((IList<string>)stringValues).IndexOf(null));
            Assert.AreEqual(-1, ((IList<string>)stringValues).IndexOf(string.Empty));
            Assert.AreEqual(-1, ((IList<string>)stringValues).IndexOf("not there"));
            Assert.False(((ICollection<string>)stringValues).Contains(null));
            Assert.False(((ICollection<string>)stringValues).Contains(string.Empty));
            Assert.False(((ICollection<string>)stringValues).Contains("not there"));
            Assert.IsEmpty(stringValues);
        }

        [Test]
        public void ImplicitStringConverter_Works()
        {
            string nullString = null;
            HeaderValues stringValues = nullString;
            CollectionAssert.IsEmpty(stringValues);
            Assert.Null((string)stringValues);
            Assert.Null((string[])stringValues);

            string aString = "abc";
            stringValues = aString;
            Assert.That(stringValues, Has.One.Items);
            Assert.AreEqual(aString, stringValues);
            Assert.AreEqual(aString, stringValues[0]);
            Assert.AreEqual(aString, ((IList<string>)stringValues)[0]);
            CollectionAssert.AreEqual(new string[] { aString }, stringValues);
        }

        [Test]
        public void ImplicitStringArrayConverter_Works()
        {
            string[] nullStringArray = null;
            HeaderValues stringValues = nullStringArray;
            CollectionAssert.IsEmpty(stringValues);
            Assert.Null((string)stringValues);
            Assert.Null((string[])stringValues);

            string aString = "abc";
            string[] aStringArray = new[] { aString };
            stringValues = aStringArray;
            Assert.That(stringValues, Has.One.Items);
            Assert.AreEqual(aString, stringValues);
            Assert.AreEqual(aString, stringValues[0]);
            Assert.AreEqual(aString, ((IList<string>)stringValues)[0]);
            CollectionAssert.AreEqual(aStringArray, stringValues);

            aString = "abc";
            string bString = "bcd";
            aStringArray = new[] { aString, bString };
            stringValues = aStringArray;
            Assert.AreEqual(2, stringValues.Count);
            Assert.AreEqual("abc,bcd", stringValues.ToString());
            CollectionAssert.AreEqual(aStringArray, stringValues);
        }


        [TestCaseSource(nameof(DefaultOrNullStringValues))]
        [TestCaseSource(nameof(EmptyStringValues))]
        public void DefaultNullOrEmpty_Enumerator(HeaderValues stringValues)
        {
            var e = stringValues.GetEnumerator();
            Assert.Null(e.Current);
            Assert.False(e.MoveNext());
            Assert.Null(e.Current);
            Assert.False(e.MoveNext());
            Assert.False(e.MoveNext());
            Assert.False(e.MoveNext());

            var e1 = ((IEnumerable<string>)stringValues).GetEnumerator();
            Assert.Null(e1.Current);
            Assert.False(e1.MoveNext());
            Assert.Null(e1.Current);
            Assert.False(e1.MoveNext());
            Assert.False(e1.MoveNext());
            Assert.False(e1.MoveNext());

            var e2 = ((IEnumerable)stringValues).GetEnumerator();
            Assert.Null(e2.Current);
            Assert.False(e2.MoveNext());
            Assert.Null(e2.Current);
            Assert.False(e2.MoveNext());
            Assert.False(e2.MoveNext());
            Assert.False(e2.MoveNext());
        }


        [TestCaseSource(nameof(FilledStringValuesWithExpected))]
        public void Enumerator(HeaderValues stringValues, string[] expected)
        {
            var e = stringValues.GetEnumerator();
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(e.MoveNext());
                Assert.AreEqual(expected[i], e.Current);
            }
            Assert.False(e.MoveNext());
            Assert.False(e.MoveNext());
            Assert.False(e.MoveNext());

            var e1 = ((IEnumerable<string>)stringValues).GetEnumerator();
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(e1.MoveNext());
                Assert.AreEqual(expected[i], e1.Current);
            }
            Assert.False(e1.MoveNext());
            Assert.False(e1.MoveNext());
            Assert.False(e1.MoveNext());

            var e2 = ((IEnumerable)stringValues).GetEnumerator();
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(e2.MoveNext());
                Assert.AreEqual(expected[i], e2.Current);
            }
            Assert.False(e2.MoveNext());
            Assert.False(e2.MoveNext());
            Assert.False(e2.MoveNext());
        }


        [TestCaseSource(nameof(FilledStringValuesWithExpected))]
        public void IndexOf(HeaderValues stringValues, string[] expected)
        {
            IList<string> list = stringValues;
            Assert.AreEqual(-1, list.IndexOf("not there"));
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(i, list.IndexOf(expected[i]));
            }
        }


        [TestCaseSource(nameof(FilledStringValuesWithExpected))]
        public void Contains(HeaderValues stringValues, string[] expected)
        {
            ICollection<string> collection = stringValues;
            Assert.False(collection.Contains("not there"));
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(collection.Contains(expected[i]));
            }
        }


        [TestCaseSource(nameof(DefaultOrNullStringValues))]
        [TestCaseSource(nameof(EmptyStringValues))]
        [TestCaseSource(nameof(FilledStringValues))]
        public void CopyTo_TooSmall(HeaderValues stringValues)
        {
            ICollection<string> collection = stringValues;
            string[] tooSmall = new string[0];

            if (collection.Count > 0)
            {
                Assert.Throws<ArgumentException>(() => collection.CopyTo(tooSmall, 0));
            }
        }


        [TestCaseSource(nameof(FilledStringValuesWithExpected))]
        public void CopyTo_CorrectSize(HeaderValues stringValues, string[] expected)
        {
            ICollection<string> collection = stringValues;
            string[] actual = new string[expected.Length];

            if (collection.Count > 0)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => collection.CopyTo(actual, -1));
                Assert.Throws<ArgumentException>(() => collection.CopyTo(actual, actual.Length + 1));
            }
            collection.CopyTo(actual, 0);
            Assert.AreEqual(expected, actual);
        }


        [TestCaseSource(nameof(DefaultOrNullStringValues))]
        [TestCaseSource(nameof(EmptyStringValues))]
        public void DefaultNullOrEmpty_Concat(HeaderValues stringValues)
        {
            string[] expected = new[] { "abc", "bcd", "foo" };
            HeaderValues expectedStringValues = new HeaderValues(expected);
            Assert.AreEqual(expected, HeaderValues.Concat(stringValues, expectedStringValues));
            Assert.AreEqual(expected, HeaderValues.Concat(expectedStringValues, stringValues));
            Assert.AreEqual(expected, HeaderValues.Concat((string)null, in expectedStringValues));
            Assert.AreEqual(expected, HeaderValues.Concat(in expectedStringValues, (string)null));

            string[] empty = new string[0];
            HeaderValues emptyStringValues = new HeaderValues(empty);
            Assert.AreEqual(empty, HeaderValues.Concat(stringValues, HeaderValues.Empty));
            Assert.AreEqual(empty, HeaderValues.Concat(HeaderValues.Empty, stringValues));
            Assert.AreEqual(empty, HeaderValues.Concat(stringValues, new HeaderValues()));
            Assert.AreEqual(empty, HeaderValues.Concat(new HeaderValues(), stringValues));
            Assert.AreEqual(empty, HeaderValues.Concat((string)null, in emptyStringValues));
            Assert.AreEqual(empty, HeaderValues.Concat(in emptyStringValues, (string)null));
        }


        [TestCaseSource(nameof(FilledStringValuesWithExpected))]
        public void Concat(HeaderValues stringValues, string[] array)
        {
            string[] filled = new[] { "abc", "bcd", "foo" };

            string[] expectedPrepended = array.Concat(filled).ToArray();
            Assert.AreEqual(expectedPrepended, HeaderValues.Concat(stringValues, new HeaderValues(filled)));

            string[] expectedAppended = filled.Concat(array).ToArray();
            Assert.AreEqual(expectedAppended, HeaderValues.Concat(new HeaderValues(filled), stringValues));

            HeaderValues values = stringValues;
            foreach (string s in filled)
            {
                values = HeaderValues.Concat(in values, s);
            }
            Assert.AreEqual(expectedPrepended, values);

            values = stringValues;
            foreach (string s in filled.Reverse())
            {
                values = HeaderValues.Concat(s, in values);
            }
            Assert.AreEqual(expectedAppended, values);
        }

        [Test]
        public void Equals_OperatorEqual()
        {
            var equalString = "abc";

            var equalStringArray = new string[] { equalString };
            var equalStringValues = new HeaderValues(equalString);
            var otherStringValues = new HeaderValues(equalString);
            var stringArray = new string[] { equalString, equalString };
            var stringValuesArray = new HeaderValues(stringArray);

            Assert.True(equalStringValues == otherStringValues);

            Assert.True(equalStringValues == equalString);
            Assert.True(equalString == equalStringValues);

            Assert.True(equalStringValues == equalStringArray);
            Assert.True(equalStringArray == equalStringValues);

            Assert.True(stringArray == stringValuesArray);
            Assert.True(stringValuesArray == stringArray);

            Assert.False(stringValuesArray == equalString);
            Assert.False(stringValuesArray == equalStringArray);
            Assert.False(stringValuesArray == equalStringValues);
        }

        [Test]
        public void Equals_OperatorNotEqual()
        {
            var equalString = "abc";

            var equalStringArray = new string[] { equalString };
            var equalStringValues = new HeaderValues(equalString);
            var otherStringValues = new HeaderValues(equalString);
            var stringArray = new string[] { equalString, equalString };
            var stringValuesArray = new HeaderValues(stringArray);

            Assert.False(equalStringValues != otherStringValues);

            Assert.False(equalStringValues != equalString);
            Assert.False(equalString != equalStringValues);

            Assert.False(equalStringValues != equalStringArray);
            Assert.False(equalStringArray != equalStringValues);

            Assert.False(stringArray != stringValuesArray);
            Assert.False(stringValuesArray != stringArray);

            Assert.True(stringValuesArray != equalString);
            Assert.True(stringValuesArray != equalStringArray);
            Assert.True(stringValuesArray != equalStringValues);
        }

        [Test]
        public void Equals_Instance()
        {
            var equalString = "abc";

            var equalStringArray = new string[] { equalString };
            var equalStringValues = new HeaderValues(equalString);
            var stringArray = new string[] { equalString, equalString };
            var stringValuesArray = new HeaderValues(stringArray);

            Assert.True(equalStringValues.Equals(equalStringValues));
            Assert.True(equalStringValues.Equals(equalString));
            Assert.True(equalStringValues.Equals(equalStringArray));
            Assert.True(stringValuesArray.Equals(stringArray));
        }


        [TestCaseSource(nameof(FilledStringValuesWithExpectedObjects))]
        public void Equals_ObjectEquals(HeaderValues stringValues, object obj)
        {
            Assert.True(stringValues == obj);
            Assert.True(obj == stringValues);
        }


        [TestCaseSource(nameof(FilledStringValuesWithExpectedObjects))]
        public void Equals_ObjectNotEquals(HeaderValues stringValues, object obj)
        {
            Assert.False(stringValues != obj);
            Assert.False(obj != stringValues);
        }


        [TestCaseSource(nameof(FilledStringValuesWithExpectedStrings))]
        public void Equals_String(HeaderValues stringValues, string expected)
        {
            var notEqual = new HeaderValues("bcd");

            Assert.True(HeaderValues.Equals(stringValues, expected));
            Assert.False(HeaderValues.Equals(stringValues, notEqual));
        }


        [TestCaseSource(nameof(FilledStringValuesWithExpected))]
        public void Equals_StringArray(HeaderValues stringValues, string[] expected)
        {
            var notEqual = new HeaderValues(new[] { "bcd", "abc" });

            Assert.True(HeaderValues.Equals(stringValues, expected));
            Assert.False(HeaderValues.Equals(stringValues, notEqual));
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class StringValuesTests
    {
        public static IEnumerable<object[]> DefaultOrNullStringValues = new List<object[]>
        {
            new object[] { new StringValues() },
            new object[] { new StringValues((string)null) },
            new object[] { new StringValues((string[])null) },
            new object[] { (string)null },
            new object[] { (string[])null }
        };

        public static IEnumerable<object[]> EmptyStringValues = new List<object[]>
        {
            new object[]{ StringValues.Empty},
            new object[]{ new StringValues(new string[0])},
            new object[]{ new string[0]}
        };

        public static IEnumerable<object> FilledStringValues = new List<object>
        {
            new StringValues("abc"),
            new StringValues(new[] { "abc" }),
            new StringValues(new[] { "abc", "bcd" }),
            new StringValues(new[] { "abc", "bcd", "foo" }),
            "abc",
            new[] { "abc" },
            new[] { "abc", "bcd" },
            new[] { "abc", "bcd", "foo" }
        };

        public static IEnumerable<object[]> FilledStringValuesWithExpectedStrings = new List<object[]>
        {
            new object[] { default(StringValues), (string)null },
            new object[] { StringValues.Empty, (string)null },
            new object[] { new StringValues(new string[] { }), (string)null },
            new object[] { new StringValues(string.Empty), string.Empty },
            new object[] { new StringValues(new string[] { string.Empty }), string.Empty },
            new object[] { new StringValues("abc"), "abc" }
        };

        public static IEnumerable<object[]> FilledStringValuesWithExpectedObjects = new List<object[]>
        {
            new object[] { default(StringValues), (object)null },
            new object[] { StringValues.Empty, (object)null },
            new object[] { new StringValues(new string[] { }), (object)null },
            new object[] { new StringValues("abc"), (object)"abc" },
            new object[] { new StringValues("abc"), (object)new[] { "abc" } },
            new object[] { new StringValues(new[] { "abc" }), (object)new[] { "abc" } },
            new object[] { new StringValues(new[] { "abc", "bcd" }), (object)new[] { "abc", "bcd" } }
        };

        public static IEnumerable<object[]> FilledStringValuesWithExpected = new List<object[]>
        {
            new object[] { default(StringValues), new string[0] },
            new object[] { StringValues.Empty, new string[0] },
            new object[] { new StringValues(string.Empty), new[] { string.Empty } },
            new object[] { new StringValues("abc"), new[] { "abc" } },
            new object[] { new StringValues(new[] { "abc" }), new[] { "abc" } },
            new object[] { new StringValues(new[] { "abc", "bcd" }), new[] { "abc", "bcd" } },
            new object[] { new StringValues(new[] { "abc", "bcd", "foo" }), new[] { "abc", "bcd", "foo" } },
            new object[] { string.Empty, new[] { string.Empty } },
            new object[] { "abc", new[] { "abc" } },
            new object[] { new[] { "abc" }, new[] { "abc" } },
            new object[] { new[] { "abc", "bcd" }, new[] { "abc", "bcd" } },
            new object[] { new[] { "abc", "bcd", "foo" }, new[] { "abc", "bcd", "foo" } },
            new object[] { new[] { null, "abc", "bcd", "foo" }, new[] { null, "abc", "bcd", "foo" } },
            new object[] { new[] { "abc", null, "bcd", "foo" }, new[] { "abc", null, "bcd", "foo" } },
            new object[] { new[] { "abc", "bcd", "foo", null }, new[] { "abc", "bcd", "foo", null } },
            new object[] { new[] { string.Empty, "abc", "bcd", "foo" }, new[] { string.Empty, "abc", "bcd", "foo" } },
            new object[] { new[] { "abc", string.Empty, "bcd", "foo" }, new[] { "abc", string.Empty, "bcd", "foo" } },
            new object[] { new[] { "abc", "bcd", "foo", string.Empty }, new[] { "abc", "bcd", "foo", string.Empty } }
        };

        public static IEnumerable<object[]> FilledStringValuesToStringToExpected = new List<object[]>
        {
            new object[] { default(StringValues), string.Empty },
            new object[] { StringValues.Empty, string.Empty },
            new object[] { new StringValues(string.Empty), string.Empty },
            new object[] { new StringValues("abc"), "abc" },
            new object[] { new StringValues(new[] { "abc" }), "abc" },
            new object[] { new StringValues(new[] { "abc", "bcd" }), "abc,bcd" },
            new object[] { new StringValues(new[] { "abc", "bcd", "foo" }), "abc,bcd,foo" },
            new object[] { string.Empty, string.Empty },
            new object[] { (string)null, string.Empty },
            new object[] { "abc","abc" },
            new object[] { new[] { "abc" }, "abc" },
            new object[] { new[] { "abc", "bcd" }, "abc,bcd" },
            new object[] { new[] { "abc", null, "bcd" }, "abc,bcd" },
            new object[] { new[] { "abc", string.Empty, "bcd" }, "abc,bcd" },
            new object[] { new[] { "abc", "bcd", "foo" }, "abc,bcd,foo" },
            new object[] { new[] { null, "abc", "bcd", "foo" }, "abc,bcd,foo" },
            new object[] { new[] { "abc", null, "bcd", "foo" }, "abc,bcd,foo" },
            new object[] { new[] { "abc", "bcd", "foo", null }, "abc,bcd,foo" },
            new object[] { new[] { string.Empty, "abc", "bcd", "foo" }, "abc,bcd,foo" },
            new object[] { new[] { "abc", string.Empty, "bcd", "foo" }, "abc,bcd,foo" },
            new object[] { new[] { "abc", "bcd", "foo", string.Empty }, "abc,bcd,foo" },
            new object[] { new[] { "abc", "bcd", "foo", string.Empty, null }, "abc,bcd,foo" }
        };

        [Theory]
        [TestCaseSource(nameof(DefaultOrNullStringValues))]
        [TestCaseSource(nameof(EmptyStringValues))]
        [TestCaseSource(nameof(FilledStringValues))]
        public void IsReadOnly_True(object stringValuesObj)
        {
            StringValues stringValues = ImplicitlyCastStringValues(stringValuesObj);
            Assert.True(((IList<string>)stringValues).IsReadOnly);
            Assert.Throws<NotSupportedException>(() => ((IList<string>)stringValues)[0] = string.Empty);
            Assert.Throws<NotSupportedException>(() => ((ICollection<string>)stringValues).Add(string.Empty));
            Assert.Throws<NotSupportedException>(() => ((IList<string>)stringValues).Insert(0, string.Empty));
            Assert.Throws<NotSupportedException>(() => ((IList<string>)stringValues).RemoveAt(0));
            Assert.Throws<NotSupportedException>(() => ((ICollection<string>)stringValues).Clear());
        }

        [Theory]
        [TestCaseSource(nameof(DefaultOrNullStringValues))]
        public void DefaultOrNull_ExpectedValues(object stringValuesObj)
        {
            StringValues stringValues = ImplicitlyCastStringValues(stringValuesObj);
            Assert.Null((string[])stringValues);
        }

        [Theory]
        [TestCaseSource(nameof(DefaultOrNullStringValues))]
        [TestCaseSource(nameof(EmptyStringValues))]
        public void DefaultNullOrEmpty_ExpectedValues(object stringValuesObj)
        {
            StringValues stringValues = ImplicitlyCastStringValues(stringValuesObj);
            Assert.That(stringValues, Is.EqualTo(StringValues.Empty));
            Assert.AreEqual(string.Empty, stringValues.ToString());
            Assert.AreEqual(new string[0], stringValues.ToArray());

            Assert.True(StringValues.IsNullOrEmpty(stringValues));
            Assert.Throws<IndexOutOfRangeException>(() => { var x = stringValues[0]; });
            Assert.Throws<IndexOutOfRangeException>(() => { var x = ((IList<string>)stringValues)[0]; });
            Assert.AreEqual(string.Empty, stringValues.ToString());
            Assert.AreEqual(-1, ((IList<string>)stringValues).IndexOf(null));
            Assert.AreEqual(-1, ((IList<string>)stringValues).IndexOf(string.Empty));
            Assert.AreEqual(-1, ((IList<string>)stringValues).IndexOf("not there"));
            Assert.False(((ICollection<string>)stringValues).Contains(null));
            Assert.False(((ICollection<string>)stringValues).Contains(string.Empty));
            Assert.False(((ICollection<string>)stringValues).Contains("not there"));
        }

        [Theory]
        [TestCaseSource(nameof(FilledStringValuesToStringToExpected))]
        public void ToString_ExpectedValues(object stringValuesObj, string expected)
        {
            StringValues stringValues = ImplicitlyCastStringValues(stringValuesObj);
            Assert.AreEqual(stringValues.ToString(), expected);
        }

        [Test]
        public void ImplicitStringConverter_Works()
        {
            string nullString = null;
            StringValues stringValues = nullString;
            Assert.That(stringValues, Is.EqualTo(StringValues.Empty));
            Assert.Null((string)stringValues);
            Assert.Null((string[])stringValues);

            string aString = "abc";
            stringValues = aString;
            Assert.AreEqual(1, stringValues.Count);
            Assert.AreEqual(aString, stringValues);
            Assert.AreEqual(aString, stringValues[0]);
            Assert.AreEqual(aString, ((IList<string>)stringValues)[0]);
            Assert.AreEqual(new string[] { aString }, stringValues);
        }

        [Test]
        public void GetHashCode_SingleValueVsArrayWithOneItem_SameHashCode()
        {
            var sv1 = new StringValues("value");
            var sv2 = new StringValues(new[] { "value" });
            Assert.AreEqual(sv1, sv2);
            Assert.AreEqual(sv1.GetHashCode(), sv2.GetHashCode());
        }

        [Test]
        public void GetHashCode_NullCases_DifferentHashCodes()
        {
            var sv1 = new StringValues((string)null);
            var sv2 = new StringValues(new[] { (string)null });
            Assert.AreNotEqual(sv1, sv2);
            Assert.AreNotEqual(sv1.GetHashCode(), sv2.GetHashCode());

            var sv3 = new StringValues((string[])null);
            Assert.AreEqual(sv1, sv3);
            Assert.AreEqual(sv1.GetHashCode(), sv3.GetHashCode());
        }

        [Test]
        public void GetHashCode_SingleValueVsArrayWithTwoItems_DifferentHashCodes()
        {
            var sv1 = new StringValues("value");
            var sv2 = new StringValues(new[] { "value", "value" });
            Assert.AreNotEqual(sv1, sv2);
            Assert.AreNotEqual(sv1.GetHashCode(), sv2.GetHashCode());
        }

        [Test]
        public void ImplicitStringArrayConverter_Works()
        {
            string[] nullStringArray = null;
            StringValues stringValues = nullStringArray;
            Assert.That(stringValues, Is.EqualTo(StringValues.Empty));
            Assert.Null((string)stringValues);
            Assert.Null((string[])stringValues);

            string aString = "abc";
            string[] aStringArray = new[] { aString };
            stringValues = aStringArray;
            Assert.AreEqual(1, stringValues.Count);
            Assert.AreEqual(aString, stringValues);
            Assert.AreEqual(aString, stringValues[0]);
            Assert.AreEqual(aString, ((IList<string>)stringValues)[0]);
            Assert.AreEqual(aStringArray, stringValues);

            aString = "abc";
            string bString = "bcd";
            aStringArray = new[] { aString, bString };
            stringValues = aStringArray;
            Assert.AreEqual(2, stringValues.Count);
            Assert.AreEqual("abc,bcd", stringValues.ToString());
            Assert.AreEqual(aStringArray, stringValues);
        }

        [Theory]
        [TestCaseSource(nameof(DefaultOrNullStringValues))]
        [TestCaseSource(nameof(EmptyStringValues))]
        public void DefaultNullOrEmpty_Enumerator(object stringValuesObj)
        {
            StringValues stringValues = ImplicitlyCastStringValues(stringValuesObj);
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

        [Theory]
        [TestCaseSource(nameof(FilledStringValuesWithExpected))]
        public void Enumerator(object stringValuesObj, string[] expected)
        {
            StringValues stringValues = ImplicitlyCastStringValues(stringValuesObj);
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

        [Test]
        public void Indexer()
        {
            StringValues sv;

            // Default empty
            sv = default;
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sv[0]; });
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sv[-1]; });

            // Empty with null string ctor
            sv = new StringValues((string)null);
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sv[0]; });
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sv[-1]; });
            // Empty with null string[] ctor
            sv = new StringValues((string[])null);
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sv[0]; });
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sv[-1]; });

            // Empty with array
            sv = Array.Empty<string>();
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sv[0]; });
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sv[-1]; });

            // One element with string
            sv = "hello";
            Assert.AreEqual("hello", sv[0]);
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sv[1]; });
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sv[-1]; });

            // One element with string[]
            sv = new string[] { "hello" };
            Assert.AreEqual("hello", sv[0]);
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sv[1]; });
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sv[-1]; });

            // One element with string[] containing null
            sv = new string[] { null };
            Assert.Null(sv[0]);
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sv[1]; });
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sv[-1]; });

            // Two elements with string[]
            sv = new string[] { "hello", "world" };
            Assert.AreEqual("hello", sv[0]);
            Assert.AreEqual("world", sv[1]);
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sv[2]; });
            Assert.Throws<IndexOutOfRangeException>(() => { var x = sv[-1]; });
        }

        [Theory]
        [TestCaseSource(nameof(FilledStringValuesWithExpected))]
        public void IndexOf(object stringValuesObj, string[] expected)
        {
            StringValues stringValues = ImplicitlyCastStringValues(stringValuesObj);
            IList<string> list = stringValues;
            Assert.AreEqual(-1, list.IndexOf("not there"));
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(i, list.IndexOf(expected[i]));
            }
        }

        [Theory]
        [TestCaseSource(nameof(FilledStringValuesWithExpected))]
        public void Contains(object stringValuesObj, string[] expected)
        {
            StringValues stringValues = ImplicitlyCastStringValues(stringValuesObj);

            ICollection<string> collection = stringValues;
            Assert.False(collection.Contains("not there"));
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(collection.Contains(expected[i]));
            }

        }

        private static StringValues ImplicitlyCastStringValues(object stringValuesObj)
        {
            StringValues stringValues = (string)null;
            if (stringValuesObj is StringValues strVal)
            {
                stringValues = strVal;
            }
            if (stringValuesObj is string[] strArr)
            {
                stringValues = strArr;
            }
            if (stringValuesObj is string str)
            {
                stringValues = str;
            }

            return stringValues;
        }

        [Theory]
        [TestCaseSource(nameof(DefaultOrNullStringValues))]
        [TestCaseSource(nameof(EmptyStringValues))]
        [TestCaseSource(nameof(FilledStringValues))]
        public void CopyTo_TooSmall(object stringValuesObj)
        {
            StringValues stringValues = ImplicitlyCastStringValues(stringValuesObj);
            ICollection<string> collection = stringValues;
            string[] tooSmall = new string[0];

            if (collection.Count > 0)
            {
                Assert.Throws<ArgumentException>(() => collection.CopyTo(tooSmall, 0));
            }
        }

        [Theory]
        [TestCaseSource(nameof(FilledStringValuesWithExpected))]
        public void CopyTo_CorrectSize(object stringValuesObj, string[] expected)
        {
            StringValues stringValues = ImplicitlyCastStringValues(stringValuesObj);
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

        [Theory]
        [TestCaseSource(nameof(DefaultOrNullStringValues))]
        [TestCaseSource(nameof(EmptyStringValues))]
        public void DefaultNullOrEmpty_Concat(object stringValuesObj)
        {
            StringValues stringValues = ImplicitlyCastStringValues(stringValuesObj);
            string[] expected = new[] { "abc", "bcd", "foo" };
            StringValues expectedStringValues = new StringValues(expected);
            Assert.AreEqual(expected, StringValues.Concat(stringValues, expectedStringValues));
            Assert.AreEqual(expected, StringValues.Concat(expectedStringValues, stringValues));
            Assert.AreEqual(expected, StringValues.Concat((string)null, in expectedStringValues));
            Assert.AreEqual(expected, StringValues.Concat(in expectedStringValues, (string)null));

            string[] empty = new string[0];
            StringValues emptyStringValues = new StringValues(empty);
            Assert.AreEqual(empty, StringValues.Concat(stringValues, StringValues.Empty));
            Assert.AreEqual(empty, StringValues.Concat(StringValues.Empty, stringValues));
            Assert.AreEqual(empty, StringValues.Concat(stringValues, new StringValues()));
            Assert.AreEqual(empty, StringValues.Concat(new StringValues(), stringValues));
            Assert.AreEqual(empty, StringValues.Concat((string)null, in emptyStringValues));
            Assert.AreEqual(empty, StringValues.Concat(in emptyStringValues, (string)null));
        }

        [Theory]
        [TestCaseSource(nameof(FilledStringValuesWithExpected))]
        public void Concat(object stringValuesObj, string[] array)
        {
            StringValues stringValues = ImplicitlyCastStringValues(stringValuesObj);
            string[] filled = new[] { "abc", "bcd", "foo" };

            string[] expectedPrepended = array.Concat(filled).ToArray();
            Assert.AreEqual(expectedPrepended, StringValues.Concat(stringValues, new StringValues(filled)));

            string[] expectedAppended = filled.Concat(array).ToArray();
            Assert.AreEqual(expectedAppended, StringValues.Concat(new StringValues(filled), stringValues));

            StringValues values = stringValues;
            foreach (string s in filled)
            {
                values = StringValues.Concat(in values, s);
            }
            Assert.AreEqual(expectedPrepended, values);

            values = stringValues;
            foreach (string s in filled.Reverse())
            {
                values = StringValues.Concat(s, in values);
            }
            Assert.AreEqual(expectedAppended, values);
        }

        [Test]
        public void Equals_OperatorEqual()
        {
            var equalString = "abc";

            var equalStringArray = new string[] { equalString };
            var equalStringValues = new StringValues(equalString);
            var otherStringValues = new StringValues(equalString);
            var stringArray = new string[] { equalString, equalString };
            var stringValuesArray = new StringValues(stringArray);

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
            var equalStringValues = new StringValues(equalString);
            var otherStringValues = new StringValues(equalString);
            var stringArray = new string[] { equalString, equalString };
            var stringValuesArray = new StringValues(stringArray);

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
            var equalStringValues = new StringValues(equalString);
            var stringArray = new string[] { equalString, equalString };
            var stringValuesArray = new StringValues(stringArray);

            Assert.True(equalStringValues.Equals(equalStringValues));
            Assert.True(equalStringValues.Equals(equalString));
            Assert.True(equalStringValues.Equals(equalStringArray));
            Assert.True(stringValuesArray.Equals(stringArray));
        }

        [Theory]
        [TestCaseSource(nameof(FilledStringValuesWithExpectedObjects))]
        public void Equals_ObjectEquals(object stringValuesObj, object obj)
        {
            StringValues stringValues = ImplicitlyCastStringValues(stringValuesObj);
            Assert.True(stringValues == obj);
            Assert.True(obj == stringValues);
        }

        [Theory]
        [TestCaseSource(nameof(FilledStringValuesWithExpectedObjects))]
        public void Equals_ObjectNotEquals(object stringValuesObj, object obj)
        {
            StringValues stringValues = ImplicitlyCastStringValues(stringValuesObj);
            Assert.False(stringValues != obj);
            Assert.False(obj != stringValues);
        }

        [Theory]
        [TestCaseSource(nameof(FilledStringValuesWithExpectedStrings))]
        public void Equals_String(object stringValuesObj, string expected)
        {
            StringValues stringValues = ImplicitlyCastStringValues(stringValuesObj);
            var notEqual = new StringValues("bcd");

            Assert.True(StringValues.Equals(stringValues, expected));
            Assert.False(StringValues.Equals(stringValues, notEqual));

            Assert.True(StringValues.Equals(stringValues, new StringValues(expected)));
            Assert.AreEqual(stringValues.GetHashCode(), new StringValues(expected).GetHashCode());
        }

        [Theory]
        [TestCaseSource(nameof(FilledStringValuesWithExpected))]
        public void Equals_StringArray(object stringValuesObj, string[] expected)
        {
            StringValues stringValues = ImplicitlyCastStringValues(stringValuesObj);
            var notEqual = new StringValues(new[] { "bcd", "abc" });

            Assert.True(StringValues.Equals(stringValues, expected));
            Assert.False(StringValues.Equals(stringValues, notEqual));

            Assert.True(StringValues.Equals(stringValues, new StringValues(expected)));
            Assert.AreEqual(stringValues.GetHashCode(), new StringValues(expected).GetHashCode());
        }
    }
}

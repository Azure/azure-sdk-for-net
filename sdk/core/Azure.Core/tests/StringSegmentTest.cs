// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class StringSegmentTest
    {
        [Test]
        public void StringSegment_Empty()
        {
            // Arrange & Act
            var segment = StringSegment.Empty;

            // Assert
            Assert.True(segment.HasValue);
            Assert.AreSame(string.Empty, segment.Value);
            Assert.AreEqual(0, segment.Offset);
            Assert.AreEqual(0, segment.Length);
        }

        [Test]
        public void StringSegment_ImplicitConvertFromString()
        {
            StringSegment segment = "Hello";

            Assert.True(segment.HasValue);
            Assert.AreEqual(0, segment.Offset);
            Assert.AreEqual(5, segment.Length);
            Assert.AreEqual("Hello", segment.Value);
        }

        [Test]
        public void StringSegment_AsSpan()
        {
            var segment = new StringSegment("Hello");

            var span = segment.AsSpan();

            Assert.AreEqual(5, span.Length);
        }

        [Test]
        public void StringSegment_ImplicitConvertToSpan()
        {
            ReadOnlySpan<char> span = new StringSegment("Hello");

            Assert.AreEqual(5, span.Length);
        }

        [Test]
        public void StringSegment_AsMemory()
        {
            var segment = new StringSegment("Hello");

            var memory = segment.AsMemory();

            Assert.AreEqual(5, memory.Length);
        }

        [Test]
        public void StringSegment_ImplicitConvertToMemory()
        {
            ReadOnlyMemory<char> memory = new StringSegment("Hello");

            Assert.AreEqual(5, memory.Length);
        }

        [Test]
        public void StringSegment_StringCtor_AllowsNullBuffers()
        {
            // Arrange & Act
            var segment = new StringSegment(null);

            // Assert
            Assert.False(segment.HasValue);
            Assert.AreEqual(0, segment.Offset);
            Assert.AreEqual(0, segment.Length);
        }

        [Test]
        public void StringSegmentConstructor_NullBuffer_Throws()
        {
            // Arrange, Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new StringSegment(null, 0, 0));
            Assert.That(exception.Message.Contains("buffer"));
        }

        [Test]
        public void StringSegmentConstructor_NegativeOffset_Throws()
        {
            // Arrange, Act and Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new StringSegment("", -1, 0));
            Assert.That(exception.Message.Contains("offset"));
        }

        [Test]
        public void StringSegmentConstructor_NegativeLength_Throws()
        {
            // Arrange, Act and Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new StringSegment("", 0, -1));
            Assert.That(exception.Message.Contains("length"));
        }

        [Test]
        [TestCase(0, 10)]
        [TestCase(10, 0)]
        [TestCase(5, 5)]
        [TestCase(int.MaxValue, int.MaxValue)]
        public void StringSegmentConstructor_OffsetOrLengthOutOfBounds_Throws(int offset, int length)
        {
            // Arrange, Act and Assert
            Assert.Throws<ArgumentException>(() => new StringSegment("lengthof9", offset, length));
        }

        [Test]
        [TestCase("", 0, 0)]
        [TestCase("abc", 2, 0)]
        public void StringSegmentConstructor_AllowsEmptyBuffers(string text, int offset, int length)
        {
            // Arrange & Act
            var segment = new StringSegment(text, offset, length);

            // Assert
            Assert.True(segment.HasValue);
            Assert.AreEqual(offset, segment.Offset);
            Assert.AreEqual(length, segment.Length);
        }

        [Test]
        public void StringSegment_StringCtor_InitializesValuesCorrectly()
        {
            // Arrange
            var buffer = "Hello world!";

            // Act
            var segment = new StringSegment(buffer);

            // Assert
            Assert.True(segment.HasValue);
            Assert.AreEqual(0, segment.Offset);
            Assert.AreEqual(buffer.Length, segment.Length);
        }

        [Test]
        public void StringSegment_Value_Valid()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 4);

            // Act
            var value = segment.Value;

            // Assert
            Assert.AreEqual("ello", value);
        }

        [Test]
        public void StringSegment_Value_Invalid()
        {
            // Arrange
            var segment = new StringSegment();

            // Act
            var value = segment.Value;

            // Assert
            Assert.Null(value);
        }

        [Test]
        public void StringSegment_HasValue_Valid()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 4);

            // Act
            var hasValue = segment.HasValue;

            // Assert
            Assert.True(hasValue);
        }

        [Test]
        public void StringSegment_HasValue_Invalid()
        {
            // Arrange
            var segment = new StringSegment();

            // Act
            var hasValue = segment.HasValue;

            // Assert
            Assert.False(hasValue);
        }

        [Test]
        [TestCase("a", 0, 1, 0, 'a')]
        [TestCase("abc", 1, 1, 0, 'b')]
        [TestCase("abcdef", 1, 4, 0, 'b')]
        [TestCase("abcdef", 1, 4, 1, 'c')]
        [TestCase("abcdef", 1, 4, 2, 'd')]
        [TestCase("abcdef", 1, 4, 3, 'e')]
        public void StringSegment_Indexer_InRange(string value, int offset, int length, int index, char expected)
        {
            var segment = new StringSegment(value, offset, length);

            var result = segment[index];

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("", 0, 0, 0)]
        [TestCase("a", 0, 1, -1)]
        [TestCase("a", 0, 1, 1)]
        public void StringSegment_Indexer_OutOfRangeThrows(string value, int offset, int length, int index)
        {
            var segment = new StringSegment(value, offset, length);
            Assert.Throws<ArgumentOutOfRangeException>(() => { var x = segment[index]; });
        }

        public static IEnumerable<object[]> EndsWithData = new List<object[]>
        {
            new object[] { "Hello", StringComparison.Ordinal, false },
            new object[] { "ello ", StringComparison.Ordinal, false },
            new object[] { "ll", StringComparison.Ordinal, false },
            new object[] { "ello", StringComparison.Ordinal, true },
            new object[] { "llo", StringComparison.Ordinal, true },
            new object[] { "lo", StringComparison.Ordinal, true },
            new object[] { "o", StringComparison.Ordinal, true },
            new object[] { string.Empty, StringComparison.Ordinal, true },
            new object[] { "eLLo", StringComparison.Ordinal, false },
            new object[] { "eLLo", StringComparison.OrdinalIgnoreCase, true },
        };

        [Test]
        [TestCaseSource(nameof(EndsWithData))]
        public void StringSegment_EndsWith_Valid(string candidate, StringComparison comparison, bool expectedResult)
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 4);

            // Act
            var result = segment.EndsWith(candidate, comparison);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void StringSegment_EndsWith_Invalid()
        {
            // Arrange
            var segment = new StringSegment();

            // Act
            var result = segment.EndsWith(string.Empty, StringComparison.Ordinal);

            // Assert
            Assert.False(result);
        }

        public static IEnumerable<object[]> StartsWithData = new List<object[]>
        {
            new object[] { "Hello", StringComparison.Ordinal, false },
            new object[] { "ello ", StringComparison.Ordinal, false },
            new object[] { "ll", StringComparison.Ordinal, false },
            new object[] { "ello", StringComparison.Ordinal, true },
            new object[] { "ell", StringComparison.Ordinal, true },
            new object[] { "el", StringComparison.Ordinal, true },
            new object[] { "e", StringComparison.Ordinal, true },
            new object[] { string.Empty, StringComparison.Ordinal, true },
            new object[] { "eLLo", StringComparison.Ordinal, false },
            new object[] { "eLLo", StringComparison.OrdinalIgnoreCase, true },
        };

        [Test]
        [TestCaseSource(nameof(StartsWithData))]
        public void StringSegment_StartsWith_Valid(string candidate, StringComparison comparison, bool expectedResult)
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 4);

            // Act
            var result = segment.StartsWith(candidate, comparison);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void StringSegment_StartsWith_Invalid()
        {
            // Arrange
            var segment = new StringSegment();

            // Act
            var result = segment.StartsWith(string.Empty, StringComparison.Ordinal);

            // Assert
            Assert.False(result);
        }

        public static IEnumerable<object[]> EqualsStringData = new List<object[]>
                {
                    new object[] { "eLLo", StringComparison.OrdinalIgnoreCase, true },
                    new object[] { "eLLo", StringComparison.Ordinal, false },
                };

        [Test]
        [TestCaseSource(nameof(EqualsStringData))]
        public void StringSegment_Equals_String_Valid(string candidate, StringComparison comparison, bool expectedResult)
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 4);

            // Act
            var result = segment.Equals(candidate, comparison);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void StringSegment_EqualsObject_Valid()
        {
            var segment1 = new StringSegment("My Car Is Cool", 3, 3);
            var segment2 = new StringSegment("Your Carport is blue", 5, 3);

            Assert.True(segment1.Equals((object)segment2));
        }

        [Test]
        public void StringSegment_EqualsNull_Invalid()
        {
            var segment1 = new StringSegment("My Car Is Cool", 3, 3);

            Assert.False(segment1.Equals(null as object));
        }

        [Test]
        public void StringSegment_StaticEquals_Valid()
        {
            var segment1 = new StringSegment("My Car Is Cool", 3, 3);
            var segment2 = new StringSegment("Your Carport is blue", 5, 3);

            Assert.True(StringSegment.Equals(segment1, segment2));
        }

        [Test]
        public void StringSegment_StaticEquals_Invalid()
        {
            var segment1 = new StringSegment("My Car Is Cool", 3, 4);
            var segment2 = new StringSegment("Your Carport is blue", 5, 4);

            Assert.False(StringSegment.Equals(segment1, segment2));
        }

        [Test]
        public void StringSegment_IsNullOrEmpty_Valid()
        {
            Assert.True(StringSegment.IsNullOrEmpty(null));
            Assert.True(StringSegment.IsNullOrEmpty(string.Empty));
            Assert.True(StringSegment.IsNullOrEmpty(new StringSegment(null)));
            Assert.True(StringSegment.IsNullOrEmpty(new StringSegment(string.Empty)));
            Assert.True(StringSegment.IsNullOrEmpty(StringSegment.Empty));
            Assert.True(StringSegment.IsNullOrEmpty(new StringSegment(string.Empty, 0, 0)));
            Assert.True(StringSegment.IsNullOrEmpty(new StringSegment("Hello", 0, 0)));
            Assert.True(StringSegment.IsNullOrEmpty(new StringSegment("Hello", 3, 0)));
        }

        [Test]
        public void StringSegment_IsNullOrEmpty_Invalid()
        {
            Assert.False(StringSegment.IsNullOrEmpty("A"));
            Assert.False(StringSegment.IsNullOrEmpty("ABCDefg"));
            Assert.False(StringSegment.IsNullOrEmpty(new StringSegment("A", 0, 1)));
            Assert.False(StringSegment.IsNullOrEmpty(new StringSegment("ABCDefg", 3, 2)));
        }

        public static IEnumerable<object[]> GetHashCode_ReturnsSameValueForEqualSubstringsData = new List<object[]>
        {
            new object[] { default(StringSegment), default(StringSegment) },
            new object[] { default(StringSegment), new StringSegment() },
            new object[] { new StringSegment("Test123", 0, 0), new StringSegment(string.Empty) },
            new object[] { new StringSegment("C`est si bon", 2, 3), new StringSegment("Yesterday", 1, 3) },
            new object[] { new StringSegment("Hello", 1, 4), new StringSegment("Hello world", 1, 4) },
            new object[] { new StringSegment("Hello"), new StringSegment("Hello", 0, 5) },
        };

        [Test]
        [TestCaseSource(nameof(GetHashCode_ReturnsSameValueForEqualSubstringsData))]
        public void GetHashCode_ReturnsSameValueForEqualSubstrings(object segment1, object segment2)
        {
            // Act
            var hashCode1 = segment1.GetHashCode();
            var hashCode2 = segment2.GetHashCode();

            // Assert
            Assert.AreEqual(hashCode1, hashCode2);
        }

        public static string testString = "Test123";

        public static IEnumerable<object[]> GetHashCode_ReturnsDifferentValuesForInequalSubstringsData = new List<object[]>
        {
            new object[] { new StringSegment(testString, 0, 1), new StringSegment(string.Empty) },
            new object[] { new StringSegment(testString, 0, 1), new StringSegment(testString, 1, 1) },
            new object[] { new StringSegment(testString, 1, 2), new StringSegment(testString, 1, 3) },
            new object[] { new StringSegment(testString, 0, 4), new StringSegment("TEST123", 0, 4) },
        };

        [Test]
        [TestCaseSource(nameof(GetHashCode_ReturnsDifferentValuesForInequalSubstringsData))]
        public void GetHashCode_ReturnsDifferentValuesForInequalSubstrings(
            object segment1,
            object segment2)
        {
            // Act
            var hashCode1 = segment1.GetHashCode();
            var hashCode2 = segment2.GetHashCode();

            // Assert
            Assert.AreNotEqual(hashCode1, hashCode2);
        }

        [Test]
        public void StringSegment_EqualsString_Invalid()
        {
            // Arrange
            var segment = new StringSegment();

            // Act
            var result = segment.Equals(string.Empty, StringComparison.Ordinal);

            // Assert
            Assert.False(result);
        }

        public static IEnumerable<object[]> DefaultStringSegmentEqualsStringSegmentData = new List<object[]>
                {
                    new object[] { default(StringSegment) },
                    new object[] { new StringSegment() },
                };

        [Test]
        [TestCaseSource(nameof(DefaultStringSegmentEqualsStringSegmentData))]
        public void DefaultStringSegment_EqualsStringSegment(object candidate)
        {
            // Arrange
            var segment = default(StringSegment);

            // Act
            var result = segment.Equals((StringSegment)candidate, StringComparison.Ordinal);

            // Assert
            Assert.True(result);
        }

        public static IEnumerable<object[]> DefaultStringSegmentDoesNotEqualStringSegmentData = new List<object[]>
                {
                    new object[] { new StringSegment("Hello, World!", 1, 4) },
                    new object[] { new StringSegment("Hello", 1, 0) },
                    new object[] { new StringSegment(string.Empty) },
                };

        [Test]
        [TestCaseSource(nameof(DefaultStringSegmentDoesNotEqualStringSegmentData))]
        public void DefaultStringSegment_DoesNotEqualStringSegment(object candidate)
        {
            // Arrange
            var segment = default(StringSegment);

            // Act
            var result = segment.Equals((StringSegment)candidate, StringComparison.Ordinal);

            // Assert
            Assert.False(result);
        }

        public static IEnumerable<object[]> DefaultStringSegmentDoesNotEqualStringData = new List<object[]>
                {
                    new object[] { string.Empty },
                    new object[] { "Hello, World!" },
                };

        [Test]
        [TestCaseSource(nameof(DefaultStringSegmentDoesNotEqualStringData))]
        public void DefaultStringSegment_DoesNotEqualString(string candidate)
        {
            // Arrange
            var segment = default(StringSegment);

            // Act
            var result = segment.Equals(candidate, StringComparison.Ordinal);

            // Assert
            Assert.False(result);
        }

        public static IEnumerable<object[]> EqualsStringSegmentData = new List<object[]>
        {
            new object[] { new StringSegment("Hello, World!", 1, 4), StringComparison.Ordinal, true },
            new object[] { new StringSegment("HELlo, World!", 1, 4), StringComparison.Ordinal, false },
            new object[] { new StringSegment("HELlo, World!", 1, 4), StringComparison.OrdinalIgnoreCase, true },
            new object[] { new StringSegment("ello, World!", 0, 4), StringComparison.Ordinal, true },
            new object[] { new StringSegment("ello, World!", 0, 3), StringComparison.Ordinal, false },
            new object[] { new StringSegment("ello, World!", 1, 3), StringComparison.Ordinal, false },
        };

        [Test]
        [TestCaseSource(nameof(EqualsStringSegmentData))]
        public void StringSegment_Equals_StringSegment_Valid(object candidate, StringComparison comparison, bool expectedResult)
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 4);

            // Act
            var result = segment.Equals((StringSegment)candidate, comparison);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void StringSegment_EqualsStringSegment_Invalid()
        {
            // Arrange
            var segment = new StringSegment();
            var candidate = new StringSegment("Hello, World!", 3, 2);

            // Act
            var result = segment.Equals(candidate, StringComparison.Ordinal);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void StringSegment_SubstringOffset_Valid()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 4);

            // Act
            var result = segment.Substring(offset: 1);

            // Assert
            Assert.AreEqual("llo", result);
        }

        [Test]
        public void StringSegment_Substring_Valid()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 4);

            // Act
            var result = segment.Substring(offset: 1, length: 2);

            // Assert
            Assert.AreEqual("ll", result);
        }

        [Test]
        public void StringSegment_Substring_Invalid()
        {
            // Arrange
            var segment = new StringSegment();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => segment.Substring(0, 0));
        }

        [Test]
        public void StringSegment_Substring_InvalidOffset()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 3);

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => segment.Substring(-1, 1));
            Assert.AreEqual("offset", exception.ParamName);
        }

        [Test]
        public void StringSegment_Substring_InvalidLength()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 3);

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => segment.Substring(0, -1));
            Assert.AreEqual("length", exception.ParamName);
        }

        [Test]
        public void StringSegment_Substring_InvalidOffsetAndLength()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 3);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => segment.Substring(2, 3));
            Assert.That(exception.Message.Contains("bounds"));
        }

        [Test]
        public void StringSegment_Substring_OffsetAndLengthOverflows()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 3);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => segment.Substring(1, int.MaxValue));
            Assert.That(exception.Message.Contains("bounds"));
        }

        [Test]
        public void StringSegment_SubsegmentOffset_Valid()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 4);

            // Act
            var result = segment.Subsegment(offset: 1);

            // Assert
            Assert.AreEqual(new StringSegment("Hello, World!", 2, 3), result);
            Assert.AreEqual("llo", result.Value);
        }

        [Test]
        public void StringSegment_Subsegment_Valid()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 4);

            // Act
            var result = segment.Subsegment(offset: 1, length: 2);

            // Assert
            Assert.AreEqual(new StringSegment("Hello, World!", 2, 2), result);
            Assert.AreEqual("ll", result.Value);
        }

        [Test]
        public void StringSegment_Subsegment_Invalid()
        {
            // Arrange
            var segment = new StringSegment();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => segment.Subsegment(0, 0));
        }

        [Test]
        public void StringSegment_Subsegment_InvalidOffset()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 3);

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => segment.Subsegment(-1, 1));
            Assert.AreEqual("offset", exception.ParamName);
        }

        [Test]
        public void StringSegment_Subsegment_InvalidLength()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 3);

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => segment.Subsegment(0, -1));
            Assert.AreEqual("length", exception.ParamName);
        }

        [Test]
        public void StringSegment_Subsegment_InvalidOffsetAndLength()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 3);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => segment.Subsegment(2, 3));
            Assert.That(exception.Message.Contains("bounds"));
        }

        [Test]
        public void StringSegment_Subsegment_OffsetAndLengthOverflows()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 3);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => segment.Subsegment(1, int.MaxValue));
            Assert.That(exception.Message.Contains("bounds"));
        }

        public static IEnumerable<object[]> CompareLesserData = new List<object[]>
        {
            new object[] { new StringSegment("abcdef", 1, 4), StringSegmentComparer.Ordinal },
            new object[] { new StringSegment("abcdef", 1, 5), StringSegmentComparer.OrdinalIgnoreCase },
            new object[] { new StringSegment("ABCDEF", 2, 2), StringSegmentComparer.OrdinalIgnoreCase },
        };

        [Test]
        [TestCaseSource(nameof(CompareLesserData))]
        public void StringSegment_Compare_Lesser(object candidate, object comparer)
        {
            // Arrange
            var segment = new StringSegment("ABCDEF", 1, 4);

            // Act
            var result = ((StringSegmentComparer)comparer).Compare(segment, (StringSegment)candidate);

            // Assert
            Assert.True(result < 0, $"{segment} should be less than {candidate}");
        }

        public static IEnumerable<object[]> CompareEqualData = new List<object[]>
        {
            new object[] { new StringSegment("abcdef", 1, 4), StringSegmentComparer.Ordinal },
            new object[] { new StringSegment("ABCDEF", 1, 4), StringSegmentComparer.OrdinalIgnoreCase },
            new object[] { new StringSegment("bcde", 0, 4), StringSegmentComparer.Ordinal },
            new object[] { new StringSegment("BcDeF", 0, 4), StringSegmentComparer.OrdinalIgnoreCase },
        };

        [Test]
        [TestCaseSource(nameof(CompareEqualData))]
        public void StringSegment_Compare_Equal(object candidate, object comparer)
        {
            // Arrange
            var segment = new StringSegment("abcdef", 1, 4);

            // Act
            var result = ((StringSegmentComparer)comparer).Compare(segment, (StringSegment)candidate);

            // Assert
            Assert.True(result == 0, $"{segment} should equal {candidate}");
        }

        public static IEnumerable<object[]> CompareGreaterData = new List<object[]>
        {
            new object[] { new StringSegment("ABCDEF", 1, 4), StringSegmentComparer.Ordinal },
            new object[] { new StringSegment("ABCDEF", 0, 6), StringSegmentComparer.OrdinalIgnoreCase },
            new object[] { new StringSegment("abcdef", 0, 3), StringSegmentComparer.Ordinal },
        };

        [Test]
        [TestCaseSource(nameof(CompareGreaterData))]
        public void StringSegment_Compare_Greater(object candidate, object comparer)
        {
            // Arrange
            var segment = new StringSegment("abcdef", 1, 4);

            // Act
            var result = ((StringSegmentComparer)comparer).Compare(segment, (StringSegment)candidate);

            // Assert
            Assert.True(result > 0, $"{segment} should be greater than {candidate}");
        }

        [Test]
        [TestCaseSource(nameof(GetHashCode_ReturnsSameValueForEqualSubstringsData))]
        public void StringSegmentComparerOrdinal_GetHashCode_ReturnsSameValueForEqualSubstrings(object segment1, object segment2)
        {
            // Arrange
            var comparer = StringSegmentComparer.Ordinal;

            // Act
            var hashCode1 = comparer.GetHashCode((StringSegment)segment1);
            var hashCode2 = comparer.GetHashCode((StringSegment)segment2);

            // Assert
            Assert.AreEqual(hashCode1, hashCode2);
        }

        [Test]
        [TestCaseSource(nameof(GetHashCode_ReturnsSameValueForEqualSubstringsData))]
        public void StringSegmentComparerOrdinalIgnoreCase_GetHashCode_ReturnsSameValueForEqualSubstrings(object segment1, object segment2)
        {
            // Arrange
            var comparer = StringSegmentComparer.OrdinalIgnoreCase;

            // Act
            var hashCode1 = comparer.GetHashCode((StringSegment)segment1);
            var hashCode2 = comparer.GetHashCode((StringSegment)segment2);

            // Assert
            Assert.AreEqual(hashCode1, hashCode2);
        }

        [Test]
        public void StringSegmentComparerOrdinalIgnoreCase_GetHashCode_ReturnsSameValueForDifferentlyCasedStrings()
        {
            // Arrange
            var segment1 = new StringSegment("abc");
            var segment2 = new StringSegment("Abcd", 0, 3);
            var comparer = StringSegmentComparer.OrdinalIgnoreCase;

            // Act
            var hashCode1 = comparer.GetHashCode(segment1);
            var hashCode2 = comparer.GetHashCode(segment2);

            // Assert
            Assert.AreEqual(hashCode1, hashCode2);
        }

        [Test]
        [TestCaseSource(nameof(GetHashCode_ReturnsDifferentValuesForInequalSubstringsData))]
        public void StringSegmentComparerOrdinal_GetHashCode_ReturnsDifferentValuesForInequalSubstrings(object segment1, object segment2)
        {
            // Arrange
            var comparer = StringSegmentComparer.Ordinal;

            // Act
            var hashCode1 = comparer.GetHashCode((StringSegment)segment1);
            var hashCode2 = comparer.GetHashCode((StringSegment)segment2);

            // Assert
            Assert.AreNotEqual(hashCode1, hashCode2);
        }

        [Test]
        public void IndexOf_ComputesIndex_RelativeToTheCurrentSegment()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 10);

            // Act
            var result = segment.IndexOf(',');

            // Assert
            Assert.AreEqual(4, result);
        }

        [Test]
        public void IndexOf_ReturnsMinusOne_IfElementNotInSegment()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 3);

            // Act
            var result = segment.IndexOf(',');

            // Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void IndexOf_SkipsANumberOfCaracters_IfStartIsProvided()
        {
            // Arrange
            const string buffer = "Hello, World!, Hello people!";
            var segment = new StringSegment(buffer, 3, buffer.Length - 3);

            // Act
            var result = segment.IndexOf('!', 15);

            // Assert
            Assert.AreEqual(buffer.Length - 4, result);
        }

        [Test]
        public void IndexOf_SearchOnlyInsideTheRange_IfStartAndCountAreProvided()
        {
            // Arrange
            const string buffer = "Hello, World!, Hello people!";
            var segment = new StringSegment(buffer, 3, buffer.Length - 3);

            // Act
            var result = segment.IndexOf('!', 15, 5);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void IndexOf_NegativeStart_OutOfRangeThrows()
        {
            // Arrange
            const string buffer = "Hello, World!, Hello people!";
            var segment = new StringSegment(buffer, 3, buffer.Length - 3);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => segment.IndexOf('!', -1, 3));
        }

        [Test]
        public void IndexOf_StartOverflowsWithOffset_OutOfRangeThrows()
        {
            // Arrange
            const string buffer = "Hello, World!, Hello people!";
            var segment = new StringSegment(buffer, 3, buffer.Length - 3);

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => segment.IndexOf('!', int.MaxValue, 3));
            Assert.AreEqual("start", exception.ParamName);
        }

        [Test]
        public void IndexOfAny_ComputesIndex_RelativeToTheCurrentSegment()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 10);

            // Act
            var result = segment.IndexOfAny(new[] { ',' });

            // Assert
            Assert.AreEqual(4, result);
        }

        [Test]
        public void IndexOfAny_ReturnsMinusOne_IfElementNotInSegment()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 3);

            // Act
            var result = segment.IndexOfAny(new[] { ',' });

            // Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void IndexOfAny_SkipsANumberOfCaracters_IfStartIsProvided()
        {
            // Arrange
            const string buffer = "Hello, World!, Hello people!";
            var segment = new StringSegment(buffer, 3, buffer.Length - 3);

            // Act
            var result = segment.IndexOfAny(new[] { '!' }, 15);

            // Assert
            Assert.AreEqual(buffer.Length - 4, result);
        }

        [Test]
        public void IndexOfAny_SearchOnlyInsideTheRange_IfStartAndCountAreProvided()
        {
            // Arrange
            const string buffer = "Hello, World!, Hello people!";
            var segment = new StringSegment(buffer, 3, buffer.Length - 3);

            // Act
            var result = segment.IndexOfAny(new[] { '!' }, 15, 5);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void LastIndexOf_ComputesIndex_RelativeToTheCurrentSegment()
        {
            // Arrange
            var segment = new StringSegment("Hello, World, how, are, you!", 1, 14);

            // Act
            var result = segment.LastIndexOf(',');

            // Assert
            Assert.AreEqual(11, result);
        }

        [Test]
        public void LastIndexOf_ReturnsMinusOne_IfElementNotInSegment()
        {
            // Arrange
            var segment = new StringSegment("Hello, World!", 1, 3);

            // Act
            var result = segment.LastIndexOf(',');

            // Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Value_DoesNotAllocateANewString_IfTheSegmentContainsTheWholeBuffer()
        {
            // Arrange
            const string buffer = "Hello, World!";
            var segment = new StringSegment(buffer);

            // Act
            var result = segment.Value;

            // Assert
            Assert.AreSame(buffer, result);
        }

        [Test]
        public void StringSegment_CreateEmptySegment()
        {
            // Arrange
            var segment = new StringSegment("//", 1, 0);

            // Assert
            Assert.True(segment.HasValue);
        }

        [Test]
        [TestCase("   value", 0, 8, "value")]
        [TestCase("value   ", 0, 8, "value")]
        [TestCase("\t\tvalue", 0, 7, "value")]
        [TestCase("value\t\t", 0, 7, "value")]
        [TestCase("\t\tvalue \t a", 1, 8, "value")]
        [TestCase("   a     ", 0, 9, "a")]
        [TestCase("value\t value  value ", 2, 13, "lue\t value  v")]
        [TestCase("\x0009value \x0085", 0, 8, "value")]
        [TestCase(" \f\t\u000B\u2028Hello \u2029\n\t ", 1, 13, "Hello")]
        [TestCase("      ", 1, 2, "")]
        [TestCase("\t\t\t", 0, 3, "")]
        [TestCase("\n\n\t\t  \t", 2, 3, "")]
        [TestCase("      ", 1, 0, "")]
        [TestCase("", 0, 0, "")]
        public void Trim_RemovesLeadingAndTrailingWhitespaces(string value, int start, int length, string expected)
        {
            // Arrange
            var segment = new StringSegment(value, start, length);

            // Act
            var actual = segment.Trim();

            // Assert
            Assert.AreEqual(expected, actual.Value);
        }

        [Test]
        [TestCase("   value", 0, 8, "value")]
        [TestCase("value   ", 0, 8, "value   ")]
        [TestCase("\t\tvalue", 0, 7, "value")]
        [TestCase("value\t\t", 0, 7, "value\t\t")]
        [TestCase("\t\tvalue \t a", 1, 8, "value \t")]
        [TestCase("   a     ", 0, 9, "a     ")]
        [TestCase("value\t value  value ", 2, 13, "lue\t value  v")]
        [TestCase("\x0009value \x0085", 0, 8, "value \x0085")]
        [TestCase(" \f\t\u000B\u2028Hello \u2029\n\t ", 1, 13, "Hello \u2029\n\t")]
        [TestCase("      ", 1, 2, "")]
        [TestCase("\t\t\t", 0, 3, "")]
        [TestCase("\n\n\t\t  \t", 2, 3, "")]
        [TestCase("      ", 1, 0, "")]
        [TestCase("", 0, 0, "")]
        public void TrimStart_RemovesLeadingWhitespaces(string value, int start, int length, string expected)
        {
            // Arrange
            var segment = new StringSegment(value, start, length);

            // Act
            var actual = segment.TrimStart();

            // Assert
            Assert.AreEqual(expected, actual.Value);
        }

        [Test]
        [TestCase("   value", 0, 8, "   value")]
        [TestCase("value   ", 0, 8, "value")]
        [TestCase("\t\tvalue", 0, 7, "\t\tvalue")]
        [TestCase("value\t\t", 0, 7, "value")]
        [TestCase("\t\tvalue \t a", 1, 8, "\tvalue")]
        [TestCase("   a     ", 0, 9, "   a")]
        [TestCase("value\t value  value ", 2, 13, "lue\t value  v")]
        [TestCase("\x0009value \x0085", 0, 8, "\x0009value")]
        [TestCase(" \f\t\u000B\u2028Hello \u2029\n\t ", 1, 13, "\f\t\u000B\u2028Hello")]
        [TestCase("      ", 1, 2, "")]
        [TestCase("\t\t\t", 0, 3, "")]
        [TestCase("\n\n\t\t  \t", 2, 3, "")]
        [TestCase("      ", 1, 0, "")]
        [TestCase("", 0, 0, "")]
        public void TrimEnd_RemovesTrailingWhitespaces(string value, int start, int length, string expected)
        {
            // Arrange
            var segment = new StringSegment(value, start, length);

            // Act
            var actual = segment.TrimEnd();

            // Assert
            Assert.AreEqual(expected, actual.Value);
        }
    }
}

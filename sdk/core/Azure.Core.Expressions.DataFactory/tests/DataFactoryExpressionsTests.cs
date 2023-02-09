// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using NUnit.Framework;

#nullable enable

namespace Azure.Core.Expressions.DataFactory.Tests
{
    public class DataFactoryExpressionsTests
    {
        private class MyObject
        {
            public MyObject(int x, string y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public string Y { get; set; }

            public override bool Equals(object? obj)
            {
                if (obj is null)
                    return false;
                if (obj is not MyObject that)
                    return false;

                return X == that.X && Y == that.Y;
            }

            public override int GetHashCode()
            {
#if NET461_OR_GREATER
                return X.GetHashCode() ^ Y.GetHashCode();
#else
                return HashCode.Combine(X, Y);
#endif
            }
        }

        private const string IntJson = "1";
        private const string ListOfStringJson = "[\"a\",\"b\"]";
        private const string EmptyListJson = "[]";
        private const string BoolJson = "true";

        private const string DoubleJson = "1.1";
        private const string StringJson = "\"a\"";
        private const string ExpressionJson = "{\"type\":\"Expression\",\"value\":\"@{myExpression}\"}";
        private const string NullJson = "null";
        private const string DictionaryJson = "{\"key1\":\"value1\",\"key2\":\"value2\"}";

        private const int IntValue = 1;
        private static readonly TimeSpan TimeSpanValue = TimeSpan.FromSeconds(5);
        private static readonly DateTimeOffset DateTimeOffsetValue = DateTimeOffset.UtcNow;
        private static readonly Uri UriValue = new Uri("https://example.com");
        private static readonly Dictionary<string, string> DictionaryValue = new()
        {
            { "key1", "value1" },
            { "key2", "value2" }
        };
        private static readonly List<string> ListOfStringValue = new List<string> { "a", "b" };
        private static readonly IList<string> EmptyListOfStringValue = new List<string>();
        private const bool BoolValue = true;
        private const double DoubleValue = 1.1;
        private const string StringValue = "a";
        private const string ExpressionValue = "@{myExpression}";

        private static string TimeSpanJson = $"\"{TimeSpanValue.ToString()}\"";
        private static string DateTimeOffsetJson = $"\"{TypeFormatters.ToString(DateTimeOffsetValue, "O")}\"";
        private static string UriJson = $"\"{UriValue!.AbsoluteUri}\"";

        [Test]
        public void CreateFromIntLiteral()
        {
            DataFactoryExpression<int> dfe = new DataFactoryExpression<int>(IntValue);
            AssertIntDfe(dfe);

            dfe = IntValue;
            AssertIntDfe(dfe);
        }

        [Test]
        public void CreateFromListOfStringLiteral()
        {
            var dfe = new DataFactoryExpression<IList<string>>(ListOfStringValue);
            AssertListOfStringDfe(dfe);

            dfe = ListOfStringValue;
            AssertListOfStringDfe(dfe);
        }

        [Test]
        public void CreateFromBoolLiteral()
        {
            var dfe = new DataFactoryExpression<bool>(BoolValue);
            AssertBoolDfe(dfe);

            dfe = BoolValue;
            AssertBoolDfe(dfe);
        }

        [Test]
        public void CreateFromDoubleLiteral()
        {
            var dfe = new DataFactoryExpression<double>(DoubleValue);
            AssertDoubleDfe(dfe);

            dfe = DoubleValue;
            AssertDoubleDfe(dfe);
        }

        [Test]
        public void CreateFromStringLiteral()
        {
            var dfe = new DataFactoryExpression<string?>(StringValue);
            AssertStringDfe(dfe, StringValue);

            dfe = StringValue;
            AssertStringDfe(dfe, StringValue);
        }

        [Test]
        public void CreateFromDateTimeOffsetLiteral()
        {
            var dfe = new DataFactoryExpression<DateTimeOffset?>(DateTimeOffsetValue);
            AssertDfe(dfe, DateTimeOffsetValue);

            dfe = DateTimeOffsetValue;
            AssertDfe(dfe, DateTimeOffsetValue);
        }

        [Test]
        public void CreateFromTimespanLiteral()
        {
            var dfe = new DataFactoryExpression<TimeSpan?>(TimeSpanValue);
            AssertDfe(dfe, TimeSpanValue);

            dfe = TimeSpanValue;
            AssertDfe(dfe, TimeSpanValue);
        }

        [Test]
        public void CreateFromUriLiteral()
        {
            var dfe = new DataFactoryExpression<Uri?>(UriValue);
            AssertDfe(dfe, UriValue);

            dfe = UriValue;
            AssertDfe(dfe, UriValue);
        }

        [Test]
        public void CreateFromDictionaryLiteral()
        {
            var dfe = new DataFactoryExpression<IDictionary<string, string>?>(DictionaryValue);
            AssertDfe(dfe, DictionaryValue);

            dfe = DictionaryValue;
            AssertDfe(dfe, DictionaryValue);
        }

        [Test]
        public void CreateFromListOfTLiteral()
        {
            var literal = new List<TestModel>
            {
                new TestModel { A = 1, B = true },
                new TestModel { A = 2, B = false }
            };            var dfe = new DataFactoryExpression<IList<TestModel>>(literal);
            AssertDfe(dfe, literal);

            dfe = literal;
            AssertDfe(dfe, literal);
        }

        [Test]
        public void IncorrectlyUseExpressionAsLiteralString()
        {
            var dfe = new DataFactoryExpression<string?>(ExpressionValue);
            AssertStringDfe(dfe, ExpressionValue);

            dfe = ExpressionValue;
            AssertStringDfe(dfe, ExpressionValue);
        }

        [Test]
        public void CreateFromExpression()
        {
            var dfe = DataFactoryExpression<string?>.FromExpression(ExpressionValue);
            AssertExpressionDfe(dfe);
        }

        [Test]
        public void NullValueForString()
        {
            var dfe = new DataFactoryExpression<string>(null);
            Assert.IsTrue(dfe.HasLiteral);
            Assert.AreEqual(null, dfe.Literal);
            Assert.AreEqual(null, dfe.ToString());
        }

        [Test]
        public void NullValueForArray()
        {
            var dfe = new DataFactoryExpression<Array>(null);
            Assert.IsTrue(dfe.HasLiteral);
            Assert.AreEqual(null, dfe.Literal);
            Assert.AreEqual(null, dfe.ToString());
        }

        [Test]
        public void EmptyValueForListOfString()
        {
            var dfe = new DataFactoryExpression<IList<string>>(EmptyListOfStringValue);
            AssertEmptyListOfStringDfe(dfe);
        }

        private static void AssertEmptyListOfStringDfe(DataFactoryExpression<IList<string>> dfe)
        {
            Assert.IsTrue(dfe.HasLiteral);
            Assert.AreEqual(dfe.Literal!.Count, 0);
            Assert.AreEqual("System.Collections.Generic.List`1[System.String]", dfe.ToString());
        }

        [Test]
        public void SerializationOfIntValue()
        {
            var dfe = new DataFactoryExpression<int>(IntValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(IntJson, actual);
        }

        [Test]
        public void SerializationOfNullableIntValue()
        {
            var dfe = new DataFactoryExpression<int?>(null);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual("null", actual);
        }

        [Test]
        public void SerializationOfBoolValue()
        {
            var dfe = new DataFactoryExpression<bool>(BoolValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(BoolJson, actual);
        }

        [Test]
        public void SerializationOfNullableBoolValue()
        {
            var dfe = new DataFactoryExpression<bool?>(null);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual("null", actual);
        }

        [Test]
        public void SerializationOfTimespanValue()
        {
            var dfe = new DataFactoryExpression<TimeSpan>(TimeSpanValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(TimeSpanJson, actual);
            Assert.AreEqual(TimeSpanValue.ToString(), dfe.ToString());
        }

        [Test]
        public void SerializationOfNullableTimeSpanValue()
        {
            var dfe = new DataFactoryExpression<TimeSpan?>(null);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual("null", actual);
            Assert.AreEqual(null, dfe.ToString());
        }

        [Test]
        public void SerializationOfDateTimeOffsetValue()
        {
            var dfe = new DataFactoryExpression<DateTimeOffset>(DateTimeOffsetValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(DateTimeOffsetJson, actual);
            Assert.AreEqual(DateTimeOffsetValue.ToString(), dfe.ToString());
        }

        [Test]
        public void SerializationOfNullableDateTimeOffsetValue()
        {
            var dfe = new DataFactoryExpression<DateTimeOffset?>(null);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual("null", actual);
            Assert.AreEqual(null, dfe.ToString());
        }

        [Test]
        public void SerializationOfDictionaryValue()
        {
            var dfe = new DataFactoryExpression<IDictionary<string, string>>(DictionaryValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(DictionaryJson, actual);
            Assert.AreEqual("System.Collections.Generic.Dictionary`2[System.String,System.String]", dfe.ToString());
        }

        [Test]
        public void SerializationOfNullableDictionaryValue()
        {
            var dfe = new DataFactoryExpression<IDictionary<string, string>?>(null);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual("null", actual);
            Assert.AreEqual(null, dfe.ToString());
        }

        [Test]
        public void SerializationOfUriValue()
        {
            var dfe = new DataFactoryExpression<Uri>(UriValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(UriJson, actual);
            Assert.AreEqual(UriValue.AbsoluteUri, dfe.ToString());
        }

        [Test]
        public void SerializationOfStringValue()
        {
            var dfe = new DataFactoryExpression<string>(StringValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(StringJson, actual);
        }

        [Test]
        public void SerializationOfNullStringValue()
        {
            var dfe = new DataFactoryExpression<string?>(null);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual("null", actual);
        }

        [Test]
        public void SerializationOfListOfT()
        {
            var elements = new List<TestModel>
            {
                new TestModel { A = 1, B = true },
                new TestModel { A = 2, B = false }
            };
            var dfe = new DataFactoryExpression<IList<TestModel>>(elements);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(@"[{""A"":1,""B"":true},{""A"":2,""B"":false}]", actual);
        }

        [Test]
        public void SerializationOfNullListOfT()
        {
            var dfe = new DataFactoryExpression<IList<TestModel>>(null);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual("null", actual);
        }

        [Test]
        public void SerializationOfDoubleValue()
        {
            var dfe = new DataFactoryExpression<double>(DoubleValue);
            var actual = GetSerializedString(dfe);
#if NET461_OR_GREATER
            Assert.AreEqual("1.1000000000000001", actual);
#else
            Assert.AreEqual(DoubleJson, actual);
#endif
        }

        [Test]
        public void SerializationOfListOfStringValue()
        {
            var dfe = new DataFactoryExpression<IList<string>>(ListOfStringValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(ListOfStringJson, actual);
        }

        [Test]
        public void SerializationOfEmptyListOfStringValue()
        {
            var dfe = new DataFactoryExpression<IList<string>>(EmptyListOfStringValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(EmptyListJson, actual);
        }

        [Test]
        public void SerializationOfExpression()
        {
            var dfe = DataFactoryExpression<int>.FromExpression(ExpressionValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(ExpressionJson, actual);
        }

        [Test]
        public void DeserializationOfIntValue()
        {
            var doc = JsonDocument.Parse(IntJson);
            var dfe = DataFactoryExpressionJsonConverter.Deserialize<int>(doc.RootElement)!;
            AssertIntDfe(dfe);
        }

        private static void AssertIntDfe(DataFactoryExpression<int> dfe)
        {
            Assert.IsTrue(dfe.HasLiteral);
            Assert.AreEqual(IntValue, dfe.Literal);
            Assert.AreEqual(IntJson, dfe.ToString());
        }

        [Test]
        public void DeserializationOfBoolValue()
        {
            var doc = JsonDocument.Parse(BoolJson);
            var dfe = DataFactoryExpressionJsonConverter.Deserialize<bool>(doc.RootElement)!;
            AssertBoolDfe(dfe);
        }

        [Test]
        public void DeserializationOfNullIntoBool()
        {
            var doc = JsonDocument.Parse(NullJson);
            var dfe = DataFactoryExpressionJsonConverter.Deserialize<bool?>(doc.RootElement);
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfNullableBool()
        {
            var dfe = new DataFactoryExpression<bool?>(null);
            var actual = GetSerializedString(dfe);
            var doc = JsonDocument.Parse(actual);
            dfe = DataFactoryExpressionJsonConverter.Deserialize<bool?>(doc.RootElement);
            Assert.IsNull(dfe);
        }

        private static void AssertBoolDfe(DataFactoryExpression<bool> dfe)
        {
            Assert.IsTrue(dfe.HasLiteral);
            Assert.AreEqual(BoolValue, dfe.Literal);
            Assert.IsTrue(string.Compare(BoolJson, dfe.ToString(), StringComparison.OrdinalIgnoreCase) == 0);
        }

        [Test]
        public void DeserializationOfStringValue()
        {
            var doc = JsonDocument.Parse(StringJson);
            var dfe = DataFactoryExpressionJsonConverter.Deserialize<string?>(doc.RootElement)!;
            AssertStringDfe(dfe, StringValue);
        }

        [Test]
        public void DeserializationOfNullIntoString()
        {
            var doc = JsonDocument.Parse(NullJson);
            var dfe = DataFactoryExpressionJsonConverter.Deserialize<string>(doc.RootElement)!;
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfNullStringValue()
        {
            var dfe = new DataFactoryExpression<string?>(null);
            var actual = GetSerializedString(dfe);
            var doc = JsonDocument.Parse(actual);
            dfe = DataFactoryExpressionJsonConverter.Deserialize<string?>(doc.RootElement);
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfTimeSpanValue()
        {
            var doc = JsonDocument.Parse(TimeSpanJson);
            var dfe = DataFactoryExpressionJsonConverter.Deserialize<TimeSpan>(doc.RootElement)!;
            Assert.AreEqual(dfe.Literal, TimeSpanValue);
        }

        [Test]
        public void DeserializationOfNullIntoTimeSpan()
        {
            var doc = JsonDocument.Parse(NullJson);
            var dfe = DataFactoryExpressionJsonConverter.Deserialize<TimeSpan>(doc.RootElement)!;
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfNullTimeSpanValue()
        {
            var dfe = new DataFactoryExpression<TimeSpan?>(null);
            var actual = GetSerializedString(dfe);
            var doc = JsonDocument.Parse(actual);
            dfe = DataFactoryExpressionJsonConverter.Deserialize<TimeSpan?>(doc.RootElement);
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfDateTimeOffsetValue()
        {
            var doc = JsonDocument.Parse(DateTimeOffsetJson);
            var dfe = DataFactoryExpressionJsonConverter.Deserialize<DateTimeOffset>(doc.RootElement)!;
            Assert.AreEqual(DateTimeOffsetValue, dfe.Literal);
        }

        [Test]
        public void DeserializationOfNullIntoUri()
        {
            var doc = JsonDocument.Parse(NullJson);
            var dfe = DataFactoryExpressionJsonConverter.Deserialize<Uri?>(doc.RootElement)!;
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfUriDateTimeOffsetValue()
        {
            var dfe = new DataFactoryExpression<Uri?>(null);
            var actual = GetSerializedString(dfe);
            var doc = JsonDocument.Parse(actual);
            dfe = DataFactoryExpressionJsonConverter.Deserialize<Uri?>(doc.RootElement);
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfUriValue()
        {
            var doc = JsonDocument.Parse(UriJson);
            var dfe = DataFactoryExpressionJsonConverter.Deserialize<Uri>(doc.RootElement)!;
            Assert.AreEqual(dfe.Literal, UriValue);
        }

        [Test]
        public void DeserializationOfNullIntoDateTimeOffset()
        {
            var doc = JsonDocument.Parse(NullJson);
            var dfe = DataFactoryExpressionJsonConverter.Deserialize<DateTimeOffset>(doc.RootElement)!;
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfNullDateTimeOffsetValue()
        {
            var dfe = new DataFactoryExpression<DateTimeOffset?>(null);
            var actual = GetSerializedString(dfe);
            var doc = JsonDocument.Parse(actual);
            dfe = DataFactoryExpressionJsonConverter.Deserialize<DateTimeOffset?>(doc.RootElement);
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfListOfT()
        {
            var elements = new List<TestModel>
            {
                new TestModel { A = 1, B = true },
                new TestModel { A = 2, B = false }
            };
            var dfe = new DataFactoryExpression<IList<TestModel>>(elements);
            var actual = GetSerializedString(dfe);
            dfe = JsonSerializer.Deserialize<DataFactoryExpression<IList<TestModel>>>(actual)!;
            Assert.AreEqual(1, dfe!.Literal![0]!.A);
            Assert.AreEqual(true, dfe.Literal[0].B);
            Assert.AreEqual(2, dfe.Literal[1].A);
            Assert.AreEqual(false, dfe.Literal[1].B);
            Assert.AreEqual("System.Collections.Generic.List`1[Azure.Core.Expressions.DataFactory.Tests.DataFactoryExpressionsTests+TestModel]", dfe.ToString());
        }

        [Test]
        public void DeserializationOfEmptyListOfT()
        {
            var elements = new List<TestModel>();
            var dfe = new DataFactoryExpression<IList<TestModel>>(elements);
            var actual = GetSerializedString(dfe);
            dfe = JsonSerializer.Deserialize<DataFactoryExpression<IList<TestModel>>>(actual);
            Assert.IsEmpty(dfe!.Literal!);
        }

        [Test]
        public void DeserializationOfNullListOfT()
        {
            var dfe = new DataFactoryExpression<IList<TestModel>>(null);
            var actual = GetSerializedString(dfe);
            dfe = JsonSerializer.Deserialize<DataFactoryExpression<IList<TestModel>>>(actual);
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfListOfTExpression()
        {
            var dfe = DataFactoryExpression<IList<TestModel>>.FromExpression("some expression");
            var serialized = GetSerializedString(dfe);
            dfe = JsonSerializer.Deserialize<DataFactoryExpression<IList<TestModel>>>(serialized)!;
            Assert.IsFalse(dfe.HasLiteral);
            Assert.AreEqual("some expression", dfe.Expression);
        }

        [Test]
        public void DeserializationOfListOfTWithNull()
        {
            var elements = new List<TestModel?>
            {
                new TestModel { A = 1, B = true },
                null
            };
            var dfe = new DataFactoryExpression<IList<TestModel?>>(elements);
            var actual = GetSerializedString(dfe);
            dfe = JsonSerializer.Deserialize<DataFactoryExpression<IList<TestModel?>>>(actual)!;
            Assert.AreEqual(1, dfe!.Literal![0]!.A);
            Assert.AreEqual(true, dfe.Literal[0]!.B);
            Assert.IsNull(dfe.Literal[1]);
        }

        [Test]
        public void DeserializationOfReadOnlyListOfTExpression()
        {
            var dfe = DataFactoryExpression<IReadOnlyList<TestModel>>.FromExpression("some expression");
            Assert.IsFalse(dfe.HasLiteral);
            Assert.AreEqual("some expression", dfe.Expression);
        }

        private static void AssertStringDfe(DataFactoryExpression<string?> dfe, string expectedValue)
        {
            Assert.IsTrue(dfe.HasLiteral);
            Assert.AreEqual(expectedValue, dfe.Literal);
            Assert.AreEqual(expectedValue, dfe.ToString());
        }

        private static void AssertDfe<T>(DataFactoryExpression<T> dfe, T expectedValue)
        {
            Assert.IsTrue(dfe.HasLiteral);
            Assert.AreEqual(expectedValue, dfe.Literal);
        }

        [Test]
        public void DeserializationOfDoubleValue()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<double>>(DoubleJson)!;
            AssertDoubleDfe(dfe);
        }

        [Test]
        public void DeserializationOfNullIntoDouble()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<double?>>(NullJson)!;
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfNullableDouble()
        {
            var dfe = new DataFactoryExpression<double?>(null);
            var actual = GetSerializedString(dfe);
            dfe = JsonSerializer.Deserialize<DataFactoryExpression<double?>>(actual);
            Assert.IsNull(dfe);
        }

        private static void AssertDoubleDfe(DataFactoryExpression<double> dfe)
        {
            Assert.IsTrue(dfe.HasLiteral);
            Assert.AreEqual(DoubleValue, dfe.Literal);
            Assert.AreEqual(DoubleJson, dfe.ToString());
        }

        [Test]
        public void DeserializationOfListOfStringValue()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<IList<string>>>(ListOfStringJson)!;
            AssertListOfStringDfe(dfe);
        }

        [Test]
        public void DeserializationOfEmptyArrayValue()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<IList<string>>>(EmptyListJson)!;
            AssertEmptyListOfStringDfe(dfe);
        }

        [Test]
        public void DeserializationOfNullIntoArray()
        {
            var doc = JsonDocument.Parse(NullJson);
            var dfe = DataFactoryExpressionJsonConverter.Deserialize<Array?>(doc.RootElement)!;
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfNullListOfString()
        {
            var dfe = new DataFactoryExpression<IList<string?>?>(null);
            var actual = GetSerializedString(dfe);
            dfe = JsonSerializer.Deserialize<DataFactoryExpression<IList<string?>?>>(actual);
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfKeyValuePairs()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<IDictionary<string, string?>?>>(DictionaryJson)!;
            AssertDictionaryDfe(dfe);
        }

        private static void AssertDictionaryDfe(DataFactoryExpression<IDictionary<string, string?>?> dfe)
        {
            Assert.IsTrue(dfe.HasLiteral);
            Assert.AreEqual(2, dfe.Literal!.Count);
            Assert.AreEqual("value1", dfe.Literal["key1"]);
            Assert.AreEqual("value2", dfe.Literal["key2"]);
            Assert.AreEqual("System.Collections.Generic.Dictionary`2[System.String,System.String]", dfe.ToString());
        }

        private static void AssertListOfStringDfe(DataFactoryExpression<IList<string>> dfe)
        {
            Assert.IsTrue(dfe.HasLiteral);
            Assert.AreEqual(2, dfe.Literal!.Count);
            Assert.AreEqual("a", dfe.Literal[0]);
            Assert.AreEqual("b", dfe.Literal[1]);
            Assert.AreEqual("System.Collections.Generic.List`1[System.String]", dfe.ToString());
        }

        [Test]
        public void DeserializationOfExpression()
        {
            var doc = JsonDocument.Parse(ExpressionJson);
            var dfe = DataFactoryExpressionJsonConverter.Deserialize<string>(doc.RootElement)!;
            AssertExpressionDfe(dfe);
        }

        private static void AssertExpressionDfe(DataFactoryExpression<string?> dfe)
        {
            Assert.IsFalse(dfe.HasLiteral);
            Assert.Throws<InvalidOperationException>(() => { var x = dfe.Literal; });
            Assert.AreEqual(ExpressionValue, dfe.ToString());
        }

        private string GetSerializedString<T>(DataFactoryExpression<T> payload)
        {
            using var ms = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(ms);
            JsonSerializer.Serialize(writer, payload);
            writer.Flush();
            ms.Position = 0;
            using var sr = new StreamReader(ms);
            return sr.ReadToEnd();
        }

        [Test]
        public void SerializationFromJsonConverterForInt()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<int>>(IntJson);
            var actual = GetSerializedString(dfe!);
            Assert.AreEqual(IntJson, actual);
        }

        [Test]
        public void SerializationFromJsonConverterForListOfString()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<IList<string>>>(ListOfStringJson);
            var actual = GetSerializedString(dfe!);
            Assert.AreEqual(ListOfStringJson, actual);
        }

        [Test]
        public void SerializationFromJsonConverterForBool()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<bool>>(BoolJson);
            var actual = GetSerializedString(dfe!);
            Assert.AreEqual(BoolJson, actual);
        }

        [Test]
        public void SerializationFromJsonConverterForDouble()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<double>>(DoubleJson);
            var actual = GetSerializedString(dfe!);
#if NET461_OR_GREATER
            Assert.AreEqual("1.1000000000000001", actual);
#else
            Assert.AreEqual(DoubleJson, actual);
#endif
        }

        [Test]
        public void SerializationFromJsonConverterForEmptyArray()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<IList<string>>>(EmptyListJson);
            var actual = GetSerializedString(dfe!);
            Assert.AreEqual(EmptyListJson, actual);
        }

        [Test]
        public void SerializationFromJsonConverterForString()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<string>>(StringJson);
            var actual = GetSerializedString(dfe!);
            Assert.AreEqual(StringJson, actual);
        }

        [Test]
        public void SerializationFromJsonConverterForExpression()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<int>>(ExpressionJson);
            var actual = GetSerializedString(dfe!);
            Assert.AreEqual(ExpressionJson, actual);
        }

        [Test]
        public void FailsIfCanConvertIsFalse()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => JsonSerializer.Deserialize<DataFactoryExpression<long>>(ExpressionJson));
            Assert.IsTrue(exception!.Message.StartsWith("The converter specified on"));
        }

        [JsonConverter(typeof(TestModelConverter))]
        public class TestModel
        {
            public int A { get; set; }

            public bool B { get; set; }

            public override string ToString() => $"A: {A},B: {B}";
        }

        private class TestModelConverter : JsonConverter<TestModel>
        {
            public override TestModel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return new TestModel()
                {
                    A = document.RootElement.GetProperty("A").GetInt32(),
                    B = document.RootElement.GetProperty("B").GetBoolean()
                };
            }

            public override void Write(Utf8JsonWriter writer, TestModel value, JsonSerializerOptions options)
            {
                writer.WriteStartObject();
                writer.WriteNumber("A", value.A);
                writer.WriteBoolean("B", value.B);
                writer.WriteEndObject();
            }
        }
    }
}

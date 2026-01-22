// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using NUnit.Framework;

#nullable enable

namespace Azure.Core.Expressions.DataFactory.Tests
{
    public class DataFactoryElementTests
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
#if NET462
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
        private const string ExpressionJson = $"{{\"type\":\"Expression\",\"value\":\"{ExpressionValue}\"}}";
        private const string SecretStringJson = $"{{\"value\":\"{SecretStringValue}\",\"type\":\"SecureString\"}}";
        private const string UnknownTypeJson = "{\"type\":\"Unknown\"}";
        private const string OtherTypeJson = $"{{\"type\":\"{OtherSecretType}\"}}";
        private const string KeyVaultSecretReferenceJson = """{"store":{"type":"LinkedServiceReference","referenceName":"referenceNameValue"},"secretName":"secretNameValue","secretVersion":"secretVersionValue","type":"AzureKeyVaultSecret"}""";
        private const string NullJson = "null";
        private const string DictionaryJson = "{\"key1\":\"value1\",\"key2\":\"value2\"}";
        private const string BinaryDataDictionaryJson = """{"key1":{"A":1,"B":true},"key2":{"C":0,"D":"foo"},"key3":null}""";

        private const int IntValue = 1;
        private static readonly BinaryData BinaryDataValue1 = new BinaryData(new TestModel { A = 1, B = true });
        private static readonly BinaryData BinaryDataValue2 = new BinaryData(new { C = 0, D = "foo" });
        private static readonly TimeSpan TimeSpanValue = TimeSpan.FromSeconds(5);
        private static readonly DateTimeOffset DateTimeOffsetValue = DateTimeOffset.UtcNow;
        private static readonly Uri UriValue = new Uri("https://example.com");
        private static readonly Dictionary<string, string> DictionaryValue = new()
        {
            { "key1", "value1" },
            { "key2", "value2" }
        };

        private static readonly Dictionary<string, BinaryData?> BinaryDataDictionaryValue = new()
        {
            { "key1", BinaryDataValue1 },
            { "key2", BinaryDataValue2 },
            { "key3", null }
        };
        private static readonly List<string> ListOfStringValue = new List<string> { "a", "b" };
        private static readonly IList<string> EmptyListOfStringValue = new List<string>();
        private const bool BoolValue = true;
        private const double DoubleValue = 1.1;
        private const string StringValue = "a";
        private const string ExpressionValue = "@{myExpression}";
        private const string SecretStringValue = "somestring";
        private const string OtherSecretType = "someothertype";
        private const string UnknownSecretType = "Unknown";
        private const string KeyVaultSecretName = "secretNameValue";

        private static string TimeSpanJson = $"\"{TimeSpanValue.ToString()}\"";
        private static string DateTimeOffsetJson = $"\"{TypeFormatters.ToString(DateTimeOffsetValue, "O")}\"";
        private static string UriJson = $"\"{UriValue!.AbsoluteUri}\"";

        [Test]
        public void CreateFromIntLiteral()
        {
            DataFactoryElement<int> dfe = DataFactoryElement<int>.FromLiteral(IntValue);
            AssertIntDfe(dfe);

            dfe = IntValue;
            AssertIntDfe(dfe);
        }

        [Test]
        public void ImplicitCastFromIntLiteral()
        {
            DataFactoryElement<int> dfe = IntValue;
            AssertIntDfe(dfe);

            dfe = IntValue;
            AssertIntDfe(dfe);
        }

        [Test]
        public void CreateFromListOfStringLiteral()
        {
            var dfe = DataFactoryElement<IList<string>>.FromLiteral(ListOfStringValue);
            AssertListOfStringDfe(dfe);

            dfe = ListOfStringValue;
            AssertListOfStringDfe(dfe);
        }

        [Test]
        public void ImplicitCastFromListOfStringLiteral()
        {
            DataFactoryElement<IList<string>> dfe = ListOfStringValue;
            AssertListOfStringDfe(dfe);

            dfe = ListOfStringValue;
            AssertListOfStringDfe(dfe);
        }

        [Test]
        public void CreateFromBinaryDataLiteral()
        {
            var dfe = DataFactoryElement<BinaryData>.FromLiteral(BinaryDataValue1);
            AssertBinaryDataDfe(dfe);

            dfe = BinaryDataValue1;
            AssertBinaryDataDfe(dfe);
        }

        [Test]
        public void CreateFromBoolLiteral()
        {
            var dfe = DataFactoryElement<bool>.FromLiteral(BoolValue);
            AssertBoolDfe(dfe);

            dfe = BoolValue;
            AssertBoolDfe(dfe);
        }

        [Test]
        public void ImplicitCastFromBoolLiteral()
        {
            DataFactoryElement<bool> dfe = BoolValue;
            AssertBoolDfe(dfe);

            dfe = BoolValue;
            AssertBoolDfe(dfe);
        }

        [Test]
        public void CreateFromDoubleLiteral()
        {
            var dfe = DataFactoryElement<double>.FromLiteral(DoubleValue);
            AssertDoubleDfe(dfe);

            dfe = DoubleValue;
            AssertDoubleDfe(dfe);
        }

        [Test]
        public void ImplicitCastFromDoubleLiteral()
        {
            DataFactoryElement<double> dfe = DoubleValue;
            AssertDoubleDfe(dfe);

            dfe = DoubleValue;
            AssertDoubleDfe(dfe);
        }

        [Test]
        public void CreateFromStringLiteral()
        {
            var dfe = DataFactoryElement<string?>.FromLiteral(StringValue);
            AssertStringDfe(dfe, StringValue, DataFactoryElementKind.Literal);

            dfe = StringValue;
            AssertStringDfe(dfe, StringValue, DataFactoryElementKind.Literal);
        }

        [Test]
        public void ImplicitCastFromStringLiteral()
        {
            DataFactoryElement<string?> dfe = StringValue;
            AssertStringDfe(dfe, StringValue, DataFactoryElementKind.Literal);

            dfe = StringValue;
            AssertStringDfe(dfe, StringValue, DataFactoryElementKind.Literal);
        }

        [Test]
        public void CreateFromDateTimeOffsetLiteral()
        {
            var dfe = DataFactoryElement<DateTimeOffset?>.FromLiteral(DateTimeOffsetValue);
            AssertDfe(dfe, DateTimeOffsetValue);

            dfe = DateTimeOffsetValue;
            AssertDfe(dfe, DateTimeOffsetValue);
        }

        [Test]
        public void ImplicitCastFromDateTimeOffsetLiteral()
        {
            DataFactoryElement<DateTimeOffset?> dfe = DateTimeOffsetValue;
            AssertDfe(dfe, DateTimeOffsetValue);

            dfe = DateTimeOffsetValue;
            AssertDfe(dfe, DateTimeOffsetValue);
        }

        [Test]
        public void CreateFromTimespanLiteral()
        {
            var dfe = DataFactoryElement<TimeSpan?>.FromLiteral(TimeSpanValue);
            AssertDfe(dfe, TimeSpanValue);

            dfe = TimeSpanValue;
            AssertDfe(dfe, TimeSpanValue);
        }

        [Test]
        public void ImplicitCastFromTimespanLiteral()
        {
            DataFactoryElement<TimeSpan?> dfe = TimeSpanValue;
            AssertDfe(dfe, TimeSpanValue);

            dfe = TimeSpanValue;
            AssertDfe(dfe, TimeSpanValue);
        }

        [Test]
        public void CreateFromUriLiteral()
        {
            var dfe = DataFactoryElement<Uri?>.FromLiteral(UriValue);
            AssertDfe(dfe, UriValue);

            dfe = UriValue;
            AssertDfe(dfe, UriValue);
        }

        [Test]
        public void ImplicitCastFromUriLiteral()
        {
            DataFactoryElement<Uri?> dfe = UriValue;
            AssertDfe(dfe, UriValue);

            dfe = UriValue;
            AssertDfe(dfe, UriValue);
        }

        [Test]
        public void CreateFromDictionaryLiteral()
        {
            var dfe = DataFactoryElement<IDictionary<string, string>?>.FromLiteral(DictionaryValue);
            AssertDfe(dfe, DictionaryValue);

            dfe = DictionaryValue;
            AssertDfe(dfe, DictionaryValue);
        }

        [Test]
        public void ImplicitCastFromDictionaryLiteral()
        {
            DataFactoryElement<IDictionary<string, string>?> dfe = DictionaryValue;
            AssertDfe(dfe, DictionaryValue);

            dfe = DictionaryValue;
            AssertDfe(dfe, DictionaryValue);
        }

        [Test]
        public void CreateFromBinaryDataDictionaryLiteral()
        {
            var dfe = DataFactoryElement<IDictionary<string, BinaryData?>?>.FromLiteral(BinaryDataDictionaryValue);
            AssertDfe(dfe, BinaryDataDictionaryValue);

            dfe = BinaryDataDictionaryValue;
            AssertDfe(dfe, BinaryDataDictionaryValue);
        }

        [Test]
        public void ImplicitCastFromBinaryDataDictionaryLiteral()
        {
            DataFactoryElement<IDictionary<string, BinaryData?>?> dfe = BinaryDataDictionaryValue;
            AssertDfe(dfe, BinaryDataDictionaryValue);

            dfe = BinaryDataDictionaryValue;
            AssertDfe(dfe, BinaryDataDictionaryValue);
        }

        [Test]
        public void CreateFromListOfTLiteral()
        {
            var literal = new List<TestModel>
            {
                new TestModel { A = 1, B = true },
                new TestModel { A = 2, B = false }
            };
            var dfe = new DataFactoryElement<IList<TestModel>>(literal);
            AssertDfe(dfe, literal);

            dfe = literal;
            AssertDfe(dfe, literal);
        }

        [Test]
        public void ImplicitCastFromListOfTLiteral()
        {
            var literal = new List<TestModel>
            {
                new TestModel { A = 1, B = true },
                new TestModel { A = 2, B = false }
            };
            DataFactoryElement<IList<TestModel>> dfe = literal;
            AssertDfe(dfe, literal);

            dfe = literal;
            AssertDfe(dfe, literal);
        }

        [Test]
        public void CreateFromMaskedStringLiteral()
        {
            var dfe = DataFactoryElement<string?>.FromSecretString(SecretStringValue);
            AssertStringDfe(dfe, SecretStringValue, DataFactoryElementKind.SecretString);
            ;
            Assert.That(dfe.ToString(), Is.EqualTo(SecretStringValue));
        }

        [Test]
        public void IncorrectlyUseExpressionAsLiteralString()
        {
            var dfe = new DataFactoryElement<string?>(ExpressionValue);
            AssertStringDfe(dfe, ExpressionValue, DataFactoryElementKind.Literal);

            dfe = ExpressionValue;
            AssertStringDfe(dfe, ExpressionValue, DataFactoryElementKind.Literal);
        }

        [Test]
        public void CreateFromExpression()
        {
            var dfe = DataFactoryElement<string?>.FromExpression(ExpressionValue);
            AssertExpressionDfe(dfe);
        }

        [Test]
        public void CreateFromKeyVaultReference()
        {
            var store = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceKind.LinkedServiceReference,
                "referenceName");
            var keyVaultReference = new DataFactoryKeyVaultSecret(store, KeyVaultSecretName);
            var dfe = DataFactoryElement<string?>.FromKeyVaultSecret(keyVaultReference);
            AssertKeyVaultReferenceDfe(dfe);
        }

        [Test]
        public void NullValueForString()
        {
            var dfe = DataFactoryElement<string>.FromLiteral(null);
            Assert.That(dfe.Kind, Is.EqualTo(DataFactoryElementKind.Literal));
            Assert.That(dfe.Literal, Is.EqualTo(null));
            Assert.That(dfe.ToString(), Is.EqualTo(null));
        }

        [Test]
        public void NullValueForArray()
        {
            var dfe = DataFactoryElement<Array>.FromLiteral(null);
            Assert.That(dfe.Kind, Is.EqualTo(DataFactoryElementKind.Literal));
            Assert.That(dfe.Literal, Is.EqualTo(null));
            Assert.That(dfe.ToString(), Is.EqualTo(null));
        }

        [Test]
        public void EmptyValueForListOfString()
        {
            var dfe = new DataFactoryElement<IList<string>>(EmptyListOfStringValue);
            AssertEmptyListOfStringDfe(dfe);
        }

        private static void AssertEmptyListOfStringDfe(DataFactoryElement<IList<string>> dfe)
        {
            Assert.That(dfe.Kind, Is.EqualTo(DataFactoryElementKind.Literal));
            Assert.That(dfe.Literal!.Count, Is.EqualTo(0));
            Assert.That(dfe.ToString(), Is.EqualTo("System.Collections.Generic.List`1[System.String]"));
        }

        [Test]
        public void SerializationOfIntValue()
        {
            var dfe = DataFactoryElement<int>.FromLiteral(IntValue);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo(IntJson));
        }

        [Test]
        public void SerializationOfNullableIntValue()
        {
            var dfe = DataFactoryElement<int?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo("null"));
        }

        [Test]
        public void SerializationOfBoolValue()
        {
            var dfe = DataFactoryElement<bool>.FromLiteral(BoolValue);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo(BoolJson));
        }

        [Test]
        public void SerializationOfNullableBoolValue()
        {
            var dfe = DataFactoryElement<bool?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo("null"));
        }

        [Test]
        public void SerializationOfTimespanValue()
        {
            var dfe = DataFactoryElement<TimeSpan>.FromLiteral(TimeSpanValue);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo(TimeSpanJson));
            Assert.That(dfe.ToString(), Is.EqualTo(TimeSpanValue.ToString()));
        }

        [Test]
        public void SerializationOfNullableTimeSpanValue()
        {
            var dfe = DataFactoryElement<TimeSpan?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo("null"));
            Assert.That(dfe.ToString(), Is.EqualTo(null));
        }

        [Test]
        public void SerializationOfDateTimeOffsetValue()
        {
            var dfe = DataFactoryElement<DateTimeOffset>.FromLiteral(DateTimeOffsetValue);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo(DateTimeOffsetJson));
            Assert.That(dfe.ToString(), Is.EqualTo(DateTimeOffsetValue.ToString()));
        }

        [Test]
        public void SerializationOfNullableDateTimeOffsetValue()
        {
            var dfe = DataFactoryElement<DateTimeOffset?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo("null"));
            Assert.That(dfe.ToString(), Is.EqualTo(null));
        }

        [Test]
        public void SerializationOfDictionaryValue()
        {
            var dfe = DataFactoryElement<IDictionary<string, string>>.FromLiteral(DictionaryValue);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo(DictionaryJson));
            Assert.That(dfe.ToString(), Is.EqualTo("System.Collections.Generic.Dictionary`2[System.String,System.String]"));
        }

        [Test]
        public void SerializationOfNullableDictionaryValue()
        {
            var dfe = DataFactoryElement<IDictionary<string, string>?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo("null"));
            Assert.That(dfe.ToString(), Is.EqualTo(null));
        }

        [Test]
        public void SerializationOfBinaryDataDictionaryValue()
        {
            var dfe = DataFactoryElement<IDictionary<string, BinaryData?>>.FromLiteral(BinaryDataDictionaryValue);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo(BinaryDataDictionaryJson));
            Assert.That(dfe.ToString(), Is.EqualTo("System.Collections.Generic.Dictionary`2[System.String,System.BinaryData]"));
        }

        [Test]
        public void SerializationOfNullableBinaryDataDictionaryValue()
        {
            var dfe = DataFactoryElement<IDictionary<string, BinaryData>?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo("null"));
            Assert.That(dfe.ToString(), Is.EqualTo(null));
        }

        [Test]
        public void SerializationOfUriValue()
        {
            var dfe = DataFactoryElement<Uri>.FromLiteral(UriValue);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo(UriJson));
            Assert.That(dfe.ToString(), Is.EqualTo(UriValue.AbsoluteUri));
        }

        [Test]
        public void SerializationOfStringValue()
        {
            var dfe = DataFactoryElement<string>.FromLiteral(StringValue);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo(StringJson));
        }

        [Test]
        public void SerializationOfNullStringValue()
        {
            var dfe = DataFactoryElement<string?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo("null"));
        }

        [Test]
        public void SerializationOfBinaryDataValue()
        {
            var dfe = DataFactoryElement<BinaryData>.FromLiteral(BinaryDataValue1);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo(BinaryDataValue1.ToString()));
        }

        [Test]
        public void BinaryDataCanHandleNonObjectsValues()
        {
            var dfeString = Deserialize<BinaryData>(StringJson).Literal!;
            Assert.That(GetSerializedString<BinaryData>(dfeString), Is.EqualTo(StringJson));

            var dfeBool = Deserialize<BinaryData>(BoolJson).Literal!;
            Assert.That(GetSerializedString<BinaryData>(dfeBool), Is.EqualTo(BoolJson));

            var dfeInt = Deserialize<BinaryData>(IntJson).Literal!;
            Assert.That(GetSerializedString<BinaryData>(dfeInt), Is.EqualTo(IntJson));
        }

        [Test]
        public void SerializationOfListOfT()
        {
            var elements = new List<TestModel>
            {
                new TestModel { A = 1, B = true },
                new TestModel { A = 2, B = false }
            };
            var dfe = DataFactoryElement<IList<TestModel>>.FromLiteral(elements);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo(@"[{""A"":1,""B"":true},{""A"":2,""B"":false}]"));
        }

        [Test]
        public void SerializationOfNullListOfT()
        {
            var dfe = DataFactoryElement<IList<TestModel>>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo("null"));
        }

        [Test]
        public void SerializationOfDoubleValue()
        {
            var dfe = DataFactoryElement<double>.FromLiteral(DoubleValue);
            var actual = GetSerializedString(dfe);
#if NET462
            Assert.That(actual, Is.EqualTo("1.1000000000000001"));
#else
            Assert.That(actual, Is.EqualTo(DoubleJson));
#endif
        }

        [Test]
        public void SerializationOfListOfStringValue()
        {
            var dfe = new DataFactoryElement<IList<string>>(ListOfStringValue);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo(ListOfStringJson));
        }

        [Test]
        public void SerializationOfEmptyListOfStringValue()
        {
            var dfe = new DataFactoryElement<IList<string>>(EmptyListOfStringValue);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo(EmptyListJson));
        }

        [Test]
        public void SerializationOfExpression()
        {
            var dfe = DataFactoryElement<int>.FromExpression(ExpressionValue);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo(ExpressionJson));
        }

        [Test]
        public void SerializationOfSecretString()
        {
            var dfe = DataFactoryElement<string>.FromSecretString(SecretStringValue);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo(SecretStringJson));
            Assert.That(dfe.ToString(), Is.EqualTo(SecretStringValue));
        }

        [Test]
        public void SerializationOfUnknownType()
        {
            var dfe = DataFactoryElement<string>.FromSecretBase(new UnknownSecret(null));
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo(UnknownTypeJson));
            Assert.That(dfe.ToString(), Is.Null);
            Assert.That(dfe.Kind, Is.EqualTo(new DataFactoryElementKind(UnknownSecretType)));
        }

        [Test]
        public void SerializationOfOtherType()
        {
            var dfe = DataFactoryElement<string>.FromSecretBase(new UnknownSecret(OtherSecretType));
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo(OtherTypeJson));
            Assert.That(dfe.ToString(), Is.Null);
            Assert.That(dfe.Kind, Is.EqualTo(new DataFactoryElementKind(OtherSecretType)));
        }

        [Test]
        public void SerializationOfKeyVaultReference()
        {
            var store = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceKind.LinkedServiceReference,
                "referenceNameValue");
            var keyVaultReference = new DataFactoryKeyVaultSecret(store, "secretNameValue")
            {
                SecretVersion = "secretVersionValue"
            };
            var dfe = DataFactoryElement<string>.FromKeyVaultSecret(keyVaultReference);
            var actual = GetSerializedString(dfe);
            Assert.That(actual, Is.EqualTo(KeyVaultSecretReferenceJson));
        }

        [Test]
        public void DeserializationOfIntValue()
        {
            var dfe = Deserialize<int>(IntJson)!;
            AssertIntDfe(dfe);
        }

        private static void AssertIntDfe(DataFactoryElement<int> dfe)
        {
            Assert.That(dfe.Kind, Is.EqualTo(DataFactoryElementKind.Literal));
            Assert.That(dfe.Literal, Is.EqualTo(IntValue));
            Assert.That(dfe.ToString(), Is.EqualTo(IntJson));
        }

        [Test]
        public void DeserializationOfBoolValue()
        {
            var dfe = Deserialize<bool>(BoolJson)!;
            AssertBoolDfe(dfe);
        }

        [Test]
        public void DeserializationOfNullIntoBool()
        {
            var dfe = Deserialize<bool?>(NullJson);
            Assert.That(dfe, Is.Null);
        }

        [Test]
        public void DeserializationOfNullableBool()
        {
            var dfe = new DataFactoryElement<bool?>(null);
            var actual = GetSerializedString(dfe);
            dfe = Deserialize<bool?>(actual);
            Assert.That(dfe, Is.Null);
        }

        private static void AssertBoolDfe(DataFactoryElement<bool> dfe)
        {
            Assert.That(dfe.Kind, Is.EqualTo(DataFactoryElementKind.Literal));
            Assert.That(dfe.Literal, Is.EqualTo(BoolValue));
            Assert.That(string.Compare(BoolJson, dfe.ToString(), StringComparison.OrdinalIgnoreCase), Is.EqualTo(0));
        }

        [Test]
        public void DeserializationOfStringValue()
        {
            var dfe = Deserialize<string?>(StringJson)!;
            AssertStringDfe(dfe, StringValue, DataFactoryElementKind.Literal);
        }

        [Test]
        public void DeserializationOfNullIntoString()
        {
            var dfe = Deserialize<string>(NullJson)!;
            Assert.That(dfe, Is.Null);
        }

        [Test]
        public void DeserializationOfNullStringValue()
        {
            var dfe = DataFactoryElement<string?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            dfe = Deserialize<string?>(actual);
            Assert.That(dfe, Is.Null);
        }

        [Test]
        public void DeserializationOfTimeSpanValue()
        {
            var dfe = Deserialize<TimeSpan>(TimeSpanJson)!;
            Assert.That(TimeSpanValue, Is.EqualTo(dfe.Literal));
        }

        [Test]
        public void DeserializationOfNullIntoTimeSpan()
        {
            var dfe = Deserialize<TimeSpan>(NullJson)!;
            Assert.That(dfe, Is.Null);
        }

        [Test]
        public void DeserializationOfNullTimeSpanValue()
        {
            var dfe = DataFactoryElement<TimeSpan?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            dfe = Deserialize<TimeSpan?>(actual);
            Assert.That(dfe, Is.Null);
        }

        [Test]
        public void DeserializationOfDateTimeOffsetValue()
        {
            var dfe = Deserialize<DateTimeOffset>(DateTimeOffsetJson)!;
            Assert.That(dfe.Literal, Is.EqualTo(DateTimeOffsetValue));
        }

        [Test]
        public void DeserializationOfNullIntoUri()
        {
            var dfe = Deserialize<Uri?>(NullJson)!;
            Assert.That(dfe, Is.Null);
        }

        [Test]
        public void DeserializationOfUriDateTimeOffsetValue()
        {
            var dfe = DataFactoryElement<Uri?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            dfe = Deserialize<Uri?>(actual);
            Assert.That(dfe, Is.Null);
        }

        [Test]
        public void DeserializationOfUriValue()
        {
            var dfe = Deserialize<Uri>(UriJson)!;
            Assert.That(UriValue, Is.EqualTo(dfe.Literal));
        }

        [Test]
        public void DeserializationOfNullIntoDateTimeOffset()
        {
            var dfe = Deserialize<DateTimeOffset?>(NullJson)!;
            Assert.That(dfe, Is.Null);
        }

        [Test]
        public void DeserializationOfNullDateTimeOffsetValue()
        {
            var dfe = DataFactoryElement<DateTimeOffset?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            dfe = Deserialize<DateTimeOffset?>(actual);
            Assert.That(dfe, Is.Null);
        }

        [Test]
        public void DeserializationOfBinaryDataValue()
        {
            var dfe = DataFactoryElement<BinaryData?>.FromLiteral(BinaryDataValue1);
            var actual = GetSerializedString(dfe);
            dfe = Deserialize<BinaryData?>(actual);
            AssertBinaryDataDfe(dfe!);
        }

        [Test]
        public void DeserializationOfListOfT()
        {
            var elements = new List<TestModel>
            {
                new TestModel { A = 1, B = true },
                new TestModel { A = 2, B = false }
            };
            var dfe = DataFactoryElement<IList<TestModel>>.FromLiteral(elements);
            var actual = GetSerializedString(dfe);
            dfe = Deserialize<IList<TestModel>>(actual)!;
            Assert.That(dfe!.Literal![0]!.A, Is.EqualTo(1));
            Assert.That(dfe.Literal[0].B, Is.EqualTo(true));
            Assert.That(dfe.Literal[1].A, Is.EqualTo(2));
            Assert.That(dfe.Literal[1].B, Is.EqualTo(false));
            Assert.That(dfe.ToString(), Is.EqualTo("System.Collections.Generic.List`1[Azure.Core.Expressions.DataFactory.Tests.DataFactoryElementTests+TestModel]"));
        }

        [Test]
        public void DeserializationOfEmptyListOfT()
        {
            var elements = new List<TestModel>();
            var dfe = DataFactoryElement<IList<TestModel>>.FromLiteral(elements);
            var actual = GetSerializedString(dfe);
            dfe = Deserialize<IList<TestModel>>(actual);
            Assert.That(dfe!.Literal!, Is.Empty);
        }

        [Test]
        public void DeserializationOfNullListOfT()
        {
            var dfe = DataFactoryElement<IList<TestModel?>>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            dfe = Deserialize<IList<TestModel?>>(actual);
            Assert.That(dfe, Is.Null);
        }

        [Test]
        public void DeserializationOfListOfTExpression()
        {
            var dfe = DataFactoryElement<IList<TestModel>>.FromExpression("some expression");
            var serialized = GetSerializedString(dfe);
            dfe = Deserialize<IList<TestModel>>(serialized)!;
            Assert.That(dfe.Kind, Is.EqualTo(DataFactoryElementKind.Expression));
            Assert.That(dfe.ExpressionString, Is.EqualTo("some expression"));
        }

        [Test]
        public void DeserializationOfListOfTWithNull()
        {
            var elements = new List<TestModel?>
            {
                new TestModel { A = 1, B = true },
                null
            };
            var dfe = DataFactoryElement<IList<TestModel?>>.FromLiteral(elements);
            var actual = GetSerializedString(dfe);
            dfe = Deserialize<IList<TestModel?>>(actual)!;
            Assert.That(dfe!.Literal![0]!.A, Is.EqualTo(1));
            Assert.That(dfe.Literal[0]!.B, Is.EqualTo(true));
            Assert.That(dfe.Literal[1], Is.Null);
        }

        [Test]
        public void DeserializationOfReadOnlyListOfTExpression()
        {
            var dfe = DataFactoryElement<IReadOnlyList<TestModel>>.FromExpression("some expression");
            Assert.That(dfe.Kind, Is.EqualTo(DataFactoryElementKind.Expression));
            Assert.That(dfe.ToString(), Is.EqualTo("some expression"));
        }

        private static void AssertStringDfe(DataFactoryElement<string?> dfe, string? expectedValue, DataFactoryElementKind expectedKind)
        {
            Assert.That(dfe.Kind, Is.EqualTo(expectedKind));
            Assert.That(dfe.ToString(), Is.EqualTo(expectedValue));
        }

        private static void AssertDfe<T>(DataFactoryElement<T> dfe, T expectedValue)
        {
            Assert.That(dfe.Kind, Is.EqualTo(DataFactoryElementKind.Literal));
            Assert.That(dfe.Literal, Is.EqualTo(expectedValue));
        }

        [Test]
        public void DeserializationOfDoubleValue()
        {
            var dfe = Deserialize<double>(DoubleJson)!;
            AssertDoubleDfe(dfe);
        }

        [Test]
        public void DeserializationOfNullIntoDouble()
        {
            var dfe = Deserialize<double?>(NullJson)!;
            Assert.That(dfe, Is.Null);
        }

        [Test]
        public void DeserializationOfNullableDouble()
        {
            var dfe = DataFactoryElement<double?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            dfe = Deserialize<double?>(actual);
            Assert.That(dfe, Is.Null);
        }

        private static void AssertDoubleDfe(DataFactoryElement<double> dfe)
        {
            Assert.That(dfe.Kind, Is.EqualTo(DataFactoryElementKind.Literal));
            Assert.That(dfe.Literal, Is.EqualTo(DoubleValue));
            Assert.That(dfe.ToString(), Is.EqualTo(DoubleJson));
        }

        [Test]
        public void DeserializationOfListOfStringValue()
        {
            var dfe = Deserialize<IList<string>>(ListOfStringJson)!;
            AssertListOfStringDfe(dfe);
        }

        [Test]
        public void DeserializationOfEmptyArrayValue()
        {
            var dfe = Deserialize<IList<string>>(EmptyListJson)!;
            AssertEmptyListOfStringDfe(dfe);
        }

        [Test]
        public void DeserializationOfNullIntoArray()
        {
            var dfe = Deserialize<IList<DataFactoryElement<int?>>>(NullJson)!;
            Assert.That(dfe, Is.Null);
        }

        [Test]
        public void DeserializationOfNullListOfString()
        {
            var dfe = DataFactoryElement<IList<string?>?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            dfe = Deserialize<IList<string?>?>(actual);
            Assert.That(dfe, Is.Null);
        }

        [Test]
        public void DeserializationOfKeyValuePairs()
        {
            var dfe = Deserialize<IDictionary<string, string?>?>(DictionaryJson)!;
            AssertDictionaryDfe(dfe);
        }

        [Test]
        public void DeserializationOfKeyBinaryDataValuePairs()
        {
            var dfe = Deserialize<IDictionary<string, BinaryData?>?>(BinaryDataDictionaryJson)!;
            AssertBinaryDataDictionaryDfe(dfe);
        }

        [Test]
        public void RoundTripDictionaryWithExtraProperties()
        {
            DataFactoryElement<IDictionary<string, string>> input = new Dictionary<string, string>
            {
                { "type", "Expression" },
                { "value", "foo" },
                // the extra property will cause this to be treated as a literal
                { "extra", "bar"}
            };
            Assert.That(input.Kind, Is.EqualTo(DataFactoryElementKind.Literal));
            var serialized = GetSerializedString(input);

            var output = Deserialize<IDictionary<string, string?>?>(serialized)!;
            Assert.That(output.Kind, Is.EqualTo(DataFactoryElementKind.Literal));
        }

        private static void AssertDictionaryDfe(DataFactoryElement<IDictionary<string, string?>?> dfe)
        {
            Assert.That(dfe.Kind, Is.EqualTo(DataFactoryElementKind.Literal));
            Assert.That(dfe.Literal!.Count, Is.EqualTo(2));
            Assert.That(dfe.Literal["key1"], Is.EqualTo("value1"));
            Assert.That(dfe.Literal["key2"], Is.EqualTo("value2"));
            Assert.That(dfe.ToString(), Is.EqualTo("System.Collections.Generic.Dictionary`2[System.String,System.String]"));
        }

        private static void AssertBinaryDataDictionaryDfe(DataFactoryElement<IDictionary<string, BinaryData?>?> dfe)
        {
            Assert.That(dfe.Kind, Is.EqualTo(DataFactoryElementKind.Literal));
            Assert.That(dfe.Literal!.Count, Is.EqualTo(3));
            Assert.That(dfe.Literal["key1"]!.ToString(), Is.EqualTo("""{"A":1,"B":true}"""));
            Assert.That(dfe.Literal["key2"]!.ToString(), Is.EqualTo("""{"C":0,"D":"foo"}"""));
            Assert.That(dfe.Literal["key3"]!.ToString(), Is.EqualTo(NullJson));
            Assert.That(dfe.ToString(), Is.EqualTo("System.Collections.Generic.Dictionary`2[System.String,System.BinaryData]"));
        }

        private static void AssertListOfStringDfe(DataFactoryElement<IList<string>> dfe)
        {
            Assert.That(dfe.Kind, Is.EqualTo(DataFactoryElementKind.Literal));
            Assert.That(dfe.Literal!.Count, Is.EqualTo(2));
            Assert.That(dfe.Literal[0], Is.EqualTo("a"));
            Assert.That(dfe.Literal[1], Is.EqualTo("b"));
            Assert.That(dfe.ToString(), Is.EqualTo("System.Collections.Generic.List`1[System.String]"));
        }

        private static void AssertBinaryDataDfe(DataFactoryElement<BinaryData> dfe)
        {
            TestModel? model = dfe.Literal!.ToObjectFromJson<TestModel>();
            Assert.That(model, Is.Not.Null);
            Assert.That(model?.A, Is.EqualTo(1));
            Assert.That(model?.B, Is.True);
        }

        [Test]
        public void DeserializationOfExpression()
        {
            var dfe = Deserialize<string?>(ExpressionJson)!;
            AssertExpressionDfe(dfe);
        }

        [Test]
        public void DeserializationOfKeyVaultReference()
        {
            var dfe = Deserialize<string?>(KeyVaultSecretReferenceJson)!;
            AssertKeyVaultReferenceDfe(dfe);
        }

        [Test]
        public void DeserializationOfSecretString()
        {
            var dfe = Deserialize<string?>(SecretStringJson)!;
            Assert.That(dfe.ToString(), Is.EqualTo(SecretStringValue));
            AssertStringDfe(dfe, SecretStringValue, DataFactoryElementKind.SecretString);
        }

        [Test]
        public void DeserializationOfUnknownType()
        {
            var doc = JsonDocument.Parse(UnknownTypeJson);
            var dfe = Deserialize<string?>(UnknownTypeJson)!;
            // the value is not retained for unknown Type
            AssertStringDfe(dfe, null, new DataFactoryElementKind("Unknown"));
        }

        [Test]
        public void DeserializationOfOtherType()
        {
            var dfe = Deserialize<string?>(OtherTypeJson)!;
            // the value is not retained for unknown Type
            AssertStringDfe(dfe, null, new DataFactoryElementKind(OtherSecretType));
        }

        private static void AssertExpressionDfe(DataFactoryElement<string?> dfe)
        {
            Assert.That(dfe.Kind, Is.EqualTo(DataFactoryElementKind.Expression));
            Assert.Throws<InvalidOperationException>(() => { var x = dfe.Literal; });
            Assert.That(dfe.ToString(), Is.EqualTo(ExpressionValue));
        }

        private static void AssertKeyVaultReferenceDfe(DataFactoryElement<string?> dfe)
        {
            Assert.That(dfe.Kind, Is.EqualTo(DataFactoryElementKind.KeyVaultSecret));
            Assert.Throws<InvalidOperationException>(() => { var x = dfe.Literal; });
            Assert.That(dfe.ToString(), Is.EqualTo(KeyVaultSecretName));
        }

        private string GetSerializedString<T>(DataFactoryElement<T> payload) => ModelReaderWriter.Write(payload).ToString();

        private ModelReaderWriterOptions s_options = new ModelReaderWriterOptions("W");
        private DataFactoryElement<T> Deserialize<T>(string json)
        {
            var instance = new DataFactoryElement<T>(default);
            return ((IJsonModel<DataFactoryElement<T>>)instance).Create(BinaryData.FromString($"{json}"), s_options)!;
        }

        [Test]
        public void SerializationFromJsonConverterForInt()
        {
            var dfe = Deserialize<int>(IntJson);
            var actual = GetSerializedString(dfe!);
            Assert.That(actual, Is.EqualTo(IntJson));
        }

        [Test]
        public void SerializationFromJsonConverterForListOfString()
        {
            var dfe = Deserialize<IList<string>>(ListOfStringJson);
            var actual = GetSerializedString(dfe!);
            Assert.That(actual, Is.EqualTo(ListOfStringJson));
        }

        [Test]
        public void SerializationFromJsonConverterForBool()
        {
            var dfe = Deserialize<bool>(BoolJson);
            var actual = GetSerializedString(dfe!);
            Assert.That(actual, Is.EqualTo(BoolJson));
        }

        [Test]
        public void SerializationFromJsonConverterForDouble()
        {
            var dfe = Deserialize<double>(DoubleJson);
            var actual = GetSerializedString(dfe!);
#if NET462
            Assert.That(actual, Is.EqualTo("1.1000000000000001"));
#else
            Assert.That(actual, Is.EqualTo(DoubleJson));
#endif
        }

        [Test]
        public void SerializationFromJsonConverterForEmptyArray()
        {
            var dfe = Deserialize<IList<string>>(EmptyListJson);
            var actual = GetSerializedString(dfe!);
            Assert.That(actual, Is.EqualTo(EmptyListJson));
        }

        [Test]
        public void SerializationFromJsonConverterForString()
        {
            var dfe = Deserialize<string>(StringJson);
            var actual = GetSerializedString(dfe!);
            Assert.That(actual, Is.EqualTo(StringJson));
        }

        [Test]
        public void SerializationFromJsonConverterForExpression()
        {
            var dfe = Deserialize<int>(ExpressionJson);
            var actual = GetSerializedString(dfe!);
            Assert.That(actual, Is.EqualTo(ExpressionJson));
        }

        [JsonConverter(typeof(TestModelConverter))]
        public class TestModel : IJsonModel<TestModel>
        {
            public int A { get; set; }

            public bool B { get; set; }

            void IJsonModel<TestModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                var format = options.Format == "W" ? ((IPersistableModel<TestModel>)this).GetFormatFromOptions(options) : options.Format;
                if (format != "J")
                {
                    throw new FormatException($"The model {nameof(TestModel)} does not support '{format}' format.");
                }

                writer.WriteStartObject();
                writer.WritePropertyName("A");
                writer.WriteNumberValue(A);
                writer.WritePropertyName("B");
                writer.WriteBooleanValue(B);
                writer.WriteEndObject();
            }

            TestModel IJsonModel<TestModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                var format = options.Format == "W" ? ((IPersistableModel<TestModel>)this).GetFormatFromOptions(options) : options.Format;
                if (format != "J")
                {
                    throw new FormatException($"The model {nameof(TestModel)} does not support '{format}' format.");
                }

                using var document = JsonDocument.ParseValue(ref reader);
                return new TestModel()
                {
                    A = document.RootElement.GetProperty("A").GetInt32(),
                    B = document.RootElement.GetProperty("B").GetBoolean()
                };
            }

            BinaryData IPersistableModel<TestModel>.Write(ModelReaderWriterOptions options)
            {
                var format = options.Format == "W" ? ((IPersistableModel<TestModel>)this).GetFormatFromOptions(options) : options.Format;
                if (format != "J")
                {
                    throw new FormatException($"The model {nameof(TestModel)} does not support '{format}' format.");
                }

                return ModelReaderWriter.Write(this, options, DataFactoryContext.Default);
            }

            TestModel IPersistableModel<TestModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                var format = options.Format == "W" ? ((IPersistableModel<TestModel>)this).GetFormatFromOptions(options) : options.Format;
                if (format != "J")
                {
                    throw new FormatException($"The model {nameof(TestModel)} does not support '{format}' format.");
                }

                using var document = JsonDocument.Parse(data);
                return new TestModel()
                {
                    A = document.RootElement.GetProperty("A").GetInt32(),
                    B = document.RootElement.GetProperty("B").GetBoolean()
                };
            }

            string IPersistableModel<TestModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
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

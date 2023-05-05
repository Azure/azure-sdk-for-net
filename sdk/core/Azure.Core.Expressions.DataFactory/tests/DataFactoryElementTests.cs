﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private const string SecureStringJson = $"{{\"type\":\"SecureString\",\"value\":\"{SecureStringValue}\"}}";
        private static readonly string SecureStringJsonNonString = $"{{\"type\":\"SecureString\",\"value\":\"{SecureStringValueNonString}\"}}";
        private const string KeyVaultSecretReferenceJson = $"{{\"type\":\"AzureKeyVaultSecretReference\",\"value\":\"{KeyVaultSecretReferenceValue}\"}}";
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
        private const string SecureStringValue = "somestring";
        private const int SecureStringValueNonString = 1;
        private const string KeyVaultSecretReferenceValue = "@Microsoft.KeyVault(SecretUri=https://myvault.vault.azure.net/secrets/mysecret/)";

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
            var dfe = DataFactoryElement<string?>.FromMaskedString(SecureStringValue);
            AssertStringDfe(dfe, SecureStringValue, DataFactoryElementKind.MaskedString);;
            Assert.AreEqual(SecureStringValue, dfe.ToString());
        }

        [Test]
        public void CreateFromMaskedStringBool()
        {
            var dfe = DataFactoryElement<bool>.FromMaskedString(false);
            Assert.AreEqual(DataFactoryElementKind.MaskedString, dfe.Kind);
            Assert.AreEqual("False", dfe.ToString());
        }

        [Test]
        public void CreateFromMaskedStringBoolNullable()
        {
            var dfe = DataFactoryElement<bool?>.FromMaskedString(false);
            Assert.AreEqual(DataFactoryElementKind.MaskedString, dfe.Kind);
            Assert.AreEqual("False", dfe.ToString());
        }

        [Test]
        public void CreateFromMaskedStringInt()
        {
            var dfe = DataFactoryElement<int>.FromMaskedString(4);
            Assert.AreEqual(DataFactoryElementKind.MaskedString, dfe.Kind);
            Assert.AreEqual("4", dfe.ToString());
        }

        [Test]
        public void CreateFromMaskedStringIntNullable()
        {
            var dfe = DataFactoryElement<int?>.FromMaskedString(new DataFactoryMaskedString(4));
            Assert.AreEqual(DataFactoryElementKind.MaskedString, dfe.Kind);
            Assert.AreEqual("4", dfe.ToString());
        }

        [Test]
        public void CreateFromMaskedStringDouble()
        {
            var dfe = DataFactoryElement<double>.FromMaskedString(new DataFactoryMaskedString(4.1));
            Assert.AreEqual(DataFactoryElementKind.MaskedString, dfe.Kind);
            Assert.AreEqual("4.1", dfe.ToString());
        }

        [Test]
        public void CreateFromMaskedStringDoubleNullable()
        {
            var dfe = DataFactoryElement<double?>.FromMaskedString(new DataFactoryMaskedString(4.1));
            Assert.AreEqual(DataFactoryElementKind.MaskedString, dfe.Kind);
            Assert.AreEqual("4.1", dfe.ToString());
        }

        [Test]
        public void CreateFromMaskedStringTimeSpan()
        {
            var dfe = DataFactoryElement<TimeSpan>.FromMaskedString(new DataFactoryMaskedString(TimeSpan.FromSeconds(1)));
            Assert.AreEqual(DataFactoryElementKind.MaskedString, dfe.Kind);
            Assert.AreEqual(TimeSpan.FromSeconds(1).ToString(), dfe.ToString());
        }

        [Test]
        public void CreateFromMaskedStringTimeSpanNullable()
        {
            var dfe = DataFactoryElement<TimeSpan?>.FromMaskedString(new DataFactoryMaskedString(TimeSpan.FromSeconds(1)));
            Assert.AreEqual(DataFactoryElementKind.MaskedString, dfe.Kind);
            Assert.AreEqual(TimeSpan.FromSeconds(1).ToString(), dfe.ToString());
        }

        [Test]
        public void CreateFromMaskedStringDateTimeOffset()
        {
            var now = DateTimeOffset.UtcNow;
            var dfe = DataFactoryElement<DateTimeOffset>.FromMaskedString(new DataFactoryMaskedString(now));
            Assert.AreEqual(DataFactoryElementKind.MaskedString, dfe.Kind);
            Assert.AreEqual(now.ToString(), dfe.ToString());
        }

        [Test]
        public void CreateFromMaskedStringDateTimeOffsetNullable()
        {
            var now = DateTimeOffset.UtcNow;
            var dfe = DataFactoryElement<DateTimeOffset?>.FromMaskedString(new DataFactoryMaskedString(now));
            Assert.AreEqual(DataFactoryElementKind.MaskedString, dfe.Kind);
            Assert.AreEqual(now.ToString(), dfe.ToString());
        }

        [Test]
        public void CreateFromMaskedStringUri()
        {
            var dfe = DataFactoryElement<Uri>.FromMaskedString(new DataFactoryMaskedString(UriValue));
            Assert.AreEqual(DataFactoryElementKind.MaskedString, dfe.Kind);
            Assert.AreEqual(UriValue.AbsoluteUri, dfe.ToString());
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
            var dfe = DataFactoryElement<string?>.FromKeyVaultSecretReference(KeyVaultSecretReferenceValue);
            AssertKeyVaultReferenceDfe(dfe);
        }

        [Test]
        public void NullValueForString()
        {
            var dfe = DataFactoryElement<string>.FromLiteral(null);
            Assert.AreEqual(DataFactoryElementKind.Literal, dfe.Kind);
            Assert.AreEqual(null, dfe.Literal);
            Assert.AreEqual(null, dfe.ToString());
        }

        [Test]
        public void NullValueForArray()
        {
            var dfe = DataFactoryElement<Array>.FromLiteral(null);
            Assert.AreEqual(DataFactoryElementKind.Literal, dfe.Kind);
            Assert.AreEqual(null, dfe.Literal);
            Assert.AreEqual(null, dfe.ToString());
        }

        [Test]
        public void EmptyValueForListOfString()
        {
            var dfe = new DataFactoryElement<IList<string>>(EmptyListOfStringValue);
            AssertEmptyListOfStringDfe(dfe);
        }

        private static void AssertEmptyListOfStringDfe(DataFactoryElement<IList<string>> dfe)
        {
            Assert.AreEqual(DataFactoryElementKind.Literal, dfe.Kind);
            Assert.AreEqual(dfe.Literal!.Count, 0);
            Assert.AreEqual("System.Collections.Generic.List`1[System.String]", dfe.ToString());
        }

        [Test]
        public void SerializationOfIntValue()
        {
            var dfe = DataFactoryElement<int>.FromLiteral(IntValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(IntJson, actual);
        }

        [Test]
        public void SerializationOfNullableIntValue()
        {
            var dfe = DataFactoryElement<int?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual("null", actual);
        }

        [Test]
        public void SerializationOfBoolValue()
        {
            var dfe = DataFactoryElement<bool>.FromLiteral(BoolValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(BoolJson, actual);
        }

        [Test]
        public void SerializationOfNullableBoolValue()
        {
            var dfe = DataFactoryElement<bool?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual("null", actual);
        }

        [Test]
        public void SerializationOfTimespanValue()
        {
            var dfe = DataFactoryElement<TimeSpan>.FromLiteral(TimeSpanValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(TimeSpanJson, actual);
            Assert.AreEqual(TimeSpanValue.ToString(), dfe.ToString());
        }

        [Test]
        public void SerializationOfNullableTimeSpanValue()
        {
            var dfe = DataFactoryElement<TimeSpan?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual("null", actual);
            Assert.AreEqual(null, dfe.ToString());
        }

        [Test]
        public void SerializationOfDateTimeOffsetValue()
        {
            var dfe = DataFactoryElement<DateTimeOffset>.FromLiteral(DateTimeOffsetValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(DateTimeOffsetJson, actual);
            Assert.AreEqual(DateTimeOffsetValue.ToString(), dfe.ToString());
        }

        [Test]
        public void SerializationOfNullableDateTimeOffsetValue()
        {
            var dfe = DataFactoryElement<DateTimeOffset?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual("null", actual);
            Assert.AreEqual(null, dfe.ToString());
        }

        [Test]
        public void SerializationOfDictionaryValue()
        {
            var dfe = DataFactoryElement<IDictionary<string, string>>.FromLiteral(DictionaryValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(DictionaryJson, actual);
            Assert.AreEqual("System.Collections.Generic.Dictionary`2[System.String,System.String]", dfe.ToString());
        }

        [Test]
        public void SerializationOfNullableDictionaryValue()
        {
            var dfe = DataFactoryElement<IDictionary<string, string>?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual("null", actual);
            Assert.AreEqual(null, dfe.ToString());
        }

        [Test]
        public void SerializationOfUriValue()
        {
            var dfe = DataFactoryElement<Uri>.FromLiteral(UriValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(UriJson, actual);
            Assert.AreEqual(UriValue.AbsoluteUri, dfe.ToString());
        }

        [Test]
        public void SerializationOfStringValue()
        {
            var dfe = DataFactoryElement<string>.FromLiteral(StringValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(StringJson, actual);
        }

        [Test]
        public void SerializationOfNullStringValue()
        {
            var dfe = DataFactoryElement<string?>.FromLiteral(null);
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
            var dfe = DataFactoryElement<IList<TestModel>>.FromLiteral(elements);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(@"[{""A"":1,""B"":true},{""A"":2,""B"":false}]", actual);
        }

        [Test]
        public void SerializationOfNullListOfT()
        {
            var dfe = DataFactoryElement<IList<TestModel>>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual("null", actual);
        }

        [Test]
        public void SerializationOfDoubleValue()
        {
            var dfe = DataFactoryElement<double>.FromLiteral(DoubleValue);
            var actual = GetSerializedString(dfe);
#if NET462
            Assert.AreEqual("1.1000000000000001", actual);
#else
            Assert.AreEqual(DoubleJson, actual);
#endif
        }

        [Test]
        public void SerializationOfListOfStringValue()
        {
            var dfe = new DataFactoryElement<IList<string>>(ListOfStringValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(ListOfStringJson, actual);
        }

        [Test]
        public void SerializationOfEmptyListOfStringValue()
        {
            var dfe = new DataFactoryElement<IList<string>>(EmptyListOfStringValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(EmptyListJson, actual);
        }

        [Test]
        public void SerializationOfExpression()
        {
            var dfe = DataFactoryElement<int>.FromExpression(ExpressionValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(ExpressionJson, actual);
        }

        [Test]
        public void SerializationOfSecureString()
        {
            var dfe = DataFactoryElement<string>.FromMaskedString(SecureStringValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(SecureStringJson, actual);
            Assert.AreEqual(SecureStringValue, dfe.ToString());
        }

        [Test]
        public void SerializationOfSecureStringLiteralNonString()
        {
            var dfe = DataFactoryElement<int>.FromMaskedString(new DataFactoryMaskedString(SecureStringValueNonString));

            var actual = GetSerializedString(dfe);
            Assert.AreEqual(SecureStringJsonNonString, actual);
            Assert.AreEqual(SecureStringValueNonString.ToString(), dfe.ToString());
        }

        [Test]
        public void SerializationOfKeyVaultReference()
        {
            var dfe = DataFactoryElement<int>.FromKeyVaultSecretReference(KeyVaultSecretReferenceValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(KeyVaultSecretReferenceJson, actual);
        }

        [Test]
        public void DeserializationOfIntValue()
        {
            var doc = JsonDocument.Parse(IntJson);
            var dfe = DataFactoryElementJsonConverter.Deserialize<int>(doc.RootElement)!;
            AssertIntDfe(dfe);
        }

        private static void AssertIntDfe(DataFactoryElement<int> dfe)
        {
            Assert.AreEqual(DataFactoryElementKind.Literal, dfe.Kind);
            Assert.AreEqual(IntValue, dfe.Literal);
            Assert.AreEqual(IntJson, dfe.ToString());
        }

        [Test]
        public void DeserializationOfBoolValue()
        {
            var doc = JsonDocument.Parse(BoolJson);
            var dfe = DataFactoryElementJsonConverter.Deserialize<bool>(doc.RootElement)!;
            AssertBoolDfe(dfe);
        }

        [Test]
        public void DeserializationOfNullIntoBool()
        {
            var doc = JsonDocument.Parse(NullJson);
            var dfe = DataFactoryElementJsonConverter.Deserialize<bool?>(doc.RootElement);
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfNullableBool()
        {
            var dfe = new DataFactoryElement<bool?>(null);
            var actual = GetSerializedString(dfe);
            var doc = JsonDocument.Parse(actual);
            dfe = DataFactoryElementJsonConverter.Deserialize<bool?>(doc.RootElement);
            Assert.IsNull(dfe);
        }

        private static void AssertBoolDfe(DataFactoryElement<bool> dfe)
        {
            Assert.AreEqual(DataFactoryElementKind.Literal, dfe.Kind);
            Assert.AreEqual(BoolValue, dfe.Literal);
            Assert.IsTrue(string.Compare(BoolJson, dfe.ToString(), StringComparison.OrdinalIgnoreCase) == 0);
        }

        [Test]
        public void DeserializationOfStringValue()
        {
            var doc = JsonDocument.Parse(StringJson);
            var dfe = DataFactoryElementJsonConverter.Deserialize<string?>(doc.RootElement)!;
            AssertStringDfe(dfe, StringValue, DataFactoryElementKind.Literal);
        }

        [Test]
        public void DeserializationOfNullIntoString()
        {
            var doc = JsonDocument.Parse(NullJson);
            var dfe = DataFactoryElementJsonConverter.Deserialize<string>(doc.RootElement)!;
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfNullStringValue()
        {
            var dfe = DataFactoryElement<string?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            var doc = JsonDocument.Parse(actual);
            dfe = DataFactoryElementJsonConverter.Deserialize<string?>(doc.RootElement);
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfTimeSpanValue()
        {
            var doc = JsonDocument.Parse(TimeSpanJson);
            var dfe = DataFactoryElementJsonConverter.Deserialize<TimeSpan>(doc.RootElement)!;
            Assert.AreEqual(dfe.Literal, TimeSpanValue);
        }

        [Test]
        public void DeserializationOfNullIntoTimeSpan()
        {
            var doc = JsonDocument.Parse(NullJson);
            var dfe = DataFactoryElementJsonConverter.Deserialize<TimeSpan>(doc.RootElement)!;
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfNullTimeSpanValue()
        {
            var dfe = DataFactoryElement<TimeSpan?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            var doc = JsonDocument.Parse(actual);
            dfe = DataFactoryElementJsonConverter.Deserialize<TimeSpan?>(doc.RootElement);
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfDateTimeOffsetValue()
        {
            var doc = JsonDocument.Parse(DateTimeOffsetJson);
            var dfe = DataFactoryElementJsonConverter.Deserialize<DateTimeOffset>(doc.RootElement)!;
            Assert.AreEqual(DateTimeOffsetValue, dfe.Literal);
        }

        [Test]
        public void DeserializationOfNullIntoUri()
        {
            var doc = JsonDocument.Parse(NullJson);
            var dfe = DataFactoryElementJsonConverter.Deserialize<Uri?>(doc.RootElement)!;
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfUriDateTimeOffsetValue()
        {
            var dfe = DataFactoryElement<Uri?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            var doc = JsonDocument.Parse(actual);
            dfe = DataFactoryElementJsonConverter.Deserialize<Uri?>(doc.RootElement);
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfUriValue()
        {
            var doc = JsonDocument.Parse(UriJson);
            var dfe = DataFactoryElementJsonConverter.Deserialize<Uri>(doc.RootElement)!;
            Assert.AreEqual(dfe.Literal, UriValue);
        }

        [Test]
        public void DeserializationOfNullIntoDateTimeOffset()
        {
            var doc = JsonDocument.Parse(NullJson);
            var dfe = DataFactoryElementJsonConverter.Deserialize<DateTimeOffset>(doc.RootElement)!;
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfNullDateTimeOffsetValue()
        {
            var dfe = DataFactoryElement<DateTimeOffset?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            var doc = JsonDocument.Parse(actual);
            dfe = DataFactoryElementJsonConverter.Deserialize<DateTimeOffset?>(doc.RootElement);
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
            var dfe = DataFactoryElement<IList<TestModel>>.FromLiteral(elements);
            var actual = GetSerializedString(dfe);
            dfe = JsonSerializer.Deserialize<DataFactoryElement<IList<TestModel>>>(actual)!;
            Assert.AreEqual(1, dfe!.Literal![0]!.A);
            Assert.AreEqual(true, dfe.Literal[0].B);
            Assert.AreEqual(2, dfe.Literal[1].A);
            Assert.AreEqual(false, dfe.Literal[1].B);
            Assert.AreEqual("System.Collections.Generic.List`1[Azure.Core.Expressions.DataFactory.Tests.DataFactoryElementTests+TestModel]", dfe.ToString());
        }

        [Test]
        public void DeserializationOfEmptyListOfT()
        {
            var elements = new List<TestModel>();
            var dfe = DataFactoryElement<IList<TestModel>>.FromLiteral(elements);
            var actual = GetSerializedString(dfe);
            dfe = JsonSerializer.Deserialize<DataFactoryElement<IList<TestModel>>>(actual);
            Assert.IsEmpty(dfe!.Literal!);
        }

        [Test]
        public void DeserializationOfNullListOfT()
        {
            var dfe = DataFactoryElement<IList<TestModel?>>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            dfe = JsonSerializer.Deserialize<DataFactoryElement<IList<TestModel?>>>(actual);
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfListOfTExpression()
        {
            var dfe = DataFactoryElement<IList<TestModel>>.FromExpression("some expression");
            var serialized = GetSerializedString(dfe);
            dfe = JsonSerializer.Deserialize<DataFactoryElement<IList<TestModel>>>(serialized)!;
            Assert.AreEqual(DataFactoryElementKind.Expression, dfe.Kind);
            Assert.AreEqual("some expression", dfe.StringValue);
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
            dfe = JsonSerializer.Deserialize<DataFactoryElement<IList<TestModel?>>>(actual)!;
            Assert.AreEqual(1, dfe!.Literal![0]!.A);
            Assert.AreEqual(true, dfe.Literal[0]!.B);
            Assert.IsNull(dfe.Literal[1]);
        }

        [Test]
        public void DeserializationOfReadOnlyListOfTExpression()
        {
            var dfe = DataFactoryElement<IReadOnlyList<TestModel>>.FromExpression("some expression");
            Assert.AreEqual(DataFactoryElementKind.Expression, dfe.Kind);
            Assert.AreEqual("some expression", dfe.ToString());
        }

        private static void AssertStringDfe(DataFactoryElement<string?> dfe, string expectedValue, DataFactoryElementKind expectedKind)
        {
            Assert.AreEqual(expectedKind, dfe.Kind);
            Assert.AreEqual(expectedValue, dfe.ToString());
        }

        private static void AssertDfe<T>(DataFactoryElement<T> dfe, T expectedValue)
        {
            Assert.AreEqual(DataFactoryElementKind.Literal, dfe.Kind);
            Assert.AreEqual(expectedValue, dfe.Literal);
        }

        [Test]
        public void DeserializationOfDoubleValue()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryElement<double>>(DoubleJson)!;
            AssertDoubleDfe(dfe);
        }

        [Test]
        public void DeserializationOfNullIntoDouble()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryElement<double?>>(NullJson)!;
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfNullableDouble()
        {
            var dfe = DataFactoryElement<double?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            dfe = JsonSerializer.Deserialize<DataFactoryElement<double?>>(actual);
            Assert.IsNull(dfe);
        }

        private static void AssertDoubleDfe(DataFactoryElement<double> dfe)
        {
            Assert.AreEqual(DataFactoryElementKind.Literal, dfe.Kind);
            Assert.AreEqual(DoubleValue, dfe.Literal);
            Assert.AreEqual(DoubleJson, dfe.ToString());
        }

        [Test]
        public void DeserializationOfListOfStringValue()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryElement<IList<string>>>(ListOfStringJson)!;
            AssertListOfStringDfe(dfe);
        }

        [Test]
        public void DeserializationOfEmptyArrayValue()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryElement<IList<string>>>(EmptyListJson)!;
            AssertEmptyListOfStringDfe(dfe);
        }

        [Test]
        public void DeserializationOfNullIntoArray()
        {
            var doc = JsonDocument.Parse(NullJson);
            var dfe = DataFactoryElementJsonConverter.Deserialize<Array?>(doc.RootElement)!;
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfNullListOfString()
        {
            var dfe = DataFactoryElement<IList<string?>?>.FromLiteral(null);
            var actual = GetSerializedString(dfe);
            dfe = JsonSerializer.Deserialize<DataFactoryElement<IList<string?>?>>(actual);
            Assert.IsNull(dfe);
        }

        [Test]
        public void DeserializationOfKeyValuePairs()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryElement<IDictionary<string, string?>?>>(DictionaryJson)!;
            AssertDictionaryDfe(dfe);
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
            Assert.AreEqual(DataFactoryElementKind.Literal, input.Kind);
            var serialized = GetSerializedString(input);

            var output = JsonSerializer.Deserialize<DataFactoryElement<IDictionary<string, string?>?>>(serialized)!;
            Assert.AreEqual(DataFactoryElementKind.Literal, output.Kind);
        }

        private static void AssertDictionaryDfe(DataFactoryElement<IDictionary<string, string?>?> dfe)
        {
            Assert.AreEqual(DataFactoryElementKind.Literal, dfe.Kind);
            Assert.AreEqual(2, dfe.Literal!.Count);
            Assert.AreEqual("value1", dfe.Literal["key1"]);
            Assert.AreEqual("value2", dfe.Literal["key2"]);
            Assert.AreEqual("System.Collections.Generic.Dictionary`2[System.String,System.String]", dfe.ToString());
        }

        private static void AssertListOfStringDfe(DataFactoryElement<IList<string>> dfe)
        {
            Assert.AreEqual(DataFactoryElementKind.Literal, dfe.Kind);
            Assert.AreEqual(2, dfe.Literal!.Count);
            Assert.AreEqual("a", dfe.Literal[0]);
            Assert.AreEqual("b", dfe.Literal[1]);
            Assert.AreEqual("System.Collections.Generic.List`1[System.String]", dfe.ToString());
        }

        [Test]
        public void DeserializationOfExpression()
        {
            var doc = JsonDocument.Parse(ExpressionJson);
            var dfe = DataFactoryElementJsonConverter.Deserialize<string>(doc.RootElement)!;
            AssertExpressionDfe(dfe);
        }

        [Test]
        public void DeserializationOfKeyVaultReference()
        {
            var doc = JsonDocument.Parse(KeyVaultSecretReferenceJson);
            var dfe = DataFactoryElementJsonConverter.Deserialize<string>(doc.RootElement)!;
            AssertKeyVaultReferenceDfe(dfe);
        }

        [Test]
        public void DeserializationOfSecureString()
        {
            var doc = JsonDocument.Parse(SecureStringJson);
            var dfe = DataFactoryElementJsonConverter.Deserialize<string>(doc.RootElement)!;
            Assert.AreEqual(SecureStringValue, dfe.StringValue);
            AssertStringDfe(dfe, SecureStringValue, DataFactoryElementKind.MaskedString);
        }

        private static void AssertExpressionDfe(DataFactoryElement<string?> dfe)
        {
            Assert.AreEqual(DataFactoryElementKind.Expression, dfe.Kind);
            Assert.Throws<InvalidOperationException>(() => { var x = dfe.Literal; });
            Assert.AreEqual(ExpressionValue, dfe.ToString());
        }

        private static void AssertKeyVaultReferenceDfe(DataFactoryElement<string?> dfe)
        {
            Assert.AreEqual(DataFactoryElementKind.KeyVaultSecretReference, dfe.Kind);
            Assert.Throws<InvalidOperationException>(() => { var x = dfe.Literal; });
            Assert.AreEqual(KeyVaultSecretReferenceValue, dfe.ToString());
        }

        private string GetSerializedString<T>(DataFactoryElement<T> payload)
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
            var dfe = JsonSerializer.Deserialize<DataFactoryElement<int>>(IntJson);
            var actual = GetSerializedString(dfe!);
            Assert.AreEqual(IntJson, actual);
        }

        [Test]
        public void SerializationFromJsonConverterForListOfString()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryElement<IList<string>>>(ListOfStringJson);
            var actual = GetSerializedString(dfe!);
            Assert.AreEqual(ListOfStringJson, actual);
        }

        [Test]
        public void SerializationFromJsonConverterForBool()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryElement<bool>>(BoolJson);
            var actual = GetSerializedString(dfe!);
            Assert.AreEqual(BoolJson, actual);
        }

        [Test]
        public void SerializationFromJsonConverterForDouble()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryElement<double>>(DoubleJson);
            var actual = GetSerializedString(dfe!);
#if NET462
            Assert.AreEqual("1.1000000000000001", actual);
#else
            Assert.AreEqual(DoubleJson, actual);
#endif
        }

        [Test]
        public void SerializationFromJsonConverterForEmptyArray()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryElement<IList<string>>>(EmptyListJson);
            var actual = GetSerializedString(dfe!);
            Assert.AreEqual(EmptyListJson, actual);
        }

        [Test]
        public void SerializationFromJsonConverterForString()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryElement<string>>(StringJson);
            var actual = GetSerializedString(dfe!);
            Assert.AreEqual(StringJson, actual);
        }

        [Test]
        public void SerializationFromJsonConverterForExpression()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryElement<int>>(ExpressionJson);
            var actual = GetSerializedString(dfe!);
            Assert.AreEqual(ExpressionJson, actual);
        }

        [Test]
        public void FailsIfCanConvertIsFalse()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => JsonSerializer.Deserialize<DataFactoryElement<long>>(ExpressionJson));
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

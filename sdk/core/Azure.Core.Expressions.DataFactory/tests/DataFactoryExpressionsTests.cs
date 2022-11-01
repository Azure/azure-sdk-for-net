// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Core.Expressions.DataFactory.Tests
{
    public class DataFactoryExpressionsTests
    {
        private const string IntJson = "1";
        private const string ArrayJson = "[1,2]";
        private const string EmptyArrayJson = "[]";
        private const string BoolJson = "true";
        private const string DoubleJson = "1.1";
        private const string StringJson = "\"a\"";
        private const string ExpressionJson = "{\"type\":\"Expression\",\"value\":\"@{myExpression}\"}";

        private const int IntValue = 1;
        private static readonly Array ArrayValue = new object[] { 1, 2 };
        private static readonly Array EmptyArrayValue = new object[] { };
        private const bool BoolValue = true;
        private const double DoubleValue = 1.1;
        private const string StringValue = "a";
        private const string ExpressionValue = "@{myExpression}";

        [Test]
        public void CreateFromIntLiteral()
        {
            DataFactoryExpression<int> dfe = new DataFactoryExpression<int>(IntValue);
            AssertIntDfe(dfe);

            dfe = IntValue;
            AssertIntDfe(dfe);
        }

        [Test]
        public void CreateFromArrayLiteral()
        {
            var dfe = new DataFactoryExpression<Array>(ArrayValue);
            AssertArrayDfe(dfe);

            dfe = ArrayValue;
            AssertArrayDfe(dfe);
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
        public void CreateFromstringLiteral()
        {
            var dfe = new DataFactoryExpression<string>(StringValue);
            AssertStringDfe(dfe, StringValue);

            dfe = StringValue;
            AssertStringDfe(dfe, StringValue);
        }

        [Test]
        public void IncorrectlyUseExpressionAsLiteralString()
        {
            var dfe = new DataFactoryExpression<string>(ExpressionValue);
            AssertStringDfe(dfe, ExpressionValue);

            dfe = ExpressionValue;
            AssertStringDfe(dfe, ExpressionValue);
        }

        [Ignore("Discussing if we should support SecureString or just string")]
        [Test]
        public void CreateFromSecureStringLiteral()
        {
            var secureString = new SecureString();
            secureString.AppendChar('a');
            var dfe = new DataFactoryExpression<SecureString>(secureString);
            AssertSecureStringDfe(dfe, secureString);

            dfe = secureString;
            AssertSecureStringDfe(dfe, secureString);
        }

        [Test]
        public void CreateFromExpression()
        {
            var dfe = DataFactoryExpression<string>.FromExpression(ExpressionValue);
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
        public void NullValueForSecureString()
        {
            var dfe = new DataFactoryExpression<SecureString>(null);
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
        public void EmptyValueForArray()
        {
            var dfe = new DataFactoryExpression<Array>(EmptyArrayValue);
            AssertEmptyArrayDfe(dfe);
        }

        private static void AssertEmptyArrayDfe(DataFactoryExpression<Array> dfe)
        {
            Assert.IsTrue(dfe.HasLiteral);
            Assert.AreEqual(dfe.Literal.Length, 0);
            Assert.AreEqual(EmptyArrayJson, dfe.ToString());
        }

        [Test]
        public void SerailizationOfIntValue()
        {
            var dfe = new DataFactoryExpression<int>(IntValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(IntJson, actual);
        }

        [Test]
        public void SerailizationOfBoolValue()
        {
            var dfe = new DataFactoryExpression<bool>(BoolValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(BoolJson, actual);
        }

        [Test]
        public void SerailizationOfStringValue()
        {
            var dfe = new DataFactoryExpression<string>(StringValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(StringJson, actual);
        }

        [Test]
        public void SerailizationOfDoubleValue()
        {
            var dfe = new DataFactoryExpression<double>(DoubleValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(DoubleJson, actual);
        }

        [Ignore("Discussing if we should support SecureString or just string")]
        [Test]
        public void SerailizationOfSecureStringValue()
        {
            var secureString = new SecureString();
            secureString.AppendChar('a');
            var dfe = new DataFactoryExpression<SecureString>(secureString);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(StringValue, actual);
        }

        [Test]
        public void SerailizationOfArrayValue()
        {
            var dfe = new DataFactoryExpression<Array>(ArrayValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(ArrayJson, actual);
        }

        [Test]
        public void SerailizationOfEmptyArrayValue()
        {
            var dfe = new DataFactoryExpression<Array>(EmptyArrayValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(EmptyArrayJson, actual);
        }

        [Test]
        public void SerailizationOfExpression()
        {
            var dfe = DataFactoryExpression<int>.FromExpression(ExpressionValue);
            var actual = GetSerializedString(dfe);
            Assert.AreEqual(ExpressionJson, actual);
        }

        [Test]
        public void DeserailizationOfIntValue()
        {
            var doc = JsonDocument.Parse(IntJson);
            var dfe = DataFactoryExpression<int>.DeserializeDataFactoryExpression(doc.RootElement);
            AssertIntDfe(dfe);
        }

        private static void AssertIntDfe(DataFactoryExpression<int> dfe)
        {
            Assert.IsTrue(dfe.HasLiteral);
            Assert.AreEqual(IntValue, dfe.Literal);
            Assert.AreEqual(IntJson, dfe.ToString());
        }

        [Test]
        public void DeserailizationOfBoolValue()
        {
            var doc = JsonDocument.Parse(BoolJson);
            var dfe = DataFactoryExpression<bool>.DeserializeDataFactoryExpression(doc.RootElement);
            AssertBoolDfe(dfe);
        }

        private static void AssertBoolDfe(DataFactoryExpression<bool> dfe)
        {
            Assert.IsTrue(dfe.HasLiteral);
            Assert.AreEqual(BoolValue, dfe.Literal);
            Assert.IsTrue(string.Compare(BoolJson, dfe.ToString(), StringComparison.OrdinalIgnoreCase) == 0);
        }

        [Test]
        public void DeserailizationOfStringValue()
        {
            var doc = JsonDocument.Parse(StringJson);
            var dfe = DataFactoryExpression<string>.DeserializeDataFactoryExpression(doc.RootElement);
            AssertStringDfe(dfe, StringValue);
        }

        private static void AssertStringDfe(DataFactoryExpression<string> dfe, string expectedValue)
        {
            Assert.IsTrue(dfe.HasLiteral);
            Assert.AreEqual(expectedValue, dfe.Literal);
            Assert.AreEqual(expectedValue, dfe.ToString());
        }

        [Test]
        public void DeserailizationOfDoubleValue()
        {
            var doc = JsonDocument.Parse(DoubleJson);
            var dfe = DataFactoryExpression<double>.DeserializeDataFactoryExpression(doc.RootElement);
            AssertDoubleDfe(dfe);
        }

        private static void AssertDoubleDfe(DataFactoryExpression<double> dfe)
        {
            Assert.IsTrue(dfe.HasLiteral);
            Assert.AreEqual(DoubleValue, dfe.Literal);
            Assert.AreEqual(DoubleJson, dfe.ToString());
        }

        [Ignore("Discussing if we should support SecureString or just string")]
        [Test]
        public void DeserailizationOfSecureStringValue()
        {
            var doc = JsonDocument.Parse(StringJson);
            var dfe = DataFactoryExpression<SecureString>.DeserializeDataFactoryExpression(doc.RootElement);
            var secureString = new SecureString();
            secureString.AppendChar('a');
            AssertSecureStringDfe(dfe, secureString);
        }

        private static void AssertSecureStringDfe(DataFactoryExpression<SecureString> dfe, SecureString secureString)
        {
            Assert.IsTrue(dfe.HasLiteral);
            Assert.AreEqual(secureString, dfe.Literal);
            Assert.AreEqual(secureString.ToString(), dfe.ToString());
        }

        [Test]
        public void DeserailizationOfArrayValue()
        {
            var doc = JsonDocument.Parse(ArrayJson);
            var dfe = DataFactoryExpression<Array>.DeserializeDataFactoryExpression(doc.RootElement);
            AssertArrayDfe(dfe);
        }

        [Test]
        public void DeserailizationOfEmptyArrayValue()
        {
            var doc = JsonDocument.Parse(EmptyArrayJson);
            var dfe = DataFactoryExpression<Array>.DeserializeDataFactoryExpression(doc.RootElement);
            AssertEmptyArrayDfe(dfe);
        }

        private static void AssertArrayDfe(DataFactoryExpression<Array> dfe)
        {
            Assert.IsTrue(dfe.HasLiteral);
            Assert.AreEqual(2, dfe.Literal.Length);
            Assert.AreEqual(1, dfe.Literal.GetValue(0));
            Assert.AreEqual(2, dfe.Literal.GetValue(1));
            Assert.AreEqual(ArrayJson, dfe.ToString());
        }

        [Test]
        public void DeserailizationOfExpression()
        {
            var doc = JsonDocument.Parse(ExpressionJson);
            var dfe = DataFactoryExpression<string>.DeserializeDataFactoryExpression(doc.RootElement);
            AssertExpressionDfe(dfe);
        }

        private static void AssertExpressionDfe(DataFactoryExpression<string> dfe)
        {
            Assert.IsFalse(dfe.HasLiteral);
            Assert.Throws<InvalidOperationException>(() => { var x = dfe.Literal; });
            Assert.AreEqual(ExpressionValue, dfe.ToString());
        }

        private string GetSerializedString(IUtf8JsonSerializable payload, bool useConverter = false)
        {
            using var ms = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(ms);
            if (useConverter)
            {
                JsonSerializer.Serialize(writer, payload);
            }
            else
            {
                payload.Write(writer);
            }
            writer.Flush();

            ms.Position = 0;
            using var sr = new StreamReader(ms);
            return sr.ReadToEnd();
        }

        [Test]
        public void SerializationFromJsonConverterForInt()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<int>>(IntJson);
            var actual = GetSerializedString(dfe , true);
            Assert.AreEqual(IntJson, actual);
        }

        [Test]
        public void SerializationFromJsonConverterForArray()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<Array>>(ArrayJson);
            var actual = GetSerializedString(dfe, true);
            Assert.AreEqual(IntJson, actual);
        }

        [Test]
        public void SerializationFromJsonConverterForBool()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<int>>(BoolJson);
            var actual = GetSerializedString(dfe, true);
            Assert.AreEqual(IntJson, actual);
        }

        [Test]
        public void SerializationFromJsonConverterForDouble()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<double>>(DoubleJson);
            var actual = GetSerializedString(dfe, true);
            Assert.AreEqual(IntJson, actual);
        }

        [Test]
        public void SerializationFromJsonConverterForEmptyArray()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<Array>>(EmptyArrayJson);
            var actual = GetSerializedString(dfe, true);
            Assert.AreEqual(IntJson, actual);
        }

        [Ignore("Discussing if we should support SecureString or just string")]
        [Test]
        public void SerializationFromJsonConverterForSecureString()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<SecureString>>(StringJson);
            var actual = GetSerializedString(dfe, true);
            Assert.AreEqual(IntJson, actual);
        }

        [Test]
        public void SerializationFromJsonConverterForString()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<string>>(StringJson);
            var actual = GetSerializedString(dfe, true);
            Assert.AreEqual(IntJson, actual);
        }

        [Test]
        public void SerializationFromJsonConverterForExpression()
        {
            var dfe = JsonSerializer.Deserialize<DataFactoryExpression<int>>(ExpressionJson);
            var actual = GetSerializedString(dfe, true);
            Assert.AreEqual(IntJson, actual);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Expressions
{
    /// <summary>
    /// Tests that BicepValue handles IPersistableModel types by converting
    /// their JSON serialization into Bicep expressions.
    /// </summary>
    public class BicepValueJsonConverterTests
    {
        /// <summary>
        /// A simple IJsonModel that serializes to a given JSON string.
        /// Used to test the JSON → Bicep conversion for various shapes.
        /// </summary>
        private class FakeModel : IJsonModel<FakeModel>
        {
            private readonly string _json;
            public FakeModel(string json) => _json = json;
            public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                using JsonDocument doc = JsonDocument.Parse(_json);
                doc.RootElement.WriteTo(writer);
            }
            public FakeModel Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotImplementedException();
            public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.FromString(_json);
            public FakeModel Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotImplementedException();
            public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        private static string CompileModel(string json)
        {
            var model = new FakeModel(json);
            var bicepValue = new BicepValue<FakeModel>(model);
            return bicepValue.Compile().ToString();
        }

        [Test]
        public void ConvertStringValue()
        {
            Assert.AreEqual("'hello'", CompileModel("\"hello\""));
        }

        [Test]
        public void ConvertIntValue()
        {
            Assert.AreEqual("42", CompileModel("42"));
        }

        [Test]
        public void ConvertNegativeIntValue()
        {
            Assert.AreEqual("-7", CompileModel("-7"));
        }

        [Test]
        public void ConvertBoolTrue()
        {
            Assert.AreEqual("true", CompileModel("true"));
        }

        [Test]
        public void ConvertBoolFalse()
        {
            Assert.AreEqual("false", CompileModel("false"));
        }

        [Test]
        public void ConvertNullValue()
        {
            Assert.AreEqual("null", CompileModel("null"));
        }

        [Test]
        public void ConvertSimpleObject()
        {
            string result = CompileModel("{\"name\":\"test\",\"count\":5}");
            Assert.That(result, Does.Contain("name: 'test'"));
            Assert.That(result, Does.Contain("count: 5"));
        }

        [Test]
        public void ConvertEmptyArray()
        {
            string result = CompileModel("[]");
            Assert.AreEqual("[]", result);
        }

        [Test]
        public void ConvertSimpleArray()
        {
            string result = CompileModel("[1,2,3]");
            Assert.That(result, Does.Contain("1"));
            Assert.That(result, Does.Contain("2"));
            Assert.That(result, Does.Contain("3"));
        }

        [Test]
        public void ConvertNestedObject()
        {
            string result = CompileModel("{\"outer\":{\"inner\":\"value\"}}");
            Assert.That(result, Does.Contain("outer:"));
            Assert.That(result, Does.Contain("inner: 'value'"));
        }

        [Test]
        public void ConvertMixedArray()
        {
            string result = CompileModel("[\"a\",1,true,null]");
            Assert.That(result, Does.Contain("'a'"));
            Assert.That(result, Does.Contain("1"));
            Assert.That(result, Does.Contain("true"));
            Assert.That(result, Does.Contain("null"));
        }
    }
}
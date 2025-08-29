// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.ClientModel.Tests.ModelReaderWriterTests;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    public class JsonModelConverterTests
    {
        private readonly JsonSerializerOptions _options;

        public JsonModelConverterTests()
        {
            _options = new JsonSerializerOptions();
            _options.Converters.Add(new JsonModelConverter());
        }

        [TestCaseSource(typeof(ReaderWriterTestSource), "NullBinaryData")]
        public void ValidateNullBinaryData(BinaryData data)
        {
            Assert.IsNull(JsonSerializer.Deserialize<ModelX>(data, _options));
            Assert.IsNull(JsonSerializer.Deserialize(data, typeof(ModelX), _options));
        }

        [TestCaseSource(typeof(ReaderWriterTestSource), "InvalidOperationBinaryData")]
        public void ValidateInvalidOperationBinaryData(BinaryData data) => ValidateJsonExceptionBinaryData(data);

        [TestCaseSource(typeof(ReaderWriterTestSource), "JsonExceptionBinaryData")]
        public void ValidateJsonExceptionBinaryData(BinaryData data)
        {
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<ModelX>(data, _options));
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize(data, typeof(ModelX), _options));
        }

        [TestCaseSource(typeof(ReaderWriterTestSource), "EmptyObjectBinaryData")]
        public void ValidateEmptyObjectBinaryData(BinaryData data)
        {
            Assert.Throws<JsonException>(() => ModelReaderWriter.Read<ModelX>(data));
            Assert.Throws<JsonException>(() => ModelReaderWriter.Read(data, typeof(ModelX)));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void CanSerializeTwoModelsWithSameConverter(string format)
        {
            CanSerializeTwoModelsWithSameConverter(format, null);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void CanSerializeTwoModelsWithSameConverter_WithContext(string format)
        {
            CanSerializeTwoModelsWithSameConverter(format, new TestClientModelReaderWriterContext());
        }

        private void CanSerializeTwoModelsWithSameConverter(string format, ModelReaderWriterContext? context)
        {
            string modelYResponse = "{\"kind\":\"Y\",\"name\":\"ymodel\",\"yProperty\":\"100\",\"extra\":\"stuff\"}";
            string modelXResponse = "{\"kind\":\"X\",\"name\":\"xmodel\",\"xProperty\":100,\"extra\":\"stuff\"}";

            var options = new JsonSerializerOptions();
            var mrwOptions = new ModelReaderWriterOptions(format);
            var converter = context is null ? new JsonModelConverter(mrwOptions) : new JsonModelConverter(mrwOptions, context);
            options.Converters.Add(converter);
            ModelY? modelY = JsonSerializer.Deserialize<ModelY>(modelYResponse, options);
            Assert.IsNotNull(modelY);

            Assert.AreEqual("Y", modelY!.Kind);
            Assert.AreEqual("ymodel", modelY.Name);
            if (format == "J")
                Assert.AreEqual("100", modelY.YProperty);

            var additionalProperties = GetRawData(modelY);
            Assert.IsNotNull(additionalProperties);
            if (format == "J")
                Assert.AreEqual("stuff", additionalProperties["extra"].ToObjectFromJson<string>());

            string expectedModelY = "{";
            expectedModelY += "\"kind\":\"Y\",\"name\":\"ymodel\"";
            if (format == "J")
                expectedModelY += ",\"yProperty\":\"100\",\"extra\":\"stuff\"";
            expectedModelY += "}";

            var actualModelY = JsonSerializer.Serialize(modelY, options);
            Assert.AreEqual(expectedModelY, actualModelY);

            ModelX? modelX = JsonSerializer.Deserialize<ModelX>(modelXResponse, options);
            Assert.IsNotNull(modelX);

            Assert.AreEqual("X", modelX!.Kind);
            Assert.AreEqual("xmodel", modelX.Name);
            if (format == "J")
                Assert.AreEqual(100, modelX.XProperty);

            additionalProperties = GetRawData(modelX);
            Assert.IsNotNull(additionalProperties);
            if (format == "J")
                Assert.AreEqual("stuff", additionalProperties["extra"].ToObjectFromJson<string>());

            string expectedModelX = "{";
            expectedModelX += "\"kind\":\"X\"";
            expectedModelX += ",\"name\":\"xmodel\"";
            if (format == "J")
                expectedModelX += ",\"xProperty\":100";
            if (format == "J")
                expectedModelX += ",\"extra\":\"stuff\"";
            expectedModelX += "}";

            var actualModelX = JsonSerializer.Serialize(modelX, options);
            Assert.AreEqual(expectedModelX, actualModelX);
        }

        [Test]
        public void NullContextThrows()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new JsonModelConverter(ModelReaderWriterOptions.Json, null!));
            Assert.IsNotNull(ex);
            Assert.AreEqual("context", ex!.ParamName);
        }

        [Test]
        public void NullOptionsThrows()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new JsonModelConverter(null!, new TestClientModelReaderWriterContext()));
            Assert.IsNotNull(ex);
            Assert.AreEqual("options", ex!.ParamName);
        }

        [Test]
        public void ConvertWithMissingInfo()
        {
            var options = new JsonSerializerOptions();
            var converter = new JsonModelConverter(ModelReaderWriterOptions.Json, new TestClientModelReaderWriterContext());
            options.Converters.Add(converter);
            var ex = Assert.Throws<InvalidOperationException>(() => JsonSerializer.Deserialize("{}", typeof(PersistableModel), options));
            Assert.IsNotNull(ex);
            Assert.AreEqual("No ModelReaderWriterTypeBuilder found for PersistableModel.  See 'https://aka.ms/no-modelreaderwritertypebuilder-found' for more info.", ex!.Message);
        }

        [Test]
        public void ConvertWithBadContext()
        {
            var options = new JsonSerializerOptions();
            var converter = new JsonModelConverter(ModelReaderWriterOptions.Json, SystemClientModelTestsInternalContext.Default);
            options.Converters.Add(converter);
            var ex = Assert.Throws<InvalidOperationException>(() => JsonSerializer.Deserialize("{}", typeof(PersistableModel), options));
            Assert.IsNotNull(ex);
            Assert.AreEqual("Either PersistableModel or the PersistableModelProxyAttribute defined needs to implement IJsonModel.", ex!.Message);
        }

        [Test]
        public void ConverterAddedWithNoJsonModel()
        {
            var data = new Person
            {
                Name = "John Doe"
            };
            var jsonOptions = new JsonSerializerOptions { Converters = { new JsonModelConverter() } };
            string json = JsonSerializer.Serialize(data, jsonOptions);
            Assert.AreEqual("{\"Name\":\"John Doe\"}", json);
        }

        private class Person
        {
            public string? Name { get; init; }
        }

        [Test]
        public void ConverterAddedWithMixedJsonModel()
        {
            var data = new PersonMixed
            {
                Name = "John Doe",
                Model = new ModelX()
                {
                    Name = "MyName",
                }
            };
            var jsonOptions = new JsonSerializerOptions { Converters = { new JsonModelConverter() } };
            string json = JsonSerializer.Serialize(data, jsonOptions);
            Assert.AreEqual("{\"Name\":\"John Doe\",\"Model\":{\"kind\":\"X\",\"name\":\"MyName\",\"fields\":[],\"keyValuePairs\":{},\"xProperty\":0}}", json);

            //without converter we should get PascalCase and different property order
            string json2 = JsonSerializer.Serialize(data);
            Assert.AreEqual("{\"Name\":\"John Doe\",\"Model\":{\"XProperty\":0,\"Fields\":[],\"KeyValuePairs\":{},\"Kind\":\"X\",\"Name\":\"MyName\"}}", json2);
        }

        private class PersonMixed
        {
            public string? Name { get; init; }
            public ModelX? Model { get; init; }
        }

        private static Dictionary<string, BinaryData> GetRawData(object model)
        {
            Type modelType = model.GetType();
            Assert.IsNotNull(modelType);
            while (modelType!.BaseType != typeof(object) && modelType.BaseType != typeof(ValueType))
            {
                modelType = modelType.BaseType!;
            }
            var propertyInfo = modelType.GetField("_serializedAdditionalRawData", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(propertyInfo);
            return (Dictionary<string, BinaryData>)propertyInfo!.GetValue(model)!;
        }

        internal class DoesNotImplementPersistableModel
        {
        }

        internal class PersistableModel : IJsonModel<PersistableModel>
        {
            public PersistableModel Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new();

            public PersistableModel Create(BinaryData data, ModelReaderWriterOptions options) => new();

            public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
            }

            public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
        }
    }
}

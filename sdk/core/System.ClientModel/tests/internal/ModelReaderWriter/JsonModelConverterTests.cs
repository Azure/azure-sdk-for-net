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
            Assert.That(JsonSerializer.Deserialize<ModelX>(data, _options), Is.Null);
            Assert.That(JsonSerializer.Deserialize(data, typeof(ModelX), _options), Is.Null);
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
            Assert.That(modelY, Is.Not.Null);

            Assert.That(modelY!.Kind, Is.EqualTo("Y"));
            Assert.That(modelY.Name, Is.EqualTo("ymodel"));
            if (format == "J")
                Assert.That(modelY.YProperty, Is.EqualTo("100"));

            var additionalProperties = GetRawData(modelY);
            Assert.That(additionalProperties, Is.Not.Null);
            if (format == "J")
                Assert.That(additionalProperties["extra"].ToObjectFromJson<string>(), Is.EqualTo("stuff"));

            string expectedModelY = "{";
            expectedModelY += "\"kind\":\"Y\",\"name\":\"ymodel\"";
            if (format == "J")
                expectedModelY += ",\"yProperty\":\"100\",\"extra\":\"stuff\"";
            expectedModelY += "}";

            var actualModelY = JsonSerializer.Serialize(modelY, options);
            Assert.That(actualModelY, Is.EqualTo(expectedModelY));

            ModelX? modelX = JsonSerializer.Deserialize<ModelX>(modelXResponse, options);
            Assert.That(modelX, Is.Not.Null);

            Assert.That(modelX!.Kind, Is.EqualTo("X"));
            Assert.That(modelX.Name, Is.EqualTo("xmodel"));
            if (format == "J")
                Assert.That(modelX.XProperty, Is.EqualTo(100));

            additionalProperties = GetRawData(modelX);
            Assert.That(additionalProperties, Is.Not.Null);
            if (format == "J")
                Assert.That(additionalProperties["extra"].ToObjectFromJson<string>(), Is.EqualTo("stuff"));

            string expectedModelX = "{";
            expectedModelX += "\"kind\":\"X\"";
            expectedModelX += ",\"name\":\"xmodel\"";
            if (format == "J")
                expectedModelX += ",\"xProperty\":100";
            if (format == "J")
                expectedModelX += ",\"extra\":\"stuff\"";
            expectedModelX += "}";

            var actualModelX = JsonSerializer.Serialize(modelX, options);
            Assert.That(actualModelX, Is.EqualTo(expectedModelX));
        }

        [Test]
        public void NullContextThrows()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new JsonModelConverter(ModelReaderWriterOptions.Json, null!));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.ParamName, Is.EqualTo("context"));
        }

        [Test]
        public void NullOptionsThrows()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new JsonModelConverter(null!, new TestClientModelReaderWriterContext()));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.ParamName, Is.EqualTo("options"));
        }

        [Test]
        public void ConvertWithMissingInfo()
        {
            var options = new JsonSerializerOptions();
            var converter = new JsonModelConverter(ModelReaderWriterOptions.Json, new TestClientModelReaderWriterContext());
            options.Converters.Add(converter);
            var ex = Assert.Throws<InvalidOperationException>(() => JsonSerializer.Deserialize("{}", typeof(PersistableModel), options));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("No ModelReaderWriterTypeBuilder found for PersistableModel.  See 'https://aka.ms/no-modelreaderwritertypebuilder-found' for more info."));
        }

        [Test]
        public void ConvertWithBadContext()
        {
            var options = new JsonSerializerOptions();
            var converter = new JsonModelConverter(ModelReaderWriterOptions.Json, SystemClientModelTestsInternalContext.Default);
            options.Converters.Add(converter);
            var ex = Assert.Throws<InvalidOperationException>(() => JsonSerializer.Deserialize("{}", typeof(PersistableModel), options));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("Either PersistableModel or the PersistableModelProxyAttribute defined needs to implement IJsonModel."));
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
            Assert.That(json, Is.EqualTo("{\"Name\":\"John Doe\"}"));
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
            Assert.That(json, Is.EqualTo("{\"Name\":\"John Doe\",\"Model\":{\"kind\":\"X\",\"name\":\"MyName\",\"fields\":[],\"keyValuePairs\":{},\"xProperty\":0}}"));

            //without converter we should get PascalCase and different property order
            string json2 = JsonSerializer.Serialize(data);
            Assert.That(json2, Is.EqualTo("{\"Name\":\"John Doe\",\"Model\":{\"XProperty\":0,\"Fields\":[],\"KeyValuePairs\":{},\"Kind\":\"X\",\"Name\":\"MyName\"}}"));
        }

        private class PersonMixed
        {
            public string? Name { get; init; }
            public ModelX? Model { get; init; }
        }

        private static Dictionary<string, BinaryData> GetRawData(object model)
        {
            Type modelType = model.GetType();
            Assert.That(modelType, Is.Not.Null);
            while (modelType!.BaseType != typeof(object) && modelType.BaseType != typeof(ValueType))
            {
                modelType = modelType.BaseType!;
            }
            var propertyInfo = modelType.GetField("_serializedAdditionalRawData", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(propertyInfo, Is.Not.Null);
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

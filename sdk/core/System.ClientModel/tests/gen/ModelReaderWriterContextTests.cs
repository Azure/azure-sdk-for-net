// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests
{
    internal class ModelReaderWriterContextTests
    {
        [Test]
        public void JsonModelIsPresent()
        {
            var modelInfo = BasicContext.Default.GetTypeBuilder(typeof(JsonModel));
            Assert.IsNotNull(modelInfo);
            JsonModel? model = InvokeCreateObject(modelInfo) as JsonModel;
            Assert.IsNotNull(model);
            var ex = Assert.Throws<InvalidOperationException>(() => BasicContext.Default.GetTypeBuilder(typeof(string)));
            Assert.IsNotNull(ex);
            Assert.AreEqual("No ModelReaderWriterTypeBuilder found for String.  See 'https://aka.ms/no-modelreaderwritertypebuilder-found' for more info.", ex!.Message);
        }

        [Test]
        public void PersistableModelIsPresent()
        {
            var modelInfo = BasicContext.Default.GetTypeBuilder(typeof(PersistableModel));
            Assert.IsNotNull(modelInfo);
            PersistableModel? model = InvokeCreateObject(modelInfo) as PersistableModel;
            Assert.IsNotNull(model);
            var ex = Assert.Throws<InvalidOperationException>(() => BasicContext.Default.GetTypeBuilder(typeof(string)));
            Assert.IsNotNull(ex);
            Assert.AreEqual("No ModelReaderWriterTypeBuilder found for String.  See 'https://aka.ms/no-modelreaderwritertypebuilder-found' for more info.", ex!.Message);
        }

        [Test]
        public void ReadOnlyJsonModelIsPresent()
        {
            var modelInfo = BasicContext.Default.GetTypeBuilder(typeof(ReadOnlyMemory<JsonModel>));
            Assert.IsNotNull(modelInfo);
            List<JsonModel>? model = InvokeCreateInstance(modelInfo) as List<JsonModel>;
            Assert.IsNotNull(model);
        }

        private object? InvokeCreateObject(ModelReaderWriterTypeBuilder modelInfo)
        {
            var method = modelInfo.GetType().GetMethod("CreateObject", Reflection.BindingFlags.NonPublic | Reflection.BindingFlags.Instance);
            return method!.Invoke(modelInfo, null);
        }

        private object? InvokeCreateInstance(ModelReaderWriterTypeBuilder modelInfo)
        {
            var method = modelInfo.GetType().GetMethod("CreateInstance", Reflection.BindingFlags.NonPublic | Reflection.BindingFlags.Instance);
            return method!.Invoke(modelInfo, null);
        }

        // ---- AOT-compatibility: proxies must work through the source-generated ModelReaderWriterContext
        // (the AOT-safe path — no reflection). Predicates receive options independently of the context.

        [Test]
        public void ConditionalProxy_ReadThroughGeneratedContext_IsAotSafe()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new TrackingJsonModelProxy();
            options.Proxies.Add(proxy);

            var result = ModelReaderWriter.Read<JsonModel>(BinaryData.FromString("{}"), options, BasicContext.Default);

            Assert.IsNotNull(result);
            Assert.IsTrue(proxy.CanHandleCalled, "CanHandle should be consulted on the generated-context path.");
            Assert.AreSame(options, proxy.LastOptions, "the caller's options should flow into CanHandle.");
            Assert.IsTrue(proxy.CreateCalled, "the proxy itself should perform the deserialization.");
        }

        [Test]
        public void ConditionalProxy_WriteThroughGeneratedContext_IsAotSafe()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new TrackingJsonModelProxy();
            options.Proxies.Add(proxy);

            var data = ModelReaderWriter.Write(new JsonModel(), options, BasicContext.Default);

            Assert.IsNotNull(data);
            Assert.IsTrue(proxy.CanHandleCalled, "CanHandle should be consulted on the write path.");
            Assert.AreSame(options, proxy.LastOptions, "the caller's options should flow into CanHandle.");
            Assert.AreEqual("{}", data.ToString());
        }

        [Test]
        public void ConditionalProxy_CollectionAndConverterUseDeclaredType_WithGeneratedContext()
        {
            const string payload = "{\"kind\":\"extension\"}";
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ExtendedBaseModelProxy();
            options.Proxies.Add(proxy);

            BaseModel? single = ModelReaderWriter.Read<BaseModel>(BinaryData.FromString(payload), options, BasicContext.Default);
            List<BaseModel>? collection = ModelReaderWriter.Read<List<BaseModel>>(
                BinaryData.FromString($"[{payload}]"), options, BasicContext.Default);
            var jsonOptions = new JsonSerializerOptions
            {
                Converters = { new JsonModelConverter(options, BasicContext.Default) }
            };
            BaseModel? fromConverter = JsonSerializer.Deserialize<BaseModel>(payload, jsonOptions);
            List<BaseModel>? converterCollection = JsonSerializer.Deserialize<List<BaseModel>>($"[{payload}]", jsonOptions);
            BaseModel? withoutProxy = ModelReaderWriter.Read<BaseModel>(
                BinaryData.FromString(payload), ModelReaderWriterOptions.Json, BasicContext.Default);

            Assert.IsInstanceOf<ModelY>(single);
            Assert.IsNotNull(collection);
            Assert.IsInstanceOf<ModelY>(collection![0]);
            Assert.AreEqual("from-proxy", collection[0].Name);
            Assert.IsInstanceOf<ModelY>(fromConverter);
            Assert.IsNotNull(converterCollection);
            Assert.IsInstanceOf<ModelY>(converterCollection![0]);
            Assert.IsInstanceOf<UnknownBaseModel>(withoutProxy);
            Assert.AreSame(options, proxy.LastOptions);
        }

        [Test]
        public void ConditionalProxy_BaseRegistration_SameInstanceWritesIdenticallyAcrossContracts()
        {
            const string payload = "{\"kind\":\"extension\",\"name\":\"ignored\"}";
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ExtendedBaseModelProxy(modelYOnly: true);
            options.Proxies.Add(proxy);

            ModelY? result = ModelReaderWriter.Read<ModelY>(BinaryData.FromString(payload), options, BasicContext.Default);
            BaseModel? registeredBase = ModelReaderWriter.Read<BaseModel>(BinaryData.FromString(payload), options, BasicContext.Default);
            ModelX? declinedPayload = ModelReaderWriter.Read<ModelX>(
                BinaryData.FromString("{\"kind\":\"X\",\"name\":\"sibling\"}"), options, BasicContext.Default);
            var jsonOptions = new JsonSerializerOptions
            {
                Converters = { new JsonModelConverter(options, BasicContext.Default) }
            };
            ModelY? converted = JsonSerializer.Deserialize<ModelY>(payload, jsonOptions);
            var model = new ModelY { Name = "original" };
            BinaryData written = ModelReaderWriter.Write(model, options, BasicContext.Default);
            BinaryData writtenAsBase = ModelReaderWriter.Write<BaseModel>(model, options, BasicContext.Default);
            BinaryData writtenAsObject = ModelReaderWriter.Write<object>(model, options, BasicContext.Default);

            Assert.IsNotNull(result);
            Assert.AreEqual("from-proxy", result!.Name);
            Assert.IsInstanceOf<ModelY>(registeredBase);
            Assert.AreEqual("from-proxy", registeredBase!.Name);
            Assert.IsNotNull(declinedPayload);
            Assert.AreEqual("sibling", declinedPayload!.Name);
            Assert.IsNotNull(converted);
            Assert.AreEqual("from-proxy", converted!.Name);
            Assert.AreEqual("{\"kind\":\"Y\"}", written.ToString());
            Assert.AreEqual(written.ToString(), writtenAsBase.ToString());
            Assert.AreEqual(written.ToString(), writtenAsObject.ToString());
            var sibling = new ModelX { Name = "sibling" };
            Assert.AreEqual(
                ModelReaderWriter.Write(sibling, ModelReaderWriterOptions.Json, BasicContext.Default).ToString(),
                ModelReaderWriter.Write(sibling, options, BasicContext.Default).ToString(),
                "CanHandle must keep the proxy from taking over the sibling ModelX.");
            Assert.AreEqual(
                ModelReaderWriter.Write<BaseModel>(sibling, ModelReaderWriterOptions.Json, BasicContext.Default).ToString(),
                ModelReaderWriter.Write<BaseModel>(sibling, options, BasicContext.Default).ToString());
            var models = new List<BaseModel> { model, sibling };
            Assert.AreEqual(
                $"[{written},{ModelReaderWriter.Write<BaseModel>(sibling, ModelReaderWriterOptions.Json, BasicContext.Default)}]",
                ModelReaderWriter.Write(models, options, BasicContext.Default).ToString());
            Assert.AreSame(options, proxy.LastOptions);
            Assert.IsNull(options.ProxiedModel);
        }

        private sealed class ExtendedBaseModelProxy : ModelProxy<BaseModel>, IJsonModel<BaseModel>
        {
            private readonly bool _modelYOnly;

            public ExtendedBaseModelProxy(bool modelYOnly = false) => _modelYOnly = modelYOnly;

            public ModelReaderWriterOptions? LastOptions { get; private set; }

            public override bool CanHandle(BaseModel model, ModelReaderWriterOptions options)
            {
                LastOptions = options;
                return !_modelYOnly || model is ModelY;
            }

            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options)
            {
                LastOptions = options;
                using JsonDocument doc = JsonDocument.Parse(data);
                return doc.RootElement.TryGetProperty("kind", out JsonElement kind) && kind.GetString() == "extension";
            }

            public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                LastOptions = options;
                Utf8JsonReader copy = reader;
                using JsonDocument doc = JsonDocument.ParseValue(ref copy);
                return doc.RootElement.TryGetProperty("kind", out JsonElement kind) && kind.GetString() == "extension";
            }

            BaseModel IJsonModel<BaseModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using JsonDocument doc = JsonDocument.ParseValue(ref reader);
                return new ModelY { Name = "from-proxy" };
            }

            public override BaseModel Create(BinaryData data, ModelReaderWriterOptions options) => new ModelY { Name = "from-proxy" };

            void IJsonModel<BaseModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteString("kind", "Y");
                writer.WriteEndObject();
            }

            public override BinaryData Write(ModelReaderWriterOptions options) => BinaryData.FromString("{\"kind\":\"Y\"}");

            public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        /// <summary>
        /// A conditional proxy over the generated-context model <see cref="JsonModel"/> that records the
        /// options passed to <c>CanHandle</c> so the AOT-safe entrypoints can be verified independently.
        /// </summary>
        private class TrackingJsonModelProxy : ModelProxy<JsonModel>, IJsonModel<JsonModel>
        {
            public bool CanHandleCalled { get; private set; }
            public ModelReaderWriterOptions? LastOptions { get; private set; }
            public bool CreateCalled { get; private set; }

            public override bool CanHandle(JsonModel model, ModelReaderWriterOptions options)
            {
                CanHandleCalled = true;
                LastOptions = options;
                return true;
            }

            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options)
            {
                CanHandleCalled = true;
                LastOptions = options;
                return true;
            }

            public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                CanHandleCalled = true;
                LastOptions = options;
                return true;
            }

            JsonModel IJsonModel<JsonModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                CreateCalled = true;
                using var doc = JsonDocument.ParseValue(ref reader);
                return new JsonModel();
            }

            public override JsonModel Create(BinaryData data, ModelReaderWriterOptions options)
            {
                CreateCalled = true;
                return new JsonModel();
            }

            public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            void IJsonModel<JsonModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            public override BinaryData Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");
        }
    }
}

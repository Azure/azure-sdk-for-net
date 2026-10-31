// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
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
        // (the AOT-safe path — no reflection), and the generated context + options must flow into CanHandle.

        [Test]
        public void ConditionalProxy_ReadThroughGeneratedContext_IsAotSafe()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new TrackingJsonModelProxy();
            options.AddProxy<JsonModel>(proxy);

            var result = ModelReaderWriter.Read<JsonModel>(BinaryData.FromString("{}"), options, BasicContext.Default);

            Assert.IsNotNull(result);
            Assert.IsTrue(proxy.CanHandleCalled, "CanHandle should be consulted on the generated-context path.");
            Assert.AreSame(BasicContext.Default, proxy.LastContext, "the generated ModelReaderWriterContext should flow into CanHandle.");
            Assert.AreSame(options, proxy.LastOptions, "the caller's options should flow into CanHandle.");
            Assert.IsTrue(proxy.HeldModelCreateCalled, "the proxy's held model should perform the deserialization.");
        }

        [Test]
        public void ConditionalProxy_WriteThroughGeneratedContext_IsAotSafe()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new TrackingJsonModelProxy();
            options.AddProxy<JsonModel>(proxy);

            var data = ModelReaderWriter.Write(new JsonModel(), options, BasicContext.Default);

            Assert.IsNotNull(data);
            Assert.IsTrue(proxy.CanHandleCalled, "CanHandle should be consulted on the write path.");
            Assert.AreSame(BasicContext.Default, proxy.LastContext, "the generated ModelReaderWriterContext should flow into CanHandle.");
            Assert.AreSame(options, proxy.LastOptions, "the caller's options should flow into CanHandle.");
        }

        [Test]
        public void ConditionalProxy_CollectionAndConverterUseDeclaredType_WithGeneratedContext()
        {
            const string payload = "{\"kind\":\"extension\"}";
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ExtendedBaseModelProxy();
            options.AddProxy<BaseModel>(proxy);

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
            Assert.AreSame(BasicContext.Default, proxy.LastContext);
            Assert.AreSame(options, proxy.LastOptions);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ConditionalProxy_ConfiguredGeneratedContextSupportsStandaloneWrites(bool requestBody)
        {
            var options = new ModelReaderWriterOptions("J", BasicContext.Default);
            var proxy = new TrackingJsonModelProxy();
            options.AddProxy<JsonModel>(proxy);
            var model = new JsonModel();

            using var stream = new MemoryStream();
            if (requestBody)
            {
                using BinaryContent content = BinaryContent.Create(model, options);
                content.WriteTo(stream);
                Assert.IsNull(options.ProxiedModel);
            }
            else
            {
                using var writer = new Utf8JsonWriter(stream);
                options.ResolveProxy((IJsonModel<JsonModel>)model).Write(writer, options);
                writer.Flush();
            }

            Assert.AreEqual("{}", BinaryData.FromBytes(stream.ToArray()).ToString());
            Assert.AreSame(BasicContext.Default, proxy.LastContext);
            Assert.AreSame(options, proxy.LastOptions);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ConditionalProxy_OptionsCopyPreservesGeneratedContext(bool explicitContext)
        {
            var original = new ModelReaderWriterOptions("J", BasicContext.Default);
            var proxy = new TrackingJsonModelProxy();
            original.AddProxy<JsonModel>(proxy);
            var copy = explicitContext
                ? new ModelReaderWriterOptions("J", original, BasicContext.Default)
                : new ModelReaderWriterOptions("J", original);

            using BinaryContent content = BinaryContent.Create(new JsonModel(), copy);
            using var stream = new MemoryStream();
            content.WriteTo(stream);

            Assert.AreSame(BasicContext.Default, proxy.LastContext);
            Assert.AreSame(original, proxy.LastOptions);
            Assert.IsNull(copy.ProxiedModel);
            Assert.IsNull(original.ProxiedModel);
        }

        private sealed class ExtendedBaseModelProxy : ConditionalModelProxy<BaseModel>
        {
            public ModelReaderWriterContext? LastContext { get; private set; }
            public ModelReaderWriterOptions? LastOptions { get; private set; }

            public ExtendedBaseModelProxy() : base(new ExtendedBaseModel()) { }

            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context)
            {
                LastContext = context;
                LastOptions = options;
                using JsonDocument doc = JsonDocument.Parse(data);
                return doc.RootElement.TryGetProperty("kind", out JsonElement kind) && kind.GetString() == "extension";
            }

            public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options, ModelReaderWriterContext context)
            {
                LastContext = context;
                LastOptions = options;
                Utf8JsonReader copy = reader;
                using JsonDocument doc = JsonDocument.ParseValue(ref copy);
                return doc.RootElement.TryGetProperty("kind", out JsonElement kind) && kind.GetString() == "extension";
            }

            private sealed class ExtendedBaseModel : IJsonModel<BaseModel>
            {
                public BaseModel Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                {
                    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
                    return new ModelY { Name = "from-proxy" };
                }

                public BaseModel Create(BinaryData data, ModelReaderWriterOptions options) => new ModelY { Name = "from-proxy" };

                public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
                {
                    writer.WriteStartObject();
                    writer.WriteString("kind", "Y");
                    writer.WriteEndObject();
                }

                public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.FromString("{\"kind\":\"Y\"}");

                public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
            }
        }

        /// <summary>
        /// A conditional proxy over the generated-context model <see cref="JsonModel"/> that records the
        /// options and context passed to <c>CanHandle</c> so the AOT-safe path can be verified.
        /// </summary>
        private class TrackingJsonModelProxy : ConditionalModelProxy<JsonModel>
        {
            public bool CanHandleCalled { get; private set; }
            public ModelReaderWriterOptions? LastOptions { get; private set; }
            public ModelReaderWriterContext? LastContext { get; private set; }
            public bool HeldModelCreateCalled => ((TrackingJsonModel)Model).CreateCalled;

            public TrackingJsonModelProxy() : base(new TrackingJsonModel()) { }

            public override bool CanHandle(JsonModel model, ModelReaderWriterOptions options, ModelReaderWriterContext context)
            {
                Assert.IsNotNull(context.GetTypeBuilder(typeof(JsonModel)));
                CanHandleCalled = true;
                LastOptions = options;
                LastContext = context;
                return true;
            }

            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context)
            {
                Assert.IsNotNull(context.GetTypeBuilder(typeof(JsonModel)));
                CanHandleCalled = true;
                LastOptions = options;
                LastContext = context;
                return true;
            }
        }

        private class TrackingJsonModel : IJsonModel<JsonModel>
        {
            public bool CreateCalled { get; private set; }

            public JsonModel Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                CreateCalled = true;
                using var doc = JsonDocument.ParseValue(ref reader);
                return new JsonModel();
            }

            public JsonModel Create(BinaryData data, ModelReaderWriterOptions options)
            {
                CreateCalled = true;
                return new JsonModel();
            }

            public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");
        }
    }
}

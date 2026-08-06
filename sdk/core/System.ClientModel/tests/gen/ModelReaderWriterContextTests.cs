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
                CanHandleCalled = true;
                LastOptions = options;
                LastContext = context;
                return true;
            }

            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context)
            {
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

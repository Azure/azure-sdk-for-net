// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support;
using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    public class ModelReaderWriterProxyChainTests
    {
        #region Chain of responsibility read tests

        [Test]
        public void ReadWithChain_SingleProxy_ReturnsProxyResult()
        {
            var options = new ModelReaderWriterOptions("J", ModelReaderWriterReflectionContext.Default);
            var proxy = new ChainProxy(handleRead: true);
            options.AddProxy<SimpleModel>(proxy);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            var result = options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);
            Assert.IsNotNull(result);
            Assert.IsTrue(proxy.CreateWasCalled);
        }

        [Test]
        public void ReadWithChain_ProxyDeclinesWithCanHandle_FallsToModel()
        {
            var options = new ModelReaderWriterOptions("J", ModelReaderWriterReflectionContext.Default);
            var proxy = new ChainProxy(handleRead: false); // CanHandle returns false = decline
            options.AddProxy<SimpleModel>(proxy);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            var result = options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);
            Assert.IsNotNull(result);
            Assert.IsFalse(proxy.CreateWasCalled);
            // Model handled it since proxy declined
            Assert.IsNull(options.ProxiedModel);
        }

        [Test]
        public void ReadWithChain_SecondProxyHandlesAfterFirstDeclines()
        {
            var options = new ModelReaderWriterOptions("J", ModelReaderWriterReflectionContext.Default);
            var proxy1 = new ChainProxy(handleRead: false);  // will decline (tried first, FIFO)
            var proxy2 = new ChainProxy(handleRead: true);   // will handle

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            var result = options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);

            Assert.IsNotNull(result);
            // proxy1 was tried first (first added, FIFO), declined via CanHandle
            Assert.IsFalse(proxy1.CreateWasCalled);
            // proxy2 was tried next, handled it
            Assert.IsTrue(proxy2.CreateWasCalled);
        }

        [Test]
        public void ReadWithChain_AllProxiesDecline_ModelHandlesIt()
        {
            var options = new ModelReaderWriterOptions("J", ModelReaderWriterReflectionContext.Default);
            var proxy1 = new ChainProxy(handleRead: false);
            var proxy2 = new ChainProxy(handleRead: false);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            var result = options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);

            Assert.IsNotNull(result);
            Assert.IsFalse(proxy1.CreateWasCalled);
            Assert.IsFalse(proxy2.CreateWasCalled);
            // ProxiedModel cleared since model handled it
            Assert.IsNull(options.ProxiedModel);
        }

        [Test]
        public void ReadWithChain_NoProxies_ModelHandlesIt()
        {
            var options = new ModelReaderWriterOptions("J");
            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");

            var result = options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);
            Assert.IsNotNull(result);
        }

        [Test]
        public void ReadWithChain_DiscriminatorPattern()
        {
            var options = new ModelReaderWriterOptions("J", ModelReaderWriterReflectionContext.Default);
            // Discriminator proxy only handles data containing "special" — registered first (FIFO)
            var discriminatorProxy = new DiscriminatorProxy("special");
            // Default proxy handles everything — registered second (fallback)
            var defaultProxy = new ChainProxy(handleRead: true);

            options.AddProxy<SimpleModel>(discriminatorProxy);
            options.AddProxy<SimpleModel>(defaultProxy);

            var model = new SimpleModel();

            // Data with discriminator — discriminatorProxy handles
            var specialData = BinaryData.FromString("{\"type\":\"special\"}");
            var result = options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, specialData);
            Assert.IsNotNull(result);
            Assert.IsTrue(discriminatorProxy.CreateWasCalled);
            Assert.IsFalse(defaultProxy.CreateWasCalled);

            // Reset
            discriminatorProxy.Reset();
            defaultProxy.Reset();

            // Data without discriminator — discriminatorProxy declines via CanHandle, defaultProxy handles
            var normalData = BinaryData.FromString("{\"type\":\"standard\"}");
            result = options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, normalData);
            Assert.IsNotNull(result);
            Assert.IsFalse(discriminatorProxy.CreateWasCalled); // CanHandle returned false, Create not called
            Assert.IsTrue(defaultProxy.CreateWasCalled); // handled it
        }

        #endregion

        #region JsonModelConverter chain-of-responsibility tests

        [Test]
        public void JsonModelConverter_Read_ChainSecondProxyHandlesAfterFirstDeclines()
        {
            var mrwOptions = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: false);  // declines via CanHandle
            var proxy2 = new ChainProxy(handleRead: true);   // handles

            mrwOptions.AddProxy<SimpleModel>(proxy1);
            mrwOptions.AddProxy<SimpleModel>(proxy2);

            var stjOptions = new JsonSerializerOptions();
            stjOptions.Converters.Add(new JsonModelConverter(mrwOptions));

            var result = JsonSerializer.Deserialize<SimpleModel>("{}", stjOptions);

            Assert.IsNotNull(result);
            Assert.IsFalse(proxy1.CreateWasCalled,
                "proxy1 should have declined via CanHandle and not had Create called.");
            Assert.IsTrue(proxy2.CreateWasCalled,
                "proxy2 should have handled the read after proxy1 declined.");
        }

        [Test]
        public void JsonModelConverter_Read_AllProxiesDecline_ModelHandles()
        {
            var mrwOptions = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: false);
            var proxy2 = new ChainProxy(handleRead: false);

            mrwOptions.AddProxy<SimpleModel>(proxy1);
            mrwOptions.AddProxy<SimpleModel>(proxy2);

            var stjOptions = new JsonSerializerOptions();
            stjOptions.Converters.Add(new JsonModelConverter(mrwOptions));

            var result = JsonSerializer.Deserialize<SimpleModel>("{}", stjOptions);

            Assert.IsNotNull(result);
            Assert.IsFalse(proxy1.CreateWasCalled);
            Assert.IsFalse(proxy2.CreateWasCalled);
        }

        [Test]
        public void JsonModelConverter_Read_DiscriminatorPattern()
        {
            var mrwOptions = new ModelReaderWriterOptions("J");
            var discriminatorProxy = new DiscriminatorProxy("special");
            var defaultProxy = new ChainProxy(handleRead: true);

            mrwOptions.AddProxy<SimpleModel>(discriminatorProxy);
            mrwOptions.AddProxy<SimpleModel>(defaultProxy);

            var stjOptions = new JsonSerializerOptions();
            stjOptions.Converters.Add(new JsonModelConverter(mrwOptions));

            // Discriminator matches — first proxy handles
            var specialResult = JsonSerializer.Deserialize<SimpleModel>("{\"type\":\"special\"}", stjOptions);
            Assert.IsNotNull(specialResult);
            Assert.IsTrue(discriminatorProxy.CreateWasCalled);
            Assert.IsFalse(defaultProxy.CreateWasCalled);

            discriminatorProxy.Reset();
            defaultProxy.Reset();

            // Discriminator doesn't match — first declines, second handles
            var normalResult = JsonSerializer.Deserialize<SimpleModel>("{\"type\":\"other\"}", stjOptions);
            Assert.IsNotNull(normalResult);
            Assert.IsFalse(discriminatorProxy.CreateWasCalled);
            Assert.IsTrue(defaultProxy.CreateWasCalled);
        }

        [Test]
        public void JsonModelConverter_Write_UsesChainCanHandle()
        {
            var mrwOptions = new ModelReaderWriterOptions("J");
            var proxy1 = new SelectiveWriteProxy(canWrite: false); // declines
            var proxy2 = new SelectiveWriteProxy(canWrite: true);  // handles

            mrwOptions.AddProxy<SimpleModel>(proxy1);
            mrwOptions.AddProxy<SimpleModel>(proxy2);

            var stjOptions = new JsonSerializerOptions();
            stjOptions.Converters.Add(new JsonModelConverter(mrwOptions));

            var model = new SimpleModel();
            string json = JsonSerializer.Serialize<IJsonModel<object>>((IJsonModel<object>)(object)model, stjOptions);

            Assert.IsFalse(proxy1.WriteWasCalled,
                "proxy1 should have declined via CanHandle(model) on the write path.");
            Assert.IsTrue(proxy2.WriteWasCalled,
                "proxy2 should have handled the write after proxy1 declined.");
        }

        #endregion

        #region Non-generic ReadWithChain (Type overload)

        [Test]
        public void ReadWithChain_NonGeneric_SecondProxyHandles()
        {
            var options = new ModelReaderWriterOptions("J", ModelReaderWriterReflectionContext.Default);
            var proxy1 = new ChainProxy(handleRead: false);
            var proxy2 = new ChainProxy(handleRead: true);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var jsonBytes = Text.Encoding.UTF8.GetBytes("{}");
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read();

            var result = options.ReadWithChain(typeof(SimpleModel), (IJsonModel<object>)(object)model, ref reader);

            Assert.IsNotNull(result);
            Assert.IsFalse(proxy1.CreateWasCalled);
            Assert.IsTrue(proxy2.CreateWasCalled);
        }

        [Test]
        public void ReadWithChain_NonGeneric_AllDecline_ModelHandles()
        {
            var options = new ModelReaderWriterOptions("J", ModelReaderWriterReflectionContext.Default);
            var proxy1 = new ChainProxy(handleRead: false);
            var proxy2 = new ChainProxy(handleRead: false);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var jsonBytes = Text.Encoding.UTF8.GetBytes("{}");
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read();

            var result = options.ReadWithChain(typeof(SimpleModel), (IJsonModel<object>)(object)model, ref reader);

            Assert.IsNotNull(result);
            Assert.IsFalse(proxy1.CreateWasCalled);
            Assert.IsFalse(proxy2.CreateWasCalled);
        }

        #endregion

        #region Collection read with chain

        [Test]
        public void CollectionRead_WithChain_PerElementDiscrimination()
        {
            var options = new ModelReaderWriterOptions("J");
            var discriminatorProxy = new DiscriminatorProxy("special");
            var defaultProxy = new ChainProxy(handleRead: true);

            options.AddProxy<SimpleModel>(discriminatorProxy);
            options.AddProxy<SimpleModel>(defaultProxy);

            // Read a list where elements differ — the chain should route per-element
            var json = "[{\"type\":\"special\"},{\"type\":\"other\"},{\"type\":\"special\"}]";
            var result = ModelReaderWriter.Read<List<SimpleModel>>(BinaryData.FromString(json), options);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result!.Count);
        }

        #endregion

        /// <summary>
        /// A proxy that peeks at the data to check for a discriminator value.
        /// </summary>
        private class DiscriminatorProxy : ConditionalModelProxy<SimpleModel>
        {
            private readonly string _discriminatorValue;
            public bool CreateWasCalled => ((TrackingModel)Model).CreateWasCalled;

            public DiscriminatorProxy(string discriminatorValue)
                : base(new TrackingModel())
            {
                _discriminatorValue = discriminatorValue;
            }

            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context)
            {
                return BinaryData.FromBytes(data).ToString().Contains($"\"type\":\"{_discriminatorValue}\"");
            }

            public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options, ModelReaderWriterContext context)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return document.RootElement.TryGetProperty("type", out var type) && type.GetString() == _discriminatorValue;
            }

            public void Reset() => ((TrackingModel)Model).Reset();
        }
    }
}

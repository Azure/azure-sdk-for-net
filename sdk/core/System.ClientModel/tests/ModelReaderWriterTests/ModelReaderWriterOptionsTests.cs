// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public class ModelReaderWriterOptionsTests
    {
        private static Dictionary<object, ModelReaderWriterOptions> _optionsMap = [];
        [ThreadStatic]
        private static ModelReaderWriterOptions? _defaultOptions;

        [SetUp]
        public void SetUp()
        {
            _defaultOptions = ModelReaderWriterOptions.Json;
        }

        [Test]
        public void Write_ShouldBeSameInstanceIfNull()
        {
            var model = new JsonModel();
            ModelReaderWriter.Write(model);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Write_ShouldBeSameIfNoProxies(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var model = new JsonModel();
            _optionsMap.Add(model, options);
            ModelReaderWriter.Write(model, options);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Write_ShouldBeSameIfSecondPassThrough(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy = new JsonModelProxy();
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy);
            var newOptions = new ModelReaderWriterOptions(options);
            var model = new JsonModel();
            _optionsMap.Add(proxy, newOptions);
            ModelReaderWriter.Write(model, newOptions);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Write_ShouldBeDifferentIfProxied(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy = new JsonModelProxy();
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy);
            var model = new JsonModel();
            _optionsMap.Add(proxy, options);
            ModelReaderWriter.Write(model, options);
        }

        [Test]
        public void Read_ShouldBeSameInstanceIfNull()
        {
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Read_ShouldBeSameIfNoProxies(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            _defaultOptions = options;
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty, options);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Read_ShouldBeSameIfSecondPassThrough(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy = new JsonModelProxy();
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy);
            var newOptions = new ModelReaderWriterOptions(options);
            _optionsMap.Add(proxy, newOptions);
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty, newOptions);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Read_ShouldBeDifferentIfProxied(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy = new JsonModelProxy();
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy);
            _optionsMap.Add(proxy, options);
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty, options);
        }

        private static void AssertOptions(object model, ModelReaderWriterOptions options)
        {
            _optionsMap.TryGetValue(model, out var passedInOptions);
            passedInOptions ??= _defaultOptions;

            if (passedInOptions!.HasProxies && passedInOptions?.IsCoreOwned == false)
            {
                Assert.IsFalse(ReferenceEquals(passedInOptions, options));
                Assert.IsTrue(options.IsCoreOwned);
                Assert.AreEqual(passedInOptions.Format, options.Format);
                var passedInProxies = GetProxies(passedInOptions);
                var optionProxies = GetProxies(options);
                Assert.IsNotNull(passedInProxies);
                Assert.IsNotNull(optionProxies);
                // Proxies dictionary is shared by reference between original and copy
                Assert.AreSame(passedInProxies, optionProxies);
            }
            else
            {
                Assert.IsTrue(ReferenceEquals(passedInOptions, options));
            }
        }

        private static object? GetProxies(ModelReaderWriterOptions passedInOptions)
        {
            return passedInOptions.GetType().GetField("_proxies", BindingFlags.NonPublic | BindingFlags.Instance)!.GetValue(passedInOptions);
        }

        private class JsonModelProxy : IJsonModel<JsonModel>
        {
            JsonModel IJsonModel<JsonModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);
                using var doc = JsonDocument.ParseValue(ref reader);
                return new JsonModel();
            }

            JsonModel IPersistableModel<JsonModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);
                return new JsonModel();
            }

            string IPersistableModel<JsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
            {
                return "J";
            }

            void IJsonModel<JsonModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<JsonModel>.Write(ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);
                return BinaryData.FromString("{}");
            }
        }

        [Test]
        public void AddProxy_MultipleProxiesForSameType_FormChain()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy1);
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy2);

            var model = new JsonModel();
            var resolved = options.ResolveProxy<JsonModel>((IPersistableModel<JsonModel>)model);
            Assert.AreSame(proxy1, resolved);
        }

        [Test]
        public void ResolveProxy_ReturnsFirstRegistered()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy1);
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy2);

            var model = new JsonModel();
            var resolved = options.ResolveProxy<JsonModel>((IPersistableModel<JsonModel>)model);
            Assert.AreSame(proxy1, resolved);
            Assert.AreSame(model, options.ProxiedModel);
        }

        [Test]
        public void ResolveProxy_IJsonModel_ReturnsFirstRegistered()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy1);
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy2);

            var model = new JsonModel();
            var resolved = options.ResolveProxy<JsonModel>((IJsonModel<JsonModel>)model);
            Assert.AreSame(proxy1, resolved);
            Assert.AreSame(model, options.ProxiedModel);
        }

        [Test]
        public void ResolveProxy_NoProxies_ReturnsSelf()
        {
            var options = new ModelReaderWriterOptions("J");
            var model = new JsonModel();

            var resolved = options.ResolveProxy<JsonModel>((IPersistableModel<JsonModel>)model);
            Assert.AreSame(model, resolved);
        }

        [Test]
        public void AddProxy_SingleProxy_BehavesLikeBefore()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new JsonModelProxy();

            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy);

            var model = new JsonModel();
            var resolvedFromModel = options.ResolveProxy<JsonModel>((IPersistableModel<JsonModel>)model);
            Assert.AreSame(proxy, resolvedFromModel);
        }

        [Test]
        public void HasProxy_NoProxies_ReturnsFalse()
        {
            var options = new ModelReaderWriterOptions("J");

            Assert.IsFalse(options.TryGetProxy<JsonModel>(ReadOnlyMemory<byte>.Empty, out IPersistableModel<JsonModel>? proxy));
            Assert.IsNull(proxy);
        }

        [Test]
        public void AddProxy_ChainSharedBetweenCopiedOptions()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy1);
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy2);

            var copied = new ModelReaderWriterOptions(options);
            Assert.IsTrue(copied.HasProxies);
            Assert.AreSame(GetProxies(options), GetProxies(copied));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Write_WithMultipleProxies_UsesFirstRegistered(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy1);
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy2);

            _optionsMap.Add(proxy1, options);
            ModelReaderWriter.Write(new JsonModel(), options);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Read_WithMultipleProxies_UsesFirstRegistered(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy1);
            options.AddProxy<JsonModel>((IJsonModel<JsonModel>)proxy2);

            _optionsMap.Add(proxy1, options);
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty, options);
        }

        private class JsonModel : IJsonModel<JsonModel>
        {
            JsonModel IJsonModel<JsonModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);
                return new JsonModel();
            }

            JsonModel IPersistableModel<JsonModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);
                return new JsonModel();
            }

            string IPersistableModel<JsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
            {
                return "J";
            }

            void IJsonModel<JsonModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);

                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<JsonModel>.Write(ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);

                var format = options.Format == "W" ? ((IPersistableModel<JsonModel>)this).GetFormatFromOptions(options) : options.Format;

                switch (format)
                {
                    case "J":
                        return ModelReaderWriter.Write(this, options);
                    default:
                        throw new FormatException($"The model {nameof(JsonModel)} does not support writing '{options.Format}' format.");
                }
            }
        }

        #region Chain of responsibility read tests

        [Test]
        public void ReadWithChain_SingleProxy_ReturnsProxyResult()
        {
            var options = new ModelReaderWriterOptions("J");
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
            var options = new ModelReaderWriterOptions("J");
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
            var options = new ModelReaderWriterOptions("J");
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
            var options = new ModelReaderWriterOptions("J");
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
            var options = new ModelReaderWriterOptions("J");
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

        [Test]
        public void ResolveProxy_Write_UsesCanHandle()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: false);
            var proxy2 = new ChainProxy(handleRead: false);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            // Write uses CanHandle — both have CanHandle(SimpleModel) => true,
            // so the first registered (proxy1) is used since it's checked first (FIFO).
            var model = new SimpleModel();
            var resolved = options.ResolveProxy<SimpleModel>((IPersistableModel<SimpleModel>)model);
            Assert.AreSame(proxy1.Model, resolved);
        }

        /// <summary>
        /// Simple model without AssertOptions logic, used for chain tests.
        /// </summary>
        private class SimpleModel : IJsonModel<SimpleModel>
        {
            SimpleModel IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using var doc = JsonDocument.ParseValue(ref reader);
                return new SimpleModel();
            }

            SimpleModel IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options)
                => new SimpleModel();

            string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            void IJsonModel<SimpleModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options)
                => ModelReaderWriter.Write(this, options);
        }

        private class TrackingModel : IJsonModel<SimpleModel>
        {
            public bool CreateWasCalled { get; private set; }
            public bool WriteWasCalled { get; private set; }
            public object? CapturedProxiedModelOnBinaryCreate { get; private set; }
            public object? CapturedProxiedModelOnReaderCreate { get; private set; }
            public object? CapturedProxiedModelOnWrite { get; private set; }

            public void Reset()
            {
                CreateWasCalled = false;
                WriteWasCalled = false;
                CapturedProxiedModelOnBinaryCreate = null;
                CapturedProxiedModelOnReaderCreate = null;
                CapturedProxiedModelOnWrite = null;
            }

            SimpleModel IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                CreateWasCalled = true;
                CapturedProxiedModelOnBinaryCreate = options.ProxiedModel;
                return new SimpleModel();
            }

            SimpleModel IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                CreateWasCalled = true;
                CapturedProxiedModelOnReaderCreate = options.ProxiedModel;
                using var doc = JsonDocument.ParseValue(ref reader);
                return new SimpleModel();
            }

            void IJsonModel<SimpleModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                WriteWasCalled = true;
                CapturedProxiedModelOnWrite = options.ProxiedModel;
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options)
            {
                WriteWasCalled = true;
                CapturedProxiedModelOnWrite = options.ProxiedModel;
                return BinaryData.FromString("{}");
            }

            string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        /// <summary>
        /// A proxy that can be configured to handle or decline reads.
        /// </summary>
        private class ChainProxy : ConditionalModelProxy<SimpleModel>
        {
            private readonly bool _handleRead;
            public bool CreateWasCalled => ((TrackingModel)Model).CreateWasCalled;
            public bool WriteWasCalled => ((TrackingModel)Model).WriteWasCalled;
            public object? CapturedProxiedModelOnCreate => ((TrackingModel)Model).CapturedProxiedModelOnBinaryCreate ?? ((TrackingModel)Model).CapturedProxiedModelOnReaderCreate;

            public ChainProxy(bool handleRead)
                : base(new TrackingModel())
            {
                _handleRead = handleRead;
            }

            public override bool CanHandle(SimpleModel model) => true;

            public override bool CanHandle(ReadOnlyMemory<byte> data) => _handleRead;

            public override bool CanHandle(ref Utf8JsonReader reader) => _handleRead;

            public void Reset() => ((TrackingModel)Model).Reset();
        }

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

            public override bool CanHandle(ReadOnlyMemory<byte> data)
            {
                return BinaryData.FromBytes(data).ToString().Contains($"\"type\":\"{_discriminatorValue}\"");
            }

            public override bool CanHandle(ref Utf8JsonReader reader)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return document.RootElement.TryGetProperty("type", out var type) && type.GetString() == _discriminatorValue;
            }

            public void Reset() => ((TrackingModel)Model).Reset();
        }

        /// <summary>
        /// A proxy that captures ProxiedModel at every interaction point (Write, Create(BinaryData), Create(ref reader)).
        /// Used to verify the ProxiedModel contract.
        /// </summary>
        private class ProxiedModelCapturingProxy : IJsonModel<SimpleModel>
        {
            public object? CapturedOnWrite { get; private set; }
            public object? CapturedOnCreateBinaryData { get; private set; }
            public object? CapturedOnCreateReader { get; private set; }
            public List<object?> AllCapturedOnCreateReader { get; } = new();

            public void Reset()
            {
                CapturedOnWrite = null;
                CapturedOnCreateBinaryData = null;
                CapturedOnCreateReader = null;
                AllCapturedOnCreateReader.Clear();
            }

            void IJsonModel<SimpleModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                CapturedOnWrite = options.ProxiedModel;
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            SimpleModel IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                CapturedOnCreateBinaryData = options.ProxiedModel;
                return new SimpleModel();
            }

            SimpleModel IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                CapturedOnCreateReader = options.ProxiedModel;
                AllCapturedOnCreateReader.Add(options.ProxiedModel);
                using var doc = JsonDocument.ParseValue(ref reader);
                return new SimpleModel();
            }

            BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options)
            {
                CapturedOnWrite = options.ProxiedModel;
                return BinaryData.FromString("{}");
            }

            string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        #region ProxiedModel Contract Tests

        [Test]
        public void ProxiedModel_IsSetToOriginalModel_DuringProxyWrite()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ProxiedModelCapturingProxy();
            options.AddProxy<SimpleModel>((IJsonModel<SimpleModel>)proxy);

            var model = new SimpleModel();
            ModelReaderWriter.Write(model, options);

            Assert.AreSame(model, proxy.CapturedOnWrite,
                "ProxiedModel must be set to the original model when proxy.Write is called, " +
                "so the proxy can read the model's state during serialization.");
        }

        [Test]
        public void ProxiedModel_IsSetToOriginalModel_DuringProxyCreateBinaryData()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ProxiedModelCapturingProxy();
            options.AddProxy<SimpleModel>((IJsonModel<SimpleModel>)proxy);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);

            Assert.AreSame(model, proxy.CapturedOnCreateBinaryData,
                "ProxiedModel must be set to the original model when proxy.Create(BinaryData) is called, " +
                "so the proxy knows which model instance it is acting on behalf of.");
        }

        [Test]
        public void ProxiedModel_IsSetToOriginalModel_DuringProxyCreateReader()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ProxiedModelCapturingProxy();
            options.AddProxy<SimpleModel>((IJsonModel<SimpleModel>)proxy);

            var model = new SimpleModel();
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes("{}");
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read();
            options.ReadWithChain<SimpleModel>((IJsonModel<SimpleModel>)model, ref reader);

            Assert.AreSame(model, proxy.CapturedOnCreateReader,
                "ProxiedModel must be set to the original model when proxy.Create(ref reader) is called " +
                "via the reader-based ReadWithChain path.");
        }

        [Test]
        public void ProxiedModel_IsNull_WhenNoProxyExists_Write()
        {
            var options = new ModelReaderWriterOptions("J");
            var model = new SimpleModel();

            var resolved = options.ResolveProxy<SimpleModel>((IPersistableModel<SimpleModel>)model);

            Assert.AreSame(model, resolved,
                "ResolveProxy must return the model itself when no proxy is registered.");
            Assert.IsNull(options.ProxiedModel,
                "ProxiedModel must remain null when no proxy is registered, " +
                "because there is no proxy that needs to access the original model.");
        }

        [Test]
        public void ProxiedModel_IsStillSetAfterSuccessfulProxyRead()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ProxiedModelCapturingProxy();
            options.AddProxy<SimpleModel>((IJsonModel<SimpleModel>)proxy);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);

            Assert.AreSame(model, options.ProxiedModel,
                "ProxiedModel must remain set to the original model after a proxy successfully handles a read, " +
                "because downstream code may still need to reference the original model.");
        }

        [Test]
        public void ProxiedModel_IsNull_WhenAllProxiesDecline_AndModelHandlesRead()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: false);
            var proxy2 = new ChainProxy(handleRead: false);
            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);

            Assert.IsNull(options.ProxiedModel,
                "ProxiedModel must be cleared (set to null) when all proxies decline and the model handles " +
                "the read itself, because the model is not acting as a proxy — it is the original.");
        }

        [Test]
        public void ProxiedModel_IsCorrectForEachProxy_InChain()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: true);
            var proxy2 = new ChainProxy(handleRead: false);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);

            Assert.IsNull(proxy2.CapturedProxiedModelOnCreate,
                "proxy2 was never reached because proxy1 handled — CapturedProxiedModelOnCreate must be null.");
            Assert.AreSame(model, proxy1.CapturedProxiedModelOnCreate,
                "ProxiedModel must be set to the original model when the proxy that handles the read " +
                "is called. ProxiedModel must not leak state between chain attempts.");
        }

        [Test]
        public void ProxiedModel_IsCorrectForEachProxy_InChain_ReaderPath()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: true);
            var proxy2 = new ChainProxy(handleRead: false);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes("{}");
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read();
            options.ReadWithChain<SimpleModel>((IJsonModel<SimpleModel>)model, ref reader);

            Assert.IsNull(proxy2.CapturedProxiedModelOnCreate,
                "proxy2 was never reached because proxy1 handled — CapturedProxiedModelOnCreate must be null.");
            Assert.AreSame(model, proxy1.CapturedProxiedModelOnCreate,
                "ProxiedModel must be set to the original model when the proxy that handles the read " +
                "in the reader-based chain is called.");
        }

        [Test]
        public void ProxiedModel_IsSetPerElement_InCollection()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ProxiedModelCapturingProxy();
            options.AddProxy<SimpleModel>((IJsonModel<SimpleModel>)proxy);

            var json = "[{},{},{}]";
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes(json);
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read();

            int elementCount = 0;
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.StartObject)
                {
                    var model = new SimpleModel();
                    options.ReadWithChain<SimpleModel>((IJsonModel<SimpleModel>)model, ref reader);
                    elementCount++;

                    Assert.IsNotNull(proxy.CapturedOnCreateReader,
                        $"ProxiedModel must be set when reading element {elementCount} of a collection. " +
                        "Each element must independently set ProxiedModel for the proxy.");
                }
                else if (reader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }
            }

            Assert.AreEqual(3, elementCount,
                "Expected 3 elements to be read from the collection.");
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

        #region ResolveProxy write path with CanHandle declining

        [Test]
        public void ResolveProxy_Write_FirstDeclinesSecondHandles()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new SelectiveWriteProxy(canWrite: false);
            var proxy2 = new SelectiveWriteProxy(canWrite: true);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var resolved = options.ResolveProxy<SimpleModel>((IPersistableModel<SimpleModel>)model);

            Assert.AreSame(proxy2.Model, resolved,
                "ResolveProxy should skip proxy1 (CanHandle=false) and return proxy2's model.");
        }

        [Test]
        public void ResolveProxy_Write_AllDecline_ReturnsSelf()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new SelectiveWriteProxy(canWrite: false);
            var proxy2 = new SelectiveWriteProxy(canWrite: false);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var resolved = options.ResolveProxy<SimpleModel>((IPersistableModel<SimpleModel>)model);

            Assert.AreSame(model, resolved,
                "ResolveProxy should return the model itself when all proxies decline.");
        }

        [Test]
        public void ResolveProxy_IJsonModel_FirstDeclinesSecondHandles()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new SelectiveWriteProxy(canWrite: false);
            var proxy2 = new SelectiveWriteProxy(canWrite: true);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var resolved = options.ResolveProxy<SimpleModel>((IJsonModel<SimpleModel>)model);

            Assert.AreSame((IJsonModel<SimpleModel>)proxy2.Model, resolved,
                "IJsonModel ResolveProxy should skip proxy1 (CanHandle=false) and return proxy2's model.");
        }

        #endregion

        #region Non-generic ReadWithChain (Type overload)

        [Test]
        public void ReadWithChain_NonGeneric_SecondProxyHandles()
        {
            var options = new ModelReaderWriterOptions("J");
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
            var options = new ModelReaderWriterOptions("J");
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

        #region WS3 Medium-severity regression tests

        [Test]
        public void AddProxy_NullProxy_ThrowsArgumentNullException()
        {
            var options = new ModelReaderWriterOptions("J");
            Assert.Throws<ArgumentNullException>(() => options.AddProxy<SimpleModel>((IPersistableModel<SimpleModel>)null!));
            Assert.Throws<ArgumentNullException>(() => options.AddProxy<SimpleModel>((IJsonModel<SimpleModel>)null!));
            Assert.Throws<ArgumentNullException>(() => options.AddProxy<SimpleModel>((ConditionalModelProxy<SimpleModel>)null!));
        }

        [Test]
        public void ResolveProxy_NullModel_ThrowsArgumentNullException()
        {
            var options = new ModelReaderWriterOptions("J");
            Assert.Throws<ArgumentNullException>(() => options.ResolveProxy<SimpleModel>((IPersistableModel<SimpleModel>)null!));
            Assert.Throws<ArgumentNullException>(() => options.ResolveProxy<SimpleModel>((IJsonModel<SimpleModel>)null!));
        }

        [Test]
        public void AddProxy_OnDefaultJsonOptions_ThrowsInvalidOperationException()
        {
            var proxy = new ChainProxy(handleRead: true);
            Assert.Throws<InvalidOperationException>(() => ModelReaderWriterOptions.Json.AddProxy<SimpleModel>(proxy));
        }

        [Test]
        public void AddProxy_OnDefaultXmlOptions_ThrowsInvalidOperationException()
        {
            var proxy = new ChainProxy(handleRead: true);
            Assert.Throws<InvalidOperationException>(() => ModelReaderWriterOptions.Xml.AddProxy<SimpleModel>(proxy));
        }

        [Test]
        public void ResolveProxy_NonGeneric_SkipsConditionalProxyWithoutJsonModel()
        {
            var options = new ModelReaderWriterOptions("J");
            // First proxy handles (CanHandle=true) but its model is persistable-only (not IJsonModel),
            // so the JSON write path must skip it instead of throwing.
            var persistableOnly = new PersistableOnlyConditionalProxy();
            var jsonProxy = new ChainProxy(handleRead: true);
            options.AddProxy<SimpleModel>(persistableOnly);
            options.AddProxy<SimpleModel>(jsonProxy);

            var model = new SimpleModel();
            var resolved = options.ResolveProxy((IJsonModel<object>)(object)model);

            Assert.AreSame(jsonProxy.Model, resolved,
                "Non-generic ResolveProxy should skip the persistable-only conditional proxy and return the JSON proxy's model.");
        }

        /// <summary>
        /// A model implementation that only supports the persistable (non-JSON) path.
        /// </summary>
        private class PersistableOnlyModel : IPersistableModel<SimpleModel>
        {
            SimpleModel IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new SimpleModel();
            string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
            BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");
        }

        /// <summary>
        /// A conditional proxy whose held model does not implement IJsonModel.
        /// </summary>
        private class PersistableOnlyConditionalProxy : ConditionalModelProxy<SimpleModel>
        {
            public PersistableOnlyConditionalProxy() : base(new PersistableOnlyModel()) { }

            public override bool CanHandle(SimpleModel model) => true;
        }

        #endregion

        /// <summary>
        /// A proxy that can be configured to accept or decline write via CanHandle(model).
        /// Used to test the write-path chain-of-responsibility where first proxy declines.
        /// </summary>
        private class SelectiveWriteProxy : ConditionalModelProxy<SimpleModel>
        {
            private readonly bool _canWrite;
            public bool WriteWasCalled => ((TrackingModel)Model).WriteWasCalled;

            public SelectiveWriteProxy(bool canWrite)
                : base(new TrackingModel())
            {
                _canWrite = canWrite;
            }

            public override bool CanHandle(SimpleModel model) => _canWrite;
        }

        #endregion
    }
}

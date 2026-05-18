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
            options.AddProxy(proxy);
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
            options.AddProxy(proxy);
            var model = new JsonModel();
            _optionsMap.Add(proxy, options);
            ModelReaderWriter.Write(proxy, options);
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
            options.AddProxy(proxy);
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
            options.AddProxy(proxy);
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
                Assert.AreEqual(passedInProxies!.Count, optionProxies!.Count);
                foreach (var key in passedInProxies.Keys)
                {
                    Assert.IsTrue(optionProxies.ContainsKey(key));
                    Assert.AreEqual(passedInProxies[key], optionProxies[key]);
                }
            }
            else
            {
                Assert.IsTrue(ReferenceEquals(passedInOptions, options));
            }
        }

        private static Dictionary<Type, object>? GetProxies(ModelReaderWriterOptions passedInOptions)
        {
            return passedInOptions.GetType().GetField("_proxies", BindingFlags.NonPublic | BindingFlags.Instance)!.GetValue(passedInOptions) as Dictionary<Type, object>;
        }

        private class JsonModelProxy : IJsonModel<JsonModel>
        {
            JsonModel IJsonModel<JsonModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);
                return new JsonModel();
            }

            public JsonModel Create(BinaryData data, ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);
                return new JsonModel();
            }

            public string GetFormatFromOptions(ModelReaderWriterOptions options)
            {
                return "J";
            }

            void IJsonModel<JsonModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);

                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            public BinaryData Write(ModelReaderWriterOptions options)
            {
                AssertOptions(this, options);

                var format = options.Format == "W" ? GetFormatFromOptions(options) : options.Format;

                switch (format)
                {
                    case "J":
                        return ModelReaderWriter.Write(this, options);
                    default:
                        throw new FormatException($"The model {nameof(JsonModel)} does not support writing '{options.Format}' format.");
                }
            }
        }

        [Test]
        public void AddProxy_MultipleCallsForSameType_LastWins()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>(proxy1);
            options.AddProxy<JsonModel>(proxy2);

            // Last AddProxy wins (single slot, replacement semantics)
            var model = new JsonModel();
            var resolved = options.ResolveProxy<JsonModel>((IPersistableModel<JsonModel>)model);
            Assert.AreSame(proxy2, resolved);
        }

        [Test]
        public void ResolveProxy_ReturnsLastRegistered()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>(proxy1);
            options.AddProxy<JsonModel>(proxy2);

            var model = new JsonModel();
            var resolved = options.ResolveProxy<JsonModel>((IPersistableModel<JsonModel>)model);
            Assert.AreSame(proxy2, resolved);
            Assert.AreSame(model, options.ProxiedModel);
        }

        [Test]
        public void ResolveProxy_IJsonModel_ReturnsLastRegistered()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>(proxy1);
            options.AddProxy<JsonModel>(proxy2);

            var model = new JsonModel();
            var resolved = options.ResolveProxy<JsonModel>((IJsonModel<JsonModel>)model);
            Assert.AreSame(proxy2, resolved);
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

            options.AddProxy<JsonModel>(proxy);

            var model = new JsonModel();
            var resolvedFromModel = options.ResolveProxy<JsonModel>((IPersistableModel<JsonModel>)model);
            Assert.AreSame(proxy, resolvedFromModel);
        }

        [Test]
        public void AddProxy_ChainSharedBetweenCopiedOptions()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>(proxy1);
            options.AddProxy<JsonModel>(proxy2);

            // Internal copy shares the same proxy chain
            var copied = new ModelReaderWriterOptions(options);
            Assert.IsTrue(copied.HasProxies);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Write_WithProxy_UsesRegisteredProxy(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy = new JsonModelProxy();

            options.AddProxy<JsonModel>(proxy);

            _optionsMap.Add(proxy, options);
            ModelReaderWriter.Write(proxy, options);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Read_WithProxy_UsesRegisteredProxy(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy = new JsonModelProxy();

            options.AddProxy<JsonModel>(proxy);

            _optionsMap.Add(proxy, options);
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
            var proxy = new ChainRouter(handleRead: true);
            options.AddDiscriminatorRouter<SimpleModel>(proxy);

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
            var proxy = new ChainRouter(handleRead: false); // CanHandle returns false = decline
            options.AddDiscriminatorRouter<SimpleModel>(proxy);

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
            var proxy1 = new ChainRouter(handleRead: false);  // will decline (tried first, FIFO)
            var proxy2 = new ChainRouter(handleRead: true);   // will handle

            options.AddDiscriminatorRouter<SimpleModel>(proxy1);
            options.AddDiscriminatorRouter<SimpleModel>(proxy2);

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
            var proxy1 = new ChainRouter(handleRead: false);
            var proxy2 = new ChainRouter(handleRead: false);

            options.AddDiscriminatorRouter<SimpleModel>(proxy1);
            options.AddDiscriminatorRouter<SimpleModel>(proxy2);

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
            var discriminatorProxy = new TestDiscriminatorRouter("special");
            // Default proxy handles everything — registered second (fallback)
            var defaultProxy = new ChainRouter(handleRead: true);

            options.AddDiscriminatorRouter<SimpleModel>(discriminatorProxy);
            options.AddDiscriminatorRouter<SimpleModel>(defaultProxy);

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

        /// <summary>
        /// A tracking IJsonModel that records when Create/Write are called.
        /// Used as the model held by test routers.
        /// </summary>
        private class TrackingJsonModel : IJsonModel<SimpleModel>
        {
            public bool CreateWasCalled { get; private set; }
            public bool WriteWasCalled { get; private set; }
            public object? CapturedProxiedModelOnCreate { get; private set; }
            public object? CapturedOnWrite { get; private set; }
            public List<object?> AllCapturedOnCreate { get; } = new();

            public void Reset()
            {
                CreateWasCalled = false;
                WriteWasCalled = false;
                CapturedProxiedModelOnCreate = null;
                CapturedOnWrite = null;
                AllCapturedOnCreate.Clear();
            }

            SimpleModel IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                CreateWasCalled = true;
                CapturedProxiedModelOnCreate = options.ProxiedModel;
                AllCapturedOnCreate.Add(options.ProxiedModel);
                using var doc = JsonDocument.ParseValue(ref reader);
                return new SimpleModel();
            }

            void IJsonModel<SimpleModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                WriteWasCalled = true;
                CapturedOnWrite = options.ProxiedModel;
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            SimpleModel IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                CreateWasCalled = true;
                CapturedProxiedModelOnCreate = options.ProxiedModel;
                AllCapturedOnCreate.Add(options.ProxiedModel);
                return new SimpleModel();
            }

            BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options)
            {
                WriteWasCalled = true;
                CapturedOnWrite = options.ProxiedModel;
                return BinaryData.FromString("{}");
            }

            string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        /// <summary>
        /// A discriminator router that can be configured to handle or decline reads.
        /// The _handleRead flag controls CanHandle — returning false means "I can't handle this."
        /// </summary>
        private class ChainRouter : DiscriminatorRouter
        {
            private readonly bool _handleRead;
            public TrackingJsonModel HeldModel { get; }

            public ChainRouter(bool handleRead) : this(handleRead, new TrackingJsonModel())
            {
            }

            public ChainRouter(bool handleRead, TrackingJsonModel model)
            {
                _handleRead = handleRead;
                HeldModel = model;
            }

            public bool CreateWasCalled => HeldModel.CreateWasCalled;
            public object? CapturedProxiedModelOnCreate => HeldModel.CapturedProxiedModelOnCreate;

            public override bool CanHandle(BinaryData data) => _handleRead;
            public override bool CanHandle(ref Utf8JsonReader reader) => _handleRead;

            public override object? Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                => ((IJsonModel<SimpleModel>)HeldModel).Create(ref reader, options);

            public override object? Create(BinaryData data, ModelReaderWriterOptions options)
                => ((IPersistableModel<SimpleModel>)HeldModel).Create(data, options);

            public void Reset() => HeldModel.Reset();
        }

        /// <summary>
        /// A discriminator router that peeks at the data to check for a discriminator value.
        /// Returns false from CanHandle if the discriminator doesn't match.
        /// </summary>
        private class TestDiscriminatorRouter : DiscriminatorRouter
        {
            private readonly string _discriminatorValue;
            public TrackingJsonModel HeldModel { get; }

            public TestDiscriminatorRouter(string discriminatorValue) : this(discriminatorValue, new TrackingJsonModel())
            {
            }

            public TestDiscriminatorRouter(string discriminatorValue, TrackingJsonModel model)
            {
                _discriminatorValue = discriminatorValue;
                HeldModel = model;
            }

            public bool CreateWasCalled => HeldModel.CreateWasCalled;

            public override bool CanHandle(BinaryData data)
            {
                return data.ToString().Contains($"\"type\":\"{_discriminatorValue}\"");
            }

            public override bool CanHandle(ref Utf8JsonReader reader)
            {
                var copy = reader;
                using var doc = JsonDocument.ParseValue(ref copy);
                return doc.RootElement.TryGetProperty("type", out var typeProp)
                    && typeProp.GetString() == _discriminatorValue;
            }

            public override object? Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                => ((IJsonModel<SimpleModel>)HeldModel).Create(ref reader, options);

            public override object? Create(BinaryData data, ModelReaderWriterOptions options)
                => ((IPersistableModel<SimpleModel>)HeldModel).Create(data, options);

            public void Reset() => HeldModel.Reset();
        }

        /// <summary>
        /// A router that captures ProxiedModel at every interaction point.
        /// Used to verify the ProxiedModel contract. Works as both write proxy and discriminator router.
        /// </summary>
        private class ProxiedModelCapturingRouter : DiscriminatorRouter
        {
            public TrackingJsonModel HeldModel { get; }
            public object? CapturedOnWrite => HeldModel.CapturedOnWrite;
            public object? CapturedOnCreateBinaryData => HeldModel.CapturedProxiedModelOnCreate;
            public object? CapturedOnCreateReader => HeldModel.CapturedProxiedModelOnCreate;
            public List<object?> AllCapturedOnCreateReader => HeldModel.AllCapturedOnCreate;

            public ProxiedModelCapturingRouter() : this(new TrackingJsonModel())
            {
            }

            public ProxiedModelCapturingRouter(TrackingJsonModel model)
            {
                HeldModel = model;
            }

            public override bool CanHandle(BinaryData data) => true;
            public override bool CanHandle(ref Utf8JsonReader reader) => true;

            public override object? Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                => ((IJsonModel<SimpleModel>)HeldModel).Create(ref reader, options);

            public override object? Create(BinaryData data, ModelReaderWriterOptions options)
                => ((IPersistableModel<SimpleModel>)HeldModel).Create(data, options);

            public void Reset() => HeldModel.Reset();
        }

        #region ProxiedModel Contract Tests

        [Test]
        public void ProxiedModel_IsSetToOriginalModel_DuringProxyWrite()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ProxiedModelCapturingRouter();
            options.AddProxy<SimpleModel>(proxy.HeldModel);

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
            var proxy = new ProxiedModelCapturingRouter();
            options.AddDiscriminatorRouter<SimpleModel>(proxy);

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
            var proxy = new ProxiedModelCapturingRouter();
            options.AddDiscriminatorRouter<SimpleModel>(proxy);

            var model = new SimpleModel();
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes("{}");
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read(); // advance to StartObject
            options.ReadWithChain<SimpleModel>((IJsonModel<SimpleModel>)model, ref reader);

            // ReadWithChain for reader path now reads into BinaryData and calls Create(BinaryData, options)
            Assert.AreSame(model, proxy.CapturedOnCreateBinaryData,
                "ProxiedModel must be set to the original model when proxy.Create(BinaryData) is called " +
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
            var proxy = new ProxiedModelCapturingRouter();
            options.AddDiscriminatorRouter<SimpleModel>(proxy);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);

            // After a proxy handles the read, ProxiedModel should still reference the model
            // since the proxy may need post-processing access.
            Assert.AreSame(model, options.ProxiedModel,
                "ProxiedModel must remain set to the original model after a proxy successfully handles a read, " +
                "because downstream code may still need to reference the original model.");
        }

        [Test]
        public void ProxiedModel_IsNull_WhenAllProxiesDecline_AndModelHandlesRead()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainRouter(handleRead: false);
            var proxy2 = new ChainRouter(handleRead: false);
            options.AddDiscriminatorRouter<SimpleModel>(proxy1);
            options.AddDiscriminatorRouter<SimpleModel>(proxy2);

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
            var proxy1 = new ChainRouter(handleRead: true);   // will handle (tried first, FIFO)
            var proxy2 = new ChainRouter(handleRead: false);  // never reached

            options.AddDiscriminatorRouter<SimpleModel>(proxy1);
            options.AddDiscriminatorRouter<SimpleModel>(proxy2);

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
            var proxy1 = new ChainRouter(handleRead: true);   // will handle (tried first, FIFO)
            var proxy2 = new ChainRouter(handleRead: false);  // never reached

            options.AddDiscriminatorRouter<SimpleModel>(proxy1);
            options.AddDiscriminatorRouter<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes("{}");
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read(); // advance to StartObject
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
            var proxy = new ProxiedModelCapturingRouter();
            options.AddDiscriminatorRouter<SimpleModel>(proxy);

            // Read a JSON array with 3 elements — each element should set ProxiedModel
            var json = "[{},{},{}]";
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes(json);
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read(); // advance to StartArray

            // Simulate what JsonCollectionReader does per element:
            // For each StartObject, call ReadWithChain with reader-based chain.
            // ReadWithChain now reads element into BinaryData and calls Create(BinaryData, options).
            int elementCount = 0;
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.StartObject)
                {
                    var model = new SimpleModel();
                    options.ReadWithChain<SimpleModel>((IJsonModel<SimpleModel>)model, ref reader);
                    elementCount++;

                    Assert.IsNotNull(proxy.CapturedOnCreateBinaryData,
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
            var proxy1 = new ChainRouter(handleRead: false);  // declines via CanHandle
            var proxy2 = new ChainRouter(handleRead: true);   // handles

            mrwOptions.AddDiscriminatorRouter<SimpleModel>(proxy1);
            mrwOptions.AddDiscriminatorRouter<SimpleModel>(proxy2);

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
            var proxy1 = new ChainRouter(handleRead: false);
            var proxy2 = new ChainRouter(handleRead: false);

            mrwOptions.AddDiscriminatorRouter<SimpleModel>(proxy1);
            mrwOptions.AddDiscriminatorRouter<SimpleModel>(proxy2);

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
            var discriminatorProxy = new TestDiscriminatorRouter("special");
            var defaultProxy = new ChainRouter(handleRead: true);

            mrwOptions.AddDiscriminatorRouter<SimpleModel>(discriminatorProxy);
            mrwOptions.AddDiscriminatorRouter<SimpleModel>(defaultProxy);

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
        public void JsonModelConverter_Write_UsesLastRegisteredProxy()
        {
            var mrwOptions = new ModelReaderWriterOptions("J");
            var proxy1 = new SelectiveWriteProxy(canWrite: true);
            var proxy2 = new SelectiveWriteProxy(canWrite: true);

            mrwOptions.AddProxy<SimpleModel>(proxy1);
            mrwOptions.AddProxy<SimpleModel>(proxy2);

            var stjOptions = new JsonSerializerOptions();
            stjOptions.Converters.Add(new JsonModelConverter(mrwOptions));

            var model = new SimpleModel();
            string json = JsonSerializer.Serialize<IJsonModel<object>>((IJsonModel<object>)(object)model, stjOptions);

            Assert.IsFalse(proxy1.WriteWasCalled,
                "proxy1 should not have been called since proxy2 replaced it.");
            Assert.IsTrue(proxy2.WriteWasCalled,
                "proxy2 should have handled the write as the last registered proxy.");
        }

        #endregion

        #region ResolveProxy write path — last registered wins

        [Test]
        public void ResolveProxy_Write_LastRegisteredWins()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new SelectiveWriteProxy(canWrite: true);
            var proxy2 = new SelectiveWriteProxy(canWrite: true);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var resolved = options.ResolveProxy<SimpleModel>((IPersistableModel<SimpleModel>)model);

            Assert.AreSame(proxy2, resolved,
                "ResolveProxy should return the last registered proxy.");
        }

        [Test]
        public void ResolveProxy_Write_NoProxy_ReturnsSelf()
        {
            var options = new ModelReaderWriterOptions("J");

            var model = new SimpleModel();
            var resolved = options.ResolveProxy<SimpleModel>((IPersistableModel<SimpleModel>)model);

            Assert.AreSame(model, resolved,
                "ResolveProxy should return the model itself when no proxies are registered.");
        }

        [Test]
        public void ResolveProxy_IJsonModel_LastRegisteredWins()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new SelectiveWriteProxy(canWrite: true);
            var proxy2 = new SelectiveWriteProxy(canWrite: true);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var resolved = options.ResolveProxy<SimpleModel>((IJsonModel<SimpleModel>)model);

            Assert.AreSame(proxy2, resolved,
                "IJsonModel ResolveProxy should return the last registered proxy.");
        }

        #endregion

        #region Non-generic ReadWithChain (Type overload)

        [Test]
        public void ReadWithChain_NonGeneric_SecondProxyHandles()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainRouter(handleRead: false);
            var proxy2 = new ChainRouter(handleRead: true);

            options.AddDiscriminatorRouter<SimpleModel>(proxy1);
            options.AddDiscriminatorRouter<SimpleModel>(proxy2);

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
            var proxy1 = new ChainRouter(handleRead: false);
            var proxy2 = new ChainRouter(handleRead: false);

            options.AddDiscriminatorRouter<SimpleModel>(proxy1);
            options.AddDiscriminatorRouter<SimpleModel>(proxy2);

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
            var discriminatorProxy = new TestDiscriminatorRouter("special");
            var defaultProxy = new ChainRouter(handleRead: true);

            options.AddDiscriminatorRouter<SimpleModel>(discriminatorProxy);
            options.AddDiscriminatorRouter<SimpleModel>(defaultProxy);

            // Read a list where elements differ — the chain should route per-element
            var json = "[{\"type\":\"special\"},{\"type\":\"other\"},{\"type\":\"special\"}]";
            var result = ModelReaderWriter.Read<List<SimpleModel>>(BinaryData.FromString(json), options);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result!.Count);
        }

        #endregion

        /// <summary>
        /// A proxy that can be configured to accept or decline write via CanHandle(model).
        /// Used to test the write-path chain-of-responsibility where first proxy declines.
        /// </summary>
        private class SelectiveWriteProxy : IJsonModel<SimpleModel>
        {
            public bool WriteWasCalled { get; private set; }

            public SelectiveWriteProxy(bool canWrite)
            {
                // canWrite is no longer used — write path picks the first registered proxy
            }

            void IJsonModel<SimpleModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                WriteWasCalled = true;
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            SimpleModel IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using var doc = JsonDocument.ParseValue(ref reader);
                return new SimpleModel();
            }

            public SimpleModel Create(BinaryData data, ModelReaderWriterOptions options)
                => new SimpleModel();

            public BinaryData Write(ModelReaderWriterOptions options)
            {
                WriteWasCalled = true;
                return BinaryData.FromString("{}");
            }

            public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        #endregion
    }
}

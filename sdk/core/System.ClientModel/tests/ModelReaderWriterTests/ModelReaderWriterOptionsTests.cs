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

        private static Dictionary<Type, List<object>>? GetProxies(ModelReaderWriterOptions passedInOptions)
        {
            return passedInOptions.GetType().GetField("_proxies", BindingFlags.NonPublic | BindingFlags.Instance)!.GetValue(passedInOptions) as Dictionary<Type, List<object>>;
        }

        private class JsonModelProxy : IJsonModel<JsonModel>
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

        [Test]
        public void AddProxy_MultipleProxiesForSameType_FormChain()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>(proxy1);
            options.AddProxy<JsonModel>(proxy2);

            // Last registered should be returned (highest priority)
            Assert.IsTrue(options.TryGetProxy<JsonModel>(out IPersistableModel<JsonModel>? resolved));
            Assert.AreSame(proxy2, resolved);

            Assert.IsTrue(options.TryGetProxy<JsonModel>(out IJsonModel<JsonModel>? jsonResolved));
            Assert.AreSame(proxy2, jsonResolved);
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

            Assert.IsTrue(options.TryGetProxy<JsonModel>(out IPersistableModel<JsonModel>? resolved));
            Assert.AreSame(proxy, resolved);

            var model = new JsonModel();
            var resolvedFromModel = options.ResolveProxy<JsonModel>((IPersistableModel<JsonModel>)model);
            Assert.AreSame(proxy, resolvedFromModel);
        }

        [Test]
        public void TryGetProxy_NoProxies_ReturnsFalse()
        {
            var options = new ModelReaderWriterOptions("J");

            Assert.IsFalse(options.TryGetProxy<JsonModel>(out IPersistableModel<JsonModel>? _));
            Assert.IsFalse(options.TryGetProxy<JsonModel>(out IJsonModel<JsonModel>? _));
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
            Assert.IsTrue(copied.TryGetProxy<JsonModel>(out IPersistableModel<JsonModel>? resolved));
            Assert.AreSame(proxy2, resolved);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Write_WithMultipleProxies_UsesLastRegistered(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>(proxy1);
            options.AddProxy<JsonModel>(proxy2);

            _optionsMap.Add(proxy2, options);
            ModelReaderWriter.Write(proxy2, options);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void Read_WithMultipleProxies_UsesLastRegistered(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>(proxy1);
            options.AddProxy<JsonModel>(proxy2);

            _optionsMap.Add(proxy2, options);
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
        public void ReadWithChain_ProxyDeclinesWithNull_FallsToModel()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ChainProxy(handleRead: false); // returns null = decline
            options.AddProxy<SimpleModel>(proxy);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            var result = options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);
            Assert.IsNotNull(result);
            Assert.IsTrue(proxy.CreateWasCalled);
            // Model handled it since proxy declined
            Assert.IsNull(options.ProxiedModel);
        }

        [Test]
        public void ReadWithChain_SecondProxyHandlesAfterFirstDeclines()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: true);   // will handle
            var proxy2 = new ChainProxy(handleRead: false);  // will decline

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            var result = options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);

            Assert.IsNotNull(result);
            // proxy2 was tried first (last added), declined
            Assert.IsTrue(proxy2.CreateWasCalled);
            // proxy1 was tried next, handled it
            Assert.IsTrue(proxy1.CreateWasCalled);
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
            Assert.IsTrue(proxy1.CreateWasCalled);
            Assert.IsTrue(proxy2.CreateWasCalled);
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
            // Default proxy handles everything
            var defaultProxy = new ChainProxy(handleRead: true);
            // Discriminator proxy only handles data containing "special"
            var discriminatorProxy = new DiscriminatorProxy("special");

            options.AddProxy<SimpleModel>(defaultProxy);
            options.AddProxy<SimpleModel>(discriminatorProxy);

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

            // Data without discriminator — discriminatorProxy declines, defaultProxy handles
            var normalData = BinaryData.FromString("{\"type\":\"standard\"}");
            result = options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, normalData);
            Assert.IsNotNull(result);
            Assert.IsTrue(discriminatorProxy.CreateWasCalled); // was called, returned null
            Assert.IsTrue(defaultProxy.CreateWasCalled); // handled it
        }

        [Test]
        public void ResolveProxy_Write_StillLastWins()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: false);
            var proxy2 = new ChainProxy(handleRead: false);

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            // Write always uses last added regardless of read behavior
            var model = new SimpleModel();
            var resolved = options.ResolveProxy<SimpleModel>((IPersistableModel<SimpleModel>)model);
            Assert.AreSame(proxy2, resolved);
        }

        /// <summary>
        /// Simple model without AssertOptions logic, used for chain tests.
        /// </summary>
        private class SimpleModel : IJsonModel<SimpleModel>
        {
            SimpleModel IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                => new SimpleModel();

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
        /// A proxy that can be configured to handle or decline reads.
        /// Returning null from Create signals "I can't handle this, try the next proxy."
        /// </summary>
        private class ChainProxy : IJsonModel<SimpleModel>
        {
            private readonly bool _handleRead;
            public bool CreateWasCalled { get; private set; }
            public object? CapturedProxiedModelOnCreate { get; private set; }

            public ChainProxy(bool handleRead)
            {
                _handleRead = handleRead;
            }

            public void Reset()
            {
                CreateWasCalled = false;
                CapturedProxiedModelOnCreate = null;
            }

            SimpleModel? IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                CreateWasCalled = true;
                CapturedProxiedModelOnCreate = options.ProxiedModel;
                return _handleRead ? new SimpleModel() : null;
            }

            SimpleModel? IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                CreateWasCalled = true;
                CapturedProxiedModelOnCreate = options.ProxiedModel;
                if (_handleRead)
                {
                    // Advance the reader past the object so caller sees it consumed
                    using var doc = JsonDocument.ParseValue(ref reader);
                    return new SimpleModel();
                }
                return null;
            }

            void IJsonModel<SimpleModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options)
                => ModelReaderWriter.Write(this, options);

            string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        /// <summary>
        /// A proxy that peeks at the data to check for a discriminator value.
        /// Returns null (declines) if the discriminator doesn't match.
        /// </summary>
        private class DiscriminatorProxy : IJsonModel<SimpleModel>
        {
            private readonly string _discriminatorValue;
            public bool CreateWasCalled { get; private set; }

            public DiscriminatorProxy(string discriminatorValue)
            {
                _discriminatorValue = discriminatorValue;
            }

            public void Reset() => CreateWasCalled = false;

            SimpleModel? IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                CreateWasCalled = true;
                if (data.ToString().Contains($"\"type\":\"{_discriminatorValue}\""))
                {
                    return new SimpleModel();
                }
                return null; // decline
            }

            SimpleModel IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                => new SimpleModel();

            void IJsonModel<SimpleModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options)
                => ModelReaderWriter.Write(this, options);

            string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
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
            options.AddProxy<SimpleModel>(proxy);

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
            options.AddProxy<SimpleModel>(proxy);

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
            options.AddProxy<SimpleModel>(proxy);

            var model = new SimpleModel();
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes("{}");
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read(); // advance to StartObject
            options.ReadWithChain<SimpleModel>((IJsonModel<SimpleModel>)model, ref reader);

            Assert.AreSame(model, proxy.CapturedOnCreateReader,
                "ProxiedModel must be set to the original model when proxy.Create(ref Utf8JsonReader) is called, " +
                "so the proxy knows which model instance it is acting on behalf of.");
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
            options.AddProxy<SimpleModel>(proxy);

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
            var proxy1 = new ChainProxy(handleRead: true);   // will handle (fallback)
            var proxy2 = new ChainProxy(handleRead: false);  // will decline (tried first)

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);

            Assert.AreSame(model, proxy2.CapturedProxiedModelOnCreate,
                "ProxiedModel must be set to the original model when the first proxy in the chain " +
                "(last registered) is called, even though it will decline.");

            Assert.AreSame(model, proxy1.CapturedProxiedModelOnCreate,
                "ProxiedModel must still be set to the original model when the second proxy in the chain " +
                "is called after the first declined. ProxiedModel must not leak state between chain attempts.");
        }

        [Test]
        public void ProxiedModel_IsCorrectForEachProxy_InChain_ReaderPath()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new ChainProxy(handleRead: true);   // will handle (fallback)
            var proxy2 = new ChainProxy(handleRead: false);  // will decline (tried first)

            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes("{}");
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read(); // advance to StartObject
            options.ReadWithChain<SimpleModel>((IJsonModel<SimpleModel>)model, ref reader);

            Assert.AreSame(model, proxy2.CapturedProxiedModelOnCreate,
                "ProxiedModel must be set to the original model when the first proxy in the reader-based chain " +
                "(last registered) is called, even though it will decline.");

            Assert.AreSame(model, proxy1.CapturedProxiedModelOnCreate,
                "ProxiedModel must still be set to the original model when the second proxy in the reader-based " +
                "chain is called after the first declined. The reader-snapshot restore must not affect ProxiedModel state.");
        }

        [Test]
        public void ProxiedModel_IsSetPerElement_InCollection()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ProxiedModelCapturingProxy();
            options.AddProxy<SimpleModel>(proxy);

            // Read a JSON array with 3 elements — each element should set ProxiedModel
            var json = "[{},{},{}]";
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes(json);
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read(); // advance to StartArray

            // Simulate what JsonCollectionReader does per element:
            // For each StartObject, call ReadWithChain with reader-based chain.
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

            Assert.AreEqual(3, proxy.AllCapturedOnCreateReader.Count,
                "Proxy must be called once per collection element. Expected 3 elements but proxy was called " +
                $"{proxy.AllCapturedOnCreateReader.Count} times.");

            for (int i = 0; i < proxy.AllCapturedOnCreateReader.Count; i++)
            {
                Assert.IsNotNull(proxy.AllCapturedOnCreateReader[i],
                    $"ProxiedModel must be non-null for collection element {i + 1}. " +
                    "The per-element chain resolution must set ProxiedModel before calling each proxy.");
            }
        }

        #endregion

        #endregion
    }
}

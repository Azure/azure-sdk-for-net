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
        public void AddProxy_MultipleCallsForSameType_FirstWins()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.AddProxy<JsonModel>(proxy1);
            options.AddProxy<JsonModel>(proxy2);

            // FIFO: first registered wins for write
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

            options.AddProxy<JsonModel>(proxy1);
            options.AddProxy<JsonModel>(proxy2);

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

            options.AddProxy<JsonModel>(proxy1);
            options.AddProxy<JsonModel>(proxy2);

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

        #region Null-contract read tests (first non-null wins)

        [Test]
        public void ReadWithChain_SingleProxy_ReturnsProxyResult()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new AlwaysHandleProxy();
            options.AddProxy<SimpleModel>(proxy);

            var result = ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), options);

            Assert.IsNotNull(result);
            Assert.IsTrue(proxy.CreateWasCalled);
        }

        [Test]
        public void ReadWithChain_ProxyReturnsNull_FallsBackToModel()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new NullReturningProxy(); // returns null = "can't handle"
            options.AddProxy<SimpleModel>(proxy);

            var result = ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), options);

            Assert.IsNotNull(result);
            Assert.IsTrue(proxy.CreateWasCalled, "Proxy should have been consulted.");
        }

        [Test]
        public void ReadWithChain_FirstNonNullWins()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new NullReturningProxy();    // returns null (can't handle)
            var proxy2 = new AlwaysHandleProxy();     // returns non-null (handles)
            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var result = ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), options);

            Assert.IsNotNull(result);
            Assert.IsTrue(proxy1.CreateWasCalled, "proxy1 should have been consulted first.");
            Assert.IsTrue(proxy2.CreateWasCalled, "proxy2 should have handled after proxy1 returned null.");
        }

        [Test]
        public void ReadWithChain_AllReturnNull_ModelHandlesItself()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new NullReturningProxy();
            var proxy2 = new NullReturningProxy();
            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var result = ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), options);

            Assert.IsNotNull(result, "Model itself should handle when all proxies return null.");
            Assert.IsTrue(proxy1.CreateWasCalled);
            Assert.IsTrue(proxy2.CreateWasCalled);
        }

        [Test]
        public void ReadWithChain_DiscriminatorPattern_ViaNull()
        {
            var options = new ModelReaderWriterOptions("J");
            // Discriminator proxy: only handles if "type" == "special", otherwise returns null
            var discriminatorProxy = new DiscriminatorProxy("special");
            var defaultProxy = new AlwaysHandleProxy();
            options.AddProxy<SimpleModel>(discriminatorProxy);
            options.AddProxy<SimpleModel>(defaultProxy);

            // Matches discriminator
            var specialResult = ModelReaderWriter.Read<SimpleModel>(
                BinaryData.FromString("{\"type\":\"special\"}"), options);
            Assert.IsNotNull(specialResult);
            Assert.IsTrue(discriminatorProxy.CreateWasCalled);
            Assert.IsFalse(defaultProxy.CreateWasCalled,
                "Default proxy should not be reached when discriminator handles.");

            discriminatorProxy.Reset();
            defaultProxy.Reset();

            // Doesn't match discriminator — falls through to default
            var otherResult = ModelReaderWriter.Read<SimpleModel>(
                BinaryData.FromString("{\"type\":\"other\"}"), options);
            Assert.IsNotNull(otherResult);
            Assert.IsTrue(discriminatorProxy.CreateWasCalled, "Discriminator was consulted.");
            Assert.IsTrue(defaultProxy.CreateWasCalled, "Default proxy handled after discriminator returned null.");
        }

        #endregion

        #region Write tests (last in list wins)

        [Test]
        public void Write_FirstProxyInListWins()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new AlwaysHandleProxy();
            var proxy2 = new AlwaysHandleProxy();
            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var model = new SimpleModel();
            ModelReaderWriter.Write(model, options);

            Assert.IsTrue(proxy1.WriteWasCalled,
                "proxy1 (first registered) should be used for write — FIFO.");
            Assert.IsFalse(proxy2.WriteWasCalled,
                "proxy2 (last registered) should NOT be used for write.");
        }

        [Test]
        public void Write_SingleProxy_UsesIt()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new AlwaysHandleProxy();
            options.AddProxy<SimpleModel>(proxy);

            var model = new SimpleModel();
            ModelReaderWriter.Write(model, options);

            Assert.IsTrue(proxy.WriteWasCalled);
        }

        #endregion

        #region ProxiedModel contract tests

        [Test]
        public void ProxiedModel_IsSetToOriginalModel_DuringProxyWrite()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ProxiedModelCapturingProxy();
            options.AddProxy<SimpleModel>(proxy);

            var model = new SimpleModel();
            ModelReaderWriter.Write(model, options);

            Assert.AreSame(model, proxy.CapturedOnWrite,
                "ProxiedModel must be set to the original model when proxy.Write is called.");
        }

        [Test]
        public void ProxiedModel_IsSetToOriginalModel_DuringProxyRead()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ProxiedModelCapturingProxy();
            options.AddProxy<SimpleModel>(proxy);

            var result = ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), options);

            Assert.IsNotNull(proxy.CapturedOnCreate,
                "ProxiedModel must be set during proxy Create.");
        }

        [Test]
        public void ProxiedModel_IsNull_WhenModelHandlesItself()
        {
            var options = new ModelReaderWriterOptions("J");
            // No proxy registered — model handles itself

            var result = ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), options);

            Assert.IsNull(options.ProxiedModel,
                "ProxiedModel should be null when model handles itself.");
        }

        #endregion

        #region JsonModelConverter integration tests

        [Test]
        public void JsonModelConverter_Read_ProxyHandles()
        {
            var mrwOptions = new ModelReaderWriterOptions("J");
            var proxy = new AlwaysHandleProxy();
            mrwOptions.AddProxy<SimpleModel>(proxy);

            var stjOptions = new JsonSerializerOptions();
            stjOptions.Converters.Add(new JsonModelConverter(mrwOptions));

            var result = JsonSerializer.Deserialize<SimpleModel>("{}", stjOptions);

            Assert.IsNotNull(result);
            Assert.IsTrue(proxy.CreateWasCalled);
        }

        [Test]
        public void JsonModelConverter_Read_FirstNonNullWins()
        {
            var mrwOptions = new ModelReaderWriterOptions("J");
            var proxy1 = new NullReturningProxy();
            var proxy2 = new AlwaysHandleProxy();
            mrwOptions.AddProxy<SimpleModel>(proxy1);
            mrwOptions.AddProxy<SimpleModel>(proxy2);

            var stjOptions = new JsonSerializerOptions();
            stjOptions.Converters.Add(new JsonModelConverter(mrwOptions));

            var result = JsonSerializer.Deserialize<SimpleModel>("{}", stjOptions);

            Assert.IsNotNull(result);
            Assert.IsTrue(proxy2.CreateWasCalled);
        }

        [Test]
        public void JsonModelConverter_Read_AllReturnNull_ModelHandles()
        {
            var mrwOptions = new ModelReaderWriterOptions("J");
            var proxy1 = new NullReturningProxy();
            var proxy2 = new NullReturningProxy();
            mrwOptions.AddProxy<SimpleModel>(proxy1);
            mrwOptions.AddProxy<SimpleModel>(proxy2);

            var stjOptions = new JsonSerializerOptions();
            stjOptions.Converters.Add(new JsonModelConverter(mrwOptions));

            var result = JsonSerializer.Deserialize<SimpleModel>("{}", stjOptions);

            Assert.IsNotNull(result);
            Assert.IsTrue(proxy1.CreateWasCalled);
            Assert.IsTrue(proxy2.CreateWasCalled);
        }

        [Test]
        public void JsonModelConverter_Read_DiscriminatorPattern()
        {
            var mrwOptions = new ModelReaderWriterOptions("J");
            var discriminatorProxy = new DiscriminatorProxy("special");
            var defaultProxy = new AlwaysHandleProxy();
            mrwOptions.AddProxy<SimpleModel>(discriminatorProxy);
            mrwOptions.AddProxy<SimpleModel>(defaultProxy);

            var stjOptions = new JsonSerializerOptions();
            stjOptions.Converters.Add(new JsonModelConverter(mrwOptions));

            // Discriminator matches
            var specialResult = JsonSerializer.Deserialize<SimpleModel>("{\"type\":\"special\"}", stjOptions);
            Assert.IsNotNull(specialResult);
            Assert.IsTrue(discriminatorProxy.CreateWasCalled);
            Assert.IsFalse(defaultProxy.CreateWasCalled);
        }

        #endregion

        #region BinaryData read tests

        [Test]
        public void Read_BinaryData_FirstNonNullWins()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new NullReturningProxy();
            var proxy2 = new AlwaysHandleProxy();
            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var result = ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), options);

            Assert.IsNotNull(result);
            Assert.IsTrue(proxy1.CreateWasCalled);
            Assert.IsTrue(proxy2.CreateWasCalled);
        }

        [Test]
        public void Read_BinaryData_AllReturnNull_ModelHandles()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new NullReturningProxy();
            var proxy2 = new NullReturningProxy();
            options.AddProxy<SimpleModel>(proxy1);
            options.AddProxy<SimpleModel>(proxy2);

            var result = ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), options);

            Assert.IsNotNull(result);
        }

        #endregion

        #region Test helpers

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
        /// A proxy that always returns a non-null result from Create (handles everything).
        /// </summary>
        private class AlwaysHandleProxy : IJsonModel<SimpleModel>
        {
            public bool CreateWasCalled { get; private set; }
            public bool WriteWasCalled { get; private set; }

            SimpleModel IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                CreateWasCalled = true;
                using var doc = JsonDocument.ParseValue(ref reader);
                return new SimpleModel();
            }

            SimpleModel IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                CreateWasCalled = true;
                return new SimpleModel();
            }

            string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            void IJsonModel<SimpleModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                WriteWasCalled = true;
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options)
                => ModelReaderWriter.Write(this, options);

            public void Reset()
            {
                CreateWasCalled = false;
                WriteWasCalled = false;
            }
        }

        /// <summary>
        /// A proxy that always returns null from Create (can't handle = decline).
        /// This is the "null contract" — returning null means "I can't handle this, try next."
        /// </summary>
        private class NullReturningProxy : IJsonModel<SimpleModel>
        {
            public bool CreateWasCalled { get; private set; }

            SimpleModel? IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                CreateWasCalled = true;
                return null!;
            }

            SimpleModel? IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                CreateWasCalled = true;
                return null!;
            }

            string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            void IJsonModel<SimpleModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options)
                => ModelReaderWriter.Write(this, options);

            public void Reset() => CreateWasCalled = false;
        }

        /// <summary>
        /// A discriminator proxy that checks for a specific "type" value in the data.
        /// Returns null if the discriminator doesn't match (null contract).
        /// </summary>
        private class DiscriminatorProxy : IJsonModel<SimpleModel>
        {
            private readonly string _discriminatorValue;
            public bool CreateWasCalled { get; private set; }

            public DiscriminatorProxy(string discriminatorValue)
            {
                _discriminatorValue = discriminatorValue;
            }

            SimpleModel? IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                CreateWasCalled = true;
                var copy = reader;
                using var doc = JsonDocument.ParseValue(ref copy);
                if (doc.RootElement.TryGetProperty("type", out var typeProp)
                    && typeProp.GetString() == _discriminatorValue)
                {
                    using var doc2 = JsonDocument.ParseValue(ref reader);
                    return new SimpleModel();
                }
                return null!;
            }

            SimpleModel? IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                CreateWasCalled = true;
                if (data.ToString().Contains($"\"type\":\"{_discriminatorValue}\""))
                {
                    return new SimpleModel();
                }
                return null!;
            }

            string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            void IJsonModel<SimpleModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options)
                => ModelReaderWriter.Write(this, options);

            public void Reset() => CreateWasCalled = false;
        }

        /// <summary>
        /// A proxy that captures the ProxiedModel value during Create/Write.
        /// </summary>
        private class ProxiedModelCapturingProxy : IJsonModel<SimpleModel>
        {
            public object? CapturedOnWrite { get; private set; }
            public object? CapturedOnCreate { get; private set; }

            SimpleModel IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                CapturedOnCreate = options.ProxiedModel;
                using var doc = JsonDocument.ParseValue(ref reader);
                return new SimpleModel();
            }

            SimpleModel IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                CapturedOnCreate = options.ProxiedModel;
                return new SimpleModel();
            }

            string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            void IJsonModel<SimpleModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                CapturedOnWrite = options.ProxiedModel;
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options)
                => ModelReaderWriter.Write(this, options);
        }

        #endregion
    }
}
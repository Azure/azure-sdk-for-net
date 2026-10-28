// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    public class ModelReaderWriterOptionsCopyAndContextTests
    {
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
            Assert.AreSame(ProxyOptionsInspector.GetProxies(options), ProxyOptionsInspector.GetProxies(copied));
        }

        [Test]
        public void ConditionalProxy_CanHandle_ReceivesOptions()
        {
            // Proves the proxy condition can depend on the caller-provided options (the derived
            // options type is preserved across the internal core copy).
            var enabled = new FlaggedOptions(useProxy: true);
            var proxyEnabled = new OptionsAwareProxy();
            enabled.AddProxy<SimpleModel>(proxyEnabled);
            Assert.IsNotNull(ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), enabled));
            Assert.IsTrue(proxyEnabled.CreateWasCalled, "Proxy should handle when the options flag is on.");

            var disabled = new FlaggedOptions(useProxy: false);
            var proxyDisabled = new OptionsAwareProxy();
            disabled.AddProxy<SimpleModel>(proxyDisabled);
            Assert.IsNotNull(ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), disabled));
            Assert.IsFalse(proxyDisabled.CreateWasCalled, "Proxy should decline when the options flag is off.");
        }

        [Test]
        public void FormatAndOptionsConstructor_CopiesRegistrationsAndPreservesProxyOptions()
        {
            var userOptions = new FlaggedOptions(useProxy: true);
            var proxy = new OptionsAwareProxy();
            userOptions.AddProxy<SimpleModel>(proxy);

            var wireOptions = new ModelReaderWriterOptions("W", userOptions);
            SimpleModel? result = ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), wireOptions);

            Assert.AreEqual("W", wireOptions.Format);
            Assert.IsFalse(wireOptions.IsCoreOwned);
            Assert.AreNotSame(ProxyOptionsInspector.GetProxies(userOptions), ProxyOptionsInspector.GetProxies(wireOptions));
            Assert.IsNotNull(result);
            Assert.IsTrue(proxy.CreateWasCalled, "The conditional proxy should receive the original derived options.");
        }

        [Test]
        public void FormatAndOptionsConstructor_FormatChangingCopyPassesOriginalOptionsToCanHandle()
        {
            var userOptions = new FlaggedOptions(useProxy: true);
            var proxy = new OptionsRecordingProxy();
            userOptions.AddProxy<SimpleModel>(proxy);

            var copy = new ModelReaderWriterOptions("PT", userOptions);
            ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), copy);

            Assert.AreEqual("PT", copy.Format);
            Assert.AreSame(userOptions, proxy.SeenOptions);
            Assert.AreEqual("J", proxy.SeenOptions!.Format);
        }

        [Test]
        public void FormatAndOptionsConstructor_RejectsNullOptions()
        {
            Assert.Throws<ArgumentNullException>(() => new ModelReaderWriterOptions("W", (ModelReaderWriterOptions)null!));
        }

        [Test]
        public void ContextConstructors_RejectNullContext()
        {
            Assert.Throws<ArgumentNullException>(() => new ModelReaderWriterOptions("J", (ModelReaderWriterContext)null!));
            Assert.Throws<ArgumentNullException>(() => new ModelReaderWriterOptions("J", ModelReaderWriterOptions.Json, null!));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ConditionalProxy_StandaloneResolutionRequiresContext(bool json)
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ContextAwareProxy();
            options.AddProxy<SimpleModel>(proxy);
            var model = new SimpleModel();

            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                if (json)
                {
                    options.ResolveProxy((IJsonModel<SimpleModel>)model);
                }
                else
                {
                    options.ResolveProxy((IPersistableModel<SimpleModel>)model);
                }
            });

            StringAssert.Contains("ModelReaderWriterContext", exception!.Message);
            Assert.IsNull(proxy.LastContext);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ConditionalProxy_StandaloneResolutionUsesConfiguredContext(bool json)
        {
            var context = ModelReaderWriterReflectionContext.Default;
            var options = new ModelReaderWriterOptions("J", context);
            var proxy = new ContextAwareProxy();
            options.AddProxy<SimpleModel>(proxy);
            var model = new SimpleModel();

            object resolved = json
                ? options.ResolveProxy((IJsonModel<SimpleModel>)model)
                : options.ResolveProxy((IPersistableModel<SimpleModel>)model);

            Assert.AreSame(proxy.Model, resolved);
            Assert.AreSame(context, proxy.LastContext);
        }

        [Test]
        public void ConditionalProxy_BinaryContentRequiresContext()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ContextAwareProxy();
            options.AddProxy<SimpleModel>(proxy);

            var exception = Assert.Throws<InvalidOperationException>(() => BinaryContent.Create(new SimpleModel(), options));

            StringAssert.Contains("ModelReaderWriterContext", exception!.Message);
            Assert.IsNull(proxy.LastContext);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ConditionalProxy_ConverterWithoutExplicitContextProvidesUsableContext(bool read)
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new ContextAwareProxy();
            options.AddProxy<SimpleModel>(proxy);
            var serializerOptions = new JsonSerializerOptions
            {
                Converters = { new JsonModelConverter(options) }
            };

            if (read)
            {
                Assert.IsNotNull(JsonSerializer.Deserialize<SimpleModel>("{}", serializerOptions));
            }
            else
            {
                Assert.AreEqual("{}", JsonSerializer.Serialize(new SimpleModel(), serializerOptions));
            }

            Assert.AreSame(ModelReaderWriterReflectionContext.Default, proxy.LastContext);
        }

        [Test]
        public void ConditionalProxy_OperationContextOverridesConfiguredContext()
        {
            var configured = new NestedWriteContext();
            var options = new ModelReaderWriterOptions("J", configured);
            var proxy = new ContextAwareProxy();
            options.AddProxy<SimpleModel>(proxy);

            ModelReaderWriter.Write(new SimpleModel(), options, ModelReaderWriterReflectionContext.Default);

            Assert.AreSame(ModelReaderWriterReflectionContext.Default, proxy.LastContext);
            Assert.AreSame(configured, options.ProxyResolutionContext);
        }

        private sealed class ContextAwareProxy : ConditionalModelProxy<SimpleModel>
        {
            internal ModelReaderWriterContext? LastContext { get; private set; }

            internal ContextAwareProxy() : base(new TrackingModel()) { }

            public override bool CanHandle(SimpleModel model, ModelReaderWriterOptions options, ModelReaderWriterContext context)
                => Observe(context);

            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context)
                => Observe(context);

            public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options, ModelReaderWriterContext context)
                => Observe(context);

            private bool Observe(ModelReaderWriterContext context)
            {
                Assert.IsNotNull(context.GetTypeBuilder(typeof(SimpleModel)));
                LastContext = context;
                return true;
            }
        }

        /// <summary>
        /// A derived options type carrying a custom flag the proxy conditions on.
        /// </summary>
        private class FlaggedOptions : ModelReaderWriterOptions
        {
            public bool UseProxy { get; }
            public FlaggedOptions(bool useProxy) : base("J") => UseProxy = useProxy;
        }

        /// <summary>
        /// A conditional proxy whose decision depends on the active options.
        /// </summary>
        private class OptionsAwareProxy : ConditionalModelProxy<SimpleModel>
        {
            public OptionsAwareProxy() : base(new TrackingModel()) { }

            public bool CreateWasCalled => ((TrackingModel)Model).CreateWasCalled;

            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context)
                => options is FlaggedOptions flagged && flagged.UseProxy;

            public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options, ModelReaderWriterContext context)
                => options is FlaggedOptions flagged && flagged.UseProxy;
        }

        /// <summary>
        /// A conditional proxy that records the options passed to <c>CanHandle</c> and never handles the request.
        /// </summary>
        private class OptionsRecordingProxy : ConditionalModelProxy<SimpleModel>
        {
            public OptionsRecordingProxy() : base(new TrackingModel()) { }

            public ModelReaderWriterOptions? SeenOptions { get; private set; }

            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context)
            {
                SeenOptions = options;
                return false;
            }

            public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options, ModelReaderWriterContext context)
            {
                SeenOptions = options;
                return false;
            }
        }
    }
}

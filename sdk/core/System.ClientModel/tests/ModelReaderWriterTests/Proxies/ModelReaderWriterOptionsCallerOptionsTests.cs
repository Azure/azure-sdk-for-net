// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support;
using System.Text.Json;
using NUnit.Framework;
using static System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support.BinaryContentHelper;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    /// <summary>
    /// Proxies receive the options supplied by the caller, regardless of the entry point used.
    /// </summary>
    public class ModelReaderWriterOptionsCallerOptionsTests
    {
        public enum EntryPoint
        {
            ModelReaderWriterWrite,
            ModelReaderWriterWriteWithContext,
            ModelReaderWriterRead,
            BinaryContent,
            JsonModelConverterWrite,
            JsonModelConverterRead,
            ResolveProxy,
            ResolveJsonProxy,
            NestedWrite
        }

        [TestCase(EntryPoint.ModelReaderWriterWrite)]
        [TestCase(EntryPoint.ModelReaderWriterWriteWithContext)]
        [TestCase(EntryPoint.ModelReaderWriterRead)]
        [TestCase(EntryPoint.BinaryContent)]
        [TestCase(EntryPoint.JsonModelConverterWrite)]
        [TestCase(EntryPoint.JsonModelConverterRead)]
        [TestCase(EntryPoint.ResolveProxy)]
        [TestCase(EntryPoint.ResolveJsonProxy)]
        [TestCase(EntryPoint.NestedWrite)]
        public void CanHandle_ReceivesCallerOptions(EntryPoint entryPoint)
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new OptionsTrackingProxy();
            options.Proxies.Add(proxy);
            var model = new SimpleModel();
            var serializerOptions = new JsonSerializerOptions
            {
                Converters = { new JsonModelConverter(options) }
            };
            bool resolvesOnCallerOptions = false;

            switch (entryPoint)
            {
                case EntryPoint.ModelReaderWriterWrite:
                    Assert.AreEqual("{}", ModelReaderWriter.Write(model, options).ToString());
                    Assert.AreSame(model, proxy.CapturedProxiedModelOnWrite);
                    break;
                case EntryPoint.ModelReaderWriterWriteWithContext:
                    Assert.AreEqual("{}", ModelReaderWriter.Write(model, options, ModelReaderWriterReflectionContext.Default).ToString());
                    Assert.AreSame(model, proxy.CapturedProxiedModelOnWrite);
                    break;
                case EntryPoint.ModelReaderWriterRead:
                    Assert.IsNotNull(ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), options));
                    Assert.IsTrue(proxy.CreateWasCalled);
                    break;
                case EntryPoint.BinaryContent:
                    Assert.AreEqual("{}", WriteBinaryContent(model, options).ToString());
                    Assert.AreSame(model, proxy.CapturedProxiedModelOnWrite);
                    break;
                case EntryPoint.JsonModelConverterWrite:
                    Assert.AreEqual("{}", JsonSerializer.Serialize(model, serializerOptions));
                    Assert.AreSame(model, proxy.CapturedProxiedModelOnWrite);
                    break;
                case EntryPoint.JsonModelConverterRead:
                    Assert.IsNotNull(JsonSerializer.Deserialize<SimpleModel>("{}", serializerOptions));
                    Assert.IsTrue(proxy.CreateWasCalled);
                    break;
                case EntryPoint.ResolveProxy:
                    IPersistableModel<SimpleModel> resolved = options.ResolveProxy((IPersistableModel<SimpleModel>)model);
                    Assert.AreSame(proxy, resolved);
                    Assert.AreEqual("{}", resolved.Write(options).ToString());
                    Assert.AreSame(model, proxy.CapturedProxiedModelOnWrite);
                    resolvesOnCallerOptions = true;
                    break;
                case EntryPoint.ResolveJsonProxy:
                    Assert.AreSame(proxy, options.ResolveProxy((IJsonModel<SimpleModel>)model));
                    resolvesOnCallerOptions = true;
                    break;
                case EntryPoint.NestedWrite:
                    options.Proxies.Add(new NestedWriteParentProxy(model));
                    Assert.AreEqual("{}", ModelReaderWriter.Write(new PlainTextModel(), options).ToString());
                    Assert.AreSame(model, proxy.CapturedProxiedModelOnWrite);
                    break;
            }

            Assert.AreSame(options, proxy.LastOptions);
            if (resolvesOnCallerOptions)
            {
                Assert.AreSame(model, options.ProxiedModel);
            }
            else
            {
                Assert.IsNull(options.ProxiedModel, "Operations must not mutate the caller's proxy execution state.");
            }
        }

        [Test]
        public void CanHandle_CanDependOnDerivedOptions()
        {
            // The proxy condition can depend on the caller-provided options because the derived
            // options type is preserved.
            var enabled = new FlaggedOptions(useProxy: true);
            var proxyEnabled = new OptionsAwareProxy();
            enabled.Proxies.Add(proxyEnabled);
            Assert.IsNotNull(ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), enabled));
            Assert.IsTrue(proxyEnabled.CreateWasCalled, "Proxy should handle when the options flag is on.");

            var disabled = new FlaggedOptions(useProxy: false);
            var proxyDisabled = new OptionsAwareProxy();
            disabled.Proxies.Add(proxyDisabled);
            Assert.IsNotNull(ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), disabled));
            Assert.IsFalse(proxyDisabled.CreateWasCalled, "Proxy should decline when the options flag is off.");
        }

        [Test]
        public void CopiedRegistrations_AreIndependent()
        {
            var original = new ModelReaderWriterOptions("J");
            var proxy = new OptionsTrackingProxy();
            original.Proxies.Add(proxy);
            var copy = new FlaggedOptions(useProxy: true, format: "W");
            foreach (ModelProxy registered in original.Proxies)
            {
                copy.Proxies.Add(registered);
            }
            var inserted = new OptionsTrackingProxy();
            original.Proxies.Insert(0, inserted);

            Assert.AreNotSame(original.Proxies, copy.Proxies);
            Assert.That(copy.Proxies, Is.EqualTo(new ModelProxy[] { proxy }));
            Assert.That(original.Proxies, Is.EqualTo(new ModelProxy[] { inserted, proxy }));

            Assert.IsNotNull(ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), copy));
            Assert.IsTrue(proxy.CreateWasCalled);
            Assert.IsFalse(inserted.CreateWasCalled);
            Assert.AreSame(copy, proxy.LastOptions);
            Assert.AreEqual("W", proxy.LastOptions!.Format);

            Assert.IsNotNull(ModelReaderWriter.Read<SimpleModel>(BinaryData.FromString("{}"), original));
            Assert.IsTrue(inserted.CreateWasCalled);

            var model = new SimpleModel();
            Assert.AreSame(proxy, copy.ResolveProxy((IJsonModel<SimpleModel>)model));
            Assert.AreSame(model, copy.ProxiedModel);
            Assert.IsNull(original.ProxiedModel);
        }

        private sealed class OptionsTrackingProxy : TrackingModel
        {
            internal ModelReaderWriterOptions? LastOptions { get; private set; }

            public override bool CanHandle(SimpleModel model, ModelReaderWriterOptions options)
                => Observe(options);

            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options)
                => Observe(options);

            public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                => Observe(options);

            private bool Observe(ModelReaderWriterOptions options)
            {
                LastOptions = options;
                return true;
            }
        }

        /// <summary>
        /// Writes a nested <see cref="SimpleModel"/> through <see cref="ModelReaderWriter"/> with the received options.
        /// </summary>
        private sealed class NestedWriteParentProxy : ModelProxy<PlainTextModel>
        {
            private readonly SimpleModel _child;

            internal NestedWriteParentProxy(SimpleModel child) => _child = child;

            public override BinaryData Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(_child, options);

            public override PlainTextModel Create(BinaryData data, ModelReaderWriterOptions options)
                => throw new NotSupportedException();

            public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        /// <summary>
        /// A derived options type carrying a custom flag the proxy conditions on.
        /// </summary>
        private class FlaggedOptions : ModelReaderWriterOptions
        {
            public bool UseProxy { get; }
            public FlaggedOptions(bool useProxy, string format = "J") : base(format) => UseProxy = useProxy;
        }

        /// <summary>
        /// A proxy whose read decision depends on the active options.
        /// </summary>
        private class OptionsAwareProxy : TrackingModel
        {
            public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options)
                => options is FlaggedOptions flagged && flagged.UseProxy;

            public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                => options is FlaggedOptions flagged && flagged.UseProxy;
        }
    }
}

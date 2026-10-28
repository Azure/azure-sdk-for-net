// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    public class ModelReaderWriterOptionsResolutionTests
    {
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
        public void ResolveProxy_Write_UsesCanHandle()
        {
            var options = new ModelReaderWriterOptions("J", ModelReaderWriterReflectionContext.Default);
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

        #region ResolveProxy write path with CanHandle declining

        [Test]
        public void ResolveProxy_Write_FirstDeclinesSecondHandles()
        {
            var options = new ModelReaderWriterOptions("J", ModelReaderWriterReflectionContext.Default);
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
            var options = new ModelReaderWriterOptions("J", ModelReaderWriterReflectionContext.Default);
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
            var options = new ModelReaderWriterOptions("J", ModelReaderWriterReflectionContext.Default);
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

        #region WS3 Medium-severity regression tests

        [Test]
        public void AddProxy_NullProxy_ThrowsArgumentNullException()
        {
            var options = new ModelReaderWriterOptions("J");
            Assert.Throws<ArgumentNullException>(() => options.AddProxy<SimpleModel>((IPersistableModel<SimpleModel>)null!));
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
            var options = new ModelReaderWriterOptions("J", ModelReaderWriterReflectionContext.Default);
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

        #endregion

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

            public override bool CanHandle(SimpleModel model, ModelReaderWriterOptions options, ModelReaderWriterContext context) => true;
        }
    }
}

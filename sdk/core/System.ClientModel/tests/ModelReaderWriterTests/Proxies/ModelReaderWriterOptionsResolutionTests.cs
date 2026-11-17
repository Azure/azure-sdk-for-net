// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    public class ModelReaderWriterOptionsResolutionTests
    {
        [TestCase(false, TestName = "ResolveProxy_ReturnsFirstRegistered")]
        [TestCase(true, TestName = "ResolveProxy_IJsonModel_ReturnsFirstRegistered")]
        public void ResolveProxy_ReturnsFirstRegistered(bool json)
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new JsonModelProxy();
            var proxy2 = new JsonModelProxy();

            options.Proxies.Add(proxy1);
            options.Proxies.Add(proxy2);

            var model = new JsonModel();
            object resolved = json
                ? options.ResolveProxy<JsonModel>((IJsonModel<JsonModel>)model)
                : options.ResolveProxy<JsonModel>((IPersistableModel<JsonModel>)model);
            Assert.AreSame(proxy1, resolved);
            Assert.AreSame(model, options.ProxiedModel);
        }

        [Test]
        public void TryGetProxy_NoProxies_ReturnsFalse()
        {
            var options = new ModelReaderWriterOptions("J");

            Assert.IsFalse(options.TryGetProxy<JsonModel>(ReadOnlyMemory<byte>.Empty, out IPersistableModel<JsonModel>? proxy));
            Assert.IsNull(proxy);
        }

        #region ResolveProxy write path with CanHandle declining

        [TestCase(false, TestName = "ResolveProxy_Write_FirstDeclinesSecondHandles")]
        [TestCase(true, TestName = "ResolveProxy_IJsonModel_FirstDeclinesSecondHandles")]
        public void ResolveProxy_Write_FirstDeclinesSecondHandles(bool json)
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new SelectiveWriteProxy(canWrite: false);
            var proxy2 = new SelectiveWriteProxy(canWrite: true);

            options.Proxies.Add(proxy1);
            options.Proxies.Add(proxy2);

            var model = new SimpleModel();
            object resolved = json
                ? options.ResolveProxy<SimpleModel>((IJsonModel<SimpleModel>)model)
                : options.ResolveProxy<SimpleModel>((IPersistableModel<SimpleModel>)model);

            Assert.AreSame(proxy2, resolved,
                "ResolveProxy should skip proxy1 (CanHandle=false) and return proxy2.");
        }

        [Test]
        public void ResolveProxy_Write_AllDecline_ReturnsSelf()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy1 = new SelectiveWriteProxy(canWrite: false);
            var proxy2 = new SelectiveWriteProxy(canWrite: false);

            options.Proxies.Add(proxy1);
            options.Proxies.Add(proxy2);

            var model = new SimpleModel();
            var resolved = options.ResolveProxy<SimpleModel>((IPersistableModel<SimpleModel>)model);

            Assert.AreSame(model, resolved,
                "ResolveProxy should return the model itself when all proxies decline.");
        }

        #endregion

        [Test]
        public void ResolveProxy_NullModel_ThrowsArgumentNullException()
        {
            var options = new ModelReaderWriterOptions("J");
            Assert.Throws<ArgumentNullException>(() => options.ResolveProxy<SimpleModel>((IPersistableModel<SimpleModel>)null!));
            Assert.Throws<ArgumentNullException>(() => options.ResolveProxy<SimpleModel>((IJsonModel<SimpleModel>)null!));
        }

        [Test]
        public void ResolveProxy_JsonModelOfObject_SkipsProxyWithoutJsonModel()
        {
            var options = new ModelReaderWriterOptions("J");
            // The first proxy handles the model but is persistable-only (not IJsonModel),
            // so the JSON write path must skip it instead of throwing.
            var persistableOnly = new PersistableOnlyProxy();
            var jsonProxy = new ChainProxy(handleRead: true);
            options.Proxies.Add(persistableOnly);
            options.Proxies.Add(jsonProxy);

            var model = new SimpleModel();
            var resolved = options.ResolveProxy((IJsonModel<object>)(object)model);

            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                resolved.Write(writer, options);
            }
            Assert.AreEqual("{}", BinaryData.FromBytes(stream.ToArray()).ToString());
            Assert.IsTrue(jsonProxy.WriteWasCalled,
                "ResolveProxy for IJsonModel<object> should skip the persistable-only proxy and write through the JSON proxy.");
            Assert.AreSame(model, jsonProxy.CapturedProxiedModelOnWrite);
        }

        /// <summary>
        /// A proxy that only supports the persistable (non-JSON) path.
        /// </summary>
        private class PersistableOnlyProxy : ModelProxy<SimpleModel>
        {
            public override SimpleModel Create(BinaryData data, ModelReaderWriterOptions options) => new SimpleModel();
            public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
            public override BinaryData Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");
        }
    }
}

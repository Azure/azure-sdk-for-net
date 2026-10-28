// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    public class ModelReaderWriterProxiedModelTests
    {
        [Test]
        public void ProxiedModel_IsSetToOriginalModel_DuringProxyWrite()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new TrackingModel();
            options.AddProxy<SimpleModel>((IJsonModel<SimpleModel>)proxy);

            var model = new SimpleModel();
            ModelReaderWriter.Write(model, options);

            Assert.AreSame(model, proxy.CapturedProxiedModelOnWrite,
                "ProxiedModel must be set to the original model when proxy.Write is called, " +
                "so the proxy can read the model's state during serialization.");
        }

        [Test]
        public void ProxiedModel_IsSetToOriginalModel_DuringProxyCreateBinaryData()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new TrackingModel();
            options.AddProxy<SimpleModel>((IJsonModel<SimpleModel>)proxy);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);

            Assert.AreSame(model, proxy.CapturedProxiedModelOnBinaryCreate,
                "ProxiedModel must be set to the original model when proxy.Create(BinaryData) is called, " +
                "so the proxy knows which model instance it is acting on behalf of.");
        }

        [Test]
        public void ProxiedModel_IsSetToOriginalModel_DuringProxyCreateReader()
        {
            var options = new ModelReaderWriterOptions("J");
            var proxy = new TrackingModel();
            options.AddProxy<SimpleModel>((IJsonModel<SimpleModel>)proxy);

            var model = new SimpleModel();
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes("{}");
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read();
            options.ReadWithChain<SimpleModel>((IJsonModel<SimpleModel>)model, ref reader);

            Assert.AreSame(model, proxy.CapturedProxiedModelOnReaderCreate,
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
            var proxy = new TrackingModel();
            options.AddProxy<SimpleModel>((IJsonModel<SimpleModel>)proxy);

            var model = new SimpleModel();
            var data = BinaryData.FromString("{}");
            options.ReadWithChain<SimpleModel>((IPersistableModel<SimpleModel>)model, data);

            Assert.AreSame(model, options.ProxiedModel,
                "ProxiedModel must remain set to the original model after a proxy successfully handles a read, " +
                "because downstream code may still need to reference the original model.");
        }

        [Test]
        public void ProxiedModel_IsCorrectForEachProxy_InChain()
        {
            var options = new ModelReaderWriterOptions("J", ModelReaderWriterReflectionContext.Default);
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
            var options = new ModelReaderWriterOptions("J", ModelReaderWriterReflectionContext.Default);
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
            var proxy = new TrackingModel();
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

                    Assert.IsNotNull(proxy.CapturedProxiedModelOnReaderCreate,
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
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    /// <summary>
    /// Behavior of proxy registration on <see cref="ClientPipelineOptions"/>.
    /// </summary>
    public class ProxyClientOptionsTests
    {
        private const string SpecialToolJson = "{\"type\":\"special\",\"name\":\"docs\"}";
        private const string OtherToolJson = "{\"type\":\"other\",\"name\":\"docs\"}";

        private static TestTool Read(string json, ModelReaderWriterOptions? options)
            => ModelReaderWriter.Read<TestTool>(BinaryData.FromString(json), options)!;

        // Builds the options a client uses to read and write models from the proxies on its client options.
        private static ModelReaderWriterOptions CreateModelReaderWriterOptions(ClientPipelineOptions clientOptions)
        {
            var options = new ModelReaderWriterOptions("J");
            foreach (ModelProxy proxy in clientOptions.ModelProxies)
            {
                options.Proxies.Add(proxy);
            }
            return options;
        }

        [Test]
        public void ClientOptions_ModelProxiesRejectNull()
        {
            var options = new ClientPipelineOptions();

            Assert.Throws<ArgumentNullException>(() => options.ModelProxies.Add(null!));
            Assert.Throws<ArgumentNullException>(() => options.ModelProxies.Insert(0, null!));
            Assert.That(options.ModelProxies, Is.Empty);
        }

        [Test]
        public void ClientOptions_ModelProxiesCreateModelReaderWriterOptionsThatUseTheProxy()
        {
            var options = new ClientPipelineOptions();
            Assert.That(options.ModelProxies, Is.Empty);
            Assert.IsFalse(options.ModelProxies.IsReadOnly);

            var proxy = new DerivedTestToolProxy("special");
            options.ModelProxies.Add(proxy);

            Assert.That(options.ModelProxies, Is.EqualTo(new ModelProxy[] { proxy }));
            ModelReaderWriterOptions registrations = CreateModelReaderWriterOptions(options);
            Assert.That(Read(SpecialToolJson, registrations), Is.InstanceOf<DerivedTestTool>());
            Assert.That(Read(OtherToolJson, registrations).GetType(), Is.EqualTo(typeof(TestTool)));
        }

        // Creating a pipeline freezes the client options, so both entry points must freeze the registrations.
        [TestCase(false, TestName = "ClientOptions_FreezeFreezesRegisteredProxies")]
        [TestCase(true, TestName = "ClientOptions_CreatingAPipelineFreezesRegisteredProxies")]
        public void ClientOptions_FreezeFreezesRegisteredProxies(bool createPipeline)
        {
            var options = new ClientPipelineOptions
            {
                Transport = new MockPipelineTransport("transport", 200)
            };
            options.ModelProxies.Add(new DerivedTestToolProxy("special"));
            IList<ModelProxy> registrations = options.ModelProxies;
            Assert.IsFalse(registrations.IsReadOnly);

            if (createPipeline)
            {
                ClientPipeline.Create(options);
            }
            else
            {
                options.Freeze();
            }

            Assert.IsTrue(registrations.IsReadOnly);
            Assert.AreSame(registrations, options.ModelProxies);
            Assert.Throws<InvalidOperationException>(() => registrations.Add(new DerivedTestToolProxy("other")));
            Assert.Throws<InvalidOperationException>(() => registrations.Insert(0, new DerivedTestToolProxy("other")));
            Assert.Throws<InvalidOperationException>(() => registrations[0] = new DerivedTestToolProxy("other"));
            Assert.Throws<InvalidOperationException>(() => registrations.Remove(registrations[0]));
            Assert.Throws<InvalidOperationException>(() => registrations.RemoveAt(0));
            Assert.Throws<InvalidOperationException>(() => registrations.Clear());
            Assert.AreEqual(1, registrations.Count);

            ModelReaderWriterOptions modelOptions = CreateModelReaderWriterOptions(options);
            Assert.That(Read(SpecialToolJson, modelOptions), Is.InstanceOf<DerivedTestTool>());
            Assert.That(Read(OtherToolJson, modelOptions).GetType(), Is.EqualTo(typeof(TestTool)));
        }

        [Test]
        public void ClientOptions_ModelProxiesFirstAccessedAfterCreatingAPipelineAreReadOnly()
        {
            var options = new ClientPipelineOptions
            {
                Transport = new MockPipelineTransport("transport", 200)
            };

            ClientPipeline.Create(options);

            Assert.IsTrue(options.ModelProxies.IsReadOnly);
            Assert.That(options.ModelProxies, Is.Empty);
            Assert.Throws<InvalidOperationException>(
                () => options.ModelProxies.Add(new DerivedTestToolProxy("other")));
        }

        [Test]
        public void ClientOptionsClone_OfFrozenOptionsAcceptsNewProxies()
        {
            var options = new ClientPipelineOptions();
            var special = new DerivedTestToolProxy("special");
            options.ModelProxies.Add(special);
            options.Freeze();

            ClientPipelineOptions clone = options.Clone();
            Assert.IsFalse(clone.ModelProxies.IsReadOnly);
            Assert.That(clone.ModelProxies, Is.EqualTo(new ModelProxy[] { special }));
            clone.ModelProxies.Add(new DerivedTestToolProxy("other"));

            Assert.That(Read(OtherToolJson, CreateModelReaderWriterOptions(clone)), Is.InstanceOf<DerivedTestTool>());
            Assert.That(Read(OtherToolJson, CreateModelReaderWriterOptions(options)).GetType(), Is.EqualTo(typeof(TestTool)));
            Assert.That(options.ModelProxies, Is.EqualTo(new ModelProxy[] { special }));
        }
    }
}

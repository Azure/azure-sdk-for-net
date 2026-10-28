// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
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

        [Test]
        public void ClientOptions_AddProxyRejectsNullAndFrozenOptions()
        {
            var options = new ClientPipelineOptions
            {
                Transport = new MockPipelineTransport("transport", 200)
            };

            Assert.Throws<ArgumentNullException>(
                () => options.AddProxy<TestTool>((IPersistableModel<TestTool>)null!));
            Assert.Throws<ArgumentNullException>(
                () => options.AddProxy<TestTool>((ConditionalModelProxy<TestTool>)null!));

            ClientPipeline.Create(options);

            Assert.Throws<InvalidOperationException>(
                () => options.AddProxy<TestTool>(new DerivedTestToolProxy("special")));
        }

        [Test]
        public void ClientOptions_DoNotExposeAModelReaderWriterOptionsSetter()
        {
            Assert.That(
                typeof(ClientPipelineOptions).GetProperty(nameof(ClientPipelineOptions.ModelReaderWriterOptions))!.GetSetMethod(),
                Is.Null);
        }

        [Test]
        public void ClientOptions_AddProxyCreatesModelReaderWriterOptionsThatUseTheProxy()
        {
            var options = new ClientPipelineOptions();
            Assert.That(options.ModelReaderWriterOptions, Is.Null);

            options.AddProxy<TestTool>(new DerivedTestToolProxy("special"));

            Assert.That(options.ModelReaderWriterOptions, Is.Not.Null);
            Assert.That(Read(SpecialToolJson, options.ModelReaderWriterOptions), Is.InstanceOf<DerivedTestTool>());
            Assert.That(Read(OtherToolJson, options.ModelReaderWriterOptions).GetType(), Is.EqualTo(typeof(TestTool)));
        }

        [Test]
        public void ClientOptionsClone_SeparatesProxyRegistrations()
        {
            var options = new ClientPipelineOptions();
            options.AddProxy<TestTool>(new DerivedTestToolProxy("special"));
            ClientPipelineOptions clone = options.Clone();
            options.ModelReaderWriterOptions!.AddProxy<TestTool>(new DerivedTestToolProxy("other"));

            TestTool special = Read(SpecialToolJson, clone.ModelReaderWriterOptions);
            TestTool other = Read(OtherToolJson, clone.ModelReaderWriterOptions);

            Assert.That(special, Is.InstanceOf<DerivedTestTool>());
            Assert.That(other.GetType(), Is.EqualTo(typeof(TestTool)));
            Assert.That(Read(OtherToolJson, options.ModelReaderWriterOptions), Is.InstanceOf<DerivedTestTool>());
        }
    }
}

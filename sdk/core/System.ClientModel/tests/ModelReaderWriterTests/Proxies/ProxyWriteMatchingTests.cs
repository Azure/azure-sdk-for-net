// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    public class ProxyWriteMatchingTests
    {
        // Proxies match the exact runtime type on write: a registration for the base type does not apply to a derived instance.
        [Test]
        public void Write_BaseTypeRegistrationDoesNotApplyToDerivedInstance()
        {
            var options = new ModelReaderWriterOptions("J");
            var baseProxy = new SentinelModel<TestTool>("base");
            options.AddProxy<TestTool>(baseProxy);
            var tool = new DerivedTestTool("derived", "docs");
            string original = ModelReaderWriter.Write(tool, new ModelReaderWriterOptions("J")).ToString();

            Assert.That(ModelReaderWriter.Write<TestTool>(tool, options).ToString(), Is.EqualTo(original));
            Assert.That(baseProxy.ProxiedModelAtWrite, Is.Null);

            options.AddProxy<DerivedTestTool>(new SentinelModel<DerivedTestTool>("exact"));

            Assert.That(ModelReaderWriter.Write<TestTool>(tool, options).ToString(), Is.EqualTo("{\"sentinel\":\"exact\"}"));
        }

        // Writes a distinct sentinel document so a test can tell the proxy, not the original model, wrote.
        private sealed class SentinelModel<T> : IJsonModel<T>
        {
            private readonly string _name;

            public SentinelModel(string name) => _name = name;

            public object? ProxiedModelAtWrite { get; private set; }

            T IJsonModel<T>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();

            void IJsonModel<T>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                ProxiedModelAtWrite = options.ProxiedModel;
                writer.WriteStartObject();
                writer.WriteString("sentinel"u8, _name);
                writer.WriteEndObject();
            }

            T IPersistableModel<T>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();

            BinaryData IPersistableModel<T>.Write(ModelReaderWriterOptions options) => BinaryData.FromString($"{{\"sentinel\":\"{_name}\"}}");

            string IPersistableModel<T>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }
    }
}

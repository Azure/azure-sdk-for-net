// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    // Takes over reading a TestTool only when the payload's "type" discriminator matches, and writes DerivedTestTool
    // instances through the proxied model.
    internal sealed class DerivedTestToolProxy : ModelProxy<TestTool>, IJsonModel<TestTool>
    {
        private readonly string _discriminator;

        public DerivedTestToolProxy(string discriminator)
        {
            _discriminator = discriminator;
        }

        public override bool CanHandle(TestTool model, ModelReaderWriterOptions options)
            => model is DerivedTestTool;

        public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data);
            return HasDiscriminator(document.RootElement);
        }

        public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            Utf8JsonReader copy = reader;
            using JsonDocument document = JsonDocument.ParseValue(ref copy);
            return HasDiscriminator(document.RootElement);
        }

        private bool HasDiscriminator(JsonElement element)
            => element.TryGetProperty("type", out JsonElement type) && type.GetString() == _discriminator;

        TestTool IJsonModel<TestTool>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DerivedTestTool.Deserialize(document.RootElement);
        }

        void IJsonModel<TestTool>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<TestTool>)options.ProxiedModel!).Write(writer, options);

        public override TestTool Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data);
            return DerivedTestTool.Deserialize(document.RootElement);
        }

        public override BinaryData Write(ModelReaderWriterOptions options)
        {
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<TestTool>)options.ProxiedModel!).Write(writer, options);
            }
            return BinaryData.FromBytes(stream.ToArray());
        }

        public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}

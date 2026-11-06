// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    // Takes over reading a TestTool only when the payload's "type" discriminator matches, and writes DerivedTestTool
    // instances through the proxied model.
    internal sealed class DerivedTestToolProxy : ConditionalModelProxy<TestTool>
    {
        private readonly string _discriminator;

        public DerivedTestToolProxy(string discriminator) : base(new DerivedTestToolModel())
        {
            _discriminator = discriminator;
        }

        public override bool CanHandle(TestTool model, ModelReaderWriterOptions options, ModelReaderWriterContext context)
            => model is DerivedTestTool;

        public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context)
        {
            using JsonDocument document = JsonDocument.Parse(data);
            return HasDiscriminator(document.RootElement);
        }

        public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options, ModelReaderWriterContext context)
        {
            Utf8JsonReader copy = reader;
            using JsonDocument document = JsonDocument.ParseValue(ref copy);
            return HasDiscriminator(document.RootElement);
        }

        private bool HasDiscriminator(JsonElement element)
            => element.TryGetProperty("type", out JsonElement type) && type.GetString() == _discriminator;

        private sealed class DerivedTestToolModel : IJsonModel<TestTool>
        {
            TestTool IJsonModel<TestTool>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using JsonDocument document = JsonDocument.ParseValue(ref reader);
                return DerivedTestTool.Deserialize(document.RootElement);
            }

            void IJsonModel<TestTool>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
                => ((IJsonModel<TestTool>)options.ProxiedModel!).Write(writer, options);

            TestTool IPersistableModel<TestTool>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                using JsonDocument document = JsonDocument.Parse(data);
                return DerivedTestTool.Deserialize(document.RootElement);
            }

            BinaryData IPersistableModel<TestTool>.Write(ModelReaderWriterOptions options)
                => ModelReaderWriter.Write((TestTool)options.ProxiedModel!, options);

            string IPersistableModel<TestTool>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }
    }
}

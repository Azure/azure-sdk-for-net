// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Proxy.OpenAILike;
using System.Text.Json;

namespace System.ClientModel.Tests.Proxy.ThirdPartyB
{
    /// <summary>
    /// Conditional proxy that takes over only when the payload's "type" discriminator is
    /// "bing_grounding". Otherwise it declines so the chain continues to the next proxy / base.
    /// </summary>
    public sealed class BingGroundingToolProxy : ConditionalModelProxy<ResponseTool>
    {
        public BingGroundingToolProxy() : base(new BingGroundingToolModel())
        {
        }

        public override bool CanHandle(ResponseTool model) => model is BingGroundingTool;

        public override bool CanHandle(ReadOnlyMemory<byte> data)
        {
            using JsonDocument doc = JsonDocument.Parse(BinaryData.FromBytes(data).ToString());
            return doc.RootElement.TryGetProperty("type", out var t) && t.GetString() == "bing_grounding";
        }

        public override bool CanHandle(ref Utf8JsonReader reader)
        {
            Utf8JsonReader copy = reader;
            using JsonDocument doc = JsonDocument.ParseValue(ref copy);
            return doc.RootElement.TryGetProperty("type", out var t) && t.GetString() == "bing_grounding";
        }

        private sealed class BingGroundingToolModel : IJsonModel<ResponseTool>
        {
            ResponseTool IJsonModel<ResponseTool>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using JsonDocument doc = JsonDocument.ParseValue(ref reader);
                return BingGroundingTool.Deserialize(doc.RootElement);
            }

            void IJsonModel<ResponseTool>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
                => ((IJsonModel<ResponseTool>)options.ProxiedModel!).Write(writer, options);

            ResponseTool IPersistableModel<ResponseTool>.Create(BinaryData data, ModelReaderWriterOptions options)
                => BingGroundingTool.Deserialize(JsonDocument.Parse(data.ToString()).RootElement);

            BinaryData IPersistableModel<ResponseTool>.Write(ModelReaderWriterOptions options)
                => ModelReaderWriter.Write((ResponseTool)options.ProxiedModel!, options);

            string IPersistableModel<ResponseTool>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }
    }
}

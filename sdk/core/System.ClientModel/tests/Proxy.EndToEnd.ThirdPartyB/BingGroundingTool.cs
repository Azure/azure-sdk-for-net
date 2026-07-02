// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Tests.Proxy.OpenAILike;
using System.Text.Json;

namespace System.ClientModel.Tests.Proxy.ThirdPartyB
{
    /// <summary>
    /// A second new ResponseTool subtype, defined in an independent third-party assembly and selected
    /// by the "bing_grounding" discriminator. Proves multiple libraries can extend the same base type.
    /// </summary>
    public sealed class BingGroundingTool : ResponseTool
    {
        public BingGroundingTool(string market) : base("bing_grounding")
        {
            Market = market;
        }

        public string Market { get; }

        protected override void WriteProperties(Utf8JsonWriter writer)
        {
            writer.WritePropertyName("market"u8);
            writer.WriteStringValue(Market);
        }

        internal static BingGroundingTool Deserialize(JsonElement element)
        {
            string market = element.TryGetProperty("market", out var m) ? m.GetString() ?? "" : "";
            return new BingGroundingTool(market);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using OpenAILike.Responses;

namespace FoundryLikeB
{
    /// <summary>
    /// A second <see cref="ResponseTool"/> subtype, defined in an independent library and selected by the
    /// "bing_grounding" discriminator. FoundryLikeB does not know about FoundryLikeA; both extend the same base type.
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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Proxy.OpenAILike;
using System.Text.Json;

namespace System.ClientModel.Tests.Proxy.ThirdPartyA
{
    /// <summary>
    /// A new ResponseTool subtype the base "OpenAI-like" library does not know about. It is defined
    /// in this third-party assembly and is selected purely by the "azure_search" discriminator.
    /// </summary>
    public sealed class AzureSearchTool : ResponseTool
    {
        public AzureSearchTool(string indexName) : base("azure_search")
        {
            IndexName = indexName;
        }

        public string IndexName { get; }

        protected override void WriteProperties(Utf8JsonWriter writer)
        {
            writer.WritePropertyName("index_name"u8);
            writer.WriteStringValue(IndexName);
        }

        internal static AzureSearchTool Deserialize(JsonElement element)
        {
            string indexName = element.TryGetProperty("index_name", out var i) ? i.GetString() ?? "" : "";
            return new AzureSearchTool(indexName);
        }
    }
}

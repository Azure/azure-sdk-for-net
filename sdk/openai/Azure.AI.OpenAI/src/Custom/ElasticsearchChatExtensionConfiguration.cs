// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.OpenAI
{
    public partial class ElasticsearchChatExtensionConfiguration : AzureChatExtensionConfiguration
    {
        /// <summary> The endpoint of Elasticsearch. </summary>
        public Uri Endpoint { get; set; }
        /// <summary> The index name of Elasticsearch. </summary>
        public string IndexName { get; set; }

        public ElasticsearchChatExtensionConfiguration()
        {
            Type = AzureChatExtensionType.Elasticsearch;
        }
    }
}

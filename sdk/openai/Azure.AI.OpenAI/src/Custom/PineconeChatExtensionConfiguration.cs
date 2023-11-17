// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI
{
    public partial class PineconeChatExtensionConfiguration : AzureChatExtensionConfiguration
    {
        /// <summary> The environment name of Pinecone. </summary>
        public string Environment { get; set; }
        /// <summary> The index name name of Pinecone. </summary>
        public string IndexName { get; set; }
        /// <summary> Customized field mapping behavior to use when interacting with the search index. </summary>
        public PineconeFieldMappingOptions FieldMappingOptions { get; set; }

        public PineconeChatExtensionConfiguration()
        {
            Type = AzureChatExtensionType.Pinecone;
        }
    }
}

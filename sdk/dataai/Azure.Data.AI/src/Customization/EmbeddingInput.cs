// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.AI
{
    [CodeGenType("EmbeddingsInputContent")]
    public partial class EmbeddingInput
    {
        /// <summary> What the item is: a document (`text`, the default), a search query (`query`) or a document image (`image`). </summary>
        [CodeGenMember("Kind")]
        public EmbeddingContentKind? ContentKind { get; set; }
    }
}

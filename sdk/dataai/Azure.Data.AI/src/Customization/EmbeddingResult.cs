// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.AI
{
    public partial class EmbeddingResult
    {
        [CodeGenMember("ModelVersion")]
        internal string ModelVersion { get; }
    }
}

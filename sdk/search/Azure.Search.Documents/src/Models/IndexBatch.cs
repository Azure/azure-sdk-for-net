// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Models
{
    // The 2026-04-01 spec renames the internal REST batch model from
    // "IndexBatch" to "IndexDocumentsBatch". That name collides with the
    // public, hand-authored generic batch type <see cref="IndexDocumentsBatch{T}"/>
    // and its static factory. Keep the generated wire model internal and named
    // "IndexBatch" so the public API surface is unchanged.
    [CodeGenType("IndexDocumentsBatch")]
    internal partial class IndexBatch
    {
    }
}

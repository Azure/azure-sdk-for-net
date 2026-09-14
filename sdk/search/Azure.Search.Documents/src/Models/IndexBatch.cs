// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Models
{
    // The TypeSpec client.tsp renames the wire model `IndexBatch` to
    // `IndexDocumentsBatch` for all non-autorest languages, which collides with
    // the hand-written public `IndexDocumentsBatch` factory type. Keep the
    // generated wire model named `IndexBatch` (internal) as it was historically.
    [CodeGenType("IndexDocumentsBatch")]
    internal partial class IndexBatch
    {
    }
}

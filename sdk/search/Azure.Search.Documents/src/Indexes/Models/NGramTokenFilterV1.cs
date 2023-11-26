// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    // CUSTOM CODE NOTE: there are two models defined in spec: NGramTokenFilter and NGramTokenFilterV2
    // we use CodeGenModel to rename `NGramTokenFilterV2` to `NGramTokenFilter`, to avoid the generator write the original `NGramTokenFilter` into the same file, we rename `NGramTokenFilter` to `NGramTokenFilterV1` to avoid that
    [CodeGenModel("NGramTokenFilter")]
    internal partial class NGramTokenFilterV1
    {
    }
}

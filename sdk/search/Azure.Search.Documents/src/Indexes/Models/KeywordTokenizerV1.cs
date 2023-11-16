// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    // CUSTOM CODE NOTE: there are two models defined in spec: KeywordTokenizer and KeywordTokenizerV2
    // we use CodeGenModel to rename `KeywordTokenizerV2` to `KeywordTokenizer`, to avoid the generator write the original `KeywordTokenizer` into the same file, we rename `KeywordTokenizer` to `KeywordTokenizerV1` to avoid that
    [CodeGenModel("KeywordTokenizer")]
    internal partial class KeywordTokenizerV1
    {
    }
}

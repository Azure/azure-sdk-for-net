// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary> A skill that calls a language model via Azure AI Foundry's Chat Completions endpoint. </summary>
    public partial class ChatCompletionSkill : SearchIndexerSkill
    {
        // TODO: Remove this once codegen fixes bug that re-creates derived types
        internal new string OdataType { get; set; } = "#Microsoft.Skills.Custom.ChatCompletionSkill";
    }
}

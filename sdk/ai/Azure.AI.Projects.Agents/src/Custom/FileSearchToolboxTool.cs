// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Responses;

namespace Azure.AI.Projects.Agents;
public partial class FileSearchToolboxTool
{
    [CodeGenMember("RankingOptions")]
    internal InternalRankingOptions InternalRankingOptions { get; set; }

    internal FileSearchToolRankingOptions RankingOptions { get => InternalRankingOptions; set => InternalRankingOptions.AsInternalRankingOptions(value); }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Responses;

namespace Azure.AI.Projects.Agents;
public partial class FileSearchToolboxTool
{
    [CodeGenMember("RankingOptions")]
    internal InternalRankingOptions RankingOptionsInternal { get; set; }

    internal FileSearchToolRankingOptions RankingOptions { get => RankingOptionsInternal; set => InternalRankingOptions.AsInternalRankingOptions(value); }
}

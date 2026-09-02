// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.Agents;

[CodeGenType("RankingOptions")]
internal partial class InternalRankingOptions
{
    public static implicit operator FileSearchToolRankingOptions(InternalRankingOptions options)
    {
        return ModelReaderWriter.Read<FileSearchToolRankingOptions>(
            ModelReaderWriter.Write(
                options,
                ModelSerializationExtensions.WireOptions,
                AzureAIProjectsAgentsContext.Default),
            ModelSerializationExtensions.WireOptions,
            OpenAIContext.Default);
    }

    public static InternalRankingOptions AsInternalRankingOptions(FileSearchToolRankingOptions options)
    {
        return ModelReaderWriter.Read<InternalRankingOptions>(
            ModelReaderWriter.Write(
                options,
                ModelSerializationExtensions.WireOptions,
                AzureAIProjectsAgentsContext.Default),
            ModelSerializationExtensions.WireOptions,
            AzureAIProjectsAgentsContext.Default);
    }
}

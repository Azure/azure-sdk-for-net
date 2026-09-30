// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ComponentModel;
using Azure.AI.Extensions.OpenAI;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.Agents;

/// <summary> Provides conversions to the legacy agent tool models. </summary>
public static partial class ResponseToolExtensions
{
    /// <summary> Converts a shared response tool to its legacy agent tool representation. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static ProjectsAgentTool AsAgentTool(this ResponseTool responseTool)
    {
        Argument.AssertNotNull(responseTool, nameof(responseTool));
        return ModelReaderWriter.Read<ProjectsAgentTool>(
            ModelReaderWriter.Write(responseTool, ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default),
            ModelReaderWriterOptions.Json,
            AzureAIProjectsAgentsContext.Default);
    }
}

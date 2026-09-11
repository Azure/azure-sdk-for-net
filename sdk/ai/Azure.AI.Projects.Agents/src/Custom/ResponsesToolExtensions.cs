// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using Azure.AI.Extensions.OpenAI;
using OpenAI.Responses;

#pragma warning disable OPENAI001

namespace Azure.AI.Projects.Agents;

/// <summary>
/// Provides conversions between Azure AI Projects toolbox tools and OpenAI response tools.
/// </summary>
internal static class ResponsesToolExtensions
{
    /// <summary>
    /// Converts an OpenAI response tool to a toolbox tool by round-tripping through the wire format.
    /// </summary>
    /// <param name="tool">The source tool instance.</param>
    public static ToolboxTool ToToolboxTool(this ResponseTool tool)
    {
        Argument.AssertNotNull(tool, nameof(tool));

        BinaryData serializedResponseItem = ModelReaderWriter.Write(tool, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default);

        // The Projects context materializes the wire representation as the corresponding toolbox tool.
        return ModelReaderWriter.Read<ToolboxTool>(serializedResponseItem, ModelSerializationExtensions.WireOptions, AzureAIProjectsAgentsContext.Default);
    }
}

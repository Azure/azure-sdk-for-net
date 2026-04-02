// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using Azure.AI.Extensions.OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects;

[CodeGenType("Tool")]
public partial class ProjectTool
{
    public static ProjectTool AsProjectTool(ResponseTool tool)
    {
        // ProjectTool is an alias of ResponseTool in a Azure.AI.Projects namespace, so we can reinterpret ResponseTool.
        BinaryData serializedResponseItem = ModelReaderWriter.Write(tool, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default);
        return ModelReaderWriter.Read<ProjectTool>(serializedResponseItem, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default);
    }
}

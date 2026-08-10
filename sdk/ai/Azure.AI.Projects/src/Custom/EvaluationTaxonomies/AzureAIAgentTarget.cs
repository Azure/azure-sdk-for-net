// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using Azure.AI.Extensions.OpenAI;
using Azure.AI.Projects.Agents;
using OpenAI.Responses;

namespace Azure.AI.Projects.Evaluation;

[CodeGenType("AzureAIAgentTarget")]
public partial class AzureAIAgentTarget
{
    /// <summary> Gets the Tools. </summary>
    [CodeGenMember("Tools")]
    internal IList<InternalTool> InternalTools { get; }

    /// <summary> Gets the Tools. </summary>
    public IList<ResponseTool> Tools
    {
        get => [.. InternalTools.Select((x) => {
        BinaryData serializedTool = ModelReaderWriter.Write(x, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default);
        return ModelReaderWriter.Read<ResponseTool>(serializedTool, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default);
        })];
    }
}

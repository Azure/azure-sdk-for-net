// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.Extensions.OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.Evaluation;

#pragma warning disable AAIP002
[CodeGenType("AzureAIAgentTarget")]
[CodeGenSerialization(nameof(Tools), DeserializationValueHook = nameof(DeserializeToolsValue))]
public partial class AzureAIAgentTarget
{
    private static void DeserializeToolsValue(JsonProperty property, ref IList<ResponseTool> tools)
    {
        IList<ResponseTool> replacementTools = new ChangeTrackingList<ResponseTool>();

        if (property.Value.ValueKind == JsonValueKind.Array)
        {
            foreach (JsonElement element in property.Value.EnumerateArray())
            {
                // Read through the Azure context so Azure-specific tool discriminators materialize as their
                // concrete Azure.AI.Extensions.OpenAI subtypes instead of OpenAI's opaque unknown-tool fallback.
                ResponseTool tool = ModelReaderWriter.Read<ResponseTool>(
                    BinaryData.FromString(element.GetRawText()),
                    ModelReaderWriterOptions.Json,
                    AzureAIExtensionsOpenAIContext.Default);
                replacementTools.Add(tool);
            }
        }
        tools = replacementTools;
    }
}

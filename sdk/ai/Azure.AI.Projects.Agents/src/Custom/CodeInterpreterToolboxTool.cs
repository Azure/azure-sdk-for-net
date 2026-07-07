// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using OpenAI.Responses;

namespace Azure.AI.Projects.Agents;
public partial class CodeInterpreterToolboxTool
{
    [CodeGenMember("Container")]
    internal BinaryData InternalContainer { get; set; }

    /// <summary>
    /// Code container, used by the tool.
    /// </summary>
    public CodeInterpreterToolContainer Container { get => ModelReaderWriter.Read<CodeInterpreterToolContainer>(InternalContainer, ModelSerializationExtensions.WireOptions, AzureAIProjectsAgentsContext.Default); set => InternalContainer = ModelReaderWriter.Write(value, ModelSerializationExtensions.WireOptions, AzureAIProjectsAgentsContext.Default);}
}

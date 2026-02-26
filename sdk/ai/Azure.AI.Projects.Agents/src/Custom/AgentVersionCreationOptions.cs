// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.Projects.Agents;

namespace Azure.AI.Projects.Agents;

[CodeGenType("CreateAgentVersionRequest1")]
[CodeGenSuppress(nameof(AgentVersionCreationOptions), typeof(InternalAgentDefinition))]
[CodeGenSerialization(nameof(Definition), SerializationName = "definition", DeserializationValueHook = nameof(DeserializeDefinitionValue))]
public partial class AgentVersionCreationOptions
{
    /// <summary> A human-readable description of the agent. </summary>
    [CodeGenMember("Description")]
    public string Description { get; set; }

    [CodeGenMember("Definition")]
    public global::Azure.AI.Projects.Agents.AgentDefinition Definition { get; set; }

    private static void DeserializeDefinitionValue(JsonProperty property, ref global::Azure.AI.Projects.Agents.AgentDefinition definition)
    {
        definition = CustomSerializationHelpers.DeserializeProjectOpenAIType<AgentDefinition>(property.Value, ModelSerializationExtensions.WireOptions);
    }
}

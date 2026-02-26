// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.Projects.Agents;

namespace Azure.AI.Projects.Agents;

[CodeGenType("UpdateAgentRequest")]
[CodeGenSerialization(nameof(Definition), SerializationName = "definition", DeserializationValueHook = nameof(DeserializeDefinitionValue))]
internal partial class InternalUpdateAgentRequest
{
    [CodeGenMember("Definition")]
    public global::Azure.AI.Projects.Agents.AgentDefinition Definition { get; set; }
    private static void DeserializeDefinitionValue(JsonProperty property, ref global::Azure.AI.Projects.Agents.AgentDefinition definition)
        => CustomSerializationHelpers.DeserializeProjectOpenAIType<AgentDefinition>(property.Value, ModelSerializationExtensions.WireOptions);
}

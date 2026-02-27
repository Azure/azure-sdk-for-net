// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.Projects.OpenAI;

namespace Azure.AI.Projects;

[CodeGenType("CreateAgentRequest")]
[CodeGenSerialization(nameof(Definition), SerializationName = "definition", DeserializationValueHook = nameof(DeserializeDefinitionValue))]
internal partial class InternalCreateAgentRequest
{
    [CodeGenMember("Definition")]
    public global::Azure.AI.Projects.OpenAI.AgentDefinition Definition { get; set; }
    private static void DeserializeDefinitionValue(JsonProperty property, ref global::Azure.AI.Projects.OpenAI.AgentDefinition definition)
        => CustomSerializationHelpers.DeserializeProjectOpenAIType<AgentDefinition>(property.Value, ModelSerializationExtensions.WireOptions);
}

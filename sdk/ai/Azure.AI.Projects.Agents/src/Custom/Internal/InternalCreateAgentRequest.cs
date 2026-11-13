// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.Projects.Agents;

namespace Azure.AI.Projects.Agents;

[CodeGenType("CreateAgentRequest")]
[CodeGenSerialization(nameof(Definition), SerializationName = "definition", DeserializationValueHook = nameof(DeserializeDefinitionValue))]
internal partial class InternalCreateAgentRequest
{
    [CodeGenMember("Definition")]
    public global::Azure.AI.Projects.Agents.ProjectsAgentDefinition Definition { get; set; }
    private static void DeserializeDefinitionValue(JsonProperty property, ref global::Azure.AI.Projects.Agents.ProjectsAgentDefinition definition)
        => CustomSerializationHelpers.DeserializeProjectOpenAIType<ProjectsAgentDefinition>(property.Value, ModelSerializationExtensions.WireOptions);
}

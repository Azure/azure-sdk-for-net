// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.Projects.Agents;

[CodeGenType("CreateAgentVersionRequest")]
[CodeGenSerialization(nameof(Definition), SerializationName = "definition", DeserializationValueHook = nameof(DeserializeDefinitionValue))]
public partial class ProjectsAgentVersionCreationOptions
{
    /// <summary> A human-readable description of the agent. </summary>
    [CodeGenMember("Description")]
    public string Description { get; set; }

    [CodeGenMember("Definition")]
    public ProjectsAgentDefinition Definition { get; set; }

    private static void DeserializeDefinitionValue(JsonProperty property, ref ProjectsAgentDefinition definition)
    {
        definition = CustomSerializationHelpers.DeserializeProjectOpenAIType<ProjectsAgentDefinition>(property.Value, ModelSerializationExtensions.WireOptions);
    }
}

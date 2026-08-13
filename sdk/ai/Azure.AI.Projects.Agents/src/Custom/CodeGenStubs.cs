// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

global using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Projects.Agents;

// Public type renames

[CodeGenType("AgentRecord")]
public partial class ProjectsAgentRecord
{
    [CodeGenMember("Object")]
    private string Object { get; } = "agent";
}

[CodeGenType("CreateAgentVersionFromManifestRequest1")] public partial class AgentManifestOptions { }

// Internal types
[CodeGenType("AgentVersionStatus ")] public partial struct AgentVersionStatus { }
[CodeGenType("FoundryFeaturesOptInKeys")] internal partial struct FoundryFeaturesOptInKeys { }
[CodeGenType("AgentObjectVersions")] public partial class AgentObjectVersions { }
// This class is being internalized because of the ADO item 5522213.
[CodeGenType("AzureFunctionDefinitionFunction")] internal partial class InternalAzureFunctionDefinitionFunction { }

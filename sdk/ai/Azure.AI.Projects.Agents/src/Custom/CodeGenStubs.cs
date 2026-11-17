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

[CodeGenType("SessionFileWriteResult")] public partial class SessionFileWriteResult { }

[CodeGenType("CreateAgentVersionFromManifestRequest1")] public partial class AgentManifestOptions { }

// Internal types
[CodeGenType("AgentVersionStatus")] public partial struct AgentVersionStatus { }
[CodeGenType("FoundryFeaturesOptInKeys")] internal partial struct FoundryFeaturesOptInKeys { }
[CodeGenType("AgentObjectVersions")] public partial class AgentObjectVersions { }
[CodeGenType("VoiceAgentSoundscapeSound")] public partial struct VoiceAgentSoundscapeSound { }
// TODO: remove this stub when the code will be again generated from feature/foundry-release.
// This class is obsolete and needs to be removed.
[CodeGenType("AzureFunctionDefinitionFunction")] internal partial class AzureFunctionDefinitionFunction { }

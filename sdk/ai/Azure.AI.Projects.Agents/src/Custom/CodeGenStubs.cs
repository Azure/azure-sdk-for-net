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

[CodeGenType("OpenApiFunctionDefinitionFunction")] public partial class OpenAPIFunctionEntry { }
[CodeGenType("WebSearchConfiguration")] public partial class ProjectWebSearchConfiguration { }
[CodeGenType("CreateAgentVersionFromManifestRequest1")] public partial class AgentManifestOptions { }

// Internal types
[CodeGenType("ApproximateLocation")] internal partial class InternalApproximateLocation { }
[CodeGenType("AgentVersionStatus ")] public partial struct AgentVersionStatus { }
[CodeGenType("FoundryFeaturesOptInKeys")] internal partial struct FoundryFeaturesOptInKeys { }
[CodeGenType("CodeInterpreterTool")] internal partial class InternalCodeInterpreterTool { }
[CodeGenType("CodeInterpreterToolAuto")] internal partial class InternalCodeInterpreterToolAuto { }
[CodeGenType("CodeInterpreterToolCallItemParam")] internal partial class InternalCodeInterpreterToolCallItemParam { }
[CodeGenType("CodeInterpreterToolCallItemResource")] internal partial class InternalCodeInterpreterToolCallItemResource { }
[CodeGenType("CodeInterpreterToolCallItemResourceStatus")] internal readonly partial struct CodeInterpreterToolCallItemResourceStatus { }
[CodeGenType("ComparisonFilter")] internal partial class InternalComparisonFilter { }
[CodeGenType("ComparisonFilterType")] internal readonly partial struct ComparisonFilterType { }
[CodeGenType("CompoundFilter")] internal partial class InternalCompoundFilter { }
[CodeGenType("CompoundFilterType")] internal readonly partial struct CompoundFilterType { }
[CodeGenType("ComputerUsePreviewTool")] internal partial class InternalComputerUsePreviewTool { }
[CodeGenType("ComputerUsePreviewToolEnvironment")] internal readonly partial struct ComputerUsePreviewToolEnvironment { }
[CodeGenType("FileSearchTool")] internal partial class InternalFileSearchTool { }
[CodeGenType("FunctionTool")] internal partial class InternalFunctionTool { }
[CodeGenType("ImageGenTool")] internal partial class InternalImageGenTool { }
[CodeGenType("ImageGenToolBackground")] internal readonly partial struct ImageGenToolBackground { }
[CodeGenType("ImageGenToolInputImageMask")] internal partial class InternalImageGenToolInputImageMask { }
[CodeGenType("ImageGenToolModeration")] internal readonly partial struct ImageGenToolModeration { }
[CodeGenType("ImageGenToolOutputFormat")] internal readonly partial struct ImageGenToolOutputFormat { }
[CodeGenType("ImageGenToolQuality")] internal readonly partial struct ImageGenToolQuality { }
[CodeGenType("ImageGenToolSize")] internal readonly partial struct ImageGenToolSize { }
[CodeGenType("ImplicitUserMessage")] internal partial class InternalImplicitUserMessage { }
[CodeGenType("Location")] internal partial class InternalLocation { }
[CodeGenType("LogProb")] internal partial class InternalLogProb { }
[CodeGenType("MCPListToolsTool")] public partial class VoiceMcpListToolsTool { }
[CodeGenType("MCPListToolsToolAnnotations")] public partial class VoiceMcpListToolsToolAnnotations { }
[CodeGenType("MCPListToolsToolInputSchema")] public partial class VoiceMcpListToolsToolInputSchema { }
[CodeGenType("InternalToolChoiceParam")] public abstract partial class VoiceAgentToolChoice { }
[CodeGenType("SpecificApplyPatchParam")] internal partial class InternalVoiceApplyPatchToolChoice { }
[CodeGenType("SpecificFunctionShellParam")] internal partial class InternalVoiceFunctionShellToolChoice { }
[CodeGenType("ToolChoiceAllowed")] internal partial class InternalVoiceAllowedToolChoice { }
[CodeGenType("ToolChoiceCodeInterpreter")] internal partial class InternalVoiceCodeInterpreterToolChoice { }
[CodeGenType("ToolChoiceComputer")] internal partial class InternalVoiceComputerToolChoice { }
[CodeGenType("ToolChoiceComputerUse")] internal partial class InternalVoiceComputerUseToolChoice { }
[CodeGenType("ToolChoiceComputerUsePreview")] internal partial class InternalVoiceComputerUsePreviewToolChoice { }
[CodeGenType("ToolChoiceCustom")] internal partial class InternalVoiceCustomToolChoice { }
[CodeGenType("ToolChoiceFileSearch")] internal partial class InternalVoiceFileSearchToolChoice { }
[CodeGenType("ToolChoiceImageGeneration")] internal partial class InternalVoiceImageGenerationToolChoice { }
[CodeGenType("ToolChoiceWebSearchPreview")] internal partial class InternalVoiceWebSearchPreviewToolChoice { }
[CodeGenType("ToolChoiceWebSearchPreview20250311")] internal partial class InternalVoiceWebSearchPreview20250311ToolChoice { }
[CodeGenType("MCPTool")] internal partial class InternalMCPTool { }
[CodeGenType("MCPToolAllowedTools1")] internal partial class InternalMCPToolAllowedTools1 { }
[CodeGenType("MCPToolRequireApproval1")] internal partial class InternalMCPToolRequireApproval1 { }
[CodeGenType("MCPToolRequireApprovalAlways")] internal partial class InternalMCPToolRequireApprovalAlways { }
[CodeGenType("MCPToolRequireApprovalNever")] internal partial class InternalMCPToolRequireApprovalNever { }
[CodeGenType("RankingOptionsRanker")] internal readonly partial struct RankingOptionsRanker { }
[CodeGenType("TopLogProb")] internal partial class InternalTopLogProb { }
[CodeGenType("VectorStoreFileAttributes")] internal partial class InternalVectorStoreFileAttributes { }
[CodeGenType("WebSearchPreviewToolSearchContextSize")] internal readonly partial struct WebSearchPreviewToolSearchContextSize { }
[CodeGenType("ComputerTool")] internal partial class InternalComputerTool { }
[CodeGenType("FunctionToolParam")] internal partial class InternalFunctionToolParam { }
[CodeGenType("NamespaceToolParam")] internal partial class InternalNamespaceToolParam { }
[CodeGenType("ToolSearchToolParam")] public partial class ToolSearchTool { }
[CodeGenType("ToolSearchExecutionType")] public partial struct ToolSearchExecutionKind { }

[System.Diagnostics.CodeAnalysis.Experimental("AAIP001")] public partial class VoiceAgentSemanticVadTurnDetection { }

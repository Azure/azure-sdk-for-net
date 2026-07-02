// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Extensions.OpenAI;

[CodeGenType("A2APreviewTool")] public partial class A2APreviewTool { }
//[CodeGenType("AISearchIndexResource")] public partial class AISearchIndexResource { }
[CodeGenType("AzureFunctionBinding")] public partial class AzureFunctionBinding { }
[CodeGenType("AzureFunctionDefinition")] public partial class AzureFunctionDefinition { }
[CodeGenType("AzureFunctionDefinitionFunction")] public partial class AzureFunctionDefinitionFunction {
    /// <summary> The JSON-encoded parameter schema for the Azure Function. </summary>
    // Customization: retain IDictionary<string, BinaryData> despite Record<unknown> basis
    [CodeGenMember("parameters")]
    public BinaryData Parameters { get; set; }
}
[CodeGenType("AzureFunctionStorageQueue")] public partial class AzureFunctionStorageQueue { }
[CodeGenType("AzureFunctionTool")] public partial class AzureFunctionTool { }
[CodeGenType("AzureAISearchTool")] public partial class AzureAISearchTool { }
[CodeGenType("AzureAISearchQueryType")] public readonly partial struct AzureAISearchQueryKind { }
[CodeGenType("BingCustomSearchConfiguration")] public partial class BingCustomSearchConfiguration { }
[CodeGenType("BingCustomSearchPreviewTool")] public partial class BingCustomSearchPreviewTool { }
[CodeGenType("BingGroundingSearchConfiguration")] public partial class BingGroundingSearchConfiguration { }
[CodeGenType("BingGroundingTool")] public partial class BingGroundingTool { }
[CodeGenType("BrowserAutomationPreviewTool")] public partial class BrowserAutomationPreviewTool { }
[CodeGenType("BrowserAutomationToolConnectionParameters")] public partial class BrowserAutomationToolConnectionParameters { }
//[CodeGenType("BrowserAutomationToolParameters")] public partial class BrowserAutomationToolParameters { }
[CodeGenType("CaptureStructuredOutputsTool")] public partial class CaptureStructuredOutputsTool { }
[CodeGenType("FabricDataAgentToolOptions")] public partial class FabricDataAgentToolOptions { }
[CodeGenType("FabricIQPreviewTool")] public partial class FabricIQPreviewTool { }
//[CodeGenType("FunctionShellToolParam")] public partial class FunctionShellToolParam { }
//[CodeGenType("FunctionShellToolParamEnvironment")] public abstract partial class FunctionShellToolParamEnvironment { }
//[CodeGenType("FunctionShellToolParamEnvironmentContainerReferenceParam")] public partial class FunctionShellToolParamEnvironmentContainerReferenceParam { }
//[CodeGenType("FunctionShellToolParamEnvironmentLocalEnvironmentParam")] public partial class FunctionShellToolParamEnvironmentLocalEnvironmentParam { }
//[CodeGenType("FunctionToolParam")] public partial class FunctionToolParam { }
//[CodeGenType("GrammarSyntax1")] public readonly partial struct GrammarSyntax { }
//[CodeGenType("InlineSkillParam")] public partial class InlineSkillParam { }
//[CodeGenType("InlineSkillSourceParam")] public partial class InlineSkillSourceParam { }
//[CodeGenType("LocalShellToolParam")] public partial class LocalShellToolParam { }
//[CodeGenType("MCPToolFilter")] public partial class MCPToolFilter { }
//[CodeGenType("MCPToolRequireApproval")] public partial class MCPToolRequireApproval { }
[CodeGenType("MemorySearchOptions")] public partial class MemorySearchOptions { }
[CodeGenType("MemorySearchPreviewTool")] public partial class MemorySearchPreviewTool { }
[CodeGenType("MicrosoftFabricPreviewTool")] public partial class MicrosoftFabricPreviewTool { }
//[CodeGenType("NamespaceToolParam")] public partial class NamespaceToolParam { }
//[CodeGenType("OpenApiAnonymousAuthDetails")] public partial class OpenApiAnonymousAuthDetails { }
//[CodeGenType("OpenApiAuthDetails")] public abstract partial class OpenApiAuthDetails { }
//[CodeGenType("OpenApiFunctionDefinition")] public partial class OpenApiFunctionDefinition { }
//[CodeGenType("OpenApiFunctionDefinitionFunction")] public partial class OpenApiFunctionDefinitionFunction { }
[CodeGenType("OpenApiManagedAuthDetails")] public partial class OpenApiManagedAuthDetails { }
[CodeGenType("OpenApiManagedSecurityScheme")] public partial class OpenApiManagedSecurityScheme { }
//[CodeGenType("OpenApiProjectConnectionAuthDetails")] public partial class OpenApiProjectConnectionAuthDetails { }
[CodeGenType("OpenApiProjectConnectionSecurityScheme")] public partial class OpenApiProjectConnectionSecurityScheme { }
//[CodeGenType("OpenApiTool")] public partial class OpenApiTool { }
[CodeGenType("ReminderPreviewTool")] public partial class ReminderPreviewTool { }
//[CodeGenType("SharepointGroundingToolParameters")] public partial class SharepointGroundingToolParameters { }
[CodeGenType("SharepointPreviewTool")] public partial class SharepointPreviewTool { }
//[CodeGenType("SkillReferenceParam")] public partial class SkillReferenceParam { }
[CodeGenType("StructuredOutputDefinition")] public partial class StructuredOutputDefinition { }
[CodeGenType("ToolProjectConnection")] public partial class ToolProjectConnection { }
//[CodeGenType("ToolSearchExecutionType")] public readonly partial struct ToolSearchExecutionType { }
//[CodeGenType("ToolSearchToolParam")] public partial class ToolSearchToolParam { }
//[CodeGenType("WebSearchApproximateLocation")] public partial class WebSearchApproximateLocation { }
[CodeGenType("WebSearchConfiguration")] public partial class WebSearchConfiguration { }

//[CodeGenType("WebSearchToolSearchContextSize")] public readonly partial struct WebSearchToolSearchContextSize { }
[CodeGenType("WorkIQPreviewTool")] public partial class WorkIQPreviewTool { }

/// <summary>
///
/// </summary>
public abstract partial class MemoryOutputItem { }

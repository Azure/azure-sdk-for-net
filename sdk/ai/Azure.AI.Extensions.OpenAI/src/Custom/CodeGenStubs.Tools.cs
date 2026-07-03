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
[CodeGenType("CaptureStructuredOutputsTool")] public partial class CaptureStructuredOutputsTool { }
[CodeGenType("FabricDataAgentToolOptions")] public partial class FabricDataAgentToolOptions { }
[CodeGenType("FabricIQPreviewTool")] public partial class FabricIQPreviewTool { }
[CodeGenType("MemorySearchOptions")] public partial class MemorySearchOptions { }
[CodeGenType("MemorySearchPreviewTool")] public partial class MemorySearchPreviewTool { }
[CodeGenType("MicrosoftFabricPreviewTool")] public partial class MicrosoftFabricPreviewTool { }
[CodeGenType("OpenApiManagedAuthDetails")] public partial class OpenApiManagedAuthDetails { }
[CodeGenType("OpenApiManagedSecurityScheme")] public partial class OpenApiManagedSecurityScheme { }
[CodeGenType("OpenApiProjectConnectionSecurityScheme")] public partial class OpenApiProjectConnectionSecurityScheme { }
[CodeGenType("SharepointPreviewTool")] public partial class SharepointPreviewTool { }
[CodeGenType("StructuredOutputDefinition")] public partial class StructuredOutputDefinition { }
[CodeGenType("ToolProjectConnection")] public partial class ToolProjectConnection { }
[CodeGenType("WebSearchConfiguration")] public partial class WebSearchConfiguration { }
[CodeGenType("WorkIQPreviewTool")] public partial class WorkIQPreviewTool { }

/// <summary>
///
/// </summary>
public abstract partial class MemoryOutputItem { }

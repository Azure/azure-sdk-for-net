// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Projects.OpenAI;

namespace OpenAI;

// Internal types

[CodeGenType("Annotation")] internal partial class InternalAnnotation { }
[CodeGenType("AnnotationFileCitation")] internal partial class InternalAnnotationFileCitation { }
[CodeGenType("AnnotationFilePath")] internal partial class InternalAnnotationFilePath { }
[CodeGenType("AnnotationUrlCitation")] internal partial class InternalAnnotationUrlCitation { }
[CodeGenType("ApproximateLocation")] internal partial class InternalApproximateLocation { }
[CodeGenType("CodeInterpreterOutput")] internal partial class InternalCodeInterpreterOutput { }
[CodeGenType("CodeInterpreterOutputImage")] internal partial class InternalCodeInterpreterOutputImage { }
[CodeGenType("CodeInterpreterOutputLogs")] internal partial class InternalCodeInterpreterOutputLogs { }
[CodeGenType("CodeInterpreterTool")] internal partial class InternalCodeInterpreterTool { }
[CodeGenType("CodeInterpreterToolAuto")] internal partial class InternalCodeInterpreterToolAuto { }
[CodeGenType("CodeInterpreterToolCallItemParam")] internal partial class InternalCodeInterpreterToolCallItemParam { }
[CodeGenType("CodeInterpreterToolCallItemResource")] internal partial class InternalCodeInterpreterToolCallItemResource { }
[CodeGenType("CodeInterpreterToolCallItemResourceStatus")] internal readonly partial struct CodeInterpreterToolCallItemResourceStatus { }
[CodeGenType("ComparisonFilter")] internal partial class InternalComparisonFilter { }
[CodeGenType("ComparisonFilterType")] internal readonly partial struct ComparisonFilterType { }
[CodeGenType("CompoundFilter")] internal partial class InternalCompoundFilter { }
[CodeGenType("CompoundFilterType")] internal readonly partial struct CompoundFilterType { }
[CodeGenType("ComputerAction")] internal partial class InternalComputerAction { }
[CodeGenType("ComputerActionClick")] internal partial class InternalComputerActionClick { }
[CodeGenType("ComputerActionClickButton")] internal readonly partial struct ComputerActionClickButton { }
[CodeGenType("ComputerActionDoubleClick")] internal partial class InternalComputerActionDoubleClick { }
[CodeGenType("ComputerActionDrag")] internal partial class InternalComputerActionDrag { }
[CodeGenType("ComputerActionKeyPress")] internal partial class InternalComputerActionKeyPress { }
[CodeGenType("ComputerActionMove")] internal partial class InternalComputerActionMove { }
[CodeGenType("ComputerActionScreenshot")] internal partial class InternalComputerActionScreenshot { }
[CodeGenType("ComputerActionScroll")] internal partial class InternalComputerActionScroll { }
[CodeGenType("ComputerActionTypeKeys")] internal partial class InternalComputerActionTypeKeys { }
[CodeGenType("ComputerActionWait")] internal partial class InternalComputerActionWait { }
[CodeGenType("ComputerToolCallItemParam")] internal partial class InternalComputerToolCallItemParam { }
[CodeGenType("ComputerToolCallItemResource")] internal partial class InternalComputerToolCallItemResource { }
[CodeGenType("ComputerToolCallItemResourceStatus")] internal readonly partial struct ComputerToolCallItemResourceStatus { }
[CodeGenType("ComputerToolCallOutputItemOutput")] internal partial class InternalComputerToolCallOutputItemOutput { }
[CodeGenType("ComputerToolCallOutputItemOutputComputerScreenshot")] internal partial class InternalComputerToolCallOutputItemOutputComputerScreenshot { }
[CodeGenType("ComputerToolCallOutputItemParam")] internal partial class InternalComputerToolCallOutputItemParam { }
[CodeGenType("ComputerToolCallOutputItemResource")] internal partial class InternalComputerToolCallOutputItemResource { }
[CodeGenType("ComputerToolCallOutputItemResourceStatus")] internal readonly partial struct ComputerToolCallOutputItemResourceStatus { }
[CodeGenType("ComputerToolCallSafetyCheck")] internal partial class InternalComputerToolCallSafetyCheck { }
[CodeGenType("ComputerUsePreviewTool")] internal partial class InternalComputerUsePreviewTool { }
[CodeGenType("ComputerUsePreviewToolEnvironment")] internal readonly partial struct ComputerUsePreviewToolEnvironment { }
[CodeGenType("Coordinate")] internal partial class InternalCoordinate { }
[CodeGenType("EasyInputMessage")] internal partial class InternalEasyInputMessage { }
[CodeGenType("FileSearchTool")] internal partial class InternalFileSearchTool { }
[CodeGenType("FileSearchToolCallItemParam")] internal partial class InternalFileSearchToolCallItemParam { }
[CodeGenType("FileSearchToolCallItemParamResult")] internal partial class InternalFileSearchToolCallItemParamResult { }
[CodeGenType("FileSearchToolCallItemResource")] internal partial class InternalFileSearchToolCallItemResource { }
[CodeGenType("FileSearchToolCallItemResourceStatus")] internal readonly partial struct FileSearchToolCallItemResourceStatus { }
[CodeGenType("FunctionTool")] internal partial class InternalFunctionTool { }
[CodeGenType("FunctionToolCallItemParam")] internal partial class InternalFunctionToolCallItemParam { }
[CodeGenType("FunctionToolCallItemResource")] internal partial class InternalFunctionToolCallItemResource { }
[CodeGenType("FunctionToolCallItemResourceStatus")] internal readonly partial struct FunctionToolCallItemResourceStatus { }
[CodeGenType("FunctionToolCallOutputItemParam")] internal partial class InternalFunctionToolCallOutputItemParam { }
[CodeGenType("FunctionToolCallOutputItemResource")] internal partial class InternalFunctionToolCallOutputItemResource { }
[CodeGenType("FunctionToolCallOutputItemResourceStatus")] internal readonly partial struct FunctionToolCallOutputItemResourceStatus { }
[CodeGenType("ImageGenTool")] internal partial class InternalImageGenTool { }
[CodeGenType("ImageGenToolBackground")] internal readonly partial struct ImageGenToolBackground { }
[CodeGenType("ImageGenToolCallItemParam")] internal partial class InternalImageGenToolCallItemParam { }
[CodeGenType("ImageGenToolCallItemResource")] internal partial class InternalImageGenToolCallItemResource { }
[CodeGenType("ImageGenToolCallItemResourceStatus")] internal readonly partial struct ImageGenToolCallItemResourceStatus { }
[CodeGenType("ImageGenToolInputImageMask")] internal partial class InternalImageGenToolInputImageMask { }
[CodeGenType("ImageGenToolModeration")] internal readonly partial struct ImageGenToolModeration { }
[CodeGenType("ImageGenToolOutputFormat")] internal readonly partial struct ImageGenToolOutputFormat { }
[CodeGenType("ImageGenToolQuality")] internal readonly partial struct ImageGenToolQuality { }
[CodeGenType("ImageGenToolSize")] internal readonly partial struct ImageGenToolSize { }
[CodeGenType("ImplicitUserMessage")] internal partial class InternalImplicitUserMessage { }
[CodeGenType("ItemContent")] internal partial class InternalItemContent { }
[CodeGenType("ItemContentInputAudio")] internal partial class InternalItemContentInputAudio { }
[CodeGenType("ItemContentInputAudioFormat")] internal readonly partial struct ItemContentInputAudioFormat { }
[CodeGenType("ItemContentInputFile")] internal partial class InternalItemContentInputFile { }
[CodeGenType("ItemContentInputImage")] internal partial class InternalItemContentInputImage { }
[CodeGenType("ItemContentInputImageDetail")] internal readonly partial struct ItemContentInputImageDetail { }
[CodeGenType("ItemContentInputText")] internal partial class InternalItemContentInputText { }
[CodeGenType("ItemContentOutputAudio")] internal partial class InternalItemContentOutputAudio { }
[CodeGenType("ItemContentOutputText")] internal partial class InternalItemContentOutputText { }
[CodeGenType("ItemContentRefusal")] internal partial class InternalItemContentRefusal { }
[CodeGenType("ItemReferenceItemParam")] internal partial class InternalItemReferenceItemParam { }
[CodeGenType("LocalShellExecAction")] internal partial class InternalLocalShellExecAction { }
[CodeGenType("LocalShellTool")] internal partial class InternalLocalShellTool { }
[CodeGenType("LocalShellToolCallItemParam")] internal partial class InternalLocalShellToolCallItemParam { }
[CodeGenType("LocalShellToolCallItemResource")] internal partial class InternalLocalShellToolCallItemResource { }
[CodeGenType("LocalShellToolCallItemResourceStatus")] internal readonly partial struct LocalShellToolCallItemResourceStatus { }
[CodeGenType("LocalShellToolCallOutputItemParam")] internal partial class InternalLocalShellToolCallOutputItemParam { }
[CodeGenType("LocalShellToolCallOutputItemResource")] internal partial class InternalLocalShellToolCallOutputItemResource { }
[CodeGenType("LocalShellToolCallOutputItemResourceStatus")] internal readonly partial struct LocalShellToolCallOutputItemResourceStatus { }
[CodeGenType("Location")] internal partial class InternalLocation { }
[CodeGenType("LogProb")] internal partial class InternalLogProb { }
[CodeGenType("MCPApprovalRequestItemParam")] internal partial class InternalMCPApprovalRequestItemParam { }
[CodeGenType("MCPApprovalRequestItemResource")] internal partial class InternalMCPApprovalRequestItemResource { }
[CodeGenType("MCPApprovalResponseItemParam")] internal partial class InternalMCPApprovalResponseItemParam { }
[CodeGenType("MCPApprovalResponseItemResource")] internal partial class InternalMCPApprovalResponseItemResource { }
[CodeGenType("MCPCallItemParam")] internal partial class InternalMCPCallItemParam { }
[CodeGenType("MCPCallItemResource")] internal partial class InternalMCPCallItemResource { }
[CodeGenType("MCPListToolsItemParam")] internal partial class InternalMCPListToolsItemParam { }
[CodeGenType("MCPListToolsItemResource")] internal partial class InternalMCPListToolsItemResource { }
[CodeGenType("MCPListToolsTool")] internal partial class InternalMCPListToolsTool { }
[CodeGenType("MCPTool")] internal partial class InternalMCPTool { }
[CodeGenType("MCPToolAllowedTools1")] internal partial class InternalMCPToolAllowedTools1 { }
[CodeGenType("MCPToolRequireApproval1")] internal partial class InternalMCPToolRequireApproval1 { }
[CodeGenType("MCPToolRequireApprovalAlways")] internal partial class InternalMCPToolRequireApprovalAlways { }
[CodeGenType("MCPToolRequireApprovalNever")] internal partial class InternalMCPToolRequireApprovalNever { }
[CodeGenType("RankingOptions")] internal partial class InternalRankingOptions { }
[CodeGenType("RankingOptionsRanker")] internal readonly partial struct RankingOptionsRanker { }
[CodeGenType("Reasoning")] internal partial class InternalReasoning { }
[CodeGenType("ReasoningEffort")] internal readonly partial struct ReasoningEffort { }
[CodeGenType("ReasoningGenerateSummary")] internal readonly partial struct ReasoningGenerateSummary { }
[CodeGenType("ReasoningItemParam")] internal partial class InternalReasoningItemParam { }
[CodeGenType("ReasoningItemResource")] internal partial class InternalReasoningItemResource { }
[CodeGenType("ReasoningItemSummaryPart")] internal partial class InternalReasoningItemSummaryPart { }
[CodeGenType("ReasoningItemSummaryTextPart")] internal partial class InternalReasoningItemSummaryTextPart { }
[CodeGenType("ReasoningSummary")] internal readonly partial struct ReasoningSummary { }
[CodeGenType("Response")] internal partial class InternalAgentResponse { }
[CodeGenType("ResponseError")] internal partial class InternalAgentResponseError { }
[CodeGenType("ResponseFormatJsonSchemaSchema")] internal partial class InternalResponseFormatJsonSchemaSchema { }
[CodeGenType("ResponsesAssistantMessageItemParam")] internal partial class InternalResponsesAssistantMessageItemParam { }
[CodeGenType("ResponsesAssistantMessageItemResource")] internal partial class InternalResponsesAssistantMessageItemResource { }
[CodeGenType("ResponsesDeveloperMessageItemParam")] internal partial class InternalResponsesDeveloperMessageItemParam { }
[CodeGenType("ResponsesDeveloperMessageItemResource")] internal partial class InternalResponsesDeveloperMessageItemResource { }
[CodeGenType("ResponsesMessageItemParam")] internal partial class InternalResponsesMessageItemParam { }
[CodeGenType("ResponsesMessageItemResource")] internal partial class InternalResponsesMessageItemResource { }
[CodeGenType("ResponsesMessageItemResourceStatus")] internal readonly partial struct ResponsesMessageItemResourceStatus { }
[CodeGenType("ResponsesMessageRole")] internal readonly partial struct ResponsesMessageRole { }
[CodeGenType("ResponsesSystemMessageItemParam")] internal partial class InternalResponsesSystemMessageItemParam { }
[CodeGenType("ResponsesSystemMessageItemResource")] internal partial class InternalResponsesSystemMessageItemResource { }
[CodeGenType("ResponseStatus")] internal readonly partial struct InternalAgentResponseStatus { }
[CodeGenType("ResponsesUserMessageItemParam")] internal partial class InternalResponsesUserMessageItemParam { }
[CodeGenType("ResponsesUserMessageItemResource")] internal partial class InternalResponsesUserMessageItemResource { }
[CodeGenType("ResponseTextFormatConfiguration")] internal partial class InternalResponseTextFormatConfiguration { }
[CodeGenType("ResponseTextFormatConfigurationJsonObject")] internal partial class InternalResponseTextFormatConfigurationJsonObject { }
[CodeGenType("ResponseTextFormatConfigurationJsonSchema")] internal partial class InternalResponseTextFormatConfigurationJsonSchema { }
[CodeGenType("ResponseTextFormatConfigurationText")] internal partial class InternalResponseTextFormatConfigurationText { }
[CodeGenType("ToolChoiceObject")] internal partial class InternalToolChoiceObject { }
[CodeGenType("ToolChoiceObjectCodeInterpreter")] internal partial class InternalToolChoiceObjectCodeInterpreter { }
[CodeGenType("ToolChoiceObjectComputer")] internal partial class InternalToolChoiceObjectComputer { }
[CodeGenType("ToolChoiceObjectFileSearch")] internal partial class InternalToolChoiceObjectFileSearch { }
[CodeGenType("ToolChoiceObjectFunction")] internal partial class InternalToolChoiceObjectFunction { }
[CodeGenType("ToolChoiceObjectImageGen")] internal partial class InternalToolChoiceObjectImageGen { }
[CodeGenType("ToolChoiceObjectMCP")] internal partial class InternalToolChoiceObjectMCP { }
[CodeGenType("ToolChoiceObjectWebSearch")] internal partial class InternalToolChoiceObjectWebSearch { }
[CodeGenType("ToolChoiceOptions")] internal readonly partial struct ToolChoiceOptions { }
[CodeGenType("TopLogProb")] internal partial class InternalTopLogProb { }
[CodeGenType("VectorStoreFileAttributes")] internal partial class InternalVectorStoreFileAttributes { }
[CodeGenType("WebSearchAction")] internal partial class InternalWebSearchAction { }
[CodeGenType("WebSearchActionFind")] internal partial class InternalWebSearchActionFind { }
[CodeGenType("WebSearchActionOpenPage")] internal partial class InternalWebSearchActionOpenPage { }
[CodeGenType("WebSearchActionSearch")] internal partial class InternalWebSearchActionSearch { }
[CodeGenType("WebSearchPreviewTool")] internal partial class InternalWebSearchPreviewTool { }
[CodeGenType("WebSearchPreviewToolSearchContextSize")] internal readonly partial struct WebSearchPreviewToolSearchContextSize { }
[CodeGenType("WebSearchToolCallItemParam")] internal partial class InternalWebSearchToolCallItemParam { }
[CodeGenType("WebSearchToolCallItemResource")] internal partial class InternalWebSearchToolCallItemResource { }
[CodeGenType("WebSearchToolCallItemResourceStatus")] internal readonly partial struct WebSearchToolCallItemResourceStatus { }

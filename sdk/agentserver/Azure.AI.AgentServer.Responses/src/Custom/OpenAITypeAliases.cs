// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// These models are no longer emitted locally: they are now owned by the OpenAI SDK
// and consumed through Azure.AI.Extensions.OpenAI. The aliases keep the historical
// AgentServer names bound to their OpenAI equivalents so that hand-written code and
// the generic output-item builders resolve against the externalized types.
global using Item = OpenAI.Responses.ResponseItem;
global using OutputItem = OpenAI.Responses.ResponseItem;
global using OutputItemApplyPatchToolCall = OpenAI.Responses.ApplyPatchCallItem;
global using OutputItemApplyPatchToolCallOutput = OpenAI.Responses.ApplyPatchCallOutputItem;
global using OutputItemCodeInterpreterToolCall = OpenAI.Responses.CodeInterpreterCallResponseItem;
global using OutputItemComputerToolCall = OpenAI.Responses.ComputerCallResponseItem;
global using OutputItemComputerToolCallOutput = OpenAI.Responses.ComputerCallOutputResponseItem;
global using OutputItemFileSearchToolCall = OpenAI.Responses.FileSearchCallResponseItem;
global using ItemFileSearchToolCall = OpenAI.Responses.FileSearchCallResponseItem;
global using OutputItemFunctionToolCall = OpenAI.Responses.FunctionCallResponseItem;
global using OutputItemImageGenToolCall = OpenAI.Responses.ImageGenerationCallResponseItem;
global using OutputItemMcpApprovalRequest = OpenAI.Responses.McpToolCallApprovalRequestItem;
global using OutputItemMcpApprovalResponseResource = OpenAI.Responses.McpToolCallApprovalResponseItem;
global using OutputItemMcpListTools = OpenAI.Responses.McpToolDefinitionListItem;
global using OutputItemMcpToolCall = OpenAI.Responses.McpToolCallItem;
global using OutputItemReasoningItem = OpenAI.Responses.ReasoningResponseItem;
global using OutputItemWebSearchToolCall = OpenAI.Responses.WebSearchCallResponseItem;
global using Error = OpenAI.Responses.ResponseError;
global using ResponseErrorInfo = OpenAI.Responses.ResponseError;
global using CreateResponse = OpenAI.Responses.CreateResponseOptions;
global using ResponseObject = OpenAI.Responses.ResponseResult;
global using ResponseStreamEvent = OpenAI.Responses.StreamingResponseUpdate;
global using ResponseStatus = OpenAI.Responses.ResponseStatus;
global using AgentReference = Azure.AI.Extensions.OpenAI.AgentReference;

// Item variants are now modelled as ItemField* discriminated members, and several
// *Param suffixes were dropped when the shell / apply-patch families were reshaped.
global using OutputItemFunctionShellCall = Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCall;
global using OutputItemFunctionShellCallOutput = Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCallOutput;
global using OutputItemLocalShellToolCall = Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCall;
global using OutputItemLocalShellToolCallOutput = Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCallOutput;
global using OutputItemCompactionBody = Azure.AI.AgentServer.Responses.Models.ItemFieldCompactionBody;
global using FunctionShellCallItemParam = Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCall;
global using FunctionShellCallOutputItemParam = Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCallOutput;
global using FunctionShellCallItemParamEnvironment = Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment;
global using FunctionShellCallOutputOutcomeParam = Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome;
global using ApplyPatchCallStatusParam = Azure.AI.AgentServer.Responses.Models.ApplyPatchCallStatus;
global using ApplyPatchCallOutputStatusParam = Azure.AI.AgentServer.Responses.Models.ApplyPatchCallOutputStatus;
global using ApplyPatchOperationParam = Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation;
global using ResponseIncompleteDetailsReason = Azure.AI.AgentServer.Responses.Models.CreateResponseResponseIncompleteDetailsReason;
global using ItemOutputMessageStatus = Azure.AI.AgentServer.Responses.Models.MessageStatus;
global using OutputMessageContent = Azure.AI.AgentServer.Responses.Models.MessageContent;

// Request-side Item* variants now resolve to the OpenAI response-item hierarchy.
global using ItemCodeInterpreterToolCall = OpenAI.Responses.CodeInterpreterCallResponseItem;
global using ItemComputerToolCall = OpenAI.Responses.ComputerCallResponseItem;
global using ItemFunctionToolCall = OpenAI.Responses.FunctionCallResponseItem;
global using ItemImageGenToolCall = OpenAI.Responses.ImageGenerationCallResponseItem;
global using ItemMcpApprovalRequest = OpenAI.Responses.McpToolCallApprovalRequestItem;
global using ItemMcpListTools = OpenAI.Responses.McpToolDefinitionListItem;
global using ItemMcpToolCall = OpenAI.Responses.McpToolCallItem;
global using ItemOutputMessage = OpenAI.Responses.MessageResponseItem;
global using ItemReasoningItem = OpenAI.Responses.ReasoningResponseItem;
global using ItemReferenceParam = OpenAI.Responses.ReferenceResponseItem;
global using ItemWebSearchToolCall = OpenAI.Responses.WebSearchCallResponseItem;
global using MCPApprovalResponse = OpenAI.Responses.McpToolCallApprovalResponseItem;
global using OutputItemFunctionToolCallOutput = OpenAI.Responses.FunctionCallOutputResponseItem;
global using FunctionCallOutputItemParam = OpenAI.Responses.FunctionCallOutputResponseItem;
global using ComputerCallOutputItemParam = OpenAI.Responses.ComputerCallOutputResponseItem;
global using ApplyPatchToolCallItemParam = OpenAI.Responses.ApplyPatchCallItem;
global using ApplyPatchToolCallOutputItemParam = OpenAI.Responses.ApplyPatchCallOutputItem;
global using Tool = OpenAI.Responses.ResponseTool;

// Item variants that remain local, emitted as ItemField* discriminated members.
global using ItemCustomToolCall = Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCall;
global using ItemCustomToolCallOutput = Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCallOutput;
global using ItemLocalShellToolCall = Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCall;
global using ItemLocalShellToolCallOutput = Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCallOutput;
global using CompactionSummaryItemParam = Azure.AI.AgentServer.Responses.Models.ItemFieldCompactionBody;
global using ApplyPatchCreateFileOperationParam = Azure.AI.AgentServer.Responses.Models.ApplyPatchCreateFileOperation;
global using ApplyPatchDeleteFileOperationParam = Azure.AI.AgentServer.Responses.Models.ApplyPatchDeleteFileOperation;
global using ApplyPatchUpdateFileOperationParam = Azure.AI.AgentServer.Responses.Models.ApplyPatchUpdateFileOperation;
global using FunctionShellCallOutputExitOutcomeParam = Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputExitOutcome;
global using FunctionShellCallItemParamEnvironmentContainerReferenceParam = Azure.AI.AgentServer.Responses.Models.ContainerReferenceResource;
global using OutputMessageContentOutputTextContent = Azure.AI.AgentServer.Responses.Models.MessageContentOutputTextContent;
global using OutputMessageContentRefusalContent = Azure.AI.AgentServer.Responses.Models.MessageContentRefusalContent;

// Azure-specific tools and their call/output items are owned by Azure.AI.Extensions.OpenAI.
global using A2AToolCall = Azure.AI.Extensions.OpenAI.A2AToolCall;
global using A2AToolCallOutput = Azure.AI.Extensions.OpenAI.A2AToolCallOutput;
global using AzureAISearchToolCall = Azure.AI.Extensions.OpenAI.AzureAISearchToolCall;
global using AzureAISearchToolCallOutput = Azure.AI.Extensions.OpenAI.AzureAISearchToolCallOutput;
global using AzureFunctionToolCall = Azure.AI.Extensions.OpenAI.AzureFunctionToolCall;
global using AzureFunctionToolCallOutput = Azure.AI.Extensions.OpenAI.AzureFunctionToolCallOutput;
global using BingCustomSearchToolCall = Azure.AI.Extensions.OpenAI.BingCustomSearchToolCall;
global using BingCustomSearchToolCallOutput = Azure.AI.Extensions.OpenAI.BingCustomSearchToolCallOutput;
global using BingGroundingToolCall = Azure.AI.Extensions.OpenAI.BingGroundingToolCall;
global using BingGroundingToolCallOutput = Azure.AI.Extensions.OpenAI.BingGroundingToolCallOutput;
global using BrowserAutomationToolCall = Azure.AI.Extensions.OpenAI.BrowserAutomationToolCall;
global using BrowserAutomationToolCallOutput = Azure.AI.Extensions.OpenAI.BrowserAutomationToolCallOutput;
global using FabricDataAgentToolCall = Azure.AI.Extensions.OpenAI.FabricDataAgentToolCall;
global using FabricDataAgentToolCallOutput = Azure.AI.Extensions.OpenAI.FabricDataAgentToolCallOutput;
global using OpenApiToolCall = Azure.AI.Extensions.OpenAI.OpenApiToolCall;
global using OpenApiToolCallOutput = Azure.AI.Extensions.OpenAI.OpenApiToolCallOutput;
global using SharepointGroundingToolCall = Azure.AI.Extensions.OpenAI.SharePointGroundingToolCall;
global using SharepointGroundingToolCallOutput = Azure.AI.Extensions.OpenAI.SharePointGroundingToolCallOutput;
global using MemorySearchToolCallItemResource = Azure.AI.Extensions.OpenAI.MemorySearchToolCall;
global using OAuthConsentRequestOutputItem = Azure.AI.Extensions.OpenAI.OAuthConsentRequestResponseItem;
global using WorkflowActionOutputItem = Azure.AI.Extensions.OpenAI.AgentWorkflowPreviewActionResponseItem;

// Stream event subtypes are replaced by their OpenAI counterparts via @@alternateType in
// client.tsp (OpenAI's StreamingResponseUpdate has a private protected constructor, so the
// emitter cannot produce derived types). These aliases keep the spec-facing names usable.
global using ResponseCodeInterpreterCallCodeDeltaEvent = OpenAI.Responses.StreamingResponseCodeInterpreterCallCodeDeltaUpdate;
global using ResponseCodeInterpreterCallCodeDoneEvent = OpenAI.Responses.StreamingResponseCodeInterpreterCallCodeDoneUpdate;
global using ResponseCodeInterpreterCallCompletedEvent = OpenAI.Responses.StreamingResponseCodeInterpreterCallCompletedUpdate;
global using ResponseCodeInterpreterCallInProgressEvent = OpenAI.Responses.StreamingResponseCodeInterpreterCallInProgressUpdate;
global using ResponseCodeInterpreterCallInterpretingEvent = OpenAI.Responses.StreamingResponseCodeInterpreterCallInterpretingUpdate;
global using ResponseCompletedEvent = OpenAI.Responses.StreamingResponseCompletedUpdate;
global using ResponseContentPartAddedEvent = OpenAI.Responses.StreamingResponseContentPartAddedUpdate;
global using ResponseContentPartDoneEvent = OpenAI.Responses.StreamingResponseContentPartDoneUpdate;
global using ResponseCreatedEvent = OpenAI.Responses.StreamingResponseCreatedUpdate;
global using ResponseCustomToolCallInputDeltaEvent = OpenAI.Responses.StreamingResponseUpdate;
global using ResponseCustomToolCallInputDoneEvent = OpenAI.Responses.StreamingResponseUpdate;
global using ResponseErrorEvent = OpenAI.Responses.StreamingResponseErrorUpdate;
global using ResponseFailedEvent = OpenAI.Responses.StreamingResponseFailedUpdate;
global using ResponseFileSearchCallCompletedEvent = OpenAI.Responses.StreamingResponseFileSearchCallCompletedUpdate;
global using ResponseFileSearchCallInProgressEvent = OpenAI.Responses.StreamingResponseFileSearchCallInProgressUpdate;
global using ResponseFileSearchCallSearchingEvent = OpenAI.Responses.StreamingResponseFileSearchCallSearchingUpdate;
global using ResponseFunctionCallArgumentsDeltaEvent = OpenAI.Responses.StreamingResponseFunctionCallArgumentsDeltaUpdate;
global using ResponseFunctionCallArgumentsDoneEvent = OpenAI.Responses.StreamingResponseFunctionCallArgumentsDoneUpdate;
global using ResponseImageGenCallCompletedEvent = OpenAI.Responses.StreamingResponseImageGenerationCallCompletedUpdate;
global using ResponseImageGenCallGeneratingEvent = OpenAI.Responses.StreamingResponseImageGenerationCallGeneratingUpdate;
global using ResponseImageGenCallInProgressEvent = OpenAI.Responses.StreamingResponseImageGenerationCallInProgressUpdate;
global using ResponseImageGenCallPartialImageEvent = OpenAI.Responses.StreamingResponseImageGenerationCallPartialImageUpdate;
global using ResponseInProgressEvent = OpenAI.Responses.StreamingResponseInProgressUpdate;
global using ResponseIncompleteEvent = OpenAI.Responses.StreamingResponseIncompleteUpdate;
global using ResponseMCPCallArgumentsDeltaEvent = OpenAI.Responses.StreamingResponseMcpCallArgumentsDeltaUpdate;
global using ResponseMCPCallArgumentsDoneEvent = OpenAI.Responses.StreamingResponseMcpCallArgumentsDoneUpdate;
global using ResponseMCPCallCompletedEvent = OpenAI.Responses.StreamingResponseMcpCallCompletedUpdate;
global using ResponseMCPCallFailedEvent = OpenAI.Responses.StreamingResponseMcpCallFailedUpdate;
global using ResponseMCPCallInProgressEvent = OpenAI.Responses.StreamingResponseMcpCallInProgressUpdate;
global using ResponseMCPListToolsCompletedEvent = OpenAI.Responses.StreamingResponseMcpListToolsCompletedUpdate;
global using ResponseMCPListToolsFailedEvent = OpenAI.Responses.StreamingResponseMcpListToolsFailedUpdate;
global using ResponseMCPListToolsInProgressEvent = OpenAI.Responses.StreamingResponseMcpListToolsInProgressUpdate;
global using ResponseOutputItemAddedEvent = OpenAI.Responses.StreamingResponseOutputItemAddedUpdate;
global using ResponseOutputItemDoneEvent = OpenAI.Responses.StreamingResponseOutputItemDoneUpdate;
global using ResponseOutputTextAnnotationAddedEvent = OpenAI.Responses.StreamingResponseOutputTextAnnotationAddedUpdate;
global using ResponseQueuedEvent = OpenAI.Responses.StreamingResponseQueuedUpdate;
global using ResponseReasoningSummaryPartAddedEvent = OpenAI.Responses.StreamingResponseReasoningSummaryPartAddedUpdate;
global using ResponseReasoningSummaryPartDoneEvent = OpenAI.Responses.StreamingResponseReasoningSummaryPartDoneUpdate;
global using ResponseReasoningSummaryTextDeltaEvent = OpenAI.Responses.StreamingResponseReasoningSummaryTextDeltaUpdate;
global using ResponseReasoningSummaryTextDoneEvent = OpenAI.Responses.StreamingResponseReasoningSummaryTextDoneUpdate;
global using ResponseRefusalDeltaEvent = OpenAI.Responses.StreamingResponseRefusalDeltaUpdate;
global using ResponseRefusalDoneEvent = OpenAI.Responses.StreamingResponseRefusalDoneUpdate;
global using ResponseTextDeltaEvent = OpenAI.Responses.StreamingResponseOutputTextDeltaUpdate;
global using ResponseTextDoneEvent = OpenAI.Responses.StreamingResponseOutputTextDoneUpdate;
global using ResponseWebSearchCallCompletedEvent = OpenAI.Responses.StreamingResponseWebSearchCallCompletedUpdate;
global using ResponseWebSearchCallInProgressEvent = OpenAI.Responses.StreamingResponseWebSearchCallInProgressUpdate;
global using ResponseWebSearchCallSearchingEvent = OpenAI.Responses.StreamingResponseWebSearchCallSearchingUpdate;

// Message items: client.tsp maps OpenAI.ItemMessage / OpenAI.OutputMessage / OpenAI.Message
// to OpenAI.Responses.MessageResponseItem, so no Azure message item type is emitted.
global using ItemMessage = OpenAI.Responses.MessageResponseItem;
global using OutputItemMessage = OpenAI.Responses.MessageResponseItem;
global using Message = OpenAI.Responses.MessageResponseItem;

// Mapped to their OpenAI counterparts in client.tsp, so no Azure type is emitted.
global using Annotation = OpenAI.Responses.ResponseMessageAnnotation;
global using ComputerAction = OpenAI.Responses.ComputerCallAction;
global using ResponseUsage = OpenAI.Responses.ResponseTokenUsage;
global using ResponseUsageInputTokensDetails = OpenAI.Responses.ResponseInputTokenUsageDetails;
global using ResponseUsageOutputTokensDetails = OpenAI.Responses.ResponseOutputTokenUsageDetails;

// Types the spec now maps onto their OpenAI counterparts via @@alternateType.
global using ConversationReference = OpenAI.Responses.ResponseConversationOptions;
global using ResponseStreamEventType = OpenAI.Responses.StreamingResponseUpdateKind;
global using OutputContentOutputTextContent = OpenAI.Responses.ResponseContentPart;
global using OutputContentRefusalContent = OpenAI.Responses.ResponseContentPart;
global using ResponseLogProb = OpenAI.Responses.ResponseTokenLogProbabilityDetails;
global using ResponseReasoningSummaryPartAddedEventPart = OpenAI.Responses.ReasoningSummaryPart;
global using ResponseReasoningSummaryPartDoneEventPart = OpenAI.Responses.ReasoningSummaryPart;
global using ResponseErrorCode = OpenAI.Responses.ResponseErrorCode;

// Item status enums. The spec declares these as inline unions, so the emitter synthesizes
// Azure duplicates that have no addressable TypeSpec name to map away. Aliasing them here
// binds every consumer outside the Models namespace to the OpenAI enum that the OpenAI item
// properties actually expect; the generated Models code keeps resolving its own copies,
// because an in-namespace declaration wins over a using alias.
global using CodeInterpreterCallStatus = OpenAI.Responses.CodeInterpreterCallStatus;
global using FileSearchCallStatus = OpenAI.Responses.FileSearchCallStatus;
global using ReasoningStatus = OpenAI.Responses.ReasoningStatus;
global using WebSearchCallStatus = OpenAI.Responses.WebSearchCallStatus;
global using MessageStatus = OpenAI.Responses.MessageStatus;
global using FunctionCallStatus = OpenAI.Responses.FunctionCallStatus;
global using ImageGenerationCallStatus = OpenAI.Responses.ImageGenerationCallStatus;
global using McpToolDefinition = OpenAI.Responses.McpToolDefinition;
global using ReasoningSummaryPart = OpenAI.Responses.ReasoningSummaryPart;
global using ReasoningSummaryTextPart = OpenAI.Responses.ReasoningSummaryTextPart;
global using ResponseContentPart = OpenAI.Responses.ResponseContentPart;
global using ResponseItem = OpenAI.Responses.ResponseItem;
global using MessageResponseItem = OpenAI.Responses.MessageResponseItem;
global using MessageRole = OpenAI.Responses.MessageRole;
global using ComputerCallOutput = OpenAI.Responses.ComputerCallOutput;
global using ComputerCallSafetyCheck = OpenAI.Responses.ComputerCallSafetyCheck;
global using ComputerCallStatus = OpenAI.Responses.ComputerCallStatus;
global using ApplyPatchOperation = OpenAI.Responses.ApplyPatchOperation;
global using ApplyPatchCallStatus = OpenAI.Responses.ApplyPatchCallStatus;
global using ApplyPatchCallOutputStatus = OpenAI.Responses.ApplyPatchCallOutputStatus;
global using ResponseToolChoice = OpenAI.Responses.ResponseToolChoice;

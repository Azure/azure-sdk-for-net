import "./main.tsp";

using Azure.ClientGenerator.Core;
using Azure.Core.Experimental;

// Map all OpenAI base types into our SDK namespace
@clientNamespace("Azure.AI.AgentServer.Responses.Models")
namespace OpenAI {
  // The responses view does not export ItemResourceType (only the full src does).
  // Bridge the gap with an alias so the Azure augmentations can reference it.
  alias ItemResourceType = OutputItemType;
}

// Map Azure.AI.Projects augmentation types into our SDK namespace
#suppress "@azure-tools/typespec-azure-core/experimental-feature" ""
@clientNamespace("Azure.AI.AgentServer.Responses.Models")
namespace Azure.AI.Projects {
  // Propagate "sequence_number" to base of stream events
  @@copyProperties(OpenAI.ResponseStreamEvent,
    {
      sequence_number: integer,
    }
  );

  // Remove created_by from specific models to avoid BinaryData/string mismatch
  // with the base OutputItem.CreatedBy (BinaryData) type
  @@withoutOmittedProperties(OpenAI.OutputItemFunctionShellCallOutput, "created_by");
  @@withoutOmittedProperties(OpenAI.OutputItemFunctionShellCall, "created_by");
  @@withoutOmittedProperties(OpenAI.OutputItemCompactionBody, "created_by");
  @@withoutOmittedProperties(OpenAI.OutputItemApplyPatchToolCallOutput, "created_by");
  @@withoutOmittedProperties(OpenAI.OutputItemApplyPatchToolCall, "created_by");

  // Remove "object" from DeleteResponseResult to work around codegen bug
  // (TypeSpec emitter generates `= "response"` string default for ResponseObjectType enum)
  @@withoutOmittedProperties(Azure.AI.Projects.DeleteResponseResult, "object");

  // ============================================================================
  // Public constructors: mark models as input+output so the C# emitter generates
  // public compact constructors. Consumers need these to construct events in their
  // IResponseHandler implementations.
  // ============================================================================

  // --- ResponseStreamEvent subtypes (53 concrete types) ---
  @@usage(OpenAI.ResponseAudioDeltaEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseAudioDoneEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseAudioTranscriptDeltaEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseAudioTranscriptDoneEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseCodeInterpreterCallCodeDeltaEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseCodeInterpreterCallCodeDoneEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseCodeInterpreterCallCompletedEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseCodeInterpreterCallInProgressEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseCodeInterpreterCallInterpretingEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseCompletedEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseContentPartAddedEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseContentPartDoneEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseCreatedEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseCustomToolCallInputDeltaEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseCustomToolCallInputDoneEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseErrorEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseFailedEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseFileSearchCallCompletedEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseFileSearchCallInProgressEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseFileSearchCallSearchingEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseFunctionCallArgumentsDeltaEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseFunctionCallArgumentsDoneEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseImageGenCallCompletedEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseImageGenCallGeneratingEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseImageGenCallInProgressEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseImageGenCallPartialImageEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseIncompleteEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseInProgressEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseMCPCallArgumentsDeltaEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseMCPCallArgumentsDoneEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseMCPCallCompletedEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseMCPCallFailedEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseMCPCallInProgressEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseMCPListToolsCompletedEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseMCPListToolsFailedEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseMCPListToolsInProgressEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseOutputItemAddedEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseOutputItemDoneEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseOutputTextAnnotationAddedEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseQueuedEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseReasoningSummaryPartAddedEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseReasoningSummaryPartDoneEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseReasoningSummaryTextDeltaEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseReasoningSummaryTextDoneEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseReasoningTextDeltaEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseReasoningTextDoneEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseRefusalDeltaEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseRefusalDoneEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseTextDeltaEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseTextDoneEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseWebSearchCallCompletedEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseWebSearchCallInProgressEvent, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseWebSearchCallSearchingEvent, Usage.input | Usage.output);

  // --- Response, ResponseError, Error, and CreateResponse ---
  @@usage(OpenAI.Response, Usage.input | Usage.output);
  @@usage(OpenAI.ResponseError, Usage.input | Usage.output);
  @@usage(OpenAI.Error, Usage.input | Usage.output);
  @@usage(OpenAI.CreateResponse, Usage.input | Usage.output);

  // --- API envelope types (server needs to construct these) ---
  @@usage(Azure.AI.Projects.ApiErrorResponse, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.DeleteResponseResult, Usage.input | Usage.output);

  // --- OpenAI OutputItem subtypes (24 concrete types) ---
  @@usage(OpenAI.OutputItemApplyPatchToolCall, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemApplyPatchToolCallOutput, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemCodeInterpreterToolCall, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemCompactionBody, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemComputerToolCall, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemComputerToolCallOutputResource, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemCustomToolCall, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemCustomToolCallOutput, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemFileSearchToolCall, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemFunctionShellCall, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemFunctionShellCallOutput, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemFunctionToolCall, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemImageGenToolCall, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemLocalShellToolCall, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemLocalShellToolCallOutput, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemMcpApprovalRequest, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemMcpApprovalResponseResource, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemMcpListTools, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemMcpToolCall, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemMessage, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemOutputMessage, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemReasoningItem, Usage.input | Usage.output);
  @@usage(OpenAI.OutputItemWebSearchToolCall, Usage.input | Usage.output);
  @@usage(OpenAI.FunctionToolCallOutputResource, Usage.input | Usage.output);

  // --- OutputContent subtypes (3 concrete types) ---
  @@usage(OpenAI.OutputContentOutputTextContent, Usage.input | Usage.output);
  @@usage(OpenAI.OutputContentReasoningTextContent, Usage.input | Usage.output);
  @@usage(OpenAI.OutputContentRefusalContent, Usage.input | Usage.output);

  // --- OutputMessageContent subtypes (2 concrete types) ---
  @@usage(OpenAI.OutputMessageContentOutputTextContent, Usage.input | Usage.output);
  @@usage(OpenAI.OutputMessageContentRefusalContent, Usage.input | Usage.output);

  // --- Azure.AI.Projects OutputItem subtypes (22 concrete types) ---
  @@usage(Azure.AI.Projects.A2AToolCall, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.A2AToolCallOutput, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.AzureAISearchToolCall, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.AzureAISearchToolCallOutput, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.AzureFunctionToolCall, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.AzureFunctionToolCallOutput, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.BingCustomSearchToolCall, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.BingCustomSearchToolCallOutput, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.BingGroundingToolCall, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.BingGroundingToolCallOutput, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.BrowserAutomationToolCall, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.BrowserAutomationToolCallOutput, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.FabricDataAgentToolCall, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.FabricDataAgentToolCallOutput, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.MemorySearchToolCallItemResource, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.OAuthConsentRequestOutputItem, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.OpenApiToolCall, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.OpenApiToolCallOutput, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.SharepointGroundingToolCall, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.SharepointGroundingToolCallOutput, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.StructuredOutputsOutputItem, Usage.input | Usage.output);
  @@usage(Azure.AI.Projects.WorkflowActionOutputItem, Usage.input | Usage.output);
}

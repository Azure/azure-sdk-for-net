// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Extensions.OpenAI
{
    /// <summary>
    ///
    /// </summary>
    public static class ResponseItemKindExtensions
    {
        extension(global::OpenAI.Responses.ResponseItemKind)
        {
            /// <summary> Gets the StructuredOutputs. </summary>
            public static global::OpenAI.Responses.ResponseItemKind StructuredOutputs => new("structured_outputs");

            /// <summary> Gets the OAuthConsentRequest. </summary>
            public static global::OpenAI.Responses.ResponseItemKind OAuthConsentRequest => new("oauth_consent_request");

            /// <summary> Gets the MemorySearchCall. </summary>
            public static global::OpenAI.Responses.ResponseItemKind MemorySearchCall => new("memory_search_call");

            /// <summary> Gets the MemoryCommandPreviewCall. </summary>
            public static global::OpenAI.Responses.ResponseItemKind MemoryCommandPreviewCall => new("memory_command_preview_call");

            /// <summary> Gets the MemoryCommandPreviewCallOutput. </summary>
            public static global::OpenAI.Responses.ResponseItemKind MemoryCommandPreviewCallOutput => new("memory_command_preview_call_output");

            /// <summary> Gets the WorkflowAction. </summary>
            public static global::OpenAI.Responses.ResponseItemKind WorkflowAction => new("workflow_action");

            /// <summary> Gets the A2APreviewCall. </summary>
            public static global::OpenAI.Responses.ResponseItemKind A2APreviewCall => new("a2a_preview_call");

            /// <summary> Gets the A2APreviewCallOutput. </summary>
            public static global::OpenAI.Responses.ResponseItemKind A2APreviewCallOutput => new("a2a_preview_call_output");

            /// <summary> Gets the BingGroundingCall. </summary>
            public static global::OpenAI.Responses.ResponseItemKind BingGroundingCall => new("bing_grounding_call");

            /// <summary> Gets the BingGroundingCallOutput. </summary>
            public static global::OpenAI.Responses.ResponseItemKind BingGroundingCallOutput => new("bing_grounding_call_output");

            /// <summary> Gets the SharepointGroundingPreviewCall. </summary>
            public static global::OpenAI.Responses.ResponseItemKind SharepointGroundingPreviewCall => new("sharepoint_grounding_preview_call");

            /// <summary> Gets the SharepointGroundingPreviewCallOutput. </summary>
            public static global::OpenAI.Responses.ResponseItemKind SharepointGroundingPreviewCallOutput => new("sharepoint_grounding_preview_call_output");

            /// <summary> Gets the AzureAISearchCall. </summary>
            public static global::OpenAI.Responses.ResponseItemKind AzureAISearchCall => new("azure_ai_search_call");

            /// <summary> Gets the AzureAISearchCallOutput. </summary>
            public static global::OpenAI.Responses.ResponseItemKind AzureAISearchCallOutput => new("azure_ai_search_call_output");

            /// <summary> Gets the BingCustomSearchPreviewCall. </summary>
            public static global::OpenAI.Responses.ResponseItemKind BingCustomSearchPreviewCall => new("bing_custom_search_preview_call");

            /// <summary> Gets the BingCustomSearchPreviewCallOutput. </summary>
            public static global::OpenAI.Responses.ResponseItemKind BingCustomSearchPreviewCallOutput => new("bing_custom_search_preview_call_output");

            /// <summary> Gets the OpenApiCall. </summary>
            public static global::OpenAI.Responses.ResponseItemKind OpenApiCall => new("openapi_call");

            /// <summary> Gets the OpenApiCallOutput. </summary>
            public static global::OpenAI.Responses.ResponseItemKind OpenApiCallOutput => new("openapi_call_output");

            /// <summary> Gets the BrowserAutomationPreviewCall. </summary>
            public static global::OpenAI.Responses.ResponseItemKind BrowserAutomationPreviewCall => new("browser_automation_preview_call");

            /// <summary> Gets the BrowserAutomationPreviewCallOutput. </summary>
            public static global::OpenAI.Responses.ResponseItemKind BrowserAutomationPreviewCallOutput => new("browser_automation_preview_call_output");

            /// <summary> Gets the FabricDataAgentPreviewCall. </summary>
            public static global::OpenAI.Responses.ResponseItemKind FabricDataAgentPreviewCall => new("fabric_dataagent_preview_call");

            /// <summary> Gets the FabricDataAgentPreviewCallOutput. </summary>
            public static global::OpenAI.Responses.ResponseItemKind FabricDataAgentPreviewCallOutput => new("fabric_dataagent_preview_call_output");

            /// <summary> Gets the AzureFunctionCall. </summary>
            public static global::OpenAI.Responses.ResponseItemKind AzureFunctionCall => new("azure_function_call");

            /// <summary> Gets the AzureFunctionCallOutput. </summary>
            public static global::OpenAI.Responses.ResponseItemKind AzureFunctionCallOutput => new("azure_function_call_output");
        }
    }
}

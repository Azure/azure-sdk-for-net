using System;
using System.Collections.Generic;
using System.Text;

using OAI = OpenAI.Responses;

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

            /// <summary> Gets the OauthConsentRequest. </summary>
            public static global::OpenAI.Responses.ResponseItemKind OauthConsentRequest => new("oauth_consent_request");

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

            /// <summary> Gets the AzureAiSearchCall. </summary>
            public static global::OpenAI.Responses.ResponseItemKind AzureAiSearchCall => new("azure_ai_search_call");

            /// <summary> Gets the AzureAiSearchCallOutput. </summary>
            public static global::OpenAI.Responses.ResponseItemKind AzureAiSearchCallOutput => new("azure_ai_search_call_output");

            /// <summary> Gets the BingCustomSearchPreviewCall. </summary>
            public static global::OpenAI.Responses.ResponseItemKind BingCustomSearchPreviewCall => new("bing_custom_search_preview_call");

            /// <summary> Gets the BingCustomSearchPreviewCallOutput. </summary>
            public static global::OpenAI.Responses.ResponseItemKind BingCustomSearchPreviewCallOutput => new("bing_custom_search_preview_call_output");

            /// <summary> Gets the OpenapiCall. </summary>
            public static global::OpenAI.Responses.ResponseItemKind OpenapiCall => new("openapi_call");

            /// <summary> Gets the OpenapiCallOutput. </summary>
            public static global::OpenAI.Responses.ResponseItemKind OpenapiCallOutput => new("openapi_call_output");

            /// <summary> Gets the BrowserAutomationPreviewCall. </summary>
            public static global::OpenAI.Responses.ResponseItemKind BrowserAutomationPreviewCall => new("browser_automation_preview_call");

            /// <summary> Gets the BrowserAutomationPreviewCallOutput. </summary>
            public static global::OpenAI.Responses.ResponseItemKind BrowserAutomationPreviewCallOutput => new("browser_automation_preview_call_output");

            /// <summary> Gets the FabricDataagentPreviewCall. </summary>
            public static global::OpenAI.Responses.ResponseItemKind FabricDataagentPreviewCall => new("fabric_dataagent_preview_call");

            /// <summary> Gets the FabricDataagentPreviewCallOutput. </summary>
            public static global::OpenAI.Responses.ResponseItemKind FabricDataagentPreviewCallOutput => new("fabric_dataagent_preview_call_output");

            /// <summary> Gets the AzureFunctionCall. </summary>
            public static global::OpenAI.Responses.ResponseItemKind AzureFunctionCall => new("azure_function_call");

            /// <summary> Gets the AzureFunctionCallOutput. </summary>
            public static global::OpenAI.Responses.ResponseItemKind AzureFunctionCallOutput => new("azure_function_call_output");
        }
    }
}

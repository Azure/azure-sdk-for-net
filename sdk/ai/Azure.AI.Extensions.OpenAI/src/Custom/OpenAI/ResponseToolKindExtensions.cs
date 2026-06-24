// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI
{
    /// <summary>
    ///
    /// </summary>
    public static class ResponseToolKindExtensions
    {
        extension(ResponseToolKind)
        {
            /// <summary>
            ///
            /// </summary>
            public static ResponseToolKind A2APreview => new ResponseToolKind("a2a_preview");
            /// <summary>
            ///
            /// </summary>
            public static ResponseToolKind BingCustomSearchPreview => new ResponseToolKind("bing_custom_search_preview");
            /// <summary>
            ///
            /// </summary>
            public static ResponseToolKind BrowserAutomationPreview => new ResponseToolKind("browser_automation_preview");
            /// <summary>
            ///
            /// </summary>
            public static ResponseToolKind FabricDataAgentPreview => new ResponseToolKind("fabric_dataagent_preview");
            /// <summary>
            ///
            /// </summary>
            public static ResponseToolKind SharePointGroundingPreview => new ResponseToolKind("sharepoint_grounding_preview");
            /// <summary>
            ///
            /// </summary>
            public static ResponseToolKind MemorySearchPreview => new ResponseToolKind("memory_search_preview");
            /// <summary>
            ///
            /// </summary>
            public static ResponseToolKind WorkIQPreview => new ResponseToolKind("work_iq_preview");
            /// <summary>
            ///
            /// </summary>
            public static ResponseToolKind FabricIQPreview => new ResponseToolKind("fabric_iq_preview");
            /// <summary>
            ///
            /// </summary>
            public static ResponseToolKind ToolboxSearchPreview => new ResponseToolKind("toolbox_search_preview");
            /// <summary>
            ///
            /// </summary>
            public static ResponseToolKind AzureAISearch => new ResponseToolKind("azure_ai_search");
            /// <summary>
            ///
            /// </summary>
            public static ResponseToolKind AzureFunction => new ResponseToolKind("azure_function");
            /// <summary>
            ///
            /// </summary>
            public static ResponseToolKind BingGrounding => new ResponseToolKind("bing_grounding");
            /// <summary>
            ///
            /// </summary>
            public static ResponseToolKind CaptureStructuredOutputs => new ResponseToolKind("capture_structured_outputs");
            /// <summary>
            ///
            /// </summary>
            public static ResponseToolKind OpenAPI => new ResponseToolKind("openapi");
            /// <summary>
            ///
            /// </summary>
            public static ResponseToolKind Custom => new ResponseToolKind("custom");
            /// <summary>
            ///
            /// </summary>
            public static ResponseToolKind Namespace => new ResponseToolKind("namespace");
        }
    }
}

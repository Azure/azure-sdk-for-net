// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Partial class for AnalyzeResult to customize LRO response handling.
    /// </summary>
    // SDK-FIX: Suppress FromLroResponse to fix service response format inconsistency (service sometimes wraps AnalyzeResult in "result" property, sometimes returns it directly)
    [CodeGenSuppress("FromLroResponse", typeof(Response))]
    public partial class AnalyzeResult
    {
        /// <summary>
        /// Converts a response to an AnalyzeResult using the LRO result path.
        /// </summary>
        /// <remarks>
        /// SDK-FIX: Customized to handle service response format inconsistency. The service sometimes wraps AnalyzeResult
        /// in a "result" property, and sometimes returns it directly. This workaround uses TryGetProperty to handle both formats.
        /// </remarks>
        /// <param name="response"> The response from the service. </param>
        internal static AnalyzeResult FromLroResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            JsonElement rootElement = document.RootElement;

            // SDK-FIX: Check if the response has a "result" property, otherwise use the root element directly (handles both response formats)
            if (rootElement.TryGetProperty("result", out JsonElement resultElement))
            {
                return DeserializeAnalyzeResult(resultElement, ModelSerializationExtensions.WireOptions);
            }
            else
            {
                // The response might be the AnalyzeResult directly
                return DeserializeAnalyzeResult(rootElement, ModelSerializationExtensions.WireOptions);
            }
        }
    }
}

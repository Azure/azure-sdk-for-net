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
    // SDK-FIX Issue #5: Suppress FromLroResponse to fix service response format inconsistency (with/without "result" wrapper)
    [CodeGenSuppress("FromLroResponse", typeof(Response))]
    public partial class AnalyzeResult
    {
        /// <summary>
        /// Converts a response to an AnalyzeResult using the LRO result path.
        /// </summary>
        /// <remarks>
        /// SDK-FIX Issue #5: This method is customized to handle service response format inconsistency.
        /// The service sometimes wraps AnalyzeResult in a "result" property, and sometimes returns it directly.
        /// This workaround uses TryGetProperty to handle both formats until the service is fixed.
        /// </remarks>
        /// <param name="response"> The response from the service. </param>
        internal static AnalyzeResult FromLroResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            JsonElement rootElement = document.RootElement;

            // SDK-FIX Issue #5: Check if the response has a "result" property, otherwise use the root element directly
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

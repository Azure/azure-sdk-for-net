// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Extension methods for <see cref="Operation{AnalysisResult}"/> returned by
    /// <see cref="ContentUnderstandingClient.AnalyzeAsync(WaitUntil, string, IEnumerable{AnalysisInput}, IDictionary{string, string}?, ProcessingLocation?, System.Threading.CancellationToken)"/>
    /// and related methods.
    /// </summary>
    public static class AnalyzeOperationExtensions
    {
        /// <summary>
        /// Gets the usage details from a completed analyze operation.
        /// </summary>
        /// <remarks>
        /// The REST API returns a <c>usage</c> field as a sibling of <c>result</c> in the LRO response
        /// envelope. This extension method reads <c>usage</c> from the operation's final response and
        /// deserializes it into an <see cref="AnalyzeUsageDetails"/> instance. The operation must have completed
        /// successfully before calling this method.
        /// </remarks>
        /// <param name="operation">The completed analyze operation.</param>
        /// <returns>
        /// The <see cref="AnalyzeUsageDetails"/> if the operation has completed and usage information is available;
        /// <c>null</c> if the operation has not completed or usage data is not present in the response.
        /// </returns>
        public static AnalyzeUsageDetails? GetUsage(this Operation<AnalysisResult> operation)
        {
            if (operation == null || !operation.HasCompleted)
            {
                return null;
            }

            try
            {
                Response response = operation.GetRawResponse();
                if (response?.Content == null)
                {
                    return null;
                }

                using JsonDocument document = JsonDocument.Parse(response.Content);
                if (document.RootElement.TryGetProperty("usage", out JsonElement usageElement)
                    && usageElement.ValueKind != JsonValueKind.Null)
                {
                    return AnalyzeUsageDetails.FromJsonElement(usageElement);
                }
            }
            catch (JsonException)
            {
                // Swallow JSON parse failures — return null when the response
                // is malformed or does not contain valid usage data.
            }
            catch (InvalidOperationException)
            {
                // Swallow deserialization/state failures (e.g. wrong JsonValueKind)
                // caused by unexpected usage data shapes.
            }

            return null;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Extension methods for analyze LRO <see cref="Operation{AnalysisResult}"/> and inline
    /// <see cref="Response{AnalysisResult}"/> values.
    /// </summary>
    public static class AnalyzeOperationExtensions
    {
        private static readonly ModelReaderWriterOptions JsonOptions = new("J");

        /// <summary>
        /// Gets the usage details from a completed analyze operation.
        /// </summary>
        /// <param name="operation">The completed analyze operation.</param>
        /// <returns>
        /// The <see cref="AnalyzeUsageDetails"/> if the operation has completed and usage information is available;
        /// <c>null</c> if the operation has not completed or usage data is not present in the response.
        /// </returns>
        [Obsolete("Use GetUsageDetails instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AnalyzeUsageDetails? GetUsage(this Operation<AnalysisResult> operation)
        {
#pragma warning disable CS0618 // Compatibility path for obsolete AnalyzeUsageDetails
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
#pragma warning restore CS0618
        }

        /// <summary>
        /// Gets generated <see cref="UsageDetails"/> from a completed analyze LRO.
        /// </summary>
        /// <param name="operation">The completed analyze operation.</param>
        /// <returns>
        /// The <see cref="UsageDetails"/> if the operation has completed and usage information is available;
        /// <c>null</c> if the operation has not completed or usage data is not present in the response.
        /// </returns>
        public static UsageDetails? GetUsageDetails(this Operation<AnalysisResult> operation)
        {
            if (operation == null || !operation.HasCompleted)
            {
                return null;
            }

            return TryGetUsageDetails(operation.GetRawResponse());
        }

        /// <summary>
        /// Gets generated <see cref="UsageDetails"/> from a completed inline analyze response.
        /// </summary>
        /// <param name="response">The inline <see cref="Response{AnalysisResult}"/> returned by analyze inline APIs.</param>
        /// <returns>
        /// The <see cref="UsageDetails"/> if usage information is available in the raw response;
        /// <c>null</c> if the response or usage data is not present.
        /// </returns>
        public static UsageDetails? GetUsageDetails(this Response<AnalysisResult> response)
        {
            if (response == null)
            {
                return null;
            }

            return TryGetUsageDetails(response.GetRawResponse());
        }

        private static UsageDetails? TryGetUsageDetails(Response? response)
        {
            try
            {
                if (response?.Content == null)
                {
                    return null;
                }

                using JsonDocument document = JsonDocument.Parse(response.Content);
                if (document.RootElement.TryGetProperty("usage", out JsonElement usageElement)
                    && usageElement.ValueKind != JsonValueKind.Null)
                {
                    return UsageDetails.DeserializeUsageDetails(usageElement, JsonOptions);
                }
            }
            catch (JsonException)
            {
            }
            catch (InvalidOperationException)
            {
            }

            return null;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Usage details from a completed analyze operation, including document page counts,
    /// contextualization tokens, and per-model LLM/embedding token consumption.
    /// </summary>
    /// <remarks>
    /// Obtain an instance by calling <see cref="AnalyzeOperationExtensions.GetUsage"/> on a
    /// completed <see cref="Operation{AnalysisResult}"/>.
    /// </remarks>
    public class AnalyzeUsageDetails
    {
        internal AnalyzeUsageDetails()
        {
            Tokens = new ReadOnlyDictionary<string, int>(new Dictionary<string, int>());
        }

        /// <summary>
        /// The number of document pages processed at the minimal level.
        /// For documents without explicit pages (e.g., txt, html), every 3000 UTF-16 characters is counted as one page.
        /// </summary>
        public int? DocumentPagesMinimal { get; internal set; }

        /// <summary>
        /// The number of document pages processed at the basic level.
        /// For documents without explicit pages (e.g., txt, html), every 3000 UTF-16 characters is counted as one page.
        /// </summary>
        public int? DocumentPagesBasic { get; internal set; }

        /// <summary>
        /// The number of document pages processed at the standard level.
        /// For documents without explicit pages (e.g., txt, html), every 3000 UTF-16 characters is counted as one page.
        /// </summary>
        public int? DocumentPagesStandard { get; internal set; }

        /// <summary> The hours of audio processed. </summary>
        public float? AudioHours { get; internal set; }

        /// <summary> The hours of video processed. </summary>
        public float? VideoHours { get; internal set; }

        /// <summary>
        /// The number of contextualization tokens consumed for preparing context,
        /// generating confidence scores, source grounding, and output formatting.
        /// </summary>
        public int? ContextualizationTokens { get; internal set; }

        /// <summary>
        /// The number of LLM and embedding tokens consumed, grouped by model
        /// (e.g., "gpt-4.1") and type (e.g., "input", "cached input", "output").
        /// </summary>
        public IReadOnlyDictionary<string, int> Tokens { get; internal set; }

        internal static AnalyzeUsageDetails FromJsonElement(JsonElement element)
        {
            var usage = new AnalyzeUsageDetails();

            if (element.TryGetProperty("documentPagesMinimal", out JsonElement minimalEl) && minimalEl.ValueKind != JsonValueKind.Null)
            {
                usage.DocumentPagesMinimal = minimalEl.GetInt32();
            }

            if (element.TryGetProperty("documentPagesBasic", out JsonElement basicEl) && basicEl.ValueKind != JsonValueKind.Null)
            {
                usage.DocumentPagesBasic = basicEl.GetInt32();
            }

            if (element.TryGetProperty("documentPagesStandard", out JsonElement standardEl) && standardEl.ValueKind != JsonValueKind.Null)
            {
                usage.DocumentPagesStandard = standardEl.GetInt32();
            }

            if (element.TryGetProperty("audioHours", out JsonElement audioEl) && audioEl.ValueKind != JsonValueKind.Null)
            {
                usage.AudioHours = audioEl.GetSingle();
            }

            if (element.TryGetProperty("videoHours", out JsonElement videoEl) && videoEl.ValueKind != JsonValueKind.Null)
            {
                usage.VideoHours = videoEl.GetSingle();
            }

            if (element.TryGetProperty("contextualizationTokens", out JsonElement ctxEl) && ctxEl.ValueKind != JsonValueKind.Null)
            {
                usage.ContextualizationTokens = ctxEl.GetInt32();
            }

            if (element.TryGetProperty("tokens", out JsonElement tokensEl) && tokensEl.ValueKind == JsonValueKind.Object)
            {
                var tokens = new Dictionary<string, int>();
                foreach (JsonProperty prop in tokensEl.EnumerateObject())
                {
                    tokens[prop.Name] = prop.Value.GetInt32();
                }
                usage.Tokens = new ReadOnlyDictionary<string, int>(tokens);
            }

            return usage;
        }
    }
}

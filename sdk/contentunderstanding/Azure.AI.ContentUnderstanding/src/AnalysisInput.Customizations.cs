// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.AI.ContentUnderstanding
{
    public partial class AnalysisInput
    {
        // CUSTOMIZATION: Replaces the generated InputRange property to add ContentRange
        // discoverability in XML doc / IDE tooltips. The property type and behavior are unchanged.

        /// <summary>
        /// Range of the input to analyze (ex. <c>"1-3,5,9-"</c>). Document content uses
        /// 1-based page numbers; audio/video content uses integer milliseconds.
        /// <para>
        /// Use <see cref="ContentRange"/> factory methods for a self-documenting API.
        /// <c>ContentRange</c> converts to <c>string</c> implicitly:
        /// <code>
        /// // Document pages (1-based)
        /// input.InputRange = ContentRange.Pages(1, 3);           // "1-3"
        /// input.InputRange = ContentRange.Combine(
        ///     ContentRange.Pages(1, 3),
        ///     ContentRange.Page(5));                              // "1-3,5"
        ///
        /// // Audio/video time ranges (milliseconds)
        /// input.InputRange = ContentRange.TimeRange(0, 5000);    // "0-5000"
        /// input.InputRange = ContentRange.TimeRangeFrom(30000);  // "30000-"
        /// </code>
        /// </para>
        /// </summary>
        /// <seealso cref="ContentRange"/>
        public string? InputRange { get; set; }
    }
}

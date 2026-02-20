// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Helper to build range expression strings for <see cref="AnalyzeInput.InputRange"/>.
    /// Use document helpers (pages) for PDFs and similar content; use audio/visual helpers (time in ms) for audio and video.
    /// </summary>
    /// <remarks>
    /// <para><b>Format:</b> Comma-separated segments. Each segment is a number (<c>5</c>), a range (<c>1-3</c>), or open-ended (<c>9-</c>).
    /// Document content uses 1-based page numbers; audio/visual uses milliseconds.</para>
    /// <para><b>Simple literals</b> — for a fixed range like "1-3,5,9-", assigning the string directly is shorter:</para>
    /// <code>input.InputRange = "1-3,5,9-";</code>
    /// <para><b>Same range using ContentRange</b> — equivalent but longer; use when building from variables or when you want to avoid format mistakes:</para>
    /// <code>input.InputRange = ContentRange.Combine(ContentRange.Pages(1, 3), ContentRange.Page(5), ContentRange.PagesFromToEnd(9));</code>
    /// <para>Document: <see cref="Pages"/>, <see cref="Page"/>, <see cref="PagesFromToEnd"/>. Audio/visual: <see cref="TimeRangeMs"/>, <see cref="TimeMs"/>, <see cref="TimeFromToEndMs"/>.</para>
    /// </remarks>
    public static class ContentRange
    {
        /// <summary>
        /// Document content: range of pages (1-based). Use for PDFs and other paged documents.
        /// </summary>
        /// <param name="startPage">First page (1-based, inclusive).</param>
        /// <param name="endPage">Last page (1-based, inclusive).</param>
        /// <returns>Range expression for document pages, e.g. "1-3".</returns>
        /// <example>ContentRange.Pages(1, 3) => "1-3" (pages 1, 2, 3).</example>
        public static string Pages(int startPage, int endPage) => $"{startPage}-{endPage}";

        /// <summary>
        /// Document content: single page (1-based). Use for PDFs and other paged documents.
        /// </summary>
        /// <param name="pageNumber">Page number (1-based).</param>
        /// <returns>Range expression for one page, e.g. "5".</returns>
        public static string Page(int pageNumber) => pageNumber.ToString();

        /// <summary>
        /// Document content: from a page to the end of the document (1-based). Use for PDFs and other paged documents.
        /// </summary>
        /// <param name="startPage">First page (1-based, inclusive).</param>
        /// <returns>Range expression, e.g. "9-" (page 9 through end).</returns>
        public static string PagesFromToEnd(int startPage) => $"{startPage}-";

        /// <summary>
        /// Audio/visual content: time range in milliseconds. Use for audio (e.g. WAV) and video (e.g. MP4).
        /// </summary>
        /// <param name="startMs">Start offset in milliseconds (inclusive).</param>
        /// <param name="endMs">End offset in milliseconds (inclusive).</param>
        /// <returns>Range expression for time, e.g. "0-60000" (first 60 seconds).</returns>
        /// <example>ContentRange.TimeRangeMs(0, 60000) => "0-60000" (0s to 60s).</example>
        public static string TimeRangeMs(long startMs, long endMs) => $"{startMs}-{endMs}";

        /// <summary>
        /// Audio/visual content: single time point in milliseconds. Use for audio and video.
        /// </summary>
        /// <param name="timeMs">Offset in milliseconds.</param>
        /// <returns>Range expression, e.g. "5000" (5 seconds in).</returns>
        public static string TimeMs(long timeMs) => timeMs.ToString();

        /// <summary>
        /// Audio/visual content: from a time (ms) to the end of the content. Use for audio and video.
        /// </summary>
        /// <param name="startMs">Start offset in milliseconds (inclusive).</param>
        /// <returns>Range expression, e.g. "120000-" (from 2 minutes to end).</returns>
        public static string TimeFromToEndMs(long startMs) => $"{startMs}-";

        /// <summary>
        /// Combines multiple range segments into one expression (comma-separated).
        /// Use the same content type for all segments: either all document page ranges or all audio/visual time ranges.
        /// </summary>
        /// <param name="segments">Individual range strings from <see cref="Pages"/>, <see cref="Page"/>, <see cref="PagesFromToEnd"/>, <see cref="TimeRangeMs"/>, <see cref="TimeMs"/>, or <see cref="TimeFromToEndMs"/>.</param>
        /// <returns>Combined expression, e.g. "1-3,5,9-" for pages 1–3, 5, and 9 to end.</returns>
        /// <example>
        /// Document: Combine(Pages(1, 3), Page(5), PagesFromToEnd(9)) => "1-3,5,9-".
        /// Audio/visual: Combine(TimeRangeMs(0, 60000), TimeMs(120000), TimeFromToEndMs(180000)) => "0-60000,120000,180000-".
        /// </example>
        public static string Combine(params string[] segments)
        {
            if (segments == null || segments.Length == 0)
                return string.Empty;
            return string.Join(",", segments);
        }

        /// <summary>
        /// Uses a raw range expression string as returned by the service or for advanced scenarios.
        /// Prefer the typed helpers (<see cref="Pages"/>, <see cref="TimeRangeMs"/>, etc.) when possible.
        /// </summary>
        /// <param name="expression">Range expression (e.g. "1-3,5,9-" for document pages or "0-60000,120000-" for milliseconds).</param>
        /// <returns>The same string, for assignment to <see cref="AnalyzeInput.InputRange"/>.</returns>
        public static string FromExpression(string expression) => expression ?? string.Empty;
    }
}

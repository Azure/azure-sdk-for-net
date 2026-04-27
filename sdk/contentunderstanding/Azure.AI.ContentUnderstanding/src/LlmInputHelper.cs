// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Converts <see cref="AnalysisResult"/> objects into LLM-friendly text.
    /// </summary>
    public static class LlmInputHelper
    {
        // ---------------------------------------------------------------
        // Public API
        // ---------------------------------------------------------------

        /// <summary>
        /// Converts a CU analysis result into LLM-friendly text.
        /// <para>
        /// Produces a formatted text string from the analysis result, suitable for
        /// injecting into an LLM prompt, storing in a vector database, or passing
        /// as tool output.
        /// </para>
        /// </summary>
        /// <param name="result">The <see cref="AnalysisResult"/> from a CU analyze operation.</param>
        /// <param name="includeFields">Whether to include structured fields in the output. Defaults to <c>true</c>.</param>
        /// <param name="includeMarkdown">Whether to include markdown content in the output. Defaults to <c>true</c>.</param>
        /// <param name="metadata">Optional user-supplied key-value pairs to include in the YAML front matter.</param>
        /// <returns>A formatted text string with YAML front matter followed by markdown content.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="result"/> is <c>null</c>.</exception>
        public static string ToLlmInput(
            AnalysisResult result,
            bool includeFields = true,
            bool includeMarkdown = true,
            IDictionary<string, object>? metadata = null)
        {
            Argument.AssertNotNull(result, nameof(result));

            if (result.Contents == null || result.Contents.Count == 0)
            {
                return string.Empty;
            }

            var contents = GetRenderableContents(result.Contents);
            if (contents.Count == 0)
            {
                return string.Empty;
            }

            int avCount = contents.Count(c => c is AudioVisualContent);

            var blocks = new List<string>();
            foreach (var content in contents)
            {
                string block = RenderContentBlock(
                    content,
                    result,
                    includeFields,
                    includeMarkdown,
                    metadata,
                    isMultiSegment: avCount > 1);
                if (!string.IsNullOrEmpty(block))
                {
                    blocks.Add(block);
                }
            }

            return string.Join("\n\n*****\n\n", blocks);
        }

        // ---------------------------------------------------------------
        // Field resolution (internal)
        // ---------------------------------------------------------------

        internal static Dictionary<string, object> ResolveFields(IDictionary<string, ContentField> fields)
        {
            var resolved = new Dictionary<string, object>();
            foreach (var kvp in fields)
            {
                object? val = ResolveFieldValue(kvp.Value);
                if (val != null)
                {
                    resolved[kvp.Key] = val;
                }
            }
            return resolved;
        }

        internal static object? ResolveFieldValue(ContentField field)
        {
            if (field is ContentObjectField objField)
            {
                var obj = objField.Value;
                return obj != null && obj.Count > 0 ? ResolveFields(obj) : null;
            }

            if (field is ContentArrayField arrField)
            {
                var arr = arrField.Value;
                if (arr != null && arr.Count > 0)
                {
                    var items = new List<object>();
                    foreach (var item in arr)
                    {
                        object? val = ResolveFieldValue(item);
                        if (val != null)
                        {
                            items.Add(val);
                        }
                    }
                    return items.Count > 0 ? items : null;
                }
                return null;
            }

            // ContentJsonField — extract raw JSON string from BinaryData
            if (field is ContentJsonField jsonField)
            {
                var bd = jsonField.Value;
                return bd != null ? bd.ToString() : null;
            }

            // Leaf field — use the .Value convenience property
            object? leafVal = field.Value;
            if (leafVal == null)
            {
                return null;
            }

            // Convert date/time to ISO strings for YAML serialization
            if (leafVal is DateTimeOffset dto)
            {
                return dto.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            if (leafVal is TimeSpan ts)
            {
                return ts.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture);
            }

            return leafVal;
        }

        // ---------------------------------------------------------------
        // Content rendering
        // ---------------------------------------------------------------

        private static IList<AnalysisContent> GetRenderableContents(IList<AnalysisContent> contents)
        {
            // Collect paths of routed top-level content items
            // (e.g., "input1/segment1" for a segment routed to prebuilt-invoice).
            var routedPaths = new HashSet<string>();
            foreach (var c in contents)
            {
                if (c is DocumentContent dc && !string.IsNullOrEmpty(dc.Category) && !string.IsNullOrEmpty(dc.Path))
                {
                    routedPaths.Add(dc.Path);
                }
            }

            var result = new List<AnalysisContent>();
            foreach (var c in contents)
            {
                if (c is DocumentContent dc && dc.Segments != null && dc.Segments.Count > 0 && string.IsNullOrEmpty(dc.Category))
                {
                    // This is a parent document — expand each segment into a
                    // synthetic DocumentContent, but skip segments that have a
                    // routed top-level content (those will be used directly).
                    string parentPath = dc.Path ?? string.Empty;
                    foreach (var seg in dc.Segments)
                    {
                        string? segPath = !string.IsNullOrEmpty(seg.SegmentId)
                            ? $"{parentPath}/{seg.SegmentId}"
                            : null;

                        if (segPath != null && routedPaths.Contains(segPath))
                        {
                            continue; // top-level version with fields will be used
                        }

                        // Extract markdown slice from parent using the segment's span
                        string? md = null;
                        if (!string.IsNullOrEmpty(dc.Markdown) && seg.Span != null)
                        {
                            int offset = seg.Span.Offset;
                            int length = seg.Span.Length;
                            if (offset >= 0 && offset + length <= dc.Markdown!.Length)
                            {
                                md = dc.Markdown.Substring(offset, length);
                            }
                        }

                        var child = ContentUnderstandingModelFactory.DocumentContent(
                            mimeType: dc.MimeType,
                            startPageNumber: seg.StartPageNumber,
                            endPageNumber: seg.EndPageNumber,
                            markdown: md,
                            category: seg.Category);

                        result.Add(child);
                    }
                }
                else
                {
                    result.Add(c);
                }
            }

            // Sort by page number so output follows document order.
            // This matters when routed segments (with fields) appear as
            // separate top-level contents after expanded parent segments.
            result.Sort((a, b) =>
            {
                int pageA = (a is DocumentContent da) ? da.StartPageNumber : 0;
                int pageB = (b is DocumentContent db) ? db.StartPageNumber : 0;
                return pageA.CompareTo(pageB);
            });

            return result;
        }

        private static string RenderContentBlock(
            AnalysisContent content,
            AnalysisResult result,
            bool includeFields,
            bool includeMarkdown,
            IDictionary<string, object>? metadata,
            bool isMultiSegment)
        {
            // Build ordered front matter data
            var fm = new List<KeyValuePair<string, object>>();

            // 1. contentType
            string kindStr = content is DocumentContent ? "document" :
                             content is AudioVisualContent ? "audioVisual" : "unknown";
            fm.Add(new KeyValuePair<string, object>("contentType", kindStr));

            // 2. User metadata
            if (metadata != null)
            {
                foreach (var kvp in metadata)
                {
                    fm.Add(new KeyValuePair<string, object>(kvp.Key, kvp.Value));
                }
            }

            // 3. timeRange (audioVisual — only for multi-segment)
            if (content is AudioVisualContent av && isMultiSegment)
            {
                string timeRange = FormatTimeRange(av.StartTime, av.EndTime);
                fm.Add(new KeyValuePair<string, object>("timeRange", timeRange));
            }

            // 4. category (classified documents)
            if (!string.IsNullOrEmpty(content.Category))
            {
                fm.Add(new KeyValuePair<string, object>("category", content.Category));
            }

            // 5. pages (documents)
            object? pagesVal = FormatPages(content);
            if (pagesVal != null)
            {
                fm.Add(new KeyValuePair<string, object>("pages", pagesVal));
            }

            // 6. fields
            if (includeFields && content.Fields != null && content.Fields.Count > 0)
            {
                var resolved = ResolveFields(content.Fields);
                if (resolved.Count > 0)
                {
                    fm.Add(new KeyValuePair<string, object>("fields", resolved));
                }
            }

            // 7. rai_warnings
            if (result.Warnings != null && result.Warnings.Count > 0)
            {
                var warningsList = FormatWarnings(result.Warnings);
                if (warningsList.Count > 0)
                {
                    fm.Add(new KeyValuePair<string, object>("rai_warnings", warningsList));
                }
            }

            // Build output string
            string frontMatter = BuildFrontMatter(fm);

            if (includeMarkdown && !string.IsNullOrEmpty(content.Markdown))
            {
                string md = content.Markdown;
                if (content is DocumentContent dc)
                {
                    md = AddPageMarkers(dc, md);
                }
                return frontMatter + "\n" + md;
            }
            return frontMatter;
        }

        // ---------------------------------------------------------------
        // Page numbering
        // ---------------------------------------------------------------

        internal static string AddPageMarkers(DocumentContent content, string markdown)
        {
            if (content.Pages != null && content.Pages.Count > 0)
            {
                string result = PageMarkersFromSpans(markdown, content.Pages);
                if (!ReferenceEquals(result, markdown)) // spans were found and used
                {
                    return result;
                }
            }
            return PageMarkersFromBreaks(markdown, content);
        }

        private static readonly Regex s_pageBreakPattern = new Regex(@"\n*<!-- PageBreak -->\n*", RegexOptions.Compiled);

        private static string PageMarkersFromSpans(string markdown, IList<DocumentPage> pages)
        {
            var markers = new List<(int Offset, int PageNumber)>();
            foreach (var page in pages)
            {
                if (page.Spans != null && page.Spans.Count > 0)
                {
                    markers.Add((page.Spans[0].Offset, page.PageNumber));
                }
            }

            if (markers.Count == 0)
            {
                return markdown;
            }

            markers.Sort((a, b) => a.Offset.CompareTo(b.Offset));

            // Strip existing <!-- PageBreak --> markers since page markers replace them
            string cleaned = s_pageBreakPattern.Replace(markdown, "\n\n");

            // Compute offset shifts from the cleaning
            var shifts = new List<(int Position, int Delta)>();
            foreach (Match m in s_pageBreakPattern.Matches(markdown))
            {
                int replacementLen = 2; // "\n\n"
                int delta = m.Length - replacementLen;
                shifts.Add((m.Index, delta));
            }

            int AdjustedOffset(int orig)
            {
                int total = 0;
                foreach (var shift in shifts)
                {
                    if (orig > shift.Position)
                    {
                        total += shift.Delta;
                    }
                }
                return orig - total;
            }

            // Build result by splicing at page boundaries
            var sb = new StringBuilder();
            int prev = 0;
            foreach (var marker in markers)
            {
                int adj = AdjustedOffset(marker.Offset);
                sb.Append(cleaned, prev, adj - prev);
                sb.Append($"<!-- page {marker.PageNumber} -->\n\n");
                prev = adj;
            }
            sb.Append(cleaned, prev, cleaned.Length - prev);

            return sb.ToString();
        }

        private static string PageMarkersFromBreaks(string markdown, DocumentContent content)
        {
            int startPage = content.StartPageNumber > 0 ? content.StartPageNumber : 1;

            string[] chunks = s_pageBreakPattern.Split(markdown);
            var parts = new List<string>();
            for (int i = 0; i < chunks.Length; i++)
            {
                int pageNum = startPage + i;
                string text = chunks[i].Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    parts.Add($"<!-- page {pageNum} -->\n\n{text}");
                }
            }
            return string.Join("\n\n", parts);
        }

        // ---------------------------------------------------------------
        // Formatting helpers
        // ---------------------------------------------------------------

        internal static string FormatTimeRange(TimeSpan start, TimeSpan end)
        {
            static string Fmt(TimeSpan t)
            {
                int totalSeconds = (int)t.TotalSeconds;
                return $"{totalSeconds / 60:D2}:{totalSeconds % 60:D2}";
            }
            return $"{Fmt(start)} \u2013 {Fmt(end)}";
        }

        private static object? FormatPages(AnalysisContent content)
        {
            if (content is not DocumentContent dc)
            {
                return null;
            }

            // Prefer actual page numbers from the pages list
            if (dc.Pages != null && dc.Pages.Count > 0)
            {
                var nums = new List<int>();
                foreach (var p in dc.Pages)
                {
                    if (p.PageNumber > 0)
                    {
                        nums.Add(p.PageNumber);
                    }
                }
                if (nums.Count > 0)
                {
                    nums.Sort();
                    return CompressPageNumbers(nums);
                }
            }

            // Fallback to start/end range
            int start = dc.StartPageNumber;
            int end = dc.EndPageNumber;
            if (start == 0 && end == 0)
            {
                return null;
            }
            if (start == end)
            {
                return start;
            }
            return $"{start}-{end}";
        }

        /// <summary>
        /// Compress a sorted list of page numbers into a compact representation.
        /// Examples: [1] → 1, [1,2,3] → "1-3", [2,3,5] → "2-3, 5".
        /// </summary>
        internal static object CompressPageNumbers(List<int> nums)
        {
            if (nums.Count == 0)
            {
                return 0;
            }
            if (nums.Count == 1)
            {
                return nums[0];
            }

            var ranges = new List<string>();
            int rangeStart = nums[0];
            int prev = nums[0];
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] == prev + 1)
                {
                    prev = nums[i];
                }
                else
                {
                    ranges.Add(rangeStart == prev ? rangeStart.ToString(CultureInfo.InvariantCulture) : $"{rangeStart}-{prev}");
                    rangeStart = nums[i];
                    prev = nums[i];
                }
            }
            ranges.Add(rangeStart == prev ? rangeStart.ToString(CultureInfo.InvariantCulture) : $"{rangeStart}-{prev}");
            return string.Join(", ", ranges);
        }

        private static List<Dictionary<string, string>> FormatWarnings(IList<ResponseError> warnings)
        {
            var items = new List<Dictionary<string, string>>();
            foreach (var w in warnings)
            {
                var entry = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(w.Code))
                {
                    entry["code"] = w.Code!;
                }
                if (!string.IsNullOrEmpty(w.Message))
                {
                    entry["message"] = w.Message!;
                }
                if (entry.Count > 0)
                {
                    items.Add(entry);
                }
            }
            return items;
        }

        // ---------------------------------------------------------------
        // Minimal YAML serializer (no external dependency)
        // ---------------------------------------------------------------

        private static readonly Regex s_yamlSpecialStart = new Regex(@"^[\-\?\:\,\[\]\{\}\#\&\*\!\|\>\'\""\%\@\`]", RegexOptions.Compiled);
        private static readonly Regex s_yamlSpecialInside = new Regex(@"[:\#] |[\n\r]", RegexOptions.Compiled);
        private static readonly Regex s_yamlBool = new Regex(@"^(true|false|yes|no|on|off|null)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex s_yamlNumber = new Regex(@"^[+\-]?(\d+\.?\d*|\.\d+)([eE][+\-]?\d+)?$", RegexOptions.Compiled);
        private static readonly Regex s_yamlDate = new Regex(@"^\d{4}-\d{2}-\d{2}", RegexOptions.Compiled);

        internal static string YamlScalar(object value)
        {
            if (value == null)
            {
                return "null";
            }
            if (value is bool b)
            {
                return b ? "true" : "false";
            }
            if (value is int i)
            {
                return i.ToString(CultureInfo.InvariantCulture);
            }
            if (value is long l)
            {
                return l.ToString(CultureInfo.InvariantCulture);
            }
            if (value is double d)
            {
                if (double.IsInfinity(d) || double.IsNaN(d))
                {
                    return d.ToString(CultureInfo.InvariantCulture);
                }
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                return d == (long)d ? ((long)d).ToString(CultureInfo.InvariantCulture) : d.ToString(CultureInfo.InvariantCulture);
            }
            if (value is float f)
            {
                if (float.IsInfinity(f) || float.IsNaN(f))
                {
                    return f.ToString(CultureInfo.InvariantCulture);
                }
                return f == (long)f ? ((long)f).ToString(CultureInfo.InvariantCulture) : f.ToString(CultureInfo.InvariantCulture);
            }

            string s = value.ToString()!;
            bool needsQuote = string.IsNullOrEmpty(s)
                || s_yamlBool.IsMatch(s)
                || s_yamlNumber.IsMatch(s)
                || s_yamlDate.IsMatch(s)
                || s_yamlSpecialStart.IsMatch(s)
                || s_yamlSpecialInside.IsMatch(s);

            return needsQuote ? ("'" + s.Replace("'", "''") + "'") : s;
        }

        internal static string BuildFrontMatter(List<KeyValuePair<string, object>> data)
        {
            var lines = new List<string> { "---" };
            EmitMapping(lines, data, indent: 0);
            lines.Add("---");
            return string.Join("\n", lines);
        }

        private static void EmitMapping(List<string> lines, List<KeyValuePair<string, object>> mapping, int indent)
        {
            string prefix = new string(' ', indent * 2);
            foreach (var kvp in mapping)
            {
                if (kvp.Value == null)
                {
                    continue;
                }
                string safeKey = YamlScalar(kvp.Key);
                if (kvp.Value is Dictionary<string, object> dict)
                {
                    if (dict.Count == 0)
                    {
                        continue;
                    }
                    lines.Add($"{prefix}{safeKey}:");
                    EmitMappingFromDict(lines, dict, indent + 1);
                }
                else if (kvp.Value is List<object> list)
                {
                    if (list.Count == 0)
                    {
                        continue;
                    }
                    lines.Add($"{prefix}{safeKey}:");
                    EmitSequence(lines, list, indent);
                }
                else if (kvp.Value is List<Dictionary<string, string>> dictList)
                {
                    if (dictList.Count == 0)
                    {
                        continue;
                    }
                    lines.Add($"{prefix}{safeKey}:");
                    EmitSequenceOfDicts(lines, dictList, indent);
                }
                else
                {
                    lines.Add($"{prefix}{safeKey}: {YamlScalar(kvp.Value)}");
                }
            }
        }

        private static void EmitMappingFromDict(List<string> lines, Dictionary<string, object> mapping, int indent)
        {
            string prefix = new string(' ', indent * 2);
            foreach (var kvp in mapping)
            {
                if (kvp.Value == null)
                {
                    continue;
                }
                string safeKey = YamlScalar(kvp.Key);
                if (kvp.Value is Dictionary<string, object> dict)
                {
                    if (dict.Count == 0)
                    {
                        continue;
                    }
                    lines.Add($"{prefix}{safeKey}:");
                    EmitMappingFromDict(lines, dict, indent + 1);
                }
                else if (kvp.Value is List<object> list)
                {
                    if (list.Count == 0)
                    {
                        continue;
                    }
                    lines.Add($"{prefix}{safeKey}:");
                    EmitSequence(lines, list, indent);
                }
                else
                {
                    lines.Add($"{prefix}{safeKey}: {YamlScalar(kvp.Value)}");
                }
            }
        }

        private static void EmitSequence(List<string> lines, List<object> sequence, int indent)
        {
            string prefix = new string(' ', indent * 2);
            foreach (var item in sequence)
            {
                if (item is Dictionary<string, object> dict)
                {
                    bool first = true;
                    foreach (var kvp in dict)
                    {
                        if (kvp.Value == null)
                        {
                            continue;
                        }
                        string tag = first ? $"{prefix}- " : $"{prefix}  ";
                        string safeKey = YamlScalar(kvp.Key);
                        if (kvp.Value is Dictionary<string, object> nested && nested.Count > 0)
                        {
                            lines.Add($"{tag}{safeKey}:");
                            EmitMappingFromDict(lines, nested, indent + 2);
                        }
                        else if (kvp.Value is List<object> nestedList && nestedList.Count > 0)
                        {
                            lines.Add($"{tag}{safeKey}:");
                            EmitSequence(lines, nestedList, indent + 2);
                        }
                        else
                        {
                            lines.Add($"{tag}{safeKey}: {YamlScalar(kvp.Value)}");
                        }
                        first = false;
                    }
                }
                else
                {
                    lines.Add($"{prefix}- {YamlScalar(item)}");
                }
            }
        }

        private static void EmitSequenceOfDicts(List<string> lines, List<Dictionary<string, string>> sequence, int indent)
        {
            string prefix = new string(' ', indent * 2);
            foreach (var dict in sequence)
            {
                bool first = true;
                foreach (var kvp in dict)
                {
                    string tag = first ? $"{prefix}- " : $"{prefix}  ";
                    lines.Add($"{tag}{YamlScalar(kvp.Key)}: {YamlScalar(kvp.Value)}");
                    first = false;
                }
            }
        }
    }
}

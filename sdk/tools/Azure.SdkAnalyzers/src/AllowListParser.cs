// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;

namespace Azure.SdkAnalyzers
{
    /// <summary>
    /// Parses the per-package analyzer allow-list file format used by
    /// <c>eng/analyzerallowlist/&lt;Project&gt;.txt</c>.
    /// </summary>
    /// <remarks>
    /// Format (line-oriented, very permissive):
    /// <list type="bullet">
    ///   <item>Blank lines and lines whose first non-whitespace char is <c>#</c> are ignored.</item>
    ///   <item>An entry starts with <c>nowarn:</c> (case-insensitive). The rest of the line is
    ///     <c>CODE [Prefix:Target]</c>, separated by whitespace.</item>
    ///   <item><c>CODE</c> is a diagnostic ID (e.g., <c>AZC0034</c>, <c>CS0618</c>).</item>
    ///   <item>If only <c>CODE</c> is present, it's a whole-assembly suppression
    ///     (current historical behavior).</item>
    ///   <item>If a target follows, it's a Roslyn DocumentationCommentId
    ///     (<c>T:</c>, <c>M:</c>, <c>N:</c>, <c>P:</c>, <c>F:</c>, <c>E:</c>, <c>!:</c>),
    ///     optionally preceded by a <c>~</c> (tolerated for muscle-memory compat with the
    ///     <c>[SuppressMessage(Target = "~T:Foo")]</c> attribute form).</item>
    /// </list>
    /// </remarks>
    internal static class AllowListParser
    {
        private const string NoWarnPrefix = "nowarn:";

        /// <summary>
        /// Parses all <c>nowarn:</c> entries from <paramref name="text"/>.
        /// </summary>
        public static IReadOnlyList<AllowListEntry> Parse(string text)
        {
            var results = new List<AllowListEntry>();
            if (string.IsNullOrEmpty(text))
            {
                return results;
            }

            using var reader = new StringReader(text);
            string line;
            int lineNumber = 0;
            while ((line = reader.ReadLine()) != null)
            {
                lineNumber++;
                AllowListEntry entry = ParseLine(line, lineNumber);
                if (entry != null)
                {
                    results.Add(entry);
                }
            }

            return results;
        }

        /// <summary>
        /// Parses one line. Returns null for blank lines, comments, and lines that aren't
        /// recognized <c>nowarn:</c> entries.
        /// </summary>
        internal static AllowListEntry ParseLine(string rawLine, int lineNumber)
        {
            if (rawLine == null)
            {
                return null;
            }

            string line = StripTrailingInlineComment(rawLine).Trim();
            if (line.Length == 0 || line[0] == '#')
            {
                return null;
            }

            if (!line.StartsWith(NoWarnPrefix, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            string body = line.Substring(NoWarnPrefix.Length).TrimStart();
            if (body.Length == 0)
            {
                return null;
            }

            // Split into CODE and optional target.
            int wsIndex = IndexOfWhitespace(body);
            string code;
            string targetPart;
            if (wsIndex < 0)
            {
                code = body;
                targetPart = null;
            }
            else
            {
                code = body.Substring(0, wsIndex);
                targetPart = body.Substring(wsIndex + 1).Trim();
                if (targetPart.Length == 0)
                {
                    targetPart = null;
                }
            }

            if (code.Length == 0)
            {
                return null;
            }

            string target = NormalizeTarget(targetPart);
            return new AllowListEntry(code, target, lineNumber);
        }

        /// <summary>
        /// Normalizes a raw target string into a canonical Roslyn DocumentationCommentId
        /// (e.g., <c>T:Foo</c>). Returns <c>null</c> if <paramref name="raw"/> is null/empty
        /// or doesn't start with a recognized DocId prefix.
        /// </summary>
        /// <remarks>
        /// Accepted forms (all map to the same canonical id):
        /// <list type="bullet">
        ///   <item><c>T:Foo</c></item>
        ///   <item><c>~T:Foo</c> — leading tilde tolerated for parity with the
        ///     <c>[SuppressMessage(Target = "~T:Foo")]</c> attribute form.</item>
        /// </list>
        /// </remarks>
        internal static string NormalizeTarget(string raw)
        {
            if (string.IsNullOrEmpty(raw))
            {
                return null;
            }

            string s = raw;
            if (s[0] == '~' && s.Length > 1)
            {
                s = s.Substring(1);
            }

            // DocId is "<kind-char>:<rest>" with kind in T M N P F E !
            if (s.Length < 3 || s[1] != ':')
            {
                return null;
            }

            char kind = s[0];
            if (kind != 'T' && kind != 'M' && kind != 'N' && kind != 'P' &&
                kind != 'F' && kind != 'E' && kind != '!')
            {
                return null;
            }

            return s;
        }

        private static int IndexOfWhitespace(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsWhiteSpace(s[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Removes a trailing inline comment (anything after a <c>#</c> that is
        /// preceded by whitespace). Required because Roslyn DocumentationCommentIds
        /// contain raw <c>#</c> in tokens like <c>#ctor</c>; we only treat
        /// <c> #</c> as a comment delimiter when it's clearly outside an identifier.
        /// </summary>
        internal static string StripTrailingInlineComment(string line)
        {
            if (line == null)
            {
                return null;
            }

            for (int i = 1; i < line.Length; i++)
            {
                if (line[i] == '#' && char.IsWhiteSpace(line[i - 1]))
                {
                    return line.Substring(0, i);
                }
            }

            return line;
        }
    }
}

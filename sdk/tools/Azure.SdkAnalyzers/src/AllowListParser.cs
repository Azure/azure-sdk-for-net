// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;

namespace Azure.SdkAnalyzers
{
    /// <summary>
    /// Parses the per-package allow-list file format (<c>eng/analyzerallowlist/&lt;Project&gt;.txt</c>).
    /// See <c>eng/analyzerallowlist/README.md</c> for the format.
    /// </summary>
    internal static class AllowListParser
    {
        private const string NoWarnPrefix = "nowarn:";

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

            int bodyStart = NoWarnPrefix.Length;
            while (bodyStart < line.Length && line[bodyStart] == ' ')
            {
                bodyStart++;
            }
            string body = line.Substring(bodyStart);
            if (body.Length == 0)
            {
                return null;
            }

            // Split on the first literal space — kept in sync with
            // eng/AnalyzerAllowList.targets, which also splits on a literal space.
            int wsIndex = body.IndexOf(' ');
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
            if (targetPart != null && target == null)
            {
                // Target supplied but not a valid DocId — reject the line so the
                // author isn't left with a silent no-op (MSBuild would also skip
                // this line, since it still contains a space).
                return null;
            }

            return new AllowListEntry(code, target, lineNumber);
        }

        /// <summary>
        /// Returns the canonical DocId (e.g. <c>T:Foo</c>) or <c>null</c> if the
        /// input isn't a recognized DocId. A leading <c>~</c> is tolerated for
        /// parity with the <c>[SuppressMessage(Target = "~T:Foo")]</c> attribute form.
        /// </summary>
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

        /// <summary>
        /// Strips a trailing <c> #...</c> comment. The space-before-hash rule
        /// keeps DocId tokens like <c>M:Foo.#ctor(...)</c> intact.
        /// </summary>
        internal static string StripTrailingInlineComment(string line)
        {
            if (line == null)
            {
                return null;
            }

            for (int i = 1; i < line.Length; i++)
            {
                if (line[i] == '#' && line[i - 1] == ' ')
                {
                    return line.Substring(0, i);
                }
            }

            return line;
        }
    }
}

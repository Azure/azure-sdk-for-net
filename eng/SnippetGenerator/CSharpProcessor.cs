// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace SnippetGenerator
{
    public class CSharpProcessor
    {
        private static readonly string _snippetFormat = "{3} <code snippet=\"{0}\">{1}{2} </code>";
        private static readonly string _snippetExampleFormat = "{3} <example snippet=\"{0}\">{1}{3} <code>{1}{2} </code>{1}{3} </example>";

        private static readonly Regex _snippetRegex = new Regex("^(?<indent>\\s*)\\/{3}\\s*<code snippet=\"(?<name>[\\w:]+)\">.*?\\s*<\\/code>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private static readonly Regex _snippetExampleRegex = new Regex("^(?<indent>\\s*)\\/{3}\\s*<example snippet=\"(?<name>[\\w:]+)\">.*?\\s*<\\/example>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public static string Process(string markdown, Func<string, string> snippetProvider)
        {
            string CodeTagFormatter(Match match)
            {
                var name = BuildResult(snippetProvider, match, out var prefix, out var builder);

                return string.Format(_snippetFormat, name, Environment.NewLine, builder, prefix);
            }

            string ExampleTagFormatter(Match match)
            {
                var name = BuildResult(snippetProvider, match, out var prefix, out var builder);

                return string.Format(_snippetExampleFormat, name, Environment.NewLine, builder, prefix);
            }

            string result = _snippetRegex.Replace(markdown, CodeTagFormatter);
            return result != markdown ? result : _snippetExampleRegex.Replace(markdown, ExampleTagFormatter);
        }

        private static string BuildResult(Func<string, string> snippetProvider, Match match, out string prefix, out StringBuilder builder)
        {
            var name = match.Groups["name"].Value;
            prefix = match.Groups["indent"].Value + "///";

            var snippetText = snippetProvider(name);

            builder = new StringBuilder();
            foreach (var line in snippetText.Split(Environment.NewLine))
            {
                builder.Append(prefix);
                if (!string.IsNullOrWhiteSpace(line))
                {
                    builder.Append(" ");
                }

                builder.AppendLine(SecurityElement.Escape(line));
            }

            if (builder.Length > 0)
            {
                builder.Length -= Environment.NewLine.Length;
            }

            return name;
        }
    }
}
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
        private static readonly string _snippetExampleFormat = "{3} <example snippet=\"{0}\">{4}{1}{3} <code>{1}{2} </code>{1}{3} </example>";

        private static readonly Regex _snippetRegex = new Regex("^(?<indent>\\s*)\\/{3}\\s*<code snippet=\"(?<name>[\\w:]+)\">.*?\\s*<\\/code>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private static readonly Regex _snippetExampleRegex = new Regex("^(?<indent>\\s*)\\/{3}\\s*<example snippet=\"(?<name>[\\w:]+)\"?>(?<body>.*?\\s*)(^\\s*\\/{3}\\s*)?<\\/example>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private static readonly Regex _CodeDocRegex = new Regex("^(?<indent>\\s*)\\/{3}\\s*<code *>.*?\\s*<\\/code>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public static string Process(string markdown, Func<string, string> snippetProvider)
        {
            string CodeTagFormatter(Match match)
            {
                var name = BuildResult(snippetProvider, match, out var prefix, out var builder, out _);

                return string.Format(_snippetFormat, name, Environment.NewLine, builder, prefix);
            }

            string ExampleTagFormatter(Match match)
            {
                var name = BuildResult(snippetProvider, match, out var prefix, out var builder, out var exampleBody);

                return string.Format(_snippetExampleFormat, name, Environment.NewLine, builder, prefix, exampleBody);
            }

            string result = _snippetRegex.Replace(markdown, CodeTagFormatter);
            return _snippetExampleRegex.Replace(result, ExampleTagFormatter);
        }

        private static string BuildResult(Func<string, string> snippetProvider, Match match, out string prefix, out StringBuilder builder, out string exampleBody)
        {
            var name = match.Groups["name"].Value;
            prefix = match.Groups["indent"].Value + "///";

            // set exampleBody to the contents of the body of the tag minus the <code>...</code> block.
            // this is to preserve any example text prefix to the code block.
            if (match.Groups["body"].Success)
            {
                var body = match.Groups["body"].Value;
                exampleBody = _CodeDocRegex.Replace(body, string.Empty).TrimEnd(Environment.NewLine.ToCharArray());
            }
            else
            {
                exampleBody = string.Empty;
            }

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
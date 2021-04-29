// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

        public static async ValueTask<string> ProcessAsync(string markdown, Func<string, ValueTask<string>> snippetProvider)
        {
            async ValueTask<string> CodeTagFormatter(Match match)
            {
                return await BuildResult(snippetProvider, match, _snippetFormat);
            }

            async ValueTask<string> ExampleTagFormatter(Match match)
            {
                return await BuildResult(snippetProvider, match, _snippetExampleFormat);
            }

            string result = await _snippetRegex.ReplaceAsync(markdown, CodeTagFormatter);
            return result != markdown ? result : await _snippetExampleRegex.ReplaceAsync(markdown, ExampleTagFormatter);
        }

        private static async ValueTask<string> BuildResult(Func<string, ValueTask<string>> snippetProvider, Match match, string format)
        {
            var name = match.Groups["name"].Value;
            var prefix = match.Groups["indent"].Value + "///";

            var snippetText = await snippetProvider(name);

            var builder = new StringBuilder();
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

            return string.Format(format, name, Environment.NewLine, builder, prefix);
        }
    }
}
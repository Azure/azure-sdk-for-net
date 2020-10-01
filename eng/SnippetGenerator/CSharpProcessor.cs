// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace SnippetGenerator
{
    public class CSharpProcessor
    {
        private static readonly string _snippetFormat = "{3} <code snippet=\"{0}\">{1}{2} </code>";
        private static readonly Regex _snippetRegex = new Regex("^(?<indent>\\s*)\\/{3}\\s*<code snippet=\\\"(?<name>[\\w:]+)\\\">.*?\\/{3}\\s*<\\/code>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public static string Process(string markdown, Func<string, string> snippetProvider)
        {
            return _snippetRegex.Replace(markdown, match =>
            {
                var name = match.Groups["name"].Value;
                var prefix = match.Groups["indent"].Value + "///";

                var snippetText = snippetProvider(name);

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

                return string.Format(_snippetFormat, name, Environment.NewLine, builder, prefix);
            });
        }

    }
}
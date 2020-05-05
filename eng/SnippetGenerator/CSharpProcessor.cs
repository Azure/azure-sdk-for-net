// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SnippetGenerator
{
    public class CSharpProcessor
    {
        private static readonly string _snippetFormat = "{3}<code snippet=\"{0}\">{1}{2}</code>";
        private static readonly Regex _snippetRegex = new Regex("^(?<ident>\\s*)\\/{3}\\s*<code snippet=\\\"(?<name>[\\w:]+)\\\">.*?\\/{3}\\s*<\\/code>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public static string Process(string markdown, Func<string, string> snippetProvider)
        {
            return _snippetRegex.Replace(markdown, match =>
            {
                var name = match.Groups["name"].Value;
                var prefix = match.Groups["ident"].Value + "/// ";

                var snippetText = snippetProvider(name);
                var text =
                    string.Join(Environment.NewLine,
                        snippetText.Split(Environment.NewLine).Select(l=>prefix + l));

                return string.Format(_snippetFormat, name, Environment.NewLine, text, prefix);
            });
        }

    }
}
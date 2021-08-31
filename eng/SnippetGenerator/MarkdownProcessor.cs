// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SnippetGenerator
{
    public class MarkdownProcessor
    {
        private static readonly string _snippetFormat = "```C# {0}{1}{2}```";
        private static readonly Regex _snippetRegex = new Regex("```\\s*?C#[ ]*?(?<name>[\\w:]+).*?```",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public static async Task<string> ProcessAsync(string markdown, Func<string, ValueTask<string>> snippetProvider)
        {
            return await _snippetRegex.ReplaceAsync(markdown, async match =>
            {
                var matchGroup = match.Groups["name"];
                if (matchGroup.Success)
                {
                    return string.Format(_snippetFormat, matchGroup.Value, Environment.NewLine, await snippetProvider(matchGroup.Value));
                }

                return match.Value;
            });
        }
    }
}
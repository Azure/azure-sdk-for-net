// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis.Text;

namespace SnippetGenerator
{
    internal class Snippet
    {
        public string Name { get; }
        public SourceText Text { get; }

        public Snippet(string name, SourceText text)
        {
            Name = name;
            Text = text;
        }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis.Text;

namespace SnippetGenerator
{
    internal class Snippet
    {
        public string Name { get; }
        public SourceText Text { get; }
        public string FilePath { get; }

        public Snippet(string name, SourceText text, string filePath)
        {
            Name = name;
            Text = text;
            FilePath = filePath;
        }
    }
}
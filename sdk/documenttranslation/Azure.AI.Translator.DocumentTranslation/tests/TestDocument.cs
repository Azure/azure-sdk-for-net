// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Translator.DocumentTranslation.Tests
{
    public class TestDocument
    {
        public TestDocument(string name, string content)
        {
            Name = name;
            Content = content;
        }

        public string Name { get; set; }

        public string Content { get; set; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Snippets;
using System.Xml;

namespace Azure.Generator.Snippets
{
    internal static class XmlWriterContentSnippets
    {
        public static ScopedApi<XmlWriter> XmlWriter(this ScopedApi<XmlWriterContent> content)
            => content.Property(nameof(XmlWriterContent.XmlWriter)).As<XmlWriter>();
    }
}

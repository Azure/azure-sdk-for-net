// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Translator.Document
{
    public partial class DocumentContent
    {
        /// <summary> Convert into a MultipartFormDataContent. </summary>
        public RequestContent ToRequestContent()
        {
            var content = new MultipartFormDataContent();
            content.Add(Document.Content, "document", Document.Name, new Dictionary<string, string>()
            {
                {"Content-Type", Document.ContentType }
            });

            foreach (var glossary in Glossary)
            {
                content.Add(glossary.Content, "glossary", glossary.Name, new Dictionary<string, string>()
            {
                {"Content-Type", Document.ContentType }
            });
            }
            return content;
        }
    }
}

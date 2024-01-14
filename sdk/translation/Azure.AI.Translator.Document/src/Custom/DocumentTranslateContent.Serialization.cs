// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Translator.Document
{
    public partial class DocumentTranslateContent
    {
        // CUSTOM CODE NOTE:
        // Implement custom serialization code to compose a request with Content-Type:
        // multipart/form-data, which currently cannot be auto-generated.

        internal virtual RequestContent ToRequestMultipartFormDataContent()
        {
            MultipartFormDataContent content = new MultipartFormDataContent();
            string filename = Optional.IsDefined(FileName) ? FileName : "file.txt";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "text/plain");
            // headers.Add("Content-Disposition", $"form-data; name=document; filename={filename}");
            content.Add(RequestContent.Create(Document), "document", "file.txt", headers);

            foreach (var glossaary in Glossary)
            {
                content.Add(RequestContent.Create(glossaary), "document", "file.txt", headers);
            }

            return content;
        }
    }
}

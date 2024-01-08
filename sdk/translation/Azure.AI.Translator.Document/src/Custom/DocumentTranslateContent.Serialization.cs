// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Translator.Document
{
    public partial class DocumentTranslateContent
    {
        /// <summary> The optional filename or descriptive identifier to associate with with the audio data. </summary>
        public string Filename { get; set; }

        // CUSTOM CODE NOTE:
        // Implement custom serialization code to compose a request with Content-Type:
        // multipart/form-data, which currently cannot be auto-generated.

        internal virtual RequestContent ToRequestContent()
        {
            MultipartFormDataContent content = new();

            string filename = Optional.IsDefined(Filename) ? Filename : "file.txt";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "text/plain");
            headers.Add("Content-Disposition", $"form-data; name=document; filename={filename}");
            content.Add(MultipartContent.Create(Document), headers);

            return content;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Translation.Document
{
    public partial class DocumentTranslateContent
    {
        internal virtual MultiPartFormDataRequestContent ToMultipartRequestContent()
        {
            MultiPartFormDataRequestContent content = new MultiPartFormDataRequestContent();
            content.Add(MultipartDocument.Content, "document", MultipartDocument.Name, MultipartDocument.ContentType);
            if (Optional.IsCollectionDefined(MultipartGlossary))
            {
                foreach (MultipartFormFileData item in MultipartGlossary)
                {
                    content.Add(item.Content, "glossary", item.Name, item.ContentType);
                }
            }
            return content;
        }
    }
}

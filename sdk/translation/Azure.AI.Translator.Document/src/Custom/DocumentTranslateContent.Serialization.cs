// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Translator.Document
{
    public partial class DocumentContent
    {
        internal virtual RequestContent ToRequestContent()
        {
            return this.MultipartFormDataContent;
        }
    }
}

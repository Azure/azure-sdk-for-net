// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.AI.Translator.Document
{
    public partial class DocumentTranslateContent
    {
        /// <summary> The optional filename or descriptive identifier to associate with with the audio data. </summary>
        public string FileName { get; set; }
    }
}

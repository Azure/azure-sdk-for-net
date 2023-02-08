// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    internal partial class AnalyzeDocumentRequest
    {
        /// <summary> Document URL to analyze. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UrlSource
        {
            get
            {
                return UriSource?.AbsoluteUri;
            }
            set
            {
                UriSource = new Uri(value);
            }
        }
    }
}
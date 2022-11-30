// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("Document")]
    public partial class AnalyzedDocument
    {
        /// <summary>
        /// Document type.
        /// </summary>
        [CodeGenMember("DocType")]
        public string DocumentType { get; }
    }
}

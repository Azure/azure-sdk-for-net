// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("DocumentTypeDetails")]
    public partial class DocumentTypeDetails
    {
        /// <summary> Description of the document semantic schema. </summary>
        public IReadOnlyDictionary<string, DocumentFieldSchema> FieldSchema { get; }
    }
}

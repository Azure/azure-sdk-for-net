// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("DocumentTable")]
    public partial class DocumentTable
    {
        /// <summary> Caption associated with the table. </summary>
        internal DocumentCaption Caption { get; }

        /// <summary> Footnotes associated with the table. </summary>
        internal IReadOnlyList<DocumentFootnote> Footnotes { get; }
    }
}

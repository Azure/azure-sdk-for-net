// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("DocumentTable")]
    public partial class DocumentTable
    {
        /// <summary> Caption associated with the table. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DocumentCaption Caption { get; }

        /// <summary> Footnotes associated with the table. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<DocumentFootnote> Footnotes { get; }
    }
}

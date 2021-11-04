// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("DocumentTableCell")]
    public partial class DocumentTableCell
    {
        /// <summary>
        /// The words that make up this table cell.
        /// </summary>
        public IReadOnlyList<DocumentWord> Words => ClientCommon.GetWords(Pages, Spans);

        /// <summary>
        /// The complete list of pages returned in the Analyze Result, including pages
        /// unrelated to this element. Used only for the convenience <see cref="Words"/>
        /// property.
        /// </summary>
        internal IReadOnlyList<DocumentPage> Pages { get; set; }
    }
}

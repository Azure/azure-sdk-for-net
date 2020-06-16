// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a receipt recognized from the input document.
    /// </summary>
    public class RecognizedReceipt
    {
        internal RecognizedReceipt(DocumentResult_internal documentResult, IReadOnlyList<PageResult_internal> pageResults, IReadOnlyList<ReadResult_internal> readResults)
        {
            RecognizedForm = new RecognizedForm(documentResult, pageResults, readResults);
        }

        /// <summary>
        /// Contains detailed form information about the recognized receipt, such as fields, form type and
        /// form content elements.
        /// </summary>
        public RecognizedForm RecognizedForm { get; }
    }
}

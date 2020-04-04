// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class RecognizedReceipt
    {
        private DocumentResult_internal _documentResult_internal;
        private IList<ReadResult_internal> _readResults;


        internal RecognizedReceipt(DocumentResult_internal documentResult_internal, IList<ReadResult_internal> readResults)
        {
            _documentResult_internal = documentResult_internal;
            _readResults = readResults;
        }

        /// <summary>
        /// </summary>
        public string ReceiptLocale { get; internal set; }

        /// <summary>
        /// </summary>
        public RecognizedForm RecognizedForm { get; internal set; }

    }
}

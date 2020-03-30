// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class CAReceipt : RecognizedReceipt
    {
        internal CAReceipt(DocumentResult_internal documentResult_internal, IList<ReadResult_internal> readResults) : base(documentResult_internal, readResults)
        {
        }

        /// <summary>
        /// Goods and Services Tax.
        /// </summary>
        public FormField<float> TaxGst { get; set; }

        /// <summary>
        /// Provincial Sales Tax.
        /// </summary>
        public FormField<float> TaxPst { get; set; }
    }
}

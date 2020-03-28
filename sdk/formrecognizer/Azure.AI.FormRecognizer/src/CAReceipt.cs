// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Azure.AI.FormRecognizer.Models.Receipts
{
    /// <summary>
    /// </summary>
    public class CAReceipt : RecognizedReceipt
    {
        internal CAReceipt(RecognizedReceipt receipt)
            : base(receipt)
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

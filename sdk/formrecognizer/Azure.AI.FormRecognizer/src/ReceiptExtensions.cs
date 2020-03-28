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
    public static class ReceiptExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="receipt"></param>
        /// <returns></returns>
        public static USReceipt AsUSReceipt(this RecognizedReceipt receipt)
        {
            return new USReceipt(receipt);
        }

        /// <summary>
        /// </summary>
        /// <param name="receipt"></param>
        /// <returns></returns>
        public static CAReceipt AsCAReceipt(this RecognizedReceipt receipt)
        {
            return new CAReceipt(receipt);
        }
    }
}

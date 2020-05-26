// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// The set of extension methods for the <see cref="RecognizedReceipt" /> class.
    /// </summary>
    public static class ReceiptExtensions
    {
        /// <summary>
        /// Converts a <see cref="RecognizedReceipt"/> instance with an &quot;en-US&quot;
        /// <see cref="RecognizedReceipt.ReceiptLocale"/> into a <see cref="USReceipt"/>.
        /// </summary>
        /// <param name="receipt">The instance that this method was invoked on.</param>
        /// <returns>A new <see cref="USReceipt"/> instance generated from the original receipt.</returns>
        public static USReceipt AsUSReceipt(this RecognizedReceipt receipt)
        {
            return new USReceipt(receipt);
        }
    }
}

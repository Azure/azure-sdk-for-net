// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// The receipt type of recognized <see cref="USReceipt"/> instances.
    /// </summary>
    public enum USReceiptType
    {
        /// <summary>
        /// Used for receipts whose type couldn't be recognized.
        /// </summary>
        Unrecognized,

        /// <summary>
        /// Used for receipts with an item list.
        /// </summary>
        Itemized,

        /// <summary>
        /// Used for credit card purchases.
        /// </summary>
        CreditCard,

        /// <summary>
        /// Used for gas receipts.
        /// </summary>
        Gas,

        /// <summary>
        /// Used for parking receipts.
        /// </summary>
        Parking,

        /// <summary>
        /// Used for other types of US sales receipts.
        /// </summary>
        Other,
    }
}

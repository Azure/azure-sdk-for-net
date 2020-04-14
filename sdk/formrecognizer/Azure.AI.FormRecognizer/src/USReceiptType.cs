// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    [Flags]
    public enum USReceiptType
    {
        /// <summary>
        /// </summary>
        Unrecognized = 0,

        /// <summary>
        /// </summary>
        Itemized = 1,

        /// <summary>
        /// </summary>
        CreditCard = 2,

        /// <summary>
        /// </summary>
        Gas = 4,

        /// <summary>
        /// </summary>
        Parking = 8,
    }
}

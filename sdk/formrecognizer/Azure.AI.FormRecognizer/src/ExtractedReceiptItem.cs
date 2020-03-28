// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models.Receipts
{
    /// <summary>
    /// </summary>
    public class USReceiptItem
    {
        internal USReceiptItem(string name, int? quantity, float? price, float? totalPrice)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            TotalPrice = totalPrice;
        }

        /// <summary>
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// </summary>
        public float? Quantity { get; }

        /// <summary>
        /// </summary>
        public float? Price { get; }

        /// <summary>
        /// </summary>
        public float? TotalPrice { get; }
    }
}

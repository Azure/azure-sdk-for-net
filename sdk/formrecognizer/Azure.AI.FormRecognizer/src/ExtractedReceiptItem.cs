// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class ExtractedReceiptItem
    {
        internal ExtractedReceiptItem(string name, int? quantity, float? price, float? totalPrice)
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
        public int? Quantity { get; }

        /// <summary>
        /// </summary>
        public float? Price { get; }

        /// <summary>
        /// </summary>
        public float? TotalPrice { get; }
    }
}

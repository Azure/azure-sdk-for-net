// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedReceiptItem
    {
        internal ExtractedReceiptItem(string name, int? quantity, float? price, float? totalPrice)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            TotalPrice = totalPrice;
        }

        public string Name { get; }
        public int? Quantity { get; }
        public float? Price { get; }
        public float? TotalPrice { get; }
    }
}

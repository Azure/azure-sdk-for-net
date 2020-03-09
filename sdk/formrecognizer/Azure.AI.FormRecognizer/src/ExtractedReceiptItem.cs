// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedReceiptItem
    {
        public ExtractedReceiptItem(string name, int quantity, float totalPrice)
        {
            Name = name;
            Quantity = quantity;
            TotalPrice = totalPrice;
        }

        public string Name { get; }
        public int Quantity { get; }
        public float TotalPrice { get; }
    }
}

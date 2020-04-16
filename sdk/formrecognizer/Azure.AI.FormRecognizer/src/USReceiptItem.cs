// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class USReceiptItem
    {
        internal USReceiptItem(FormField<string> name, FormField<float> quantity, FormField<float> price, FormField<float> totalPrice)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            TotalPrice = totalPrice;
        }

        /// <summary>
        /// </summary>
        public FormField<string> Name { get; }

        /// <summary>
        /// </summary>
        public FormField<float> Quantity { get; }

        /// <summary>
        /// </summary>
        public FormField<float> Price { get; }

        /// <summary>
        /// </summary>
        public FormField<float> TotalPrice { get; }
    }
}

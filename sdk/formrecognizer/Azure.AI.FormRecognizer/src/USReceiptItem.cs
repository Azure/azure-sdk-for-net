// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents an item in a recognized US sales receipt.
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
        /// The field for the name of this item.
        /// </summary>
        public FormField<string> Name { get; }

        /// <summary>
        /// The field for the quantity associated with this item.
        /// </summary>
        public FormField<float> Quantity { get; }

        /// <summary>
        /// The field for the price of a single unit of this item.
        /// </summary>
        public FormField<float> Price { get; }

        /// <summary>
        /// The field for the total price of this item, taking the quantity into account.
        /// </summary>
        public FormField<float> TotalPrice { get; }
    }
}

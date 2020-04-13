// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class USReceiptItem
    {
#pragma warning disable CA1801 // Remove unused parameter
        internal USReceiptItem(string name, int? quantity, float? price, float? totalPrice)
#pragma warning restore CA1801 // Remove unused parameter
        {
            //Name = name;
            //Quantity = quantity;
            //Price = price;
            //TotalPrice = totalPrice;
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

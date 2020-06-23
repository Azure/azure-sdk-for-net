// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Samples
{
    /// <summary>
    /// Represents an item in a recognized receipt.
    /// </summary>
    public class ReceiptItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptItem"/> class.
        /// </summary>
        /// <param name="name">The field for the name of this item.</param>
        /// <param name="quantity">The field for the quantity associated with this item.</param>
        /// <param name="price">The field for the price of a single unit of this item.</param>
        /// <param name="totalPrice">The field for the total price of this item, taking the quantity into account.</param>
        public ReceiptItem(FormField<string> name, FormField<float> quantity, FormField<float> price, FormField<float> totalPrice)
        {
            // To see the list of the supported fields returned by service and its corresponding types, consult:
            // https://westus2.dev.cognitive.microsoft.com/docs/services/form-recognizer-api-v2-preview/operations/GetAnalyzeReceiptResult

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

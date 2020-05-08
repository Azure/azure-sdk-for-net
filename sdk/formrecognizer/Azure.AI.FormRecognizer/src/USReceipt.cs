// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a receipt recognized from the input document and provides members
    /// for accessing common fields present in US sales receipts.
    /// </summary>
    public class USReceipt : RecognizedReceipt
    {
        internal USReceipt(RecognizedReceipt receipt)
            : base(receipt)
        {
            float receiptTypeConfidence;
            ReceiptType = ConvertUSReceiptType(out receiptTypeConfidence);
            ReceiptTypeConfidence = receiptTypeConfidence;

            MerchantAddress = ConvertStringField("MerchantAddress", RecognizedForm.Fields);
            MerchantName = ConvertStringField("MerchantName", RecognizedForm.Fields);
            MerchantPhoneNumber = ConvertPhoneNumberField("MerchantPhoneNumber", RecognizedForm.Fields);
            Subtotal = ConvertFloatField("Subtotal", RecognizedForm.Fields);
            Tax = ConvertFloatField("Tax", RecognizedForm.Fields);
            Tip = ConvertFloatField("Tip", RecognizedForm.Fields);
            Total = ConvertFloatField("Total", RecognizedForm.Fields);
            TransactionDate = ConvertDateField("TransactionDate", RecognizedForm.Fields);
            TransactionTime = ConvertTimeField("TransactionTime", RecognizedForm.Fields);

            Items = ConvertReceiptItems();
        }

        /// <summary>
        /// The type of receipt the service identified the submitted receipt to be.
        /// </summary>
        public USReceiptType ReceiptType { get; internal set; }

        /// <summary>
        /// Measures the degree of certainty of the <see cref="ReceiptType"/> attribution. Value
        /// is between [0.0, 1.0].
        /// </summary>
        public float ReceiptTypeConfidence { get; internal set; }

        /// <summary>
        /// A list of purchased items present in the recognized receipt.
        /// </summary>
        // TODO: Can we make this nullable in case a value isn't present or
        // isn't read by the learner?
        // https://github.com/Azure/azure-sdk-for-net/issues/10361
        public IReadOnlyList<USReceiptItem> Items { get; internal set; }

        /// <summary>
        /// The merchant's address.
        /// </summary>
        public FormField<string> MerchantAddress { get; internal set; }

        /// <summary>
        /// The merchant's name.
        /// </summary>
        public FormField<string> MerchantName { get; internal set; }

        /// <summary>
        /// The merchant's phone number.
        /// </summary>
        public FormField<string> MerchantPhoneNumber { get; internal set; }

        /// <summary>
        /// The subtotal price.
        /// </summary>
        public FormField<float> Subtotal { get; internal set; }

        /// <summary>
        /// The tax price.
        /// </summary>
        public FormField<float> Tax { get; internal set; }

        /// <summary>
        /// The tip price.
        /// </summary>
        public FormField<float> Tip { get; internal set; }

        /// <summary>
        /// The total price.
        /// </summary>
        public FormField<float> Total { get; internal set; }

        /// <summary>
        /// The transaction date.
        /// </summary>
        public FormField<DateTime> TransactionDate { get; internal set; }

        /// <summary>
        /// The transaction time.
        /// </summary>
        public FormField<TimeSpan> TransactionTime { get; internal set; }

        private USReceiptType ConvertUSReceiptType(out float receiptTypeConfidence)
        {
            USReceiptType receiptType = USReceiptType.Unrecognized;
            receiptTypeConfidence = Constants.DefaultConfidenceValue;

            FormField value;
            if (RecognizedForm.Fields.TryGetValue("ReceiptType", out value))
            {
                receiptTypeConfidence = value.Confidence;

                receiptType = value.Value.AsString() switch
                {
                    "Itemized" => USReceiptType.Itemized,
                    "CreditCard" => USReceiptType.CreditCard,
                    "Gas" => USReceiptType.Gas,
                    "Parking" => USReceiptType.Parking,
                    "Other" => USReceiptType.Other,
                    _ => USReceiptType.Unrecognized,
                };
            }

            return receiptType;
        }

        private IReadOnlyList<USReceiptItem> ConvertReceiptItems()
        {
            List<USReceiptItem> items = new List<USReceiptItem>();

            FormField value;
            if (RecognizedForm.Fields.TryGetValue("Items", out value))
            {
                Debug.Assert(value.Value.Type == FieldValueType.ListType);

                IReadOnlyList<FormField> itemList = value.Value.AsList();
                foreach (var item in itemList)
                {
                    Debug.Assert(item.Value.Type == FieldValueType.DictionaryType);

                    IReadOnlyDictionary<string, FormField> itemFields = item.Value.AsDictionary();

                    items.Add(new USReceiptItem(
                        ConvertStringField("Name", itemFields),
                        ConvertFloatField("Quantity", itemFields),
                        ConvertFloatField("Price", itemFields),
                        ConvertFloatField("TotalPrice", itemFields)
                    ));
                }
            }

            return items;
        }
    }
}

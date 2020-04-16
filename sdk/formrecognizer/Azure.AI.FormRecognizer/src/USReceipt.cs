// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class USReceipt : RecognizedReceipt
    {
        internal USReceipt(RecognizedReceipt receipt)
            : base(receipt)
        {
            ReceiptType = ConvertUSReceiptType();

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
        /// </summary>
        public USReceiptType ReceiptType { get; internal set; }

        /// <summary>
        /// </summary>
        // TODO: Can we make this nullable in case a value isn't present or
        // isn't read by the learner?
        // https://github.com/Azure/azure-sdk-for-net/issues/10361
        public IReadOnlyList<USReceiptItem> Items { get; internal set; }

        /// <summary>
        /// </summary>
        public FormField<string> MerchantAddress { get; internal set; }

        /// <summary>
        /// </summary>
        public FormField<string> MerchantName { get; internal set; }

        /// <summary>
        /// </summary>
        public FormField<string> MerchantPhoneNumber { get; internal set; }

        /// <summary>
        /// </summary>
        public FormField<float> Subtotal { get; internal set; }

        /// <summary>
        /// </summary>
        public FormField<float> Tax { get; internal set; }

        /// <summary>
        /// </summary>
        public FormField<float> Tip { get; internal set; }

        /// <summary>
        /// </summary>
        public FormField<float> Total { get; internal set; }

        /// <summary>
        /// </summary>
        public FormField<DateTime> TransactionDate { get; internal set; }

        /// <summary>
        /// </summary>
        public FormField<TimeSpan> TransactionTime { get; internal set; }

        private USReceiptType ConvertUSReceiptType()
        {
            USReceiptType receiptType = USReceiptType.Unrecognized;

            FormField value;
            if (RecognizedForm.Fields.TryGetValue("ReceiptType", out value))
            {
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

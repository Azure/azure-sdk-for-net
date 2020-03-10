﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedReceipt
    {
        internal ExtractedReceipt(DocumentResult_internal documentResult, ReadResult_internal readResult)
        {
            PageRange = new PageRange(documentResult.PageRange);
            SetReceiptValues(documentResult.Fields);

            if (readResult != null)
            {
                RawExtractedPage = new RawExtractedPage(readResult);
            }
        }

        public PageRange PageRange { get; internal set; }

        // TODO: Can we make this nullable in case a value isn't present or
        // isn't read by the learner?
        // https://github.com/Azure/azure-sdk-for-net/issues/10361
        public IReadOnlyList<ExtractedReceiptItem> Items { get; internal set; }
        public string MerchantAddress { get; internal set; }
        public string MerchantName { get; internal set; }
        public string MerchantPhoneNumber { get; internal set; }

        public ExtractedReceiptType ReceiptType { get; internal set; }
        public float Subtotal { get; internal set; }
        public float Tax { get; internal set; }
        public float Tip { get; internal set; }
        public float Total { get; internal set; }
        public DateTimeOffset TransactionDate { get; internal set; }
        public DateTimeOffset TransactionTime { get; internal set; }

        // TODO: Have this handle Items correctly
        // https://github.com/Azure/azure-sdk-for-net/issues/10379
        public IReadOnlyDictionary<string, ExtractedReceiptField> ExtractedFields { get; internal set; }

        public RawExtractedPage RawExtractedPage { get; }

        private void SetReceiptValues(IDictionary<string, FieldValue_internal> fields)
        {
            ReceiptType = ConvertReceiptType(fields);

            MerchantAddress = ConvertStringValue("MerchantAddress", fields);
            MerchantName = ConvertStringValue("MerchantName", fields);
            MerchantPhoneNumber = ConvertStringValue("MerchantPhoneNumber", fields);

            Subtotal = ConvertFloatValue("Subtotal", fields);
            Tax = ConvertFloatValue("Tax", fields);
            Tip = ConvertFloatValue("Tip", fields);
            Total = ConvertFloatValue("Total", fields);

            TransactionDate = ConvertDateTimeOffsetValue("TransactionDate", fields);
            TransactionTime = ConvertDateTimeOffsetValue("TransactionTime", fields);

            Items = ConvertReceiptItems(fields);
            ExtractedFields = ConvertExtractedFields(fields);
        }

        private static IReadOnlyDictionary<string, ExtractedReceiptField> ConvertExtractedFields(IDictionary<string, FieldValue_internal> fields)
        {
            Dictionary<string, ExtractedReceiptField> extractedFields = new Dictionary<string, ExtractedReceiptField>();
            foreach (var field in fields)
            {
                ExtractedReceiptField extractedField = new ExtractedReceiptField(field.Value);
                extractedFields[field.Key] = extractedField;
            }
            return extractedFields;
        }

        private static ExtractedReceiptType ConvertReceiptType(IDictionary<string, FieldValue_internal> fields)
        {
            ExtractedReceiptType receiptType = ExtractedReceiptType.Unrecognized;

            FieldValue_internal value;
            if (fields.TryGetValue("ReceiptType", out value))
            {
                receiptType = value.ValueString switch
                {
                    "Itemized" => ExtractedReceiptType.Itemized,
                    _ => ExtractedReceiptType.Unrecognized,
                };
            }

            return receiptType;
        }

        private static string ConvertStringValue(string fieldName, IDictionary<string, FieldValue_internal> fields)
        {
            string stringValue = default;

            FieldValue_internal value;
            if (fields.TryGetValue(fieldName, out value))
            {
                // TODO: How should we handle Phone Numbers?
                // https://github.com/Azure/azure-sdk-for-net/issues/10333
                Debug.Assert(value.Type == FieldValueType.String || value.Type == FieldValueType.PhoneNumber);

                // TODO: When should we use text and when should we use string?
                // For now, use text if the value is null.
                // https://github.com/Azure/azure-sdk-for-net/issues/10333
                stringValue = value.ValueString ?? value.Text;
            }

            return stringValue;
        }

        private static float ConvertFloatValue(string fieldName, IDictionary<string, FieldValue_internal> fields)
        {
            float floatValue = default;

            FieldValue_internal value;
            if (fields.TryGetValue(fieldName, out value))
            {
                Debug.Assert(value.Type == FieldValueType.Number);

                // TODO: Sometimes ValueNumber isn't populated in ReceiptItems.  The following is a
                // workaround to get the value from Text if ValueNumber isn't there.
                // https://github.com/Azure/azure-sdk-for-net/issues/10333
                float parsedFloat;
                if (float.TryParse(value.Text.TrimStart('$'), out parsedFloat))
                {
                    floatValue = value.ValueNumber.HasValue ? value.ValueNumber.Value : parsedFloat;
                }
                else
                {
                    // TODO: make this nullable
                    // https://github.com/Azure/azure-sdk-for-net/issues/10361
                    floatValue = value.ValueNumber.HasValue ? value.ValueNumber.Value : default;
                }
            }

            return floatValue;
        }

        private static int ConvertIntValue(string fieldName, IDictionary<string, FieldValue_internal> fields)
        {
            int intValue = default;

            FieldValue_internal value;
            if (fields.TryGetValue(fieldName, out value))
            {
                Debug.Assert(value.Type == FieldValueType.Number);

                // TODO: Sometimes ValueInteger isn't populated in ReceiptItems.  The following is a
                // workaround to get the value from Text if ValueNumber isn't there.
                // https://github.com/Azure/azure-sdk-for-net/issues/10333
                int parsedInt;
                if (int.TryParse(value.Text, out parsedInt))
                {
                    intValue = value.ValueInteger.HasValue ? value.ValueInteger.Value : parsedInt;
                }
                else
                {
                    // TODO: make this nullable
                    // https://github.com/Azure/azure-sdk-for-net/issues/10361
                    intValue = value.ValueInteger.HasValue ? value.ValueInteger.Value : default;
                }
            }

            return intValue;
        }

        private static DateTimeOffset ConvertDateTimeOffsetValue(string fieldName, IDictionary<string, FieldValue_internal> fields)
        {
            DateTimeOffset dateTimeOffsetValue = default;

            FieldValue_internal value;
            if (fields.TryGetValue(fieldName, out value))
            {
                // TODO: Make this nullable?
                // https://github.com/Azure/azure-sdk-for-net/issues/10361
                dateTimeOffsetValue = value.Type switch
                {
                    // TODO: Unsuppress
                    // https://github.com/Azure/azure-sdk-for-net/issues/10376
#pragma warning disable CA1305 // Specify IFormatProvider
                    FieldValueType.Date => DateTimeOffset.Parse(value.ValueDate),
                    FieldValueType.Time => DateTimeOffset.Parse(value.ValueTime),
#pragma warning restore CA1305 // Specify IFormatProvider
                    _ => throw new InvalidOperationException($"The value type {value.Type} was expected to be a Date or Time")
                };
            }

            return dateTimeOffsetValue;
        }

        private static IReadOnlyList<ExtractedReceiptItem> ConvertReceiptItems(IDictionary<string, FieldValue_internal> fields)
        {
            List<ExtractedReceiptItem> items = new List<ExtractedReceiptItem>();

            FieldValue_internal value;
            if (fields.TryGetValue("Items", out value))
            {
                Debug.Assert(value.Type == FieldValueType.Array);

                ICollection<FieldValue_internal> arrayValue = value.ValueArray;
                foreach (var receiptItemValue in arrayValue)
                {
                    Debug.Assert(receiptItemValue.Type == FieldValueType.Object);

                    IDictionary<string, FieldValue_internal> objectValue = receiptItemValue.ValueObject;

                    string name = ConvertStringValue("Name", objectValue);
                    int quantity = ConvertIntValue("Quantity", objectValue);
                    float totalPrice = ConvertFloatValue("TotalPrice", objectValue);

                    ExtractedReceiptItem item = new ExtractedReceiptItem(name, quantity, totalPrice);
                    items.Add(item);
                }
            }

            return items;
        }
    }
}

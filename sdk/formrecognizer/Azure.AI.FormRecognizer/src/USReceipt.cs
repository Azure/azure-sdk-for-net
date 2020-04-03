﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        internal USReceipt(DocumentResult_internal documentResult_internal, IList<ReadResult_internal> readResults)
            : base(documentResult_internal, readResults)
        {
        }
        //internal USReceipt(DocumentResult_internal documentResult, IList<ReadResult_internal> readResults)
        //{
        //    PageRange = new FormPageRange(documentResult.PageRange);

        //    SetReceiptValues(documentResult.Fields);

        //    if (readResults != null)
        //    {
        //        Pages = ConvertPageText(PageRange.FirstPageNumber, PageRange.LastPageNumber, readResults);
        //    }
        //}

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
        public USReceiptType ReceiptType { get; internal set; }

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

        ///// <summary>
        ///// </summary>
        //// TODO: Have this handle Items correctly
        //// https://github.com/Azure/azure-sdk-for-net/issues/10379
        //public IReadOnlyDictionary<string, FormField> Fields { get; internal set; }

        //private void SetReceiptValues(IDictionary<string, FieldValue_internal> fields)
        //{
        //    //ReceiptType = ConvertReceiptType(fields);

        //    //MerchantAddress = ConvertStringValue("MerchantAddress", fields);
        //    //MerchantName = ConvertStringValue("MerchantName", fields);
        //    //MerchantPhoneNumber = ConvertStringValue("MerchantPhoneNumber", fields);

        //    //Subtotal = ConvertFloatValue("Subtotal", fields);
        //    //Tax = ConvertFloatValue("Tax", fields);
        //    //Tip = ConvertFloatValue("Tip", fields);
        //    //Total = ConvertFloatValue("Total", fields);

        //    //TransactionDate = ConvertDateTimeOffsetValue("TransactionDate", fields);
        //    //TransactionTime = ConvertDateTimeOffsetValue("TransactionTime", fields);

        //    //Items = ConvertReceiptItems(fields);
        //    //Fields = ConvertExtractedFields(fields);
        //}

        //private static IReadOnlyDictionary<string, UnitedStatesReceiptField> ConvertExtractedFields(IDictionary<string, FieldValue_internal> fields)
        //{
        //    Dictionary<string, UnitedStatesReceiptField> extractedFields = new Dictionary<string, UnitedStatesReceiptField>();
        //    foreach (var field in fields)
        //    {
        //        UnitedStatesReceiptField extractedField = new UnitedStatesReceiptField(field.Value);
        //        extractedFields[field.Key] = extractedField;
        //    }
        //    return extractedFields;
        //}

        //private static UnitedStatesReceiptType ConvertReceiptType(IDictionary<string, FieldValue_internal> fields)
        //{
        //    UnitedStatesReceiptType receiptType = UnitedStatesReceiptType.Unrecognized;

        //    FieldValue_internal value;
        //    if (fields.TryGetValue("ReceiptType", out value))
        //    {
        //        receiptType = value.ValueString switch
        //        {
        //            "Itemized" => UnitedStatesReceiptType.Itemized,
        //            _ => UnitedStatesReceiptType.Unrecognized,
        //        };
        //    }

        //    return receiptType;
        //}

        private static string ConvertStringValue(string fieldName, IDictionary<string, FieldValue_internal> fields)
        {
            string stringValue = default;

            FieldValue_internal value;
            if (fields.TryGetValue(fieldName, out value))
            {
                // TODO: How should we handle Phone Numbers?
                // https://github.com/Azure/azure-sdk-for-net/issues/10333
                Debug.Assert(value.Type == FieldValueType.StringType || value.Type == FieldValueType.PhoneNumberType);

                // TODO: When should we use text and when should we use string?
                // For now, use text if the value is null.
                // https://github.com/Azure/azure-sdk-for-net/issues/10333
                stringValue = value.ValueString ?? value.Text;
            }

            return stringValue;
        }

        private static float? ConvertFloatValue(string fieldName, IDictionary<string, FieldValue_internal> fields)
        {
            float? floatValue = default;

            FieldValue_internal value;
            if (fields.TryGetValue(fieldName, out value))
            {
                Debug.Assert(value.Type == FieldValueType.FloatType);

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
                    floatValue = value.ValueNumber;
                }
            }

            return floatValue;
        }

        private static int? ConvertIntValue(string fieldName, IDictionary<string, FieldValue_internal> fields)
        {
            int? intValue = default;

            FieldValue_internal value;
            if (fields.TryGetValue(fieldName, out value))
            {
                Debug.Assert(value.Type == FieldValueType.IntegerType);

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
                    intValue = value.ValueInteger;
                }
            }

            return intValue;
        }

        private static DateTimeOffset? ConvertDateTimeOffsetValue(string fieldName, IDictionary<string, FieldValue_internal> fields)
        {
            DateTimeOffset? dateTimeOffsetValue = default;

            FieldValue_internal value;
            if (fields.TryGetValue(fieldName, out value))
            {
                // TODO: Make this nullable?
                // https://github.com/Azure/azure-sdk-for-net/issues/10361
                dateTimeOffsetValue = value.Type switch
                {
                    FieldValueType.DateType => value.ValueDate == null ? default : DateTimeOffset.Parse(value.ValueDate, CultureInfo.InvariantCulture),
                    FieldValueType.TimeType => value.ValueTime == null ? default : DateTimeOffset.Parse(value.ValueTime, CultureInfo.InvariantCulture),
                    _ => throw new InvalidOperationException($"The value type {value.Type} was expected to be a Date or Time")
                };
            }

            return dateTimeOffsetValue;
        }

        //private static IReadOnlyList<USReceiptItem> ConvertReceiptItems(IDictionary<string, FieldValue_internal> fields)
        //{
        //    List<USReceiptItem> items = new List<USReceiptItem>();

        //    FieldValue_internal value;
        //    if (fields.TryGetValue("Items", out value))
        //    {
        //        Debug.Assert(value.Type == FieldValueType.ListType);

        //        ICollection<FieldValue_internal> arrayValue = value.ValueArray;
        //        foreach (var receiptItemValue in arrayValue)
        //        {
        //            Debug.Assert(receiptItemValue.Type == FieldValueType.DictionaryType);

        //            IDictionary<string, FieldValue_internal> objectValue = receiptItemValue.ValueObject;

        //            string name = ConvertStringValue("Name", objectValue);
        //            int? quantity = ConvertIntValue("Quantity", objectValue);
        //            float? price = ConvertFloatValue("Price", objectValue);
        //            float? totalPrice = ConvertFloatValue("TotalPrice", objectValue);

        //            USReceiptItem item = new USReceiptItem(name, quantity, price, totalPrice);
        //            items.Add(item);
        //        }
        //    }

        //    return items;
        //}

        private static IReadOnlyList<FormPage> ConvertPageText(int startPageNumber, int endPageNumber, IList<ReadResult_internal> readResults)
        {
            List<FormPage> pageTexts = new List<FormPage>();
            for (int i = startPageNumber - 1; i < endPageNumber - 1; i++)
            {
                if (readResults[i].Lines != null)
                {
                    pageTexts.Add(new FormPage(readResults[i]));
                }
            }
            return pageTexts;
        }
    }
}

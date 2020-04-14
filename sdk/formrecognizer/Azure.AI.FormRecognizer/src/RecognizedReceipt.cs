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
    public class RecognizedReceipt
    {
        internal RecognizedReceipt(DocumentResult_internal documentResult, IReadOnlyList<PageResult_internal> pageResults, IReadOnlyList<ReadResult_internal> readResults)
        {
            // Hard-coding locale for v2.0.
            ReceiptLocale = "en-US";
            RecognizedForm = new RecognizedForm(documentResult, pageResults, readResults);
        }

        internal RecognizedReceipt(RecognizedReceipt receipt)
        {
            ReceiptLocale = receipt.ReceiptLocale;
            RecognizedForm = receipt.RecognizedForm;
        }

        /// <summary>
        /// </summary>
        public string ReceiptLocale { get; internal set; }

        /// <summary>
        /// </summary>
        public RecognizedForm RecognizedForm { get; internal set; }

        internal static FormField<string> ConvertStringField(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            // TODO: validate field - do TryGet()
            FormField field = fields[fieldName];
            return new FormField<string>(field, field.Value.AsString());
        }

        internal static FormField<string> ConvertPhoneNumberField(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            FormField field = fields[fieldName];
            return new FormField<string>(field, field.Value.AsPhoneNumber());
        }

        internal static FormField<int> ConvertIntField(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            FormField field = fields[fieldName];
            return new FormField<int>(field, field.Value.AsInt32());
        }

        internal static FormField<float> ConvertFloatField(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            FormField field = fields[fieldName];
            return new FormField<float>(field, field.Value.AsFloat());
        }

        internal static FormField<DateTime> ConvertDateField(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            FormField field = fields[fieldName];
            return new FormField<DateTime>(field, field.Value.AsDate());
        }

        internal static FormField<TimeSpan> ConvertTimeField(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            FormField field = fields[fieldName];
            return new FormField<TimeSpan>(field, field.Value.AsTime());
        }
    }
}

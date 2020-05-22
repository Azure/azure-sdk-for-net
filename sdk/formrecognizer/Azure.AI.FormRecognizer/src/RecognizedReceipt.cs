// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a receipt recognized from the input document.
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
        /// A culture name representing the location in which the receipt has been issued. Currently only
        /// &quot;en-US&quot; is supported.
        /// </summary>
        public string ReceiptLocale { get; internal set; }

        /// <summary>
        /// Contains detailed form information about the recognized receipt, such as fields, form type and
        /// form content elements.
        /// </summary>
        public RecognizedForm RecognizedForm { get; internal set; }

        internal static FormField<string> ConvertStringField(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            FormField field;
            if (fields.TryGetValue(fieldName, out field))
            {
                return new FormField<string>(field, field.Value.AsString());
            }

            return null;
        }

        internal static FormField<string> ConvertPhoneNumberField(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            FormField field;
            if (fields.TryGetValue(fieldName, out field))
            {
                return new FormField<string>(field, field.Value.AsPhoneNumber());
            }

            return null;
        }

        internal static FormField<int> ConvertIntField(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            FormField field;
            if (fields.TryGetValue(fieldName, out field))
            {
                return new FormField<int>(field, field.Value.AsInt32());
            }

            return null;
        }

        internal static FormField<float> ConvertFloatField(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            FormField field;
            if (fields.TryGetValue(fieldName, out field))
            {
                return new FormField<float>(field, field.Value.AsFloat());
            }

            return null;
        }

        internal static FormField<DateTime> ConvertDateField(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            FormField field;
            if (fields.TryGetValue(fieldName, out field))
            {
                return new FormField<DateTime>(field, field.Value.AsDate());
            }

            return null;
        }

        internal static FormField<TimeSpan> ConvertTimeField(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            FormField field;
            if (fields.TryGetValue(fieldName, out field))
            {
                return new FormField<TimeSpan>(field, field.Value.AsTime());
            }

            return null;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Samples
{
    /// <summary>
    /// Represents a receipt recognized from the input document and provides strongly-typed members
    /// for accessing common fields present in recognized receipts.
    /// </summary>
    public class Receipt
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Receipt"/> class.
        /// </summary>
        /// <param name="recognizedForm">The form from which information will be extracted to build this receipt.</param>
        #region Snippet:FormRecognizerSampleReceiptWrapper
        public Receipt(RecognizedForm recognizedForm)
        {
            // To see the list of the supported fields returned by service and its corresponding types, consult:
            // https://westus2.dev.cognitive.microsoft.com/docs/services/form-recognizer-api-v2-preview/operations/GetAnalyzeReceiptResult

            ReceiptType = ConvertStringField("ReceiptType", recognizedForm.Fields);
            MerchantAddress = ConvertStringField("MerchantAddress", recognizedForm.Fields);
            MerchantName = ConvertStringField("MerchantName", recognizedForm.Fields);
            MerchantPhoneNumber = ConvertPhoneNumberField("MerchantPhoneNumber", recognizedForm.Fields);
            Subtotal = ConvertFloatField("Subtotal", recognizedForm.Fields);
            Tax = ConvertFloatField("Tax", recognizedForm.Fields);
            Tip = ConvertFloatField("Tip", recognizedForm.Fields);
            Total = ConvertFloatField("Total", recognizedForm.Fields);
            TransactionDate = ConvertDateField("TransactionDate", recognizedForm.Fields);
            TransactionTime = ConvertTimeField("TransactionTime", recognizedForm.Fields);

            Items = ConvertReceiptItems(recognizedForm.Fields);
        }
        #endregion

        /// <summary>
        /// The type of receipt the service identified the submitted receipt to be.
        /// </summary>
        public FormField<string> ReceiptType { get; }

        /// <summary>
        /// A list of purchased items present in the recognized receipt.
        /// </summary>
        public IReadOnlyList<ReceiptItem> Items { get; }

        /// <summary>
        /// The merchant's address.
        /// </summary>
        public FormField<string> MerchantAddress { get; }

        /// <summary>
        /// The merchant's name.
        /// </summary>
        public FormField<string> MerchantName { get; }

        /// <summary>
        /// The merchant's phone number.
        /// </summary>
        public FormField<string> MerchantPhoneNumber { get; }

        /// <summary>
        /// The subtotal price.
        /// </summary>
        public FormField<float> Subtotal { get; }

        /// <summary>
        /// The tax price.
        /// </summary>
        public FormField<float> Tax { get; }

        /// <summary>
        /// The tip price.
        /// </summary>
        public FormField<float> Tip { get; }

        /// <summary>
        /// The total price.
        /// </summary>
        public FormField<float> Total { get; }

        /// <summary>
        /// The transaction date.
        /// </summary>
        public FormField<DateTime> TransactionDate { get; }

        /// <summary>
        /// The transaction time.
        /// </summary>
        public FormField<TimeSpan> TransactionTime { get; }

        /// <summary>
        /// Converts an item <see cref="FormField"/> into a list of <see cref="ReceiptItem"/>, making the name,
        /// quantity, price and total price of each item strongly-typed. Returns an empty list if the "Items"
        /// field does not exist or if conversion is not possible.
        /// </summary>
        /// <param name="fields">The dictionary of fields in the recognized receipt. Returned by the service.</param>
        /// <returns>A list of <see cref="ReceiptItem"/> with strongly-typed properties. Returns an empty list if the "Items" field does not exist or if conversion is not possible.</returns>
        private IReadOnlyList<ReceiptItem> ConvertReceiptItems(IReadOnlyDictionary<string, FormField> fields)
        {
            List<ReceiptItem> items = new List<ReceiptItem>();

            if (fields.TryGetValue("Items", out FormField itemsField)
                && itemsField.Value.Type == FieldValueType.List)
            {
                foreach (FormField itemField in itemsField.Value.AsList())
                {
                    if (itemField.Value.Type == FieldValueType.Dictionary)
                    {
                        IReadOnlyDictionary<string, FormField> itemPropertyFields = itemField.Value.AsDictionary();

                        FormField<string> name = ConvertStringField("Name", itemPropertyFields);
                        FormField<float> quantity = ConvertFloatField("Quantity", itemPropertyFields);
                        FormField<float> price = ConvertFloatField("Price", itemPropertyFields);
                        FormField<float> totalPrice = ConvertFloatField("TotalPrice", itemPropertyFields);

                        items.Add(new ReceiptItem(name, quantity, price, totalPrice));
                    }
                }
            }

            return items;
        }

        /// <summary>
        /// Converts a weakly-typed <see cref="FormField"/> into a strongly-typed <see cref="FormField{T}"/> of type
        /// <c>string</c>. Returns <c>null</c> if field does not exist or if conversion is not possible.
        /// </summary>
        /// <param name="fieldName">The key to retrieve the field to be converted from the <paramref name="fields"/> dictionary.</param>
        /// <param name="fields">The dictionary of fields in the recognized receipt. Returned by the service.</param>
        /// <returns>A strongly-typed <see cref="FormField{T}"/>. Returns <c>null</c> if field does not exist or if conversion is not possible.</returns>
        private static FormField<string> ConvertStringField(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            if (fields.TryGetValue(fieldName, out FormField field)
                && field.Value.Type == FieldValueType.String)
            {
                return new FormField<string>(field, field.Value.AsString());
            }

            return null;
        }

        /// <summary>
        /// Converts a weakly-typed <see cref="FormField"/> into a strongly-typed <see cref="FormField{T}"/> of type
        /// <c>string</c>, but formatted as a phone number. Returns <c>null</c> if field does not exist or if conversion
        /// is not possible.
        /// </summary>
        /// <param name="fieldName">The key to retrieve the field to be converted from the <paramref name="fields"/> dictionary.</param>
        /// <param name="fields">The dictionary of fields in the recognized receipt. Returned by the service.</param>
        /// <returns>A strongly-typed <see cref="FormField{T}"/>. Returns <c>null</c> if field does not exist or if conversion is not possible.</returns>
        private static FormField<string> ConvertPhoneNumberField(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            if (fields.TryGetValue(fieldName, out FormField field)
                && field.Value.Type == FieldValueType.PhoneNumber)
            {
                return new FormField<string>(field, field.Value.AsPhoneNumber());
            }

            return null;
        }

        /// <summary>
        /// Converts a weakly-typed <see cref="FormField"/> into a strongly-typed <see cref="FormField{T}"/> of type
        /// <c>long</c>. Returns <c>null</c> if field does not exist or if conversion is not possible.
        /// </summary>
        /// <param name="fieldName">The key to retrieve the field to be converted from the <paramref name="fields"/> dictionary.</param>
        /// <param name="fields">The dictionary of fields in the recognized receipt. Returned by the service.</param>
        /// <returns>A strongly-typed <see cref="FormField{T}"/>. Returns <c>null</c> if field does not exist or if conversion is not possible.</returns>
        private static FormField<long> ConvertInt64Field(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            if (fields.TryGetValue(fieldName, out FormField field)
                && field.Value.Type == FieldValueType.Float)
            {
                return new FormField<long>(field, field.Value.AsInt64());
            }

            return null;
        }

        /// <summary>
        /// Converts a weakly-typed <see cref="FormField"/> into a strongly-typed <see cref="FormField{T}"/> of type
        /// <c>float</c>. Returns <c>null</c> if field does not exist or if conversion is not possible.
        /// </summary>
        /// <param name="fieldName">The key to retrieve the field to be converted from the <paramref name="fields"/> dictionary.</param>
        /// <param name="fields">The dictionary of fields in the recognized receipt. Returned by the service.</param>
        /// <returns>A strongly-typed <see cref="FormField{T}"/>. Returns <c>null</c> if field does not exist or if conversion is not possible.</returns>
        private static FormField<float> ConvertFloatField(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            if (fields.TryGetValue(fieldName, out FormField field)
                && field.Value.Type == FieldValueType.Float)
            {
                return new FormField<float>(field, field.Value.AsFloat());
            }

            return null;
        }

        /// <summary>
        /// Converts a weakly-typed <see cref="FormField"/> into a strongly-typed <see cref="FormField{T}"/> of type
        /// <see cref="DateTime"/>. Returns <c>null</c> if field does not exist or if conversion is not possible.
        /// </summary>
        /// <param name="fieldName">The key to retrieve the field to be converted from the <paramref name="fields"/> dictionary.</param>
        /// <param name="fields">The dictionary of fields in the recognized receipt. Returned by the service.</param>
        /// <returns>A strongly-typed <see cref="FormField{T}"/>. Returns <c>null</c> if field does not exist or if conversion is not possible.</returns>
        private static FormField<DateTime> ConvertDateField(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            if (fields.TryGetValue(fieldName, out FormField field)
                && field.Value.Type == FieldValueType.Date)
            {
                return new FormField<DateTime>(field, field.Value.AsDate());
            }

            return null;
        }

        /// <summary>
        /// Converts a weakly-typed <see cref="FormField"/> into a strongly-typed <see cref="FormField{T}"/> of type
        /// <see cref="TimeSpan"/>. Returns <c>null</c> if field does not exist or if conversion is not possible.
        /// </summary>
        /// <param name="fieldName">The key to retrieve the field to be converted from the <paramref name="fields"/> dictionary.</param>
        /// <param name="fields">The dictionary of fields in the recognized receipt. Returned by the service.</param>
        /// <returns>A strongly-typed <see cref="FormField{T}"/>. Returns <c>null</c> if field does not exist or if conversion is not possible.</returns>
        private static FormField<TimeSpan> ConvertTimeField(string fieldName, IReadOnlyDictionary<string, FormField> fields)
        {
            if (fields.TryGetValue(fieldName, out FormField field)
                && field.Value.Type == FieldValueType.Time)
            {
                return new FormField<TimeSpan>(field, field.Value.AsTime());
            }

            return null;
        }
    }
}

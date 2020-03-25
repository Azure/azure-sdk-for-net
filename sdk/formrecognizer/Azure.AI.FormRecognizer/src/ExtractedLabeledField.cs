// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//using System;
//using System.Collections.Generic;
//using System.Globalization;

//namespace Azure.AI.FormRecognizer.Models
//{
//    /// <summary>
//    /// </summary>
//    // Maps to FieldValue in swagger.
//    public class LabeledFormField
//    {
//        private FieldValue_internal _fieldValue;

//        internal LabeledFormField(KeyValuePair<string, FieldValue_internal> field, IList<ReadResult_internal> readResults)
//        {
//            _fieldValue = field.Value;

//            // Supervised
//            Type = field.Value.Type;
//            Confidence = field.Value.Confidence;
//            PageNumber = field.Value.Page;
//            Label = field.Key;
//            Value = field.Value.Text;
//            ValueBoundingBox = new BoundingBox(field.Value.BoundingBox);

//            if (field.Value.Elements != null)
//            {
//                TextElements = FormField.ConvertTextReferences(readResults, field.Value.Elements);
//            }

//            // TODO: Add strongly-typed value
//            // https://github.com/Azure/azure-sdk-for-net/issues/10333
//        }

//        /// <summary> Type of field value. </summary>
//        public FormValueType Type { get; internal set; }

//        /// <summary>
//        /// </summary>
//        // TODO: Why can this be nullable on FieldValue.Confidence?
//        // https://github.com/Azure/azure-sdk-for-net/issues/10378
//        public float? Confidence { get; internal set; }

//        /// <summary>
//        /// </summary>
//        public int? PageNumber { get; internal set; }

//        /// <summary>
//        /// </summary>
//        public string Label { get; internal set; }

//        /// <summary>
//        /// </summary>
//        public string Value { get; internal set; }

//        /// <summary>
//        /// </summary>
//        public BoundingBox ValueBoundingBox { get; internal set; }

//        /// <summary>
//        /// </summary>
//        public IReadOnlyList<FormText> TextElements { get; internal set; }

//        /// <summary>
//        /// Gets the value of the field as a <see cref="string"/>.
//        /// </summary>
//        /// <returns></returns>
//        public string GetString()
//        {
//            if (Type != FormValueType.StringValue)
//            {
//                throw new InvalidOperationException($"Cannot get field as String.  Field value's type is {Type}.");
//            }

//            return _fieldValue.ValueString;
//        }

//        /// <summary>
//        /// Gets the value of the field as an <see cref="int"/>.
//        /// </summary>
//        /// <returns></returns>
//        public int GetInt32()
//        {
//            if (Type != FormValueType.IntegerValue)
//            {
//                throw new InvalidOperationException($"Cannot get field as Integer.  Field value's type is {Type}.");
//            }

//            if (!_fieldValue.ValueInteger.HasValue)
//            {
//                throw new InvalidOperationException($"Field value is null.");
//            }

//            return _fieldValue.ValueInteger.Value;
//        }

//        /// <summary>
//        /// Gets the value of the field as an <see cref="float"/>.
//        /// </summary>
//        /// <returns></returns>
//        public float GetFloat()
//        {
//            if (Type != FormValueType.FloatValue)
//            {
//                throw new InvalidOperationException($"Cannot get field as Float.  Field value's type is {Type}.");
//            }

//            if (!_fieldValue.ValueNumber.HasValue)
//            {
//                throw new InvalidOperationException($"Field value is null.");
//            }

//            return _fieldValue.ValueNumber.Value;
//        }

//        /// <summary>
//        /// Gets the value of the field as an <see cref="DateTimeOffset"/>.
//        /// </summary>
//        /// <returns></returns>
//        public DateTimeOffset GetDateTimeOffset()
//        {
//            if (Type != FormValueType.DateValue && Type != FormValueType.TimeValue)
//            {
//                throw new InvalidOperationException($"Cannot get field as DateTimeOffset.  Field value's type is {Type}.");
//            }

//            if (_fieldValue.ValueDate == null && _fieldValue.ValueTime == null)
//            {
//                throw new InvalidOperationException($"Field date and time values are both null.");
//            }

//            DateTimeOffset? date = _fieldValue.ValueDate == null ? default : DateTimeOffset.Parse(_fieldValue.ValueDate, CultureInfo.InvariantCulture);
//            TimeSpan? time = _fieldValue.ValueTime == null ? default : TimeSpan.Parse(_fieldValue.ValueTime, CultureInfo.InvariantCulture);

//            DateTimeOffset dateTimeOffset;

//            if (date.HasValue)
//            {
//                dateTimeOffset = new DateTimeOffset(date.Value.DateTime);
//            }

//            if (time.HasValue)
//            {
//                dateTimeOffset.Add(time.Value);
//            }

//            return dateTimeOffset;
//        }

//        /// <summary>
//        /// Gets the value of the field as a phone number <see cref="string"/>.
//        /// </summary>
//        /// <returns></returns>
//        public string GetPhoneNumber()
//        {
//            if (Type != FormValueType.PhoneNumberValue)
//            {
//                throw new InvalidOperationException($"Cannot get field as PhoneNumber.  Field value's type is {Type}.");
//            }

//            return _fieldValue.ValuePhoneNumber;
//        }
//    }
//}

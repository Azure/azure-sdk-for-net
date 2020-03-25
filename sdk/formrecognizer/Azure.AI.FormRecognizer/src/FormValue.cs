// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public struct FieldValue
    {
#pragma warning disable CS0649 // Add readonly modifier
        private FieldValue_internal _fieldValue;
#pragma warning restore CS0649 // Add readonly modifier

        /// <summary> Type of field value. </summary>
        public FieldValueType Type { get; internal set; }

        /// <summary>
        /// Gets the value of the field as a <see cref="string"/>.
        /// </summary>
        /// <returns></returns>
        public string AsString()
        {
            if (Type != FieldValueType.StringType)
            {
                throw new InvalidOperationException($"Cannot get field as String.  Field value's type is {Type}.");
            }

            return _fieldValue.ValueString;
        }

        /// <summary>
        /// Gets the value of the field as an <see cref="int"/>.
        /// </summary>
        /// <returns></returns>
        public int AsInt32()
        {
            if (Type != FieldValueType.IntegerType)
            {
                throw new InvalidOperationException($"Cannot get field as Integer.  Field value's type is {Type}.");
            }

            if (!_fieldValue.ValueInteger.HasValue)
            {
                throw new InvalidOperationException($"Field value is null.");
            }

            return _fieldValue.ValueInteger.Value;
        }

        /// <summary>
        /// Gets the value of the field as an <see cref="float"/>.
        /// </summary>
        /// <returns></returns>
        public float AsFloat()
        {
            if (Type != FieldValueType.FloatType)
            {
                throw new InvalidOperationException($"Cannot get field as Float.  Field value's type is {Type}.");
            }

            if (!_fieldValue.ValueNumber.HasValue)
            {
                throw new InvalidOperationException($"Field value is null.");
            }

            return _fieldValue.ValueNumber.Value;
        }

        /// <summary>
        /// Gets the value of the field as an <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <returns></returns>
        public DateTimeOffset AsDateTimeOffset()
        {
            if (Type != FieldValueType.DateType && Type != FieldValueType.TimeType)
            {
                throw new InvalidOperationException($"Cannot get field as DateTimeOffset.  Field value's type is {Type}.");
            }

            if (_fieldValue.ValueDate == null && _fieldValue.ValueTime == null)
            {
                throw new InvalidOperationException($"Field date and time values are both null.");
            }

            DateTimeOffset? date = _fieldValue.ValueDate == null ? default : DateTimeOffset.Parse(_fieldValue.ValueDate, CultureInfo.InvariantCulture);
            TimeSpan? time = _fieldValue.ValueTime == null ? default : TimeSpan.Parse(_fieldValue.ValueTime, CultureInfo.InvariantCulture);

            DateTimeOffset dateTimeOffset;

            if (date.HasValue)
            {
                dateTimeOffset = new DateTimeOffset(date.Value.DateTime);
            }

            if (time.HasValue)
            {
                dateTimeOffset.Add(time.Value);
            }

            return dateTimeOffset;
        }

        /// <summary>
        /// Gets the value of the field as a phone number <see cref="string"/>.
        /// </summary>
        /// <returns></returns>
        public string AsPhoneNumber()
        {
            if (Type != FieldValueType.PhoneNumberType)
            {
                throw new InvalidOperationException($"Cannot get field as PhoneNumber.  Field value's type is {Type}.");
            }

            return _fieldValue.ValuePhoneNumber;
        }
    }
}

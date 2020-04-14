// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public readonly struct FieldValue
    {
        private readonly FieldValue_internal _fieldValue;
        private readonly IReadOnlyList<ReadResult_internal> _readResults;

        internal FieldValue(FieldValue_internal fieldValue, IReadOnlyList<ReadResult_internal> readResults)
        {
            Type = fieldValue.Type;
            _fieldValue = fieldValue;
            _readResults = readResults;
        }

        /// <summary> Type of field value. </summary>
        public FieldValueType Type { get; }

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
        /// Gets the value of the field as a <see cref="float"/>.
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
        /// Gets the value of the field as a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <returns></returns>
        public DateTime AsDate()
        {
            if (Type != FieldValueType.DateType)
            {
                throw new InvalidOperationException($"Cannot get field as Date.  Field value's type is {Type}.");
            }

            DateTime date = default;
            if (!DateTime.TryParse(_fieldValue.ValueDate, out date))
            {
                throw new InvalidOperationException($"Cannot parse Date value {_fieldValue.ValueDate}.");
            }

            return date;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <returns></returns>
        public TimeSpan AsTime()
        {
            if (Type != FieldValueType.TimeType)
            {
                throw new InvalidOperationException($"Cannot get field as Time.  Field value's type is {Type}.");
            }

            TimeSpan time = default;
            if (!TimeSpan.TryParse(_fieldValue.ValueDate, out time))
            {
                throw new InvalidOperationException($"Cannot parse Time value {_fieldValue.ValueDate}.");
            }

            return time;
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

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<FormField> AsList()
        {
            if (Type != FieldValueType.ListType)
            {
                throw new InvalidOperationException($"Cannot get field as List.  Field value's type is {Type}.");
            }

            List<FormField> fieldList = new List<FormField>();
            foreach (var fieldValue in _fieldValue.ValueArray)
            {
                fieldList.Add(new FormField(null, fieldValue, _readResults));
            }

            return fieldList;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IReadOnlyDictionary<string, FormField> AsDictionary()
        {
            if (Type != FieldValueType.DictionaryType)
            {
                throw new InvalidOperationException($"Cannot get field as Dictionary.  Field value's type is {Type}.");
            }

            Dictionary<string, FormField> fieldDictionary = new Dictionary<string, FormField>();

            foreach (var kvp in _fieldValue.ValueObject)
            {
                fieldDictionary[kvp.Key] = new FormField(kvp.Key, kvp.Value, _readResults);
            }

            return fieldDictionary;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents the strongly-typed value of a field recognized from the input document and provides
    /// methods for converting it to the appropriate type.
    /// </summary>
    public readonly struct FieldValue
    {
        private readonly FieldValue_internal _fieldValue;
        private readonly IReadOnlyList<ReadResult> _readResults;

        internal FieldValue(FieldValue_internal fieldValue, IReadOnlyList<ReadResult> readResults)
            : this()
        {
            ValueType = fieldValue.Type;
            _fieldValue = fieldValue;
            _readResults = readResults;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        /// <param name="isPhoneNumber">Whether or not this value represents a phone number.</param>
        internal FieldValue(string value, bool isPhoneNumber = false)
            : this()
        {
            ValueType = isPhoneNumber ? FieldValueType.PhoneNumber : FieldValueType.String;
            ValueString = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        internal FieldValue(long value)
            : this()
        {
            ValueType = FieldValueType.Int64;
            ValueInteger = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        internal FieldValue(float value)
            : this()
        {
            ValueType = FieldValueType.Float;
            ValueNumber = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        internal FieldValue(DateTime value)
            : this()
        {
            ValueType = FieldValueType.Date;
            ValueDate = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        internal FieldValue(TimeSpan value)
            : this()
        {
            ValueType = FieldValueType.Time;
            ValueTime = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        internal FieldValue(IReadOnlyList<FormField> value)
            : this()
        {
            ValueType = FieldValueType.List;
            ValueList = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        internal FieldValue(IReadOnlyDictionary<string, FormField> value)
            : this()
        {
            ValueType = FieldValueType.Dictionary;
            ValueDictionary = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        internal FieldValue(SelectionMarkState value)
            : this()
        {
            ValueType = FieldValueType.SelectionMark;
            ValueSelectionMark = value;
        }

        /// <summary>
        /// The data type of the field value.
        /// </summary>
        public FieldValueType ValueType { get; }

        /// <summary>
        /// The <c>string</c> or phone number value of this instance. Values are usually
        /// extracted from <see cref="_fieldValue"/>, so this property is exclusively used
        /// for mocking.
        /// </summary>
        private string ValueString { get; }

        /// <summary>
        /// The <c>long</c> value of this instance. Values are usually extracted from
        /// <see cref="_fieldValue"/>, so this property is exclusively used for mocking.
        /// </summary>
        private long ValueInteger { get; }

        /// <summary>
        /// The <c>float</c> value of this instance. Values are usually extracted from
        /// <see cref="_fieldValue"/>, so this property is exclusively used for mocking.
        /// </summary>
        private float ValueNumber { get; }

        /// <summary>
        /// The <see cref="DateTime"/> value of this instance. Values are usually extracted from
        /// <see cref="_fieldValue"/>, so this property is exclusively used for mocking.
        /// </summary>
        private DateTime ValueDate { get; }

        /// <summary>
        /// The <see cref="TimeSpan"/> value of this instance. Values are usually extracted from
        /// <see cref="_fieldValue"/>, so this property is exclusively used for mocking.
        /// </summary>
        private TimeSpan ValueTime { get; }

        /// <summary>
        /// The <see cref="List{T}"/> value of this instance. Values are usually extracted
        /// from <see cref="_fieldValue"/>, so this property is exclusively used for mocking.
        /// </summary>
        private IReadOnlyList<FormField> ValueList { get; }

        /// <summary>
        /// The <see cref="Dictionary{TKey, TValue}"/> value of this instance. Values are
        /// usually extracted from <see cref="_fieldValue"/>, so this property is exclusively
        /// used for mocking.
        /// </summary>
        private IReadOnlyDictionary<string, FormField> ValueDictionary { get; }

        /// <summary>
        /// The <see cref="FieldValueSelectionMark"/> value of this instance. Values are usually extracted from
        /// <see cref="_fieldValue"/>, so this property is exclusively used for mocking.
        /// </summary>
        private SelectionMarkState ValueSelectionMark { get; }

        /// <summary>
        /// Gets the value of the field as a <see cref="string"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="string"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="FieldValueType.String"/>.</exception>
        public string AsString()
        {
            if (ValueType != FieldValueType.String)
            {
                throw new InvalidOperationException($"Cannot get field as String.  Field value's type is {ValueType}.");
            }

            if (_fieldValue == null)
            {
                return ValueString;
            }

            return _fieldValue?.ValueString;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="long"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="long"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="FieldValueType.Int64"/> or when the value is <c>null</c>.</exception>
        public long AsInt64()
        {
            if (ValueType != FieldValueType.Int64)
            {
                throw new InvalidOperationException($"Cannot get field as Integer.  Field value's type is {ValueType}.");
            }

            if (_fieldValue == null)
            {
                return ValueInteger;
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
        /// <returns>The value of the field converted to a <see cref="float"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="FieldValueType.Float"/>.</exception>
        public float AsFloat()
        {
            if (ValueType != FieldValueType.Float)
            {
                throw new InvalidOperationException($"Cannot get field as Float.  Field value's type is {ValueType}.");
            }

            if (_fieldValue == null)
            {
                return ValueNumber;
            }

            if (!_fieldValue.ValueNumber.HasValue)
            {
                // TODO: Sometimes ValueNumber isn't populated in ReceiptItems.  The following is a
                // workaround to get the value from Text if ValueNumber isn't there.
                // https://github.com/Azure/azure-sdk-for-net/issues/10333
                float parsedFloat;
                if (float.TryParse(_fieldValue.Text.TrimStart('$'), out parsedFloat))
                {
                    return parsedFloat;
                }
            }

            return _fieldValue.ValueNumber.Value;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="DateTime"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="DateTime"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="FieldValueType.Date"/> or when the value is <c>null</c>.</exception>
        public DateTime AsDate()
        {
            if (ValueType != FieldValueType.Date)
            {
                throw new InvalidOperationException($"Cannot get field as Date.  Field value's type is {ValueType}.");
            }

            if (_fieldValue == null)
            {
                return ValueDate;
            }

            if (!_fieldValue.ValueDate.HasValue)
            {
                throw new InvalidOperationException($"Field value is null.");
            }

            return _fieldValue.ValueDate.Value.UtcDateTime;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="TimeSpan"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="FieldValueType.Time"/> or when the value is <c>null</c>.</exception>
        public TimeSpan AsTime()
        {
            if (ValueType != FieldValueType.Time)
            {
                throw new InvalidOperationException($"Cannot get field as Time.  Field value's type is {ValueType}.");
            }

            if (_fieldValue == null)
            {
                return ValueTime;
            }

            if (!_fieldValue.ValueTime.HasValue)
            {
                throw new InvalidOperationException($"Field value is null.");
            }

            return _fieldValue.ValueTime.Value;
        }

        /// <summary>
        /// Gets the value of the field as a phone number <see cref="string"/>.
        /// </summary>
        /// <returns>The value of the field converted to a phone number <see cref="string"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="FieldValueType.String"/>.</exception>
        public string AsPhoneNumber()
        {
            if (ValueType != FieldValueType.PhoneNumber)
            {
                throw new InvalidOperationException($"Cannot get field as PhoneNumber.  Field value's type is {ValueType}.");
            }

            if (_fieldValue == null)
            {
                return ValueString;
            }

            return _fieldValue.ValuePhoneNumber;
        }

        /// <summary>
        /// Gets the value of the field as an <see cref="IReadOnlyList{T}"/>.
        /// </summary>
        /// <returns>The value of the field converted to an <see cref="IReadOnlyList{T}"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="FieldValueType.List"/>.</exception>
        public IReadOnlyList<FormField> AsList()
        {
            if (ValueType != FieldValueType.List)
            {
                throw new InvalidOperationException($"Cannot get field as List.  Field value's type is {ValueType}.");
            }

            if (_fieldValue == null)
            {
                return ValueList;
            }

            List<FormField> fieldList = new List<FormField>();
            foreach (var fieldValue in _fieldValue.ValueArray)
            {
                fieldList.Add(new FormField(null, fieldValue, _readResults));
            }

            return fieldList;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="Dictionary{TKey, TValue}"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="Dictionary{TKey, TValue}"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="FieldValueType.Dictionary"/>.</exception>
        public IReadOnlyDictionary<string, FormField> AsDictionary()
        {
            if (ValueType != FieldValueType.Dictionary)
            {
                throw new InvalidOperationException($"Cannot get field as Dictionary.  Field value's type is {ValueType}.");
            }

            if (_fieldValue == null)
            {
                return ValueDictionary;
            }

            Dictionary<string, FormField> fieldDictionary = new Dictionary<string, FormField>();

            foreach (var kvp in _fieldValue.ValueObject)
            {
                fieldDictionary[kvp.Key] = new FormField(kvp.Key, kvp.Value, _readResults);
            }

            return fieldDictionary;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="SelectionMarkState"/>.
        /// </summary>
        /// <returns>The value of the field converted to <see cref="SelectionMarkState"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="FieldValueType.SelectionMark"/>.</exception>
        public SelectionMarkState AsSelectionMarkState()
        {
            if (ValueType != FieldValueType.SelectionMark)
            {
                throw new InvalidOperationException($"Cannot get field as SelectionMark.  Field value's type is {ValueType}.");
            }

            if (_fieldValue == null)
            {
                return ValueSelectionMark;
            }

            if (!_fieldValue.ValueSelectionMark.HasValue)
            {
                throw new InvalidOperationException($"Field value is null.");
            }

            return _fieldValue.ValueSelectionMark.Value;
        }
    }
}

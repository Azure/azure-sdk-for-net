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
        /// Initializes a new instance of the <see cref="FieldValue"/> structure. This constructor
        /// is intended to be used for internal testing only.
        /// </summary>
        /// <param name="type">The field type.</param>
        internal FieldValue(FieldValueType type)
            : this()
        {
            ValueType = type;
            _fieldValue = new FieldValue_internal(type);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure. This constructor
        /// is intended to be used for mocking only.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        /// <param name="type">The data type of the field value.</param>
        internal FieldValue(string value, FieldValueType type)
            : this()
        {
            if (type != FieldValueType.String && type != FieldValueType.PhoneNumber && type != FieldValueType.CountryRegion)
            {
                throw new ArgumentException($"Specified {nameof(type)} does not support string value ({type}).");
            }

            ValueString = value;
            ValueType = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure. This constructor
        /// is intended to be used for mocking only.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        internal FieldValue(long value)
            : this()
        {
            ValueType = FieldValueType.Int64;
            ValueInteger = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure. This constructor
        /// is intended to be used for mocking only.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        internal FieldValue(float value)
            : this()
        {
            ValueType = FieldValueType.Float;
            ValueNumber = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure. This constructor
        /// is intended to be used for mocking only.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        internal FieldValue(DateTime value)
            : this()
        {
            ValueType = FieldValueType.Date;
            ValueDate = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure. This constructor
        /// is intended to be used for mocking only.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        internal FieldValue(TimeSpan value)
            : this()
        {
            ValueType = FieldValueType.Time;
            ValueTime = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure. This constructor
        /// is intended to be used for mocking only.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        internal FieldValue(IReadOnlyList<FormField> value)
            : this()
        {
            ValueType = FieldValueType.List;
            ValueList = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure. This constructor
        /// is intended to be used for mocking only.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        internal FieldValue(IReadOnlyDictionary<string, FormField> value)
            : this()
        {
            ValueType = FieldValueType.Dictionary;
            ValueDictionary = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure. This constructor
        /// is intended to be used for mocking only.
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

            // Use when mocking
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

            // Use when mocking
            if (_fieldValue == null)
            {
                return ValueInteger;
            }

            if (!_fieldValue.ValueInteger.HasValue)
            {
                throw new InvalidOperationException($"Value was extracted from the form, but cannot be normalized to {nameof(FieldValueType.Int64)} type. Consider accessing the `ValueData.text` property for a textual representation of the value.");
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

            // Use when mocking
            if (_fieldValue == null)
            {
                return ValueNumber;
            }

            if (!_fieldValue.ValueNumber.HasValue)
            {
                // Workaround for receipts that was never deleted and got shipped in 3.0.0 GA so we need to maintain
                if (float.TryParse(_fieldValue.Text.TrimStart('$'), out float parsedFloat))
                {
                    return parsedFloat;
                }
                else
                {
                    throw new InvalidOperationException($"Value was extracted from the form, but cannot be normalized to {nameof(FieldValueType.Float)} type. Consider accessing the `ValueData.text` property for a textual representation of the value.");
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

            // Use when mocking
            if (_fieldValue == null)
            {
                return ValueDate;
            }

            if (!_fieldValue.ValueDate.HasValue)
            {
                throw new InvalidOperationException($"Value was extracted from the form, but cannot be normalized to {nameof(FieldValueType.Date)} type. Consider accessing the `ValueData.text` property for a textual representation of the value.");
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

            // Use when mocking
            if (_fieldValue == null)
            {
                return ValueTime;
            }

            if (!_fieldValue.ValueTime.HasValue)
            {
                throw new InvalidOperationException($"Value was extracted from the form, but cannot be normalized to {nameof(FieldValueType.Time)} type. Consider accessing the `ValueData.text` property for a textual representation of the value.");
            }

            return _fieldValue.ValueTime.Value;
        }

        /// <summary>
        /// Gets the value of the field as a phone number <see cref="string"/>.
        /// </summary>
        /// <returns>The value of the field converted to a phone number <see cref="string"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="FieldValueType.PhoneNumber"/>.</exception>
        public string AsPhoneNumber()
        {
            if (ValueType != FieldValueType.PhoneNumber)
            {
                throw new InvalidOperationException($"Cannot get field as PhoneNumber.  Field value's type is {ValueType}.");
            }

            // Use when mocking
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

            // Use when mocking
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

            // Use when mocking
            if (_fieldValue == null)
            {
                return ValueDictionary;
            }

            Dictionary<string, FormField> fieldDictionary = new Dictionary<string, FormField>();

            foreach (var kvp in _fieldValue.ValueObject)
            {
                if (kvp.Value == null)
                {
                    fieldDictionary[kvp.Key] = null;
                }
                else
                {
                    fieldDictionary[kvp.Key] = new FormField(kvp.Key, kvp.Value, _readResults);
                }
            }

            return fieldDictionary;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="SelectionMarkState"/>.
        /// </summary>
        /// <returns>The value of the field converted to <see cref="SelectionMarkState"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="FieldValueType.SelectionMark"/>.</exception>
        /// <remarks>
        /// This method is only available for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/> and newer.
        /// </remarks>
        public SelectionMarkState AsSelectionMarkState()
        {
            if (ValueType != FieldValueType.SelectionMark)
            {
                throw new InvalidOperationException($"Cannot get field as SelectionMark.  Field value's type is {ValueType}.");
            }

            // Use when mocking
            if (_fieldValue == null)
            {
                return ValueSelectionMark;
            }

            if (!_fieldValue.ValueSelectionMark.HasValue)
            {
                throw new InvalidOperationException($"Value was extracted from the form, but cannot be normalized to {nameof(FieldValueType.SelectionMark)} type. Consider accessing the `ValueData.text` property for a textual representation of the value.");
            }

            return _fieldValue.ValueSelectionMark.Value;
        }

        /// <summary>
        /// Gets the value of the field as an ISO 3166-1 alpha-3 country code <see cref="string"/>.
        /// </summary>
        /// <returns>The value of the field converted to an ISO 3166-1 alpha-3 country code <see cref="string"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="FieldValueType.CountryRegion"/>.</exception>
        public string AsCountryRegion()
        {
            if (ValueType != FieldValueType.CountryRegion)
            {
                throw new InvalidOperationException($"Cannot get field as country code.  Field value's type is {ValueType}.");
            }

            // Use when mocking
            if (_fieldValue == null)
            {
                return ValueString;
            }

            return _fieldValue.ValueCountryRegion;
        }
    }
}

﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private readonly IReadOnlyList<ReadResult_internal> _readResults;

        internal FieldValue(FieldValue_internal fieldValue, IReadOnlyList<ReadResult_internal> readResults)
        {
            Type = fieldValue.Type;
            _fieldValue = fieldValue;
            _readResults = readResults;
        }

        /// <summary>
        /// The data type of the field value.
        /// </summary>
        public FieldValueType Type { get; }

        /// <summary>
        /// Gets the value of the field as a <see cref="string"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="string"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="Type"/> is not <see cref="FieldValueType.StringType"/>.</exception>
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
        /// <returns>The value of the field converted to an <see cref="int"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="Type"/> is not <see cref="FieldValueType.IntegerType"/> or when the value is <c>null</c>.</exception>
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
        /// <returns>The value of the field converted to a <see cref="float"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="Type"/> is not <see cref="FieldValueType.FloatType"/>.</exception>
        public float AsFloat()
        {
            if (Type != FieldValueType.FloatType)
            {
                throw new InvalidOperationException($"Cannot get field as Float.  Field value's type is {Type}.");
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
        /// <exception cref="InvalidOperationException">Thrown when <see cref="Type"/> is not <see cref="FieldValueType.DateType"/> or when the value is <c>null</c>.</exception>
        public DateTime AsDate()
        {
            if (Type != FieldValueType.DateType)
            {
                throw new InvalidOperationException($"Cannot get field as Date.  Field value's type is {Type}.");
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
        /// <exception cref="InvalidOperationException">Thrown when <see cref="Type"/> is not <see cref="FieldValueType.TimeType"/> or when the value is <c>null</c>.</exception>
        public TimeSpan AsTime()
        {
            if (Type != FieldValueType.TimeType)
            {
                throw new InvalidOperationException($"Cannot get field as Time.  Field value's type is {Type}.");
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
        /// <exception cref="InvalidOperationException">Thrown when <see cref="Type"/> is not <see cref="FieldValueType.StringType"/>.</exception>
        public string AsPhoneNumber()
        {
            if (Type != FieldValueType.PhoneNumberType)
            {
                throw new InvalidOperationException($"Cannot get field as PhoneNumber.  Field value's type is {Type}.");
            }

            return _fieldValue.ValuePhoneNumber;
        }

        /// <summary>
        /// Gets the value of the field as an <see cref="IReadOnlyList{T}"/>.
        /// </summary>
        /// <returns>The value of the field converted to an <see cref="IReadOnlyList{T}"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="Type"/> is not <see cref="FieldValueType.ListType"/>.</exception>
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
        /// Gets the value of the field as a <see cref="Dictionary{TKey, TValue}"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="Dictionary{TKey, TValue}"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="Type"/> is not <see cref="FieldValueType.DictionaryType"/>.</exception>
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

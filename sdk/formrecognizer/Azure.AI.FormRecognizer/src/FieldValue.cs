// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

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
#pragma warning disable CA1822
        public DateTime AsDate()
#pragma warning restore CA1822
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <returns></returns>
#pragma warning disable CA1822
        public TimeSpan AsTime()
#pragma warning restore CA1822
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the value of the field as a phone number <see cref="string"/>.
        /// </summary>
        /// <returns></returns>
#pragma warning disable CA1822
        public string AsPhoneNumber()
#pragma warning restore CA1822
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
#pragma warning disable CA1822
        public IReadOnlyList<FieldValue> AsList()
#pragma warning restore CA1822
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
#pragma warning disable CA1822
        public IReadOnlyDictionary<string, FieldValue> AsDictionary()
#pragma warning restore CA1822
        {
            throw new NotImplementedException();
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Azure.Core.Json;

namespace Azure
{
    public partial class DynamicData
    {
        // Operators that cast from DynamicData to another type
        private static readonly Dictionary<Type, MethodInfo> CastFromOperators = typeof(DynamicData)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(method => method.Name == "op_Explicit" || method.Name == "op_Implicit")
            .ToDictionary(method => method.ReturnType);

        /// <summary>
        /// Converts the value to a <see cref="bool"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator bool(DynamicData value)
        {
            try
            {
                return value._element.GetBoolean();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidCastExceptionText(typeof(bool), value._element), e);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="int"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator int(DynamicData value)
        {
            try
            {
                return value._element.GetInt32();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidCastExceptionText(typeof(int), value._element), e);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="long"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator long(DynamicData value)
        {
            try
            {
                return value._element.GetInt64();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidCastExceptionText(typeof(long), value._element), e);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="string"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator string?(DynamicData value)
        {
            try
            {
                return value._element.GetString();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidCastExceptionText(typeof(string), value._element), e);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="float"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator float(DynamicData value)
        {
            try
            {
                return value._element.GetSingle();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidCastExceptionText(typeof(float), value._element), e);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="double"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator double(DynamicData value)
        {
            try
            {
                return value._element.GetDouble();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidCastExceptionText(typeof(double), value._element), e);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="bool"/> or null.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator bool?(DynamicData value)
        {
            try
            {
                return value._element.ValueKind == JsonValueKind.Null ? null : value._element.GetBoolean();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidCastExceptionText(typeof(bool?), value._element), e);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="int"/> or null.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator int?(DynamicData value)
        {
            try
            {
                return value._element.ValueKind == JsonValueKind.Null ? null : value._element.GetInt32();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidCastExceptionText(typeof(int?), value._element), e);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="long"/> or null.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator long?(DynamicData value)
        {
            try
            {
                return value._element.ValueKind == JsonValueKind.Null ? null : value._element.GetInt64();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidCastExceptionText(typeof(long?), value._element), e);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="float"/> or null.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator float?(DynamicData value)
        {
            try
            {
                return value._element.ValueKind == JsonValueKind.Null ? null : value._element.GetSingle();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidCastExceptionText(typeof(float?), value._element), e);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="double"/> or null.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator double?(DynamicData value)
        {
            try
            {
                return value._element.ValueKind == JsonValueKind.Null ? null : value._element.GetDouble();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidCastExceptionText(typeof(double?), value._element), e);
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="DynamicData"/> and <see cref="object"/> have the same value.
        /// </summary>
        /// <remarks>
        /// This operator calls through to <see cref="DynamicData.Equals(object?)"/> when DynamicData is on the left-hand
        /// side of the operation.  <see cref="DynamicData.Equals(object?)"/> has value semantics when the DynamicData represents
        /// a JSON primitive, i.e. string, bool, number, or null, and reference semantics otherwise, i.e. for objects and arrays.
        ///
        /// Please note that if DynamicData is on the right-hand side of a <c>==</c> operation, this operator will not be invoked.
        /// Because of this the result of a <c>==</c> comparison with <c>null</c> on the left and a DynamicData instance on the right will return <c>false</c>.
        /// </remarks>
        /// <param name="left">The <see cref="DynamicData"/> to compare.</param>
        /// <param name="right">The <see cref="object"/> to compare.</param>
        /// <returns><c>true</c> if the value of <paramref name="left"/> is the same as the value of <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator ==(DynamicData? left, object? right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether the specified <see cref="DynamicData"/> and <see cref="object"/> have different values.
        /// </summary>
        /// <remarks>
        /// This operator calls through to <see cref="DynamicData.Equals(object?)"/> when DynamicData is on the left-hand
        /// side of the operation.  <see cref="DynamicData.Equals(object?)"/> has value semantics when the DynamicData represents
        /// a JSON primitive, i.e. string, bool, number, or null, and reference semantics otherwise, i.e. for objects and arrays.
        ///
        /// Please note that if DynamicData is on the right-hand side of a <c>!=</c> operation, this operator will not be invoked.
        /// Because of this the result of a <c>!=</c> comparison with <c>null</c> on the left and a DynamicData instance on the right will return <c>true</c>.
        /// </remarks>
        /// <param name="left">The <see cref="DynamicData"/> to compare.</param>
        /// <param name="right">The <see cref="object"/> to compare.</param>
        /// <returns><c>true</c> if the value of <paramref name="left"/> is different from the value of <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator !=(DynamicData? left, object? right) => !(left == right);

        private static string GetInvalidCastExceptionText(Type target, MutableJsonElement element)
        {
            return $"Unable to cast element to '{target}'.  Element has kind '{element.ValueKind}'.";
        }
    }
}

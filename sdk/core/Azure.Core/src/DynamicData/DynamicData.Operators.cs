// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Core.Json;

namespace Azure.Core.Serialization
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
                throw new InvalidCastException(GetInvalidKindExceptionText(typeof(bool), value._element), e);
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
                throw new InvalidCastException(GetInvalidKindExceptionText(typeof(string), value._element), e);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator byte(DynamicData value)
        {
            try
            {
                return value._element.GetByte();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidKindExceptionText(typeof(byte), value._element), e);
            }
            catch (FormatException formatException)
            {
                throw new InvalidCastException(GetInvalidFormatExceptionText(typeof(byte), value._element), formatException);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="sbyte"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator sbyte(DynamicData value)
        {
            try
            {
                return value._element.GetSByte();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidKindExceptionText(typeof(sbyte), value._element), e);
            }
            catch (FormatException formatException)
            {
                throw new InvalidCastException(GetInvalidFormatExceptionText(typeof(sbyte), value._element), formatException);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="short"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator short(DynamicData value)
        {
            try
            {
                return value._element.GetInt16();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidKindExceptionText(typeof(short), value._element), e);
            }
            catch (FormatException formatException)
            {
                throw new InvalidCastException(GetInvalidFormatExceptionText(typeof(short), value._element), formatException);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="ushort"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator ushort(DynamicData value)
        {
            try
            {
                return value._element.GetUInt16();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidKindExceptionText(typeof(ushort), value._element), e);
            }
            catch (FormatException formatException)
            {
                throw new InvalidCastException(GetInvalidFormatExceptionText(typeof(ushort), value._element), formatException);
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
                throw new InvalidCastException(GetInvalidKindExceptionText(typeof(int), value._element), e);
            }
            catch (FormatException formatException)
            {
                throw new InvalidCastException(GetInvalidFormatExceptionText(typeof(int), value._element), formatException);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator uint(DynamicData value)
        {
            try
            {
                return value._element.GetUInt32();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidKindExceptionText(typeof(uint), value._element), e);
            }
            catch (FormatException formatException)
            {
                throw new InvalidCastException(GetInvalidFormatExceptionText(typeof(uint), value._element), formatException);
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
                throw new InvalidCastException(GetInvalidKindExceptionText(typeof(long), value._element), e);
            }
            catch (FormatException formatException)
            {
                throw new InvalidCastException(GetInvalidFormatExceptionText(typeof(long), value._element), formatException);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator ulong(DynamicData value)
        {
            try
            {
                return value._element.GetUInt64();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidKindExceptionText(typeof(ulong), value._element), e);
            }
            catch (FormatException formatException)
            {
                throw new InvalidCastException(GetInvalidFormatExceptionText(typeof(ulong), value._element), formatException);
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
                throw new InvalidCastException(GetInvalidKindExceptionText(typeof(float), value._element), e);
            }
            catch (FormatException formatException)
            {
                throw new InvalidCastException(GetInvalidFormatExceptionText(typeof(float), value._element), formatException);
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
                throw new InvalidCastException(GetInvalidKindExceptionText(typeof(double), value._element), e);
            }
            catch (FormatException formatException)
            {
                throw new InvalidCastException(GetInvalidFormatExceptionText(typeof(double), value._element), formatException);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator decimal(DynamicData value)
        {
            try
            {
                return value._element.GetDecimal();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidKindExceptionText(typeof(decimal), value._element), e);
            }
            catch (FormatException formatException)
            {
                throw new InvalidCastException(GetInvalidFormatExceptionText(typeof(decimal), value._element), formatException);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator DateTime(DynamicData value)
        {
            try
            {
                if (value._options.DateTimeFormat.Equals(UnixFormat, StringComparison.InvariantCultureIgnoreCase))
                {
                    return value.ConvertTo<DateTime>();
                }

                return value._element.GetDateTime();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidKindExceptionText(typeof(DateTime), value._element), e);
            }
            catch (FormatException formatException)
            {
                throw new InvalidCastException(GetInvalidFormatExceptionText(typeof(DateTime), value._element), formatException);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator DateTimeOffset(DynamicData value)
        {
            try
            {
                if (value._options.DateTimeFormat.Equals(UnixFormat, StringComparison.InvariantCultureIgnoreCase))
                {
                    return value.ConvertTo<DateTimeOffset>();
                }

                return value._element.GetDateTimeOffset();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidKindExceptionText(typeof(DateTimeOffset), value._element), e);
            }
            catch (FormatException formatException)
            {
                throw new InvalidCastException(GetInvalidFormatExceptionText(typeof(DateTimeOffset), value._element), formatException);
            }
        }

        /// <summary>
        /// Converts the value to a <see cref="Guid"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator Guid(DynamicData value)
        {
            try
            {
                return value._element.GetGuid();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidCastException(GetInvalidKindExceptionText(typeof(Guid), value._element), e);
            }
            catch (FormatException formatException)
            {
                throw new InvalidCastException(GetInvalidFormatExceptionText(typeof(Guid), value._element), formatException);
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
        /// </remarks>
        /// <param name="left">The <see cref="DynamicData"/> to compare.</param>
        /// <param name="right">The <see cref="object"/> to compare.</param>
        /// <returns><c>true</c> if the value of <paramref name="left"/> is different from the value of <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator !=(DynamicData? left, object? right) => !(left == right);

        private static string GetInvalidKindExceptionText(Type target, MutableJsonElement element)
        {
            return $"Unable to cast element to '{target}'.  Element has kind '{element.ValueKind}'.";
        }

        private static string GetInvalidFormatExceptionText(Type target, MutableJsonElement element)
        {
            return $"Unable to cast element to '{target}'.  Element has value '{element}'.";
        }
    }
}

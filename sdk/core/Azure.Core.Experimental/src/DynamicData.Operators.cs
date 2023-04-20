﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Azure.Core.Json;

namespace Azure.Core.Dynamic
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

        private static string GetInvalidCastExceptionText(Type target, MutableJsonElement element)
        {
            return $"Unable to cast element to '{target}'.  Element has kind '{element.ValueKind}'.";
        }
    }
}

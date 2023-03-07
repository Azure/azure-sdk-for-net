// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace Azure.Core.Dynamic
{
    public partial class DynamicJson
    {
        // Operators that cast from DynamicJson to another type
        private static readonly Dictionary<Type, MethodInfo> CastFromOperators = typeof(DynamicJson)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(method => method.Name == "op_Explicit" || method.Name == "op_Implicit")
            .ToDictionary(method => method.ReturnType);

        /// <summary>
        /// Converts the value to a <see cref="bool"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator bool(DynamicJson value) => value._element.GetBoolean();

        /// <summary>
        /// Converts the value to a <see cref="int"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator int(DynamicJson value) => value._element.GetInt32();

        /// <summary>
        /// Converts the value to a <see cref="long"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator long(DynamicJson value) => value._element.GetInt64();

        /// <summary>
        /// Converts the value to a <see cref="string"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator string?(DynamicJson value)
        {
            if (value._element.ValueKind == JsonValueKind.String)
            {
                return value._element.GetString();
            }

            if (value._element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return value._element.ToString();
        }

        /// <summary>
        /// Converts the value to a <see cref="float"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator float(DynamicJson value) => value._element.GetSingle();

        /// <summary>
        /// Converts the value to a <see cref="double"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator double(DynamicJson value) => value._element.GetDouble();

        /// <summary>
        /// Converts the value to a <see cref="bool"/> or null.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator bool?(DynamicJson value) => value._element.ValueKind == JsonValueKind.Null ? null : value._element.GetBoolean();

        /// <summary>
        /// Converts the value to a <see cref="int"/> or null.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator int?(DynamicJson value) => value._element.ValueKind == JsonValueKind.Null ? null : value._element.GetInt32();

        /// <summary>
        /// Converts the value to a <see cref="long"/> or null.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator long?(DynamicJson value) => value._element.ValueKind == JsonValueKind.Null ? null : value._element.GetInt64();

        /// <summary>
        /// Converts the value to a <see cref="float"/> or null.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator float?(DynamicJson value) => value._element.ValueKind == JsonValueKind.Null ? null : value._element.GetSingle();

        /// <summary>
        /// Converts the value to a <see cref="double"/> or null.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator double?(DynamicJson value) => value._element.ValueKind == JsonValueKind.Null ? null : value._element.GetDouble();
    }
}

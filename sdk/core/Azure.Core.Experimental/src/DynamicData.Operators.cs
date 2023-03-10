// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace Azure.Core.Dynamic
{
    public partial class DynamicData
    {
        // Operators that cast from DynamicJson to another type
        private static readonly Dictionary<Type, MethodInfo> CastFromOperators = typeof(DynamicData)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(method => method.Name == "op_Explicit" || method.Name == "op_Implicit")
            .ToDictionary(method => method.ReturnType);

        /// <summary>
        /// Converts the value to a <see cref="bool"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator bool(DynamicData value) => value._element.GetBoolean();

        /// <summary>
        /// Converts the value to a <see cref="int"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator int(DynamicData value) => value._element.GetInt32();

        /// <summary>
        /// Converts the value to a <see cref="long"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator long(DynamicData value) => value._element.GetInt64();

        /// <summary>
        /// Converts the value to a <see cref="string"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator string?(DynamicData value) => value._element.GetString();

        /// <summary>
        /// Converts the value to a <see cref="float"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator float(DynamicData value) => value._element.GetSingle();

        /// <summary>
        /// Converts the value to a <see cref="double"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator double(DynamicData value) => value._element.GetDouble();

        /// <summary>
        /// Converts the value to a <see cref="bool"/> or null.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator bool?(DynamicData value) => value._element.ValueKind == ObjectValueKind.Null ? null : value._element.GetBoolean();

        /// <summary>
        /// Converts the value to a <see cref="int"/> or null.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator int?(DynamicData value) => value._element.ValueKind == ObjectValueKind.Null ? null : value._element.GetInt32();

        /// <summary>
        /// Converts the value to a <see cref="long"/> or null.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator long?(DynamicData value) => value._element.ValueKind == ObjectValueKind.Null ? null : value._element.GetInt64();

        /// <summary>
        /// Converts the value to a <see cref="float"/> or null.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator float?(DynamicData value) => value._element.ValueKind == ObjectValueKind.Null ? null : value._element.GetSingle();

        /// <summary>
        /// Converts the value to a <see cref="double"/> or null.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator double?(DynamicData value) => value._element.ValueKind == ObjectValueKind.Null ? null : value._element.GetDouble();
    }
}

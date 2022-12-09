// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// A mutable representation of a JSON value.
    /// </summary>
    public partial class JsonData : IDynamicMetaObjectProvider, IEquatable<JsonData>
    {
        /// <summary>
        /// Converts the value to a <see cref="bool"/>
        /// </summary>
        /// <param name="json">The value to convert.</param>
        public static explicit operator bool(JsonData json) => json.GetBoolean();

        /// <summary>
        /// Converts the value to a <see cref="int"/>
        /// </summary>
        /// <param name="json">The value to convert.</param>
        public static explicit operator int(JsonData json) => json.GetIn32();

        /// <summary>
        /// Converts the value to a <see cref="long"/>
        /// </summary>
        /// <param name="json">The value to convert.</param>
        public static explicit operator long(JsonData json) => json.GetLong();

        /// <summary>
        /// Converts the value to a <see cref="string"/>
        /// </summary>
        /// <param name="json">The value to convert.</param>
        public static explicit operator string?(JsonData json) => json.GetString();

        /// <summary>
        /// Converts the value to a <see cref="float"/>
        /// </summary>
        /// <param name="json">The value to convert.</param>
        public static explicit operator float(JsonData json) => json.GetFloat();

        /// <summary>
        /// Converts the value to a <see cref="double"/>
        /// </summary>
        /// <param name="json">The value to convert.</param>
        public static explicit operator double(JsonData json) => json.GetDouble();

        /// <summary>
        /// Converts the value to a <see cref="bool"/>
        /// </summary>
        /// <param name="json">The value to convert.</param>
        public static explicit operator bool?(JsonData json) => json.Kind == JsonValueKind.Null ? null : json.GetBoolean();

        /// <summary>
        /// Converts the value to a <see cref="int"/> or null.
        /// </summary>
        /// <param name="json">The value to convert.</param>
        public static explicit operator int?(JsonData json) => json.Kind == JsonValueKind.Null ? null : json.GetIn32();

        /// <summary>
        /// Converts the value to a <see cref="long"/> or null.
        /// </summary>
        /// <param name="json">The value to convert.</param>
        public static explicit operator long?(JsonData json) => json.Kind == JsonValueKind.Null ? null : json.GetLong();

        /// <summary>
        /// Converts the value to a <see cref="float"/> or null.
        /// </summary>
        /// <param name="json">The value to convert.</param>
        public static explicit operator float?(JsonData json) => json.Kind == JsonValueKind.Null ? null : json.GetFloat();

        /// <summary>
        /// Converts the value to a <see cref="double"/> or null.
        /// </summary>
        /// <param name="json">The value to convert.</param>
        public static explicit operator double?(JsonData json) => json.Kind == JsonValueKind.Null ? null : json.GetDouble();

        /// <summary>
        /// Returns true if a <see cref="JsonData"/> has the same value as a given string,
        /// and false otherwise.
        /// </summary>
        /// <param name="left">The <see cref="JsonData"/> to compare.</param>
        /// <param name="right">The <see cref="string"/> to compare.</param>
        /// <returns>True if the given JsonData represents the given string, and false otherwise.</returns>
        public static bool operator ==(JsonData? left, string? right)
        {
            if (left is null && right is null)
            {
                return true;
            }

            if (left is null || right is null)
            {
                return false;
            }

            return left.Kind == JsonValueKind.String && ((string?)left._value) == right;
        }

        /// <summary>
        /// Returns false if a <see cref="JsonData"/> has the same value as a given string,
        /// and true otherwise.
        /// </summary>
        /// <param name="left">The <see cref="JsonData"/> to compare.</param>
        /// <param name="right">The <see cref="string"/> to compare.</param>
        /// <returns>False if the given JsonData represents the given string, and false otherwise</returns>
        public static bool operator !=(JsonData? left, string? right) => !(left == right);

        /// <summary>
        /// Returns true if a <see cref="JsonData"/> has the same value as a given string,
        /// and false otherwise.
        /// </summary>
        /// <param name="left">The <see cref="string"/> to compare.</param>
        /// <param name="right">The <see cref="JsonData"/> to compare.</param>
        /// <returns>True if the given JsonData represents the given string, and false otherwise.</returns>
        public static bool operator ==(string? left, JsonData? right)
        {
            if (left is null && right is null)
            {
                return true;
            }

            if (left is null || right is null)
            {
                return false;
            }

            return right.Kind == JsonValueKind.String && ((string?)right._value) == left;
        }

        /// <summary>
        /// Returns false if a <see cref="JsonData"/> has the same value as a given string,
        /// and true otherwise.
        /// </summary>
        /// <param name="left">The <see cref="string"/> to compare.</param>
        /// <param name="right">The <see cref="JsonData"/> to compare.</param>
        /// <returns>False if the given JsonData represents the given string, and false otherwise</returns>
        public static bool operator !=(string? left, JsonData? right) => !(left == right);

        /// <summary>
        /// Returns true if a <see cref="JsonData"/> has the same value as a given int,
        /// and false otherwise.
        /// </summary>
        /// <param name="left">The <see cref="JsonData"/> to compare.</param>
        /// <param name="right">The <see cref="int"/> to compare.</param>
        /// <returns>True if the given JsonData represents the given int, and false otherwise.</returns>
        public static bool operator ==(JsonData? left, int right)
        {
            if (left is null)
            {
                return false;
            }

            return left.Kind == JsonValueKind.Number && ((int)left) == right;
        }

        /// <summary>
        /// Returns false if a <see cref="JsonData"/> has the same value as a given int,
        /// and true otherwise.
        /// </summary>
        /// <param name="left">The <see cref="JsonData"/> to compare.</param>
        /// <param name="right">The <see cref="int"/> to compare.</param>
        /// <returns>False if the given JsonData represents the given string, and false otherwise</returns>
        public static bool operator !=(JsonData? left, int right) => !(left == right);

        /// <summary>
        /// Returns true if a <see cref="JsonData"/> has the same value as a given int,
        /// and false otherwise.
        /// </summary>
        /// <param name="left">The <see cref="int"/> to compare.</param>
        /// <param name="right">The <see cref="JsonData"/> to compare.</param>
        /// <returns>True if the given JsonData represents the given int, and false otherwise.</returns>
        public static bool operator ==(int left, JsonData? right)
        {
            if (right is null)
            {
                return false;
            }

            return right.Kind == JsonValueKind.Number && ((int)right) == left;
        }

        /// <summary>
        /// Returns false if a <see cref="JsonData"/> has the same value as a given int,
        /// and true otherwise.
        /// </summary>
        /// <param name="left">The <see cref="int"/> to compare.</param>
        /// <param name="right">The <see cref="JsonData"/> to compare.</param>
        /// <returns>False if the given JsonData represents the given int, and false otherwise</returns>
        public static bool operator !=(int left, JsonData? right) => !(left == right);
    }
}

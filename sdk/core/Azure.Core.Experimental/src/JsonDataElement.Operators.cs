// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core.Dynamic
{
    public partial struct JsonDataElement
    {
        /// <summary>
        /// Converts the value to a <see cref="bool"/>
        /// </summary>
        /// <param name="element">The value to convert.</param>
        public static implicit operator bool(JsonDataElement element) => element.GetBoolean();

        /// <summary>
        /// Converts the value to a <see cref="int"/>
        /// </summary>
        /// <param name="element">The value to convert.</param>
        public static implicit operator int(JsonDataElement element) => element.GetInt32();

        /// <summary>
        /// Converts the value to a <see cref="long"/>
        /// </summary>
        /// <param name="element">The value to convert.</param>
        public static implicit operator long(JsonDataElement element) => element.GetInt64();

        /// <summary>
        /// Converts the value to a <see cref="string"/>
        /// </summary>
        /// <param name="element">The value to convert.</param>
        public static implicit operator string?(JsonDataElement element) => element.GetString();

        /// <summary>
        /// Converts the value to a <see cref="float"/>
        /// </summary>
        /// <param name="element">The value to convert.</param>
        public static implicit operator float(JsonDataElement element) => element.GetFloat();

        /// <summary>
        /// Converts the value to a <see cref="double"/>
        /// </summary>
        /// <param name="element">The value to convert.</param>
        public static implicit operator double(JsonDataElement element) => element.GetDouble();

        ///// <summary>
        ///// Converts the value to a <see cref="bool"/> or null.
        ///// </summary>
        ///// <param name="element">The value to convert.</param>
        //public static implicit operator bool?(JsonDataElement element) => element.Kind == JsonValueKind.Null ? null : element.GetBoolean();

        ///// <summary>
        ///// Converts the value to a <see cref="int"/> or null.
        ///// </summary>
        ///// <param name="element">The value to convert.</param>
        //public static implicit operator int?(JsonDataElement element) => element.Kind == JsonValueKind.Null ? null : element.GetInt32();

        ///// <summary>
        ///// Converts the value to a <see cref="long"/> or null.
        ///// </summary>
        ///// <param name="element">The value to convert.</param>
        //public static implicit operator long?(JsonDataElement element) => element.Kind == JsonValueKind.Null ? null : element.GetLong();

        ///// <summary>
        ///// Converts the value to a <see cref="float"/> or null.
        ///// </summary>
        ///// <param name="element">The value to convert.</param>
        //public static implicit operator float?(JsonDataElement element) => element.Kind == JsonValueKind.Null ? null : element.GetFloat();

        ///// <summary>
        ///// Converts the value to a <see cref="double"/> or null.
        ///// </summary>
        ///// <param name="element">The value to convert.</param>
        //public static implicit operator double?(JsonDataElement element) => element.Kind == JsonValueKind.Null ? null : element.GetDouble();
    }
}

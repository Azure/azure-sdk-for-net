// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Abstract class for empty classes.
    /// </summary>
    public abstract class EmptyPlaceholderObject: IUtf8JsonSerializable
    {
        /// <summary>
        /// Generic value.
        /// </summary>
        protected object Value { get; set; }

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="value"></param>
        protected EmptyPlaceholderObject(object value)
        {
            Value = value;
        }

        /// <inheritdoc />
#pragma warning disable AZC0014 // Avoid using banned types in public API
        public void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
#pragma warning restore AZC0014 // Avoid using banned types in public API
    }
}

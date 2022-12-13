// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// A dynamic abstraction over content data that may have an underlying
    /// format of JSON or other format.
    /// </summary>
    public abstract class DynamicData
    {
        /// <summary>
        /// Writes the data to the provided writer as a JSON value.
        /// </summary>
        /// <param name="writer">The writer to which to write the document.</param>
        /// <param name="data">The dynamic data value to write.</param>
        public static void WriteTo(Utf8JsonWriter writer, DynamicData data)
        {
            data.WriteTo(writer);
        }

        internal abstract void WriteTo(Utf8JsonWriter writer);
    }
}

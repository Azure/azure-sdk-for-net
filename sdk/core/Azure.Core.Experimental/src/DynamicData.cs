// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// A dynamic abstraction over content data.  Deriving types are implemented
    /// for a specific format, such as JSON or XML.
    ///
    /// This and related types are not intended to be mocked.
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

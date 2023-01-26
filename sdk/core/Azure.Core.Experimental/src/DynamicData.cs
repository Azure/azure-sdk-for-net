// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

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
        /// Writes the data to the provided stream.
        /// </summary>
        /// <param name="stream">The stream to which to write the document.</param>
        /// <param name="data">The dynamic data value to write.</param>
        public static void WriteTo(Stream stream, DynamicData data)
        {
            data.WriteTo(stream);
        }

        internal abstract void WriteTo(Stream stream);
    }
}

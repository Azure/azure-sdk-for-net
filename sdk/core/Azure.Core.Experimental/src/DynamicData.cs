// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Dynamic;
using System.IO;

// TODO: remove
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// A dynamic abstraction over content data.  Deriving types are implemented
    /// for a specific format, such as JSON or XML.
    ///
    /// This and related types are not intended to be mocked.
    /// </summary>
    public abstract partial class DynamicData : IDynamicMetaObjectProvider
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

        ///// <inheritdoc />
        //public abstract DynamicMetaObject GetMetaObject(Expression parameter);

        /// <summary>
        /// Writes the data to the provided stream.
        /// </summary>
        /// <param name="stream">The stream to which to write the document.</param>
        public abstract void WriteTo(Stream stream);

        public abstract object? GetProperty(string name);

        public abstract object? SetProperty(string name, object value);

        public abstract IEnumerable GetEnumerable();

        public abstract object? GetViaIndexer(object index);

        public abstract object? SetElement(int index, object value);

        public object? SetViaIndexer(object index, object value)
        {
            switch (index)
            {
                case string propertyName:
                    return SetProperty(propertyName, value);
                case int arrayIndex:
                    return SetElement(arrayIndex, value);
            }

            throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        }

        public abstract T ConvertTo<T>();
    }
}

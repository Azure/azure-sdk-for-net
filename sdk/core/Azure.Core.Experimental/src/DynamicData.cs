// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

// TODO: remove
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ** TODO
//   - ToDynamic() extensions
//   - Move casing logic into base class?  Should there be common Options?
//   - Do we want these APIs public?
//   - Should cast move into base type?
//   - Is there stuff in MutableJsonElement that should move? E.g. validation of element type asumptions?
//   - Should base class be IDisposable?
//   - Should operators move to the base class?

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
        private static readonly MethodInfo GetPropertyMethod = typeof(DynamicData).GetMethod(nameof(GetProperty), BindingFlags.Public | BindingFlags.Instance)!;
        private static readonly MethodInfo SetPropertyMethod = typeof(DynamicData).GetMethod(nameof(SetProperty), BindingFlags.Public | BindingFlags.Instance)!;
        private static readonly MethodInfo GetEnumerableMethod = typeof(DynamicData).GetMethod(nameof(GetEnumerable), BindingFlags.Public | BindingFlags.Instance)!;
        private static readonly MethodInfo GetViaIndexerMethod = typeof(DynamicData).GetMethod(nameof(GetViaIndexer), BindingFlags.Public | BindingFlags.Instance)!;
        private static readonly MethodInfo SetViaIndexerMethod = typeof(DynamicData).GetMethod(nameof(SetViaIndexer), BindingFlags.Public | BindingFlags.Instance)!;

        /// <summary>
        /// Writes the data to the provided stream.
        /// </summary>
        /// <param name="stream">The stream to which to write the document.</param>
        /// <param name="data">The dynamic data value to write.</param>
        public static void WriteTo(Stream stream, DynamicData data)
        {
            data.WriteTo(stream);
        }

        /// <summary>
        /// Writes the data to the provided stream.
        /// </summary>
        /// <param name="stream">The stream to which to write the document.</param>
        public abstract void WriteTo(Stream stream);

        public abstract object? GetProperty(string name);

        public abstract object? GetElement(int index);

        public abstract object? SetProperty(string name, object value);

        public abstract IEnumerable GetEnumerable();

        public object? GetViaIndexer(object index)
        {
            switch (index)
            {
                case string propertyName:
                    return GetProperty(propertyName);
                case int arrayIndex:
                    return GetElement(arrayIndex);
            }

            throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        }

        public abstract object? SetElement(int index, object value);

        public object? SetViaIndexer(object index, object value)
        {
            return index switch
            {
                string propertyName => SetProperty(propertyName, value),
                int arrayIndex => SetElement(arrayIndex, value),
                _ => throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}"),
            };
        }

        public abstract T ConvertTo<T>();
    }
}

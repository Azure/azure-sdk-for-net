// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;

namespace Azure.Search.Documents.Samples
{
    /// <summary>
    /// Indicates that the public properties of a model type should be serialized as camel-case in order to match
    /// the field names of a search index.
    /// </summary>
    /// <remarks>
    /// Types without this attribute are expected to have property names that exactly match their corresponding
    /// fields names in Azure Cognitive Search. Otherwise, it would not be possible to use instances of the type to populate
    /// the index.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
    public class SerializePropertyNamesAsCamelCaseAttribute : Attribute
    {
        /// <summary>
        /// Indicates whether the given type is annotated with SerializePropertyNamesAsCamelCaseAttribute.
        /// </summary>
        /// <typeparam name="T">The type to test.</typeparam>
        /// <returns>true if the given type is annotated with SerializePropertyNamesAsCamelCaseAttribute,
        /// false otherwise.</returns>
        public static bool IsDefinedOnType<T>() => IsDefinedOnType(typeof(T));

        /// <summary>
        /// Indicates whether the given type is annotated with SerializePropertyNamesAsCamelCaseAttribute.
        /// </summary>
        /// <param name="modelType">The type to test.</param>
        /// <returns>true if the given type is annotated with SerializePropertyNamesAsCamelCaseAttribute,
        /// false otherwise.</returns>
        public static bool IsDefinedOnType(Type modelType) =>
            modelType
                .GetTypeInfo()
                .GetCustomAttributes(typeof(SerializePropertyNamesAsCamelCaseAttribute), inherit: true)
                .Any();
    }
}

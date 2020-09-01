// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Defines extension methods for <see cref="DataType" />.
    /// </summary>
    public static class DataTypeExtensions
    {
        /// <summary>
        /// Indicates whether or not the given data type is a complex type.
        /// </summary>
        /// <param name="dataType">The data type to check.</param>
        /// <returns>
        /// <c>true</c> if the type represents a complex object or collection of complex objects; <c>false</c> otherwise.
        /// </returns>
        public static bool IsComplex(this DataType dataType) =>
            dataType == DataType.Complex || dataType == DataType.Collection(DataType.Complex);
    }
}

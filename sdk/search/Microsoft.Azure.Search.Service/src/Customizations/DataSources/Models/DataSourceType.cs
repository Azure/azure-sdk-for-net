// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Microsoft.Azure.Search.Common;
using Microsoft.Azure.Search.Serialization;
using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Defines the type of a datasource.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<DataSourceType>))]
    public struct DataSourceType : IEquatable<DataSourceType>
    {
        private readonly string _value;

        /// <summary>
        /// Indicates an Azure SQL datasource.
        /// </summary>
        public static readonly DataSourceType AzureSql = new DataSourceType("azuresql");

        /// <summary>
        /// Indicates a DocumentDB datasource.
        /// </summary>
        [Obsolete("This member is deprecated. Use CosmosDb instead")]
        public static readonly DataSourceType DocumentDb = new DataSourceType("documentdb");

        /// <summary>
        /// Indicates a CosmosDB datasource.
        /// </summary>
        public static readonly DataSourceType CosmosDb = new DataSourceType("cosmosdb");

        /// <summary>
        /// Indicates a Azure Blob datasource.
        /// </summary>
        public static readonly DataSourceType AzureBlob = new DataSourceType("azureblob");

        /// <summary>
        /// Indicates a Azure Table datasource.
        /// </summary>
        public static readonly DataSourceType AzureTable = new DataSourceType("azuretable");

        private DataSourceType(string typeName)
        {
            Throw.IfArgumentNull(typeName, nameof(typeName));
            _value = typeName;
        }

        /// <summary>
        /// Defines implicit conversion from string to DataSourceType.
        /// </summary>
        /// <param name="value">string to convert.</param>
        /// <returns>The string as a DataSourceType.</returns>
        public static implicit operator DataSourceType(string value) => new DataSourceType(value);

        /// <summary>
        /// Defines explicit conversion from DataSourceType to string.
        /// </summary>
        /// <param name="dataSourceType">DataSourceType to convert.</param>
        /// <returns>The DataSourceType as a string.</returns>
        public static explicit operator string(DataSourceType dataSourceType) => dataSourceType.ToString();

        /// <summary>
        /// Compares two DataSourceType values for equality.
        /// </summary>
        /// <param name="lhs">The first DataSourceType to compare.</param>
        /// <param name="rhs">The second DataSourceType to compare.</param>
        /// <returns>true if the DataSourceType objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(DataSourceType lhs, DataSourceType rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two DataSourceType values for inequality.
        /// </summary>
        /// <param name="lhs">The first DataSourceType to compare.</param>
        /// <param name="rhs">The second DataSourceType to compare.</param>
        /// <returns>true if the DataSourceType objects are not equal; false otherwise.</returns>
        public static bool operator !=(DataSourceType lhs, DataSourceType rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the DataSourceType for equality with another DataSourceType.
        /// </summary>
        /// <param name="other">The DataSourceType with which to compare.</param>
        /// <returns><c>true</c> if the DataSourceType objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(DataSourceType other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is DataSourceType ? Equals((DataSourceType)obj) : false;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the DataSourceType.
        /// </summary>
        /// <returns>The DataSourceType as a string.</returns>
        public override string ToString() => _value;
    }
}

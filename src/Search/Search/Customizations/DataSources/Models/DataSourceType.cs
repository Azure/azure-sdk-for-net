// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;

    /// <summary>
    /// Defines the type of an Azure Search datasource.
    /// </summary>
    public sealed class DataSourceType
    {
        /// <summary>
        /// Indicates an Azure SQL datasource.
        /// </summary>
        public static readonly DataSourceType AzureSql = new DataSourceType("azuresql");

        /// <summary>
        /// Indicates a DocumentDB datasource.
        /// </summary>
        public static readonly DataSourceType DocumentDb = new DataSourceType("documentdb");

        private readonly string _name;

        private DataSourceType(string typeName)
        {
            _name = typeName;
        }

        /// <summary>
        /// Defines implicit conversion from DataSourceType to string.
        /// </summary>
        /// <param name="type">DataSourceType to convert.</param>
        /// <returns>The name of the DataSourceType as a string.</returns>
        public static implicit operator string(DataSourceType type)
        {
            return type.ToString();
        }

        /// <summary>
        /// Returns the name of the DataSourceType in a form that can be used in an Azure Search datasource definition.
        /// </summary>
        /// <returns>The name of the DataSourceType as a string.</returns>
        public override string ToString()
        {
            return _name;
        }
    }
}

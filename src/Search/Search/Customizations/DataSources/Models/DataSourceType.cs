// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;

namespace Microsoft.Azure.Search.Models
{
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

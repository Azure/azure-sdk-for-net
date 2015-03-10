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
    /// Defines the data type of a field in an Azure Search index.
    /// </summary>
    public sealed class DataType
    {
        /// <summary>
        /// Indicates that a field contains a string.
        /// </summary>
        public static readonly DataType String = new DataType("Edm.String");

        /// <summary>
        /// Indicates that a field contains a 32-bit signed integer.
        /// </summary>
        public static readonly DataType Int32 = new DataType("Edm.Int32");

        /// <summary>
        /// Indicates that a field contains a 64-bit signed integer.
        /// </summary>
        public static readonly DataType Int64 = new DataType("Edm.Int64");

        /// <summary>
        /// Indicates that a field contains an IEEE double-precision floating point number.
        /// </summary>
        public static readonly DataType Double = new DataType("Edm.Double");

        /// <summary>
        /// Indicates that a field contains a Boolean value (true or false).
        /// </summary>
        public static readonly DataType Boolean = new DataType("Edm.Boolean");

        /// <summary>
        /// Indicates that a field contains a date/time value, including timezone information.
        /// </summary>
        public static readonly DataType DateTimeOffset = new DataType("Edm.DateTimeOffset");

        /// <summary>
        /// Indicates that a field contains a geo-location in terms of longitude and latitude.
        /// </summary>
        public static readonly DataType GeographyPoint = new DataType("Edm.GeographyPoint");

        private string _name;

        private DataType(string typeName)
        {
            _name = typeName;
        }

        /// <summary>
        /// Creates a DataType for a collection of the given type.
        /// </summary>
        /// <param name="elementType">The DataType of the elements of the collection.</param>
        /// <returns>A new DataType for a collection.</returns>
        public static DataType Collection(DataType elementType)
        {
            if (elementType == null)
            {
                throw new ArgumentNullException("elementType");
            }

            return new DataType(System.String.Format("Collection({0})", elementType.ToString()));
        }

        /// <summary>
        /// Defines implicit conversion from DataType to string.
        /// </summary>
        /// <param name="dataType">DataType to convert.</param>
        /// <returns>The name of the DataType as a string.</returns>
        public static implicit operator string(DataType dataType)
        {
            return dataType.ToString();
        }

        /// <summary>
        /// Returns the name of the DataType in a form that can be used in an Azure Search index definition.
        /// </summary>
        /// <returns>The name of the DataType as a string.</returns>
        public override string ToString()
        {
            return _name;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines the data type of a field in an Azure Search index.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<DataType>))]
    public sealed class DataType : ExtensibleEnum<DataType>
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

        private DataType(string typeName) : base(typeName)
        {
            // Base class does all initialization.
        }

        /// <summary>
        /// Creates a new DataType instance, or returns an existing instance if the given name matches that of a
        /// known data type.
        /// </summary>
        /// <param name="name">Name of the data type.</param>
        /// <returns>A DataType instance with the given name.</returns>
        public static DataType Create(string name)
        {
            // Data types are purposefully open-ended. If we get one we don't recognize, just create a new object.
            return Lookup(name) ?? new DataType(name);
        }

        /// <summary>
        /// Creates a DataType for a collection of the given type.
        /// </summary>
        /// <param name="elementType">The DataType of the elements of the collection.</param>
        /// <returns>A new DataType for a collection.</returns>
        public static DataType Collection(DataType elementType)
        {
            Throw.IfArgumentNull(elementType, "elementType");
            return new DataType(System.String.Format("Collection({0})", elementType.ToString()));
        }
    }
}

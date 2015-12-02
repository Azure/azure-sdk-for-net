// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Defines the data type of a field in an Azure Search index.
    /// </summary>
    public sealed class DataType : IEquatable<DataType>
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

        private static readonly Lazy<Dictionary<string, DataType>> _typeMap =
            new Lazy<Dictionary<string, DataType>>(CreateTypeMap, isThreadSafe: true);

        private string _name;

        private DataType(string typeName)
        {
            _name = typeName;
        }

        /// <summary>
        /// Defines implicit conversion from DataType to string.
        /// </summary>
        /// <param name="dataType">DataType to convert.</param>
        /// <returns>The name of the DataType as a string.</returns>
        public static implicit operator string(DataType dataType)
        {
            return (dataType != null) ? dataType.ToString() : null;
        }

        /// <summary>
        /// Creates a new DataType instance, or returns an existing instance if the given name matches that of a
        /// known data type.
        /// </summary>
        /// <param name="name">Name of the data type.</param>
        /// <returns>A DataType instance with the given name.</returns>
        public static DataType Create(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            // Data types are purposefully open-ended. If we get one we don't recognize, just create a new object.
            DataType dataType;
            if (_typeMap.Value.TryGetValue(name, out dataType))
            {
                return dataType;
            }
            else
            {
                return new DataType(name);
            }
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
        /// Compares the DataType for equality with another DataType.
        /// </summary>
        /// <param name="other">The DataType with which to compare.</param>
        /// <returns>true if the DataType objects are equal; false otherwise.</returns>
        public bool Equals(DataType other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }

            return this._name == other._name;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return this.Equals(obj as AnalyzerName);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }

        /// <summary>
        /// Returns the name of the DataType in a form that can be used in an Azure Search index definition.
        /// </summary>
        /// <returns>The name of the DataType as a string.</returns>
        public override string ToString()
        {
            return _name;
        }

        private static Dictionary<string, DataType> CreateTypeMap()
        {
            IEnumerable<FieldInfo> allPublicStaticFields =
                typeof(DataType).GetTypeInfo().DeclaredFields.Where(f => f.IsStatic && f.IsPublic);

            IEnumerable<DataType> allKnownValues =
                allPublicStaticFields
                    .Where(f => f.FieldType == typeof(DataType))
                    .Select(f => f.GetValue(null))
                    .OfType<DataType>();

            allKnownValues = allKnownValues.Concat(allKnownValues.Select(v => Collection(v)));
            return allKnownValues.ToDictionary(v => (string)v, v => v);
        }
    }
}

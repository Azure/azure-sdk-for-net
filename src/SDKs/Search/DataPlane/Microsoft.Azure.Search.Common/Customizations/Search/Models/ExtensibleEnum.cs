// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Common;

    /// <summary>
    /// Abstract base class for types that act like enums, but can be extended with arbitrary string values.
    /// </summary>
    public abstract class ExtensibleEnum<T> : IEquatable<T> where T : ExtensibleEnum<T>
    {
        private static readonly Lazy<Dictionary<string, T>> _nameMap =
            new Lazy<Dictionary<string, T>>(CreateNameMap, isThreadSafe: true);

        private string _name;

        /// <summary>
        /// Initializes a new instance of the ExtensibleEnum class.
        /// </summary>
        /// <param name="name">The value for this instance of the extensible enumeration.</param>
        protected ExtensibleEnum(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Compares two ExtensibleEnum values for equality.
        /// </summary>
        /// <param name="lhs">The first ExtensibleEnum to compare.</param>
        /// <param name="rhs">The second ExtensibleEnum to compare.</param>
        /// <returns>true if the ExtensibleEnum objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(ExtensibleEnum<T> lhs, T rhs) => object.Equals(lhs, rhs);

        /// <summary>
        /// Compares two ExtensibleEnum values for inequality.
        /// </summary>
        /// <param name="lhs">The first ExtensibleEnum to compare.</param>
        /// <param name="rhs">The second ExtensibleEnum to compare.</param>
        /// <returns>true if the ExtensibleEnum objects are not equal; false otherwise.</returns>
        public static bool operator !=(ExtensibleEnum<T> lhs, T rhs) => !object.Equals(lhs, rhs);

        /// <summary>
        /// Defines explicit conversion from ExtensibleEnum to string.
        /// </summary>
        /// <param name="name">ExtensibleEnum to convert.</param>
        /// <returns>The ExtensibleEnum as a string.</returns>
        public static explicit operator string(ExtensibleEnum<T> name) => name?.ToString();

        /// <summary>
        /// Looks up an ExtensibleEnum instance by name, or returns null if the given name does not match one of the
        /// known values of this ExtensibleEnum.
        /// </summary>
        /// <param name="name">Name of the ExtensibleEnum value.</param>
        /// <returns>An instance of type T with the given name, or null if no such instance could be found.</returns>
        protected static T Lookup(string name)
        {
            Throw.IfArgumentNull(name, "name");

            T enumValue;
            return _nameMap.Value.TryGetValue(name, out enumValue) ? enumValue : null;
        }

        /// <summary>
        /// Compares the ExtensibleEnum for equality with another ExtensibleEnum.
        /// </summary>
        /// <param name="other">The ExtensibleEnum with which to compare.</param>
        /// <returns><c>true</c> if the ExtensibleEnum objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(T other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }

            return this._name == other._name;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as T);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }

        /// <summary>
        /// Returns a string representation of the ExtensibleEnum.
        /// </summary>
        /// <returns>The ExtensibleEnum as a string.</returns>
        public override string ToString()
        {
            return _name;
        }

        private static Dictionary<string, T> CreateNameMap()
        {
            IEnumerable<FieldInfo> allPublicStaticFields =
                typeof(T).GetTypeInfo().DeclaredFields.Where(f => f.IsStatic && f.IsPublic);

            IEnumerable<T> allKnownValues =
                allPublicStaticFields
                    .Where(f => f.FieldType == typeof(T))
                    .Select(f => f.GetValue(null))
                    .OfType<T>();

            return allKnownValues.ToDictionary(v => (string)v, v => v);
        }
    }
}

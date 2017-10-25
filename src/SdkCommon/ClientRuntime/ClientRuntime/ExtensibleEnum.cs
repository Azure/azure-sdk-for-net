// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Rest
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    /// <summary>
    /// Abstract base class for types that act like enums, but can be extended with arbitrary string values.
    /// </summary>
    public abstract class ExtensibleEnum<T, V> where T : ExtensibleEnum<T, V>
    {
        protected static readonly ConcurrentDictionary<V, T> _valueMap = new ConcurrentDictionary<V, T>();

        protected readonly V _value;

        /// <summary>
        /// Initializes a new instance of the ExtensibleEnum class.
        /// </summary>
        /// <param value="value">The value for this instance of the extensible enumeration.</param>
        protected ExtensibleEnum(V value)
        {
            _value = value;
        }

        /// <summary>
        /// Static map to store allowed values for enums        
        ///</summary>
        public static Dictionary<V, T> AllowedValuesMap { get; protected set; } = new Dictionary<V, T>();
        
        /// <summary>
        /// Defines explicit conversion from ExtensibleEnum to string.
        /// </summary>
        /// <param val="val">ExtensibleEnum to convert.</param>
        /// <returns>The ExtensibleEnum as a string.</returns>
        public static implicit operator V(ExtensibleEnum<T, V> val) => val._value;

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        /// <summary>
        /// Returns a string representation of the ExtensibleEnum.
        /// </summary>
        /// <returns>The ExtensibleEnum as a string.</returns>
        public override string ToString()
        {
            return _value.ToString();
        }
        
    }
}

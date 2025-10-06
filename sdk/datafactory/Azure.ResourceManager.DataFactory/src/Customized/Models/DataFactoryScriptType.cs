// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary> The type of the query. Type: string. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct DataFactoryScriptType : IEquatable<DataFactoryScriptType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DataFactoryScriptType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DataFactoryScriptType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string QueryValue = "Query";
        private const string NonQueryValue = "NonQuery";

        /// <summary> Query. </summary>
        public static DataFactoryScriptType Query { get; } = new DataFactoryScriptType(QueryValue);
        /// <summary> NonQuery. </summary>
        public static DataFactoryScriptType NonQuery { get; } = new DataFactoryScriptType(NonQueryValue);
        /// <summary> Determines if two <see cref="DataFactoryScriptType"/> values are the same. </summary>
        public static bool operator ==(DataFactoryScriptType left, DataFactoryScriptType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DataFactoryScriptType"/> values are not the same. </summary>
        public static bool operator !=(DataFactoryScriptType left, DataFactoryScriptType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DataFactoryScriptType"/>. </summary>
        public static implicit operator DataFactoryScriptType(string value) => new DataFactoryScriptType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DataFactoryScriptType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DataFactoryScriptType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

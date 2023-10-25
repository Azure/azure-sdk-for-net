// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary> Linked service reference type. </summary>
    public readonly partial struct DataFactoryLinkedServiceReferenceType : IEquatable<DataFactoryLinkedServiceReferenceType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DataFactoryLinkedServiceReferenceType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DataFactoryLinkedServiceReferenceType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LinkedServiceReferenceValue = "LinkedServiceReference";

        /// <summary> LinkedServiceReference. </summary>
        public static DataFactoryLinkedServiceReferenceType LinkedServiceReference { get; } = new DataFactoryLinkedServiceReferenceType(LinkedServiceReferenceValue);
        /// <summary> Determines if two <see cref="DataFactoryLinkedServiceReferenceType"/> values are the same. </summary>
        public static bool operator ==(DataFactoryLinkedServiceReferenceType left, DataFactoryLinkedServiceReferenceType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DataFactoryLinkedServiceReferenceType"/> values are not the same. </summary>
        public static bool operator !=(DataFactoryLinkedServiceReferenceType left, DataFactoryLinkedServiceReferenceType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DataFactoryLinkedServiceReferenceType"/>. </summary>
        public static implicit operator DataFactoryLinkedServiceReferenceType(string value) => new DataFactoryLinkedServiceReferenceType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DataFactoryLinkedServiceReferenceType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DataFactoryLinkedServiceReferenceType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

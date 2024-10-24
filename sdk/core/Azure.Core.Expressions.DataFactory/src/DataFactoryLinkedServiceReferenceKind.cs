// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary> Linked service reference type. </summary>
    public readonly partial struct DataFactoryLinkedServiceReferenceKind : IEquatable<DataFactoryLinkedServiceReferenceKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DataFactoryLinkedServiceReferenceKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DataFactoryLinkedServiceReferenceKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LinkedServiceReferenceValue = "LinkedServiceReference";

        /// <summary> LinkedServiceReference. </summary>
        public static DataFactoryLinkedServiceReferenceKind LinkedServiceReference { get; } = new DataFactoryLinkedServiceReferenceKind(LinkedServiceReferenceValue);
        /// <summary> Determines if two <see cref="DataFactoryLinkedServiceReferenceKind"/> values are the same. </summary>
        public static bool operator ==(DataFactoryLinkedServiceReferenceKind left, DataFactoryLinkedServiceReferenceKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DataFactoryLinkedServiceReferenceKind"/> values are not the same. </summary>
        public static bool operator !=(DataFactoryLinkedServiceReferenceKind left, DataFactoryLinkedServiceReferenceKind right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DataFactoryLinkedServiceReferenceKind"/>. </summary>
        public static implicit operator DataFactoryLinkedServiceReferenceKind(string value) => new DataFactoryLinkedServiceReferenceKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is DataFactoryLinkedServiceReferenceKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DataFactoryLinkedServiceReferenceKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

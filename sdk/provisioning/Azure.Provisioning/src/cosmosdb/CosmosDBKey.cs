// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.CosmosDB
{
    /// <summary> Role definition. </summary>
    public readonly partial struct CosmosDBKey : IEquatable<CosmosDBKey>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CosmosDBKey"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CosmosDBKey(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Primary master key.
        /// </summary>
        public static CosmosDBKey PrimaryKey { get; } = new CosmosDBKey("primaryMasterKey");

        /// <summary>
        /// Secondary master key.
        /// </summary>
        public static CosmosDBKey SecondaryKey { get; } = new CosmosDBKey("secondaryMasterKey");

        /// <summary>
        /// Primary read-only master key.
        /// </summary>
        public static CosmosDBKey PrimaryReadonlyMasterKey { get; } = new CosmosDBKey("primaryReadonlyMasterKey");

        /// <summary>
        /// Primary read-only master key.
        /// </summary>
        public static CosmosDBKey SecondaryReadonlyMasterKey { get; } = new CosmosDBKey("secondaryReadonlyMasterKey");

        /// <summary> Converts a string to a <see cref="CosmosDBKey"/>. </summary>
        public static implicit operator CosmosDBKey(string value) => new CosmosDBKey(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is CosmosDBKey other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CosmosDBKey other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

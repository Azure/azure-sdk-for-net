// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: Provides constructor, field, static members, Equals/GetHashCode/ToString
// for the extensible struct. Generated partial provides operators (==, !=, implicit).

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Gets the status of the storage account at the time the operation was called. </summary>
    public readonly partial struct StorageAccountProvisioningState : IEquatable<StorageAccountProvisioningState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StorageAccountProvisioningState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StorageAccountProvisioningState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CreatingValue = "Creating";
        private const string ResolvingDnsValue = "ResolvingDNS";
        private const string SucceededValue = "Succeeded";

        /// <summary> Creating. </summary>
        public static StorageAccountProvisioningState Creating { get; } = new StorageAccountProvisioningState(CreatingValue);
        /// <summary> ResolvingDNS. </summary>
        public static StorageAccountProvisioningState ResolvingDns { get; } = new StorageAccountProvisioningState(ResolvingDnsValue);
        /// <summary> Succeeded. </summary>
        public static StorageAccountProvisioningState Succeeded { get; } = new StorageAccountProvisioningState(SucceededValue);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StorageAccountProvisioningState other && Equals(other);

        /// <inheritdoc />
        public bool Equals(StorageAccountProvisioningState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

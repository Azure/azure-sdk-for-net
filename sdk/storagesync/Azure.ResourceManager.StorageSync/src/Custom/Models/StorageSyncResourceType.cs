// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

[assembly:CodeGenSuppressType("StorageSyncResourceType")]
namespace Azure.ResourceManager.StorageSync.Models
{
    /// <summary> The resource type. Must be set to Microsoft.StorageSync/storageSyncServices. </summary>
    public readonly partial struct StorageSyncResourceType : IEquatable<StorageSyncResourceType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StorageSyncResourceType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StorageSyncResourceType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }
#pragma warning disable CA1707
        private const string Microsoft_StorageSync_StorageSyncServicesValue = "Microsoft.StorageSync/storageSyncServices";

        /// <summary> Microsoft.StorageSync/storageSyncServices. </summary>
        public static StorageSyncResourceType Microsoft_StorageSync_StorageSyncServices { get; } = new StorageSyncResourceType(Microsoft_StorageSync_StorageSyncServicesValue);
#pragma warning restore CA1707
        /// <summary> Determines if two <see cref="StorageSyncResourceType"/> values are the same. </summary>
        public static bool operator ==(StorageSyncResourceType left, StorageSyncResourceType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StorageSyncResourceType"/> values are not the same. </summary>
        public static bool operator !=(StorageSyncResourceType left, StorageSyncResourceType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="StorageSyncResourceType"/>. </summary>
        public static implicit operator StorageSyncResourceType(string value) => new StorageSyncResourceType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StorageSyncResourceType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StorageSyncResourceType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

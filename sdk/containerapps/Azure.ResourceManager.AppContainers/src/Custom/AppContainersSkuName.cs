// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppContainers.Models
{
    // This type was removed from the service spec but is preserved here as a hidden member
    // to avoid breaking existing consumers. The implementation matches the original generated
    // code before it was removed in commit 04dba6ae.
    // See https://github.com/Azure/azure-sdk-for-net/issues/56807

    /// <summary> Name of the Sku. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("AppContainersSkuName is no longer supported by the service and will be removed in a future release.")]
    public readonly partial struct AppContainersSkuName : IEquatable<AppContainersSkuName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AppContainersSkuName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AppContainersSkuName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ConsumptionValue = "Consumption";
        private const string PremiumValue = "Premium";

        /// <summary> Consumption SKU of Managed Environment. </summary>
        public static AppContainersSkuName Consumption { get; } = new AppContainersSkuName(ConsumptionValue);
        /// <summary> Premium SKU of Managed Environment. </summary>
        public static AppContainersSkuName Premium { get; } = new AppContainersSkuName(PremiumValue);
        /// <summary> Determines if two <see cref="AppContainersSkuName"/> values are the same. </summary>
        public static bool operator ==(AppContainersSkuName left, AppContainersSkuName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AppContainersSkuName"/> values are not the same. </summary>
        public static bool operator !=(AppContainersSkuName left, AppContainersSkuName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="AppContainersSkuName"/>. </summary>
        public static implicit operator AppContainersSkuName(string value) => new AppContainersSkuName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AppContainersSkuName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AppContainersSkuName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

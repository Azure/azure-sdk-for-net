// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Batch.Models
{
    /// <summary> The provisioning state of the certificate. </summary>
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct BatchAccountCertificateProvisioningState : IEquatable<BatchAccountCertificateProvisioningState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="BatchAccountCertificateProvisioningState"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public BatchAccountCertificateProvisioningState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private static readonly BatchAccountCertificateProvisioningState _Succeeded = new("Succeeded");
        private static readonly BatchAccountCertificateProvisioningState _Deleting = new("Deleting");
        private static readonly BatchAccountCertificateProvisioningState _Failed = new("Failed");

        /// <summary> Succeeded. </summary>
        public static BatchAccountCertificateProvisioningState Succeeded => _Succeeded;
        /// <summary> Deleting. </summary>
        public static BatchAccountCertificateProvisioningState Deleting => _Deleting;
        /// <summary> Failed. </summary>
        public static BatchAccountCertificateProvisioningState Failed => _Failed;

        /// <summary> Converts a string to a <see cref="BatchAccountCertificateProvisioningState"/>. </summary>
        public static implicit operator BatchAccountCertificateProvisioningState(string value) => new(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is BatchAccountCertificateProvisioningState other && Equals(other);

        /// <inheritdoc />
        public bool Equals(BatchAccountCertificateProvisioningState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc />
        public override string ToString() => _value;

        /// <summary> Equality operator. </summary>
        public static bool operator ==(BatchAccountCertificateProvisioningState left, BatchAccountCertificateProvisioningState right) => left.Equals(right);
        /// <summary> Inequality operator. </summary>
        public static bool operator !=(BatchAccountCertificateProvisioningState left, BatchAccountCertificateProvisioningState right) => !left.Equals(right);
    }
}

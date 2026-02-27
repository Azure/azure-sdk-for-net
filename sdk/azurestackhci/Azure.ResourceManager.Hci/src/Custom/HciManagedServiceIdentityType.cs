// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary>
    /// Backward-compat type alias for HciManagedServiceIdentityType.
    /// Old autorest SDK used prepend-rp-prefix to create this from ManagedServiceIdentityType.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly struct HciManagedServiceIdentityType
    {
        private readonly Azure.ResourceManager.Models.ManagedServiceIdentityType _value;

        /// <summary> Initializes a new instance of <see cref="HciManagedServiceIdentityType"/>. </summary>
        public HciManagedServiceIdentityType(string value)
        {
            _value = new Azure.ResourceManager.Models.ManagedServiceIdentityType(value);
        }

        /// <summary> Converts to ManagedServiceIdentityType. </summary>
        public static implicit operator Azure.ResourceManager.Models.ManagedServiceIdentityType(HciManagedServiceIdentityType value) => value._value;

        /// <summary> Converts from ManagedServiceIdentityType. </summary>
        public static implicit operator HciManagedServiceIdentityType(Azure.ResourceManager.Models.ManagedServiceIdentityType value) => new HciManagedServiceIdentityType(value.ToString());

        /// <inheritdoc />
        public override string ToString() => _value.ToString();
    }
}

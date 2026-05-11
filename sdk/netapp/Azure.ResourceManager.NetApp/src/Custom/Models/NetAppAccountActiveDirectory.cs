// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward compatibility: v1.15.0 exposed the boolean properties as `AesEncryption`,
    // `LdapSigning`, `LdapOverTLS`. They were renamed in this migration to the
    // `Is...Enabled` style for consistency with other SDKs. The old names are preserved
    // here as forwarding shims so existing user code continues to compile.
    public partial class NetAppAccountActiveDirectory
    {
        // Formerly AesEncryption; renamed to IsAesEncryptionEnabled.
        /// <summary> Compatibility alias for <see cref="IsAesEncryptionEnabled"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? AesEncryption
        {
            get => IsAesEncryptionEnabled;
            set => IsAesEncryptionEnabled = value;
        }

        // Formerly LdapSigning; renamed to IsLdapSigningEnabled.
        /// <summary> Compatibility alias for <see cref="IsLdapSigningEnabled"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? LdapSigning
        {
            get => IsLdapSigningEnabled;
            set => IsLdapSigningEnabled = value;
        }

        // Formerly LdapOverTLS; renamed to IsLdapOverTlsEnabled.
        /// <summary> Compatibility alias for <see cref="IsLdapOverTlsEnabled"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? LdapOverTLS
        {
            get => IsLdapOverTlsEnabled;
            set => IsLdapOverTlsEnabled = value;
        }
    }
}

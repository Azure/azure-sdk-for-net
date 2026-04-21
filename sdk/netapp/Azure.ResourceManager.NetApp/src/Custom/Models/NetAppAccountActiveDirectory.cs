// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppAccountActiveDirectory
    {
        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? AesEncryption
        {
            get => IsAesEncryptionEnabled;
            set => IsAesEncryptionEnabled = value;
        }

        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? LdapSigning
        {
            get => IsLdapSigningEnabled;
            set => IsLdapSigningEnabled = value;
        }

        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? LdapOverTLS
        {
            get => IsLdapOverTlsEnabled;
            set => IsLdapOverTlsEnabled = value;
        }
    }
}

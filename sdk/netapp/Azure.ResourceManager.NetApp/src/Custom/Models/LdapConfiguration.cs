// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class LdapConfiguration
    {
        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsLdapOverTlsEnabled
        {
            get => LdapOverTLS;
            set => LdapOverTLS = value;
        }
    }
}

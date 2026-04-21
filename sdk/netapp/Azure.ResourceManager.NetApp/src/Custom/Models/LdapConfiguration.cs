// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    // Note: this is the *new* property name added for naming consistency with sibling
    // bool properties (Is...Enabled). The generated property `LdapOverTLS` matches the
    // wire name; we expose `IsLdapOverTlsEnabled` as a forwarding alias so callers can
    // adopt the new naming. Marked [EditorBrowsable(Never)] only because the new name
    // is added later in the migration and we want to steer users to the new naming via
    // CHANGELOG guidance rather than IntelliSense ranking.
    public partial class LdapConfiguration
    {
        /// <summary> Naming-consistency alias for <see cref="LdapOverTLS"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsLdapOverTlsEnabled
        {
            get => LdapOverTLS;
            set => LdapOverTLS = value;
        }
    }
}

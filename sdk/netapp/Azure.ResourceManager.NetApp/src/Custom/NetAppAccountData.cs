// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    // The 2026 TypeSpec model removed the legacy account-level Entra ID and LDAP
    // configuration objects. Preserve the old public properties for source compat.
    public partial class NetAppAccountData
    {
        private EntraIdConfig _entraIdConfig;

        /// <summary> Entra ID configuration. </summary>
        public EntraIdConfig EntraIdConfig
        {
            get => _entraIdConfig;
            set => _entraIdConfig = value;
        }

        /// <summary> LDAP configuration. </summary>
        public LdapConfiguration LdapConfiguration
        {
            get => Properties is null ? default : Properties.LdapConfiguration;
            set
            {
                if (Properties is null)
                {
                    Properties = new AccountProperties();
                }
                Properties.LdapConfiguration = value;
            }
        }
    }
}

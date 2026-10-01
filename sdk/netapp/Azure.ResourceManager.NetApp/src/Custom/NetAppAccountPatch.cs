// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetApp.Models
{
    // Restore TrackedResourceData base type and read-only flattened properties that
    // existed on the previously shipped autorest SDK. The new spec models the patch
    // type as PatchModel<NetAppAccount> which strips id/location and read-only
    // properties; preserve them here for backward compatibility.
    public partial class NetAppAccountPatch : TrackedResourceData
    {
        private EntraIdConfigPatch _entraIdConfig;
        private LdapConfiguration _ldapConfiguration;

        // ProvisioningState/DisableShowmount were read-only on the GA model. The new patch
        // type omits them entirely, so these stubs preserve source compatibility while
        // throwing on access — callers should read provisioning state from NetAppAccountData.
        /// <summary> Azure lifecycle management. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. Read the provisioning state from NetAppAccountData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProvisioningState => throw new NotSupportedException("ProvisioningState is no longer available on NetAppAccountPatch. Read it from NetAppAccountData instead.");

        /// <summary> Shows the status of disableShowmount for all volumes under the subscription, null equals false. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. Read DisableShowmount from NetAppAccountData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? DisableShowmount => throw new NotSupportedException("DisableShowmount is no longer available on NetAppAccountPatch. Read it from NetAppAccountData instead.");

        /// <summary> MultiAD Status for the account. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. Read MultiAdStatus from NetAppAccountData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MultiAdStatus? MultiAdStatus => throw new NotSupportedException("MultiAdStatus is no longer available on NetAppAccountPatch. Read it from NetAppAccountData instead.");

        /// <summary> Entra ID configuration. </summary>
        public EntraIdConfigPatch EntraIdConfig
        {
            get => _entraIdConfig;
            set => _entraIdConfig = value;
        }

        /// <summary> LDAP configuration. </summary>
        public LdapConfiguration LdapConfiguration
        {
            get
            {
                if (_ldapConfiguration is null && Properties?.LdapConfiguration is not null)
                {
                    BinaryData data = ModelReaderWriter.Write(Properties.LdapConfiguration, ModelSerializationExtensions.WireOptions, AzureResourceManagerNetAppContext.Default);
                    _ldapConfiguration = ModelReaderWriter.Read<LdapConfiguration>(data, ModelSerializationExtensions.WireOptions, AzureResourceManagerNetAppContext.Default);
                }
                return _ldapConfiguration;
            }
            set
            {
                _ldapConfiguration = value;
                if (Properties is null)
                {
                    Properties = new AccountPropertiesPatch();
                }
                if (value is null)
                {
                    Properties.LdapConfiguration = null;
                    return;
                }
                BinaryData data = ModelReaderWriter.Write(value, ModelSerializationExtensions.WireOptions, AzureResourceManagerNetAppContext.Default);
                Properties.LdapConfiguration = ModelReaderWriter.Read<LdapConfigurationPatch>(data, ModelSerializationExtensions.WireOptions, AzureResourceManagerNetAppContext.Default);
            }
        }
    }
}

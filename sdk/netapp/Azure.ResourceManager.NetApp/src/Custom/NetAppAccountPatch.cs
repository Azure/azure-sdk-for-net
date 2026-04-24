// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetApp.Models
{
    // Restore TrackedResourceData base type and read-only flattened properties that
    // existed on the previously shipped autorest SDK. The new spec models the patch
    // type as PatchModel<NetAppAccount> which strips id/location and read-only
    // properties; preserve them here for backward compatibility.
    //
    // Suppress the generator-emitted 'NfsV4IDDomain' flattening property and replace
    // it with the GA-shipped 'NfsV4IdDomain' casing. The matching @@clientName on
    // AccountProperties.nfsV4IDDomain is not propagated by PatchModel<> templates.
    [CodeGenSuppress("NfsV4IDDomain")]
    public partial class NetAppAccountPatch : TrackedResourceData
    {
        /// <summary> Azure lifecycle management. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProvisioningState => null;

        /// <summary> Shows the status of disableShowmount for all volumes under the subscription, null equals false. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? DisableShowmount => null;

        /// <summary> Domain for NFSv4 user ID mapping. This property will be set for all NetApp accounts in the subscription and region and only affect non ldap NFSv4 volumes. </summary>
        public string NfsV4IdDomain
        {
            get => Properties?.NfsV4IDDomain;
            set => (Properties ??= new AccountPropertiesPatch()).NfsV4IDDomain = value;
        }
    }
}

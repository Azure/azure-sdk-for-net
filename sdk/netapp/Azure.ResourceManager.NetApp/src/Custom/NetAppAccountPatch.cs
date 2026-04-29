// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
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
    }
}

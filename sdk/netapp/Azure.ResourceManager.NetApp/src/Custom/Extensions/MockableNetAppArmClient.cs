// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Mocking
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public partial class MockableNetAppArmClient : ArmResource
    {
        // Custom xml docs have been removed; the generator already emits proper xml docs for
        // the resource-getter overloads. The methods listed below are present because they
        // (a) override the generated method's visibility with [EditorBrowsable(Never)] for
        // backward-compat, or (b) target a deprecated resource type retained for source
        // compatibility.

        /// <summary>
        /// Gets an object representing a <see cref="NetAppAccountBackupResource" /> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppAccountBackupResource GetNetAppAccountBackupResource(ResourceIdentifier id)
        {
            NetAppAccountBackupResource.ValidateResourceId(id);
            return new NetAppAccountBackupResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="NetAppVolumeBackupResource" /> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppVolumeBackupResource GetNetAppVolumeBackupResource(ResourceIdentifier id)
        {
            NetAppVolumeBackupResource.ValidateResourceId(id);
            return new NetAppVolumeBackupResource(Client, id);
        }

        // Volume keeps its unprefixed generated name (NetAppVolumeResource is the GA name);
        // this resource-getter exposes the GA name. See NetAppVolumeResource.cs for context.
        /// <summary>
        /// Gets an object representing a <see cref="NetAppVolumeResource" /> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppVolumeResource GetNetAppVolumeResource(ResourceIdentifier id)
        {
            return new NetAppVolumeResource(Client, id);
        }

        // The mgmt emitter does not auto-generate the ArmClient resource-getter for resources
        // routed via @@clientLocation, so this overload is provided manually to mirror the
        // generated pattern for other resources above.
        /// <summary>
        /// Gets an object representing a <see cref="NetAppSubscriptionQuotaItemResource" /> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppSubscriptionQuotaItemResource GetNetAppSubscriptionQuotaItemResource(ResourceIdentifier id)
        {
            NetAppSubscriptionQuotaItemResource.ValidateResourceId(id);
            return new NetAppSubscriptionQuotaItemResource(Client, id);
        }
    }
}

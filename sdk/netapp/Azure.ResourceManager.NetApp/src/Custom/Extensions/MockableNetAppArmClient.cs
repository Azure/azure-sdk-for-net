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

        /// <summary>
        /// Gets an object representing a <see cref="NetAppVolumeResource" /> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppVolumeResource GetNetAppVolumeResource(ResourceIdentifier id)
        {
            return new NetAppVolumeResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="NetAppSubscriptionQuotaItemResource" /> along with the instance operations that can be performed on it but with no data.
        /// This type has been replaced by <see cref="NetAppResourceQuotaLimitResource" />.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppSubscriptionQuotaItemResource GetNetAppSubscriptionQuotaItemResource(ResourceIdentifier id)
        {
            throw new NotSupportedException("GetNetAppSubscriptionQuotaItemResource is not supported. Use GetNetAppResourceQuotaLimitResource instead.");
        }
    }
}

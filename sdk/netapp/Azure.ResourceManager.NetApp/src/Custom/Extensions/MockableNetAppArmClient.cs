// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Mocking
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public partial class MockableNetAppArmClient : ArmResource
    {
        /// <summary>
        /// Gets an object representing a <see cref="NetAppAccountBackupResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="NetAppAccountBackupResource.CreateResourceIdentifier" /> to create a <see cref="NetAppAccountBackupResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NetAppAccountBackupResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppAccountBackupResource GetNetAppAccountBackupResource(ResourceIdentifier id)
        {
            NetAppAccountBackupResource.ValidateResourceId(id);
            return new NetAppAccountBackupResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="NetAppVolumeBackupResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="NetAppVolumeBackupResource.CreateResourceIdentifier" /> to create a <see cref="NetAppVolumeBackupResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NetAppVolumeBackupResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]

        public virtual NetAppVolumeBackupResource GetNetAppVolumeBackupResource(ResourceIdentifier id)
        {
                NetAppVolumeBackupResource.ValidateResourceId(id);
                return new NetAppVolumeBackupResource(Client, id);
        }
    }
}

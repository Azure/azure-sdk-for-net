// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NetApp
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.NetApp. </summary>
    public static partial class NetAppExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="NetAppAccountBackupResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="NetAppAccountBackupResource.CreateResourceIdentifier" /> to create a <see cref="NetAppAccountBackupResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NetAppAccountBackupResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppAccountBackupResource GetNetAppAccountBackupResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableNetAppArmClient(client).GetNetAppAccountBackupResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="NetAppVolumeBackupResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="NetAppVolumeBackupResource.CreateResourceIdentifier" /> to create a <see cref="NetAppVolumeBackupResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NetAppVolumeBackupResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]

        public static NetAppVolumeBackupResource GetNetAppVolumeBackupResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableNetAppArmClient(client).GetNetAppVolumeBackupResource(id);
        }
    }
}

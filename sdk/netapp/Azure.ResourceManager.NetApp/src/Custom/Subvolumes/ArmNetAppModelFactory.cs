// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    public static partial class ArmNetAppModelFactory
    {
        /// <summary> Initializes a subvolume data model for mocking. </summary>
        public static NetAppSubvolumeInfoData NetAppSubvolumeInfoData(
            ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default,
            string path = default, long? size = default, string parentPath = default, string provisioningState = default)
        {
            return new NetAppSubvolumeInfoData(id, name, resourceType, systemData,
                path is null && size is null && parentPath is null && provisioningState is null
                    ? null : new SubvolumeProperties(path, size, parentPath, provisioningState, default),
                default);
        }

        /// <summary> Initializes a subvolume patch model for mocking. </summary>
        public static NetAppSubvolumeInfoPatch NetAppSubvolumeInfoPatch(long? size = default, string path = default)
        {
            return new NetAppSubvolumeInfoPatch(size is null && path is null ? null : new SubvolumePatchParams(size, path, default), default);
        }

        /// <summary> Initializes subvolume metadata for mocking. </summary>
        public static NetAppSubvolumeMetadata NetAppSubvolumeMetadata(
            ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default,
            string path = default, string parentPath = default, long? size = default, long? bytesUsed = default, string permissions = default,
            DateTimeOffset? createdOn = default, DateTimeOffset? accessedOn = default, DateTimeOffset? modifiedOn = default,
            DateTimeOffset? changedOn = default, string provisioningState = default)
        {
            return new NetAppSubvolumeMetadata(id, name, resourceType, systemData,
                path is null && parentPath is null && size is null && bytesUsed is null && permissions is null && createdOn is null &&
                accessedOn is null && modifiedOn is null && changedOn is null && provisioningState is null
                    ? null : new SubvolumeModelProperties(path, parentPath, size, bytesUsed, permissions, createdOn, accessedOn, modifiedOn,
                        changedOn, provisioningState, default),
                default);
        }
    }
}

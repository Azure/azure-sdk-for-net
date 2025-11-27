// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using static Azure.Core.Pipeline.TaskExtensions;

namespace Azure.ResourceManager.AppConfiguration.Models
{
    public static partial class ArmAppConfigurationModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="AppConfiguration.AppConfigurationSnapshotData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="snapshotType"> The type of the resource. </param>
        /// <param name="provisioningState"> The provisioning state of the snapshot. </param>
        /// <param name="status"> The current status of the snapshot. </param>
        /// <param name="filters"> A list of filters used to filter the key-values included in the snapshot. </param>
        /// <param name="compositionType"> The composition type describes how the key-values within the snapshot are composed. The 'key' composition type ensures there are no two key-values containing the same key. The 'key_label' composition type ensures there are no two key-values containing the same key and label. </param>
        /// <param name="createdOn"> The time that the snapshot was created. </param>
        /// <param name="expireOn"> The time that the snapshot will expire. </param>
        /// <param name="retentionPeriod"> The amount of time, in seconds, that a snapshot will remain in the archived state before expiring. This property is only writable during the creation of a snapshot. If not specified, the default lifetime of key-value revisions will be used. </param>
        /// <param name="size"> The size in bytes of the snapshot. </param>
        /// <param name="itemsCount"> The amount of key-values in the snapshot. </param>
        /// <param name="tags"> The tags of the snapshot. NOTE: These are data plane tags, not Azure Resource Manager (ARM) tags. </param>
        /// <param name="eTag"> A value representing the current state of the snapshot. </param>
        /// <returns> A new <see cref="AppConfiguration.AppConfigurationSnapshotData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AppConfigurationSnapshotData AppConfigurationSnapshotData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string snapshotType, AppConfigurationProvisioningState? provisioningState = null, AppConfigurationSnapshotStatus? status = null, IEnumerable<SnapshotKeyValueFilter> filters = null, SnapshotCompositionType? compositionType = null, DateTimeOffset? createdOn = null, DateTimeOffset? expireOn = null, long? retentionPeriod = null, long? size = null, long? itemsCount = null, IDictionary<string, string> tags = null, ETag? eTag = null)
            => AppConfigurationSnapshotData(id, name, resourceType, systemData, provisioningState, status, filters, compositionType, createdOn, expireOn, retentionPeriod, size, itemsCount, tags, eTag);
    }
}

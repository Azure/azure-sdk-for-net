// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// A class representing the NetAppBackup data model.
    /// Backup of a Volume
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppBackupData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="NetAppBackupData"/>. </summary>
        /// <param name="location"> Resource location. </param>
        public NetAppBackupData(AzureLocation location)
        {
            Location = location;
        }

        /// <summary> Initializes a new instance of <see cref="NetAppBackupData"/>. </summary>
        internal NetAppBackupData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, AzureLocation location, string backupId, DateTimeOffset? createdOn, string provisioningState, long? size, string label, NetAppBackupType? backupType, string failureReason, ResourceIdentifier volumeResourceId, bool? useExistingSnapshot, string snapshotName, ResourceIdentifier backupPolicyResourceId) : base(id, name, resourceType, systemData)
        {
            Location = location;
            BackupId = backupId;
            CreatedOn = createdOn;
            ProvisioningState = provisioningState;
            Size = size;
            Label = label;
            BackupType = backupType;
            FailureReason = failureReason;
            VolumeResourceId = volumeResourceId;
            UseExistingSnapshot = useExistingSnapshot;
            SnapshotName = snapshotName;
            BackupPolicyArmResourceId = backupPolicyResourceId;
        }

        /// <summary> Resource location. </summary>
        public AzureLocation Location { get; set; }

        /// <summary> UUID v4 used to identify the Backup. </summary>
        public string BackupId { get; }

        /// <summary> The creation date of the backup. </summary>
        public DateTimeOffset? CreatedOn { get; }

        /// <summary> Azure lifecycle management. </summary>
        public string ProvisioningState { get; }

        /// <summary> Size of backup in bytes. </summary>
        public long? Size { get; }

        /// <summary> Label for backup. </summary>
        public string Label { get; set; }

        /// <summary> Type of backup Manual or Scheduled. </summary>
        public NetAppBackupType? BackupType { get; }

        /// <summary> Failure reason. </summary>
        public string FailureReason { get; }

        /// <summary> Volume name. </summary>
        public string VolumeName { get; }

        /// <summary> ResourceId used to identify the Volume. </summary>
        public ResourceIdentifier VolumeResourceId { get; set; }

        /// <summary> Manual backup an already existing snapshot. </summary>
        public bool? UseExistingSnapshot { get; set; }

        /// <summary> The name of the snapshot. </summary>
        public string SnapshotName { get; set; }

        /// <summary> ResourceId used to identify the backup policy. </summary>
        internal ResourceIdentifier BackupPolicyArmResourceId { get; set; }

        /// <summary> ResourceId used to identify the backup policy. </summary>
        public string BackupPolicyResourceId
        {
            get { return BackupPolicyArmResourceId?.ToString(); }
        }

        internal static NetAppBackupData DeserializeNetAppBackupData(System.Text.Json.JsonElement element)
        {
            if (element.ValueKind == System.Text.Json.JsonValueKind.Null)
            {
                return null;
            }
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Azure.ResourceManager.Models.SystemData systemData = default;
            string backupId = default;
            DateTimeOffset? creationDate = default;
            string provisioningState = default;
            long? size = default;
            string label = default;
            NetAppBackupType? backupType = default;
            string failureReason = default;
            string volumeName = default;
            bool? useExistingSnapshot = default;
            string snapshotName = default;
            ResourceIdentifier volumeResourceId = default;
            ResourceIdentifier backupPolicyResourceId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("location"u8))
                {
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = System.Text.Json.JsonSerializer.Deserialize<Azure.ResourceManager.Models.SystemData>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
                    {
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("backupId"u8))
                        {
                            backupId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("creationDate"u8))
                        {
                            if (property0.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
                            {
                                continue;
                            }
                            creationDate = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            provisioningState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("size"u8))
                        {
                            if (property0.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
                            {
                                continue;
                            }
                            size = property0.Value.GetInt64();
                            continue;
                        }
                        if (property0.NameEquals("label"u8))
                        {
                            label = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("backupType"u8))
                        {
                            if (property0.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
                            {
                                continue;
                            }
                            backupType = new NetAppBackupType(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("failureReason"u8))
                        {
                            failureReason = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("volumeName"u8))
                        {
                            volumeName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("volumeResourceId"u8))
                        {
                            if (property0.Value.ValueKind != System.Text.Json.JsonValueKind.Null)
                            {
                                volumeResourceId = new ResourceIdentifier(property0.Value.GetString());
                            }
                            continue;
                        }
                        if (property0.NameEquals("useExistingSnapshot"u8))
                        {
                            if (property0.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
                            {
                                continue;
                            }
                            useExistingSnapshot = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("snapshotName"u8))
                        {
                            snapshotName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("backupPolicyResourceId"u8))
                        {
                            if (property0.Value.ValueKind != System.Text.Json.JsonValueKind.Null)
                            {
                                backupPolicyResourceId = new ResourceIdentifier(property0.Value.GetString());
                            }
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new NetAppBackupData(id, name, type, systemData, location, backupId, creationDate, provisioningState, size, label, backupType, failureReason, volumeResourceId, useExistingSnapshot, snapshotName, backupPolicyResourceId);
        }
    }
}

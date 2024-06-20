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
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;
        /// <summary> Initializes a new instance of <see cref="NetAppBackupData"/>. </summary>
        /// <param name="location"> Resource location. </param>
        public NetAppBackupData(AzureLocation location)
        {
            Location = location;
        }

        /// <summary> Initializes a new instance of <see cref="NetAppBackupData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="backupId"> UUID v4 used to identify the Backup. </param>
        /// <param name="createdOn"> The creation date of the backup. </param>
        /// <param name="provisioningState"> Azure lifecycle management. </param>
        /// <param name="size"> Size of backup. </param>
        /// <param name="label"> Label for backup. </param>
        /// <param name="backupType"> Type of backup Manual or Scheduled. </param>
        /// <param name="failureReason"> Failure reason. </param>
        /// <param name="volumeName"> Volume name. </param>
        /// <param name="useExistingSnapshot"> Manual backup an already existing snapshot. This will always be false for scheduled backups and true/false for manual backups. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal NetAppBackupData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, AzureLocation location, string backupId, DateTimeOffset? createdOn, string provisioningState, long? size, string label, NetAppBackupType? backupType, string failureReason, string volumeName, bool? useExistingSnapshot, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            Location = location;
            BackupId = backupId;
            CreatedOn = createdOn;
            ProvisioningState = provisioningState;
            Size = size;
            Label = label;
            BackupType = backupType;
            FailureReason = failureReason;
            VolumeName = volumeName;
            UseExistingSnapshot = useExistingSnapshot;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Resource location. </summary>
        public AzureLocation Location { get; set; }
        /// <summary> UUID v4 used to identify the Backup. </summary>
        public string BackupId { get; }
        /// <summary> The creation date of the backup. </summary>
        public DateTimeOffset? CreatedOn { get; }
        /// <summary> Azure lifecycle management. </summary>
        public string ProvisioningState { get; }
        /// <summary> Size of backup. </summary>
        public long? Size { get; }
        /// <summary> Label for backup. </summary>
        public string Label { get; set; }
        /// <summary> Type of backup Manual or Scheduled. </summary>
        public NetAppBackupType? BackupType { get; }
        /// <summary> Failure reason. </summary>
        public string FailureReason { get; }
        /// <summary> Volume name. </summary>
        public string VolumeName { get; }
        /// <summary> Manual backup an already existing snapshot. This will always be false for scheduled backups and true/false for manual backups. </summary>
        public bool? UseExistingSnapshot { get; set; }
    }
}

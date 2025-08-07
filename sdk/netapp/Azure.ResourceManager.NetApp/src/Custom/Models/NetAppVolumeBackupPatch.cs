// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Backup patch. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppVolumeBackupPatch
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

        /// <summary> Initializes a new instance of <see cref="NetAppVolumeBackupPatch"/>. </summary>
        public NetAppVolumeBackupPatch()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }
        /// <summary> Initializes a new instance of <see cref="NetAppVolumeBackupPatch"/>. </summary>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        public NetAppVolumeBackupPatch(IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Tags = new ChangeTrackingDictionary<string, string>();
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; }
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

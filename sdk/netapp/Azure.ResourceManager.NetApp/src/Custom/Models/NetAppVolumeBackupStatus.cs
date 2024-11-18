// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//#nullable disable

//using System.Collections.Generic;
//using System;
//using System.ComponentModel;

//namespace Azure.ResourceManager.NetApp.Models
//{
//    /// <summary> Backup status. </summary>
//    [EditorBrowsable(EditorBrowsableState.Never)]
//    public partial class NetAppVolumeBackupStatus
//    {
//        /// <summary>
//        /// Keeps track of any properties unknown to the library.
//        /// <para>
//        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
//        /// </para>
//        /// <para>
//        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
//        /// </para>
//        /// <para>
//        /// Examples:
//        /// <list type="bullet">
//        /// <item>
//        /// <term>BinaryData.FromObjectAsJson("foo")</term>
//        /// <description>Creates a payload of "foo".</description>
//        /// </item>
//        /// <item>
//        /// <term>BinaryData.FromString("\"foo\"")</term>
//        /// <description>Creates a payload of "foo".</description>
//        /// </item>
//        /// <item>
//        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
//        /// <description>Creates a payload of { "key": "value" }.</description>
//        /// </item>
//        /// <item>
//        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
//        /// <description>Creates a payload of { "key": "value" }.</description>
//        /// </item>
//        /// </list>
//        /// </para>
//        /// </summary>
//        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

//        /// <summary> Initializes a new instance of <see cref="NetAppVolumeBackupStatus"/>. </summary>
//        internal NetAppVolumeBackupStatus()
//        {
//        }

//        /// <summary> Initializes a new instance of <see cref="NetAppVolumeBackupStatus"/>. </summary>
//        /// <param name="isHealthy"> Backup health status. </param>
//        /// <param name="relationshipStatus"> Status of the backup mirror relationship. </param>
//        /// <param name="mirrorState"> The status of the backup. </param>
//        /// <param name="unhealthyReason"> Reason for the unhealthy backup relationship. </param>
//        /// <param name="errorMessage"> Displays error message if the backup is in an error state. </param>
//        /// <param name="lastTransferSize"> Displays the last transfer size. </param>
//        /// <param name="lastTransferType"> Displays the last transfer type. </param>
//        /// <param name="totalTransferBytes"> Displays the total bytes transferred. </param>
//        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
//        internal NetAppVolumeBackupStatus(bool? isHealthy, NetAppRelationshipStatus? relationshipStatus, NetAppMirrorState? mirrorState, string unhealthyReason, string errorMessage, long? lastTransferSize, string lastTransferType, long? totalTransferBytes, IDictionary<string, BinaryData> serializedAdditionalRawData)
//        {
//            IsHealthy = isHealthy;
//            RelationshipStatus = relationshipStatus;
//            MirrorState = mirrorState;
//            UnhealthyReason = unhealthyReason;
//            ErrorMessage = errorMessage;
//            LastTransferSize = lastTransferSize;
//            LastTransferType = lastTransferType;
//            TotalTransferBytes = totalTransferBytes;
//            _serializedAdditionalRawData = serializedAdditionalRawData;
//        }

//        /// <summary> Backup health status. </summary>
//        public bool? IsHealthy { get; }
//        /// <summary> Status of the backup mirror relationship. </summary>
//        public NetAppRelationshipStatus? RelationshipStatus { get; }
//        /// <summary> The status of the backup. </summary>
//        public NetAppMirrorState? MirrorState { get; }
//        /// <summary> Reason for the unhealthy backup relationship. </summary>
//        public string UnhealthyReason { get; }
//        /// <summary> Displays error message if the backup is in an error state. </summary>
//        public string ErrorMessage { get; }
//        /// <summary> Displays the last transfer size. </summary>
//        public long? LastTransferSize { get; }
//        /// <summary> Displays the last transfer type. </summary>
//        public string LastTransferType { get; }
//        /// <summary> Displays the total bytes transferred. </summary>
//        public long? TotalTransferBytes { get; }
//    }
//}

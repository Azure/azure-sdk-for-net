// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> Performance tier properties. </summary>
    public partial class MySqlPerformanceTier
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

        /// <summary> Initializes a new instance of <see cref="MySqlPerformanceTier"/>. </summary>
        internal MySqlPerformanceTier()
        {
            ServiceLevelObjectives = new ChangeTrackingList<MySqlPerformanceTierServiceLevelObjectives>();
        }

        /// <summary> Initializes a new instance of <see cref="MySqlPerformanceTier"/>. </summary>
        /// <param name="id"> ID of the performance tier. </param>
        /// <param name="maxBackupRetentionDays"> Maximum Backup retention in days for the performance tier edition. </param>
        /// <param name="minBackupRetentionDays"> Minimum Backup retention in days for the performance tier edition. </param>
        /// <param name="maxStorageInMB"> Max storage allowed for a server. </param>
        /// <param name="minLargeStorageInMB"> Max storage allowed for a server. </param>
        /// <param name="maxLargeStorageInMB"> Max storage allowed for a server. </param>
        /// <param name="minStorageInMB"> Max storage allowed for a server. </param>
        /// <param name="serviceLevelObjectives"> Service level objectives associated with the performance tier. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MySqlPerformanceTier(string id, int? maxBackupRetentionDays, int? minBackupRetentionDays, int? maxStorageInMB, int? minLargeStorageInMB, int? maxLargeStorageInMB, int? minStorageInMB, IReadOnlyList<MySqlPerformanceTierServiceLevelObjectives> serviceLevelObjectives, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            MaxBackupRetentionDays = maxBackupRetentionDays;
            MinBackupRetentionDays = minBackupRetentionDays;
            MaxStorageInMB = maxStorageInMB;
            MinLargeStorageInMB = minLargeStorageInMB;
            MaxLargeStorageInMB = maxLargeStorageInMB;
            MinStorageInMB = minStorageInMB;
            ServiceLevelObjectives = serviceLevelObjectives;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> ID of the performance tier. </summary>
        public string Id { get; }
        /// <summary> Maximum Backup retention in days for the performance tier edition. </summary>
        public int? MaxBackupRetentionDays { get; }
        /// <summary> Minimum Backup retention in days for the performance tier edition. </summary>
        public int? MinBackupRetentionDays { get; }
        /// <summary> Max storage allowed for a server. </summary>
        public int? MaxStorageInMB { get; }
        /// <summary> Max storage allowed for a server. </summary>
        public int? MinLargeStorageInMB { get; }
        /// <summary> Max storage allowed for a server. </summary>
        public int? MaxLargeStorageInMB { get; }
        /// <summary> Max storage allowed for a server. </summary>
        public int? MinStorageInMB { get; }
        /// <summary> Service level objectives associated with the performance tier. </summary>
        public IReadOnlyList<MySqlPerformanceTierServiceLevelObjectives> ServiceLevelObjectives { get; }
    }
}
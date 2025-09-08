// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> A recoverable server resource. </summary>
    public partial class MySqlRecoverableServerResourceData : ResourceData
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

        /// <summary> Initializes a new instance of <see cref="MySqlRecoverableServerResourceData"/>. </summary>
        public MySqlRecoverableServerResourceData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="MySqlRecoverableServerResourceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="lastAvailableBackupOn"> The last available backup date time. </param>
        /// <param name="serviceLevelObjective"> The service level objective. </param>
        /// <param name="edition"> Edition of the performance tier. </param>
        /// <param name="vCores"> vCore associated with the service level objective. </param>
        /// <param name="hardwareGeneration"> Hardware generation associated with the service level objective. </param>
        /// <param name="version"> The MySQL version. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MySqlRecoverableServerResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DateTimeOffset? lastAvailableBackupOn, string serviceLevelObjective, string edition, int? vCores, string hardwareGeneration, string version, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            LastAvailableBackupOn = lastAvailableBackupOn;
            ServiceLevelObjective = serviceLevelObjective;
            Edition = edition;
            VCores = vCores;
            HardwareGeneration = hardwareGeneration;
            Version = version;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The last available backup date time. </summary>
        public DateTimeOffset? LastAvailableBackupOn { get; }
        /// <summary> The service level objective. </summary>
        public string ServiceLevelObjective { get; }
        /// <summary> Edition of the performance tier. </summary>
        public string Edition { get; }
        /// <summary> vCore associated with the service level objective. </summary>
        public int? VCores { get; }
        /// <summary> Hardware generation associated with the service level objective. </summary>
        public string HardwareGeneration { get; }
        /// <summary> The MySQL version. </summary>
        public string Version { get; }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Sql.Models;
using SystemData = Azure.ResourceManager.Models.SystemData;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A class representing the DistributedAvailabilityGroup data model.
    /// Distributed availability group between box and Sql Managed Instance.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DistributedAvailabilityGroupData : ResourceData
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

        /// <summary> Initializes a new instance of <see cref="DistributedAvailabilityGroupData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DistributedAvailabilityGroupData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DistributedAvailabilityGroupData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="targetDatabase"> The name of the target database. </param>
        /// <param name="sourceEndpoint"> The source endpoint. </param>
        /// <param name="primaryAvailabilityGroupName"> The primary availability group name. </param>
        /// <param name="secondaryAvailabilityGroupName"> The secondary availability group name. </param>
        /// <param name="replicationMode"> The replication mode of a distributed availability group. Parameter will be ignored during link creation. </param>
        /// <param name="distributedAvailabilityGroupId"> The distributed availability group id. </param>
        /// <param name="sourceReplicaId"> The source replica id. </param>
        /// <param name="targetReplicaId"> The target replica id. </param>
        /// <param name="linkState"> The link state. </param>
        /// <param name="lastHardenedLsn"> The last hardened lsn. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DistributedAvailabilityGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string targetDatabase, string sourceEndpoint, string primaryAvailabilityGroupName, string secondaryAvailabilityGroupName, DistributedAvailabilityGroupReplicationMode? replicationMode, Guid? distributedAvailabilityGroupId, Guid? sourceReplicaId, Guid? targetReplicaId, string linkState, string lastHardenedLsn, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            TargetDatabase = targetDatabase;
            SourceEndpoint = sourceEndpoint;
            PrimaryAvailabilityGroupName = primaryAvailabilityGroupName;
            SecondaryAvailabilityGroupName = secondaryAvailabilityGroupName;
            ReplicationMode = replicationMode;
            DistributedAvailabilityGroupId = distributedAvailabilityGroupId;
            SourceReplicaId = sourceReplicaId;
            TargetReplicaId = targetReplicaId;
            LinkState = linkState;
            LastHardenedLsn = lastHardenedLsn;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The name of the target database. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.targetDatabase")]
        public string TargetDatabase { get; set; }
        /// <summary> The source endpoint. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.sourceEndpoint")]
        public string SourceEndpoint { get; set; }
        /// <summary> The primary availability group name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.primaryAvailabilityGroupName")]
        public string PrimaryAvailabilityGroupName { get; set; }
        /// <summary> The secondary availability group name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.secondaryAvailabilityGroupName")]
        public string SecondaryAvailabilityGroupName { get; set; }
        /// <summary> The replication mode of a distributed availability group. Parameter will be ignored during link creation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.replicationMode")]
        public DistributedAvailabilityGroupReplicationMode? ReplicationMode { get; set; }
        /// <summary> The distributed availability group id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.distributedAvailabilityGroupId")]
        public Guid? DistributedAvailabilityGroupId { get; }
        /// <summary> The source replica id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.sourceReplicaId")]
        public Guid? SourceReplicaId { get; }
        /// <summary> The target replica id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.targetReplicaId")]
        public Guid? TargetReplicaId { get; }
        /// <summary> The link state. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.linkState")]
        public string LinkState { get; }
        /// <summary> The last hardened lsn. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.lastHardenedLsn")]
        public string LastHardenedLsn { get; }
    }
}

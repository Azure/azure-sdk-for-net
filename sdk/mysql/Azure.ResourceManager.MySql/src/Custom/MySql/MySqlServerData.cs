// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.MySql.Models;

namespace Azure.ResourceManager.MySql
{
    /// <summary>
    /// A class representing the MySqlServer data model.
    /// Represents a server.
    /// </summary>
    public partial class MySqlServerData : TrackedResourceData
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

        /// <summary> Initializes a new instance of <see cref="MySqlServerData"/>. </summary>
        /// <param name="location"> The location. </param>
        public MySqlServerData(AzureLocation location) : base(location)
        {
            PrivateEndpointConnections = new ChangeTrackingList<MySqlServerPrivateEndpointConnection>();
        }

        /// <summary> Initializes a new instance of <see cref="MySqlServerData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> The Azure Active Directory identity of the server. Current supported identity types: SystemAssigned. </param>
        /// <param name="sku"> The SKU (pricing tier) of the server. </param>
        /// <param name="administratorLogin"> The administrator's login name of a server. Can only be specified when the server is being created (and is required for creation). </param>
        /// <param name="version"> Server version. </param>
        /// <param name="sslEnforcement"> Enable ssl enforcement or not when connect to server. </param>
        /// <param name="minimalTlsVersion"> Enforce a minimal Tls version for the server. </param>
        /// <param name="byokEnforcement"> Status showing whether the server data encryption is enabled with customer-managed keys. </param>
        /// <param name="infrastructureEncryption"> Status showing whether the server enabled infrastructure encryption. </param>
        /// <param name="userVisibleState"> A state of a server that is visible to user. </param>
        /// <param name="fullyQualifiedDomainName"> The fully qualified domain name of a server. </param>
        /// <param name="earliestRestoreOn"> Earliest restore point creation time (ISO8601 format). </param>
        /// <param name="storageProfile"> Storage profile of a server. </param>
        /// <param name="replicationRole"> The replication role of the server. </param>
        /// <param name="masterServerId"> The master server id of a replica server. </param>
        /// <param name="replicaCapacity"> The maximum number of replicas that a master server can have. </param>
        /// <param name="publicNetworkAccess"> Whether or not public network access is allowed for this server. Value is optional but if passed in, must be 'Enabled' or 'Disabled'. </param>
        /// <param name="privateEndpointConnections"> List of private endpoint connections on a server. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MySqlServerData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity, MySqlSku sku, string administratorLogin, MySqlServerVersion? version, MySqlSslEnforcementEnum? sslEnforcement, MySqlMinimalTlsVersionEnum? minimalTlsVersion, string byokEnforcement, MySqlInfrastructureEncryption? infrastructureEncryption, MySqlServerState? userVisibleState, string fullyQualifiedDomainName, DateTimeOffset? earliestRestoreOn, MySqlStorageProfile storageProfile, string replicationRole, ResourceIdentifier masterServerId, int? replicaCapacity, MySqlPublicNetworkAccessEnum? publicNetworkAccess, IReadOnlyList<MySqlServerPrivateEndpointConnection> privateEndpointConnections, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData, tags, location)
        {
            Identity = identity;
            Sku = sku;
            AdministratorLogin = administratorLogin;
            Version = version;
            SslEnforcement = sslEnforcement;
            MinimalTlsVersion = minimalTlsVersion;
            ByokEnforcement = byokEnforcement;
            InfrastructureEncryption = infrastructureEncryption;
            UserVisibleState = userVisibleState;
            FullyQualifiedDomainName = fullyQualifiedDomainName;
            EarliestRestoreOn = earliestRestoreOn;
            StorageProfile = storageProfile;
            ReplicationRole = replicationRole;
            MasterServerId = masterServerId;
            ReplicaCapacity = replicaCapacity;
            PublicNetworkAccess = publicNetworkAccess;
            PrivateEndpointConnections = privateEndpointConnections;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="MySqlServerData"/> for deserialization. </summary>
        internal MySqlServerData()
        {
        }

        /// <summary> The Azure Active Directory identity of the server. Current supported identity types: SystemAssigned. </summary>
        public ManagedServiceIdentity Identity { get; set; }
        /// <summary> The SKU (pricing tier) of the server. </summary>
        public MySqlSku Sku { get; set; }
        /// <summary> The administrator's login name of a server. Can only be specified when the server is being created (and is required for creation). </summary>
        public string AdministratorLogin { get; set; }
        /// <summary> Server version. </summary>
        public MySqlServerVersion? Version { get; set; }
        /// <summary> Enable ssl enforcement or not when connect to server. </summary>
        public MySqlSslEnforcementEnum? SslEnforcement { get; set; }
        /// <summary> Enforce a minimal Tls version for the server. </summary>
        public MySqlMinimalTlsVersionEnum? MinimalTlsVersion { get; set; }
        /// <summary> Status showing whether the server data encryption is enabled with customer-managed keys. </summary>
        public string ByokEnforcement { get; }
        /// <summary> Status showing whether the server enabled infrastructure encryption. </summary>
        public MySqlInfrastructureEncryption? InfrastructureEncryption { get; set; }
        /// <summary> A state of a server that is visible to user. </summary>
        public MySqlServerState? UserVisibleState { get; set; }
        /// <summary> The fully qualified domain name of a server. </summary>
        public string FullyQualifiedDomainName { get; set; }
        /// <summary> Earliest restore point creation time (ISO8601 format). </summary>
        public DateTimeOffset? EarliestRestoreOn { get; set; }
        /// <summary> Storage profile of a server. </summary>
        public MySqlStorageProfile StorageProfile { get; set; }
        /// <summary> The replication role of the server. </summary>
        public string ReplicationRole { get; set; }
        /// <summary> The master server id of a replica server. </summary>
        public ResourceIdentifier MasterServerId { get; set; }
        /// <summary> The maximum number of replicas that a master server can have. </summary>
        public int? ReplicaCapacity { get; set; }
        /// <summary> Whether or not public network access is allowed for this server. Value is optional but if passed in, must be 'Enabled' or 'Disabled'. </summary>
        public MySqlPublicNetworkAccessEnum? PublicNetworkAccess { get; set; }
        /// <summary> List of private endpoint connections on a server. </summary>
        public IReadOnlyList<MySqlServerPrivateEndpointConnection> PrivateEndpointConnections { get; }
    }
}
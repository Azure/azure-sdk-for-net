// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> The properties used to create a new server by restoring from a backup. </summary>
    public partial class MySqlServerPropertiesForRestore : MySqlServerPropertiesForCreate
    {
        /// <summary> Initializes a new instance of <see cref="MySqlServerPropertiesForRestore"/>. </summary>
        /// <param name="sourceServerId"> The source server id to restore from. </param>
        /// <param name="restorePointInTime"> Restore point creation time (ISO8601 format), specifying the time to restore from. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceServerId"/> is null. </exception>
        public MySqlServerPropertiesForRestore(ResourceIdentifier sourceServerId, DateTimeOffset restorePointInTime)
        {
            Argument.AssertNotNull(sourceServerId, nameof(sourceServerId));

            SourceServerId = sourceServerId;
            RestorePointInTime = restorePointInTime;
            CreateMode = MySqlCreateMode.PointInTimeRestore;
        }

        /// <summary> Initializes a new instance of <see cref="MySqlServerPropertiesForRestore"/>. </summary>
        /// <param name="version"> Server version. </param>
        /// <param name="sslEnforcement"> Enable ssl enforcement or not when connect to server. </param>
        /// <param name="minimalTlsVersion"> Enforce a minimal Tls version for the server. </param>
        /// <param name="infrastructureEncryption"> Status showing whether the server enabled infrastructure encryption. </param>
        /// <param name="publicNetworkAccess"> Whether or not public network access is allowed for this server. Value is optional but if passed in, must be 'Enabled' or 'Disabled'. </param>
        /// <param name="storageProfile"> Storage profile of a server. </param>
        /// <param name="createMode"> The mode to create a new server. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="sourceServerId"> The source server id to restore from. </param>
        /// <param name="restorePointInTime"> Restore point creation time (ISO8601 format), specifying the time to restore from. </param>
        internal MySqlServerPropertiesForRestore(MySqlServerVersion? version, MySqlSslEnforcementEnum? sslEnforcement, MySqlMinimalTlsVersionEnum? minimalTlsVersion, MySqlInfrastructureEncryption? infrastructureEncryption, MySqlPublicNetworkAccessEnum? publicNetworkAccess, MySqlStorageProfile storageProfile, MySqlCreateMode createMode, IDictionary<string, BinaryData> serializedAdditionalRawData, ResourceIdentifier sourceServerId, DateTimeOffset restorePointInTime) : base(version, sslEnforcement, minimalTlsVersion, infrastructureEncryption, publicNetworkAccess, storageProfile, createMode, serializedAdditionalRawData)
        {
            SourceServerId = sourceServerId;
            RestorePointInTime = restorePointInTime;
            CreateMode = createMode;
        }

        /// <summary> Initializes a new instance of <see cref="MySqlServerPropertiesForRestore"/> for deserialization. </summary>
        internal MySqlServerPropertiesForRestore()
        {
        }

        /// <summary> The source server id to restore from. </summary>
        public ResourceIdentifier SourceServerId { get; }
        /// <summary> Restore point creation time (ISO8601 format), specifying the time to restore from. </summary>
        public DateTimeOffset RestorePointInTime { get; }
    }
}
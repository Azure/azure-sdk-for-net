// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Hyperscale node edition capabilities. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PostgreSqlFlexibleServerHyperscaleNodeEditionCapability
    {
        /// <summary> Initializes a new instance of PostgreSqlFlexibleServerHyperscaleNodeEditionCapability. </summary>
        internal PostgreSqlFlexibleServerHyperscaleNodeEditionCapability()
        {
            SupportedStorageEditions = new ChangeTrackingList<PostgreSqlFlexibleServerStorageEditionCapability>();
            SupportedServerVersions = new ChangeTrackingList<PostgreSqlFlexibleServerServerVersionCapability>();
            SupportedNodeTypes = new ChangeTrackingList<PostgreSqlFlexibleServerNodeTypeCapability>();
        }

        /// <summary> Initializes a new instance of PostgreSqlFlexibleServerHyperscaleNodeEditionCapability. </summary>
        /// <param name="name"> Server edition name. </param>
        /// <param name="supportedStorageEditions"> The list of editions supported by this server edition. </param>
        /// <param name="supportedServerVersions"> The list of server versions supported by this server edition. </param>
        /// <param name="supportedNodeTypes"> The list of Node Types supported by this server edition. </param>
        /// <param name="status"> The status. </param>
        internal PostgreSqlFlexibleServerHyperscaleNodeEditionCapability(string name, IReadOnlyList<PostgreSqlFlexibleServerStorageEditionCapability> supportedStorageEditions, IReadOnlyList<PostgreSqlFlexibleServerServerVersionCapability> supportedServerVersions, IReadOnlyList<PostgreSqlFlexibleServerNodeTypeCapability> supportedNodeTypes, string status)
        {
            Name = name;
            SupportedStorageEditions = supportedStorageEditions;
            SupportedServerVersions = supportedServerVersions;
            SupportedNodeTypes = supportedNodeTypes;
            Status = status;
        }

        /// <summary> Server edition name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get; }
        /// <summary> The list of editions supported by this server edition. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<PostgreSqlFlexibleServerStorageEditionCapability> SupportedStorageEditions { get; }
        /// <summary> The list of server versions supported by this server edition. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<PostgreSqlFlexibleServerServerVersionCapability> SupportedServerVersions { get; }
        /// <summary> The list of Node Types supported by this server edition. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<PostgreSqlFlexibleServerNodeTypeCapability> SupportedNodeTypes { get; }
        /// <summary> The status. </summary>
        public string Status { get; }
    }
}

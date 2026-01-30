// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Represents capability of a fast provisioning edition. </summary>
    public partial class PostgreSqlFlexibleServerFastProvisioningEditionCapability : PostgreSqlBaseCapability
    {
        /// <summary> Fast provisioning supported storage in Gb. </summary>
        [WirePath("supportedStorageGb")]
        public long? SupportedStorageGb { get; }
    }
}

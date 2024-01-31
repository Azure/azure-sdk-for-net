// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Vcores capability. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PostgreSqlFlexibleServerVCoreCapability
    {
        /// <summary> Initializes a new instance of PostgreSqlFlexibleServerVCoreCapability. </summary>
        internal PostgreSqlFlexibleServerVCoreCapability()
        {
        }

        /// <summary> Initializes a new instance of PostgreSqlFlexibleServerVCoreCapability. </summary>
        /// <param name="name"> vCore name. </param>
        /// <param name="vCores"> supported vCores. </param>
        /// <param name="supportedIops"> supported IOPS. </param>
        /// <param name="supportedMemoryPerVCoreInMB"> supported memory per vCore in MB. </param>
        /// <param name="status"> The status. </param>
        internal PostgreSqlFlexibleServerVCoreCapability(string name, long? vCores, long? supportedIops, long? supportedMemoryPerVCoreInMB, string status)
        {
            Name = name;
            VCores = vCores;
            SupportedIops = supportedIops;
            SupportedMemoryPerVCoreInMB = supportedMemoryPerVCoreInMB;
            Status = status;
        }

        /// <summary> vCore name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get; }
        /// <summary> supported vCores. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? VCores { get; }
        /// <summary> supported IOPS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? SupportedIops { get; }
        /// <summary> supported memory per vCore in MB. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? SupportedMemoryPerVCoreInMB { get; }
        /// <summary> The status. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Status { get; }
    }
}

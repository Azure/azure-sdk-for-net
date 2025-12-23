// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Vcores capability. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PostgreSqlFlexibleServerVCoreCapability
    {
        private readonly IDictionary<string, BinaryData> _serializedAdditionalRawData;

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
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal PostgreSqlFlexibleServerVCoreCapability(string name, long? vCores, long? supportedIops, long? supportedMemoryPerVCoreInMB, string status, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            VCores = vCores;
            SupportedIops = supportedIops;
            SupportedMemoryPerVCoreInMB = supportedMemoryPerVCoreInMB;
            Status = status;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> vCore name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("name")]
        public string Name { get; }
        /// <summary> supported vCores. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("vCores")]
        public long? VCores { get; }
        /// <summary> supported IOPS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("supportedIops")]
        public long? SupportedIops { get; }
        /// <summary> supported memory per vCore in MB. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("supportedMemoryPerVcoreMB")]
        public long? SupportedMemoryPerVCoreInMB { get; }
        /// <summary> The status. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("status")]
        public string Status { get; }
    }
}

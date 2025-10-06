// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> Properties for a CVE analysis summary. </summary>
    public partial class CveSummary
    {
        /// <summary> The total number of critical severity CVEs detected. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? Critical => CriticalCveCount;
        /// <summary> The total number of high severity CVEs detected. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? High => HighCveCount;
        /// <summary> The total number of medium severity CVEs detected. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? Medium => MediumCveCount;
        /// <summary> The total number of low severity CVEs detected. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? Low => LowCveCount;
        /// <summary> The total number of unknown severity CVEs detected. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? Unknown => UnknownCveCount;
    }
}

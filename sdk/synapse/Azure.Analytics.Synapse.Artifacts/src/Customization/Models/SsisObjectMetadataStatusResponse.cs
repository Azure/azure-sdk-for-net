// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> The status of the operation. </summary>
    public partial class SsisObjectMetadataStatusResponse
    {
        /// <summary> Initializes a new instance of SsisObjectMetadataStatusResponse. </summary>
        public SsisObjectMetadataStatusResponse()
        {
        }

        /// <summary> The status of the operation. </summary>
        public string Status { get; set; }
        /// <summary> The operation name. </summary>
        public string Name { get; set; }
        /// <summary> The operation properties. </summary>
        public string Properties { get; set; }
        /// <summary> The operation error message. </summary>
        public string Error { get; set; }
    }
}

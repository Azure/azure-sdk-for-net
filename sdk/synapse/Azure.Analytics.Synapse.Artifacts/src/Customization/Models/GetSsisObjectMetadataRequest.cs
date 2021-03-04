// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> The request payload of get SSIS object metadata. </summary>
    public partial class GetSsisObjectMetadataRequest
    {
        /// <summary> Initializes a new instance of GetSsisObjectMetadataRequest. </summary>
        public GetSsisObjectMetadataRequest()
        {
        }

        /// <summary> Metadata path. </summary>
        public string MetadataPath { get; set; }
    }
}

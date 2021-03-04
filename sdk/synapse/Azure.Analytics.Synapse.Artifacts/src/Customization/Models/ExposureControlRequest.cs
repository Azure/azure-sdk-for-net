// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> The exposure control request. </summary>
    public partial class ExposureControlRequest
    {
        /// <summary> Initializes a new instance of ExposureControlRequest. </summary>
        public ExposureControlRequest()
        {
        }
        /// <summary> The feature name. </summary>
        public string FeatureName { get; set; }
        /// <summary> The feature type. </summary>
        public string FeatureType { get; set; }
    }
}

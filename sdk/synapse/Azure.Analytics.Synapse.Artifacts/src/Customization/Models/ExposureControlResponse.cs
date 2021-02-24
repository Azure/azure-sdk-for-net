// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> The exposure control response. </summary>
    public partial class ExposureControlResponse
    {
        /// <summary> Initializes a new instance of ExposureControlResponse. </summary>
        public ExposureControlResponse()
        {
        }

        /// <summary> The feature name. </summary>
        public string FeatureName { get; set; }
        /// <summary> The feature value. </summary>
        public string Value { get; set; }
    }
}

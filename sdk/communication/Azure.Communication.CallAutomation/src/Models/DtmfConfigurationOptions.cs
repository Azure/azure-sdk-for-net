// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary> Represents the configuration for DTMF functionality in calls. </summary>
    public class DtmfConfigurationOptions
    {
        /// <summary> Initializes a new instance of <see cref="DtmfConfigurationOptions"/>. </summary>
        public DtmfConfigurationOptions()
        {
        }

        /// <summary> Enabling DTMF broadcast allows DTMF tones to be transmitted during group calls. </summary>
        public bool EnableDtmfBroadcastInGroupCalls { get; set; }
    }
}

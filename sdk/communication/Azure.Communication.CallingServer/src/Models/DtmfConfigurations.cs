// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Collections.Generic;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The DtmfConfigurations.
    /// </summary>
    public class DtmfConfigurations
    {
        /// <summary> Initializes a new instance of DtmfConfigurationsInternal. </summary>
        public DtmfConfigurations()
        {
            StopTones = new ChangeTrackingList<StopTones>();
        }

        /// <summary> Time to wait between DTMF inputs to stop recognizing. </summary>
        public int? InterToneTimeoutInSeconds { get; set; }
        /// <summary> Maximum number of DTMFs to be collected. </summary>
        public int? MaxTonesToCollect { get; set; }
        /// <summary> List of tones that will stop recognizing. </summary>
        public IList<StopTones> StopTones { get; }
    }
}

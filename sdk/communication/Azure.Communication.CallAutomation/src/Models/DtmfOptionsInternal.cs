// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("DtmfOptions")]
    internal partial class DtmfOptionsInternal
    {
        /// <summary>
        /// List of tones that will stop the recognition once detected.
        /// </summary>
        [CodeGenMember("StopTones")]
        public IList<DtmfTone> StopTones { get; set; }
    }
}

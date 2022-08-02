// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Communication;

namespace Azure.Communication.CallingServer
{
    /// <summary> Options for DTMF tone recognition. </summary>
    public partial class DtmfOptions
    {
        /// <summary> Initializes a new instance of DtmfOptionsInternal. </summary>
        public DtmfOptions()
        {
        }

        /// <summary> Collects the number of digit in DTMF. </summary>
        public CollectTones CollectTones { get; set; }
        /// <summary> Dtmf tone producer participant. </summary>
        public CommunicationIdentifier DtfmToneProducer { get; set; }
    }
}

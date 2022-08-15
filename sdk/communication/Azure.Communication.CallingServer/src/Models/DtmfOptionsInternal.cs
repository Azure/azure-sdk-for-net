// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallingServer
{
    [CodeGenModel("DtmfOptions")]

    internal partial class DtmfOptionsInternal
    {
        /// <summary>
        /// The identifier for the participant whose bitstream will be written to the channel.
        /// represented by the channel number.
        /// </summary>
        public CommunicationIdentifierModel DtfmToneProducer { get; set; }
    }
}

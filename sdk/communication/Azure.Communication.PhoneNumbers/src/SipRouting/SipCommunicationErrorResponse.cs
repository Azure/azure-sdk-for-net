// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.PhoneNumbers.SipRouting
{
    [CodeGenModel("CommunicationErrorResponse")]
    internal partial class SipCommunicationErrorResponse
    {
        /// <summary> The Communication Services error. </summary>
        public CommunicationError Error { get; }
    }
}

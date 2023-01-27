// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The CallSource. </summary>
    public class CallSource
    {
        /// <summary> The alternate identity of the source of the call if dialing out to a pstn number. </summary>
        public PhoneNumberIdentifier CallerId { get; set; }
        /// <summary> Display name of the caller </summary>
        public string DisplayName { get; set; }
        /// <summary> Gets the identifier. </summary>
        public CommunicationIdentifier Identifier { get; }
    }
}

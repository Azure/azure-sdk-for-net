// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The CallSource. </summary>
    public class CallSource
    {
        /// <summary> Initializes a new instance of CallSourceDto. </summary>
        /// <param name="identifier">Caller's identifier.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="identifier"/> is null. </exception>
        public CallSource(CommunicationIdentifier identifier)
        {
            if (identifier == null)
            {
                throw new ArgumentNullException(nameof(identifier));
            }

            Identifier = identifier;
        }

        /// <summary> The alternate identity of the source of the call if dialing out to a pstn number. </summary>
        public PhoneNumberIdentifier CallerId { get; set; }
        /// <summary> Display name of the caller </summary>
        public string DisplayName { get; set; }
        /// <summary> Gets the identifier. </summary>
        public CommunicationIdentifier Identifier { get; }
    }
}

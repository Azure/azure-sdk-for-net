// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallingServer.Models
{
    /// <summary> The CallSource. </summary>
    public class CallSource
    {
        /// <summary> Initializes a new instance of CallSourceDto. </summary>
        /// <param name="identifier">Caller's identifier.</param>
        /// <param name="alternateCallerId">Caller's caller Id.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="identifier"/> is null. </exception>
        public CallSource(CommunicationIdentifier identifier, PhoneNumberIdentifier alternateCallerId = null)
        {
            if (identifier == null)
            {
                throw new ArgumentNullException(nameof(identifier));
            }

            Identifier = identifier;
            AlternateCallerId = alternateCallerId;
        }

        /// <summary> The alternate identity of the source of the call if dialing out to a pstn number. </summary>
        public PhoneNumberIdentifier AlternateCallerId { get; set; }
        /// <summary> Gets the identifier. </summary>
        public CommunicationIdentifier Identifier { get; set; }
    }
}

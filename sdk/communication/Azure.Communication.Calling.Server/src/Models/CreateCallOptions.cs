// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.Calling.Server
{
    /// <summary> The options for creating a call. </summary>
    public class CreateCallOptions
    {
        /// <summary> The alternate caller id of the source. </summary>
        public PhoneNumberIdentifier AlternateCallerId { get; set; }

        /// <summary> The subject. </summary>
        public string Subject { get; set; }

        /// <summary> The callback URI. </summary>
        public Uri CallbackUri { get; }

        /// <summary> The requested modalities. </summary>
        public IList<CallModality> RequestedModalities { get; }

        /// <summary> The requested call events to subscribe to. </summary>
        public IList<EventSubscriptionType> RequestedCallEvents { get; }

        /// <summary> Initializes a new instance of CreateCallRequest. </summary>
        /// <param name="callbackUri"> The callback URI. </param>
        /// <param name="requestedModalities"> The requested modalities. </param>
        /// <param name="requestedCallEvents"> The requested call events to subscribe to. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="callbackUri"/>, <paramref name="requestedModalities"/>, or <paramref name="requestedCallEvents"/> is null. </exception>
        public CreateCallOptions(Uri callbackUri, IEnumerable<CallModality> requestedModalities, IEnumerable<EventSubscriptionType> requestedCallEvents)
        {
            if (callbackUri == null)
            {
                throw new ArgumentNullException(nameof(callbackUri));
            }
            if (requestedModalities == null)
            {
                throw new ArgumentNullException(nameof(requestedModalities));
            }
            if (requestedCallEvents == null)
            {
                throw new ArgumentNullException(nameof(requestedCallEvents));
            }

            CallbackUri = callbackUri;
            RequestedModalities = requestedModalities.ToList();
            RequestedCallEvents = requestedCallEvents.ToList();
        }
    }
}

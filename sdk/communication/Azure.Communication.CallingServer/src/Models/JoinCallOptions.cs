// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary> The options for joining a call. </summary>
    public class JoinCallOptions
    {
        /// <summary> The subject. </summary>
        public string Subject { get; set; }

        /// <summary> The callback URI. </summary>
        public Uri CallbackUri { get; }

        /// <summary> The requested media types. </summary>
        public IList<MediaType> RequestedMediaTypes { get; }

        /// <summary> The requested call events to subscribe to. </summary>
        public IList<EventSubscriptionType> RequestedCallEvents { get; }

        /// <summary> Initializes a new instance of JoinCallOptions. </summary>
        /// <param name="callbackUri"> The callback URI. </param>
        /// <param name="requestedMediaTypes"> The requested media types. </param>
        /// <param name="requestedCallEvents"> The requested call events to subscribe to. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="callbackUri"/>, <paramref name="requestedMediaTypes"/>, or <paramref name="requestedCallEvents"/> is null. </exception>
        public JoinCallOptions(Uri callbackUri, IEnumerable<MediaType> requestedMediaTypes, IEnumerable<EventSubscriptionType> requestedCallEvents)
        {
            Argument.AssertNotNull(callbackUri, nameof(callbackUri));
            Argument.AssertNotNull(requestedMediaTypes, nameof(requestedMediaTypes));
            Argument.AssertNotNull(requestedCallEvents, nameof(requestedCallEvents));

            CallbackUri = callbackUri;
            RequestedMediaTypes = requestedMediaTypes.ToList();
            RequestedCallEvents = requestedCallEvents.ToList();
        }
    }
}

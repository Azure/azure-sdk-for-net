// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The MediaStreamingSubscription. </summary>
    public class MediaStreamingSubscription
    {
        /// <summary> Initializes a new instance of <see cref="MediaStreamingSubscriptionInternal"/>. </summary>
        /// <param name="id"> Gets or Sets subscription Id. </param>
        /// <param name="state"> Gets or Sets media streaming subscription state. </param>
        /// <param name="subscribedContentTypes"> Gets or Sets the subscribed media streaming content types. </param>
        /// <param name="streamUrl"> Media streaming subscription stream URL. </param>
        public MediaStreamingSubscription(string id, MediaStreamingSubscriptionState? state, IReadOnlyList<MediaStreamingContent> subscribedContentTypes, string streamUrl)
        {
            Id = id;
            State = state;
            SubscribedContentTypes = subscribedContentTypes;
            StreamUrl = streamUrl;
        }

        /// <summary> Gets or Sets subscription Id. </summary>
        public string Id { get; }
        /// <summary> Gets or Sets media streaming subscription state. </summary>
        public MediaStreamingSubscriptionState? State { get; }
        /// <summary> Gets or Sets the subscribed media streaming content types. </summary>
        public IReadOnlyList<MediaStreamingContent> SubscribedContentTypes { get; }
        /// <summary> Media streaming subscription stream URL. </summary>
        public string StreamUrl { get; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The TranscriptionSubscription. </summary>
    public class TranscriptionSubscription
    {
        /// <summary> Initializes a new instance of <see cref="TranscriptionSubscriptionInternal"/>. </summary>
        /// <param name="id"> Gets or Sets subscription Id. </param>
        /// <param name="state"> Gets or Sets media streaming subscription state. </param>
        /// <param name="subscribedResultStates"> Gets or Sets the subscribed media streaming content types. </param>
        internal TranscriptionSubscription(string id, TranscriptionSubscriptionState? state, IReadOnlyList<TranscriptionResultState> subscribedResultStates)
        {
            Id = id;
            State = state;
            SubscribedResultStates = subscribedResultStates;
        }

        /// <summary> Gets or Sets subscription Id. </summary>
        public string Id { get; }
        /// <summary> Gets or Sets transcription subscription state. </summary>
        public TranscriptionSubscriptionState? State { get; }
        /// <summary> Gets or Sets the subscribed transcription result types. </summary>
        public IReadOnlyList<TranscriptionResultState> SubscribedResultStates { get; }
    }
}

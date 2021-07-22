// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Personalizer.Models;
using Azure.Core;

namespace Azure.AI.Personalizer
{
    /// <summary> The Personalizer service client for single and multi slot Rank, Reward and Event Activation. </summary>
    public class PersonalizerClient
    {
        /// <summary> The PersonalizerBase service client. </summary>
        internal RankClient RankClient { get; set; }
        /// <summary> The Events service client. </summary>
        internal EventsClient EventsClient { get; set; }
        /// <summary> The MultiSlot service client. </summary>
        internal MultiSlotClient MultiSlotClient { get; set; }
        /// <summary> The MultiSlotEvents service client. </summary>
        internal MultiSlotEventsClient MultiSlotEventsClient { get; set; }

        /// <summary> Initializes a new instance of Personalizer Client for mocking. </summary>
        protected PersonalizerClient()
        {
        }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PersonalizerClient(string endpoint, TokenCredential credential, PersonalizerClientOptions options = null)
        {
            RankClient = new RankClient(endpoint, credential, options);
            EventsClient = new EventsClient(endpoint, credential, options);
            MultiSlotClient = new MultiSlotClient(endpoint, credential, options);
            MultiSlotEventsClient = new MultiSlotEventsClient(endpoint, credential, options);
        }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PersonalizerClient(string endpoint, AzureKeyCredential credential, PersonalizerClientOptions options = null)
        {
            RankClient = new RankClient(endpoint, credential, options);
            EventsClient = new EventsClient(endpoint, credential, options);
            MultiSlotClient = new MultiSlotClient(endpoint, credential, options);
            MultiSlotEventsClient = new MultiSlotEventsClient(endpoint, credential, options);
        }

        /// <summary> Submit a Personalizer rank request. Receives a context and a list of actions. Returns which of the provided actions should be used by your application, in rewardActionId. </summary>
        /// <param name="rankRequest"> A Personalizer Rank request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerRankResult>> RankAsync(PersonalizerRankOptions rankRequest, CancellationToken cancellationToken = default)
        {
            return await RankClient.RankAsync(rankRequest, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Submit a Personalizer rank request. Receives a context and a list of actions. Returns which of the provided actions should be used by your application, in rewardActionId. </summary>
        /// <param name="rankRequest"> A Personalizer Rank request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerRankResult> Rank(PersonalizerRankOptions rankRequest, CancellationToken cancellationToken = default)
        {
            return RankClient.Rank(rankRequest, cancellationToken);
        }

        /// <summary> Submit a Personalizer multi-slot rank request. Receives a context, a list of actions, and a list of slots. Returns which of the provided actions should be used in each slot, in each rewardActionId. </summary>
        /// <param name="body"> A Personalizer multi-slot Rank request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerMultiSlotRankResult>> MultiSlotRankAsync(PersonalizerMultiSlotRankOptions body, CancellationToken cancellationToken = default)
        {
            return await MultiSlotClient.RankAsync(body, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Submit a Personalizer multi-slot rank request. Receives a context, a list of actions, and a list of slots. Returns which of the provided actions should be used in each slot, in each rewardActionId. </summary>
        /// <param name="body"> A Personalizer multi-slot Rank request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerMultiSlotRankResult> MultiSlotRank(PersonalizerMultiSlotRankOptions body, CancellationToken cancellationToken = default)
        {
            return MultiSlotClient.Rank(body, cancellationToken);
        }

        /// <summary> Report reward between 0 and 1 that resulted from using the action specified in rewardActionId, for the specified event. </summary>
        /// <param name="eventId"> The event id this reward applies to. </param>
        /// <param name="reward"> The reward should be a floating point number, typically between 0 and 1. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> RewardAsync(string eventId, PersonalizerRewardOptions reward, CancellationToken cancellationToken = default)
        {
            return await EventsClient.RewardAsync(eventId, reward, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Report reward between 0 and 1 that resulted from using the action specified in rewardActionId, for the specified event. </summary>
        /// <param name="eventId"> The event id this reward applies to. </param>
        /// <param name="reward"> The reward should be a floating point number, typically between 0 and 1. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Reward(string eventId, PersonalizerRewardOptions reward, CancellationToken cancellationToken = default)
        {
            return EventsClient.Reward(eventId, reward, cancellationToken);
        }

        /// <summary> Report reward that resulted from using the action specified in rewardActionId for the slot. </summary>
        /// <param name="eventId"> The event id this reward applies to. </param>
        /// <param name="body"> List of slot id and reward values. The reward should be a floating point number, typically between 0 and 1. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> MultiSlotRewardAsync(string eventId, PersonalizerMultiSlotRewardOptions body, CancellationToken cancellationToken = default)
        {
            return await MultiSlotEventsClient.RewardAsync(eventId, body, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Report reward that resulted from using the action specified in rewardActionId for the slot. </summary>
        /// <param name="eventId"> The event id this reward applies to. </param>
        /// <param name="body"> List of slot id and reward values. The reward should be a floating point number, typically between 0 and 1. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response MultiSlotReward(string eventId, PersonalizerMultiSlotRewardOptions body, CancellationToken cancellationToken = default)
        {
            return MultiSlotEventsClient.Reward(eventId, body, cancellationToken);
        }

        /// <summary> Report that the specified event was actually used (e.g. by being displayed to the user) and a reward should be expected for it. </summary>
        /// <param name="eventId"> The event ID to be activated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ActivateAsync(string eventId, CancellationToken cancellationToken = default)
        {
            return await EventsClient.ActivateAsync(eventId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Report that the specified event was actually used (e.g. by being displayed to the user) and a reward should be expected for it. </summary>
        /// <param name="eventId"> The event ID to be activated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Activate(string eventId, CancellationToken cancellationToken = default)
        {
            return EventsClient.Activate(eventId, cancellationToken);
        }

        /// <summary> Report that the specified event was actually used or displayed to the user and a rewards should be expected for it. </summary>
        /// <param name="eventId"> The event ID this activation applies to. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> MultiSlotActivateAsync(string eventId, CancellationToken cancellationToken = default)
        {
            return await MultiSlotEventsClient.ActivateAsync(eventId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Report that the specified event was actually used or displayed to the user and a rewards should be expected for it. </summary>
        /// <param name="eventId"> The event ID this activation applies to. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response MultiSlotActivate(string eventId, CancellationToken cancellationToken = default)
        {
            return MultiSlotEventsClient.Activate(eventId, cancellationToken);
        }
    }
}

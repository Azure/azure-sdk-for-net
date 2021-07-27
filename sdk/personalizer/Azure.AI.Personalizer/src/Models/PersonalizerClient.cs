// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Personalizer.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Personalizer
{
    /// <summary> The Personalizer service client for single and multi slot Rank, Reward and Event Activation. </summary>
    public class PersonalizerClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal RankRestClient RankRestClient { get; set; }
        internal EventsRestClient EventsRestClient { get; set; }
        internal MultiSlotRestClient MultiSlotRestClient { get; set; }
        internal MultiSlotEventsRestClient MultiSlotEventsRestClient { get; set; }

        /// <summary> Initializes a new instance of Personalizer Client for mocking. </summary>
        protected PersonalizerClient()
        {
        }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PersonalizerClient(Uri endpoint, TokenCredential credential, PersonalizerClientOptions options = null)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            options ??= new PersonalizerClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://cognitiveservices.azure.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes));
            string stringEndpoint = endpoint.AbsoluteUri;
            RankRestClient = new RankRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            EventsRestClient = new EventsRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            MultiSlotRestClient = new MultiSlotRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            MultiSlotEventsRestClient = new MultiSlotEventsRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
        }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public PersonalizerClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, null){ }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PersonalizerClient(Uri endpoint, AzureKeyCredential credential, PersonalizerClientOptions options = null)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            options ??= new PersonalizerClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "Ocp-Apim-Subscription-Key"));
            string stringEndpoint = endpoint.AbsoluteUri;
            RankRestClient = new RankRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            EventsRestClient = new EventsRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            MultiSlotRestClient = new MultiSlotRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            MultiSlotEventsRestClient = new MultiSlotEventsRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
        }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public PersonalizerClient(Uri endpoint, AzureKeyCredential credential): this(endpoint, credential, null) { }

        /// <summary> Initializes a new instance of MultiSlotEventsClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        internal PersonalizerClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            string stringEndpoint = endpoint.AbsoluteUri;
            RankRestClient = new RankRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            EventsRestClient = new EventsRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            MultiSlotRestClient = new MultiSlotRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            MultiSlotEventsRestClient = new MultiSlotEventsRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Submit a Personalizer rank request. Receives a context and a list of actions. Returns which of the provided actions should be used by your application, in rewardActionId. </summary>
        /// <param name="rankOptions"> A Personalizer Rank request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerRankResult>> RankAsync(PersonalizerRankOptions rankOptions, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.Rank");
            scope.Start();
            try
            {
                return await RankRestClient.RankAsync(rankOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Submit a Personalizer rank request. Receives a context and a list of actions. Returns which of the provided actions should be used by your application, in rewardActionId. </summary>
        /// <param name="actions">The set of actions the Personalizer service
        /// can pick from.
        /// The set should not contain more than 50 actions.
        /// The order of the actions does not affect the rank result but the
        /// order
        /// should match the sequence your application would have used to
        /// display them.
        /// The first item in the array will be used as Baseline item in
        /// Offline evaluations.</param>
        /// <param name="contextFeatures">Features of the context used for
        /// Personalizer as a dictionary of dictionaries. This depends on the application, and
        /// typically includes features about the current user, their
        /// device, profile information, aggregated data about time and date, etc.
        /// Features should not include personally identifiable information (PII),
        /// unique UserIDs, or precise timestamps. Need to be JSON serializable.
        /// https://docs.microsoft.com/azure/cognitive-services/personalizer/concepts-features.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerRankResult>> RankAsync(IList<PersonalizerRankableAction> actions, IList<object> contextFeatures = default(IList<object>), CancellationToken cancellationToken = default)
        {
            PersonalizerRankOptions options = new PersonalizerRankOptions(actions, contextFeatures);
            return await RankAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Submit a Personalizer rank request. Receives a context and a list of actions. Returns which of the provided actions should be used by your application, in rewardActionId. </summary>
        /// <param name="rankOptions"> A Personalizer Rank request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerRankResult> Rank(PersonalizerRankOptions rankOptions, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.Rank");
            scope.Start();
            try
            {
                return RankRestClient.Rank(rankOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Submit a Personalizer rank request. Receives a context and a list of actions. Returns which of the provided actions should be used by your application, in rewardActionId. </summary>
        /// <param name="actions">The set of actions the Personalizer service
        /// can pick from.
        /// The set should not contain more than 50 actions.
        /// The order of the actions does not affect the rank result but the
        /// order
        /// should match the sequence your application would have used to
        /// display them.
        /// The first item in the array will be used as Baseline item in
        /// Offline evaluations.</param>
        /// <param name="contextFeatures">Features of the context used for
        /// Personalizer as a dictionary of dictionaries. This depends on the application, and
        /// typically includes features about the current user, their
        /// device, profile information, aggregated data about time and date, etc.
        /// Features should not include personally identifiable information (PII),
        /// unique UserIDs, or precise timestamps. Need to be JSON serializable.
        /// https://docs.microsoft.com/azure/cognitive-services/personalizer/concepts-features.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerRankResult> Rank(IList<PersonalizerRankableAction> actions, IList<object> contextFeatures = default(IList<object>), CancellationToken cancellationToken = default)
        {
            PersonalizerRankOptions options = new PersonalizerRankOptions(actions, contextFeatures);
            return Rank(options, cancellationToken);
        }

        /// <summary> Submit a Personalizer multi-slot rank request. Receives a context, a list of actions, and a list of slots. Returns which of the provided actions should be used in each slot, in each rewardActionId. </summary>
        /// <param name="body"> A Personalizer multi-slot Rank request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerMultiSlotRankResult>> MultiSlotRankAsync(PersonalizerMultiSlotRankOptions body, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.MultiSlotRank");
            scope.Start();
            try
            {
                return await MultiSlotRestClient.RankAsync(body, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Submit a Personalizer multi-slot rank request. Receives a context, a list of actions, and a list of slots. Returns which of the provided actions should be used in each slot, in each rewardActionId. </summary>
        /// <param name="actions">
        /// The set of actions the Personalizer service can pick from.
        ///
        /// The set should not contain more than 50 actions.
        ///
        /// The order of the actions does not affect the rank result but the order
        ///
        /// should match the sequence your application would have used to display them.
        ///
        /// The first item in the array will be used as Baseline item in Offline Evaluations.
        /// </param>
        /// <param name="slots">
        /// The set of slots the Personalizer service should select actions for.
        ///
        /// The set should not contain more than 50 slots.
        /// </param>
        /// <param name="contextFeatures">Features of the context used for
        /// Personalizer as a dictionary of dictionaries. This depends on the application, and
        /// typically includes features about the current user, their
        /// device, profile information, aggregated data about time and date, etc.
        /// Features should not include personally identifiable information (PII),
        /// unique UserIDs, or precise timestamps. Need to be JSON serializable.
        /// https://docs.microsoft.com/azure/cognitive-services/personalizer/concepts-features.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerMultiSlotRankResult>> MultiSlotRankAsync(IEnumerable<PersonalizerRankableAction> actions, IEnumerable<PersonalizerSlotOptions> slots, IList<object> contextFeatures = default(IList<object>), CancellationToken cancellationToken = default)
        {
            PersonalizerMultiSlotRankOptions options = new PersonalizerMultiSlotRankOptions(actions, slots, contextFeatures);
            return await MultiSlotRankAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Submit a Personalizer multi-slot rank request. Receives a context, a list of actions, and a list of slots. Returns which of the provided actions should be used in each slot, in each rewardActionId. </summary>
        /// <param name="body"> A Personalizer multi-slot Rank request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerMultiSlotRankResult> MultiSlotRank(PersonalizerMultiSlotRankOptions body, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.MultiSlotRank");
            scope.Start();
            try
            {
                return MultiSlotRestClient.Rank(body, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Submit a Personalizer multi-slot rank request. Receives a context, a list of actions, and a list of slots. Returns which of the provided actions should be used in each slot, in each rewardActionId. </summary>
        /// <param name="actions">
        /// The set of actions the Personalizer service can pick from.
        ///
        /// The set should not contain more than 50 actions.
        ///
        /// The order of the actions does not affect the rank result but the order
        ///
        /// should match the sequence your application would have used to display them.
        ///
        /// The first item in the array will be used as Baseline item in Offline Evaluations.
        /// </param>
        /// <param name="slots">
        /// The set of slots the Personalizer service should select actions for.
        ///
        /// The set should not contain more than 50 slots.
        /// </param>
        /// <param name="contextFeatures">Features of the context used for
        /// Personalizer as a dictionary of dictionaries. This depends on the application, and
        /// typically includes features about the current user, their
        /// device, profile information, aggregated data about time and date, etc.
        /// Features should not include personally identifiable information (PII),
        /// unique UserIDs, or precise timestamps. Need to be JSON serializable.
        /// https://docs.microsoft.com/azure/cognitive-services/personalizer/concepts-features.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerMultiSlotRankResult> MultiSlotRank(IEnumerable<PersonalizerRankableAction> actions, IEnumerable<PersonalizerSlotOptions> slots, IList<object> contextFeatures = default(IList<object>), CancellationToken cancellationToken = default)
        {
            PersonalizerMultiSlotRankOptions options = new PersonalizerMultiSlotRankOptions(actions, slots, contextFeatures);
            return MultiSlotRank(options, cancellationToken);
        }

        /// <summary> Report reward between 0 and 1 that resulted from using the action specified in rewardActionId, for the specified event. </summary>
        /// <param name="eventId"> The event id this reward applies to. </param>
        /// <param name="rewardValue"> The reward should be a floating point number, typically between 0 and 1. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> RewardAsync(string eventId, float rewardValue, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.Reward");
            scope.Start();
            try
            {
                PersonalizerRewardOptions reward = new PersonalizerRewardOptions(rewardValue);
                return await EventsRestClient.RewardAsync(eventId, reward, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Report reward between 0 and 1 that resulted from using the action specified in rewardActionId, for the specified event. </summary>
        /// <param name="eventId"> The event id this reward applies to. </param>
        /// <param name="rewardValue"> The reward should be a floating point number, typically between 0 and 1. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Reward(string eventId, float rewardValue, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.Reward");
            scope.Start();
            try
            {
                PersonalizerRewardOptions reward = new PersonalizerRewardOptions(rewardValue);
                return EventsRestClient.Reward(eventId, reward, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Report reward that resulted from using the action specified in rewardActionId for the slot. </summary>
        /// <param name="eventId"> The event id this reward applies to. </param>
        /// <param name="body"> List of slot id and reward values. The reward should be a floating point number, typically between 0 and 1. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> MultiSlotRewardAsync(string eventId, PersonalizerMultiSlotRewardOptions body, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.MultiSlotReward");
            scope.Start();
            try
            {
                return await MultiSlotEventsRestClient.RewardAsync(eventId, body, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Report reward that resulted from using the action specified in rewardActionId for the slot. </summary>
        /// <param name="eventId"> The event id this reward applies to. </param>
        /// <param name="slotId"> Slot id for which we are sending the reward. </param>
        /// <param name="rewardValue"> Reward to be assigned to slotId. Value should be between -1 and 1 inclusive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> MultiSlotRewardAsync(string eventId, string slotId, float rewardValue, CancellationToken cancellationToken = default)
        {
            PersonalizerMultiSlotRewardOptions options = new PersonalizerMultiSlotRewardOptions(new List<PersonalizerSlotReward> { new PersonalizerSlotReward(slotId, rewardValue) });
            return await MultiSlotRewardAsync(eventId, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Report reward that resulted from using the action specified in rewardActionId for the slot. </summary>
        /// <param name="eventId"> The event id this reward applies to. </param>
        /// <param name="body"> List of slot id and reward values. The reward should be a floating point number, typically between 0 and 1. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response MultiSlotReward(string eventId, PersonalizerMultiSlotRewardOptions body, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.MultiSlotReward");
            scope.Start();
            try
            {
                return MultiSlotEventsRestClient.Reward(eventId, body, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Report reward that resulted from using the action specified in rewardActionId for the slot. </summary>
        /// <param name="eventId"> The event id this reward applies to. </param>
        /// <param name="slotId"> Slot id for which we are sending the reward. </param>
        /// <param name="rewardValue"> Reward to be assigned to slotId. Value should be between -1 and 1 inclusive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response MultiSlotReward(string eventId, string slotId, float rewardValue, CancellationToken cancellationToken = default)
        {
            PersonalizerMultiSlotRewardOptions options = new PersonalizerMultiSlotRewardOptions(new List<PersonalizerSlotReward> { new PersonalizerSlotReward(slotId, rewardValue) });
            return MultiSlotReward(eventId, options, cancellationToken);
        }

        /// <summary> Report that the specified event was actually used (e.g. by being displayed to the user) and a reward should be expected for it. </summary>
        /// <param name="eventId"> The event ID to be activated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ActivateAsync(string eventId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.Activate");
            scope.Start();
            try
            {
                return await EventsRestClient.ActivateAsync(eventId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Report that the specified event was actually used (e.g. by being displayed to the user) and a reward should be expected for it. </summary>
        /// <param name="eventId"> The event ID to be activated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Activate(string eventId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.Activate");
            scope.Start();
            try
            {
                return EventsRestClient.Activate(eventId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Report that the specified event was actually used or displayed to the user and a rewards should be expected for it. </summary>
        /// <param name="eventId"> The event ID this activation applies to. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> MultiSlotActivateAsync(string eventId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.MultiSlotActivate");
            scope.Start();
            try
            {
                return await MultiSlotEventsRestClient.ActivateAsync(eventId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Report that the specified event was actually used or displayed to the user and a rewards should be expected for it. </summary>
        /// <param name="eventId"> The event ID this activation applies to. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response MultiSlotActivate(string eventId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.MultiSlotActivate");
            scope.Start();
            try
            {
                return MultiSlotEventsRestClient.Activate(eventId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}

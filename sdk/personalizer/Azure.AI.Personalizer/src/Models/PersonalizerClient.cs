// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Rl.Net;

namespace Azure.AI.Personalizer
{
    /// <summary> The Personalizer service client for single and multi slot Rank, Reward and Event Activation. </summary>
    ///<see href="https://docs.microsoft.com/azure/cognitive-services/personalizer/what-is-personalizer"/>
    public class PersonalizerClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        private readonly bool _isLocalInference;
        private string stringEndpoint;
        private string apiKey;
        private float _interactionsSubsampleRate = 1.0f;
        private float _observationsSubsampleRate = 1.0f;

        private readonly RankProcessor _rankProcessor;

        internal RankRestClient RankRestClient { get; set; }
        internal EventsRestClient EventsRestClient { get; set; }
        internal MultiSlotRestClient MultiSlotRestClient { get; set; }
        internal MultiSlotEventsRestClient MultiSlotEventsRestClient { get; set; }
        internal ServiceConfigurationRestClient ServiceConfigurationRestClient { get; set; }
        internal PolicyRestClient PolicyRestClient { get; set; }
        internal PersonalizerServiceProperties _personalizerServiceProperties { get; set; }
        internal PersonalizerPolicy _personalizerPolicy { get; set; }

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
            stringEndpoint = endpoint.AbsoluteUri;
            RankRestClient = new RankRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            EventsRestClient = new EventsRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            MultiSlotRestClient = new MultiSlotRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            MultiSlotEventsRestClient = new MultiSlotEventsRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            ServiceConfigurationRestClient = new ServiceConfigurationRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            PolicyRestClient = new PolicyRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
        }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="isLocalInference"> A flag to determine whether to use local inference. </param>
        /// <param name="interactionsSubsampleRate"> Percentage from (0,1] determines how much percentage of interaction events to consider </param>
        /// <param name="observationsSubSampleRate"> Percentage from (0,1] determines how much percentage of observation events to consider </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PersonalizerClient(Uri endpoint, TokenCredential credential, bool isLocalInference, float interactionsSubsampleRate = 1.0f, float observationsSubSampleRate = 1.0f, PersonalizerClientOptions options = null) :
            this(endpoint, credential, options)
        {
            _isLocalInference = isLocalInference;
            if (isLocalInference)
            {
                validateAndAssignSampleRate(interactionsSubsampleRate, observationsSubSampleRate);
                //Intialize liveModel and call Rank processor
                //ToDo:TASK 13057958: Working on changes to support token authentication in RLClient
                Configuration configuration = GetConfigurationForLiveModel("Token", "token");
                LiveModel liveModel = new LiveModel(configuration);
                liveModel.Init();
                _rankProcessor = new RankProcessor(liveModel);
            }
        }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public PersonalizerClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, null) { }

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
            apiKey = credential.Key;
            options ??= new PersonalizerClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "Ocp-Apim-Subscription-Key"));
            stringEndpoint = endpoint.AbsoluteUri;
            RankRestClient = new RankRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            EventsRestClient = new EventsRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            MultiSlotRestClient = new MultiSlotRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            MultiSlotEventsRestClient = new MultiSlotEventsRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            ServiceConfigurationRestClient = new ServiceConfigurationRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            PolicyRestClient = new PolicyRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
        }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="isLocalInference"> A flag to determine whether to use local inference. </param>
        /// <param name="interactionsSubsampleRate"> Percentage from (0,1] determines how much percentage of interaction events to consider </param>
        /// <param name="observationsSubSampleRate"> Percentage from (0,1] determines how much percentage of observation events to consider </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PersonalizerClient(Uri endpoint, AzureKeyCredential credential, bool isLocalInference, float interactionsSubsampleRate = 1.0f, float observationsSubSampleRate = 1.0f, PersonalizerClientOptions options = null) :
            this(endpoint, credential, options)
        {
            _isLocalInference = isLocalInference;
            if (isLocalInference)
            {
                validateAndAssignSampleRate(interactionsSubsampleRate, observationsSubSampleRate);
                //Intialize liveModel and Rankprocessor
                Configuration configuration = GetConfigurationForLiveModel("apiKey", apiKey);
                LiveModel liveModel = new LiveModel(configuration);
                liveModel.Init();
                _rankProcessor = new RankProcessor(liveModel);
            }
        }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public PersonalizerClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, null) { }

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
        /// <param name="options"> A Personalizer Rank request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerRankResult>> RankAsync(PersonalizerRankOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.Rank");
            scope.Start();
            try
            {
                if (_isLocalInference)
                {
                    return _rankProcessor.Rank(options);
                }
                else
                {
                    return await RankRestClient.RankAsync(options, cancellationToken).ConfigureAwait(false);
                }
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
        public virtual async Task<Response<PersonalizerRankResult>> RankAsync(IEnumerable<PersonalizerRankableAction> actions, IEnumerable<object> contextFeatures, CancellationToken cancellationToken = default)
        {
            PersonalizerRankOptions options = new PersonalizerRankOptions(actions, contextFeatures);
            return await RankAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Submit a Personalizer rank request. Receives a context and a list of actions. Returns which of the provided actions should be used by your application, in rewardActionId. </summary>
        /// <param name="options"> A Personalizer Rank request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerRankResult> Rank(PersonalizerRankOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.Rank");
            scope.Start();
            try
            {
                if (_isLocalInference)
                {
                    return _rankProcessor.Rank(options);
                }
                else
                {
                    return RankRestClient.Rank(options, cancellationToken);
                }
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
        public virtual Response<PersonalizerRankResult> Rank(IEnumerable<PersonalizerRankableAction> actions, IEnumerable<object> contextFeatures, CancellationToken cancellationToken = default)
        {
            PersonalizerRankOptions options = new PersonalizerRankOptions(actions, contextFeatures);
            return Rank(options, cancellationToken);
        }

        /// <summary> Submit a Personalizer multi-slot rank request. Receives a context, a list of actions, and a list of slots. Returns which of the provided actions should be used in each slot, in each rewardActionId. </summary>
        /// <param name="options"> A Personalizer multi-slot Rank request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerMultiSlotRankResult>> RankMultiSlotAsync(PersonalizerRankMultiSlotOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.RankMultiSlot");
            scope.Start();
            try
            {
                if (_isLocalInference)
                {
                    return _rankProcessor.Rank(options);
                }
                else
                {
                    return await MultiSlotRestClient.RankAsync(options, cancellationToken).ConfigureAwait(false);
                }
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
        public virtual async Task<Response<PersonalizerMultiSlotRankResult>> RankMultiSlotAsync(IEnumerable<PersonalizerRankableAction> actions, IEnumerable<PersonalizerSlotOptions> slots, IList<object> contextFeatures, CancellationToken cancellationToken = default)
        {
            PersonalizerRankMultiSlotOptions options = new PersonalizerRankMultiSlotOptions(actions, slots, contextFeatures);
            return await RankMultiSlotAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Submit a Personalizer multi-slot rank request. Receives a context, a list of actions, and a list of slots. Returns which of the provided actions should be used in each slot, in each rewardActionId. </summary>
        /// <param name="options"> A Personalizer multi-slot Rank request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerMultiSlotRankResult> RankMultiSlot(PersonalizerRankMultiSlotOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.RankMultiSlot");
            scope.Start();
            try
            {
                if (_isLocalInference)
                {
                    return _rankProcessor.Rank(options);
                }
                else
                {
                    return MultiSlotRestClient.Rank(options, cancellationToken);
                }
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
        public virtual Response<PersonalizerMultiSlotRankResult> RankMultiSlot(IEnumerable<PersonalizerRankableAction> actions, IEnumerable<PersonalizerSlotOptions> slots, IList<object> contextFeatures, CancellationToken cancellationToken = default)
        {
            PersonalizerRankMultiSlotOptions options = new PersonalizerRankMultiSlotOptions(actions, slots, contextFeatures);
            return RankMultiSlot(options, cancellationToken);
        }

        /// <summary> Report reward between 0 and 1 that resulted from using the action specified in rewardActionId, for the specified event. </summary>
        /// <param name="eventId"> The event id this reward applies to. </param>
        /// <param name="reward"> The reward should be a floating point number, typically between 0 and 1. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> RewardAsync(string eventId, float reward, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.Reward");
            scope.Start();
            try
            {
                PersonalizerRewardOptions rewardOptions = new PersonalizerRewardOptions(reward);
                return await EventsRestClient.RewardAsync(eventId, rewardOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Report reward between 0 and 1 that resulted from using the action specified in rewardActionId, for the specified event. </summary>
        /// <param name="eventId"> The event id this reward applies to. </param>
        /// <param name="reward"> The reward should be a floating point number, typically between 0 and 1. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Reward(string eventId, float reward, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.Reward");
            scope.Start();
            try
            {
                PersonalizerRewardOptions rewardOptions = new PersonalizerRewardOptions(reward);
                return EventsRestClient.Reward(eventId, rewardOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Report reward that resulted from using the action specified in rewardActionId for the slot. </summary>
        /// <param name="eventId"> The event id this reward applies to. </param>
        /// <param name="options"> List of slot id and reward values. The reward should be a floating point number, typically between 0 and 1. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> RewardMultiSlotAsync(string eventId, PersonalizerRewardMultiSlotOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.RewardMultiSlot");
            scope.Start();
            try
            {
                return await MultiSlotEventsRestClient.RewardAsync(eventId, options, cancellationToken).ConfigureAwait(false);
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
        /// <param name="reward"> Reward to be assigned to slotId. Value should be between -1 and 1 inclusive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> RewardMultiSlotAsync(string eventId, string slotId, float reward, CancellationToken cancellationToken = default)
        {
            PersonalizerRewardMultiSlotOptions options = new PersonalizerRewardMultiSlotOptions(new List<PersonalizerSlotReward> { new PersonalizerSlotReward(slotId, reward) });
            return await RewardMultiSlotAsync(eventId, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Report reward that resulted from using the action specified in rewardActionId for the slot. </summary>
        /// <param name="eventId"> The event id this reward applies to. </param>
        /// <param name="options"> List of slot id and reward values. The reward should be a floating point number, typically between 0 and 1. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response RewardMultiSlot(string eventId, PersonalizerRewardMultiSlotOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.RewardMultiSlot");
            scope.Start();
            try
            {
                return MultiSlotEventsRestClient.Reward(eventId, options, cancellationToken);
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
        /// <param name="reward"> Reward to be assigned to slotId. Value should be between -1 and 1 inclusive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response RewardMultiSlot(string eventId, string slotId, float reward, CancellationToken cancellationToken = default)
        {
            PersonalizerRewardMultiSlotOptions options = new PersonalizerRewardMultiSlotOptions(new List<PersonalizerSlotReward> { new PersonalizerSlotReward(slotId, reward) });
            return RewardMultiSlot(eventId, options, cancellationToken);
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
        public virtual async Task<Response> ActivateMultiSlotAsync(string eventId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.ActivateMultiSlot");
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
        public virtual Response ActivateMultiSlot(string eventId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerClient.ActivateMultiSlot");
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

        /// <summary> Gets the configuration details for the live model to use </summary>
        internal Configuration GetConfigurationForLiveModel(string authType, string authValue)
        {
            _personalizerServiceProperties = ServiceConfigurationRestClient.Get();
            _personalizerPolicy = PolicyRestClient.Get();
            Configuration config = new Configuration();
            // set up the model
            if (authType == "apiKey")
            {
                config["http.api.key"] = authValue;
            }
            else
            {
                //ToDo: TASK 13057958 Working on changes to support token authentication in RLClient
                //config["http.token.key"] = authValue;
            }
            config["interaction.http.api.host"] = stringEndpoint+"personalizer/v1.1-preview.2/logs/interactions";
            config["observation.http.api.host"] = stringEndpoint+"personalizer/v1.1-preview.2/logs/observations";
            config["interaction.subsample.rate"] = Convert.ToString(_interactionsSubsampleRate, CultureInfo.InvariantCulture);
            config["observation.subsample.rate"] = Convert.ToString(_observationsSubsampleRate, CultureInfo.InvariantCulture);
            //ToDo: TASK 13057958 Working on changes to support model api in RL.Net
            config["model.blob.uri"] = stringEndpoint + "personalizer/v1.1-preview.1/model";
            config["vw.commandline"] = _personalizerPolicy.Arguments;
            config["protocol.version"] = "2";
            config["initial_exploration.epsilon"] = Convert.ToString(_personalizerServiceProperties.ExplorationPercentage, CultureInfo.InvariantCulture);
            config["rank.learning.mode"] = Convert.ToString(_personalizerServiceProperties.LearningMode, CultureInfo.InvariantCulture);
            //return the config model
            return config;
        }

        /// <summary> validate interactionsSubsampleRate and observationsSubSampleRate inputs from user and throws exception if not in range </summary>
        private void validateAndAssignSampleRate(float interactionsSubsampleRate,float observationsSubSampleRate)
        {
            if (0 >= interactionsSubsampleRate || interactionsSubsampleRate > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(interactionsSubsampleRate), "Percentage should be between (0,1]");
            }
            if (0 >= observationsSubSampleRate || observationsSubSampleRate > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(observationsSubSampleRate), "Percentage should be between (0,1]");
            }
            _interactionsSubsampleRate = interactionsSubsampleRate;
            _observationsSubsampleRate = observationsSubSampleRate;
        }
    }
}

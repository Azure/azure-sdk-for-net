// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;

namespace Azure.AI.Personalizer
{
    /// <summary> The Personalizer service client. </summary>
    public partial class PersonalizerClient
    {
        /// <summary> The PersonalizerV1Preview1 service client. </summary>
        public PersonalizerV1Preview1Client PersonalizerV1Preview1;
        /// <summary> The MultiSlot service client. </summary>
        public MultiSlotClient MultiSlot;
        /// <summary> The MultiSlotEvents service client. </summary>
        public MultiSlotEventsClient MultiSlotEvents;
        /// <summary> The Model service client. </summary>
        public ModelClient Model;
        /// <summary> The Log service client. </summary>
        public LogClient Log;
        /// <summary> The Events service client. </summary>
        public EventsClient Events;
        /// <summary> The Evaluation service client. </summary>
        public EvaluationClient Evaluation;
        /// <summary> The Evaluations service client. </summary>
        public EvaluationsClient Evaluations;
        /// <summary> The Policy service client. </summary>
        public PolicyClient Policy;
        /// <summary> The ServiceConfiguration service client. </summary>
        public ServiceConfigurationClient ServiceConfiguration;

        /// <summary> Initializes a new instance of PersonalizerV1Preview1Client for mocking. </summary>
        protected PersonalizerClient()
        {
        }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PersonalizerClient(string endpoint, TokenCredential credential, PersonalizerV1Preview1ClientOptions options = null)
        {
            PersonalizerV1Preview1 = new PersonalizerV1Preview1Client(endpoint, credential, options);
            MultiSlot = new MultiSlotClient(endpoint, credential, options);
            MultiSlotEvents = new MultiSlotEventsClient(endpoint, credential, options);
            Model = new ModelClient(endpoint, credential, options);
            Log = new LogClient(endpoint, credential, options);
            Events = new EventsClient(endpoint, credential, options);
            Evaluation = new EvaluationClient(endpoint, credential, options);
            Evaluations = new EvaluationsClient(endpoint, credential, options);
            Policy = new PolicyClient(endpoint, credential, options);
            ServiceConfiguration = new ServiceConfigurationClient(endpoint, credential, options);
        }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PersonalizerClient(string endpoint, AzureKeyCredential credential, PersonalizerV1Preview1ClientOptions options = null)
        {
            PersonalizerV1Preview1 = new PersonalizerV1Preview1Client(endpoint, credential, options);
            MultiSlot = new MultiSlotClient(endpoint, credential, options);
            MultiSlotEvents = new MultiSlotEventsClient(endpoint, credential, options);
            Model = new ModelClient(endpoint, credential, options);
            Log = new LogClient(endpoint, credential, options);
            Events = new EventsClient(endpoint, credential, options);
            Evaluation = new EvaluationClient(endpoint, credential, options);
            Evaluations = new EvaluationsClient(endpoint, credential, options);
            Policy = new PolicyClient(endpoint, credential, options);
            ServiceConfiguration = new ServiceConfigurationClient(endpoint, credential, options);
        }
    }
}

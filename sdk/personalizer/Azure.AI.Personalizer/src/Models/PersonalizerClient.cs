// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;

namespace Azure.AI.Personalizer
{
    /// <summary> The Personalizer service client. </summary>
    public partial class PersonalizerClient
    {
        /// <summary> The PersonalizerBase service client. </summary>
        public PersonalizerBaseClient PersonalizerBase { get; set; }
        /// <summary> The MultiSlot service client. </summary>
        public MultiSlotClient MultiSlot { get; set; }
        /// <summary> The MultiSlotEvents service client. </summary>
        public MultiSlotEventsClient MultiSlotEvents { get; set; }
        /// <summary> The Model service client. </summary>
        public ModelClient Model { get; set; }
        /// <summary> The Log service client. </summary>
        public LogClient Log { get; set; }
        /// <summary> The Events service client. </summary>
        public EventsClient Events { get; set; }
        /// <summary> The Evaluations service client. </summary>
        public EvaluationsClient Evaluations { get; set; }
        /// <summary> The Policy service client. </summary>
        public PolicyClient Policy { get; set; }
        /// <summary> The ServiceConfiguration service client. </summary>
        public ServiceConfigurationClient ServiceConfiguration { get; set; }

        /// <summary> Initializes a new instance of PersonalizerBaseClient for mocking. </summary>
        protected PersonalizerClient()
        {
        }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PersonalizerClient(string endpoint, TokenCredential credential, PersonalizerBaseClientOptions options = null)
        {
            PersonalizerBase = new PersonalizerBaseClient(endpoint, credential, options);
            MultiSlot = new MultiSlotClient(endpoint, credential, options);
            MultiSlotEvents = new MultiSlotEventsClient(endpoint, credential, options);
            Model = new ModelClient(endpoint, credential, options);
            Log = new LogClient(endpoint, credential, options);
            Events = new EventsClient(endpoint, credential, options);
            Evaluations = new EvaluationsClient(endpoint, credential, options);
            Policy = new PolicyClient(endpoint, credential, options);
            ServiceConfiguration = new ServiceConfigurationClient(endpoint, credential, options);
        }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PersonalizerClient(string endpoint, AzureKeyCredential credential, PersonalizerBaseClientOptions options = null)
        {
            PersonalizerBase = new PersonalizerBaseClient(endpoint, credential, options);
            MultiSlot = new MultiSlotClient(endpoint, credential, options);
            MultiSlotEvents = new MultiSlotEventsClient(endpoint, credential, options);
            Model = new ModelClient(endpoint, credential, options);
            Log = new LogClient(endpoint, credential, options);
            Events = new EventsClient(endpoint, credential, options);
            Evaluations = new EvaluationsClient(endpoint, credential, options);
            Policy = new PolicyClient(endpoint, credential, options);
            ServiceConfiguration = new ServiceConfigurationClient(endpoint, credential, options);
        }
    }
}

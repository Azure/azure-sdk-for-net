// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;

namespace Azure.AI.Personalizer
{
    /// <summary> The Personalizer service client. </summary>
    public partial class PersonalizerClient
    {
        /// <summary> The PersonalizerV1Preview1 service client. </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Design",
            "CA1051:Do not declare visible instance fields",
            Justification = "Client field in wrapper client should be visible so that its methods are accessible")]
        public PersonalizerV1Preview1Client PersonalizerV1Preview1;
        /// <summary> The MultiSlot service client. </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Design",
            "CA1051:Do not declare visible instance fields",
            Justification = "Client field in wrapper client should be visible so that its methods are accessible")]
        public MultiSlotClient MultiSlot;
        /// <summary> The MultiSlotEvents service client. </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Design",
            "CA1051:Do not declare visible instance fields",
            Justification = "Client field in wrapper client should be visible so that its methods are accessible")]
        public MultiSlotEventsClient MultiSlotEvents;
        /// <summary> The Model service client. </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Design",
            "CA1051:Do not declare visible instance fields",
            Justification = "Client field in wrapper client should be visible so that its methods are accessible")]
        public ModelClient Model;
        /// <summary> The Log service client. </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Design",
            "CA1051:Do not declare visible instance fields",
            Justification = "Client field in wrapper client should be visible so that its methods are accessible")]
        public LogClient Log;
        /// <summary> The Events service client. </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Design",
            "CA1051:Do not declare visible instance fields",
            Justification = "Client field in wrapper client should be visible so that its methods are accessible")]
        public EventsClient Events;
        /// <summary> The Evaluation service client. </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Design",
            "CA1051:Do not declare visible instance fields",
            Justification = "Client field in wrapper client should be visible so that its methods are accessible")]
        public EvaluationClient Evaluation;
        /// <summary> The Evaluations service client. </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Design",
            "CA1051:Do not declare visible instance fields",
            Justification = "Client field in wrapper client should be visible so that its methods are accessible")]
        public EvaluationsClient Evaluations;
        /// <summary> The Policy service client. </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Design",
            "CA1051:Do not declare visible instance fields",
            Justification = "Client field in wrapper client should be visible so that its methods are accessible")]
        public PolicyClient Policy;
        /// <summary> The ServiceConfiguration service client. </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Design",
            "CA1051:Do not declare visible instance fields",
            Justification = "Client field in wrapper client should be visible so that its methods are accessible")]
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

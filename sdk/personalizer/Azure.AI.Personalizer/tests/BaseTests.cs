using System.Net.Http;
using Azure;
using Azure.AI.Personalizer;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Microsoft.Azure.AI.Personalizer.Tests
{
    public abstract class BaseTests
    {
        public static bool IsTestTenant = false;
        // BaseEndpoint only contains protocol and hostname
        private static string BaseEndpoint = "http://localhost:5000";
        private static string ApiKey = "000";
        private HttpPipeline _pipeline;
        private ClientDiagnostics _clientDiagnostics;

        internal PersonalizerClientV1Preview1RestClient GetPersonalizerClient(DelegatingHandler handler)
        {
            var credential = new AzureKeyCredential(ApiKey);
            _clientDiagnostics = new ClientDiagnostics(null);
            _pipeline = HttpPipelineBuilder.Build(null, new AzureKeyCredentialPolicy(credential, "Ocp-Apim-Subscription-Key"));  ;
            return new PersonalizerClientV1Preview1RestClient(clientDiagnostics: _clientDiagnostics, pipeline: _pipeline, endpoint: BaseEndpoint);
        }

        internal EvaluationRestClient GetEvaluationClient(DelegatingHandler handler)
        {
            var credential = new AzureKeyCredential(ApiKey);
            _clientDiagnostics = new ClientDiagnostics(null);
            _pipeline = HttpPipelineBuilder.Build(null, new AzureKeyCredentialPolicy(credential, "Ocp-Apim-Subscription-Key"));
            ;
            return new EvaluationRestClient(clientDiagnostics: _clientDiagnostics, pipeline: _pipeline, endpoint: BaseEndpoint);
        }

        internal EvaluationsRestClient GetEvaluationsClient(DelegatingHandler handler)
        {
            var credential = new AzureKeyCredential(ApiKey);
            _clientDiagnostics = new ClientDiagnostics(null);
            _pipeline = HttpPipelineBuilder.Build(null, new AzureKeyCredentialPolicy(credential, "Ocp-Apim-Subscription-Key"));
            ;
            return new EvaluationsRestClient(clientDiagnostics: _clientDiagnostics, pipeline: _pipeline, endpoint: BaseEndpoint);
        }
        internal EventsRestClient GetEventsClient(DelegatingHandler handler)
        {
            var credential = new AzureKeyCredential(ApiKey);
            _clientDiagnostics = new ClientDiagnostics(null);
            _pipeline = HttpPipelineBuilder.Build(null, new AzureKeyCredentialPolicy(credential, "Ocp-Apim-Subscription-Key"));
            ;
            return new EventsRestClient(clientDiagnostics: _clientDiagnostics, pipeline: _pipeline, endpoint: BaseEndpoint);
        }

        internal LogRestClient GetLogClient(DelegatingHandler handler)
        {
            var credential = new AzureKeyCredential(ApiKey);
            _clientDiagnostics = new ClientDiagnostics(null);
            _pipeline = HttpPipelineBuilder.Build(null, new AzureKeyCredentialPolicy(credential, "Ocp-Apim-Subscription-Key"));
            ;
            return new LogRestClient(clientDiagnostics: _clientDiagnostics, pipeline: _pipeline, endpoint: BaseEndpoint);
        }

        internal ModelRestClient GetModelClient(DelegatingHandler handler)
        {
            var credential = new AzureKeyCredential(ApiKey);
            _clientDiagnostics = new ClientDiagnostics(null);
            _pipeline = HttpPipelineBuilder.Build(null, new AzureKeyCredentialPolicy(credential, "Ocp-Apim-Subscription-Key"));
            ;
            return new ModelRestClient(clientDiagnostics: _clientDiagnostics, pipeline: _pipeline, endpoint: BaseEndpoint);
        }

        internal MultiSlotEventsRestClient GetMultiSlotEventClient(DelegatingHandler handler)
        {
            var credential = new AzureKeyCredential(ApiKey);
            _clientDiagnostics = new ClientDiagnostics(null);
            _pipeline = HttpPipelineBuilder.Build(null, new AzureKeyCredentialPolicy(credential, "Ocp-Apim-Subscription-Key"));
            ;
            return new MultiSlotEventsRestClient(clientDiagnostics: _clientDiagnostics, pipeline: _pipeline, endpoint: BaseEndpoint);
        }

        internal MultiSlotRestClient GetMultiSlotClient(DelegatingHandler handler)
        {
            var credential = new AzureKeyCredential(ApiKey);
            _clientDiagnostics = new ClientDiagnostics(null);
            _pipeline = HttpPipelineBuilder.Build(null, new AzureKeyCredentialPolicy(credential, "Ocp-Apim-Subscription-Key"));
            ;
            return new MultiSlotRestClient(clientDiagnostics: _clientDiagnostics, pipeline: _pipeline, endpoint: BaseEndpoint);
        }

        internal PolicyRestClient GetPolicyClient(DelegatingHandler handler)
        {
            var credential = new AzureKeyCredential(ApiKey);
            _clientDiagnostics = new ClientDiagnostics(null);
            _pipeline = HttpPipelineBuilder.Build(null, new AzureKeyCredentialPolicy(credential, "Ocp-Apim-Subscription-Key"));
            ;
            return new PolicyRestClient(clientDiagnostics: _clientDiagnostics, pipeline: _pipeline, endpoint: BaseEndpoint);
        }

        internal ServiceConfigurationRestClient GetServiceConfigurationClient(DelegatingHandler handler)
        {
            var credential = new AzureKeyCredential(ApiKey);
            _clientDiagnostics = new ClientDiagnostics(null);
            _pipeline = HttpPipelineBuilder.Build(null, new AzureKeyCredentialPolicy(credential, "Ocp-Apim-Subscription-Key"));
            ;
            return new ServiceConfigurationRestClient(clientDiagnostics: _clientDiagnostics, pipeline: _pipeline, endpoint: BaseEndpoint);
        }
    }
}

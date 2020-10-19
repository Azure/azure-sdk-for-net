using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using System.Net.Http;

namespace QnAMaker.Tests
{
    public abstract class BaseTests
    {
        public static bool IsTestTenant = false;
        private static readonly string QnAMakerPreviewSubscriptionKey;
        private static readonly string QnAMakerSubscriptionKey;
        private static readonly string QnAMakerEndpointKey;

        static BaseTests()
        {
            // Retrieve the configuration information.
            QnAMakerPreviewSubscriptionKey = "";
            QnAMakerSubscriptionKey = "";
            QnAMakerEndpointKey = "";
        }

        protected IQnAMakerClient GetQnAMakerClient(DelegatingHandler handler)
        {
            IQnAMakerClient client = new QnAMakerClient(new ApiKeyServiceClientCredentials(QnAMakerPreviewSubscriptionKey), handlers: handler)
            {
                Endpoint = "https://australiaeast.api.cognitive.microsoft.com"
            };

            return client;
        }

        protected IQnAMakerClient GetQnAMakerCustomDomainClient(DelegatingHandler handler)
        {
            IQnAMakerClient client = new QnAMakerClient(new ApiKeyServiceClientCredentials(QnAMakerSubscriptionKey), handlers: handler)
            {
                Endpoint = "https://sk4cs.cognitiveservices.azure.com"
            };

            return client;
        }

        protected QnAMakerRuntimeClient GetQnAMakerRuntimeClient(DelegatingHandler handler)
        {
            var client = new QnAMakerRuntimeClient(new EndpointKeyServiceClientCredentials(QnAMakerEndpointKey), handlers: handler)
            {
                RuntimeEndpoint = "https://sk4cs.azurewebsites.net"
            };

            return client;
        }        
    }
}

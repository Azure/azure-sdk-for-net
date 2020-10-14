using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using System.Net.Http;

namespace QnAMaker.Tests
{
    public abstract class BaseTests
    {
        public static bool IsTestTenant = false;
        private static readonly string QnAMakerSubscriptionKey;
        private static readonly string QnAMakerEndpointKey;

        static BaseTests()
        {
            // Retrieve the configuration information.
            QnAMakerSubscriptionKey = "";
            QnAMakerEndpointKey = "";
        }

        protected IQnAMakerClient GetQnAMakerClient(DelegatingHandler handler)
        {
            IQnAMakerClient client = new QnAMakerClient(new ApiKeyServiceClientCredentials(QnAMakerSubscriptionKey), handlers: handler)
            {
                Endpoint = "https://westus.api.cognitive.microsoft.com"
            };

            return client;
        }

        protected IQnAMakerClient GetQnAMakerPreviewClient(DelegatingHandler handler)
        {
            IQnAMakerClient client = new QnAMakerClient(new ApiKeyServiceClientCredentials(QnAMakerSubscriptionKey), isPreview: true, handlers: handler)
            {
                Endpoint = "https://australiaeast.api.cognitive.microsoft.com"
            };

            return client;
        }
        protected IQnAMakerRuntimeClient GetQnAMakerRuntimeClient(DelegatingHandler handler)
        {
            IQnAMakerRuntimeClient client = new QnAMakerRuntimeClient(new EndpointKeyServiceClientCredentials(QnAMakerEndpointKey), handlers: handler)
            {
                RuntimeEndpoint = "https://myqnamakerapp.azurewebsites.net"
            };

            return client;
        }

        protected IQnAMakerRuntimeClient GetQnAMakerPreviewRuntimeClient(DelegatingHandler handler)
        {
            IQnAMakerRuntimeClient client = new QnAMakerRuntimeClient(new ApiKeyServiceClientCredentials(QnAMakerSubscriptionKey), isPreview: true, handlers: handler)
            {
                RuntimeEndpoint = "https://australiaeast.api.cognitive.microsoft.com"
            };

            return client;
        }
    }
}

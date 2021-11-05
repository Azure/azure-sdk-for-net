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

        protected QnAMakerRuntimeClient GetQnAMakerRuntimeClient(DelegatingHandler handler)
        {
            // Do not initialize QnAMakerClient with EndpointKeyCredentials.
            // The following will fallback to constructor with ServiceCredentials instead.
            //       var client = new QnAMakerClient(new EndpointKeyServiceClientCredentials(QnAMakerEndpointKey), handler);
            // Because, it is a customized 'internal' contructor for backward compatibility with V2.x.x SDK 
            // Use QnAMakerRuntimeClient instead like below

            var client = new QnAMakerRuntimeClient(new EndpointKeyServiceClientCredentials(QnAMakerEndpointKey), handlers: handler)
            {
                RuntimeEndpoint = "https://sk4cs.azurewebsites.net"
            };

            return client;
        }        
    }
}

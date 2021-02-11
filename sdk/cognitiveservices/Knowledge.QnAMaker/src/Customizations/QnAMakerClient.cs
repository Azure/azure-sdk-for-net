using System.Net.Http;

namespace Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker
{
    public partial class QnAMakerClient
    {
        /// <summary>
        /// Initializes a new instance of the QnAMakerClient class for QnA Maker resources with hosted Runtime.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify client subscription.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal QnAMakerClient(EndpointKeyServiceClientCredentials credentials, params DelegatingHandler[] handlers) : this(handlers)
        {            
            if (credentials == null)
            {
                throw new System.ArgumentNullException("credentials");
            }

            Credentials = credentials;
            Credentials.InitializeServiceClient(this);
            BaseUri = "{Endpoint}/qnamaker";
        }
    }
}
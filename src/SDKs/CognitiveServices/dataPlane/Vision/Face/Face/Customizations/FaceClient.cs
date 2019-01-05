namespace Microsoft.Azure.CognitiveServices.Vision.Face
{
    using Microsoft.Rest;
    using System.Net.Http;

    public partial class FaceClient 
    {
    
        /// <summary>
        /// Initializes a new instance of the FaceClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify client subscription.
        /// </param>
        /// <param name='endpoint'>
        /// Required. Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://westus.api.cognitive.microsoft.com).
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public FaceClient(ServiceClientCredentials credentials, string endpoint, params DelegatingHandler[] handlers) : this(credentials, handlers)        
        {
            Endpoint = endpoint;  
        }
    }
}

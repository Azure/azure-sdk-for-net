namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;

    /// <summary>
    /// Allows authentication to the API using a basic apiKey mechanism
    /// </summary>
    public class ApiKeyServiceClientCredentials : ServiceClientCredentials
    {
        private readonly string predictionKey;

        /// <summary>
        /// Creates a new instance of the ApiKeyServiceClientCredentails class
        /// </summary>
        /// <param name="predictionKey">The prediction key to authenticate and authorize as</param>
        public ApiKeyServiceClientCredentials(string predictionKey)
        {
            this.predictionKey = predictionKey;
        }

        /// <summary>
        /// Add the Basic Authentication Header to each outgoing request
        /// </summary>
        /// <param name="request">The outgoing request</param>
        /// <param name="cancellationToken">A token to cancel the operation</param>
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            request.Headers.Add("Prediction-Key", this.predictionKey);

            return Task.FromResult<object>(null);
        }
    }
}

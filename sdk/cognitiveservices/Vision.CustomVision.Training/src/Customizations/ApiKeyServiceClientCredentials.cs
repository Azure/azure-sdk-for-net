namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training
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
        private readonly string trainingKey;

        /// <summary>
        /// Creates a new instance of the ApiKeyServiceClientCredentails class
        /// </summary>
        /// <param name="trainingKey">The training key to authenticate and authorize as</param>
        public ApiKeyServiceClientCredentials(string trainingKey)
        {
            this.trainingKey = trainingKey;
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

            request.Headers.Add("Training-Key", this.trainingKey);

            return Task.FromResult<object>(null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.KeyVault.Customized.Authentication
{
    /// <summary>
    /// A <see cref="DelegatingHandler"/> which will update the <see cref="HttpBearerChallengeCache"/> when a 401 response is returned with a WWW-Authenticate bearer challenge header.
    /// </summary>
    public class ChallengeCacheHandler : MessageProcessingHandler
    {
        /// <summary>
        /// Returns the specified request without performing any processing
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return request;
        }
        /// <summary>
        /// Updates the <see cref="HttpBearerChallengeCache"/> when the specified response has a return code of 401
        /// </summary>
        /// <param name="response">The response to evaluate</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            // if the response came back as 401 and the response contains a bearer challenge update the challenge cache
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                HttpBearerChallenge challenge = HttpBearerChallenge.GetBearerChallengeFromResponse(response);

                if (challenge != null)
                {
                    // Update challenge cache
                    HttpBearerChallengeCache.GetInstance().SetChallengeForURL(response.RequestMessage.RequestUri, challenge);
                }
            }

            return response;
        }

    }
}

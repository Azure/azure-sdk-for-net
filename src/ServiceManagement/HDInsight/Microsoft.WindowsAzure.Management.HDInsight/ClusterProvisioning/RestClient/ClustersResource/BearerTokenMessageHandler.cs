// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient.ClustersResource
{
    using System;
    using System.Net.Http;
    using System.Threading;

    /// <summary>
    /// This is a message processing handler that would add an OAuth bearer token authorization header to every request.
    /// </summary>
    internal class BearerTokenMessageHandler : MessageProcessingHandler
    {
        private readonly string oauthBearerToken;
        private const string AuthorizationHeaderName = "Authorization";
 
        public BearerTokenMessageHandler(string oauthBearerToken)
        {
            if (oauthBearerToken == null)
            {
                throw new ArgumentNullException("oauthBearerToken");
            }

            this.oauthBearerToken = oauthBearerToken;
        }

        protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                if (!request.Headers.Contains(AuthorizationHeaderName))
                {
                    request.Headers.TryAddWithoutValidation(AuthorizationHeaderName, "Bearer " + this.oauthBearerToken);
                }
            }
            return request;
        }

        protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            return response;
        }
    }
}

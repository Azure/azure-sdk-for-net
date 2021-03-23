// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace KubernetesConfiguration.Tests.Helpers
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class RecordedDelegatingHandler : DelegatingHandler
    {
        /// <summary>
        /// Passes the async operation to the base class
        /// </summary>
        /// <param name="request">The request to send</param>
        /// <param name="cancellationToken">The cancellation token for the async operation</param>
        /// <returns>The async task</returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return await base.SendAsync(request, cancellationToken);
        }
    }
}

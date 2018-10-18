// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Rest.ClientRuntime.Tests.Fakes
{
    public class BadResponseDelegatingHandler : DelegatingHandler
    {
        public BadResponseDelegatingHandler()
        {
            StatusCodeToReturn = HttpStatusCode.InternalServerError;
            NumberOfTimesToFail = int.MaxValue;
        }

        public int NumberOfTimesFailedSoFar { get; private set; }

        public int NumberOfTimesToFail { get; set; }

        public HttpStatusCode StatusCodeToReturn { get; set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            if (NumberOfTimesToFail > NumberOfTimesFailedSoFar)
            {
                response = new HttpResponseMessage(StatusCodeToReturn);
                NumberOfTimesFailedSoFar++;
            }
            return Task.Run(() => response);
        }
    }
}

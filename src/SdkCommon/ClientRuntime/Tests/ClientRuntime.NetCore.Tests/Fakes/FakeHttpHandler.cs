// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Rest.ClientRuntime.Tests.Fakes
{
    public class FakeHttpHandler : HttpClientHandler
    {
        public FakeHttpHandler()
        {
            StatusCodeToReturn = HttpStatusCode.InternalServerError;
            NumberOfTimesToFail = int.MaxValue;
        }

        public System.Action<HttpResponseMessage> TweakResponse { get; set; }

        public int NumberOfTimesToFail { get; set; }

        public int NumberOfTimesFailedSoFar { get; private set; }

        public HttpStatusCode StatusCodeToReturn { get; set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            if (NumberOfTimesToFail > NumberOfTimesFailedSoFar)
            {
                response = new HttpResponseMessage(StatusCodeToReturn);
                if (TweakResponse != null)
                {
                    TweakResponse(response);
                }
                NumberOfTimesFailedSoFar++;
            }

            return Task.Run(() => response);
        }
    }
}

//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Common.Test.Fakes
{
    public class FakeHttpHandler : HttpClientHandler
    {
        public FakeHttpHandler()
        {
            StatusCodeToReturn = HttpStatusCode.InternalServerError;
            NumberOfTimesToFail = int.MaxValue;
        }

        public int NumberOfTimesToFail { get; set; }

        public int NumberOfTimesFailedSoFar { get; private set; }

        public HttpStatusCode StatusCodeToReturn { get; set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            if (NumberOfTimesToFail > NumberOfTimesFailedSoFar)
            {
                response = new HttpResponseMessage(StatusCodeToReturn);
                NumberOfTimesFailedSoFar++;
            }

            return Task.Run(() => response);
        }
    }
}

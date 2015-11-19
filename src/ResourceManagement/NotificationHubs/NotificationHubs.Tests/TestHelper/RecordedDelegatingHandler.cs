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

namespace NotificationHubs.Tests.TestHelper
{

    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    public class RecordedDelegatingHandler : DelegatingHandler
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public RecordedDelegatingHandler()
        {
        }

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

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

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure
{
    public abstract class RetryHandler
        : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            int retryCount = 0;
            TimeSpan retryInterval;

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            
            while (ShouldRetry(request, response, retryCount++, out retryInterval))
            {
                await TaskEx.Delay(retryInterval, cancellationToken);
                response = await base.SendAsync(request, cancellationToken);
            }

            return response;
        }

        protected abstract bool ShouldRetry(HttpRequestMessage request, HttpResponseMessage response, int retryCount, out TimeSpan retryInterval);
    }
}

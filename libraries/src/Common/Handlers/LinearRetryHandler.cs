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
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure
{
    public abstract class LinearRetryHandler
        : RetryHandler
    {
        public TimeSpan RetryInterval { get; private set; }
        public int MaximumRetryAttempts { get; private set; }

        public LinearRetryHandler()
            : this(3)
        {
        }

        public LinearRetryHandler(int maximumRetryAttempts)
            : this(maximumRetryAttempts, TimeSpan.FromSeconds(30))
        {
        }

        public LinearRetryHandler(int maximumRetryAtempts, TimeSpan retryInterval)
            : base()
        {
            MaximumRetryAttempts = maximumRetryAtempts;
            RetryInterval = retryInterval;
        }

        protected override bool ShouldRetry(HttpRequestMessage request, HttpResponseMessage response, int retryCount, out TimeSpan retryInterval)
        {
            retryInterval = TimeSpan.Zero;

            HttpStatusCode statusCode = response.StatusCode;
            if ((statusCode >= HttpStatusCode.BadRequest && statusCode < HttpStatusCode.InternalServerError) ||
                statusCode == HttpStatusCode.Unused || // Internal error / Cancellation
                statusCode == HttpStatusCode.NotImplemented ||
                statusCode == HttpStatusCode.HttpVersionNotSupported)
            {
                return false;
            }

            retryInterval = RetryInterval;
            return retryCount < MaximumRetryAttempts;
        }
    }
}

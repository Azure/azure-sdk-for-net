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
using Microsoft.WindowsAzure.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure
{
    /// <summary>
    /// The CloudCredentials class is the base class for providing credentials
    /// to access Windows Azure services.
    /// </summary>
    public abstract class CloudCredentials
    {
        /// <summary>
        /// Initialize a ServiceClient instance to process credentials.
        /// </summary>
        /// <typeparam name="T">Type of ServiceClient.</typeparam>
        /// <param name="client">The ServiceClient.</param>
        public virtual void InitializeServiceClient<T>(ServiceClient<T> client)
            where T : ServiceClient<T>
        {
        }

        /// <summary>
        /// Apply the credentials to the HTTP request.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// Task that will complete when processing has completed.
        /// </returns>
        public virtual Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Return an empty task by default
            return TaskEx.FromResult<object>(null);
        }
    }
}

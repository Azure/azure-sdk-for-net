// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace Microsoft.Azure.Batch
{
    using System;
    using Protocol;
    using Protocol.Models;

    /// <summary>
    /// Interceptor which contains a function used to generate a client request id to set as <see cref="IOptions.ClientRequestId"/>.
    /// If there are multiple instances of this then the last set wins.
    /// </summary>
    public class ClientRequestIdProvider : Protocol.RequestInterceptor
    {
        internal /*readonly*/ Func<IBatchRequest, Guid> GenerateClientRequestIdFunc { get; private set; }

        /// <summary>
        /// Initializes a new <see cref="ClientRequestIdProvider"/> for use in setting the client request id of a request.
        /// </summary>
        /// <param name="generateClientRequestIdFunc">
        /// A function used to generate the client request id.  This function may be called more than once for any
        /// given operation due to retries.
        /// </param>
        public ClientRequestIdProvider(Func<IBatchRequest, Guid> generateClientRequestIdFunc)
        {
            this.GenerateClientRequestIdFunc = generateClientRequestIdFunc;

            base.ModificationInterceptHandler = SetClientRequestIdInterceptor;
        }

        private void SetClientRequestIdInterceptor(Protocol.IBatchRequest request)
        {
            // if there is a factory, call it
            if (null != this.GenerateClientRequestIdFunc)
            {
                request.ClientRequestIdProvider = this;
            }
        }
    }
}

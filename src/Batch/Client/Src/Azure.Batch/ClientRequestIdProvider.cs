// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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

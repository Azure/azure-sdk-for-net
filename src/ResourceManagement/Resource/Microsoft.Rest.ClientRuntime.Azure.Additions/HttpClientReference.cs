// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Rest.Azure
{
    /// <summary>
    /// Reference counting HttpClient, ensures that client is not disposed until all classes are finished using it
    /// </summary>
    public class HttpClientReference : HttpClient
    {
        int _referenceCount = 1;

        /// <summary>
        /// Create a new HttpClientReference with the given message handler chain
        /// </summary>
        /// <param name="handler">The message handler chain to use in the http client</param>
        public HttpClientReference(HttpMessageHandler handler) : base(handler)
        {
        }

        /// <summary>
        /// Create a new HttpClientReference with the given message handler chain
        /// </summary>
        /// <param name="handler">The message handler chain to use in the http client</param>
        /// <param name="disposeHandler">Indicates whether the handlers should be disposed when the HttpClientReference is disposed</param>
        public HttpClientReference(HttpMessageHandler handler, bool disposeHandler) : base(handler, disposeHandler)
        {
        }

        /// <summary>
        /// Get a disposable reference to the HttpClient
        /// </summary>
        /// <returns>A reference to the http client</returns>
        public HttpClient GetReference()
        {
            Interlocked.Increment(ref _referenceCount);
            return this;
        }

        protected override void Dispose(bool disposing)
        {
            if (Interlocked.Decrement(ref _referenceCount) == 0)
            {
                base.Dispose(disposing);
            }
        }

        /// <summary>
        /// Reset the reference count so the object can be immediately disposed
        /// </summary>
        public void ResetReferences()
        {
            Interlocked.Exchange(ref _referenceCount, 1);
        }
    }
}

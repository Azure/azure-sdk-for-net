// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Net.Http;

namespace Hyak.Common.Internals
{
    /// <summary>
    /// Wrapper class for HttpMessageHandler that prevents InnerHandler from
    /// being disposed.
    /// </summary>
    internal class IndisposableDelegatingHandler : DelegatingHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndisposableDelegatingHandler" /> class from HttpMessageHandler.
        /// </summary>
        /// <param name="innerHandler">InnerHandler to wrap.</param>
        public IndisposableDelegatingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        /// <summary>
        /// Overrides Dispose of the base class to prevent disposal of the InnerHandler.
        /// </summary>
        /// <param name="disposing">If set to true indicates the method is being called from Dispose().</param>
        protected override void Dispose(bool disposing)
        {
            // Do not call base.  The actual base Dispose method does nothing
            // but forward disposal on to the InnerHandler, which we don't want
            // to do if we're managing lifetime of HttpMessageHandlers by
            // ourselves.
        }
    }
}

﻿//
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

namespace Microsoft.WindowsAzure.Common.Internals
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

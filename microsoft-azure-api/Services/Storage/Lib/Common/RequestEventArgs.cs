// -----------------------------------------------------------------------------------------
// <copyright file="RequestEventArgs.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage
{
    using System;

#if !WINDOWS_RT
    using System.Net;
#endif

    /// <summary>
    /// Provides information and event data that is associated with a request event.
    /// </summary>
    public sealed class RequestEventArgs
#if !WINDOWS_RT
        : EventArgs
#endif
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestEventArgs"/> class by using the specified <see cref="RequestResult"/> parameter.
        /// </summary>
        /// <param name="res">The <see cref="RequestResult"/> object.</param>
        public RequestEventArgs(RequestResult res)
#if !WINDOWS_RT
            : base()
#endif
        {
            this.RequestInformation = res;
        }

        /// <summary>
        /// Gets the request information associated with this event.
        /// </summary>
        /// <value>The request information associated with this event.</value>
        public RequestResult RequestInformation { get; internal set; }

#if WINDOWS_RT
        public Uri RequestUri { get; internal set; }
#else
        /// <summary>
        /// Gets the HTTP request associated with this event.
        /// </summary>
        /// <value>The HTTP request associated with this event.</value>
        public HttpWebRequest Request { get; internal set; }

        /// <summary>
        /// Gets the HTTP response associated with this event.
        /// </summary>
        /// <value>The HTTP response associated with this event.</value>
        public HttpWebResponse Response { get; internal set; }
#endif
    }
}

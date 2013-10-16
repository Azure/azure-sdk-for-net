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
using System.Collections.Generic;
using System.Net.Http;

namespace Microsoft.WindowsAzure
{
    /// <summary>
    /// The ICloudTracingInterceptor provides useful information about cloud
    /// operations.  Interception is global and a tracing interceptor can be
    /// added via CloudContext.Configuration.Tracing.AddTracingInterceptor.
    /// </summary>
    public interface ICloudTracingInterceptor
    {
        /// <summary>
        /// Trace information.
        /// </summary>
        /// <param name="message">The information to trace.</param>
        void Information(string message);

        /// <summary>
        /// Probe configuration for the value of a setting.
        /// </summary>
        /// <param name="source">The configuration source.</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The value of the setting in the source.</param>
        void Configuration(string source, string name, string value);

        /// <summary>
        /// Enter a method.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="instance">The instance with the method.</param>
        /// <param name="method">Name of the method.</param>
        /// <param name="parameters">Method parameters.</param>
        void Enter(string invocationId, object instance, string method, IDictionary<string, object> parameters);

        /// <summary>
        /// Send an HTTP request.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="request">The request about to be sent.</param>
        void SendRequest(string invocationId, HttpRequestMessage request);

        /// <summary>
        /// Receive an HTTP reponse.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="response">The response instance.</param>
        void ReceiveResponse(string invocationId, HttpResponseMessage response);

        /// <summary>
        /// Raise an error.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="ex">The error.</param>
        void Error(string invocationId, Exception ex);

        /// <summary>
        /// Exit a method.  Note: Exit will not be called in the event of an
        /// error.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="returnValue">Method return value.</param>
        void Exit(string invocationId, object returnValue);
    }
}

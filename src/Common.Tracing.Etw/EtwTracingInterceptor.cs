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

namespace Microsoft.WindowsAzure.Common.Tracing.Etw
{
    /// <summary>
    /// Implementation for ICloudTracingInterceptor that raises ETW events.
    /// </summary>
    /// <remarks>
    /// To use ETW with the Microsoft Azure Common Library:
    /// 1. Register the logger into the CloudContext.
    /// 2. Use tools such as PerfView to capure events under the
    /// Microsoft-WindowsAzure provider.
    /// </remarks>
    /// <example>
    /// This shows how to hook up the tracing interceptor.
    /// <code>
    /// CloudContext.Configuration.Tracing.AddTracingInterceptor(
    ///     new EtwTracingInterceptor());
    /// </code>
    /// </example>
    public class EtwTracingInterceptor : ICloudTracingInterceptor
    {
        /// <summary>
        /// Trace information.
        /// </summary>
        /// <param name="message">The information to trace.</param>
        public void Information(string message)
        {
            CloudTracingEventSource.Log.Information(message);
        }

        /// <summary>
        /// Probe configuration for the value of a setting.
        /// </summary>
        /// <param name="source">The configuration source.</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The value of the setting in the source.</param>
        public void Configuration(string source, string name, string value)
        {
            CloudTracingEventSource.Log.Configuration(source, name, value);
        }

        /// <summary>
        /// Enter a method.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="instance">The instance with the method.</param>
        /// <param name="method">Name of the method.</param>
        /// <param name="parameters">Method parameters.</param>
        public void Enter(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            string instanceAsString = instance == null ? string.Empty : instance.ToString();
            string parametersAsString = parameters == null ? string.Empty : parameters.AsFormattedString();

            CloudTracingEventSource.Log.Enter(invocationId, instanceAsString, method, parametersAsString);
        }

        /// <summary>
        /// Send an HTTP request.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="request">The request about to be sent.</param>
        public virtual void SendRequest(string invocationId, HttpRequestMessage request)
        {
            string requestAsString = request == null ? string.Empty : request.AsFormattedString();

            CloudTracingEventSource.Log.SendRequest(invocationId, requestAsString);
        }

        /// <summary>
        /// Receive an HTTP response.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="response">The response instance.</param>
        public virtual void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            string responseAsString = response == null ? string.Empty : response.AsFormattedString();

            CloudTracingEventSource.Log.ReceiveResponse(invocationId, responseAsString);
        }

        /// <summary>
        /// Raise an error.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="exception">The error.</param>
        public void Error(string invocationId, Exception exception)
        {
            string exceptionAsString = exception == null ? string.Empty : exception.ToString();

            CloudTracingEventSource.Log.Error(invocationId, exceptionAsString);
        }

        /// <summary>
        /// Exit a method.  Note: Exit will not be called in the event of an
        /// error.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="returnValue">Method return value.</param>
        public void Exit(string invocationId, object returnValue)
        {
            string returnValueAsString = returnValue == null ? string.Empty : returnValue.ToString();

            CloudTracingEventSource.Log.Exit(invocationId, returnValueAsString);
        }
    }
}

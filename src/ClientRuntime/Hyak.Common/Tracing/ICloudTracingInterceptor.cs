// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Hyak.Common
{
    /// <summary>
    /// The ICloudTracingInterceptor provides useful information about cloud
    /// operations.  Interception is global and a tracing interceptor can be
    /// added via TracingAdapter.AddTracingInterceptor.
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
        /// Receive an HTTP response.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="response">The response instance.</param>
        void ReceiveResponse(string invocationId, HttpResponseMessage response);

        /// <summary>
        /// Raise an error.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="exception">The error.</param>
        void Error(string invocationId, Exception exception);

        /// <summary>
        /// Exit a method.  Note: Exit will not be called in the event of an
        /// error.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="returnValue">Method return value.</param>
        void Exit(string invocationId, object returnValue);
    }
}

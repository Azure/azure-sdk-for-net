// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Microsoft.Rest.Tracing.Etw
{
    /// <summary>
    /// Implementation for IServiceClientTracingInterceptor that raises ETW events.
    /// </summary>
    /// <remarks>
    /// To use ETW with the Microsoft AutoRest generated client:
    /// 1. Register the logger.
    /// 2. Use tools such as PerfView to capture events under the
    /// Microsoft.Rest provider.
    /// </remarks>
    /// <example>
    /// This shows how to hook up the tracing interceptor.
    /// <code>
    /// TracingAdapter.AddTracingInterceptor(
    ///     new EtwTracingInterceptor());
    /// </code>
    /// </example>
    public class EtwTracingInterceptor : IServiceClientTracingInterceptor
    {
        /// <summary>
        /// Trace information.
        /// </summary>
        /// <param name="message">The information to trace.</param>
        public void Information(string message)
        {
            HttpOperationEventSource.Log.Information(message);
        }

        /// <summary>
        /// Probe configuration for the value of a setting.
        /// </summary>
        /// <param name="source">The configuration source.</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The value of the setting in the source.</param>
        public void Configuration(string source, string name, string value)
        {
            HttpOperationEventSource.Log.Configuration(source, name, value);
        }

        /// <summary>
        /// Enter a method.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="instance">The instance with the method.</param>
        /// <param name="method">Name of the method.</param>
        /// <param name="parameters">Method parameters.</param>
        public void EnterMethod(string invocationId, object instance, string method,
            IDictionary<string, object> parameters)
        {
            string instanceAsString = instance == null ? string.Empty : instance.ToString();
            string parametersAsString = parameters == null ? string.Empty : parameters.AsFormattedString();

            HttpOperationEventSource.Log.Enter(invocationId, instanceAsString, method, parametersAsString);
        }

        /// <summary>
        /// Send an HTTP request.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="request">The request about to be sent.</param>
        public virtual void SendRequest(string invocationId, HttpRequestMessage request)
        {
            string requestAsString = request == null ? string.Empty : request.AsFormattedString();

            HttpOperationEventSource.Log.SendRequest(invocationId, requestAsString);
        }

        /// <summary>
        /// Receive an HTTP response.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="response">The response instance.</param>
        public virtual void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            string responseAsString = response == null ? string.Empty : response.AsFormattedString();

            HttpOperationEventSource.Log.ReceiveResponse(invocationId, responseAsString);
        }

        /// <summary>
        /// Raise an error.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="exception">The error.</param>
        public void TraceError(string invocationId, Exception exception)
        {
            string exceptionAsString = exception == null ? string.Empty : exception.ToString();

            HttpOperationEventSource.Log.Error(invocationId, exceptionAsString);
        }

        /// <summary>
        /// Exit a method.  Note: Exit will not be called in the event of an
        /// error.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="returnValue">Method return value.</param>
        public void ExitMethod(string invocationId, object returnValue)
        {
            string returnValueAsString = returnValue == null ? string.Empty : returnValue.ToString();

            HttpOperationEventSource.Log.Exit(invocationId, returnValueAsString);
        }
    }
}

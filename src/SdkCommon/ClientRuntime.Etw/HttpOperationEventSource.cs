// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Diagnostics.Tracing;

namespace Microsoft.Rest.Tracing.Etw
{
    /// <summary>
    /// Class that inherits from EventSource and is used as a data model for ETW events.
    /// </summary>
    [EventSource(Name = "Microsoft.Rest")]
    internal sealed class HttpOperationEventSource : EventSource
    {
        private static HttpOperationEventSource _log;

        private HttpOperationEventSource()
        {
        }

        /// <summary>
        /// Gets an instance of the HttpOperationEventSource.
        /// </summary>
        public static HttpOperationEventSource Log
        {
            get
            {
                if (_log == null)
                {
                    _log = new HttpOperationEventSource();
                }
                return _log;
            }
        }

        /// <summary>
        /// Logs information message.
        /// </summary>
        /// <param name="Message">Message</param>
        [Event(1, Level = EventLevel.Informational)]
        public void Information(string Message)
        {
            WriteEvent(1, Message);
        }

        /// <summary>
        /// Logs a configuration event.
        /// </summary>
        /// <param name="Source">Event source.</param>
        /// <param name="Name">Configuration name.</param>
        /// <param name="Value">Configuration value.</param>
        [Event(2, Level = EventLevel.Informational)]
        public void Configuration(string Source, string Name, string Value)
        {
            WriteEvent(2, Source, Name, Value);
        }

        /// <summary>
        /// Logs method start.
        /// </summary>
        /// <param name="InvocationId">Correlation ID for a series of events.</param>
        /// <param name="Instance">Instance of the method.</param>
        /// <param name="Method">Method name.</param>
        /// <param name="Parameters">Method parameters passed to the method.</param>
        [Event(3, Level = EventLevel.Informational)]
        public void Enter(string InvocationId, string Instance, string Method, string Parameters)
        {
            WriteEvent(3, InvocationId, Instance, Method, Parameters);
        }

        /// <summary>
        /// Logs sending an HTTP request.
        /// </summary>
        /// <param name="InvocationId">Correlation ID for a series of events.</param>
        /// <param name="Request">The request about to be sent.</param>
        [Event(4, Level = EventLevel.Informational)]
        public void SendRequest(string InvocationId, string Request)
        {
            WriteEvent(4, InvocationId, Request);
        }

        /// <summary>
        /// Logs receipt of an HTTP response.
        /// </summary>
        /// <param name="InvocationId">Correlation ID for a series of events.</param>
        /// <param name="Response">The response instance.</param>
        [Event(5, Level = EventLevel.Informational)]
        public void ReceiveResponse(string InvocationId, string Response)
        {
            WriteEvent(5, InvocationId, Response);
        }

        /// <summary>
        /// Logs an error.
        /// </summary>
        /// <param name="InvocationId">Correlation ID for a series of events.</param>
        /// <param name="Exception">Exception.</param>
        [Event(6, Level = EventLevel.Error)]
        public void Error(string InvocationId, string Exception)
        {
            WriteEvent(6, InvocationId, Exception);
        }

        /// <summary>
        /// Logs method exit.
        /// </summary>
        /// <param name="InvocationId">Correlation ID for a series of events.</param>
        /// <param name="ReturnValue">Return value.</param>
        [Event(7, Level = EventLevel.Informational)]
        public void Exit(string InvocationId, string ReturnValue)
        {
            WriteEvent(7, InvocationId, ReturnValue);
        }
    }
}

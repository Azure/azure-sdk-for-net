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

using Hyak.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Microsoft.Azure.Test
{
    /// <summary>
    /// Intercepts WAML traces and logs to Trace and Debug listeners
    /// </summary>
    public class TestLogTracingInterceptor : ICloudTracingInterceptor
    {
        static TestLogTracingInterceptor()
        {
            Current = new TestLogTracingInterceptor();
        }

        public static TestLogTracingInterceptor Current
        {
            get;
            private set;
        }

        /// <summary>
        /// Hide the constructor, there should only be one loggin interceptor
        /// </summary>
        private TestLogTracingInterceptor()
        {
        }

        /// <summary>
        /// Ensure that the given set of trace listener collections contains a trace listener oif the given type
        /// </summary>
        /// <typeparam name="T">The trace listener type to validate</typeparam>
        /// <param name="collections">The trace listener collections to search</param>
        public static void EnsureTraceListener<T>(params TraceListenerCollection[] collections) where T : TraceListener, new()
        {
            foreach (TraceListenerCollection collection in collections)
            {
                EnsureTraceListenerInCollection<T>(collection);
            }
        }

        /// <summary>
        /// Ensure that the given trace listener collection contains a trace listener oif the given type
        /// </summary>
        /// <typeparam name="T">The trace listener type to validate</typeparam>
        public static void EnsureTraceListenerInCollection<T>(TraceListenerCollection collection) where T : TraceListener, new()
        {
            foreach (TraceListener listener in collection)
            {
                if ((listener as T) != null)
                {
                    return;
                }
            }

            collection.Add(new T());
        }

        /// <summary>
        /// CConfigure the interceptor for use in the current environment
        /// </summary>
        public void Start()
        {
            this.Stop();
            EnsureTraceListener<DefaultTraceListener>(Trace.Listeners, Debug.Listeners);
            TracingAdapter.AddTracingInterceptor(this);
        }

        /// <summary>
        /// Form,at and write a message out to each trace sink
        /// </summary>
        /// <param name="format">string.Format message format</param>
        /// <param name="parameters">additional arguments to the format</param>
        static void WriteMessage(string format, params object[] parameters)
        {
            //Trace.WriteLine(string.Format(format, parameters));
            Debug.WriteLine(string.Format(format, parameters));
        }

        /// <summary>
        /// Stop the interceptor from logging messages
        /// </summary>
        public void Stop()
        {
            try
            {
                TracingAdapter.RemoveTracingInterceptor(this);
            }
            catch (Exception)
            {
            }

        }

        /// <summary>
        /// Log a configuration event
        /// </summary>
        /// <param name="source">config source</param>
        /// <param name="name">name of config item</param>
        /// <param name="value">value of config item</param>
        public void Configuration(string source, string name, string value)
        {
            WriteMessage("Configuration event: source: {0}, name: {1}, value: {2}", source, name, value);
        }

        /// <summary>
        /// Trace the entry into a WAML operation
        /// </summary>
        /// <param name="invocationId">Correlation id</param>
        /// <param name="instance">implementing instance of the operation</param>
        /// <param name="method">Name of the method being called</param>
        /// <param name="parameters">Parameters passed in the method call, keyed by parameter name</param>
        public void Enter(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            WriteMessage("Enter: invocation: {0}, instance: {1}, method: {2}, parameters: {3}", invocationId, instance, method, parameters.AsFormattedString());
        }

        /// <summary>
        /// Trace the throwing of an exception by a WAML client
        /// </summary>
        /// <param name="invocationId">Correlation id</param>
        /// <param name="exception">Exception raised</param>
        public void Error(string invocationId, Exception exception)
        {
            WriteMessage("Error: invocation: {0}, exception: {1}", invocationId, exception);
        }

        /// <summary>
        /// Trace a WAML method exit
        /// </summary>
        /// <param name="invocationId">Correlation id</param>
        /// <param name="returnValue">Return value from the method</param>
        public void Exit(string invocationId, object returnValue)
        {
            WriteMessage("Exit: invocation: {0}, returned: {1}", invocationId, returnValue);
        }

        /// <summary>
        /// Travce an informational event raised by a WAML client
        /// </summary>
        /// <param name="message">The information message</param>
        public void Information(string message)
        {
            WriteMessage("Information {0}", message);
        }

        /// <summary>
        /// Trace a response received by a WAML client
        /// </summary>
        /// <param name="invocationId">Correlation id</param>
        /// <param name="response">The raw response data</param>
        public void ReceiveResponse(string invocationId, System.Net.Http.HttpResponseMessage response)
        {
            WriteMessage("Response: {0}, {1}", invocationId, response.AsFormattedString());
        }

        /// <summary>
        /// Trace a request sent by a WAML client
        /// </summary>
        /// <param name="invocationId">Correlation id</param>
        /// <param name="request">The raw request data</param>
        public void SendRequest(string invocationId, System.Net.Http.HttpRequestMessage request)
        {
            WriteMessage("Request: {0}, {1}", invocationId, request.AsFormattedString());
        }
    }
}

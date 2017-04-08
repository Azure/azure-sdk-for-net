// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;

namespace Microsoft.Rest
{
    /// <summary>
    /// Provides a set of methods and properties that help you trace the service client.
    /// </summary>
    public static class ServiceClientTracing
    {
        /// <summary>
        /// The collection of tracing interceptors to notify.
        /// </summary>
        private static readonly List<IServiceClientTracingInterceptor> _interceptors =
            new List<IServiceClientTracingInterceptor>();

        /// <summary>
        /// A read-only, thread-safe collection of tracing interceptors.  Since
        /// List is only thread-safe for reads (and adding/removing tracing
        /// interceptors isn't a very common operation), we simply replace the
        /// entire collection of interceptors so any enumeration of the list
        /// in progress on a different thread will not be affected by the
        /// change.
        /// </summary>
        private static List<IServiceClientTracingInterceptor> _threadSafeInterceptors =
            new List<IServiceClientTracingInterceptor>();

        /// <summary>
        /// Lock used to synchronize mutation of the tracing interceptors.
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        /// The invocation identifier.
        /// </summary>
        private static long _nextInvocationId = 0;

        private static bool _isEnabled = false;

        /// <summary>
        /// Gets or sets a value indicating whether tracing is enabled.
        /// Tracing can be disabled for performance.
        /// </summary>
        public static bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; }
        }

        /// <summary>
        /// Gets a sequence of the tracing interceptors to notify of changes.
        /// </summary>
        internal static IEnumerable<IServiceClientTracingInterceptor> TracingInterceptors
        {
            get { return _threadSafeInterceptors; }
        }

        /// <summary>
        /// Get the next invocation identifier.
        /// </summary>
        public static long NextInvocationId
        {
            get
            {
                // In the event of long.MaxValue requests, this will
                // automatically rollover
                return Interlocked.Increment(ref _nextInvocationId);
            }
        }

        /// <summary>
        /// Add a tracing interceptor to be notified of changes.
        /// </summary>
        /// <param name="interceptor">The tracing interceptor.</param>
        public static void AddTracingInterceptor(IServiceClientTracingInterceptor interceptor)
        {
            if (interceptor == null)
            {
                throw new ArgumentNullException("interceptor");
            }

            lock (_lock)
            {
                _interceptors.Add(interceptor);
                _threadSafeInterceptors = new List<IServiceClientTracingInterceptor>(_interceptors);
            }
        }

        /// <summary>
        /// Remove a tracing interceptor from change notifications.
        /// </summary>
        /// <param name="interceptor">The tracing interceptor.</param>
        /// <returns>True if the tracing interceptor was found and removed; false otherwise.</returns>
        public static bool RemoveTracingInterceptor(IServiceClientTracingInterceptor interceptor)
        {
            if (interceptor == null)
            {
                throw new ArgumentNullException("interceptor");
            }

            bool removed;
            lock (_lock)
            {
                removed = _interceptors.Remove(interceptor);
                if (removed)
                {
                    _threadSafeInterceptors = new List<IServiceClientTracingInterceptor>(_interceptors);
                }
            }
            return removed;
        }

        /// <summary>
        /// Write the informational tracing message.
        /// </summary>
        /// <param name="message">The message to trace.</param>
        /// <param name="parameters">An object array containing zero or more objects to format</param>
        public static void Information(string message, params object[] parameters)
        {
            if (IsEnabled)
            {
                Information(string.Format(CultureInfo.InvariantCulture, message, parameters));
            }
        }

        /// <summary>
        /// Represents the tracing configuration for the value of a setting.
        /// </summary>
        /// <param name="source">The configuration source.</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The value of the setting in the source.</param>
        public static void Configuration(string source, string name, string value)
        {
            if (IsEnabled)
            {
                foreach (IServiceClientTracingInterceptor writer in TracingInterceptors)
                {
                    writer.Configuration(source, name, value);
                }
            }
        }

        /// <summary>
        /// Specifies the tracing information.
        /// </summary>
        /// <param name="message">The message to trace.</param>
        public static void Information(string message)
        {
            if (IsEnabled)
            {
                foreach (IServiceClientTracingInterceptor writer in TracingInterceptors)
                {
                    writer.Information(message);
                }
            }
        }

        /// <summary>
        /// Represents the tracing entry.
        /// </summary>
        /// <param name="invocationId"></param>
        /// <param name="instance">The tracing instance.</param>
        /// <param name="method">The tracing method.</param>
        /// <param name="parameters">Method parameters.</param>     
        public static void Enter(string invocationId, object instance, string method,
            IDictionary<string, object> parameters)
        {
            if (IsEnabled)
            {
                foreach (IServiceClientTracingInterceptor writer in TracingInterceptors)
                {
                    writer.EnterMethod(invocationId, instance, method, parameters);
                }
            }
        }

        /// <summary>
        /// Sends a tracing request.
        /// </summary>
        /// <param name="invocationId">The invocation identifier.</param>
        /// <param name="request">The request about to be sent.</param>
        public static void SendRequest(string invocationId, HttpRequestMessage request)
        {
            if (IsEnabled)
            {
                foreach (IServiceClientTracingInterceptor writer in TracingInterceptors)
                {
                    writer.SendRequest(invocationId, request);
                }
            }
        }

        /// <summary>
        /// Receives a tracing response.
        /// </summary>
        /// <param name="invocationId">The invocation identifier.</param>
        /// <param name="response">The response message instance.</param>
        public static void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            if (IsEnabled)
            {
                foreach (IServiceClientTracingInterceptor writer in TracingInterceptors)
                {
                    writer.ReceiveResponse(invocationId, response);
                }
            }
        }

        /// <summary>
        /// Represents the tracing error.
        /// </summary>
        /// <param name="invocationId">The invocation identifier.</param>
        /// <param name="ex">The tracing exception.</param>
        public static void Error(string invocationId, Exception ex)
        {
            if (IsEnabled)
            {
                foreach (IServiceClientTracingInterceptor writer in TracingInterceptors)
                {
                    writer.TraceError(invocationId, ex);
                }
            }
        }

        /// <summary>
        /// Abandons the tracing method.
        /// </summary>
        /// <param name="invocationId">The invocation identifier.</param>
        /// <param name="result">Method return result.</param>
        public static void Exit(string invocationId, object result)
        {
            if (IsEnabled)
            {
                foreach (IServiceClientTracingInterceptor writer in TracingInterceptors)
                {
                    writer.ExitMethod(invocationId, result);
                }
            }
        }
    }
}
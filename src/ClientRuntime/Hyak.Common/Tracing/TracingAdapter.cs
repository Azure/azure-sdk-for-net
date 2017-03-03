// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;

namespace Hyak.Common
{
    public static class TracingAdapter
    {
        /// <summary>
        /// The collection of tracing interceptors to notify.
        /// </summary>
        private static List<ICloudTracingInterceptor> _interceptors;

        /// <summary>
        /// A read-only, thread-safe collection of tracing interceptors.  Since
        /// List is only thread-safe for reads (and adding/removing tracing
        /// interceptors isn't a very common operation), we simply replace the
        /// entire collection of interceptors so any enumeration of the list
        /// in progress on a different thread will not be affected by the
        /// change.
        /// </summary>
        private static List<ICloudTracingInterceptor> _threadSafeInterceptors;

        /// <summary>
        /// Lock used to synchronize mutation of the tracing interceptors.
        /// </summary>
        private static object _lock;

        /// <summary>
        /// Gets or sets a value indicating whether tracing is enabled.
        /// Tracing can be disabled for performance.
        /// </summary>
        public static bool IsEnabled { get; set; }

        /// <summary>
        /// Gets a sequence of the tracing interceptors to notify of changes.
        /// </summary>
        internal static IEnumerable<ICloudTracingInterceptor> TracingInterceptors
        {
            get { return _threadSafeInterceptors; }
        }

        /// <summary>
        /// Initializes a new instance of the CloudTracing class.
        /// </summary>
        static TracingAdapter()
        {
            IsEnabled = true;
            _lock = new object();
            _interceptors = new List<ICloudTracingInterceptor>();
            _threadSafeInterceptors = new List<ICloudTracingInterceptor>();
        }

        /// <summary>
        /// Add a tracing interceptor to be notified of changes.
        /// </summary>
        /// <param name="interceptor">The tracing interceptor.</param>
        public static void AddTracingInterceptor(ICloudTracingInterceptor interceptor)
        {
            if (interceptor == null)
            {
                throw new ArgumentNullException("interceptor");
            }

            lock (_lock)
            {
                _interceptors.Add(interceptor);
                _threadSafeInterceptors = new List<ICloudTracingInterceptor>(_interceptors);
            }
        }

        /// <summary>
        /// Remove a tracing interceptor from change notifications.
        /// </summary>
        /// <param name="interceptor">The tracing interceptor.</param>
        /// <returns>
        /// True if the tracing interceptor was found and removed; false
        /// otherwise.
        /// </returns>
        public static bool RemoveTracingInterceptor(ICloudTracingInterceptor interceptor)
        {
            if (interceptor == null)
            {
                throw new ArgumentNullException("interceptor");
            }

            bool removed = false;
            lock (_lock)
            {
                removed = _interceptors.Remove(interceptor);
                if (removed)
                {
                    _threadSafeInterceptors = new List<ICloudTracingInterceptor>(_interceptors);
                }
            }
            return removed;
        }

        private static long _nextInvocationId = 0;

        public static long NextInvocationId
        {
            get
            {
                // In the event of long.MaxValue requests, this will
                // automatically rollover
                return Interlocked.Increment(ref _nextInvocationId);             
            }
        }

        public static void Information(string message, params object[] parameters)
        {
            if (IsEnabled)
            {
                Information(string.Format(CultureInfo.InvariantCulture, message, parameters));
            }
        }
        
        public static void Configuration(string source, string name, string value)
        {
            if (IsEnabled)
            {
                foreach (ICloudTracingInterceptor writer in TracingInterceptors)
                {
                    writer.Configuration(source, name, value);
                }
            }
        }

        public static void Information(string message)
        {
            if (IsEnabled)
            {
                foreach (ICloudTracingInterceptor writer in TracingInterceptors)
                {
                    writer.Information(message);
                }
            }
        }

        public static void Enter(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            if (IsEnabled)
            {
                foreach (ICloudTracingInterceptor writer in TracingInterceptors)
                {
                    writer.Enter(invocationId, instance, method, parameters);
                }
            }
        }

        public static void SendRequest(string invocationId, HttpRequestMessage request)
        {
            if (IsEnabled)
            {
                foreach (ICloudTracingInterceptor writer in TracingInterceptors)
                {
                    writer.SendRequest(invocationId, request);
                }
            }
        }

        public static void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            if (IsEnabled)
            {
                foreach (ICloudTracingInterceptor writer in TracingInterceptors)
                {
                    writer.ReceiveResponse(invocationId, response);
                }
            }
        }

        public static void Error(string invocationId, Exception ex)
        {
            if (IsEnabled)
            {
                foreach (ICloudTracingInterceptor writer in TracingInterceptors)
                {
                    writer.Error(invocationId, ex);
                }
            }
        }

        public static void Exit(string invocationId, object result)
        {
            if (IsEnabled)
            {
                foreach (ICloudTracingInterceptor writer in TracingInterceptors)
                {
                    writer.Exit(invocationId, result);
                }
            }
        }
    }
}

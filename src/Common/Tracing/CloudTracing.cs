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

namespace Microsoft.WindowsAzure.Common
{
    /// <summary>
    /// Provides tracing utilities that insight into all aspects of client
    /// operations via implementations of the ICloudTracingInterceptor
    /// interface.  All tracing is global.
    /// </summary>
    /// <remarks>
    /// The utilities in the internal Tracing class provide helpers for
    /// notifying the active trace listeners of changes.
    /// </remarks>
    public class CloudTracing
    {
        /// <summary>
        /// The collection of tracing interceptors to notify.
        /// </summary>
        private List<ICloudTracingInterceptor> _interceptors;

        /// <summary>
        /// A read-only, thread-safe collection of tracing interceptors.  Since
        /// List is only thread-safe for reads (and adding/removing tracing
        /// interceptors isn't a very common operation), we simply replace the
        /// entire collection of interceptors so any enumeration of the list
        /// in progress on a different thread will not be affected by the
        /// change.
        /// </summary>
        internal List<ICloudTracingInterceptor> _threadSafeInterceptors;

        /// <summary>
        /// Lock used to synchronize mutation of the tracing interceptors.
        /// </summary>
        private object _lock;

        /// <summary>
        /// Gets or sets a value indicating whether tracing is enabled.
        /// Tracing can be disabled for performance.
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Gets a sequnce of the tracing interceptors to notify of changes.
        /// </summary>
        internal IEnumerable<ICloudTracingInterceptor> TracingInterceptors
        {
            get { return _threadSafeInterceptors; }
        }

        /// <summary>
        /// Initializes a new instance of the CloudTracing class.
        /// </summary>
        internal CloudTracing()
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
        public void AddTracingInterceptor(ICloudTracingInterceptor interceptor)
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
        public bool RemoveTracingInterceptor(ICloudTracingInterceptor interceptor)
        {
            if (interceptor == null)
            {
                throw new ArgumentNullException("interceptor");
            }

            bool removed = false;
            lock (_lock)
            {
                removed =_interceptors.Remove(interceptor);
                if (removed)
                {
                    _threadSafeInterceptors = new List<ICloudTracingInterceptor>(_interceptors);
                }
            }
            return removed;
        }
    }
}

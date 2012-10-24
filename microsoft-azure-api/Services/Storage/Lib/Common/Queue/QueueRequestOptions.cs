// -----------------------------------------------------------------------------------------
// <copyright file="QueueRequestOptions.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Queue
{
    using Microsoft.WindowsAzure.Storage.RetryPolicies;
    using System;

    /// <summary>
    /// Represents a set of timeout and retry policy options that may be specified for a queue operation request.
    /// </summary>
    public sealed class QueueRequestOptions : IRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueRequestOptions"/> class.
        /// </summary>
        public QueueRequestOptions()
        {
        }

        /// <summary>
        /// Clones an instance of QueueRequestOptions so that we can apply defaults.
        /// </summary>
        /// <param name="other">QueueRequestOptions instance to be cloned.</param>
        internal QueueRequestOptions(QueueRequestOptions other)
            : this()
        {
            if (other != null)
            {
                this.RetryPolicy = other.RetryPolicy;
                this.ServerTimeout = other.ServerTimeout;
                this.MaximumExecutionTime = other.MaximumExecutionTime;
            }
        }

        internal static QueueRequestOptions ApplyDefaults(QueueRequestOptions options, CloudQueueClient serviceClient)
        {
            QueueRequestOptions modifiedOptions = new QueueRequestOptions(options);

            modifiedOptions.RetryPolicy = modifiedOptions.RetryPolicy ?? serviceClient.RetryPolicy;
            modifiedOptions.ServerTimeout = modifiedOptions.ServerTimeout ?? serviceClient.ServerTimeout;
            modifiedOptions.MaximumExecutionTime = modifiedOptions.MaximumExecutionTime ?? serviceClient.MaximumExecutionTime;

            return modifiedOptions;
        }

        /// <summary>
        /// Gets or sets the retry policy for the request.
        /// </summary>
        /// <value>The retry policy delegate.</value>
        public IRetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Gets or sets the server timeout for the request. 
        /// </summary>
        /// <value>The client and server timeout interval for the request.</value>
        public TimeSpan? ServerTimeout { get; set; }

        /// <summary>
        /// Gets or sets the maximum execution time accross all potential retries etc. 
        /// </summary>
        /// <value>The maximum execution time.</value>
        public TimeSpan? MaximumExecutionTime { get; set; }
    }
}

// -----------------------------------------------------------------------------------------
// <copyright file="TableRequestOptions.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Table
{
    using Microsoft.WindowsAzure.Storage.RetryPolicies;
    using System;

    /// <summary>
    /// Represents a set of timeout and retry policy options that may be specified for a request against the Table service.
    /// </summary>
    public sealed class TableRequestOptions : IRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableRequestOptions"/> class.
        /// </summary>
        public TableRequestOptions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableRequestOptions"/> class with the specified <see cref="TableRequestOptions"/>.
        /// </summary>
        /// <param name="other">The request options used to initialize this instance of the <see cref="TableRequestOptions"/> class.</param>
        public TableRequestOptions(TableRequestOptions other)
        {
            if (other != null)
            {
                this.ServerTimeout = other.ServerTimeout;
                this.RetryPolicy = other.RetryPolicy;
                this.MaximumExecutionTime = other.MaximumExecutionTime;
                this.OperationExpiryTime = other.OperationExpiryTime;
            }
        }

        internal static TableRequestOptions ApplyDefaults(TableRequestOptions requestOptions, CloudTableClient serviceClient)
        {
            TableRequestOptions modifiedOptions = new TableRequestOptions(requestOptions);
            modifiedOptions.RetryPolicy = modifiedOptions.RetryPolicy ?? serviceClient.RetryPolicy;
            modifiedOptions.ServerTimeout = modifiedOptions.ServerTimeout ?? serviceClient.ServerTimeout;
            modifiedOptions.MaximumExecutionTime = modifiedOptions.MaximumExecutionTime ?? serviceClient.MaximumExecutionTime;

            if (!modifiedOptions.OperationExpiryTime.HasValue && modifiedOptions.MaximumExecutionTime.HasValue)
            {
                modifiedOptions.OperationExpiryTime = DateTime.Now + modifiedOptions.MaximumExecutionTime.Value;
            }

            return modifiedOptions;
        }

        /// <summary>
        ///  Gets or sets the absolute expiry time across all potential retries for the request. 
        /// </summary>
        internal DateTime? OperationExpiryTime { get; set; }

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
        /// Gets or sets the maximum execution time for all potential retries for the request.
        /// </summary>
        /// <value>A <see cref="TimeSpan"/> representing the maximum execution time for retries for the request.</value>
        public TimeSpan? MaximumExecutionTime { get; set; }
    }
}

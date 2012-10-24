// -----------------------------------------------------------------------------------------
// <copyright file="IRequestOptions.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage
{
    using Microsoft.WindowsAzure.Storage.RetryPolicies;
    using System;

    /// <summary>
    /// An interface required for request option types.
    /// </summary>
    /// <remarks>The <see cref="QueueRequestOptions"/>, <see cref="BlobRequestOptions"/>, and <see cref="TableRequestOptions"/> classes implement the <see cref="IRequestOptions"/> interface.</remarks>
    public interface IRequestOptions
    {
        /// <summary>
        /// Gets or sets the retry policy for the request.
        /// </summary>
        /// <value>The retry policy delegate.</value>
        IRetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Gets or sets the server timeout for the request. 
        /// </summary>
        /// <value>The client and server timeout interval for the request.</value>
        TimeSpan? ServerTimeout { get; set; }

        /// <summary>
        /// Gets or sets the maximum execution time across all potential retries.
        /// </summary>
        /// <value>The maximum execution time across all potential retries.</value>
        TimeSpan? MaximumExecutionTime { get; set; }
    }
}

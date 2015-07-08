// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System;
    using System.Threading;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    /// <summary>
    /// Provides an abstraction context over web requests.
    /// </summary>
    public interface IAbstractionContext
    {
        /// <summary>
        /// Gets the HTTP operation timeout.
        /// </summary>
        TimeSpan HttpOperationTimeout { get; }

        /// <summary>
        /// Gets a cancellation token to cancel any running requests.
        /// </summary>
        CancellationToken CancellationToken { get; }

        /// <summary>
        /// Gets a logger to write log messages to.
        /// </summary>
        ILogger Logger { get; }

        /// <summary>
        /// Gets the retry policy.
        /// </summary>
        IRetryPolicy RetryPolicy { get; }
    }
}
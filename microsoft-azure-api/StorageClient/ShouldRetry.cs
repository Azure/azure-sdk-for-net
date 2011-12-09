//-----------------------------------------------------------------------
// <copyright file="ShouldRetry.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
// <summary>
//    Contains code for the ShouldRetry delegate.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;

    /// <summary>
    /// Determines whether a request should be retried.
    /// </summary>
    /// <param name="retryCount">The number of times the request has been retried.</param>
    /// <param name="lastException">The exception raised by the most recent operation.</param>
    /// <param name="delay">An optional delay that specifies how long to wait before retrying a request.</param>
    /// <returns><c>true</c> if the request should be retried; otherwise, <c>false</c>.</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.Design",
        "CA1021:AvoidOutParameters",
        Justification = "Custom retry policies are advanced.")]
    public delegate bool ShouldRetry(int retryCount, Exception lastException, out TimeSpan delay);
}

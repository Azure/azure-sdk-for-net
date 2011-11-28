//-----------------------------------------------------------------------
// <copyright file="ShouldRetry.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
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

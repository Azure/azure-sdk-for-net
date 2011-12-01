//-----------------------------------------------------------------------
// <copyright file="RetryPolicy.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the RetryPolicy delegate.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    /// <summary>
    /// Returns a delegate that implements a custom retry policy.
    /// </summary>
    /// <returns>A delegate that determines whether or not to retry an operation.</returns>
    public delegate ShouldRetry RetryPolicy();
}

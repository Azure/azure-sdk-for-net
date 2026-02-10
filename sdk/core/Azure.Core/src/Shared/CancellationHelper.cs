#pragma warning disable SA1636
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#pragma warning restore SA1636

#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    // Copy of https://github.com/dotnet/runtime/blob/b6dda7b719eab464d417904a4f4501b42cc10cdb/src/libraries/System.Net.Http/src/System/Net/Http/CancellationHelper.cs#L10
    internal static class CancellationHelper
    {
        /// <summary>The default message used by <see cref="OperationCanceledException"/>.</summary>
        private static readonly string s_cancellationMessage = new OperationCanceledException().Message; // use same message as the default ctor

        /// <summary>Determines whether to wrap an <see cref="Exception"/> in a cancellation exception.</summary>
        /// <param name="exception">The exception.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that may have triggered the exception.</param>
        /// <returns>true if the exception should be wrapped; otherwise, false.</returns>
        internal static bool ShouldWrapInOperationCanceledException(Exception exception, CancellationToken cancellationToken) =>
            !(exception is OperationCanceledException) && cancellationToken.IsCancellationRequested;

        /// <summary>Creates a cancellation exception.</summary>
        /// <param name="innerException">The inner exception to wrap. May be null.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that triggered the cancellation.</param>
        /// <param name="message">The custom message to use.</param>
        /// <returns>The cancellation exception.</returns>
#pragma warning disable CA1801 // Unused parameter
        internal static Exception CreateOperationCanceledException(Exception? innerException, CancellationToken cancellationToken, string? message = null) =>
#pragma warning restore CA1801 // Unused parameter
#if NETCOREAPP2_1_OR_GREATER
            new TaskCanceledException(message ?? s_cancellationMessage, innerException, cancellationToken); // TCE for compatibility with other handlers that use TaskCompletionSource.TrySetCanceled()
#else
            new TaskCanceledException(message ?? s_cancellationMessage, innerException);
#endif

        /// <summary>Throws a cancellation exception.</summary>
        /// <param name="innerException">The inner exception to wrap. May be null.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that triggered the cancellation.</param>
        private static void ThrowOperationCanceledException(Exception? innerException, CancellationToken cancellationToken) =>
            throw CreateOperationCanceledException(innerException, cancellationToken);

        /// <summary>Throws a cancellation exception if cancellation has been requested via <paramref name="cancellationToken"/>.</summary>
        /// <param name="cancellationToken">The token to check for a cancellation request.</param>
        internal static void ThrowIfCancellationRequested(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                ThrowOperationCanceledException(innerException: null, cancellationToken);
            }
        }
    }
}
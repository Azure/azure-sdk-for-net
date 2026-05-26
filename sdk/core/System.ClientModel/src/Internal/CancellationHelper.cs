// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

// Copy of https://github.com/dotnet/runtime/blob/b6dda7b719eab464d417904a4f4501b42cc10cdb/src/libraries/System.Net.Http/src/System/Net/Http/CancellationHelper.cs#L10
internal static class CancellationHelper
{
    /// <summary>The default message used by <see cref="OperationCanceledException"/>.</summary>
    private static readonly string s_cancellationMessage = new OperationCanceledException().Message; // use same message as the default ctor

    /// <summary>Determines whether to wrap an <see cref="Exception"/> in a cancellation exception.</summary>
    /// <param name="exception">The exception.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> that may have triggered the exception.</param>
    /// <returns><c>true</c> if the exception should be wrapped; otherwise, <c>false</c>.</returns>
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
    /// <param name="innerException">The inner exception to wrap. May be null.</param>
    internal static void ThrowIfCancellationRequested(CancellationToken cancellationToken, Exception? innerException = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            ThrowOperationCanceledException(innerException, cancellationToken);
        }
    }

    /// <summary>Throws a cancellation exception if cancellation has been requested via <paramref name="messageToken"/> or <paramref name="timeoutToken"/>.</summary>
    /// <param name="messageToken">The user-provided token.</param>
    /// <param name="timeoutToken">The linked token that is cancelled on timeout provided token.</param>
    /// <param name="innerException">The inner exception to use.</param>
    /// <param name="timeout">The timeout used for the operation.</param>
#pragma warning disable CA1068 // Cancellation token has to be the last parameter
    internal static void ThrowIfCancellationRequestedOrTimeout(CancellationToken messageToken, CancellationToken timeoutToken, Exception? innerException, TimeSpan timeout)
#pragma warning restore CA1068
    {
        ThrowIfCancellationRequested(messageToken, innerException);

        if (timeoutToken.IsCancellationRequested)
        {
            throw CreateOperationCanceledException(
                innerException,
                timeoutToken,
                $"The operation was cancelled because it exceeded the configured timeout of {timeout:g}. " +
                    $"The default timeout can be adjusted by passing a custom {nameof(ClientPipelineOptions)}.{nameof(ClientPipelineOptions.NetworkTimeout)} value to the client's constructor. See https://aka.ms/net/scm/configure/networktimeout for more information.");
        }
    }
}

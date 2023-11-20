// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

internal class ClientUtilities
{
    #region Argument validation
    public static void AssertNotNull<T>(T value, string name)
    {
        if (value is null)
        {
            throw new ArgumentNullException(name);
        }
    }

    public static void AssertNotNullOrEmpty(string value, string name)
    {
        if (value is null)
        {
            throw new ArgumentNullException(name);
        }

        if (value.Length == 0)
        {
            throw new ArgumentException("Value cannot be an empty string.", name);
        }
    }

    /// <summary>
    /// Throws if <paramref name="value"/> is less than the <paramref name="minimum"/> or greater than the <paramref name="maximum"/>.
    /// </summary>
    /// <typeparam name="T">The type of to validate which implements <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="value">The value to validate.</param>
    /// <param name="minimum">The minimum value to compare.</param>
    /// <param name="maximum">The maximum value to compare.</param>
    /// <param name="name">The name of the parameter.</param>
    public static void AssertInRange<T>(T value, T minimum, T maximum, string name) where T : notnull, IComparable<T>
    {
        if (minimum.CompareTo(value) > 0)
        {
            throw new ArgumentOutOfRangeException(name, "Value is less than the minimum allowed.");
        }

        if (maximum.CompareTo(value) < 0)
        {
            throw new ArgumentOutOfRangeException(name, "Value is greater than the maximum allowed.");
        }
    }
    #endregion

    #region CancellationToken helpers

    /// <summary>The default message used by <see cref="OperationCanceledException"/>.</summary>
    private static readonly string s_cancellationMessage = new OperationCanceledException().Message; // use same message as the default ctor

    /// <summary>Determines whether to wrap an <see cref="Exception"/> in a cancellation exception.</summary>
    /// <param name="exception">The exception.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> that may have triggered the exception.</param>
    /// <returns>true if the exception should be wrapped; otherwise, false.</returns>
    public static bool ShouldWrapInOperationCanceledException(Exception exception, CancellationToken cancellationToken) =>
        !(exception is OperationCanceledException) && cancellationToken.IsCancellationRequested;

    /// <summary>Throws a cancellation exception if cancellation has been requested via <paramref name="cancellationToken"/>.</summary>
    /// <param name="cancellationToken">The token to check for a cancellation request.</param>
    public static void ThrowIfCancellationRequested(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            ThrowOperationCanceledException(innerException: null, cancellationToken);
        }
    }

    /// <summary>Throws a cancellation exception.</summary>
    /// <param name="innerException">The inner exception to wrap. May be null.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> that triggered the cancellation.</param>
    private static void ThrowOperationCanceledException(Exception? innerException, CancellationToken cancellationToken) =>
        throw CreateOperationCanceledException(innerException, cancellationToken);

    public static Exception CreateOperationCanceledException(Exception? innerException, CancellationToken cancellationToken, string? message = null) =>
#if NET6_0_OR_GREATER
        new TaskCanceledException(message ?? s_cancellationMessage, innerException, cancellationToken); // TCE for compatibility with other handlers that use TaskCompletionSource.TrySetCanceled()
#else
        new TaskCanceledException(message ?? s_cancellationMessage, innerException);
#endif

    #endregion
}

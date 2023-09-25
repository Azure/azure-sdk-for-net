// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Experimental
{
    /// <summary>
    /// TBD.
    /// </summary>
    public class ClientUtilities
    {
        /// <summary>
        /// TBD.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AssertNotNull<T>(T value, string name)
        {
            if (value is null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>The default message used by <see cref="OperationCanceledException"/>.</summary>
        private static readonly string s_cancellationMessage = new OperationCanceledException().Message; // use same message as the default ctor

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

        private static Exception CreateOperationCanceledException(Exception? innerException, CancellationToken cancellationToken, string? message = null) =>
#if NETCOREAPP2_1_OR_GREATER
            new TaskCanceledException(message ?? s_cancellationMessage, innerException, cancellationToken); // TCE for compatibility with other handlers that use TaskCompletionSource.TrySetCanceled()
#else
            new TaskCanceledException(message ?? s_cancellationMessage, innerException);
#endif
    }
}

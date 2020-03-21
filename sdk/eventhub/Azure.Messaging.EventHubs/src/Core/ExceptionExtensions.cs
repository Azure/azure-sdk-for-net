// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   The set of extensions for the <see cref="Exception" />
    ///   class.
    /// </summary>
    ///
    internal static class ExceptionExtensions
    {
        /// <summary>
        ///   Serves as an inverse to the "is" operator, determining whether the <paramref name="instance"/>
        ///   is NOT of type <typeparamref name="T"/>.
        /// </summary>
        ///
        /// <typeparam name="T">The <see cref="Exception" /> type to test the <paramref name="instance"/> against.</typeparam>
        ///
        /// <param name="instance">The instance to consider.</param>
        ///
        /// <returns><c>true</c> if the specified instance is NOT of type <typeparamref name="T"/>; otherwise, <c>false</c>.</returns>
        ///
        public static bool IsNotType<T>(this Exception instance) where T : Exception => (!(instance is T));

        /// <summary>
        ///   Determines whether the <paramref name="instance"/> is considered a fatal exception and should avoid retries,
        ///   logging, and similar activities.
        /// </summary>
        ///
        /// <param name="instance">The instance to consider.</param>
        ///
        /// <returns><c>true</c> if the specified instance should be considered fatal; otherwise, <c>false</c>.</returns>
        ///
        public static bool IsFatalException(this Exception instance) =>
            (instance is TaskCanceledException
                || instance is OutOfMemoryException
                || instance is StackOverflowException
                || instance is ThreadAbortException);
    }
}

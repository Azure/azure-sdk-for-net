// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   The set of extensions for the <see cref="CancellationToken" />
    ///   struct.
    /// </summary>
    ///
    internal static class CancellationTokenExtensions
    {
        /// <summary>
        ///   Throws an exception of the requested type if cancellation has been requested
        ///   of the <paramref name="instance" />.
        /// </summary>
        ///
        /// <typeparam name="T">The type of exception to throw; the type must have a parameterless constructor.</typeparam>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        ///
        public static void ThrowIfCancellationRequested<T>(this CancellationToken instance) where T : Exception, new()
        {
            if (instance.IsCancellationRequested)
            {
                throw new T();
            }
        }
    }
}

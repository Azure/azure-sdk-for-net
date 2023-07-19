// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Core
{
    internal abstract class TransportConnectionScope : IDisposable
    {
        /// <summary>
        ///   Indicates whether this <see cref="TransportConnectionScope"/> has been disposed.
        /// </summary>
        ///
        /// <value><c>true</c> if disposed; otherwise, <c>false</c>.</value>
        ///
        public abstract bool IsDisposed { get; protected set; }

        /// <summary>
        /// Disposes of the connection scope.
        /// </summary>
        public abstract void Dispose();
    }
}

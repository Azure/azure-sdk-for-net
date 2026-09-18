// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Azure.Core.Tests;
using NUnit.Framework;

namespace Azure.Core.TestFramework.Tests
{
    public class ClientDiagnosticListenerTests
    {
        [Test]
        public void DisposeReleasesAllListenersSubscription()
        {
            var references = new List<WeakReference>();
            for (int i = 0; i < 10; i++)
            {
                references.Add(CreateAndDisposeListener());
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            CollectionAssert.IsEmpty(
                references.FindAll(r => r.IsAlive),
                "Disposed listeners are still rooted by DiagnosticListener.AllListeners.");
        }

        // The listener must not be reachable from the caller's frame, otherwise it stays rooted
        // regardless of whether the subscription was released.
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static WeakReference CreateAndDisposeListener()
        {
            var listener = new ClientDiagnosticListener($"Source.{Guid.NewGuid()}");
            listener.Dispose();
            return new WeakReference(listener);
        }
    }
}

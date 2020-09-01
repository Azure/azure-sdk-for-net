// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="CancellationTokenExtensions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class CancellationTokenExtensionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="CancellationTokenExtensions.ThrowIfCancellationRequested" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ThrowIfCancellationRequestedDoesNotThrowIfNotCanceled()
        {
            using var source = new CancellationTokenSource();
            Assert.That(() => source.Token.ThrowIfCancellationRequested<TaskCanceledException>(), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CancellationTokenExtensions.ThrowIfCancellationRequested" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ThrowIfCancellationRequestedThrowsTheRequestedType()
        {
            using var source = new CancellationTokenSource();
            source.Cancel();

            Assert.That(() => source.Token.ThrowIfCancellationRequested<TaskCanceledException>(), Throws.InstanceOf<TaskCanceledException>(), "A TaskCanceledException was requested and should have been thrown.");
            Assert.That(() => source.Token.ThrowIfCancellationRequested<ArithmeticException>(), Throws.InstanceOf<ArithmeticException>(), "A ArithmeticException was requested and should have been thrown.");
        }
    }
}

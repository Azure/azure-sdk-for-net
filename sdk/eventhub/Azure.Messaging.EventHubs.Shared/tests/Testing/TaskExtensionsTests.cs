// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="TaskExtensions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class TaskExtensionsTests
    {
        /// <summary>
        ///  Verifies functionality of the <see cref="TaskExtensions.IgnoreExceptions" />
        ///  method.
        /// </summary>
        ///
        [Test]
        public void IgnoreExceptionDoesNotSurfaceExceptions()
        {
            var exceptionTask = Task.Run(() => throw new DllNotFoundException());
            Assert.That(async () => await exceptionTask.IgnoreExceptions(), Throws.Nothing);
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="TaskExtensions.IgnoreExceptions" />
        ///  method.
        /// </summary>
        ///
        [Test]
        public void IgnoreExceptionDoesNotInterfereWithSuccessfulTasks()
        {
            var successfulTask = Task.Delay(250);
            Assert.That(async () => await successfulTask.IgnoreExceptions(), Throws.Nothing);
        }
    }
}

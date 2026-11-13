// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="ExceptionExtensions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class ExceptionExtensionsTests
    {
        /// <summary>
        ///  Verifies functionality of the <see cref="ExceptionExtensions.IsNotType" />
        ///  method.
        /// </summary>
        ///
        public void IsNotTypeRecognizesAnInstanceOfTheType()
        {
            var instance = new DivideByZeroException();
            Assert.That(instance.IsNotType<DivideByZeroException>(), Is.False);
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="ExceptionExtensions.IsNotType" />
        ///  method.
        /// </summary>
        ///
        public void IsNotTypeRecognizesASubTypeOfTheType()
        {
            var instance = new DivideByZeroException();
            Assert.That(instance.IsNotType<Exception>(), Is.False);
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="ExceptionExtensions.IsFatalException" />
        ///  method.
        /// </summary>
        ///
        public void IsFatalExceptionRecognizesTaskCancellationAsFatal()
        {
            var instance = new TaskCanceledException();
            Assert.That(instance.IsFatalException(), Is.True);
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="ExceptionExtensions.IsFatalException" />
        ///  method.
        /// </summary>
        ///
        public void IsFatalExceptionRecognizesEventHubsExceptionIsNotFatal()
        {
            var instance = new EventHubsException(true, "hub");
            Assert.That(instance.IsFatalException(), Is.False);
        }
    }
}

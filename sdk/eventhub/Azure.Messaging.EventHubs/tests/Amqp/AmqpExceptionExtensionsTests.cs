// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Amqp;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="Amqp.ExceptionExtensions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class AmqpExceptionExtensionsTests
    {
        /// <summary>
        ///   The set of test cases for "normal" exceptions that do not get
        ///   translated.
        /// </summary>
        ///
        public static IEnumerable<object[]> GeneralExceptionCases()
        {
            yield return new[] { new ArgumentNullException("blah") };
            yield return new[] { new EventHubsException(false, "thing") };
            yield return new[] { new TimeoutException() };
            yield return new[] { new Exception() };
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExceptionExtensions.TranslateServiceException" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TranslateServiceExceptionValidatesTheInstance()
        {
            Assert.That(() => ((Exception)null).TranslateServiceException("dummy"), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExceptionExtensions.TranslateServiceException" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TranslateServiceExceptionTranslatesAmqpExceptions()
        {
            var eventHub = "someHub";
            var exception = AmqpError.CreateExceptionForError(new Error { Condition = AmqpError.ServerBusyError }, eventHub);
            var translated = exception.TranslateServiceException(eventHub);

            Assert.That(translated, Is.Not.Null, "An exception should have been returned.");

            var eventHubsException = translated as EventHubsException;
            Assert.That(eventHubsException, Is.Not.Null, "The exception type should be appropriate for the `Server Busy` scenario.");
            Assert.That(eventHubsException.Reason, Is.EqualTo(EventHubsException.FailureReason.ServiceBusy), "The exception reason should indicate `Server Busy`.");
            Assert.That(eventHubsException.EventHubName, Is.EqualTo(eventHub), "The Event Hub name should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExceptionExtensions.TranslateServiceException" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TranslateServiceExceptionTranslatesOperationCanceledWithoutEmbeddedExceptions()
        {
            var eventHub = "someHub";
            var exception = new OperationCanceledException();
            var translated = exception.TranslateServiceException(eventHub);

            Assert.That(translated, Is.Not.Null, "An exception should have been returned.");

            var eventHubsException = translated as EventHubsException;
            Assert.That(eventHubsException, Is.Not.Null, "The exception type should be appropriate for the `Server Busy` scenario.");
            Assert.That(eventHubsException.Reason, Is.EqualTo(EventHubsException.FailureReason.ServiceTimeout), "The exception reason should indicate a service timeout.");
            Assert.That(eventHubsException.EventHubName, Is.EqualTo(eventHub), "The Event Hub name should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExceptionExtensions.TranslateServiceException" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TranslateServiceExceptionTranslatesOperationCanceledWithEmbeddedAmqpException()
        {
            var eventHub = "someHub";
            var exception = new OperationCanceledException("oops", AmqpError.CreateExceptionForError(new Error { Condition = AmqpError.ServerBusyError }, eventHub));
            var translated = exception.TranslateServiceException(eventHub);

            Assert.That(translated, Is.Not.Null, "An exception should have been returned.");

            var eventHubsException = translated as EventHubsException;
            Assert.That(eventHubsException, Is.Not.Null, "The exception type should be appropriate for the `Server Busy` scenario.");
            Assert.That(eventHubsException.Reason, Is.EqualTo(EventHubsException.FailureReason.ServiceBusy), "The exception reason should indicate `Server Busy`.");
            Assert.That(eventHubsException.EventHubName, Is.EqualTo(eventHub), "The Event Hub name should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExceptionExtensions.TranslateServiceException" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TranslateServiceExceptionTranslatesOperationCanceledWithEmbeddedGeneralException()
        {
            var eventHub = "someHub";
            var embedded = new ArgumentException();
            var exception = new OperationCanceledException("oops", embedded);
            var translated = exception.TranslateServiceException(eventHub);

            Assert.That(translated, Is.Not.Null, "An exception should have been returned.");
            Assert.That(translated, Is.SameAs(embedded), "The embedded (inner) exception should have been returned.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExceptionExtensions.TranslateServiceException" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(GeneralExceptionCases))]
        public void TranslateServiceExceptionDoesNotTranslateGeneralExceptions(Exception generalException)
        {
            var eventHub = "someHub";
            var translated = generalException.TranslateServiceException(eventHub);

            Assert.That(translated, Is.Not.Null, "An exception should have been returned.");
            Assert.That(translated, Is.SameAs(generalException), "The general exception should have been returned.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExceptionExtensions.TranslateConnectionCloseDuringLinkCreationException" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TranslateConnectionCloseDuringLinkCreationExceptionValidatesTheInstance()
        {
            Assert.That(() => ((InvalidOperationException)null).TranslateConnectionCloseDuringLinkCreationException("dummy"), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExceptionExtensions.TranslateConnectionCloseDuringLinkCreationException" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TranslateConnectionCloseDuringLinkCreationExceptionDetectsTheConnectionClosedTaskCanceledException()
        {
            var sourceException = new TaskCanceledException();
            var exception = (sourceException.TranslateConnectionCloseDuringLinkCreationException("dummy") as EventHubsException);

            Assert.That(exception, Is.Not.Null, "The exception should have been translated to an Event Hubs exception.");
            Assert.That(exception.IsTransient, Is.True, "The translation exception should allow retries.");
            Assert.That(exception.Reason, Is.EqualTo(EventHubsException.FailureReason.ServiceCommunicationProblem), "The translated exception should have the correct failure reason.");
            Assert.That(exception.InnerException, Is.EqualTo(sourceException), "The translated exception should wrap the source exception.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExceptionExtensions.TranslateConnectionCloseDuringLinkCreationException" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TranslateConnectionCloseDuringLinkCreationExceptionDetectsTheConnectionClosedInvalidOperationException()
        {
            var sourceException = new InvalidOperationException("Can't create session when the connection is closing");
            var exception = (sourceException.TranslateConnectionCloseDuringLinkCreationException("dummy") as EventHubsException);

            Assert.That(exception, Is.Not.Null, "The exception should have been translated to an Event Hubs exception.");
            Assert.That(exception.IsTransient, Is.True, "The translation exception should allow retries.");
            Assert.That(exception.Reason, Is.EqualTo(EventHubsException.FailureReason.ServiceCommunicationProblem), "The translated exception should have the correct failure reason.");
            Assert.That(exception.InnerException, Is.EqualTo(sourceException), "The translated exception should wrap the source exception.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExceptionExtensions.TranslateConnectionCloseDuringLinkCreationException" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("nope")]
        [TestCase("when the connection is closed")]
        [TestCase("Can't create session")]
        public void TranslateConnectionCloseDuringLinkCreationExceptionIgnoresNonMatchingInvalidOperationExceptions(string sourceMessage)
        {
            var sourceException = new InvalidOperationException(sourceMessage);
            var exception = sourceException.TranslateConnectionCloseDuringLinkCreationException("dummy");

            Assert.That(exception, Is.SameAs(sourceException), "The exception should not have been translated.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExceptionExtensions.TranslateConnectionCloseDuringLinkCreationException" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TranslateConnectionCloseDuringLinkCreationExceptionDetectsTheConnectionClosedObjectDisposedException()
        {
            var sourceException = new ObjectDisposedException("foo");
            var exception = (sourceException.TranslateConnectionCloseDuringLinkCreationException("dummy") as EventHubsException);

            Assert.That(exception, Is.Not.Null, "The exception should have been translated to an Event Hubs exception.");
            Assert.That(exception.IsTransient, Is.False, "The translation exception should not allow retries.");
            Assert.That(exception.Reason, Is.EqualTo(EventHubsException.FailureReason.ClientClosed), "The translated exception should have the correct failure reason.");
            Assert.That(exception.InnerException, Is.EqualTo(sourceException), "The translated exception should wrap the source exception.");
        }
    }
}

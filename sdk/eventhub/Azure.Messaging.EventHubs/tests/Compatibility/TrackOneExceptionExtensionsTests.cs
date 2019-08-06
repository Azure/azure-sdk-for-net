// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Messaging.EventHubs.Compatibility;
using Azure.Messaging.EventHubs.Errors;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="TrackOneExceptionExtensions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class TrackOneExceptionExtensionsTests
    {
        /// <summary>
        ///   The set of test cases for the well-known types derived from the <see cref="EventHubsException" />
        ///   and their expected transient status.
        /// </summary>
        ///
        public static IEnumerable<object[]> ExceptionMappingTestCases()
        {
            TrackOne.EventHubsException exception;

            exception = new TrackOne.EventHubsCommunicationException("One");
            exception.EventHubsNamespace = "test_thing";
            yield return new object[] { exception, typeof(Errors.EventHubsCommunicationException) };

            exception = new TrackOne.EventHubsTimeoutException("Two");
            exception.EventHubsNamespace = "OMG!-Thing!";
            yield return new object[] { exception, typeof(Errors.EventHubsTimeoutException) };

            yield return new object[] { new TrackOne.MessagingEntityNotFoundException("Three"), typeof(Errors.EventHubsResourceNotFoundException) };
            yield return new object[] { new TrackOne.MessageSizeExceededException("Four"), typeof(Errors.MessageSizeExceededException) };
            yield return new object[] { new TrackOne.QuotaExceededException("Five"), typeof(Errors.QuotaExceededException) };
            yield return new object[] { new TrackOne.ReceiverDisconnectedException("Six"), typeof(Errors.ConsumerDisconnectedException) };
            yield return new object[] { new TrackOne.ServerBusyException("Seven"), typeof(Errors.ServiceBusyException) };
            yield return new object[] { new TrackOne.EventHubsException(true, "Eight"), typeof(Errors.EventHubsException) };
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneExceptionExtensions.MapToTrackTwoException" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void MapExceptionValidatesTheInstance()
        {
            Assert.That(() => ((TrackOne.EventHubsException)null).MapToTrackTwoException(), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies that well-known derived exception types have the correct value for their
        ///   <see cref="EventHubsException.IsTransient" /> property.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ExceptionMappingTestCases))]
        public void DerrivedExceptionsHaveTheCorrectTransientValues(Exception exception,
                                                                    Type expectedMappedType)
        {
            var eventHubsException = (TrackOne.EventHubsException)exception;
            var mappedException = eventHubsException.MapToTrackTwoException();

            Assert.That(mappedException, Is.Not.Null, "The mapping should produce an exception.");
            Assert.That(mappedException.GetType(), Is.EqualTo(expectedMappedType), "The mapped exception type was incorrect.");
            Assert.That(mappedException.IsTransient, Is.EqualTo(eventHubsException.IsTransient), "The mapped exception should agree on being transient.");
            Assert.That(mappedException.ResourceName, Is.EqualTo(eventHubsException.EventHubsNamespace), "The mapped exception should use the namespace as its resource name.");
            Assert.That(mappedException.Message, Does.Contain(eventHubsException.EventHubsNamespace ?? String.Empty), "The mapped exception should include the namespace in its message.");
            Assert.That(mappedException.Message, Does.Contain(eventHubsException.RawMessage), "The mapped exception should include the message text in its message.");
            Assert.That(mappedException.InnerException, Is.EqualTo(eventHubsException), "The mapped exception should wrap the original instance.");
        }

        /// <summary>
        ///   Verifies that derived exception types in the current library are well-known and have a
        ///   corresponding test case.
        /// </summary>
        ///
        [Test]
        public void EventHubsExceptionTypesShouldHaveMappings()
        {
            var allDerrivedTypes = typeof(EventHubsException)
               .Assembly
               .GetTypes()
               .Where(type => typeof(EventHubsException).IsAssignableFrom(type))
               .Select(type => type.Name)
               .OrderBy(name => name);

            var knownDerrivedTypes = ExceptionMappingTestCases()
                .Select(testCase => ((Type)testCase[1]).Name)
                .OrderBy(name => name);

            Assert.That(allDerrivedTypes, Is.EquivalentTo(knownDerrivedTypes), "All exceptions derived from EventHubsException in the client library should have a matching mapping.");
        }
    }
}

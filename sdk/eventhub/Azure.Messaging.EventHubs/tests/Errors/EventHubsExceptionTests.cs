// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Messaging.EventHubs.Errors;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubsException" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventHubsExceptionTests
    {
        /// <summary>
        ///   The set of test cases for the different constructor signatures.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorPropertyTestCases()
        {
            Func<EventHubsException> constructor;

            constructor = () => new EventHubsException(true, "test");
            yield return new object[] { constructor, true, "test", "constructor with transient and resource" };

            constructor = () => new EventHubsException(true, "thing", null);
            yield return new object[] { constructor, true, "thing", "constructor with transient, resource, and message" };

            constructor = () => new EventHubsException(true, "bobl", null, new Exception());
            yield return new object[] { constructor, true, "bobl", "constructor with transient, resource, message, and exception" };
        }

        /// <summary>
        ///   The set of test cases for the well-known types derived from the <see cref="EventHubsException" />
        ///   and their expected transient status.
        /// </summary>
        ///
        public static IEnumerable<object[]> DerrivedExceptionTransientTestCases()
        {
            // Transient exceptions

            yield return new object[] { new EventHubsCommunicationException("resource", "message"), true };
            yield return new object[] { new EventHubsTimeoutException("resource", "message"), true };
            yield return new object[] { new ServiceBusyException("resource", "message"), true };

            // Final exceptions

            yield return new object[] { new MessageSizeExceededException("resource", "message"), false };
            yield return new object[] { new EventHubsResourceNotFoundException("resource", "message"), false };
            yield return new object[] { new QuotaExceededException("resource", "message"), false };
            yield return new object[] { new ConsumerDisconnectedException("resource", "message"), false };
            yield return new object[] { new EventHubsClientClosedException("resource", "message"), false };
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorPropertyTestCases))]
        public void ConstructorSetsCustomProperties(Func<EventHubsException> constructor,
                                                    bool expectedIsTransient,
                                                    string expectedResourceName,
                                                    string constructorDescription)
        {
            EventHubsException instance = constructor();
            Assert.That(instance.IsTransient, Is.EqualTo(expectedIsTransient), $"IsTransient should be set for the { constructorDescription }");
            Assert.That(instance.ResourceName, Is.EqualTo(expectedResourceName), $"EventHubsNamespace should be set for the { constructorDescription }");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsException.Message" />
        ///   property.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void MessageIsPopulatedForNoResource(string resourceName)
        {
            var message = "Test message!";
            var instance = new EventHubsException(false, resourceName, message);

            Assert.That(instance.Message, Is.EqualTo(message));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsException.Message" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void MessageUsesResourceName()
        {
            var message = "Test message!";
            var namespaceValue = "the-namespace";
            var instance = new EventHubsException(false, namespaceValue, message);

            Assert.That(instance.Message, Does.Contain(namespaceValue), "The message should include the Event Hubs namespace");
            Assert.That(instance.Message, Does.Contain(message), "The message should include the exception message text");
        }

        /// <summary>
        ///   Verifies that well-known derived exception types have the correct value for their
        ///   <see cref="EventHubsException.IsTransient" /> property.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(DerrivedExceptionTransientTestCases))]
        public void DerrivedExceptionsHaveTheCorrectTransientValues(EventHubsException exception,
                                                                    bool expectedTransient)
        {
            Assert.That(exception.IsTransient, Is.EqualTo(expectedTransient), $"The { exception.GetType().Name } has an incorrect IsTransient value.");
        }

        /// <summary>
        ///   Verifies that derived exception types in the current library are well-known and have a
        ///   corresponding test case.
        /// </summary>
        ///
        [Test]
        public void DerrivedExceptionsAreWellKnown()
        {
            IOrderedEnumerable<string> allDerrivedTypes = typeof(EventHubsException)
               .Assembly
               .GetTypes()
               .Where(type => (type != typeof(EventHubsException) && typeof(EventHubsException).IsAssignableFrom(type)))
               .Select(type => type.Name)
               .OrderBy(name => name);

            IOrderedEnumerable<string> knownDerrivedTypes = DerrivedExceptionTransientTestCases()
                .Select(testCase => testCase[0].GetType().Name)
                .OrderBy(name => name);

            Assert.That(allDerrivedTypes, Is.EquivalentTo(knownDerrivedTypes), "All exceptions derived from EventHubsException in the client library should have a matching IsTransient test case.");
        }
    }
}

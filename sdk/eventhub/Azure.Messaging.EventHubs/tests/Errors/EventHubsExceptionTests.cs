// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
            yield return new object[] { constructor, true, "test", "constructor with transient and resource", default(EventHubsException.FailureReason) };

            constructor = () => new EventHubsException(true, "thing", null);
            yield return new object[] { constructor, true, "thing", "constructor with transient, resource, and message", default(EventHubsException.FailureReason) };

            constructor = () => new EventHubsException(true, "bobl", null, new Exception());
            yield return new object[] { constructor, true, "bobl", "constructor with transient, resource, message, and exception", default(EventHubsException.FailureReason) };

            constructor = () => new EventHubsException(true, "bobl", null, EventHubsException.FailureReason.ClientClosed, new Exception());
            yield return new object[] { constructor, true, "bobl", "constructor with transient, resource, message, reason, and exception", EventHubsException.FailureReason.ClientClosed };

            constructor = () => new EventHubsException(true, "bobl", null, EventHubsException.FailureReason.MessageSizeExceeded);
            yield return new object[] { constructor, true, "bobl", "constructor with transient, resource, message, and reason", EventHubsException.FailureReason.MessageSizeExceeded };

            constructor = () => new EventHubsException(true, "bobl", EventHubsException.FailureReason.QuotaExceeded);
            yield return new object[] { constructor, true, "bobl", "constructor with transient, resource, and reason", EventHubsException.FailureReason.QuotaExceeded };

            constructor = () => new EventHubsException("bobl", null, EventHubsException.FailureReason.MessageSizeExceeded);
            yield return new object[] { constructor, false, "bobl", "constructor with resource, message, and reason", EventHubsException.FailureReason.MessageSizeExceeded };
        }

        /// <summary>
        ///   The set of test cases for the well-known reasons associated with the <see cref="EventHubsException" />
        ///   and their expected transient status.
        /// </summary>
        ///
        public static IEnumerable<object[]> ExceptionTransientTestCases()
        {
            foreach (var name in Enum.GetNames(typeof(EventHubsException.FailureReason)))
            {
                var item = (EventHubsException.FailureReason)Enum.Parse(typeof(EventHubsException.FailureReason), name);

                switch (item)
                {
                    case EventHubsException.FailureReason.ServiceCommunicationProblem:
                    case EventHubsException.FailureReason.ServiceTimeout:
                    case EventHubsException.FailureReason.ServiceBusy:
                        yield return new object[] { item, true };
                        break;

                    default:
                        yield return new object[] { item, false };
                        break;
                }
            }
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
                                                    string constructorDescription,
                                                    EventHubsException.FailureReason expectedReason)
        {
            EventHubsException instance = constructor();
            Assert.That(instance.IsTransient, Is.EqualTo(expectedIsTransient), $"IsTransient should be set for the { constructorDescription }");
            Assert.That(instance.EventHubName, Is.EqualTo(expectedResourceName), $"EventHubsNamespace should be set for the { constructorDescription }");
            Assert.That(instance.Reason, Is.EqualTo(expectedReason), $"Reason should be set for the { constructorDescription }");
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

            Assert.That(instance.Message, Does.StartWith(message));
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
        ///   Verifies functionality of the <see cref="EventHubsException.Message" />
        ///   property.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("EntityName")]
        public void MessageIncludesTroubleshootingLink(string resourceName)
        {
            var message = "Test message!";
            var instance = new EventHubsException(false, resourceName, message);

            Assert.That(instance.Message, Contains.Substring(Resources.TroubleshootingGuideLink));
        }

        /// <summary>
        ///   Verifies that well-known derived exception types have the correct value for their
        ///   <see cref="EventHubsException.IsTransient" /> property.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ExceptionTransientTestCases))]
        public void FailureReasonsAreAssociatedWithTheCorrectTransientValues(EventHubsException.FailureReason failureReason,
                                                                             bool expectedTransient)
        {
            var exception = new EventHubsException("Name", "Message", failureReason);
            Assert.That(exception.IsTransient, Is.EqualTo(expectedTransient), $"The '{ failureReason }' reason has an incorrect IsTransient value.");
        }

        /// <summary>
        ///   Verifies that defined failure reasons in the current library are well-known and have a
        ///   corresponding test case.
        /// </summary>
        ///
        [Test]
        public void FailureReasonsAreWellKnown()
        {
            var knownReasons = new List<EventHubsException.FailureReason>();

            foreach (var name in Enum.GetNames(typeof(EventHubsException.FailureReason)))
            {
                knownReasons.Add((EventHubsException.FailureReason)Enum.Parse(typeof(EventHubsException.FailureReason), name));
            }

            IOrderedEnumerable<EventHubsException.FailureReason> reasonTestCases = ExceptionTransientTestCases()
                .Select(testCase => (EventHubsException.FailureReason)testCase[0])
                .OrderBy(item => item.ToString());

            Assert.That(knownReasons.OrderBy(item => item.ToString()), Is.EquivalentTo(reasonTestCases), "All failure reasons defined by EventHubsException in the client library should have a matching IsTransient test case.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsException.ToString" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToStringContainsExceptionDetails()
        {
            var message = "Test message!";
            var eventHubName = "the-thub";
            var reason = EventHubsException.FailureReason.QuotaExceeded;

            EventHubsException instance;

            try
            {
                throw new EventHubsException(false, eventHubName, message, reason);
            }
            catch (EventHubsException ex)
            {
                instance = ex;
            }

            var exceptionString = instance.ToString();
            Assert.That(exceptionString, Is.Not.Null.And.Not.Empty, "The ToString value should be populated.");
            Assert.That(exceptionString, Contains.Substring(typeof(EventHubsException).FullName), "The ToString value should contain the type name.");
            Assert.That(exceptionString, Contains.Substring(reason.ToString()), "The ToString value should contain the failure reason.");
            Assert.That(exceptionString, Contains.Substring(eventHubName), "The ToString value should contain the Event Hub name.");
            Assert.That(exceptionString, Contains.Substring($"{ Environment.NewLine }{ instance.StackTrace }"), "The ToString value should contain the stack trace on a new line.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsException.ToString" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToStringContainsInnerExceptionDetails()
        {
            var message = "Inner message!";
            var innerException = new DivideByZeroException(message);

            EventHubsException instance;

            try
            {
                throw new EventHubsException(false, "hub", "Outer", EventHubsException.FailureReason.QuotaExceeded, innerException);
            }
            catch (EventHubsException ex)
            {
                instance = ex;
            }

            var exceptionString = instance.ToString();
            Assert.That(exceptionString, Is.Not.Null.And.Not.Empty, "The ToString value should be populated.");
            Assert.That(exceptionString, Contains.Substring(innerException.ToString()), "The ToString value should contain the full set of details for the inner exception.");
        }
    }
}

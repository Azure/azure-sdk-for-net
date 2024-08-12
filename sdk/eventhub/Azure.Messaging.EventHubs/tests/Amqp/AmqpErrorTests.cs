// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="AmqpError" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class AmqpErrorTests
    {
        /// <summary>
        ///   The set of test cases for simple conditions and their matches
        ///   to the proper exception types.
        /// </summary>
        ///
        public static IEnumerable<object[]> SimpleConditionExceptionMatchTestCases()
        {
            // Custom conditions.

            yield return new object[] { AmqpError.TimeoutError, typeof(EventHubsException), EventHubsException.FailureReason.ServiceTimeout };
            yield return new object[] { AmqpError.DisabledError, typeof(EventHubsException), EventHubsException.FailureReason.ResourceNotFound };
            yield return new object[] { AmqpError.ServerBusyError, typeof(EventHubsException), EventHubsException.FailureReason.ServiceBusy };
            yield return new object[] { AmqpError.ProducerStolenError, typeof(EventHubsException), EventHubsException.FailureReason.ProducerDisconnected };
            yield return new object[] { AmqpError.SequenceOutOfOrderError, typeof(EventHubsException), EventHubsException.FailureReason.InvalidClientState };
            yield return new object[] { AmqpError.ArgumentError, typeof(ArgumentException), null };
            yield return new object[] { AmqpError.ArgumentOutOfRangeError, typeof(ArgumentOutOfRangeException), null };

            // Stock conditions.

            yield return new object[] { AmqpErrorCode.Stolen, typeof(EventHubsException), EventHubsException.FailureReason.ConsumerDisconnected };
            yield return new object[] { AmqpErrorCode.UnauthorizedAccess, typeof(UnauthorizedAccessException), null };
            yield return new object[] { AmqpErrorCode.ResourceLimitExceeded, typeof(EventHubsException), EventHubsException.FailureReason.QuotaExceeded };
            yield return new object[] { AmqpErrorCode.NotAllowed, typeof(InvalidOperationException), null };
            yield return new object[] { AmqpErrorCode.NotImplemented, typeof(NotSupportedException), null };
            yield return new object[] { AmqpErrorCode.IllegalState, typeof(EventHubsException), EventHubsException.FailureReason.ClientClosed };
        }

        /// <summary>
        ///   The set of test cases for simple status codes and their matches
        ///   to the proper exception types.
        /// </summary>
        ///
        public static IEnumerable<object[]> SimpleStatusExceptionMatchTestCases()
        {
            // Custom conditions.

            yield return new object[] { AmqpResponseStatusCode.RequestTimeout, typeof(EventHubsException), EventHubsException.FailureReason.ServiceTimeout };
            yield return new object[] { AmqpResponseStatusCode.ServiceUnavailable, typeof(EventHubsException), EventHubsException.FailureReason.ServiceBusy };
            yield return new object[] { AmqpResponseStatusCode.BadRequest, typeof(ArgumentException), null };

            // Stock conditions.

            yield return new object[] { AmqpResponseStatusCode.Gone, typeof(EventHubsException), EventHubsException.FailureReason.ConsumerDisconnected };
            yield return new object[] { AmqpResponseStatusCode.Unauthorized, typeof(UnauthorizedAccessException), null };
            yield return new object[] { AmqpResponseStatusCode.Forbidden, typeof(EventHubsException), EventHubsException.FailureReason.QuotaExceeded };
            yield return new object[] { AmqpResponseStatusCode.NotImplemented, typeof(NotSupportedException), null };
            yield return new object[] { AmqpResponseStatusCode.InternalServerError, typeof(EventHubsException), EventHubsException.FailureReason.ServiceCommunicationProblem };
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.CreateExceptionForResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateExceptionForResponseWithNoResponse()
        {
            Exception exception = AmqpError.CreateExceptionForResponse(null, null);

            Assert.That(exception, Is.Not.Null, "An exception should have been created");
            Assert.That(exception, Is.TypeOf<EventHubsException>(), "The exception should be a generic Event Hubs exception");
            Assert.That(exception.Message, Does.StartWith(Resources.UnknownCommunicationException), "The exception message should indicate an unknown failure");
            Assert.That(((EventHubsException)exception).IsTransient, Is.True, "The exception should be considered transient");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.CreateExceptionForResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(SimpleStatusExceptionMatchTestCases))]
        public void CreateExceptionForResponseWitStatus(AmqpResponseStatusCode statusCode,
                                                        Type exceptionType,
                                                        EventHubsException.FailureReason? reason)
        {
            var description = "This is a test description.";
            var resourceName = "TestHub";

            using var response = AmqpMessage.Create();
            response.ApplicationProperties = new ApplicationProperties();
            response.ApplicationProperties.Map[AmqpResponse.StatusCode] = (int)statusCode;
            response.ApplicationProperties.Map[AmqpResponse.StatusDescription] = description;

            Exception exception = AmqpError.CreateExceptionForResponse(response, resourceName);

            Assert.That(exception, Is.Not.Null, "An exception should have been created");
            Assert.That(exception, Is.TypeOf(exceptionType), "The exception should be the proper type");
            Assert.That(exception.Message, Is.SupersetOf(description), "The exception message should contain the description");

            if (exception is EventHubsException)
            {
                Assert.That(((EventHubsException)exception).Reason, Is.EqualTo(reason), "The proper failure reason should be specified");
                Assert.That(((EventHubsException)exception).EventHubName, Is.EqualTo(resourceName), "The exception should report the proper resource");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.CreateExceptionForResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateExceptionForResponseWithTimeoutStatusAndStatusDescription()
        {
            var description = $"This has { GetNotFoundStatusText() } embedded in it";
            var resourceName = "TestHub";

            using var response = AmqpMessage.Create();
            response.ApplicationProperties = new ApplicationProperties();
            response.ApplicationProperties.Map[AmqpResponse.StatusCode] = (int)AmqpResponseStatusCode.NotFound;
            response.ApplicationProperties.Map[AmqpResponse.StatusDescription] = description;

            Exception exception = AmqpError.CreateExceptionForResponse(response, resourceName);

            Assert.That(exception, Is.Not.Null, "An exception should have been created");
            Assert.That(exception, Is.TypeOf<EventHubsException>(), "The exception should match");
            Assert.That(((EventHubsException)exception).Reason, Is.EqualTo(EventHubsException.FailureReason.ResourceNotFound), "The exception reason should match.");
            Assert.That(exception.Message, Is.SupersetOf(description), "The exception message should contain the description");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.CreateExceptionForResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateExceptionForResponseWithTimeoutStatusAndPattern()
        {
            var description = GetNotFoundExpression().ToString().Replace("*.", "some value");
            var resourceName = "TestHub";

            using var response = AmqpMessage.Create();
            response.ApplicationProperties = new ApplicationProperties();
            response.ApplicationProperties.Map[AmqpResponse.StatusCode] = (int)AmqpResponseStatusCode.NotFound;
            response.ApplicationProperties.Map[AmqpResponse.StatusDescription] = description;

            Exception exception = AmqpError.CreateExceptionForResponse(response, resourceName);

            Assert.That(exception, Is.Not.Null, "An exception should have been created");
            Assert.That(exception, Is.TypeOf<EventHubsException>(), "The exception should match");
            Assert.That(((EventHubsException)exception).Reason, Is.EqualTo(EventHubsException.FailureReason.ResourceNotFound), "The exception reason should match.");
            Assert.That(exception.Message, Is.SupersetOf(description), "The exception message should contain the description");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.CreateExceptionForResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateExceptionForResponseWithUnmappedStatus()
        {
            var description = "Some description";
            var resourceName = "TestHub";

            using var response = AmqpMessage.Create();
            response.ApplicationProperties = new ApplicationProperties();
            response.ApplicationProperties.Map[AmqpResponse.StatusCode] = int.MaxValue;
            response.ApplicationProperties.Map[AmqpResponse.StatusDescription] = description;

            Exception exception = AmqpError.CreateExceptionForResponse(response, resourceName);

            Assert.That(exception, Is.Not.Null, "An exception should have been created");
            Assert.That(exception, Is.TypeOf<EventHubsException>(), "The exception should match");
            Assert.That(exception.Message, Is.SupersetOf(description), "The exception message should contain the description");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.CreateExceptionForResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(SimpleConditionExceptionMatchTestCases))]
        public void CreateExceptionForResponseWithCondition(AmqpSymbol condition,
                                                            Type exceptionType,
                                                            EventHubsException.FailureReason? reason)
        {
            var description = "This is a test description.";
            var resourceName = "TestHub";

            using var response = AmqpMessage.Create();
            response.ApplicationProperties = new ApplicationProperties();
            response.ApplicationProperties.Map[AmqpResponse.ErrorCondition] = condition;
            response.ApplicationProperties.Map[AmqpResponse.StatusDescription] = description;

            Exception exception = AmqpError.CreateExceptionForResponse(response, resourceName);

            Assert.That(exception, Is.Not.Null, "An exception should have been created");
            Assert.That(exception, Is.TypeOf(exceptionType), "The exception should be the proper type");
            Assert.That(exception.Message, Is.SupersetOf(description), "The exception message should contain the description");

            if (exception is EventHubsException)
            {
                Assert.That(((EventHubsException)exception).Reason, Is.EqualTo(reason), "The proper failure reason should be specified");
                Assert.That(((EventHubsException)exception).EventHubName, Is.EqualTo(resourceName), "The exception should report the proper resource");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.CreateExceptionForResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateExceptionForResponseWithTimeoutConditionAndStatusDescription()
        {
            var description = $"This has { GetNotFoundStatusText() } embedded in it";
            var resourceName = "TestHub";

            using var response = AmqpMessage.Create();
            response.ApplicationProperties = new ApplicationProperties();
            response.ApplicationProperties.Map[AmqpResponse.ErrorCondition] = AmqpErrorCode.NotFound;
            response.ApplicationProperties.Map[AmqpResponse.StatusDescription] = description;

            Exception exception = AmqpError.CreateExceptionForResponse(response, resourceName);

            Assert.That(exception, Is.Not.Null, "An exception should have been created");
            Assert.That(exception, Is.TypeOf<EventHubsException>(), "The exception should match");
            Assert.That(((EventHubsException)exception).Reason, Is.EqualTo(EventHubsException.FailureReason.ResourceNotFound), "The exception reason should match.");
            Assert.That(exception.Message, Is.SupersetOf(description), "The exception message should contain the description");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.CreateExceptionForResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateExceptionForResponseWithTimeoutConditionAndPattern()
        {
            var description = GetNotFoundExpression().ToString().Replace("*.", "some value");
            var resourceName = "TestHub";

            using var response = AmqpMessage.Create();
            response.ApplicationProperties = new ApplicationProperties();
            response.ApplicationProperties.Map[AmqpResponse.ErrorCondition] = AmqpErrorCode.NotFound;
            response.ApplicationProperties.Map[AmqpResponse.StatusDescription] = description;

            Exception exception = AmqpError.CreateExceptionForResponse(response, resourceName);

            Assert.That(exception, Is.Not.Null, "An exception should have been created");
            Assert.That(exception, Is.TypeOf<EventHubsException>(), "The exception should match");
            Assert.That(((EventHubsException)exception).Reason, Is.EqualTo(EventHubsException.FailureReason.ResourceNotFound), "The exception reason should match.");
            Assert.That(exception.Message, Is.SupersetOf(description), "The exception message should contain the description");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.CreateExceptionForResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateExceptionForResponseWithUnknownTimeout()
        {
            var description = "NOT_KNOWN";
            var resourceName = "TestHub";

            using var response = AmqpMessage.Create();
            response.ApplicationProperties = new ApplicationProperties();
            response.ApplicationProperties.Map[AmqpResponse.ErrorCondition] = AmqpErrorCode.NotFound;
            response.ApplicationProperties.Map[AmqpResponse.StatusDescription] = description;

            Exception exception = AmqpError.CreateExceptionForResponse(response, resourceName);

            Assert.That(exception, Is.Not.Null, "An exception should have been created");
            Assert.That(exception, Is.TypeOf<EventHubsException>(), "The exception should match");
            Assert.That(((EventHubsException)exception).Reason, Is.EqualTo(EventHubsException.FailureReason.ServiceCommunicationProblem), "The exception reason should match.");
            Assert.That(exception.Message, Is.SupersetOf(description), "The exception message should contain the description");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.CreateExceptionForResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateExceptionForResponseWithUnknownCondition()
        {
            var description = "NOT_KNOWN";
            var resourceName = "TestHub";

            using var response = AmqpMessage.Create();
            response.ApplicationProperties = new ApplicationProperties();
            response.ApplicationProperties.Map[AmqpResponse.ErrorCondition] = new AmqpSymbol("Invalid");
            response.ApplicationProperties.Map[AmqpResponse.StatusDescription] = description;

            Exception exception = AmqpError.CreateExceptionForResponse(response, resourceName);

            Assert.That(exception, Is.Not.Null, "An exception should have been created");
            Assert.That(exception, Is.TypeOf<EventHubsException>(), "The exception should match");
            Assert.That(exception.Message, Is.SupersetOf(description), "The exception message should contain the description");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.CreateExceptionForError" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateExceptionForErrorWithNoResponse()
        {
            Exception exception = AmqpError.CreateExceptionForError(null, null);

            Assert.That(exception, Is.Not.Null, "An exception should have been created");
            Assert.That(exception, Is.TypeOf<EventHubsException>(), "The exception should be a generic Event Hubs exception");
            Assert.That(exception.Message, Does.StartWith(Resources.UnknownCommunicationException), "The exception message should indicate an unknown failure");
            Assert.That(((EventHubsException)exception).IsTransient, Is.True, "The exception should be considered transient");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.CreateExceptionForError" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(SimpleConditionExceptionMatchTestCases))]
        public void CreateExceptionForErrorWithCondition(AmqpSymbol condition,
                                                         Type exceptionType,
                                                         EventHubsException.FailureReason? reason)
        {
            var description = "This is a test description.";
            var resourceName = "TestHub";

            var error = new Error
            {
                Condition = condition,
                Description = description
            };

            Exception exception = AmqpError.CreateExceptionForError(error, resourceName);

            Assert.That(exception, Is.Not.Null, "An exception should have been created");
            Assert.That(exception, Is.TypeOf(exceptionType), "The exception should be the proper type");
            Assert.That(exception.Message, Is.SupersetOf(description), "The exception message should contain the description");

            if (exception is EventHubsException)
            {
                Assert.That(((EventHubsException)exception).Reason, Is.EqualTo(reason), "The proper failure reason should be specified");
                Assert.That(((EventHubsException)exception).EventHubName, Is.EqualTo(resourceName), "The exception should report the proper resource");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.CreateExceptionForError" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateExceptionForErrorWithTimeoutStatusDescription()
        {
            var description = $"This has { GetNotFoundStatusText() } embedded in it";
            var resourceName = "TestHub";

            var error = new Error
            {
                Condition = AmqpErrorCode.NotFound,
                Description = description
            };

            Exception exception = AmqpError.CreateExceptionForError(error, resourceName);

            Assert.That(exception, Is.Not.Null, "An exception should have been created");
            Assert.That(exception, Is.TypeOf<EventHubsException>(), "The exception should match");
            Assert.That(((EventHubsException)exception).Reason, Is.EqualTo(EventHubsException.FailureReason.ResourceNotFound), "The exception reason should match.");
            Assert.That(exception.Message, Is.SupersetOf(description), "The exception message should contain the description");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.CreateExceptionForError" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateExceptionForErrorWithTimeoutPattern()
        {
            var description = GetNotFoundExpression().ToString().Replace("*.", "some value");
            var resourceName = "TestHub";

            var error = new Error
            {
                Condition = AmqpErrorCode.NotFound,
                Description = description
            };

            Exception exception = AmqpError.CreateExceptionForError(error, resourceName);

            Assert.That(exception, Is.Not.Null, "An exception should have been created");
            Assert.That(exception, Is.TypeOf<EventHubsException>(), "The exception should match");
            Assert.That(((EventHubsException)exception).Reason, Is.EqualTo(EventHubsException.FailureReason.ResourceNotFound), "The exception reason should match.");
            Assert.That(exception.Message, Is.SupersetOf(description), "The exception message should contain the description");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.CreateExceptionForError" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateExceptionForErrorWithUnknownTimeout()
        {
            var description = "NOT_KNOWN";
            var resourceName = "TestHub";

            var error = new Error
            {
                Condition = AmqpErrorCode.NotFound,
                Description = description
            };

            Exception exception = AmqpError.CreateExceptionForError(error, resourceName);

            Assert.That(exception, Is.Not.Null, "An exception should have been created");
            Assert.That(exception, Is.TypeOf<EventHubsException>(), "The exception should match");
            Assert.That(((EventHubsException)exception).Reason, Is.EqualTo(EventHubsException.FailureReason.ServiceCommunicationProblem), "The exception reason should match.");
            Assert.That(exception.Message, Is.SupersetOf(description), "The exception message should contain the description");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.CreateExceptionForError" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateExceptionForErrorWithIllegalStateCondition()
        {
            var description = $"'someclient' is closed";
            var resourceName = "TestHub";

            var error = new Error
            {
                Condition = AmqpErrorCode.IllegalState,
                Description = description
            };

            Exception exception = AmqpError.CreateExceptionForError(error, resourceName);

            Assert.That(exception, Is.Not.Null, "An exception should have been created");
            Assert.That(exception, Is.TypeOf<EventHubsException>(), "The exception should match");
            Assert.That(((EventHubsException)exception).IsTransient, Is.True, "The exception should be transient.");
            Assert.That(((EventHubsException)exception).Reason, Is.EqualTo(EventHubsException.FailureReason.ClientClosed), "The exception reason should match.");
            Assert.That(exception.Message, Is.SupersetOf(description), "The exception message should contain the description");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.CreateExceptionForError" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateExceptionForErrorWithUnknownCondition()
        {
            var description = "NOT_KNOWN";
            var resourceName = "TestHub";

            var error = new Error
            {
                Condition = new AmqpSymbol("Invalid"),
                Description = description
            };

            Exception exception = AmqpError.CreateExceptionForError(error, resourceName);

            Assert.That(exception, Is.Not.Null, "An exception should have been created");
            Assert.That(exception, Is.TypeOf<EventHubsException>(), "The exception should match");
            Assert.That(exception.Message, Is.SupersetOf(description), "The exception message should contain the description");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.ThrowIfErrorResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(AmqpResponseStatusCode.OK)]
        [TestCase(AmqpResponseStatusCode.Accepted)]
        public void ThrowIfErrorResponseDoesNotThrowOnSuccess(AmqpResponseStatusCode statusCode)
        {
            var description = "This is a test description.";
            var resourceName = "TestHub";

            using var response = AmqpMessage.Create();
            response.ApplicationProperties = new ApplicationProperties();
            response.ApplicationProperties.Map[AmqpResponse.StatusCode] = (int)statusCode;
            response.ApplicationProperties.Map[AmqpResponse.StatusDescription] = description;

            Assert.That(() => AmqpError.ThrowIfErrorResponse(response, resourceName), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpError.ThrowIfErrorResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(AmqpResponseStatusCode.BadRequest)]
        [TestCase(AmqpResponseStatusCode.InternalServerError)]
        [TestCase(AmqpResponseStatusCode.ServiceUnavailable)]
        [TestCase(AmqpResponseStatusCode.Unauthorized)]
        [TestCase(AmqpResponseStatusCode.RequestTimeout)]
        [TestCase(AmqpResponseStatusCode.NotFound)]
        [TestCase(AmqpResponseStatusCode.Forbidden)]
        [TestCase(AmqpResponseStatusCode.Created)]
        [TestCase(AmqpResponseStatusCode.Redirect)]
        public void ThrowIfErrorResponseThrowsOnFailure(AmqpResponseStatusCode statusCode)
        {
            var description = "This is a test description.";
            var resourceName = "TestHub";

            using var response = AmqpMessage.Create();
            response.ApplicationProperties = new ApplicationProperties();
            response.ApplicationProperties.Map[AmqpResponse.StatusCode] = (int)statusCode;
            response.ApplicationProperties.Map[AmqpResponse.StatusDescription] = description;

            Assert.That(() => AmqpError.ThrowIfErrorResponse(response, resourceName), Throws.Exception);
        }

        /// <summary>
        ///   Gets text used to determine that a status description corresponds
        ///   to a "Not Found" case, using the private field value.
        /// </summary>
        ///
        private static string GetNotFoundStatusText() =>
            (string)
                typeof(AmqpError)
                    .GetField("NotFoundStatusText", BindingFlags.Static | BindingFlags.NonPublic)
                    .GetValue(null);

        /// <summary>
        ///   Gets pattern used to determine that a status description corresponds
        ///   to a "Not Found" case, using the private field value.
        /// </summary>
        ///
        private static Regex GetNotFoundExpression() =>
            (Regex)
                typeof(AmqpError)
                    .GetProperty("NotFoundExpression", BindingFlags.Static | BindingFlags.NonPublic)
                    .GetValue(null);
    }
}

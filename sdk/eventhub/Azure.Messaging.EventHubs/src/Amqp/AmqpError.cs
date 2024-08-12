// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The set of well-known error codes associated with an AMQP messages and
    ///   entities.
    /// </summary>
    ///
    internal static class AmqpError
    {
        /// <summary>
        ///   The status text that appears when an AMQP error was due to a missing resource.
        /// </summary>
        ///
        private const string NotFoundStatusText = "status-code: 404";

        /// <summary>
        ///   Indicates that a timeout occurred on the link.
        /// </summary>
        ///
        public static AmqpSymbol TimeoutError { get; } = AmqpConstants.Vendor + ":timeout";

        /// <summary>
        ///   Indicates that an entity was disabled.
        /// </summary>
        ///
        public static AmqpSymbol DisabledError { get; } = AmqpConstants.Vendor + ":entity-disabled";

        /// <summary>
        ///   Indicates that the server was busy and could not allow the requested operation.
        /// </summary>
        ///
        public static AmqpSymbol ServerBusyError { get; } = AmqpConstants.Vendor + ":server-busy";

        /// <summary>
        ///   Indicates that an argument provided to the Event Hubs service was incorrect.
        /// </summary>
        ///
        public static AmqpSymbol ArgumentError { get; } = AmqpConstants.Vendor + ":argument-error";

        /// <summary>
        ///   Indicates that an argument provided to the Event Hubs service was incorrect.
        /// </summary>
        ///
        public static AmqpSymbol ArgumentOutOfRangeError { get; } = AmqpConstants.Vendor + ":argument-out-of-range";

        /// <summary>
        ///   Indicates that a sequence number was out of order.
        /// </summary>
        ///
        public static AmqpSymbol SequenceOutOfOrderError { get; } = AmqpConstants.Vendor + ":out-of-order-sequence";

        /// <summary>
        ///   Indicates that a partition was stolen by another producer with exclusive access.
        /// </summary>
        ///
        public static AmqpSymbol ProducerStolenError { get; } = AmqpConstants.Vendor + ":producer-epoch-stolen";

        /// <summary>
        ///   The expression to test for when the service returns a "Not Found" response to determine the context.
        /// </summary>
        ///
        private static Regex NotFoundExpression { get; } = new Regex("The messaging entity .* could not be found", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        /// <summary>The set of mappings from AMQP error conditions to response status codes.</summary>
        private static readonly IReadOnlyDictionary<AmqpResponseStatusCode, AmqpSymbol> StatusCodeMap = new Dictionary<AmqpResponseStatusCode, AmqpSymbol>()
        {
            { AmqpResponseStatusCode.NotFound, AmqpErrorCode.NotFound },
            { AmqpResponseStatusCode.NotImplemented, AmqpErrorCode.NotImplemented},
            { AmqpResponseStatusCode.Unauthorized, AmqpErrorCode.UnauthorizedAccess },
            { AmqpResponseStatusCode.Forbidden, AmqpErrorCode.ResourceLimitExceeded },
            { AmqpResponseStatusCode.Gone, AmqpErrorCode.Stolen.Value },
            { AmqpResponseStatusCode.InternalServerError, AmqpErrorCode.InternalError },
            { AmqpResponseStatusCode.BadRequest, ArgumentError },
            { AmqpResponseStatusCode.RequestTimeout, TimeoutError },
            { AmqpResponseStatusCode.ServiceUnavailable, ServerBusyError }
        };

        /// <summary>
        ///   Creates the exception that corresponds to a given AMQP response message.
        /// </summary>
        ///
        /// <param name="response">The response to consider.</param>
        /// <param name="eventHubsResource">The Event Hubs resource associated with the request.</param>
        /// <param name="innerException">The exception to embed in the newly created exception.</param>
        ///
        /// <returns>The exception that most accurately represents the response failure.</returns>
        ///
        public static Exception CreateExceptionForResponse(AmqpMessage response,
                                                           string eventHubsResource,
                                                           Exception innerException = default)
        {
            if (response == null)
            {
                return new EventHubsException(eventHubsResource, Resources.UnknownCommunicationException, EventHubsException.FailureReason.ServiceCommunicationProblem);
            }

            if (!response.ApplicationProperties.Map.TryGetValue<string>(AmqpResponse.StatusDescription, out var description))
            {
                description = Resources.UnknownCommunicationException;
            }

            return CreateException(DetermineErrorCondition(response).Value, description, eventHubsResource, innerException);
        }

        /// <summary>
        ///   Creates the exception that corresponds to a given AMQP error.
        /// </summary>
        ///
        /// <param name="error">The AMQP error to consider.</param>
        /// <param name="eventHubsResource">The Event Hubs resource associated with the operation.</param>
        /// <param name="innerException">The exception to embed in the newly created exception.</param>
        ///
        /// <returns>The exception that most accurately represents the error that was encountered.</returns>
        ///
        public static Exception CreateExceptionForError(Error error,
                                                        string eventHubsResource,
                                                        Exception innerException = default)
        {
            if (error == null)
            {
                return new EventHubsException(true, eventHubsResource, Resources.UnknownCommunicationException);
            }

            return CreateException(error.Condition.Value, error.Description, eventHubsResource, innerException);
        }

        /// <summary>
        ///   Determines if a given AMQP message response is an error and, if so, throws the
        ///   appropriate corresponding exception type.
        /// </summary>
        ///
        /// <param name="response">The AMQP response message to consider.</param>
        /// <param name="eventHubName">The name of the Event Hub associated with the request.</param>
        ///
        public static void ThrowIfErrorResponse(AmqpMessage response,
                                                string eventHubName)
        {
            var statusCode = default(int);

            if ((response?.ApplicationProperties?.Map.TryGetValue(AmqpResponse.StatusCode, out statusCode) == false)
                || (!AmqpResponse.IsSuccessStatus((AmqpResponseStatusCode)statusCode)))
            {
                throw CreateExceptionForResponse(response, eventHubName);
            }
        }

        /// <summary>
        ///   Creates the exception that corresponds to a given AMQP failure scenario.
        /// </summary>
        ///
        /// <param name="condition">The error condition that represents the failure scenario.</param>
        /// <param name="description">The descriptive text to use for messaging the scenario.</param>
        /// <param name="eventHubsResource">The Event Hubs resource associated with the failure.</param>
        /// <param name="innerException">The exception to embed in the newly created exception.</param>
        ///
        /// <returns>The exception that most accurately represents the failure scenario.</returns>
        ///
        private static Exception CreateException(string condition,
                                                 string description,
                                                 string eventHubsResource,
                                                 Exception innerException = default)
        {
            // The request timed out.

            if (string.Equals(condition, TimeoutError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new EventHubsException(eventHubsResource, description, EventHubsException.FailureReason.ServiceTimeout, innerException);
            }

            // The Event Hubs resource was disabled.

            if (string.Equals(condition, DisabledError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new EventHubsException(eventHubsResource, description, EventHubsException.FailureReason.ResourceNotFound, innerException);
            }

            // The Event Hubs service was busy; this likely means that requests are being throttled.

            if (string.Equals(condition, ServerBusyError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new EventHubsException(eventHubsResource, description, EventHubsException.FailureReason.ServiceBusy, innerException);
            }

            // An argument was rejected by the Event Hubs service.

            if (string.Equals(condition, ArgumentError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new ArgumentException(IncludeTroubleshootingGuideLink(description), innerException);
            }

            if (string.Equals(condition, ArgumentOutOfRangeError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new ArgumentOutOfRangeException(IncludeTroubleshootingGuideLink(description), innerException);
            }

            // The consumer was superseded by one with a higher owner level.

            if (string.Equals(condition, AmqpErrorCode.Stolen.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new EventHubsException(eventHubsResource, description, EventHubsException.FailureReason.ConsumerDisconnected, innerException);
            }

            // The producer was superseded by one with a higher owner level.

            if (string.Equals(condition, ProducerStolenError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new EventHubsException(eventHubsResource, description, EventHubsException.FailureReason.ProducerDisconnected, innerException);
            }

            // The client-supplied sequence number was not in the expected order.

            if (string.Equals(condition, SequenceOutOfOrderError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new EventHubsException(eventHubsResource, description, EventHubsException.FailureReason.InvalidClientState, innerException);
            }

            // Authorization was denied.

            if (string.Equals(condition, AmqpErrorCode.UnauthorizedAccess.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new UnauthorizedAccessException(IncludeTroubleshootingGuideLink(description), innerException);
            }

            // Requests are being rejected due to exceeding the service quota.

            if (string.Equals(condition, AmqpErrorCode.ResourceLimitExceeded.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new EventHubsException(eventHubsResource, description, EventHubsException.FailureReason.QuotaExceeded, innerException);
            }

            // The link was closed; generally this exception would be thrown for partition specific producers and would be caused by race conditions
            // between an operation and a request to close a client.  It may also occur due to a race condition where the service closes a link or
            // connection while an operation is being prepared.
            //
            // Consider this scenario to be transient so that the operation can be retried if the client itself has not been closed.

            if (string.Equals(condition, AmqpErrorCode.IllegalState.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new EventHubsException(true, eventHubsResource, description, EventHubsException.FailureReason.ClientClosed, innerException);
            }

            // The service does not understand how to process the request.

            if (string.Equals(condition, AmqpErrorCode.NotAllowed.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new InvalidOperationException(IncludeTroubleshootingGuideLink(description), innerException);
            }

            if (string.Equals(condition, AmqpErrorCode.NotImplemented.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new NotSupportedException(IncludeTroubleshootingGuideLink(description), innerException);
            }

            // The Event Hubs resource was not valid or communication with the service was interrupted.

            if (string.Equals(condition, AmqpErrorCode.NotFound.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                if (NotFoundExpression.IsMatch(description)
                    || (description.IndexOf(NotFoundStatusText, StringComparison.InvariantCultureIgnoreCase) >= 0))
                {
                    return new EventHubsException(eventHubsResource, description, EventHubsException.FailureReason.ResourceNotFound, innerException);
                }

                return new EventHubsException(eventHubsResource, description, EventHubsException.FailureReason.ServiceCommunicationProblem, innerException);
            }

            // There was no specific exception that could be determined; fall back to a generic one.

            return new EventHubsException(eventHubsResource, description, EventHubsException.FailureReason.ServiceCommunicationProblem, innerException);
        }

        /// <summary>
        ///   Determines the applicable error condition for a given response message.
        /// </summary>
        ///
        /// <param name="response">The AMQP response message to consider.</param>
        ///
        /// <returns>The AMQP error condition that best represents the response.</returns>
        ///
        private static AmqpSymbol DetermineErrorCondition(AmqpMessage response)
        {
            // If there was an error condition present, use that.

            if (response.ApplicationProperties.Map.TryGetValue(AmqpResponse.ErrorCondition, out AmqpSymbol condition))
            {
                return condition;
            }

            // If no error condition was present, perform a reverse lookup in the mappings to determine the
            // condition from the response status code.

            if ((response.ApplicationProperties.Map.TryGetValue<int>(AmqpResponse.StatusCode, out var statusCode))
                && (StatusCodeMap.TryGetValue((AmqpResponseStatusCode)statusCode, out condition)))
            {
                return condition;
            }

            // If no specific value could be determined, fall back to a generic condition.

            return AmqpErrorCode.InternalError;
        }

        /// <summary>
        ///   Enriches an error message to include the troubleshooting guide link.
        /// </summary>
        ///
        /// <param name="message">The message to enrich.</param>
        ///
        /// <returns>The <paramref name="message" /> with troubleshooting guide link included.</returns>
        ///
        /// <remarks>
        ///  The troubleshooting guide is automatically included in the message for any <see cref="EventHubsException" />
        ///  instances; this method is needed only for other exception types.
        /// </remarks>
        ///
        private static string IncludeTroubleshootingGuideLink(string message) => $"{ message }{ Environment.NewLine }{ Resources.TroubleshootingGuideLink }";
    }
}

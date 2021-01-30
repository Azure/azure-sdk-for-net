// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal static class AmqpExceptionHelper
    {
        private static readonly Dictionary<string, AmqpResponseStatusCode> s_conditionToStatusMap = new Dictionary<string, AmqpResponseStatusCode>
        {
            { AmqpClientConstants.TimeoutError.Value, AmqpResponseStatusCode.RequestTimeout },
            { AmqpErrorCode.NotFound.Value, AmqpResponseStatusCode.NotFound },
            { AmqpErrorCode.NotImplemented.Value, AmqpResponseStatusCode.NotImplemented },
            { AmqpClientConstants.EntityAlreadyExistsError.Value, AmqpResponseStatusCode.Conflict },
            { AmqpClientConstants.MessageLockLostError.Value, AmqpResponseStatusCode.Gone },
            { AmqpClientConstants.SessionLockLostError.Value, AmqpResponseStatusCode.Gone },
            { AmqpErrorCode.ResourceLimitExceeded.Value, AmqpResponseStatusCode.Forbidden },
            { AmqpClientConstants.NoMatchingSubscriptionError.Value, AmqpResponseStatusCode.InternalServerError },
            { AmqpErrorCode.NotAllowed.Value, AmqpResponseStatusCode.BadRequest },
            { AmqpErrorCode.UnauthorizedAccess.Value, AmqpResponseStatusCode.Unauthorized },
            { AmqpErrorCode.MessageSizeExceeded.Value, AmqpResponseStatusCode.Forbidden },
            { AmqpClientConstants.ServerBusyError.Value, AmqpResponseStatusCode.ServiceUnavailable },
            { AmqpClientConstants.ArgumentError.Value, AmqpResponseStatusCode.BadRequest },
            { AmqpClientConstants.ArgumentOutOfRangeError.Value, AmqpResponseStatusCode.BadRequest },
            { AmqpClientConstants.StoreLockLostError.Value, AmqpResponseStatusCode.Gone },
            { AmqpClientConstants.SessionCannotBeLockedError.Value, AmqpResponseStatusCode.Gone },
            { AmqpClientConstants.PartitionNotOwnedError.Value, AmqpResponseStatusCode.Gone },
            { AmqpClientConstants.EntityDisabledError.Value, AmqpResponseStatusCode.BadRequest },
            { AmqpClientConstants.PublisherRevokedError.Value, AmqpResponseStatusCode.Unauthorized },
            { AmqpClientConstants.AuthorizationFailedError.Value, AmqpResponseStatusCode.Unauthorized},
            { AmqpErrorCode.Stolen.Value, AmqpResponseStatusCode.Gone }
        };

        public static AmqpSymbol GetResponseErrorCondition(AmqpMessage response, AmqpResponseStatusCode statusCode)
        {
            object condition = response.ApplicationProperties.Map[ManagementConstants.Response.ErrorCondition];
            if (condition != null)
            {
                return (AmqpSymbol)condition;
            }

            // Most of the time we should have an error condition
            foreach (var kvp in s_conditionToStatusMap)
            {
                if (kvp.Value == statusCode)
                {
                    return kvp.Key;
                }
            }

            return AmqpErrorCode.InternalError;
        }

        public static AmqpResponseStatusCode GetResponseStatusCode(this AmqpMessage responseMessage)
        {
            var amqpResponseStatusCode = AmqpResponseStatusCode.Unused;
            object statusCodeValue = responseMessage?.ApplicationProperties.Map[ManagementConstants.Response.StatusCode];
            if (statusCodeValue is int && Enum.IsDefined(typeof(AmqpResponseStatusCode), statusCodeValue))
            {
                amqpResponseStatusCode = (AmqpResponseStatusCode)statusCodeValue;
            }

            return amqpResponseStatusCode;
        }

        public static Exception ToMessagingContractException(this AmqpMessage responseMessage, AmqpResponseStatusCode statusCode)
        {
            AmqpSymbol errorCondition = GetResponseErrorCondition(responseMessage, statusCode);
            var statusDescription = responseMessage.ApplicationProperties.Map[ManagementConstants.Response.StatusDescription] as string ?? errorCondition.Value;
            return ToMessagingContractException(errorCondition.Value, statusDescription);
        }

        public static Exception ToMessagingContractException(this Error error, bool connectionError = false)
        {
            if (error == null)
            {
                return new ServiceBusException(true, "Unknown error.");
            }

            return ToMessagingContractException(error.Condition.Value, error.Description, connectionError);
        }

        public static Exception ToMessagingContractException(string condition, string message, bool connectionError = false)
        {
            if (string.Equals(condition, AmqpClientConstants.TimeoutError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new ServiceBusException(message, ServiceBusFailureReason.ServiceTimeout);
            }

            if (string.Equals(condition, AmqpErrorCode.NotFound.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                if (connectionError)
                {
                    return new ServiceBusException(message, ServiceBusFailureReason.ServiceCommunicationProblem);
                }

                return new ServiceBusException(message, ServiceBusFailureReason.MessagingEntityNotFound);
            }

            if (string.Equals(condition, AmqpErrorCode.NotImplemented.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new NotSupportedException(message);
            }

            if (string.Equals(condition, AmqpErrorCode.NotAllowed.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new InvalidOperationException(message);
            }

            if (string.Equals(condition, AmqpErrorCode.UnauthorizedAccess.Value, StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals(condition, AmqpClientConstants.AuthorizationFailedError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new UnauthorizedAccessException(message);
            }

            if (string.Equals(condition, AmqpClientConstants.ServerBusyError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new ServiceBusException(message, ServiceBusFailureReason.ServiceBusy);
            }

            if (string.Equals(condition, AmqpClientConstants.ArgumentError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new ArgumentException(message);
            }

            if (string.Equals(condition, AmqpClientConstants.ArgumentOutOfRangeError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new ArgumentOutOfRangeException(message);
            }

            if (string.Equals(condition, AmqpClientConstants.EntityDisabledError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new ServiceBusException(message, ServiceBusFailureReason.MessagingEntityDisabled);
            }

            if (string.Equals(condition, AmqpClientConstants.MessageLockLostError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new ServiceBusException(message, ServiceBusFailureReason.MessageLockLost);
            }

            if (string.Equals(condition, AmqpClientConstants.EntityAlreadyExistsError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new ServiceBusException(message, ServiceBusFailureReason.MessagingEntityAlreadyExists);
            }

            if (string.Equals(condition, AmqpClientConstants.SessionLockLostError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new ServiceBusException(message, ServiceBusFailureReason.SessionLockLost);
            }

            if (string.Equals(condition, AmqpErrorCode.ResourceLimitExceeded.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new ServiceBusException(message, ServiceBusFailureReason.QuotaExceeded);
            }

            if (string.Equals(condition, AmqpErrorCode.MessageSizeExceeded.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new ServiceBusException(message, ServiceBusFailureReason.MessageSizeExceeded);
            }

            if (string.Equals(condition, AmqpClientConstants.MessageNotFoundError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new ServiceBusException(message, ServiceBusFailureReason.MessageNotFound);
            }

            if (string.Equals(condition, AmqpClientConstants.SessionCannotBeLockedError.Value, StringComparison.InvariantCultureIgnoreCase))
            {
                return new ServiceBusException(message, ServiceBusFailureReason.SessionCannotBeLocked);
            }

            return new ServiceBusException(true, message);
        }

        public static Exception TranslateException(Exception exception, string referenceId = null, Exception innerException = null, bool connectionError = false)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat(CultureInfo.InvariantCulture, exception.Message);
            if (referenceId != null)
            {
                stringBuilder.AppendFormat(CultureInfo.InvariantCulture, $"Reference: {referenceId}, {DateTime.UtcNow}");
            }

            var message = stringBuilder.ToString();
            var aggregateException = innerException == null ? exception : new AggregateException(exception, innerException);

            switch (exception)
            {
                case SocketException _:
                    message = stringBuilder.AppendFormat(CultureInfo.InvariantCulture, $" ErrorCode: {((SocketException)exception).SocketErrorCode}").ToString();
                    return new ServiceBusException(message, ServiceBusFailureReason.ServiceCommunicationProblem, innerException: aggregateException);

                case IOException _:
                    if (exception.InnerException is SocketException socketException)
                    {
                        message = stringBuilder.AppendFormat(CultureInfo.InvariantCulture, $" ErrorCode: {socketException.SocketErrorCode}").ToString();
                    }
                    return new ServiceBusException(message, ServiceBusFailureReason.ServiceCommunicationProblem, innerException: aggregateException);

                case AmqpException amqpException:
                    return amqpException.Error.ToMessagingContractException(connectionError);

                case OperationCanceledException operationCanceledException when operationCanceledException.InnerException is AmqpException amqpException:
                    return amqpException.Error.ToMessagingContractException(connectionError);

                case OperationCanceledException _ when connectionError:
                    return new ServiceBusException(message, ServiceBusFailureReason.ServiceCommunicationProblem, innerException: aggregateException);

                case OperationCanceledException operationCanceledException when
                operationCanceledException.InnerException != null:
                    return operationCanceledException.InnerException;

                case OperationCanceledException operationEx when !(operationEx is TaskCanceledException):
                    return new ServiceBusException(operationEx.Message, ServiceBusFailureReason.ServiceTimeout);

                case TimeoutException _:
                    return new ServiceBusException(
                        message,
                        ServiceBusFailureReason.ServiceTimeout,
                        innerException: aggregateException);

                case InvalidOperationException _ when connectionError:
                    return new ServiceBusException(message, ServiceBusFailureReason.ServiceCommunicationProblem, innerException: aggregateException);
            }

            if (connectionError)
            {
                return new ServiceBusException(message, ServiceBusFailureReason.ServiceCommunicationProblem, innerException: aggregateException);
            }

            return aggregateException;
        }

        public static string GetTrackingId(this AmqpLink link)
        {
            if (link.Settings.Properties != null &&
                link.Settings.Properties.TryGetValue<string>(
                    AmqpClientConstants.TrackingIdName,
                    out var trackingContext))
            {
                return trackingContext;
            }

            return null;
        }

        public static Exception GetInnerException(this AmqpObject amqpObject)
        {
            var connectionError = false;
            Exception innerException;
            switch (amqpObject)
            {
                case AmqpSession amqpSession:
                    innerException = amqpSession.TerminalException ?? amqpSession.Connection.TerminalException;
                    break;

                case AmqpLink amqpLink:
                    connectionError = amqpLink.Session.IsClosing();
                    innerException = amqpLink.TerminalException ?? amqpLink.Session.TerminalException ?? amqpLink.Session.Connection.TerminalException;
                    break;

                case RequestResponseAmqpLink amqpReqRespLink:
                    innerException = amqpReqRespLink.TerminalException ?? amqpReqRespLink.Session.TerminalException ?? amqpReqRespLink.Session.Connection.TerminalException;
                    break;

                default:
                    return null;
            }

            return innerException == null ? null : TranslateException(innerException, null, null, connectionError);
        }
    }
}

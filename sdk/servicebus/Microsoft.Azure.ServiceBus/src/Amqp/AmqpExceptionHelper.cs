// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Net.Sockets;
    using System.Text;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Encoding;
    using Microsoft.Azure.Amqp.Framing;

    static class AmqpExceptionHelper
    {
        static readonly Dictionary<string, AmqpResponseStatusCode> ConditionToStatusMap = new Dictionary<string, AmqpResponseStatusCode>
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
            foreach (var kvp in ConditionToStatusMap)
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
            AmqpSymbol errorCondition = AmqpExceptionHelper.GetResponseErrorCondition(responseMessage, statusCode);
            var statusDescription = responseMessage.ApplicationProperties.Map[ManagementConstants.Response.StatusDescription] as string ?? errorCondition.Value;
            return AmqpExceptionHelper.ToMessagingContractException(errorCondition.Value, statusDescription);
        }

        public static Exception ToMessagingContractException(this Error error, bool connectionError = false)
        {
            if (error == null)
            {
                return new ServiceBusException(true, "Unknown error.");
            }

            return ToMessagingContractException(error.Condition.Value, error.Description, connectionError);
        }

        static Exception ToMessagingContractException(string condition, string message, bool connectionError = false)
        {
            if (string.Equals(condition, AmqpClientConstants.TimeoutError.Value))
            {
                return new ServiceBusTimeoutException(message);
            }

            if (string.Equals(condition, AmqpErrorCode.NotFound.Value))
            {
                if (connectionError)
                {
                    return new ServiceBusCommunicationException(message, null);
                }

                return new MessagingEntityNotFoundException(message, null);
            }

            if (string.Equals(condition, AmqpErrorCode.NotImplemented.Value))
            {
                return new NotSupportedException(message);
            }

            if (string.Equals(condition, AmqpErrorCode.NotAllowed.Value))
            {
                return new InvalidOperationException(message);
            }

            if (string.Equals(condition, AmqpErrorCode.UnauthorizedAccess.Value) ||
                string.Equals(condition, AmqpClientConstants.AuthorizationFailedError.Value))
            {
                return new UnauthorizedException(message);
            }

            if (string.Equals(condition, AmqpClientConstants.ServerBusyError.Value))
            {
                return new ServerBusyException(message);
            }

            if (string.Equals(condition, AmqpClientConstants.ArgumentError.Value))
            {
                return new ArgumentException(message);
            }

            if (string.Equals(condition, AmqpClientConstants.ArgumentOutOfRangeError.Value))
            {
                return new ArgumentOutOfRangeException(message);
            }

            if (string.Equals(condition, AmqpClientConstants.EntityDisabledError.Value))
            {
                return new MessagingEntityDisabledException(message, null);
            }

            if (string.Equals(condition, AmqpClientConstants.MessageLockLostError.Value))
            {
                return new MessageLockLostException(message);
            }

            if (string.Equals(condition, AmqpClientConstants.SessionLockLostError.Value))
            {
                return new SessionLockLostException(message);
            }

            if (string.Equals(condition, AmqpErrorCode.ResourceLimitExceeded.Value))
            {
                return new QuotaExceededException(message);
            }

            if (string.Equals(condition, AmqpErrorCode.MessageSizeExceeded.Value))
            {
                return new MessageSizeExceededException(message);
            }

            if (string.Equals(condition, AmqpClientConstants.MessageNotFoundError.Value))
            {
                return new MessageNotFoundException(message);
            }

            if (string.Equals(condition, AmqpClientConstants.SessionCannotBeLockedError.Value))
            {
                return new SessionCannotBeLockedException(message);
            }

            return new ServiceBusException(true, message);
        }

        public static Exception GetClientException(Exception exception, string referenceId = null, Exception innerException = null, bool connectionError = false)
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
                    return new ServiceBusCommunicationException(message, aggregateException);

                case IOException _:
                    if (exception.InnerException is SocketException socketException)
                    {
                        message = stringBuilder.AppendFormat(CultureInfo.InvariantCulture, $" ErrorCode: {socketException.SocketErrorCode}").ToString();
                    }
                    return new ServiceBusCommunicationException(message, aggregateException);

                case AmqpException amqpException:
                    return amqpException.Error.ToMessagingContractException(connectionError);

                case OperationCanceledException operationCanceledException when operationCanceledException.InnerException is AmqpException amqpException:
                    return amqpException.Error.ToMessagingContractException(connectionError);

                case OperationCanceledException _ when connectionError:
                    return new ServiceBusCommunicationException(message, aggregateException);

                case OperationCanceledException _:
                    return new ServiceBusException(true, message, aggregateException);

                case TimeoutException _:
                    return new ServiceBusTimeoutException(message, aggregateException);

                case InvalidOperationException ex when ex.Message.IndexOf("connection is closing", StringComparison.OrdinalIgnoreCase) != -1:
                    return new ServiceBusException(true, aggregateException);

                case InvalidOperationException _ when connectionError:
                    return new ServiceBusCommunicationException(message, aggregateException);
            }

            if (connectionError)
            {
                return new ServiceBusCommunicationException(message, aggregateException);
            }

            return aggregateException;
        }

        public static string GetTrackingId(this AmqpLink link)
        {
            if (link.Settings.Properties != null &&
                link.Settings.Properties.TryGetValue<string>(AmqpClientConstants.TrackingIdName, out var trackingContext))
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

            return innerException == null ? null : GetClientException(innerException, null, null, connectionError);
        }
    }
}
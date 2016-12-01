// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Encoding;
    using Microsoft.Azure.Amqp.Framing;

    class AmqpExceptionHelper
    {
        static readonly Dictionary<string, AmqpResponseStatusCode> ConditionToStatusMap = new Dictionary<string, AmqpResponseStatusCode>()
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
            { AmqpErrorCode.Stolen.Value, AmqpResponseStatusCode.Gone }
        };

        public static AmqpSymbol GetResponseErrorCondition(AmqpMessage response, AmqpResponseStatusCode statusCode)
        {
            object condition = response.ApplicationProperties.Map[AmqpClientConstants.ResponseErrorCondition];
            if (condition != null)
            {
                return (AmqpSymbol)condition;
            }
            else
            {
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
        }

        public static Exception ToMessagingContract(Error error, bool connectionError = false)
        {
            if (error == null)
            {
                return new ServiceBusException(true, "Unknown error.");
            }

            return ToMessagingContract(error.Condition.Value, error.Description, connectionError);
        }

        public static Exception ToMessagingContract(string condition, string message, bool connectionError = false)
        {
            if (string.Equals(condition, AmqpClientConstants.TimeoutError.Value))
            {
                return new TimeoutException(message);
            }
            else if (string.Equals(condition, AmqpErrorCode.NotFound.Value))
            {
                if (connectionError)
                {
                    return new ServiceBusCommunicationException(message, null);
                }
                else
                {
                    return new MessagingEntityNotFoundException(message, null);
                }
            }
            else if (string.Equals(condition, AmqpErrorCode.NotImplemented.Value))
            {
                return new NotSupportedException(message);
            }
            else if (string.Equals(condition, AmqpErrorCode.NotAllowed.Value))
            {
                return new InvalidOperationException(message);
            }
            else if (string.Equals(condition, AmqpErrorCode.UnauthorizedAccess.Value))
            {
                return new UnauthorizedAccessException(message);
            }
            else if (string.Equals(condition, AmqpClientConstants.ServerBusyError.Value))
            {
                return new ServerBusyException(message);
            }
            else if (string.Equals(condition, AmqpClientConstants.ArgumentError.Value))
            {
                return new ArgumentException(message);
            }
            else if (string.Equals(condition, AmqpClientConstants.ArgumentOutOfRangeError.Value))
            {
                return new ArgumentOutOfRangeException(message);
            }
            else if (string.Equals(condition, AmqpClientConstants.EntityDisabledError.Value))
            {
                return new MessagingEntityDisabledException(message, null);
            }
            else if (string.Equals(condition, AmqpClientConstants.MessageLockLostError.Value))
            {
                return new MessageLockLostException(message);
            }
            else if (string.Equals(condition, AmqpClientConstants.SessionLockLostError.Value))
            {
                return new SessionLockLostException(message);
            }
            else if (string.Equals(condition, AmqpErrorCode.ResourceLimitExceeded.Value))
            {
                return new QuotaExceededException(message);
            }
            else
            {
                return new ServiceBusException(true, message);
            }
        }
    }
}

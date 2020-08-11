// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.EventHubs.Amqp
{
    /// <summary>
    ///   The set of extension methods for the <see cref="Exception" /> class.
    /// </summary>
    ///
    internal static class ExceptionExtensions
    {
        /// <summary>
        ///   Considers an exception surfaced during an AMQP-based service operation, unwrapping
        ///   and translating it into the form that should be considered for error handling
        ///   decisions.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="eventHubName">The name of the Event Hub that the service operation was targeting.</param>
        ///
        /// <returns>The <see cref="Exception" /> that corresponds to the <paramref name="instance" /> and which represents the service error.</returns>
        ///
        public static Exception TranslateServiceException(this Exception instance,
                                                          string eventHubName)
        {
            Argument.AssertNotNull(instance, nameof(instance));

            switch (instance)
            {
                case AmqpException amqpEx:
                    return AmqpError.CreateExceptionForError(amqpEx.Error, eventHubName);

                case OperationCanceledException operationEx when (operationEx.InnerException is AmqpException):
                    return AmqpError.CreateExceptionForError(((AmqpException)operationEx.InnerException).Error, eventHubName);

                case OperationCanceledException operationEx when (operationEx.InnerException != null):
                    return operationEx.InnerException;

                case OperationCanceledException operationEx when (!(operationEx is TaskCanceledException)):
                    return new EventHubsException(eventHubName, operationEx.Message, EventHubsException.FailureReason.ServiceTimeout);

                default:
                    return instance;
            }
        }

        /// <summary>
        ///   Considers an exception surfaced during the creation of an AMQP link, determining if the cause was a race condition
        ///   with the connection closing and translating it into the form that should be considered for error handling decisions.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="eventHubName">The name of the Event Hub that the service operation was targeting.</param>
        ///
        /// <returns>The <see cref="Exception" /> that corresponds to the <paramref name="instance" /> and which represents the service error.</returns>
        ///
        public static Exception TranslateConnectionCloseDuringLinkCreationException(this Exception instance,
                                                                                    string eventHubName)
        {
            Argument.AssertNotNull(instance, nameof(instance));

            switch (instance)
            {
                case InvalidOperationException _ when (instance.Message.IndexOf("when the connection is closing", StringComparison.InvariantCultureIgnoreCase) >= 0):
                case TaskCanceledException _:
                    return new EventHubsException(true, eventHubName, Resources.CouldNotCreateLink, EventHubsException.FailureReason.ServiceCommunicationProblem, instance);

                case ObjectDisposedException _:
                    return new EventHubsException(false, eventHubName, Resources.CouldNotCreateLink, EventHubsException.FailureReason.ClientClosed, instance);

                default:
                    return instance;
            }
        }
    }
}

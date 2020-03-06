// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus.Amqp
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
        /// <param name="entityName">The name of the Service Bus entity that the service operation was targeting.</param>
        ///
        /// <returns>The <see cref="Exception" /> that corresponds to the <paramref name="instance" /> and which represents the service error.</returns>
        ///
        public static Exception TranslateServiceException(
            this Exception instance,
            string entityName)
        {
            Argument.AssertNotNull(instance, nameof(instance));

            switch (instance)
            {
                case AmqpException amqpEx:
                    return AmqpError.CreateExceptionForError(amqpEx.Error, entityName);

                case OperationCanceledException operationEx when (operationEx.InnerException is AmqpException):
                    return AmqpError.CreateExceptionForError(((AmqpException)operationEx.InnerException).Error, entityName);

                case OperationCanceledException operationEx when (operationEx.InnerException != null):
                    return operationEx.InnerException;

                case OperationCanceledException operationEx when (!(operationEx is TaskCanceledException)):
                    return new ServiceBusException(operationEx.Message, ServiceBusException.FailureReason.ServiceTimeout, entityName);

                default:
                    return instance;
            }
        }
    }
}

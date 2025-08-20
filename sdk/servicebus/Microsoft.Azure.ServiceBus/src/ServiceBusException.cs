// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using Primitives;

    /// <summary>
    /// Base Exception for various Service Bus errors.
    /// </summary>
    public class ServiceBusException : Exception
    {
        /// <summary>
        /// Returns a new ServiceBusException
        /// </summary>
        /// <param name="isTransient">Specifies whether or not the exception is transient.</param>
        public ServiceBusException(bool isTransient)
        {
            this.IsTransient = isTransient;
        }

        /// <summary>
        /// Returns a new ServiceBusException
        /// </summary>
        /// <param name="isTransient">Specifies whether or not the exception is transient.</param>
        /// <param name="message">The detailed message exception.</param>
        public ServiceBusException(bool isTransient, string message)
            : base(message)
        {
            this.IsTransient = isTransient;
        }

        /// <summary>
        /// Returns a new ServiceBusException
        /// </summary>
        /// <param name="isTransient">Specifies whether or not the exception is transient.</param>
        public ServiceBusException(bool isTransient, Exception innerException)
            : base(innerException.Message, innerException)
        {
            this.IsTransient = isTransient;
        }

        /// <summary>
        /// Returns a new ServiceBusException
        /// </summary>
        /// <param name="isTransient">Specifies whether or not the exception is transient.</param>
        /// <param name="message">The detailed message exception.</param>
        public ServiceBusException(bool isTransient, string message, Exception innerException)
            : base(message, innerException)
        {
            this.IsTransient = isTransient;
        }

        /// <summary>
        /// Gets the message as a formatted string.
        /// </summary>
        public override string Message
        {
            get
            {
                var baseMessage = base.Message;
                if (string.IsNullOrEmpty(this.ServiceBusNamespace))
                {
                    return baseMessage;
                }

                return "{0}, ({1})".FormatInvariant(baseMessage, this.ServiceBusNamespace);
            }
        }

        /// <summary>
        /// A boolean indicating if the exception is a transient error or not.
        /// </summary>
        /// <value>returns true when user can retry the operation that generated the exception without additional intervention.</value>
        public bool IsTransient { get; }

        /// <summary>
        /// Gets the Service Bus namespace from which the exception occurred, if available.
        /// </summary>
        public string ServiceBusNamespace { get; internal set; }
    }
}
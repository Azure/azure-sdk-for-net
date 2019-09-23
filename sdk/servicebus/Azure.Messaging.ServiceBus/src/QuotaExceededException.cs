// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    using System;

    /// <summary>
    /// The exception that is thrown when the Quota (Entity Max Size or other Connection etc) allocated to the Entity has exceeded.  Callers should check the
    /// error message to see which of the Quota exceeded and take appropriate action.
    /// </summary>
    public sealed class QuotaExceededException : ServiceBusException
    {
        public QuotaExceededException(string message)
            : this(message, null)
        {
        }

        public QuotaExceededException(string message, Exception innerException)
            : base(false, message, innerException)
        {
        }
    }
}
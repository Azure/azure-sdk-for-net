// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;

    /// <summary>
    /// The exception that is thrown when the Quota (Entity Max Size or other Connection etc) allocated to the Entity has exceeded.  Callers should check the
    /// error message to see which of the Quota exceeded and take appropriate action.
    /// </summary>
    public sealed class QuotaExceededException : ServiceBusException
    {
        internal QuotaExceededException(string message)
            : this(message, null)
        {
        }

        internal QuotaExceededException(string message, Exception innerException)
            : base(false, message, innerException)
        {
        }
    }
}
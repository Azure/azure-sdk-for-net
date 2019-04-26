// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;

    /// <summary>
    /// Provides an Event Hubs quota exceeded exception.
    /// </summary>
    public class QuotaExceededException : EventHubsException
    {
        /// <summary></summary>
        /// <param name="message"></param>
        public QuotaExceededException(string message)
            : base(false, message)
        {
        }

        /// <summary></summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public QuotaExceededException(string message, Exception innerException)
            : base(false, message, innerException)
        {
        }
    }
}

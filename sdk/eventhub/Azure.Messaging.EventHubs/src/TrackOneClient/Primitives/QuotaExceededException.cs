// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace TrackOne
{
    /// <summary>
    /// Provides an Event Hubs quota exceeded exception.
    /// </summary>
    internal class QuotaExceededException : EventHubsException
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

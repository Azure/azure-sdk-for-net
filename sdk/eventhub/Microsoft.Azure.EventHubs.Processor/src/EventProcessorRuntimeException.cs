// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    using System;

    /// <summary>
    /// An exception thrown during event processing.
    /// </summary>
    public class EventProcessorRuntimeException : EventHubsException
    {
        internal EventProcessorRuntimeException(string message, string action)
            : this(message, action, null)
        {
        }

        internal EventProcessorRuntimeException(string message, string action, Exception innerException)
            : base(true, message, innerException)
        {
            this.Action = action;
        }

        /// <summary>
        /// Gets the action that was being performed when the exception occured.
        /// </summary>
        public string Action { get; }
    }
}
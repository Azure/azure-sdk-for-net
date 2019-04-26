// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    using System;

    /// <summary>
    /// An exception which specifies that the <see cref="EventProcessorHost"/> configuration is incorrect.
    /// </summary>
    public class EventProcessorConfigurationException : EventHubsException
    {
        internal EventProcessorConfigurationException(string message)
            : this(message, null)
        {
        }

        internal EventProcessorConfigurationException(string message, Exception innerException)
            : base(false, message, innerException)
        {
        }
    }
}
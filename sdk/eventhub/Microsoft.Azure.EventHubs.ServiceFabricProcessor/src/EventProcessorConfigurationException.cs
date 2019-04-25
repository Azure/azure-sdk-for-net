// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.using System;

namespace Microsoft.Azure.EventHubs.ServiceFabricProcessor
{
    using System;

    /// <summary>
    /// Exception thrown when the configuration of the service has a problem.
    /// </summary>
    public class EventProcessorConfigurationException : Exception
    {
        /// <summary>
        /// Construct the exception.
        /// </summary>
        /// <param name="message"></param>
        public EventProcessorConfigurationException(string message) : base(message)
        {
        }
    }
}

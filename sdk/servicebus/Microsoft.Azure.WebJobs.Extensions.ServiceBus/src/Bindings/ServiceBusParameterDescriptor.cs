// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class ServiceBusParameterDescriptor : ParameterDescriptor
    {
        /// <summary>Gets or sets the name of the queue or topic.</summary>
        public string QueueOrTopicName { get; set; }
    }
}

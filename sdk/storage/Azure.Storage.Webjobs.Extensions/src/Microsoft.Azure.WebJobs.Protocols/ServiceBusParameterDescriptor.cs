// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>
    /// Represents a parameter bound to an Azure Service Bus entity.
    /// </summary>
    [JsonTypeName("ServiceBus")]
#if PUBLICPROTOCOL
    public class ServiceBusParameterDescriptor : ParameterDescriptor
#else
    internal class ServiceBusParameterDescriptor : ParameterDescriptor
#endif
    {
        /// <summary>Gets or sets the name of the Service Bus namespace.</summary>
        public string NamespaceName { get; set; }

        /// <summary>Gets or sets the name of the queue or topic.</summary>
        public string QueueOrTopicName { get; set; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Management
{
    /// <summary>
    /// Specifies the type of entities the namespace can contain.
    /// </summary>
    public enum NamespaceType
    {
        /// <summary>
        /// Namespace contains service bus entities (queues, topics)
        /// </summary>
        ServiceBus = 0,

        /// <summary>
        /// Supported only for backward compatibility.
        /// Namespace can contain mixture of messaging entities and notification hubs.
        /// </summary>
        Mixed = 2,

        /// <summary>
        /// Other type of resource.
        /// </summary>
        Others = 99,
    }
}

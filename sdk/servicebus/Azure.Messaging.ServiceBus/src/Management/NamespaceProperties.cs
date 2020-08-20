// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Management
{
    /// <summary>
    /// Represents the properties related to a Service Bus namespace.
    /// </summary>
    public class NamespaceProperties
    {
        /// <summary>
        /// Name of the namespace.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Type of entities present in the namespace.
        /// </summary>
        internal NamespaceType NamespaceType { get; set; }

        /// <summary>
        /// The time at which the namespace was created.
        /// </summary>
        public DateTimeOffset CreatedTime { get; internal set; }

        /// <summary>
        /// The last time at which the namespace was modified.
        /// </summary>
        public DateTimeOffset ModifiedTime { get; internal set; }

        /// <summary>
        /// The SKU/tier of the namespace. Valid only for <see cref="NamespaceType.Messaging"/>
        /// </summary>
        public MessagingSku MessagingSku { get; internal set; }

        /// <summary>
        /// The number of messaging units allocated for namespace.
        /// Valid only for <see cref="NamespaceType.Messaging"/> and <see cref="MessagingSku.Premium"/>
        /// </summary>
        public int MessagingUnits { get; internal set; }

        /// <summary>
        /// The alias for the namespace.
        /// </summary>
        public string Alias { get; internal set; }
    }
}

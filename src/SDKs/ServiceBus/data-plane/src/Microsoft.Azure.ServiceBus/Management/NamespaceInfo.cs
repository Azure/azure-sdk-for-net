// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
{
    using System;

    /// <summary>
    /// Represents the metadata related to a service bus namespace.
    /// </summary>
    public class NamespaceInfo
    {
        /// <summary>
        /// Name of the namespace.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of entities present in the namespace.
        /// </summary>
        public NamespaceType NamespaceType { get; set; }

        /// <summary>
        /// The time at which the namespace was created.
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// The last time at which the namespace was modified.
        /// </summary>
        public DateTime ModifiedTime { get; set; }

        /// <summary>
        /// The SKU/tier of the namespace. Valid only for <see cref="NamespaceType.ServiceBus"/>
        /// </summary>
        public MessagingSku MessagingSku { get; set; }

        /// <summary>
        /// Number of messaging units allocated for namespace. 
        /// Valid only for <see cref="NamespaceType.ServiceBus"/> and <see cref="MessagingSku.Premium"/>
        /// </summary>
        public int MessagingUnits { get; set; }

        /// <summary>
        /// Alias for the namespace.
        /// </summary>
        public string Alias { get; set; }
    }
}

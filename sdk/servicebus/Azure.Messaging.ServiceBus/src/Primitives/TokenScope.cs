// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Primitives
{
    /// <summary>
    /// A enum representing the scope of the <see cref="SecurityToken"/>.
    /// </summary>
    public enum TokenScope
    {
        /// <summary>
        /// The namespace.
        /// </summary>
        Namespace = 0,

        /// <summary>
        /// The entity.
        /// </summary>
        Entity = 1
    }
}

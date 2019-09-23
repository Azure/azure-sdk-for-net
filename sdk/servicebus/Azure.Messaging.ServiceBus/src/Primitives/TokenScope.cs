// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.ServiceBus.Primitives
{
    /// <summary>
    /// A enum representing the scope of the <see cref="TokenCredential"/>.
    /// </summary>
    internal enum TokenScope
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
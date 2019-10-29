// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
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

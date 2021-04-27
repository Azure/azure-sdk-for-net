// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Administration
{
    /// <summary>
    /// The access rights that may be conferred by an authorization rule.
    /// </summary>
#pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    public enum AccessRights
#pragma warning restore CA1717 // Only FlagsAttribute enums should have plural names
    {
        /// <summary>
        /// The access right is Manage.
        /// </summary>
        Manage = 0,

        /// <summary>
        /// The access right is Send.
        /// </summary>
        Send = 1,

        /// <summary>
        /// The access right is Listen.
        /// </summary>
        Listen = 2
    }
}

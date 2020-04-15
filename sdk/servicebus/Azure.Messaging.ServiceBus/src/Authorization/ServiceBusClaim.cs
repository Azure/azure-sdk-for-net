// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Authorization
{
    /// <summary>
    ///   The set of claims for operations associated with the Service Bus service.
    /// </summary>
    ///
    internal static class ServiceBusClaim
    {
        /// <summary>Needed for management operations, such as querying metadata, against the service.</summary>
        public const string Manage = "Manage";

        /// <summary>Needed for sending messages to the service.</summary>
        public const string Send = "Send";

        /// <summary>Needed for receiving messages from the service. </summary>
        public const string Listen = "Listen";
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Authorization
{
    /// <summary>
    ///   The set of claims for operations associated with the Event Hubs service.
    /// </summary>
    ///
    internal static class EventHubsClaim
    {
        /// <summary>Needed for management operations, such as querying metadata, against the service.</summary>
        public const string Manage = "Manage";

        /// <summary>Needed for sending data, such as publishing events, to the service.</summary>
        public const string Send = "Send";

        /// <summary>Needed for receiving data, such as events, from the service. </summary>
        public const string Listen = "Listen";
    }
}

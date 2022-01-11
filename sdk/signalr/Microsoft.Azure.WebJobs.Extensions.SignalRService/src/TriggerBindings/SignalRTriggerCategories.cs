﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// A class contains constant strings that represent SignalR trigger category.
    /// </summary>
    public static class SignalRTriggerCategories
    {
        /// <summary>
        /// Triggered by SignalR client connection connected or disconnected events.
        /// </summary>
        public const string Connections = "connections";
        /// <summary>
        /// Triggered by a message sent by a SignalR client.
        /// </summary>
        public const string Messages = "messages";
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// A class contains constant strings that represents different trigger event type.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "AZC0012:Avoid single word type names", Justification = "Breaking change")]
    public static class Event
    {
        /// <summary>
        /// Represents an event that a SignalR client is connected to Azure SignalR Service.
        /// </summary>
        public const string Connected = "connected";
        /// <summary>
        /// Represents an event that a SignalR client is disconnected from Azure SignalR Service.
        /// </summary>
        public const string Disconnected = "disconnected";
    }
}
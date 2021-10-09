// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "AZC0012:Avoid single word type names", Justification = "Breaking change")]
    public static class Event
    {
        public const string Connected = "connected";
        public const string Disconnected = "disconnected";
    }
}
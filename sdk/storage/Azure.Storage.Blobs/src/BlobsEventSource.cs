// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Writes diagnostic events for the Azure.Storage.Blobs client library.
    /// Events can be captured with <see cref="AzureEventSourceListener"/>.
    /// </summary>
    internal class BlobsEventSource : AzureEventSource
    {
        private const string EventSourceName = "Azure-Storage-Blobs";

        private const int SessionAuthenticationDisabledEvent = 1;
        private const int SessionAuthenticationCannotBeEnabledEvent = 2;

        private BlobsEventSource() : base(EventSourceName) { }

        public static BlobsEventSource Singleton { get; } = new BlobsEventSource();

        [Event(
            SessionAuthenticationDisabledEvent,
            Level = EventLevel.Warning,
            Message = "Session authentication disabled: the account name could not be determined from the URL: {0}. Falling back to bearer token authentication. Set BlobClientOptions.SessionOptions.AccountName to use Sessions.")]
        public void SessionAuthenticationDisabledAccountNameUnavailable(string endpoint)
        {
            WriteEvent(SessionAuthenticationDisabledEvent, endpoint);
        }

        [Event(
            SessionAuthenticationCannotBeEnabledEvent,
            Level = EventLevel.Warning,
            Message = "Session authentication cannot be enabled: the account name could not be determined from the URL: {0}. Set BlobClientOptions.SessionOptions.AccountName to use Sessions.")]
        public void SessionAuthenticationCannotBeEnabledAccountNameUnavailable(string endpoint)
        {
            WriteEvent(SessionAuthenticationCannotBeEnabledEvent, endpoint);
        }
    }
}

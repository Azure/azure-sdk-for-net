// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Text;
using Azure.Core;
using Azure.Core.Diagnostics;

namespace Azure.Identity
{
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureIdentityEventSource : EventSource
    {
        private const string EventSourceName = "Azure-Identity";

        private const int GetTokenEvent = 1;
        private const int GetTokenSucceededEvent = 2;
        private const int GetTokenFailedEvent = 3;
        private const int ProbeImdsEndpointEvent = 4;
        private const int ImdsEndpointFoundEvent = 5;
        private const int ImdsEndpointUnavailableEvent = 6;

        private AzureIdentityEventSource() : base(EventSourceName, EventSourceSettings.Default, AzureEventSourceListener.TraitName, AzureEventSourceListener.TraitValue) { }

        public static AzureIdentityEventSource Singleton { get; } = new AzureIdentityEventSource();

        [NonEvent]
        public void GetToken(string method, TokenRequestContext context)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.All))
            {
                GetToken(method, FormatStringArray(context.Scopes), context.ParentRequestId);
            }
        }

        [Event(GetTokenEvent, Level = EventLevel.Informational, Message = "{0} invoked. Scopes: {1} ParentRequestId: {2}")]
        public void GetToken(string method, string scopes, string parentRequestId)
        {
            WriteEvent(GetTokenEvent, method, scopes, parentRequestId);
        }

        [NonEvent]
        public void GetTokenSucceeded(string method, TokenRequestContext context, DateTimeOffset expiresOn)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.All))
            {
                GetTokenSucceeded(method, FormatStringArray(context.Scopes), context.ParentRequestId, expiresOn.ToString("O", CultureInfo.InvariantCulture));
            }
        }

        [Event(GetTokenSucceededEvent, Level = EventLevel.Informational, Message = "{0} succeeded. Scopes: {1} ParentRequestId: {2} ExpiresOn: {3}")]
        public void GetTokenSucceeded(string method, string scopes, string parentRequestId, string expiresOn)
        {
            WriteEvent(GetTokenSucceededEvent, method, scopes, parentRequestId, expiresOn);
        }

        [NonEvent]
        public void GetTokenFailed(string method, TokenRequestContext context, Exception ex)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.All))
            {
                GetTokenFailed(method, FormatStringArray(context.Scopes), context.ParentRequestId, FormatException(ex));
            }
        }

        [Event(GetTokenFailedEvent, Level = EventLevel.Informational, Message = "{0} was unable to retrieve an access token. Scopes: {1} ParentRequestId: {2} Exception: {3}")]
        public void GetTokenFailed(string method, string scopes, string parentRequestId, string exception)
        {
            WriteEvent(GetTokenFailedEvent, method, scopes, parentRequestId, exception);
        }

        [NonEvent]
        public void ProbeImdsEndpoint(RequestUriBuilder uri)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.All))
            {
                ProbeImdsEndpoint(uri.ToString());
            }
        }

        [Event(ProbeImdsEndpointEvent, Level = EventLevel.Informational, Message = "Probiing IMDS endpoint for availability. Endpoint: {0}")]
        public void ProbeImdsEndpoint(string uri)
        {
            WriteEvent(ProbeImdsEndpointEvent, uri);
        }

        [NonEvent]
        public void ImdsEndpointFound(RequestUriBuilder uri)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.All))
            {
                ImdsEndpointFound(uri.ToString());
            }
        }

        [Event(ImdsEndpointFoundEvent, Level = EventLevel.Informational, Message = "IMDS endpoint is available. Endpoint: {0}")]
        public void ImdsEndpointFound(string uri)
        {
            WriteEvent(ImdsEndpointFoundEvent, uri);
        }

        [NonEvent]
        public void ImdsEndpointUnavailable(RequestUriBuilder uri)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.All))
            {
                ImdsEndpointUnavailable(uri.ToString());
            }
        }

        [Event(ImdsEndpointUnavailableEvent, Level = EventLevel.Informational, Message = "IMDS endpoint is did not respond. Endpoint: {0}")]
        public void ImdsEndpointUnavailable(string uri)
        {
            WriteEvent(ImdsEndpointUnavailableEvent, uri);
        }

        [NonEvent]
        private static string FormatException(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            bool nest = false;
            do
            {
                if (nest)
                {
                    // Format how Exception.ToString() would.
                    sb.AppendLine()
                      .Append(" ---> ");
                }
                // Do not include StackTrace, but do include HResult (often useful for CryptographicExceptions or IOExceptions).
                sb.Append(ex.GetType().FullName)
                  .Append(" (0x")
                  .Append(ex.HResult.ToString("x", CultureInfo.InvariantCulture))
                  .Append("): ")
                  .Append(ex.Message);
                ex = ex.InnerException;
                nest = true;
            }
            while (ex != null);
            return sb.ToString();
        }

        [NonEvent]
        private static string FormatStringArray(string[] array)
        {
            return new StringBuilder("[ ").Append(string.Join(", ", array)).Append(" ]").ToString();
        }
    }
}

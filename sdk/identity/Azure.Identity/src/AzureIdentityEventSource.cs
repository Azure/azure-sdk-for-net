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
        private const int ImdsEndpointUnavailableEvent = 4;

        private AzureIdentityEventSource() : base(EventSourceName, EventSourceSettings.Default, AzureEventSourceListener.TraitName, AzureEventSourceListener.TraitValue) { }

        public static AzureIdentityEventSource Singleton { get; } = new AzureIdentityEventSource();

        [Event(GetTokenEvent, Level = EventLevel.Informational, Message = "{0} [ Scopes: {1} ParentRequestId: {2} ]")]
        public void GetToken(string fullyQualifiedMethod, TokenRequestContext context)
        {
            WriteEvent(GetTokenEvent, fullyQualifiedMethod, context.Scopes, context.ParentRequestId);
        }

        [Event(GetTokenSucceededEvent, Level = EventLevel.Informational, Message = "{0} succeeded [ Scopes: {1} ParentRequestId: {2} ExpiresOn: {3} ]")]
        public void GetTokenSuccess(string fullyQualifiedMethod, TokenRequestContext context, DateTimeOffset ExpiresOn)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.All))
            {
                WriteEvent(GetTokenSucceededEvent, fullyQualifiedMethod, context.Scopes, context.ParentRequestId, ExpiresOn.ToString("O", CultureInfo.InvariantCulture));
            }
        }

        [Event(GetTokenFailedEvent, Level = EventLevel.Informational, Message = "{0} was unable to retrieve an access token [ Scopes: {1} ParentRequestId: {2} ] {3}")]
        public void GetTokenFailed(string fullyQualifiedMethod, TokenRequestContext context, Exception ex)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.All))
            {
                string exStr = FormatException(ex);

                WriteEvent(GetTokenFailedEvent, fullyQualifiedMethod, context.Scopes, context.ParentRequestId, exStr);
            }
        }

        [Event(ProbeImdsEndpointEvent, Level = EventLevel.Informational, Message = "Probiing IMDS endpoint for availability. Endpoint: {0}")]
        public void ProbeImdsEndpoint(RequestUriBuilder uri)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.All))
            {
                WriteEvent(ProbeImdsEndpointEvent, uri.ToString());
            }
        }

        [Event(ImdsEndpointFoundEvent, Level = EventLevel.Informational, Message = "IMDS endpoint is available. Endpoint: {0}")]
        public void ImdsEndpointFound(RequestUriBuilder uri)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.All))
            {
                WriteEvent(ImdsEndpointFoundEvent, uri.ToString());
            }
        }

        [Event(ImdsEndpointUnavailableEvent, Level = EventLevel.Informational, Message = "IMDS endpoint is did not respond. Endpoint: {0}")]
        public void ImdsEndpointUnavailable(RequestUriBuilder uri)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.All))
            {
                WriteEvent(ImdsEndpointUnavailableEvent, uri.ToString());
            }
        }
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
    }
}

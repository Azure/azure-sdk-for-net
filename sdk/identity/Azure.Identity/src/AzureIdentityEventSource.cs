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
        private const int MsalLogVerboseEvent = 7;
        private const int MsalLogInfoEvent = 8;
        private const int MsalLogWarningEvent = 9;
        private const int MsalLogErrorEvent = 10;

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
        public void ProbeImdsEndpoint(Uri uri)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.All))
            {
                ProbeImdsEndpoint(uri.ToString());
            }
        }

        [Event(ProbeImdsEndpointEvent, Level = EventLevel.Informational, Message = "Probing IMDS endpoint for availability. Endpoint: {0}")]
        public void ProbeImdsEndpoint(string uri)
        {
            WriteEvent(ProbeImdsEndpointEvent, uri);
        }

        [NonEvent]
        public void ImdsEndpointFound(Uri uri)
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
        public void ImdsEndpointUnavailable(Uri uri, string error)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.All))
            {
                ImdsEndpointUnavailable(uri.ToString(), error);
            }
        }

        [NonEvent]
        public void ImdsEndpointUnavailable(Uri uri, Exception e)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.All))
            {
                ImdsEndpointUnavailable(uri.ToString(), FormatException(e));
            }
        }

        [Event(ImdsEndpointUnavailableEvent, Level = EventLevel.Informational, Message = "IMDS endpoint is not available. Endpoint: {0}. Error: {1}")]
        public void ImdsEndpointUnavailable(string uri, string error)
        {
            WriteEvent(ImdsEndpointUnavailableEvent, uri, error);
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
        public void LogMsal(Microsoft.Identity.Client.LogLevel level, string message, bool containsPii)
        {
            if (!containsPii)
            {
                switch (level)
                {
                    case Microsoft.Identity.Client.LogLevel.Error when IsEnabled(EventLevel.Error, EventKeywords.All):
                        LogMsalError(message);
                        break;
                    case Microsoft.Identity.Client.LogLevel.Warning when IsEnabled(EventLevel.Warning, EventKeywords.All):
                        LogMsalWarning(message);
                        break;
                    case Microsoft.Identity.Client.LogLevel.Info when IsEnabled(EventLevel.Informational, EventKeywords.All):
                        LogMsalInformational(message);
                        break;
                    case Microsoft.Identity.Client.LogLevel.Verbose when IsEnabled(EventLevel.Verbose, EventKeywords.All):
                        LogMsalVerbose(message);
                        break;
                    default:
                        break;
                }
            }
        }

        [Event(MsalLogErrorEvent, Level = EventLevel.Error, Message = "{0}")]
        public void LogMsalError(string message)
        {
            WriteEvent(MsalLogErrorEvent, message);
        }

        [Event(MsalLogWarningEvent, Level = EventLevel.Warning, Message = "{0}")]
        public void LogMsalWarning(string message)
        {
            WriteEvent(MsalLogWarningEvent, message);
        }

        [Event(MsalLogInfoEvent, Level = EventLevel.Informational, Message = "{0}")]
        public void LogMsalInformational(string message)
        {
            WriteEvent(MsalLogInfoEvent, message);
        }

        [Event(MsalLogVerboseEvent, Level = EventLevel.Verbose, Message = "{0}")]
        public void LogMsalVerbose(string message)
        {
            WriteEvent(MsalLogVerboseEvent, message);
        }

        [NonEvent]
        private static string FormatStringArray(string[] array)
        {
            return new StringBuilder("[ ").Append(string.Join(", ", array)).Append(" ]").ToString();
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;

namespace Azure.Security.KeyVault.Certificates
{
    [EventSource(Name = EventSourceName)]
    internal sealed class CertificatesEventSource : EventSource
    {
        internal const int BeginUpdateStatusEvent = 1;
        internal const int EndUpdateStatusEvent = 2;

        private const string EventSourceName = "Azure-Security-KeyVault-Certificates";
        private const string Deleted = "(deleted)";
        private const string NoError = "(none)";

        private CertificatesEventSource() : base(EventSourceName, EventSourceSettings.Default, AzureEventSourceListener.TraitName, AzureEventSourceListener.TraitValue) { }

        public static CertificatesEventSource Singleton { get; } = new CertificatesEventSource();

        [NonEvent]
        public void BeginUpdateStatus(CertificateOperationProperties properties) =>
            BeginUpdateStatus(properties?.Id.ToString(), properties?.Status, properties?.Error?.Message);

        [Event(BeginUpdateStatusEvent, Level = EventLevel.Verbose, Message = "Updating certificate operation status: {0}, current status: {1}, error: {2}")]
        public void BeginUpdateStatus(string id, string status, string error) => WriteEvent(BeginUpdateStatusEvent, id ?? Deleted, status, error ?? NoError);

        [NonEvent]
        public void EndUpdateStatus(CertificateOperationProperties properties) =>
            EndUpdateStatus(properties?.Id.ToString(), properties?.Status, properties?.Error?.Message);

        [Event(EndUpdateStatusEvent, Level = EventLevel.Verbose, Message = "Updated certificate operation status: {0}, ending status: {1}, error: {2}")]
        public void EndUpdateStatus(string id, string status, string error) => WriteEvent(EndUpdateStatusEvent, id ?? Deleted, status, error ?? NoError);
    }
}

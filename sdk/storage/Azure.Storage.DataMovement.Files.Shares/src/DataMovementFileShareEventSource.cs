// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class DataMovementFileShareEventSource : AzureEventSource
    {
        private const string EventSourceName = "Azure-Storage-DataMovement-Files-Shares";

        private const int ProtocolValidationSkippedEvent = 1;

        private DataMovementFileShareEventSource() : base(EventSourceName) { }

        public static DataMovementFileShareEventSource Singleton { get; } = new DataMovementFileShareEventSource();

        [Event(ProtocolValidationSkippedEvent, Level = EventLevel.Informational, Message = "Transfer [{0}] Protocol Validation skipped for {1}: Resource={2}")]
        public void ProtocolValidationSkipped(string transferId, string endpoint, string resourceUri)
        {
            WriteEvent(ProtocolValidationSkippedEvent, transferId, endpoint, resourceUri);
        }
    }
}

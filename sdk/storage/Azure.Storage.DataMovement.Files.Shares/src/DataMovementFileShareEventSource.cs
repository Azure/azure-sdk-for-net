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
        private const int SymLinkDetectedEvent = 2;
        private const int HardLinkDetectedEvent = 3;

        private DataMovementFileShareEventSource() : base(EventSourceName) { }

        public static DataMovementFileShareEventSource Singleton { get; } = new DataMovementFileShareEventSource();

        [Event(ProtocolValidationSkippedEvent, Level = EventLevel.Informational, Message = "Transfer [{0}] Protocol Validation skipped for {1}: Resource={2}")]
        public void ProtocolValidationSkipped(string transferId, string endpoint, string resourceUri)
        {
            WriteEvent(ProtocolValidationSkippedEvent, transferId, endpoint, resourceUri);
        }

        [Event(SymLinkDetectedEvent, Level = EventLevel.Informational, Message = "Source resource item detected to be Symbolic link. The item transfer will be skipped: Resource={0}")]
        public void SymLinkDetected(string resourceUri)
        {
            WriteEvent(SymLinkDetectedEvent, resourceUri);
        }

        [Event(HardLinkDetectedEvent, Level = EventLevel.Informational, Message = "Source resource item detected to be Hard link. The item will be transfered as a regular file: Resource={0}")]
        public void HardLinkDetected(string resourceUri)
        {
            WriteEvent(HardLinkDetectedEvent, resourceUri);
        }
    }
}

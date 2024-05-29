// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Recording Storage base
    /// </summary>
    public abstract partial class RecordingStorage
    {
        /// <summary>
        /// Recording storage
        /// </summary>
        /// <param name="recordingStorageKind"></param>
        public RecordingStorage(RecordingStorageKind recordingStorageKind)
        {
            this.RecordingStorageKind = recordingStorageKind;
        }

        /// <summary>
        /// Recording storage Kind
        /// </summary>
        public RecordingStorageKind RecordingStorageKind { get; private set; }

        /// <summary> Creates AzureBlobContainer Storage for Recording. </summary>
        public static RecordingStorage CreateAzureBlobContainerRecordingStorage(Uri recordingDestinationContainerUri)
        {
            return new AzureBlobContainerRecordingStorage(recordingDestinationContainerUri);
        }

        /// <summary> Creates AzureCommunications Storage for Recording. </summary>
        public static RecordingStorage CreateAzureCommunicationsRecordingStorage()
        {
            return new AzureCommunicationsRecordingStorage();
        }
    }
}
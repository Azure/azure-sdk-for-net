// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The AzureBlobContainerRecordingStorage. </summary>
    internal class AzureBlobContainerRecordingStorage : RecordingStorage
    {
        /// <summary> Initializes a new instance of <see cref="AzureBlobContainerRecordingStorage"/>. </summary>
        public AzureBlobContainerRecordingStorage(Uri recordingDestinationContainerUri)
             : base(RecordingStorageKind.AzureBlobStorage)
        {
            RecordingDestinationContainerUri = recordingDestinationContainerUri;
        }

        /// <summary> The Azure blob storage container uri. </summary>
        public Uri RecordingDestinationContainerUri { get; set; }
    }
}
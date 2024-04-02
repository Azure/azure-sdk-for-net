// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

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

        /// <summary> The RecordingDestinationContainerUri. </summary>
        public Uri RecordingDestinationContainerUri { get; set; }
    }
}

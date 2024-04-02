// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

using System;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("ExternalStorage")]
    public abstract partial class RecordingStorage
    {
        /// <summary> Gets the Uri of a container or a location within a container. </summary>
        [CodeGenMember("RecordingDestinationContainerUrl")]
        private Uri RecordingDestinationContainerUri { get; set; }

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

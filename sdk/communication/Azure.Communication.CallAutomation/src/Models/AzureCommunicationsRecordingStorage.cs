// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The AzureCommunicationsRecordingStorage. </summary>
    internal class AzureCommunicationsRecordingStorage : RecordingStorage
    {
        /// <summary> Initializes a new instance of <see cref="AzureCommunicationsRecordingStorage"/>. </summary>
        public AzureCommunicationsRecordingStorage()
            : base(RecordingStorageKind.AzureCommunicationServices)
        {
        }
    }
}
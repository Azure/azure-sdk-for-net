// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Abstract base class used for different storage options used for storing call recording.
    /// </summary>
    public abstract class ExternalStorage
    {
        /// <summary>
        /// Identifier of storage type.
        /// </summary>
        public RecordingStorageType StorageType { get; protected set; }
    }
}

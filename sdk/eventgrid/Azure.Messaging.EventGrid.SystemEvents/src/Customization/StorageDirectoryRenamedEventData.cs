// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class StorageDirectoryRenamedEventData
    {
        /// <summary>
        /// For service use only. Diagnostic data occasionally included by the Azure Storage service. This property should be ignored by event consumers.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object StorageDiagnostics { get; }
    }
}

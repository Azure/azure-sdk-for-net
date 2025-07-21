// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Schema of the Data property of an EventGridEvent for a Microsoft.Storage.DirectoryDeleted event. </summary>
    public partial class StorageDirectoryDeletedEventData
    {
        [CodeGenMember("Recursive")]
        internal string RecursiveString { get; }

        /// <summary>
        /// Is this event for a recursive delete operation.
        /// </summary>
        public bool? Recursive
        {
            get
            {
                if (_recursive == null && RecursiveString != null)
                {
                    _recursive = bool.Parse(RecursiveString);
                }

                return _recursive;
            }
        }

        private bool? _recursive;

        /// <summary>
        /// For service use only. Diagnostic data occasionally included by the Azure Storage service. This property should be ignored by event consumers.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object StorageDiagnostics { get; }
    }
}

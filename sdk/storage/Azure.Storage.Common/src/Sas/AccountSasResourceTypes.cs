// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// Specifies the resource types accessible from an account level shared
    /// access signature.
    /// </summary>
    [Flags]
    public enum AccountSasResourceTypes
    {
        /// <summary>
        /// Indicates whether service-level APIs are accessible
        /// from this shared access signature (e.g., Get/Set Service
        /// Properties, Get Service Stats, List Containers/Queues/Tables/
        /// Shares).
        /// </summary>
        Service = 1,

        /// <summary>
        /// Indicates whether blob container-level APIs are accessible
        /// from this shared access signature (e.g., Create/Delete Container,
        /// Create/Delete Queue, Create/Delete Table, Create/Delete Share, List
        /// Blobs/Files and Directories).
        /// </summary>
        Container = 2,

#pragma warning disable CA1720 // Identifier contains type name
        /// <summary>
        /// Indicates whether object-level APIs for blobs, queue
        /// messages, and files are accessible from this shared access
        /// signature (e.g. Put Blob, Query Entity, Get Messages, Create File,
        /// etc.).
        /// </summary>
        Object = 4,
#pragma warning restore CA1720 // Identifier contains type name

        /// <summary>
        /// Indicates all service-level APIs are accessible from this shared
        /// access signature.
        /// </summary>
        All = ~0
    }
}

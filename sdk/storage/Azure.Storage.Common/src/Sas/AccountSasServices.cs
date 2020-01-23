// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// Specifies the services accessible from an account level shared access
    /// signature.
    /// </summary>
    [Flags]
    public enum AccountSasServices
    {
        /// <summary>
        /// Indicates whether Azure Blob Storage resources are
        /// accessible from the shared access signature.
        /// </summary>
        Blobs = 1,

        /// <summary>
        /// Indicates whether Azure Queue Storage resources are
        /// accessible from the shared access signature.
        /// </summary>
        Queues = 2,

        /// <summary>
        /// Indicates whether Azure File Storage resources are
        /// accessible from the shared access signature.
        /// </summary>
        Files = 4,

        /// <summary>
        /// Indicates whether Azure Table Storage resources are
        /// accessible from the shared access signature.
        /// </summary>
        Tables = 8,

        /// <summary>
        /// Indicates all services are accessible from the shared
        /// access signature.
        /// </summary>
        All = ~0
    }
}

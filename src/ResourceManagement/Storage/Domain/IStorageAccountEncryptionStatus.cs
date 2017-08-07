// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using System;

    /// <summary>
    /// Type representing the encryption status of a storage service.
    /// </summary>
    public interface IStorageAccountEncryptionStatus 
    {
        /// <summary>
        /// Gets the storage service type.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.StorageService StorageService { get; }

        /// <summary>
        /// Gets rough estimate of the date/time when the encryption was last enabled, null if
        /// the encryption is disabled.
        /// </summary>
        System.DateTime? LastEnabledTime { get; }

        /// <summary>
        /// Gets true if the encryption is enabled for the service false otherwise.
        /// </summary>
        bool IsEnabled { get; }
    }
}
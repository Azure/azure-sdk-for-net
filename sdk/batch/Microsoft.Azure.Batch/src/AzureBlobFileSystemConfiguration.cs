// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using System;

    public partial class AzureBlobFileSystemConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureBlobFileSystemConfiguration"/> class.
        /// </summary>
        /// <param name='accountName'>The Azure Storage account name.</param>
        /// <param name='containerName'>The Azure Blob Storage Container name.</param>
        /// <param name='relativeMountPath'>The relative path on the compute node where the file system will be mounted.</param>
        /// <param name='key'>The key to use to authenticate with Azure Storage. This can be either a SAS key or a Storage Account Key.</param>
        /// <param name='blobfuseOptions'>Additional command line options to pass to the mount command.</param>
        public AzureBlobFileSystemConfiguration(
            string accountName,
            string containerName,
            string relativeMountPath,
            AzureStorageAuthenticationKey key,
            string blobfuseOptions = default(string)) : this(accountName, containerName, relativeMountPath, blobfuseOptions: blobfuseOptions)
        {
            SasKey = key.SasKey;
            AccountKey = key.AccountKey;
        }
    }
}

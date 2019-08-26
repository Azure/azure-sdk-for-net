// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using System;

    public partial class MountConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MountConfiguration"/> class with an <see cref="AzureBlobFileSystemConfiguration"/>.
        /// </summary>
        public MountConfiguration(AzureBlobFileSystemConfiguration configuration) : this(azureBlobFileSystemConfiguration: configuration)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MountConfiguration"/> class with an <see cref="AzureFileShareConfiguration"/>.
        /// </summary>
        public MountConfiguration(AzureFileShareConfiguration configuration) : this(azureFileShareConfiguration: configuration)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MountConfiguration"/> class with an <see cref="NfsMountConfiguration"/>.
        /// </summary>
        public MountConfiguration(NfsMountConfiguration configuration) : this(nfsMountConfiguration: configuration)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MountConfiguration"/> class with an <see cref="CifsMountConfiguration"/>.
        /// </summary>
        public MountConfiguration(CifsMountConfiguration configuration) : this(cifsMountConfiguration: configuration)
        {
        }
    }
}

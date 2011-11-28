//-----------------------------------------------------------------------
// <copyright file="BlobContainerPermissions.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the BlobContainerPermissions class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the permissions for a container.
    /// </summary>
    public class BlobContainerPermissions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerPermissions"/> class.
        /// </summary>
        public BlobContainerPermissions()
        {
            this.PublicAccess = BlobContainerPublicAccessType.Off;
            SharedAccessPolicies = new SharedAccessPolicies();
        }

        /// <summary>
        /// Gets or sets the public access setting for the container.
        /// </summary>
        /// <value>The public access setting for the container.</value>
        public BlobContainerPublicAccessType PublicAccess { get; set; }

        /// <summary>
        /// Gets the set of shared access policies for the container.
        /// </summary>
        /// <value>The set of shared access policies for the container.</value>
        public SharedAccessPolicies SharedAccessPolicies { get; private set; }
    }
}

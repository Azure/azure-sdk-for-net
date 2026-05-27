// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Batch
{
    public static partial class BatchExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="BatchAccountCertificateResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="BatchAccountCertificateResource.CreateResourceIdentifier" /> to create a <see cref="BatchAccountCertificateResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="BatchAccountCertificateResource"/> object. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release. Certificate management APIs have been removed from the Batch service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BatchAccountCertificateResource GetBatchAccountCertificateResource(this ArmClient client, ResourceIdentifier id)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");
    }
}

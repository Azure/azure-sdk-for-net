// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Batch
{
    public partial class BatchAccountResource
    {
        /// <summary> Gets a collection of BatchAccountCertificateResources in the BatchAccount. </summary>
        /// <returns> An object representing collection of BatchAccountCertificateResources and their operations over a BatchAccountCertificateResource. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release. Certificate management APIs have been removed from the Batch service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual BatchAccountCertificateCollection GetBatchAccountCertificates()
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Gets the specified certificate. </summary>
        /// <param name="certificateName"> The identifier for the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release. Certificate management APIs have been removed from the Batch service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<BatchAccountCertificateResource> GetBatchAccountCertificate(string certificateName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Gets the specified certificate. </summary>
        /// <param name="certificateName"> The identifier for the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release. Certificate management APIs have been removed from the Batch service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<BatchAccountCertificateResource>> GetBatchAccountCertificateAsync(string certificateName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");
    }
}

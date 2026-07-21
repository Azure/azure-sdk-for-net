// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.ArtifactSigning.Models;

namespace Azure.ResourceManager.ArtifactSigning
{
    public partial class ArtifactSigningCertificateProfileResource
    {
        // Backward-compatibility shim. The single-certificate revoke operation was replaced by the
        // batch RevokeCertificates operation. This overload wraps the single content into a list and
        // delegates to RevokeCertificates to preserve source compatibility.
        /// <summary> Revoke a certificate. </summary>
        /// <param name="content"> The certificate to revoke. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Use RevokeCertificates instead.")]
        public virtual Response RevokeCertificate(RevokeCertificateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));
            return RevokeCertificates(new RevokeCertificateList(new[] { content }), cancellationToken);
        }

        // Backward-compatibility shim. Use RevokeCertificatesAsync instead.
        /// <summary> Revoke a certificate. </summary>
        /// <param name="content"> The certificate to revoke. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Use RevokeCertificatesAsync instead.")]
        public virtual Task<Response> RevokeCertificateAsync(RevokeCertificateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));
            return RevokeCertificatesAsync(new RevokeCertificateList(new[] { content }), cancellationToken);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService.Mocking
{
    public partial class MockableAppServiceTenantResource : ArmResource
    {
        /// <summary>
        /// Description for Implements Csm operations Api to exposes the list of available Csm Apis under the resource provider
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.CertificateRegistration/operations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateRegistrationProvider_ListOperations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CsmOperationDescription"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CsmOperationDescription> GetOperationsCertificateRegistrationProvidersAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Implements Csm operations Api to exposes the list of available Csm Apis under the resource provider
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.CertificateRegistration/operations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateRegistrationProvider_ListOperations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CsmOperationDescription"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CsmOperationDescription> GetOperationsCertificateRegistrationProviders(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }
    }
}

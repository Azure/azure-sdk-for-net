// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.AppService.Mocking
{
    public partial class MockableAppServiceArmClient : ArmResource
    {
        /// <summary>
        /// Gets an object representing an <see cref="AppServiceCertificateOrderResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="AppServiceCertificateOrderResource.CreateResourceIdentifier" /> to create an <see cref="AppServiceCertificateOrderResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AppServiceCertificateOrderResource"/> object. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AppServiceCertificateOrderResource GetAppServiceCertificateOrderResource(ResourceIdentifier id)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Gets an object representing an <see cref="AppServiceCertificateResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="AppServiceCertificateResource.CreateResourceIdentifier" /> to create an <see cref="AppServiceCertificateResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AppServiceCertificateResource"/> object. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AppServiceCertificateResource GetAppServiceCertificateResource(ResourceIdentifier id)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Gets an object representing a <see cref="CertificateOrderDetectorResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="CertificateOrderDetectorResource.CreateResourceIdentifier" /> to create a <see cref="CertificateOrderDetectorResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CertificateOrderDetectorResource"/> object. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual CertificateOrderDetectorResource GetCertificateOrderDetectorResource(ResourceIdentifier id)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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
        public virtual AppServiceCertificateOrderResource GetAppServiceCertificateOrderResource(ResourceIdentifier id)
        {
            AppServiceCertificateOrderResource.ValidateResourceId(id);
            return new AppServiceCertificateOrderResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="AppServiceCertificateResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="AppServiceCertificateResource.CreateResourceIdentifier" /> to create an <see cref="AppServiceCertificateResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AppServiceCertificateResource"/> object. </returns>
        public virtual AppServiceCertificateResource GetAppServiceCertificateResource(ResourceIdentifier id)
        {
            AppServiceCertificateResource.ValidateResourceId(id);
            return new AppServiceCertificateResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="CertificateOrderDetectorResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="CertificateOrderDetectorResource.CreateResourceIdentifier" /> to create a <see cref="CertificateOrderDetectorResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CertificateOrderDetectorResource"/> object. </returns>
        public virtual CertificateOrderDetectorResource GetCertificateOrderDetectorResource(ResourceIdentifier id)
        {
            CertificateOrderDetectorResource.ValidateResourceId(id);
            return new CertificateOrderDetectorResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="DomainOwnershipIdentifierResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DomainOwnershipIdentifierResource.CreateResourceIdentifier" /> to create a <see cref="DomainOwnershipIdentifierResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DomainOwnershipIdentifierResource"/> object. </returns>
        public virtual DomainOwnershipIdentifierResource GetDomainOwnershipIdentifierResource(ResourceIdentifier id)
        {
            DomainOwnershipIdentifierResource.ValidateResourceId(id);
            return new DomainOwnershipIdentifierResource(Client, id);
        }
    }
}

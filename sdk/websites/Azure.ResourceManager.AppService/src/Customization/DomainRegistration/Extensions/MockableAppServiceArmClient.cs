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
        /// Gets an object representing an <see cref="AppServiceDomainResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="AppServiceDomainResource.CreateResourceIdentifier" /> to create an <see cref="AppServiceDomainResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AppServiceDomainResource"/> object. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AppServiceDomainResource GetAppServiceDomainResource(ResourceIdentifier id)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Gets an object representing a <see cref="TopLevelDomainResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="TopLevelDomainResource.CreateResourceIdentifier" /> to create a <see cref="TopLevelDomainResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TopLevelDomainResource"/> object. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TopLevelDomainResource GetTopLevelDomainResource(ResourceIdentifier id)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Gets an object representing a <see cref="DomainOwnershipIdentifierResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DomainOwnershipIdentifierResource.CreateResourceIdentifier" /> to create a <see cref="DomainOwnershipIdentifierResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DomainOwnershipIdentifierResource"/> object. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DomainOwnershipIdentifierResource GetDomainOwnershipIdentifierResource(ResourceIdentifier id)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }
    }
}

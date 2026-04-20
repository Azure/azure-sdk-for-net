// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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
        public virtual AppServiceDomainResource GetAppServiceDomainResource(ResourceIdentifier id)
        {
            AppServiceDomainResource.ValidateResourceId(id);
            return new AppServiceDomainResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="TopLevelDomainResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="TopLevelDomainResource.CreateResourceIdentifier" /> to create a <see cref="TopLevelDomainResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TopLevelDomainResource"/> object. </returns>
        public virtual TopLevelDomainResource GetTopLevelDomainResource(ResourceIdentifier id)
        {
            TopLevelDomainResource.ValidateResourceId(id);
            return new TopLevelDomainResource(Client, id);
        }
    }
}

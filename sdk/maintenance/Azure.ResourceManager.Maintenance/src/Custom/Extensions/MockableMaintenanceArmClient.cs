// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance.Mocking
{
    // Suppress duplicate GetMaintenanceConfigurationResource factory method (generator emits it twice
    // for MaintenanceConfigurations and MaintenanceConfigurationOperationGroup contributing to the same resource)
    [CodeGenSuppress("GetMaintenanceConfigurationResource", typeof(ResourceIdentifier))]
    public partial class MockableMaintenanceArmClient
    {
        /// <summary> Gets an object representing a <see cref="MaintenanceConfigurationResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MaintenanceConfigurationResource"/> object. </returns>
        public virtual MaintenanceConfigurationResource GetMaintenanceConfigurationResource(ResourceIdentifier id)
        {
            MaintenanceConfigurationResource.ValidateResourceId(id);
            return new MaintenanceConfigurationResource(Client, id);
        }

        /// <summary> Gets an object representing a <see cref="MaintenancePublicConfigurationResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MaintenancePublicConfigurationResource"/> object. </returns>
        public virtual MaintenancePublicConfigurationResource GetMaintenancePublicConfigurationResource(ResourceIdentifier id)
        {
            return new MaintenancePublicConfigurationResource(Client, id);
        }
    }
}

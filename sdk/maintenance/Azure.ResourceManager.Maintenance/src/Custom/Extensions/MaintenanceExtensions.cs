// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance
{
    // Suppress duplicate generated methods caused by multi-scope operations
    [CodeGenSuppress("GetMaintenanceConfigurationResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    public static partial class MaintenanceExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="MaintenanceConfigurationResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MaintenanceConfigurationResource"/> object. </returns>
        public static MaintenanceConfigurationResource GetMaintenanceConfigurationResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableMaintenanceArmClient(client).GetMaintenanceConfigurationResource(id);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDBForPostgreSql.Mocking
{
    [CodeGenSuppress("GetConfigurationResource", typeof(ResourceIdentifier))]
    public partial class MockableCosmosDBForPostgreSqlArmClient : ArmResource
    {
        /// <summary> Gets an object representing a <see cref="ConfigurationResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ConfigurationResource"/> object. </returns>
        public virtual ConfigurationResource GetConfigurationResource(ResourceIdentifier id)
        {
            ConfigurationResource.ValidateResourceId(id);
            return new ConfigurationResource(Client, id);
        }
    }
}

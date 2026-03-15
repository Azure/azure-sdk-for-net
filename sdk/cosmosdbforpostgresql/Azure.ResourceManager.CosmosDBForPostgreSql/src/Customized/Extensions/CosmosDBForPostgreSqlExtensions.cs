// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.CosmosDBForPostgreSql.Mocking;

namespace Azure.ResourceManager.CosmosDBForPostgreSql
{
    public static partial class CosmosDBForPostgreSqlExtensions
    {
        /// <summary> Gets an object representing a <see cref="ConfigurationResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ConfigurationResource"/> object. </returns>
        public static ConfigurationResource GetConfigurationResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableCosmosDBForPostgreSqlArmClient(client).GetConfigurationResource(id);
        }
    }
}

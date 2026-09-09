// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedApplications.Mocking
{
    // ApplicationDefinitionOpsById is internalized in client.tsp to avoid exposing disambiguation_dummy CRUD APIs;
    // keep the standard mockable ResourceIdentifier entry point as SDK-side customization.
    [CodeGenSuppress("GetApplicationDefinitionResource", typeof(ResourceIdentifier))]
    public partial class MockableManagedApplicationsArmClient
    {
        /// <summary> Gets an object representing a <see cref="ApplicationDefinitionResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ApplicationDefinitionResource"/> object. </returns>
        public virtual ApplicationDefinitionResource GetApplicationDefinitionResource(ResourceIdentifier id)
        {
            ApplicationDefinitionResource.ValidateResourceId(id);
            return new ApplicationDefinitionResource(Client, id);
        }
    }
}

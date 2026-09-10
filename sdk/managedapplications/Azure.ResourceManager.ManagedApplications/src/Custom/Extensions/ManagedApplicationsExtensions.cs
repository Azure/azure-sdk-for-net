// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.ManagedApplications.Mocking;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedApplications
{
    // ApplicationDefinitionOpsById is internalized in client.tsp to avoid exposing disambiguation_dummy CRUD APIs;
    // keep the standard ArmClient ResourceIdentifier entry point as SDK-side customization.
    [CodeGenSuppress("GetApplicationDefinitionResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    public static partial class ManagedApplicationsExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="ApplicationDefinitionResource"/> along with the instance operations that can be performed on it but with no data.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableManagedApplicationsArmClient.GetApplicationDefinitionResource(ResourceIdentifier)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="ApplicationDefinitionResource"/> object. </returns>
        public static ApplicationDefinitionResource GetApplicationDefinitionResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableManagedApplicationsArmClient(client).GetApplicationDefinitionResource(id);
        }
    }
}

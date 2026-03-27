// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    // Backward compatibility and API evolution: the old SDK (AutoRest-based, v1.1.1) exposed
    // GetServiceAlertResource(ResourceIdentifier) on MockableAlertsManagementArmClient. The Obsolete
    // folder marks GetServiceAlertResource with [Obsolete(true)] as a planned rename. This file
    // suppresses the generated method and re-adds it as GetAlertResource, providing the new
    // canonical method name for getting a ServiceAlertResource by ID.
    [CodeGenSuppress("GetServiceAlertResource", typeof(ResourceIdentifier))]
    public partial class MockableAlertsManagementArmClient : ArmResource
    {
        /// <summary>
        /// Gets an object representing a <see cref="ServiceAlertResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ServiceAlertResource.CreateResourceIdentifier" /> to create a <see cref="ServiceAlertResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ServiceAlertResource" /> object. </returns>
        public virtual ServiceAlertResource GetAlertResource(ResourceIdentifier id)
        {
            ServiceAlertResource.ValidateResourceId(id);
            return new ServiceAlertResource(Client, id);
        }
    }
}

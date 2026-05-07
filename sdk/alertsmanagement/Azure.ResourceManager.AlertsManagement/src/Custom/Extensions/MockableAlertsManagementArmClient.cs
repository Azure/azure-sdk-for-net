// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    // The TypeSpec spec defines two @armResourceOperations interfaces (Alerts and
    // AlertGetAllTenantOperation) that both bind to the Alert resource model, so the MPG generator
    // emits an identical GetServiceAlertResource(ResourceIdentifier) factory twice (CS0111 duplicate
    // member). The CodeGenSuppress below removes both generator-emitted overloads and we add a single
    // canonical GetServiceAlertResource manually to match the v1.1.1 API surface.
    [CodeGenSuppress("GetServiceAlertResource", typeof(ResourceIdentifier))]
    public partial class MockableAlertsManagementArmClient : ArmResource
    {
        /// <summary>
        /// Gets an object representing a <see cref="ServiceAlertResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ServiceAlertResource.CreateResourceIdentifier" /> to create a <see cref="ServiceAlertResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ServiceAlertResource" /> object. </returns>
        public virtual ServiceAlertResource GetServiceAlertResource(ResourceIdentifier id)
        {
            ServiceAlertResource.ValidateResourceId(id);
            return new ServiceAlertResource(Client, id);
        }
    }
}

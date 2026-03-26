// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    // Backward compatibility: the generated mocking method is named GetServiceAlertResource
    // (from the TypeSpec Alert renamed to ServiceAlert), but the old SDK exposed GetAlertResource.
    // CodeGenSuppress removes the generated method and this file re-adds it with the old name.
    [CodeGenSuppress("GetServiceAlertResource", typeof(ResourceIdentifier))]
    public partial class MockableAlertsManagementArmClient : ArmResource
    {
        public virtual ServiceAlertResource GetAlertResource(ResourceIdentifier id)
        {
            ServiceAlertResource.ValidateResourceId(id);
            return new ServiceAlertResource(Client, id);
        }
    }
}

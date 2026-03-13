// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    [CodeGenSuppress("GetAlertResource", typeof(ResourceIdentifier))]
    public partial class MockableAlertsManagementArmClient : ArmResource
    {
        public virtual AlertResource GetAlertResource(ResourceIdentifier id)
        {
            AlertResource.ValidateResourceId(id);
            return new AlertResource(Client, id);
        }
    }
}

#pragma warning restore CS1591

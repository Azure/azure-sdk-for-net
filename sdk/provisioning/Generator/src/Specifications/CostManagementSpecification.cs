// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.CostManagement;
using Azure.ResourceManager.CostManagement.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class CostManagementSpecification() :
    Specification("CostManagement", typeof(CostManagementExtensions), serviceDirectory: "costmanagement")
{
    protected override void Customize()
    {
        // Rename to avoid AZC0034 conflicts
        CustomizeResource<ScheduledActionResource>(r => r.Name = "CostManagementScheduledAction");
        CustomizeResource<TenantScheduledActionResource>(r => r.Name = "TenantCostManagementScheduledAction");
        CustomizeEnum<FunctionType>(e => e.Name = "CostManagementFunctionType");
    }
}

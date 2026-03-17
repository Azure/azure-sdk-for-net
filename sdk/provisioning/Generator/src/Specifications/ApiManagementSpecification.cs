// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.ApiManagement;

namespace Azure.Provisioning.Generator.Specifications;

public class ApiManagementSpecification() :
    Specification("ApiManagement", typeof(ApiManagementExtensions), serviceDirectory: "apimanagement")
{
    protected override void Customize()
    {
        // Rename to avoid AZC0012: type name 'Api' is too generic
        CustomizeModel<ApiResource>(m => m.Name = "ApiManagementApi");
    }
}

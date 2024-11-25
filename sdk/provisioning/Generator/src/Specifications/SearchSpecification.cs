// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Linq;
using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.Search;
using Azure.ResourceManager.Search.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class SearchSpecification() :
    Specification("Search", typeof(SearchExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<SearchServiceResource>("SearchManagementRequestOptions");
        RemoveProperty<SearchPrivateEndpointConnectionResource>("SearchManagementRequestOptions");
        RemoveProperty<SharedSearchServicePrivateLinkResource>("SearchManagementRequestOptions");
        RemoveProperty<SearchPrivateEndpointConnectionData>("ResourceType");
        RemoveProperty<SharedSearchServicePrivateLinkResourceData>("ResourceType");
        RemoveProperty<SearchServiceResource>("PublicInternetAccess");
        RemoveProperty<SearchServiceResource>("SkuName");
        RemoveModel<SearchServicePublicInternetAccess>();
        RemoveModel<SearchSkuName>();
        RemoveProperty<SharedSearchServicePrivateLinkResourceProperties>("SharedPrivateLinkResourceStatus");
        RemoveProperty<SharedSearchServicePrivateLinkResourceProperties>("SharedPrivateLinkResourceProvisioningState");
        
        // Patch models
        CustomizeEnum<SearchServicePrivateLinkServiceConnectionStatus>(e => { foreach (EnumValue member in e.Values) { member.Value = member.Name; } });
        CustomizeEnum<SearchServiceHostingMode>(e => { foreach (EnumValue member in e.Values) { member.Value = member.Name.ToCamelCase(); } });
        CustomizeEnum<SearchServiceStatus>(e => { foreach (EnumValue member in e.Values) { member.Value = member.Name.ToLower(); } });
        CustomizeEnum<SearchServiceProvisioningState>(e => { foreach (EnumValue member in e.Values) { member.Value = member.Name; } });
        CustomizeEnum<SearchEncryptionWithCmkEnforcement>(e => { foreach (EnumValue member in e.Values) { member.Value = member.Name; } });
        CustomizeEnum<SearchEncryptionComplianceStatus>(e => { foreach (EnumValue member in e.Values) { member.Value = member.Name; } });
        CustomizeEnum<SearchAadAuthFailureMode>(e => { foreach (EnumValue member in e.Values) { member.Value = member.Name.ToCamelCase(); } });

        // Naming requirements
        AddNameRequirements<SearchServiceResource>(min: 2, max: 60, lower: true, digits: true, hyphen: true);

        // Roles
        Roles.Add(new Role("SearchIndexDataContributor", "8ebe5a00-799e-43f5-93ac-243d3dce84a7", "Grants full access to Azure Cognitive Search index data."));
        Roles.Add(new Role("SearchIndexDataReader", "1407120a-92aa-4202-b7e9-c0e197c71c8f", "Grants read access to Azure Cognitive Search index data."));
        Roles.Add(new Role("SearchServiceContributor", "7ca78c08-252a-4471-8644-bb5ff32d4ba0", "Lets you manage Search services, but not access to them."));

        // Assign Roles
        CustomizeResource<SearchServiceResource>(r => r.GenerateRoleAssignment = true);
    }
}

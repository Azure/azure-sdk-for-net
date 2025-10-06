// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.ManagedServiceIdentities;

namespace Azure.Provisioning.Generator.Specifications;

public class ManagedServiceIdentitiesSpecification : Specification
{
    public ManagedServiceIdentitiesSpecification() :
        base("ManagedServiceIdentities", typeof(ManagedServiceIdentitiesExtensions))
    {
        Namespace = "Azure.Provisioning.Roles";
        SkipCleaning = true;
    }

    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<FederatedIdentityCredentialResource>("Issuer");

        // Customize models
        IncludeHiddenVersions<FederatedIdentityCredentialResource>("2025-01-31-PREVIEW", "2023-07-31-PREVIEW", "2022-01-31-PREVIEW");
        IncludeHiddenVersions<UserAssignedIdentityResource>("2025-01-31-PREVIEW", "2023-07-31-PREVIEW", "2022-01-31-PREVIEW", "2021-09-30-PREVIEW", "2015-08-31-PREVIEW");

        // Naming requirements
        AddNameRequirements<UserAssignedIdentityResource>(min: 3, max: 128, lower: true, upper: true, digits: true, hyphen: true, underscore: true);
    }
}

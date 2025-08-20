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

        // Naming requirements
        AddNameRequirements<UserAssignedIdentityResource>(min: 3, max: 128, lower: true, upper: true, digits: true, hyphen: true, underscore: true);
    }
}

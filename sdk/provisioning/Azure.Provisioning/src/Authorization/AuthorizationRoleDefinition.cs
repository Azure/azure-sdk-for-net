// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Authorization;

// Customize the generated RoleDefinition resource.
public partial class AuthorizationRoleDefinition
{
    // Special case AuthorizationRoleDefinition.Name as a GUID since regular
    // naming policies won't be able to manage that as cleanly.  Anyone who
    // really wants can override the value though.
    private partial BicepValue<string> GetNameDefaultValue() =>
        BicepFunction.CreateGuid(BicepFunction.GetResourceGroup().Id, BicepIdentifier);
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ApiManagement
{
    // Renames the generated data type from ApiManagementUserData to UserContractData
    // to preserve the previous SDK's public type name. Cannot use @@clientName in client.tsp
    // because that would also rename ApiManagementUserResource/Collection, breaking compat.
    [CodeGenType("ApiManagementUserData")]
    public partial class UserContractData { }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.ApiManagement;

// Preserve the released name and avoid the analyzer-invalid generic type name generated from ApiContract.
[CodeGenType("Api")]
public partial class ApiManagementApi
{
}

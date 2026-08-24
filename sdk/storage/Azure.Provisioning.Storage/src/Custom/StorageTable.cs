// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

// TypeSpec names this resource Table, while the shipped provisioning API uses StorageTable.
// Pin the generated type name locally to preserve compatibility without changing management output.
[CodeGenType("Table")]
public partial class StorageTable
{
}

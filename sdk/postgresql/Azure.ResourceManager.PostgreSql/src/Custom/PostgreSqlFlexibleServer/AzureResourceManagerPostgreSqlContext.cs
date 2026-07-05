// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql;

// Keeps the generated flexible-server serialization context in the existing PostgreSql namespace.
[CodeGenType("AzureResourceManagerPostgreSqlFlexibleServersContext")]
public partial class AzureResourceManagerPostgreSqlContext
{
}

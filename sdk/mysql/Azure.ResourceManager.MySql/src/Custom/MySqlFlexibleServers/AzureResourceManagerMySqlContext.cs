// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.MySql.FlexibleServers.Models;

namespace Azure.ResourceManager.MySql;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
[CodeGenType("AzureResourceManagerMySqlFlexibleServersContext")]
[ModelReaderWriterBuildable(typeof(MySqlFlexibleServersPrivateEndpointConnection))]
public partial class AzureResourceManagerMySqlContext
{
}

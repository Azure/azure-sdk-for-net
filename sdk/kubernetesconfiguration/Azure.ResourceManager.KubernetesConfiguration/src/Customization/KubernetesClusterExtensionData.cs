// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.KubernetesConfiguration.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.KubernetesConfiguration
{
    // Note: The @@alternateType decorator in client.tsp maps AksAssignedIdentity back
    // to ManagedServiceIdentity for backward compatibility with the old AutoRest SDK (1.2.0).
    // PackageUri type was also mapped back to Uri via @@alternateType.
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Input;
using System.Collections.Generic;

namespace Azure.Generator.Management
{
    internal record ManagementMethodMap(
        IReadOnlyList<ResourceMetadata> Resources,
        IReadOnlyDictionary<ResourceScope, IReadOnlyList<InputServiceMethod>> ExtensionNonResourceOperations,
        IReadOnlyDictionary<ResourceMetadata, IReadOnlyList<InputServiceMethod>> ResourceNonResourceOperations
        );
}

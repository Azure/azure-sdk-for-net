// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Generator.Management.Models
{
    internal record ResourceMetadata(string ResourceType, bool IsSingleton, ResourceScope ResourceScope, IReadOnlyList<ResourceMethod> Methods, string? ParentResource = null);
}

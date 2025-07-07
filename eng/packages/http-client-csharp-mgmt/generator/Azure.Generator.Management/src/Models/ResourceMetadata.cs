// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Generator.Management.Models
{
    internal record ResourceMetadata(
        string ResourceIdPattern,
        string ResourceType,
        ResourceScope ResourceScope,
        IReadOnlyList<ResourceMethod> Methods,
        string? singletonResourceName,
        string? ParentResource);
}

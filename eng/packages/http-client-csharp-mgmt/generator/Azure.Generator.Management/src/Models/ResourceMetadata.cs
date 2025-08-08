// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System.Collections.Generic;

namespace Azure.Generator.Management.Models
{
    internal record ResourceMetadata(
        string ResourceIdPattern,
        string ResourceType,
        InputModelType ResourceModel,
        ResourceScope ResourceScope,
        IReadOnlyList<ResourceMethod> Methods,
        string? SingletonResourceName,
        string? ParentResourceId,
        string ResourceName);
}

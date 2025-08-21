// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Generator.Management.Models
{
    internal record ResourceMethodCategory(
        IReadOnlyList<ResourceMethod> MethodsInResource,
        IReadOnlyList<ResourceMethod> MethodsInCollection,
        IReadOnlyList<ResourceMethod> MethodsInExtension);
}

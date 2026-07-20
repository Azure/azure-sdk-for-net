// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Generator.Management.Models;

/// <summary> Categorizes resource methods by where they are generated (resource, collection, or extension). </summary>
/// <param name="MethodsInResource"> Methods generated in the resource class. </param>
/// <param name="MethodsInCollection"> Methods generated in the collection class. </param>
/// <param name="MethodsInExtension"> Methods generated in the extension class. </param>
public record ResourceMethodCategory(
    IReadOnlyList<ResourceMethod> MethodsInResource,
    IReadOnlyList<ResourceMethod> MethodsInCollection,
    IReadOnlyList<ResourceMethod> MethodsInExtension);

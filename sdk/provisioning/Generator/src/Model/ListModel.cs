// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Generator.Model;

/// <summary>
/// Simple wrapper for a list of nested models.
/// </summary>
/// <param name="elementType">Type of values.</param>
public class ListModel(ModelBase elementType)
    : ModelBase(
        $"List<{elementType.Name}>",
        ns: "Azure.Provisioning")
{
    public ModelBase ElementType { get; } = elementType;

    public override string GetTypeReference() =>
        $"IList<{ElementType.GetTypeReference()}>";
}

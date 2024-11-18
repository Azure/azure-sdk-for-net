// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Generator.Model;

/// <summary>
/// Simple wrapper for a dictionary of nested models.  Keys are always strings.
/// </summary>
/// <param name="elementType">Type of values.</param>
public class DictionaryModel(ModelBase elementType)
    : ModelBase(
        $"IDictionary<String,{elementType.Name}>",
        ns: "Azure.Provisioning")
{
    public ModelBase ElementType { get; } = elementType;

    public override string GetTypeReference() =>
        $"IDictionary<string, {ElementType.GetTypeReference()}>";
}

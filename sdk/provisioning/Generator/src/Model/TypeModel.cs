// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Provisioning.Generator.Model;

/// <summary>
/// Represents a complex type with properties.
/// </summary>
public abstract class TypeModel : ModelBase
{
    public IList<Property> Properties { get; set; } = [];
    public TypeModel? BaseType { get; set; } = null;
    public string? DiscriminatorName { get; set; } = null;
    public string? DiscriminatorValue { get; set; } = null;
    public bool FromExpression { get; set; } = false;

    protected TypeModel(Specification spec, Type armType, string name, string? ns = default, string? description = default)
        : base(name, ns, armType, description)
    {
        Spec = spec;
        TypeRegistry.Register(this);
    }

    protected HashSet<string> CollectNamespaces()
    {
        HashSet<string> namespaces = [.. TypeRegistry.CollectNamespaces(Properties.Select(p => p.PropertyType))];
        namespaces.Add("Azure.Provisioning.Primitives");
        namespaces.Remove(Namespace!);
        return namespaces;
    }

    public override void Lint()
    {
        base.Lint();
        //if (BaseType is not null && DiscriminatorName is null) { Warn($"{GetTypeReference()} has a {nameof(BaseType)} but no {nameof(DiscriminatorName)}."); }
        if (DiscriminatorName is not null && DiscriminatorValue is null) { Warn($"{GetTypeReference()} has a {nameof(DiscriminatorName)} but no {nameof(DiscriminatorValue)}."); }
        //if (Properties.Count == 0 && !ArmType!.IsAbstract) { Warn($"{GetTypeReference()} has no properties."); }
        foreach (Property property in Properties)
        {
            if (property.Name is null) { Warn($"{GetTypeReference()} has a property with no {nameof(Property.Name)}."); }
            if (property.Path is null) { Warn($"{GetTypeReference()}.{property.Name} has no {nameof(Property.Path)}."); }
            // if (property.Description is null) { Warn($"{GetTypeReference()}.{property.Name} has no {nameof(Property.Description)}."); })
        }
        HashSet<string> paths = [.. Properties.Select(p => string.Join('.', p?.Path ?? []))];
        if (paths.Count != Properties.Count) { Warn($"{GetTypeReference()} has duplicate paths."); }
    }
}

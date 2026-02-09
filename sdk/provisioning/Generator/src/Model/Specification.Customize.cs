// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Azure.Provisioning.Generator.Model;

public abstract partial class Specification : ModelBase
{
    protected virtual void Customize() { }

    public void RemoveModel<T>()
    {
        ModelBase m = GetModel<T>();
        ModelNameMapping.Remove(m.Name);
        ModelArmTypeMapping.Remove(m.ArmType!);
        TypeRegistry.Remove(m);
    }

    public ModelBase GetModel<T>() =>
        ModelArmTypeMapping.GetValueOrDefault(typeof(T)) ??
            throw new InvalidOperationException($"Failed to find {typeof(T).FullName} to customize!");

    public Resource GetResource<T>() =>
        GetModel<T>() as Resource ??
            throw new InvalidOperationException($"Failed to find {typeof(T).FullName} to customize!");

    public SimpleModel GetSimpleModel<T>() =>
        GetModel<T>() as SimpleModel ??
            throw new InvalidOperationException($"Failed to find {typeof(T).FullName} to customize!");

    public EnumModel GetEnum<T>() =>
        GetModel<T>() as EnumModel ??
            throw new InvalidOperationException($"Failed to find {typeof(T).FullName} to customize!");

    protected void CustomizeResource<T>(Action<Resource> action) =>
        action(GetResource<T>());

    protected void CustomizeResource(string resourceName, Action<Resource> action) =>
        action(ModelNameMapping.GetValueOrDefault(resourceName) as Resource ??
            throw new InvalidOperationException($"Failed to find {resourceName} to customize!"));

    protected void CustomizeSimpleModel<T>(Action<SimpleModel> action) =>
        action(GetSimpleModel<T>());

    protected void CustomizeEnum<T>(Action<EnumModel> action) =>
        action(GetEnum<T>());

    protected void CustomizeModel<T>(Action<ModelBase> action) =>
        action(GetModel<T>());

    protected void CustomizeModel(string modelName, Action<ModelBase> action) =>
        action(ModelNameMapping.GetValueOrDefault(modelName) ??
            throw new InvalidOperationException($"Failed to find {modelName} to customize!"));

    protected void CustomizeProperty<T>(string propertyName, Action<Property> action) =>
        CustomizeProperty(GetModel<T>(), propertyName, action);

    protected void CustomizePropertyIsoDuration<T>(string propertyName) =>
        CustomizeProperty(GetModel<T>(), propertyName, p => p.Format = "P");

    protected void CustomizeProperty(string modelName, string propertyName, Action<Property> action) =>
        CustomizeProperty(ModelNameMapping.GetValueOrDefault(modelName) ??
            throw new InvalidOperationException($"Failed to find {modelName} to customize!"), propertyName, action);

    private static void CustomizeProperty(ModelBase model, string propertyName, Action<Property> action)
    {
        TypeModel typeModel = model as TypeModel ??
            throw new InvalidOperationException($"Failed to find {model.Name} to customize property!");
        Property? property = typeModel.Properties.FirstOrDefault(p => p.Name == propertyName) ??
            throw new InvalidOperationException($"Failed to find {model.Name}.{propertyName} to customize!");
        action(property);
    }

    public void RemoveProperties<T>(params string[] propertyNames)
    {
        foreach (string propertyName in propertyNames)
        {
            RemoveProperty<T>(propertyName);
        }
    }

    public void RemoveProperty<T>(string propertyName)
    {
        TypeModel model = GetModel<T>() as TypeModel ??
            throw new InvalidOperationException($"Failed to find {typeof(T).FullName} to remove property!");
        Property property = model.Properties.FirstOrDefault(p => p.Name == propertyName) ??
            throw new InvalidOperationException($"Failed to find property {propertyName} on type {typeof(T).FullName} to remove!");
        model.Properties.Remove(property);
    }

    public void AddNameRequirements<T>(
        int max,
        int min = 1,
        bool lower = false,
        bool upper = false,
        bool digits = false,
        bool hyphen = false,
        bool underscore = false,
        bool period = false,
        bool parens = false) =>
        GetResource<T>().NameRequirements = new(max, min, lower, upper, digits, hyphen, underscore, period, parens);

    public void OrderEnum<T>(params string[] names)
    {
        EnumModel model = GetEnum<T>();
        for (int i = names.Length - 1; i >= 0; i--)
        {
            EnumValue val = model.Values.First(v => v.Name == names[i]);
            model.Values.Remove(val);
            model.Values.Insert(0, val);
        }
    }

    public void IncludeVersions<T>(params string[] apiVersions)
    {
        Resource resource = GetResource<T>();
        for (int i = apiVersions.Length - 1; i >= 0; i--)
        {
            if (resource.ResourceVersions!.Contains(apiVersions[i])) { continue; }
            resource.ResourceVersions!.Insert(0, apiVersions[i]);
        }
    }

    public void IncludeHiddenVersions<T>(params string[] apiVersions)
    {
        Resource resource = GetResource<T>();
        resource.HiddenResourceVersions ??= [];
        foreach (string version in apiVersions)
        {
            if (resource.HiddenResourceVersions.Contains(version)) { continue; }
            resource.HiddenResourceVersions.Add(version);
        }
    }
}

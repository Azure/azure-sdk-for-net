// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Generator.Model;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.Provisioning.Generator.Model;

public class Property(TypeModel parent, ModelBase propertyType, PropertyInfo? armMember, ParameterInfo? armParameter)
{
    public TypeModel? Parent { get; } = parent;
    public PropertyInfo? ArmMember { get; internal set; } = armMember;
    public ParameterInfo? ArmParameter { get; } = armParameter;

    public string Name { get; set; } =
        armParameter?.Name.ToPascalCase() ?? armMember!.Name;

    public ModelBase? PropertyType { get; set; } = propertyType;

    public string? Description { get; set; } =
        armParameter is not null ?
            parent?.Spec?.DocComments.GetSummary(armParameter) :
            parent?.Spec?.DocComments.GetSummary(armMember!);

    
    public string FieldName { get => $"_{Name.ToCamelCase()}"; }
    public IList<string>? Path { get; set; }

    public bool IsReadOnly { get; set; } = false;
    public bool IsRequired { get; set; } = false;
    public bool IsSecure { get; set; } = false;
    public string? Format { get; set; } = null;

    public bool GenerateDefaultValue { get; set; } = false;
    public bool HideAccessors { get; set; } = false;

    public string BicepTypeReference
    {
        get
        {
            return GetBicepType(PropertyType);
            static string GetBicepType(ModelBase? type) =>
                type switch
                {
                    null => "BicepValue<object>",
                    DictionaryModel d when IsCollection(d.ElementType) => $"BicepDictionary<{GetBicepType(d.ElementType)}>",
                    DictionaryModel d => $"BicepDictionary<{d.ElementType.GetTypeReference()}>",
                    ListModel l when IsCollection(l.ElementType) => $"BicepList<{GetBicepType(l.ElementType)}>",
                    ListModel l => $"BicepList<{l.ElementType.GetTypeReference()}>",
                    SimpleModel m => m.GetTypeReference(),
                    Resource m => m.GetTypeReference(),
                    _ => $"BicepValue<{type.GetTypeReference()}>",
                };
            static bool IsCollection(ModelBase type) =>
                type is DictionaryModel || type is ListModel;
        }
    }

    public string BicepPropertyTypeReference
    {
        get
        {
            return GetBicepType(PropertyType);
            static string GetBicepType(ModelBase? type) =>
                type switch
                {
                    null => "object",
                    DictionaryModel d when d.ElementType is DictionaryModel => $"BicepDictionary<{GetBicepType(d.ElementType)}>",
                    DictionaryModel d when d.ElementType is ListModel => $"BicepList<{GetBicepType(d.ElementType)}>",
                    DictionaryModel d => d.ElementType.GetTypeReference(),
                    ListModel l when l.ElementType is DictionaryModel => $"BicepDictionary<{GetBicepType(l.ElementType)}>",
                    ListModel l when l.ElementType is ListModel => $"BicepList<{GetBicepType(l.ElementType)}>",
                    ListModel l => l.ElementType.GetTypeReference(),
                    SimpleModel m => m.GetTypeReference(),
                    Resource m => m.GetTypeReference(),
                    _ => type.GetTypeReference(),
                };
        }
    }

    public PropertyHideLevel HideLevel { get; set; } = PropertyHideLevel.DoNotHide;

    public override string ToString() =>
        $"<Property {Parent?.Spec?.Name}::{Parent?.Name}.{Name} : {PropertyType?.Name}>";
}

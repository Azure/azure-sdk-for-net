// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;

namespace Azure.Generator.Management.Visitors;

internal class InheritableSystemObjectModelVisitor : ScmLibraryVisitor
{
    // TODO: Remove this visitor once MTG fully supports inheritable system model replacements.
    // See https://github.com/microsoft/typespec/issues/10787.
    protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
    {
        if (type is SystemObjectModelProvider systemType)
        {
            UpdateNamespace(systemType);
            EnsureFrameworkTypeRegistered(systemType);
        }

        if (type is ModelProvider modelProvider && GetEffectiveBaseProvider(modelProvider) is not null && type is not SystemObjectModelProvider)
        {
            UpdateRegularModelInheritance(modelProvider);
        }
        return type;
    }

    protected override TypeProvider? VisitType(TypeProvider type)
    {
        if (type is SystemObjectModelProvider systemType)
        {
            UpdateNamespace(systemType);
            EnsureFrameworkTypeRegistered(systemType);
        }

        if (type is ModelProvider modelProvider && GetEffectiveBaseProvider(modelProvider) is not null && type is not SystemObjectModelProvider)
        {
            UpdateRegularModelInheritance(modelProvider);
        }

        return type;
    }

    private static void UpdateNamespace(SystemObjectModelProvider systemType)
    {
        // This is needed because we updated the namespace with NamespaceVisitor in Azure generator earlier
        systemType.Update(@namespace: systemType.SystemType.Namespace);
    }

    /// <summary>
    /// Registers the framework CSharpType (from KnownManagementTypes) as an alias in the CSharpTypeMap.
    /// This allows BuildBaseModelProvider() to find SystemObjectModelProvider when custom code
    /// uses a Roslyn-resolved framework CSharpType (which differs from the non-framework CSharpType
    /// created by SystemObjectModelProvider).
    /// </summary>
    private static void EnsureFrameworkTypeRegistered(SystemObjectModelProvider systemType)
    {
        var frameworkType = new CSharpType(systemType.SystemType.FrameworkType);
        var typeMap = ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap;
        if (!typeMap.ContainsKey(frameworkType))
        {
            typeMap[frameworkType] = systemType;
        }
    }

    private HashSet<ModelProvider> _regularUpdated = new();

    private void UpdateRegularModelInheritance(ModelProvider model)
    {
        if (_regularUpdated.Contains(model))
        {
            return;
        }

        var effectiveBaseProvider = GetEffectiveBaseProvider(model);
        if (effectiveBaseProvider is null)
        {
            return;
        }

        var basePropertyNames = EnumerateBaseModelProperties(effectiveBaseProvider);
        var mergedProperties = new List<PropertyProvider>(model.Properties);

        // When a custom CLR base is narrower than the TypeSpec base (for example, custom
        // ResourceData vs. generated TrackedResourceData), the original TypeSpec base chain still
        // owns properties like Location/Tags that are no longer supplied by the custom base.
        // Reconcile those lost properties back onto the derived model so constructors and
        // serialization still emit them.
        var materializedPropertyNames = new HashSet<string>(StringComparer.Ordinal);
        foreach (var property in mergedProperties)
        {
            materializedPropertyNames.Add(property.Name);
        }

        foreach (var baseProperty in GetOriginalBaseModelProperties(model))
        {
            if (basePropertyNames.Contains(baseProperty.Name) || materializedPropertyNames.Contains(baseProperty.Name))
            {
                continue;
            }

            var generatedProperty = CodeModelGenerator.Instance.TypeFactory.CreateProperty(baseProperty, model);
            if (generatedProperty is not null)
            {
                mergedProperties.Add(generatedProperty);
                materializedPropertyNames.Add(baseProperty.Name);
            }
        }

        var removedPropertyNames = new HashSet<string>();
        var remainingProperties = new List<PropertyProvider>();

        foreach (var prop in mergedProperties)
        {
            // Only remove true C# duplicate/shadowing properties. Some services expose
            // public SDK properties with distinct CLR names but inherited ARM wire names
            // (for example a model-specific "DefaultName" serialized as "name").
            // Removing those by wire name would be a public API breaking change.
            if (prop.Modifiers.HasFlag(MethodSignatureModifiers.New)
                || basePropertyNames.Contains(prop.Name))
            {
                removedPropertyNames.Add(prop.Name);
            }
            else
            {
                remainingProperties.Add(prop);
            }
        }

        StripOrphanedVirtualModifiers(effectiveBaseProvider, removedPropertyNames);
        // Reset cached constructors, serialization, and model factories so they do not keep
        // references to inherited ARM properties removed from the model surface.
        model.Update(name: model.Name, properties: remainingProperties.ToArray(), reset: true);

        _regularUpdated.Add(model);
    }

    private static IEnumerable<InputModelProperty> GetOriginalBaseModelProperties(ModelProvider model)
    {
        var inputModel = typeof(ModelProvider)
            .GetField("_inputModel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            ?.GetValue(model) as InputModelType;

        if (inputModel is null)
        {
            yield break;
        }

        var seen = new HashSet<InputModelType>();
        var current = inputModel.BaseModel;
        while (current is not null && seen.Add(current))
        {
            foreach (var property in current.Properties)
            {
                yield return property;
            }
            current = current.BaseModel;
        }
    }

    private static TypeProvider? GetEffectiveBaseProvider(ModelProvider model)
    {
        // Custom base declarations win over the TypeSpec base for inherited-property filtering.
        // Example: a model may infer TrackedResourceData from TypeSpec, but a custom partial can
        // narrow the effective base to ResourceData. In that case we must compare against the
        // custom base's members, not the TypeSpec hierarchy.
        if (model.CustomCodeView?.BaseType is { } customBaseType)
        {
            if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(customBaseType, out var customBaseProvider)
                && customBaseProvider is TypeProvider typeProvider)
            {
                return typeProvider;
            }
        }

        return model.BaseModelProvider;
    }

    private static TypeProvider? GetBaseTypeProvider(TypeProvider typeProvider)
    {
        if (typeProvider is ModelProvider modelProvider)
        {
            return GetEffectiveBaseProvider(modelProvider);
        }

        if (typeProvider.BaseType is not null
            && ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(typeProvider.BaseType, out var mappedProvider)
            && mappedProvider is TypeProvider baseTypeProvider)
        {
            return baseTypeProvider;
        }

        return null;
    }

    private static HashSet<string> EnumerateBaseModelProperties(TypeProvider baseModel)
    {
        var basePropertyNames = new HashSet<string>(StringComparer.Ordinal);
        TypeProvider? currentModel = baseModel;
        while (currentModel != null)
        {
            foreach (var property in currentModel.Properties)
            {
                basePropertyNames.Add(property.Name);
            }
            currentModel = GetBaseTypeProvider(currentModel);
        }
        return basePropertyNames;
    }

    private static void StripOrphanedVirtualModifiers(TypeProvider baseModel, HashSet<string> removedPropertyNames)
    {
        if (removedPropertyNames.Count == 0)
        {
            return;
        }

        TypeProvider? current = baseModel;
        while (current != null)
        {
            foreach (var property in current.Properties)
            {
                if (removedPropertyNames.Contains(property.Name) && property.Modifiers.HasFlag(MethodSignatureModifiers.Virtual))
                {
                    property.Update(modifiers: property.Modifiers & ~MethodSignatureModifiers.Virtual);
                }
            }
            current = GetBaseTypeProvider(current);
        }
    }
}

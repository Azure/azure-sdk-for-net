// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

        if (type is ModelProvider modelProvider && modelProvider is not SystemObjectModelProvider && ShouldUpdateInheritance(modelProvider))
        {
            UpdateRegularModelInheritance(modelProvider, updateSerialization: false);
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

        if (type is ModelProvider model && model is not SystemObjectModelProvider && ShouldUpdateInheritance(model))
        {
            UpdateRegularModelInheritance(model, updateSerialization: true);
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
    private Dictionary<ModelProvider, CSharpType?> _customBaseTypes = new();

    private static bool HasInheritableBase(ModelProvider model)
        => model.BaseModelProvider is not null || GetCustomBaseType(model) is not null;

    private bool ShouldUpdateInheritance(ModelProvider model)
        => HasInheritableBase(model) || _customBaseTypes.ContainsKey(model);

    private void UpdateRegularModelInheritance(ModelProvider model, bool updateSerialization)
    {
        var customBaseType = GetCachedCustomBaseType(model);

        if (_regularUpdated.Contains(model))
        {
            if (updateSerialization)
            {
                UpdateSerializationMethodModifiers(model, customBaseType);
            }
            return;
        }

        var basePropertyNames = EnumerateBaseModelProperties(model.BaseModelProvider, customBaseType);
        var removedPropertyNames = new HashSet<string>();
        var remainingProperties = new List<PropertyProvider>();

        foreach (var prop in model.Properties)
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

        if (model.BaseModelProvider is not null)
        {
            StripOrphanedVirtualModifiers(model.BaseModelProvider, removedPropertyNames);
        }

        // Reset cached constructors, serialization, and model factories so they do not keep
        // references to inherited ARM properties removed from the model surface.
        model.Update(name: model.Name, properties: remainingProperties.ToArray(), reset: true);

        _regularUpdated.Add(model);

        if (updateSerialization)
        {
            UpdateSerializationMethodModifiers(model, customBaseType);
        }
    }

    private static HashSet<string> EnumerateBaseModelProperties(ModelProvider? baseModel, CSharpType? customBaseType)
    {
        var basePropertyNames = new HashSet<string>(StringComparer.Ordinal);
        ModelProvider? currentModel = baseModel;
        while (currentModel != null)
        {
            foreach (var property in currentModel.Properties)
            {
                basePropertyNames.Add(property.Name);
            }
            foreach (var property in currentModel.CustomCodeView?.Properties ?? [])
            {
                basePropertyNames.Add(property.Name);
            }
            currentModel = currentModel.BaseModelProvider;
        }

        if (customBaseType is not null)
        {
            AddPropertiesFromCSharpType(customBaseType, basePropertyNames);
        }

        return basePropertyNames;
    }

    private static void AddPropertiesFromCSharpType(CSharpType baseType, HashSet<string> propertyNames)
    {
        var typeMap = ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap;
        if (typeMap.TryGetValue(baseType, out var provider) && provider is not null)
        {
            foreach (var property in provider.Properties)
            {
                propertyNames.Add(property.Name);
            }
            foreach (var property in provider.CustomCodeView?.Properties ?? [])
            {
                propertyNames.Add(property.Name);
            }

            if (provider is ModelProvider modelProvider)
            {
                foreach (var property in EnumerateBaseModelProperties(modelProvider.BaseModelProvider, GetCustomBaseType(modelProvider)))
                {
                    propertyNames.Add(property);
                }
            }
            else if (provider.BaseType is not null && !provider.BaseType.Equals(baseType))
            {
                AddPropertiesFromCSharpType(provider.BaseType, propertyNames);
            }
        }

        if (baseType.IsFrameworkType && baseType.FrameworkType is { } frameworkType)
        {
            foreach (var property in frameworkType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                propertyNames.Add(property.Name);
            }
        }
    }

    private static void UpdateSerializationMethodModifiers(ModelProvider model, CSharpType? customBaseType)
    {
        if (customBaseType is null)
        {
            return;
        }

        foreach (var method in model.SerializationProviders.SelectMany(p => p.Methods))
        {
            if (!IsSerializationCoreMethod(method.Signature.Name))
            {
                continue;
            }

            var modifiers = method.Signature.Modifiers & ~MethodSignatureModifiers.Virtual & ~MethodSignatureModifiers.New & ~MethodSignatureModifiers.Override;
            var shouldOverride = !TryGetInheritedSerializationMethod(customBaseType, method.Signature.Name, out var inheritedOverride)
                || inheritedOverride;
            modifiers |= shouldOverride ? MethodSignatureModifiers.Override : MethodSignatureModifiers.New;
            method.Signature.Update(modifiers: modifiers);
            method.Update(signature: method.Signature);
        }
    }

    private static CSharpType? GetCustomBaseType(ModelProvider model)
        => model.CustomCodeView?.BaseType ?? model.BaseType;

    private CSharpType? GetCachedCustomBaseType(ModelProvider model)
    {
        if (!_customBaseTypes.TryGetValue(model, out var customBaseType))
        {
            customBaseType = GetCustomBaseType(model);
            _customBaseTypes[model] = customBaseType;
        }

        return customBaseType;
    }

    private static bool TryGetInheritedSerializationMethod(CSharpType baseType, string methodName, out bool shouldOverride)
    {
        if (!IsSerializationCoreMethod(methodName))
        {
            shouldOverride = false;
            return false;
        }

        var typeMap = ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap;
        if (typeMap.TryGetValue(baseType, out var provider) && provider is not null)
        {
            var providerMethod = provider.Methods.FirstOrDefault(m => m.Signature.Name == methodName);
            if (providerMethod is not null)
            {
                shouldOverride = providerMethod.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Virtual)
                    || providerMethod.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Override);
                return true;
            }

            if (provider.BaseType is not null)
            {
                if (IsResourceDataType(provider.BaseType))
                {
                    shouldOverride = true;
                    return true;
                }

                return TryGetInheritedSerializationMethod(provider.BaseType, methodName, out shouldOverride);
            }
        }

        if (baseType.IsFrameworkType)
        {
            for (var frameworkType = baseType.FrameworkType; frameworkType is not null; frameworkType = frameworkType.BaseType)
            {
                var inheritedMethod = frameworkType
                    .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
                    .FirstOrDefault(m => m.Name == methodName);
                if (inheritedMethod is not null)
                {
                    shouldOverride = inheritedMethod.IsVirtual && !inheritedMethod.IsFinal;
                    return true;
                }
            }
        }

        shouldOverride = false;
        return false;
    }

    private static bool IsSerializationCoreMethod(string methodName)
        => methodName is "JsonModelWriteCore" or "JsonModelCreateCore" or "PersistableModelWriteCore" or "PersistableModelCreateCore";

    private static bool IsResourceDataType(CSharpType type)
        => type.Name is "ResourceData" or "TrackedResourceData"
            && type.Namespace is "Azure.ResourceManager.Models" or "Azure.ResourceManager.Resources.Models";

    private static void StripOrphanedVirtualModifiers(ModelProvider baseModel, HashSet<string> removedPropertyNames)
    {
        if (removedPropertyNames.Count == 0)
        {
            return;
        }

        ModelProvider? current = baseModel;
        while (current != null)
        {
            foreach (var property in current.Properties)
            {
                if (removedPropertyNames.Contains(property.Name) && property.Modifiers.HasFlag(MethodSignatureModifiers.Virtual))
                {
                    property.Update(modifiers: property.Modifiers & ~MethodSignatureModifiers.Virtual);
                }
            }
            current = current.BaseModelProvider;
        }
    }
}

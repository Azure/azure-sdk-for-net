// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Providers;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

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

        if (type?.BaseModelProvider is not null && type is not SystemObjectModelProvider)
        {
            UpdateRegularModelInheritance(type);
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

        if (type is ModelProvider model3 && model3.BaseModelProvider is not null && model3 is not SystemObjectModelProvider)
        {
            UpdateRegularModelInheritance(model3);
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

        var baseProperties = EnumerateBaseModelProperties(model.BaseModelProvider!);
        var removedPropertyNames = new HashSet<string>();
        var remainingProperties = new List<PropertyProvider>();

        foreach (var prop in model.Properties)
        {
            // Only remove true C# duplicate/shadowing properties. Some services expose
            // public SDK properties with distinct CLR names but inherited ARM wire names
            // (for example a model-specific "DefaultName" serialized as "name").
            // Removing those by wire name would be a public API breaking change.
            if (prop.Modifiers.HasFlag(MethodSignatureModifiers.New)
                || baseProperties.Names.Contains(prop.Name)
                || IsCanonicalDuplicateWireProperty(prop, baseProperties.WirePaths))
            {
                removedPropertyNames.Add(prop.Name);
            }
            else
            {
                remainingProperties.Add(prop);
            }
        }

        StripOrphanedVirtualModifiers(model.BaseModelProvider!, removedPropertyNames);
        // Reset cached constructors, serialization, and model factories so they do not keep
        // references to inherited ARM properties removed from the model surface.
        model.Update(name: model.Name, properties: remainingProperties.ToArray(), reset: true);

        _regularUpdated.Add(model);
    }

    private static BaseModelPropertyInfo EnumerateBaseModelProperties(ModelProvider baseModel)
    {
        var basePropertyNames = new HashSet<string>(StringComparer.Ordinal);
        var baseWirePaths = new HashSet<string>(StringComparer.Ordinal);
        ModelProvider? currentModel = baseModel;
        while (currentModel != null)
        {
            if (currentModel is SystemObjectModelProvider systemObjectModelProvider)
            {
                AddInheritedSystemObjectProperties(systemObjectModelProvider, basePropertyNames, baseWirePaths);
            }

            foreach (var property in currentModel.Properties.Concat(currentModel.CustomCodeView?.Properties ?? []))
            {
                basePropertyNames.Add(property.Name);
                if (TryGetWirePath(property, out var wirePath))
                {
                    baseWirePaths.Add(wirePath);
                }
            }
            currentModel = currentModel.BaseModelProvider;
        }
        return new BaseModelPropertyInfo(basePropertyNames, baseWirePaths);
    }

    private static void AddInheritedSystemObjectProperties(SystemObjectModelProvider systemObjectModelProvider, HashSet<string> basePropertyNames, HashSet<string> baseWirePaths)
    {
        var properties = systemObjectModelProvider is InheritableSystemObjectModelProvider inheritableSystemObjectModelProvider
            ? inheritableSystemObjectModelProvider.InheritedProperties
            : GetSystemObjectModelProperties(systemObjectModelProvider);

        foreach (var property in properties)
        {
            basePropertyNames.Add(property.Name);
            if (TryGetWirePath(property, out var wirePath))
            {
                baseWirePaths.Add(wirePath);
            }
        }
    }

    private static IReadOnlyList<PropertyProvider> GetSystemObjectModelProperties(SystemObjectModelProvider systemObjectModelProvider)
    {
        if (ManagementClientGenerator.Instance.SourceInputModel.FindForTypeInCustomization(
                systemObjectModelProvider.SystemType.Namespace,
                systemObjectModelProvider.SystemType.Name,
                declaringTypeName: null,
                includeReferencedAssemblies: true) is { } referencedType)
        {
            return [.. systemObjectModelProvider.Properties, .. referencedType.Properties];
        }

        return systemObjectModelProvider.Properties;
    }

    private static bool IsCanonicalDuplicateWireProperty(PropertyProvider property, HashSet<string> baseWirePaths)
    {
        if (!TryGetWirePath(property, out var wirePath) || !baseWirePaths.Contains(wirePath))
        {
            return false;
        }

        return property.Name == wirePath.ToIdentifierName();
    }

    private static bool TryGetWirePath(PropertyProvider property, out string wirePath)
    {
        if (property.WireInfo is null)
        {
            return TryGetWirePathFromAttribute(property, out wirePath);
        }

        if (property is not FlattenedPropertyProvider)
        {
            wirePath = property.WireInfo.SerializedName;
            return true;
        }

        var propertyHierarchy = new List<PropertyProvider>();
        var current = property;
        while (current is FlattenedPropertyProvider flattenedProperty)
        {
            propertyHierarchy.Add(flattenedProperty.FlattenedProperty);
            current = flattenedProperty.OriginalProperty;
        }
        propertyHierarchy.Add(current);

        wirePath = string.Join('.', propertyHierarchy.Select(p => p.WireInfo!.SerializedName));
        return true;
    }

    private static bool TryGetWirePathFromAttribute(PropertyProvider property, out string wirePath)
    {
        foreach (var attribute in property.Attributes)
        {
            if (attribute.Type.Name is "WirePath" or "WirePathAttribute" &&
                attribute.Arguments is [Microsoft.TypeSpec.Generator.Expressions.LiteralExpression { Literal: string value }, ..])
            {
                wirePath = value;
                return true;
            }
        }

        wirePath = string.Empty;
        return false;
    }

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

    private sealed record BaseModelPropertyInfo(HashSet<string> Names, HashSet<string> WirePaths);
}

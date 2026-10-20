// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Primitives;
using Azure.ResourceManager.Models;
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

        RestoreMissingFrameworkWireMetadata(model.BaseModelProvider!);
        var basePropertyNames = EnumerateBaseModelProperties(model.BaseModelProvider!);
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

        StripOrphanedVirtualModifiers(model.BaseModelProvider!, removedPropertyNames);
        // Reset cached constructors, serialization, and model factories so they do not keep
        // references to inherited ARM properties removed from the model surface.
        model.Update(name: model.Name, properties: remainingProperties.ToArray(), reset: true);

        _regularUpdated.Add(model);
    }

    private static void RestoreMissingFrameworkWireMetadata(ModelProvider baseModel)
    {
        for (ModelProvider? current = baseModel; current is not null; current = current.BaseModelProvider)
        {
            if (current is not SystemObjectModelProvider systemType ||
                !KnownManagementTypes.TryGetInheritableSystemType(systemType.SystemType, out _))
            {
                continue;
            }

            var properties = new List<PropertyProvider>();
            var changed = false;
            foreach (var property in systemType.Properties)
            {
                if (property.WireInfo is not null || !TryGetFrameworkWireMetadata(property, out var wireInfo))
                {
                    properties.Add(property);
                    continue;
                }

                // Historical symbol properties are shared. Clone rather than attaching model-local
                // fallback metadata to them; current input metadata always wins when it exists.
                properties.Add(new PropertyProvider(
                    property.Description, property.Modifiers, property.Type, property.Name, property.Body, systemType,
                    property.ExplicitInterface, wireInfo, property.IsRef, property.Attributes, property.Suppressions));
                changed = true;
            }

            if (changed)
            {
                // Rebuild canonical properties and constructor parameter links before the derived
                // model rebuilds its own constructor and serializer below.
                systemType.Update(properties: properties, reset: true);
            }
        }
    }

    private static bool TryGetFrameworkWireMetadata(PropertyProvider property, out PropertyWireInformation? wireInfo)
    {
        (string? name, Type? type, bool readOnly) = property.Name switch
        {
            nameof(ResourceData.Id) => ("id", typeof(ResourceIdentifier), true),
            nameof(ResourceData.Name) => ("name", typeof(string), true),
            nameof(ResourceData.ResourceType) => ("type", typeof(ResourceType), true),
            nameof(ResourceData.SystemData) => ("systemData", typeof(SystemData), true),
            nameof(TrackedResourceData.Location) => ("location", typeof(AzureLocation), false),
            nameof(TrackedResourceData.Tags) => ("tags", typeof(IDictionary<string, string>), false),
            _ => (null, null, false)
        };
        wireInfo = null;
        if (name is null || type is null || !property.Type.WithNullable(false).Equals(new CSharpType(type)))
        {
            return false;
        }

        // An inherited ARM envelope retains the same wire fields as an explicitly customized
        // framework base, even when the current input does not repeat those fields.
        wireInfo = new PropertyWireInformation(
            property.SerializationFormat, isRequired: false, isReadOnly: readOnly, isNullable: false,
            isDiscriminator: false, serializedName: name, isHttpMetadata: false, isApiVersion: false);
        return true;
    }

    private static HashSet<string> EnumerateBaseModelProperties(ModelProvider baseModel)
    {
        var basePropertyNames = new HashSet<string>(StringComparer.Ordinal);
        ModelProvider? currentModel = baseModel;
        while (currentModel != null)
        {
            foreach (var property in currentModel.Properties)
            {
                basePropertyNames.Add(property.Name);
            }
            currentModel = currentModel.BaseModelProvider;
        }
        return basePropertyNames;
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
}

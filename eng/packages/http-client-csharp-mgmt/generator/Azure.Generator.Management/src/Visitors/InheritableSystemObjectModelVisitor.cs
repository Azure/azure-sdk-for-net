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

namespace Azure.Generator.Management.Visitors;

internal class InheritableSystemObjectModelVisitor : ScmLibraryVisitor
{
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
        if (type is ModelFactoryProvider modelFactory)
        {
            UpdateModelFactory(modelFactory);
        }

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

    private static void UpdateModelFactory(ModelFactoryProvider modelFactory)
    {
        var methods = new List<MethodProvider>();
        foreach (var method in modelFactory.Methods)
        {
            var returnType = method.Signature.ReturnType;
            if (returnType is not null && KnownManagementTypes.IsKnownManagementType(returnType))
            {
                continue;
            }
            methods.Add(method);
        }
        modelFactory.Update(methods: methods);
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

        var baseProperties = EnumerateRegularBaseModelProperties(model.BaseModelProvider!);
        var removedPropertyNames = new HashSet<string>();
        var remainingProperties = new List<PropertyProvider>();

        foreach (var prop in model.Properties)
        {
            var serializedName = prop.WireInfo?.SerializedName;
            string? inheritedPropertyName = null;
            var matchesInheritedWireName = serializedName is not null &&
                baseProperties.SerializedNameToPropertyName.TryGetValue(serializedName, out inheritedPropertyName);
            if (prop.Modifiers.HasFlag(MethodSignatureModifiers.New)
                || baseProperties.PropertyNames.Contains(prop.Name)
                || matchesInheritedWireName)
            {
                removedPropertyNames.Add(prop.Name);
                if (inheritedPropertyName is not null)
                {
                    removedPropertyNames.Add(inheritedPropertyName);
                }
            }
            else
            {
                remainingProperties.Add(prop);
            }
        }

        StripOrphanedVirtualModifiers(model.BaseModelProvider!, removedPropertyNames);
        model.Update(properties: remainingProperties.ToArray());

        _regularUpdated.Add(model);
    }

    private static (HashSet<string> PropertyNames, Dictionary<string, string> SerializedNameToPropertyName) EnumerateRegularBaseModelProperties(ModelProvider baseModel)
    {
        var basePropertyNames = new HashSet<string>(StringComparer.Ordinal);
        var baseSerializedNameToPropertyName = new Dictionary<string, string>(StringComparer.Ordinal);
        ModelProvider? currentModel = baseModel;
        while (currentModel != null)
        {
            foreach (var property in currentModel.Properties)
            {
                basePropertyNames.Add(property.Name);
                if (property.WireInfo?.SerializedName is { } serializedName)
                {
                    baseSerializedNameToPropertyName.TryAdd(serializedName, property.Name);
                }
            }
            currentModel = currentModel.BaseModelProvider;
        }
        return (basePropertyNames, baseSerializedNameToPropertyName);
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

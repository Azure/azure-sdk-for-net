// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Providers;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

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

        if (type is ModelProvider modelProvider && modelProvider is not SystemObjectModelProvider)
        {
            EnsureInheritableSystemModel(modelProvider);
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

        if (type is ModelProvider model3 && model3 is not SystemObjectModelProvider)
        {
            EnsureInheritableSystemModel(model3);
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

    internal static void EnsureInheritableSystemModel(ModelProvider model)
    {
        EnsureCustomCodeBaseModelProvider(model);
        if (model.BaseModelProvider is not null)
        {
            UpdateRegularModelInheritance(model);
            EnsureSystemBaseConstructors(model);
            EnsureSystemBaseSerializationOverride(model);
        }
    }

    private static void EnsureCustomCodeBaseModelProvider(ModelProvider model)
    {
        var customCodeBaseType = model.CustomCodeView?.BaseType;
        if (customCodeBaseType is null)
        {
            return;
        }

        if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(customCodeBaseType, out var baseTypeProvider)
            && baseTypeProvider is SystemObjectModelProvider systemBaseProvider)
        {
            ApplySystemBaseProvider(model, customCodeBaseType, systemBaseProvider);
            return;
        }

        if (!TryGetFrameworkResourceDataType(customCodeBaseType, out var frameworkBaseType))
        {
            return;
        }

        if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(frameworkBaseType, out var frameworkBaseTypeProvider)
            && frameworkBaseTypeProvider is SystemObjectModelProvider frameworkSystemBaseProvider)
        {
            ApplySystemBaseProvider(model, customCodeBaseType, frameworkSystemBaseProvider);
            return;
        }

        if (model is ResourceDataModelProvider resourceDataModel
            && resourceDataModel.InputModel.BaseModel is not null)
        {
            var resourceSystemBaseProvider = new SystemObjectModelProvider(frameworkBaseType, resourceDataModel.InputModel.BaseModel);
            ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap[frameworkBaseType] =
                resourceSystemBaseProvider;
            ApplySystemBaseProvider(model, customCodeBaseType, resourceSystemBaseProvider);
        }
    }

    private static readonly FieldInfo? _baseModelProviderField = typeof(ModelProvider).GetField("_baseModelProvider", BindingFlags.NonPublic | BindingFlags.Instance);
    private static readonly FieldInfo? _baseTypeProviderField = typeof(ModelProvider).GetField("_baseTypeProvider", BindingFlags.NonPublic | BindingFlags.Instance);

    private static void ApplySystemBaseProvider(ModelProvider model, CSharpType customCodeBaseType, SystemObjectModelProvider systemBaseProvider)
    {
        ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap[customCodeBaseType] = systemBaseProvider;
        _baseModelProviderField?.SetValue(model, systemBaseProvider);
        _baseTypeProviderField?.SetValue(model, systemBaseProvider);
    }

    private static bool TryGetFrameworkResourceDataType(CSharpType type, out CSharpType frameworkType)
    {
        if (type.AreNamesEqual(typeof(TrackedResourceData)))
        {
            frameworkType = typeof(TrackedResourceData);
            return true;
        }

        frameworkType = null!;
        return false;
    }

    private static void UpdateRegularModelInheritance(ModelProvider model)
    {
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
        if (removedPropertyNames.Count > 0)
        {
            // Reset cached constructors, serialization, and model factories so they do not keep
            // references to inherited ARM properties removed from the model surface.
            model.Update(name: model.Name, properties: remainingProperties.ToArray(), reset: true);
        }
    }

    private static void EnsureSystemBaseSerializationOverride(ModelProvider model)
    {
        if (model.BaseModelProvider is not SystemObjectModelProvider)
        {
            return;
        }

        foreach (var serialization in model.SerializationProviders.OfType<MrwSerializationTypeDefinition>())
        {
            foreach (var method in serialization.Methods.Where(m => m.Signature.Name == "JsonModelWriteCore"))
            {
                var modifiers = method.Signature.Modifiers;
                if (modifiers.HasFlag(MethodSignatureModifiers.Override))
                {
                    continue;
                }

                modifiers &= ~MethodSignatureModifiers.Virtual;
                modifiers |= MethodSignatureModifiers.Override;
                method.Signature.Update(modifiers: modifiers);

                var arguments = method.Signature.Parameters.Select(p => p.AsArgument()).ToArray();
                var bodyStatements = new List<MethodBodyStatement> { Base.Invoke(method.Signature.Name, arguments).Terminate() };
                if (method.BodyStatements is not null)
                {
                    bodyStatements.Add(method.BodyStatements);
                }

                method.Update(
                    signature: method.Signature,
                    bodyStatements: bodyStatements);
            }
        }
    }

    private static void EnsureSystemBaseConstructors(ModelProvider model)
    {
        if (model.BaseModelProvider is not SystemObjectModelProvider
            || model.BaseType is null
            || !model.BaseType.AreNamesEqual(typeof(TrackedResourceData)))
        {
            return;
        }

        foreach (var constructor in model.Constructors)
        {
            var signature = constructor.Signature;
            var initializer = signature.Initializer;
            if (initializer is not { IsBase: true } || initializer.Arguments.Count != 5)
            {
                continue;
            }

            var arguments = initializer.Arguments.ToList();
            if (signature.Parameters.Count >= 5
                && signature.Parameters[3].Name == "location"
                && signature.Parameters[4].Name == "tags")
            {
                arguments = [arguments[0], arguments[1], arguments[2], Default, arguments[4], arguments[3]];
            }
            else
            {
                arguments.Insert(3, Default);
            }
            var newInitializer = new ConstructorInitializer(initializer.IsBase, arguments);
            var newSignature = new ConstructorSignature(signature.Type, signature.Description, signature.Modifiers, signature.Parameters, signature.Attributes, newInitializer);
            constructor.Update(signature: newSignature);
        }
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

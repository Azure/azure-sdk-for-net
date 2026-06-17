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
using Microsoft.TypeSpec.Generator.Input.Extensions;
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

        if (!TryGetFrameworkResourceDataType(customCodeBaseType, out var frameworkBaseType))
        {
            if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(customCodeBaseType, out var baseTypeProvider)
                && baseTypeProvider is SystemObjectModelProvider systemBaseProvider)
            {
                ApplySystemBaseProvider(model, customCodeBaseType, systemBaseProvider);
            }
            return;
        }

        if (model is ResourceDataModelProvider resourceDataModel
            && resourceDataModel.InputModel.BaseModel is not null)
        {
            // Custom code may ask a generated resource model to inherit the framework ResourceData/TrackedResourceData
            // type instead of the service-defined TypeSpec base. Keep the service-defined base model metadata so the
            // inherited ARM properties still serialize/deserialize, but do not register this model-specific provider
            // globally where it could replace unrelated resource bases.
            if (IsPolymorphic(resourceDataModel.InputModel))
            {
                return;
            }

            var resourceSystemBaseProvider = new SystemObjectModelProvider(frameworkBaseType, resourceDataModel.InputModel.BaseModel);
            ApplySystemBaseProvider(model, customCodeBaseType, resourceSystemBaseProvider, addTypeMapEntry: false);
            return;
        }

        if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(frameworkBaseType, out var frameworkBaseTypeProvider)
            && frameworkBaseTypeProvider is SystemObjectModelProvider frameworkSystemBaseProvider)
        {
            ApplySystemBaseProvider(model, customCodeBaseType, frameworkSystemBaseProvider);
        }
    }

    private static readonly FieldInfo? _baseModelProviderField = typeof(ModelProvider).GetField("_baseModelProvider", BindingFlags.NonPublic | BindingFlags.Instance);
    private static readonly FieldInfo? _baseTypeProviderField = typeof(ModelProvider).GetField("_baseTypeProvider", BindingFlags.NonPublic | BindingFlags.Instance);

    private static void ApplySystemBaseProvider(ModelProvider model, CSharpType customCodeBaseType, SystemObjectModelProvider systemBaseProvider, bool addTypeMapEntry = true)
    {
        if (addTypeMapEntry)
        {
            ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap[customCodeBaseType] = systemBaseProvider;
        }
        _baseModelProviderField?.SetValue(model, systemBaseProvider);
        _baseTypeProviderField?.SetValue(model, systemBaseProvider);
    }

    private static bool IsPolymorphic(InputModelType model)
        => model.DiscriminatorProperty is not null
            || model.DerivedModels.Count > 0
            || model.DiscriminatedSubtypes.Count > 0;

    private static bool TryGetFrameworkResourceDataType(CSharpType type, out CSharpType frameworkType)
    {
        if (KnownManagementTypes.TryGetInheritableSystemType(type, out var knownFrameworkType))
        {
            frameworkType = knownFrameworkType;
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
        if (model.BaseModelProvider is not SystemObjectModelProvider systemBaseModel)
        {
            return;
        }

        foreach (var serialization in model.SerializationProviders.OfType<MrwSerializationTypeDefinition>())
        {
            foreach (var method in serialization.Methods)
            {
                if (method.Signature.Name is "PersistableModelCreateCore" or "JsonModelCreateCore"
                    && method.Signature.ReturnType is not null
                    && !method.Signature.ReturnType.AreNamesEqual(systemBaseModel.SystemType))
                {
                    method.Signature.Update(returnType: systemBaseModel.SystemType);
                    continue;
                }

                if (method.Signature.Name != "JsonModelWriteCore")
                {
                    continue;
                }

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
                    bodyStatements.AddRange(method.BodyStatements);
                }

                method.Update(
                    signature: method.Signature,
                    bodyStatements: bodyStatements);
            }
        }
    }

    private static void EnsureSystemBaseConstructors(ModelProvider model)
    {
        if (model.BaseModelProvider is not SystemObjectModelProvider systemBaseModel
            || model.BaseType is null
            || !KnownManagementTypes.TryGetInheritableSystemType(model.BaseType, out _))
        {
            return;
        }

        var baseProperties = EnumerateBaseModelPropertiesInOrder(systemBaseModel);
        // The generated base initializer was built for the service-defined base model. When custom code
        // replaces that base with a framework model, rebuild the initializer in the framework constructor order.
        var baseConstructorPropertyNames = GetFrameworkConstructorPropertyNames(systemBaseModel.SystemType);
        if (baseProperties.Count == 0 || baseConstructorPropertyNames.Count == 0)
        {
            return;
        }

        foreach (var constructor in model.Constructors)
        {
            var signature = constructor.Signature;
            var initializer = signature.Initializer;
            if (initializer is not { IsBase: true })
            {
                continue;
            }
            // Empty initializers are intentionally left alone.
            if (initializer.Arguments.Count == 0)
            {
                continue;
            }

            var argumentsByPropertyName = BuildConstructorArgumentMap(baseProperties, signature.Parameters, initializer.Arguments);
            var arguments = BuildBaseConstructorArguments(baseConstructorPropertyNames, baseProperties, argumentsByPropertyName);

            var newInitializer = new ConstructorInitializer(initializer.IsBase, arguments);
            var newSignature = new ConstructorSignature(signature.Type, signature.Description, signature.Modifiers, signature.Parameters, signature.Attributes, newInitializer);
            constructor.Update(signature: newSignature);
        }
    }

    private static IReadOnlyList<string> GetFrameworkConstructorPropertyNames(CSharpType baseType)
    {
        if (!baseType.IsFrameworkType)
        {
            return [];
        }

        // SystemObjectModelProvider properties come from the service-defined base model, whose property order
        // can differ from the actual framework type constructor. Reflection gives the constructor shape that
        // the emitted C# must call.
        return baseType.FrameworkType
            .GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .OrderByDescending(c => c.GetParameters().Length)
            .Select(c => c.GetParameters()
                .Select(p => p.Name?.ToIdentifierName())
                .Where(name => name is not null)
                .Cast<string>()
                .ToArray())
            .FirstOrDefault(parameters => parameters.Length > 0) ?? [];
    }

    private static IReadOnlyList<ValueExpression> BuildBaseConstructorArguments(
        IReadOnlyList<string> targetPropertyNames,
        IReadOnlyList<PropertyProvider> sourceProperties,
        IReadOnlyDictionary<string, ValueExpression> argumentsByPropertyName)
    {
        var arguments = new List<ValueExpression>(targetPropertyNames.Count);
        var usedSourcePropertyNames = new HashSet<string>(StringComparer.Ordinal);
        var sourceIndex = 0;

        for (int i = 0; i < targetPropertyNames.Count; i++)
        {
            var targetPropertyName = targetPropertyNames[i];
            if (argumentsByPropertyName.TryGetValue(targetPropertyName, out var argument))
            {
                arguments.Add(argument);
                usedSourcePropertyNames.Add(targetPropertyName);
                continue;
            }

            while (sourceIndex < sourceProperties.Count
                   && (usedSourcePropertyNames.Contains(sourceProperties[sourceIndex].Name)
                       || !argumentsByPropertyName.ContainsKey(sourceProperties[sourceIndex].Name)))
            {
                sourceIndex++;
            }

            if (sourceIndex < sourceProperties.Count)
            {
                var sourcePropertyName = sourceProperties[sourceIndex].Name;
                // Prefer exact target-property matches that appear later. Only use a positional bridge when
                // source metadata identifies the known ARM resource type wire field for the framework ResourceType slot.
                if (!targetPropertyNames.Skip(i + 1).Contains(sourcePropertyName, StringComparer.Ordinal)
                    && IsResourceTypeConstructorBridge(targetPropertyName, sourceProperties[sourceIndex]))
                {
                    arguments.Add(argumentsByPropertyName[sourcePropertyName]);
                    usedSourcePropertyNames.Add(sourcePropertyName);
                    sourceIndex++;
                    continue;
                }
            }

            arguments.Add(Default);
        }

        return arguments;
    }

    // ResourceData exposes the ARM wire field "type" as the CLR property ResourceType. This is the only
    // positional bridge we allow when rebuilding framework base constructor calls; other missing arguments
    // must stay default rather than accidentally consuming unrelated service-defined fields.
    private static bool IsResourceTypeConstructorBridge(string targetPropertyName, PropertyProvider sourceProperty)
        => targetPropertyName == nameof(ResourceData.ResourceType)
            && sourceProperty.WireInfo?.SerializedName == "type";

    private static Dictionary<string, ValueExpression> BuildConstructorArgumentMap(IReadOnlyList<PropertyProvider> baseProperties, IReadOnlyList<ParameterProvider> parameters, IReadOnlyList<ValueExpression> arguments)
    {
        var basePropertiesByWireName = baseProperties
            .Where(p => p.WireInfo is not null)
            .GroupBy(p => p.WireInfo!.SerializedName, StringComparer.Ordinal)
            .ToDictionary(g => g.Key, g => g.First(), StringComparer.Ordinal);
        var basePropertiesByName = baseProperties.ToDictionary(p => p.Name, StringComparer.Ordinal);
        var argumentsByPropertyName = new Dictionary<string, ValueExpression>(StringComparer.Ordinal);
        foreach (var parameter in parameters)
        {
            if (TryGetBaseProperty(parameter, basePropertiesByName, basePropertiesByWireName, out var property))
            {
                argumentsByPropertyName[property.Name] = parameter.AsArgument();
            }
        }

        return argumentsByPropertyName;
    }

    private static bool TryGetBaseProperty(
        ParameterProvider parameter,
        IReadOnlyDictionary<string, PropertyProvider> basePropertiesByName,
        IReadOnlyDictionary<string, PropertyProvider> basePropertiesByWireName,
        out PropertyProvider property)
    {
        // WireInfo is the most reliable link between a constructor parameter and its inherited property,
        // including cases where the CLR property name differs from the wire name.
        if (parameter.WireInfo is not null
            && basePropertiesByWireName.TryGetValue(parameter.WireInfo.SerializedName, out property!))
        {
            return true;
        }

        var parameterName = parameter.Name.TrimStart('@');
        // Some generated constructor parameters may be escaped C# keywords (for example @type) or may not carry
        // WireInfo, so fall back to the unescaped wire name and then the generated CLR identifier.
        if (basePropertiesByWireName.TryGetValue(parameterName, out property!))
        {
            return true;
        }

        return basePropertiesByName.TryGetValue(parameterName.ToIdentifierName(), out property!);
    }

    private static HashSet<string> EnumerateBaseModelProperties(ModelProvider baseModel)
    {
        var basePropertyNames = new HashSet<string>(StringComparer.Ordinal);
        var visited = new HashSet<ModelProvider>();
        ModelProvider? currentModel = baseModel;
        while (currentModel != null && visited.Add(currentModel))
        {
            if (currentModel is SystemObjectModelProvider systemModel && systemModel.SystemType.IsFrameworkType)
            {
                foreach (var property in systemModel.SystemType.FrameworkType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    basePropertyNames.Add(property.Name);
                }
            }

            foreach (var property in currentModel.Properties)
            {
                basePropertyNames.Add(property.Name);
            }
            currentModel = currentModel.BaseModelProvider;
        }
        return basePropertyNames;
    }

    private static IReadOnlyList<PropertyProvider> EnumerateBaseModelPropertiesInOrder(ModelProvider baseModel)
    {
        var properties = new List<PropertyProvider>();
        var propertyNames = new HashSet<string>(StringComparer.Ordinal);

        foreach (var model in EnumerateBaseModels(baseModel).Reverse())
        {
            foreach (var property in model.Properties)
            {
                if (propertyNames.Add(property.Name))
                {
                    properties.Add(property);
                }
            }
        }

        return properties;
    }

    private static IEnumerable<ModelProvider> EnumerateBaseModels(ModelProvider baseModel)
    {
        var visited = new HashSet<ModelProvider>();
        ModelProvider? currentModel = baseModel;
        while (currentModel != null && visited.Add(currentModel))
        {
            yield return currentModel;
            currentModel = currentModel.BaseModelProvider;
        }
    }

    private static void StripOrphanedVirtualModifiers(ModelProvider baseModel, HashSet<string> removedPropertyNames)
    {
        if (removedPropertyNames.Count == 0)
        {
            return;
        }

        ModelProvider? current = baseModel;
        var visited = new HashSet<ModelProvider>();
        while (current != null && visited.Add(current))
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

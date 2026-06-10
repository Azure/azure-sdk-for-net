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
    // TODO: Remove this visitor once MTG fully supports inheritable system model replacements.
    // See https://github.com/microsoft/typespec/issues/10787.
    protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
    {
        if (type is SystemObjectModelProvider systemType)
        {
            UpdateNamespace(systemType);
            EnsureFrameworkTypeRegistered(systemType);
        }

        TryRegisterCustomBaseModel(type);

        if (type is not null && (type.BaseModelProvider is not null || ResolveMappedBaseProvider(type) is not null) && type is not SystemObjectModelProvider)
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

        TryRegisterCustomBaseModel(type as ModelProvider);

        if (type is ModelProvider model3 && (model3.BaseModelProvider is not null || ResolveMappedBaseProvider(model3) is not null) && model3 is not SystemObjectModelProvider)
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

    private static void TryRegisterCustomBaseModel(ModelProvider? model)
    {
        if (model?.CustomCodeView?.BaseType is not { } baseType)
        {
            return;
        }

        var typeMap = ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap;
        if (typeMap.ContainsKey(baseType))
        {
            return;
        }

        var customBase = ManagementClientGenerator.Instance.SourceInputModel.FindForTypeInCustomization(baseType.Namespace, baseType.Name, null);
        if (customBase is not null)
        {
            typeMap[baseType] = customBase is ModelProvider customBaseModel ? customBaseModel : new CustomCodeModelProvider(customBase);
            model.Update(name: model.Name, reset: true);
        }
    }

    private HashSet<ModelProvider> _regularUpdated = new();

    private void UpdateRegularModelInheritance(ModelProvider model)
    {
        if (_regularUpdated.Contains(model))
        {
            return;
        }

        var basePropertyNames = EnumerateBaseTypeProperties(model.BaseModelProvider ?? ResolveMappedBaseProvider(model));
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
    }

    private static HashSet<string> EnumerateBaseTypeProperties(TypeProvider? baseType)
    {
        var basePropertyNames = new HashSet<string>(StringComparer.Ordinal);
        TypeProvider? currentModel = baseType;
        while (currentModel != null)
        {
            foreach (var property in currentModel.Properties)
            {
                basePropertyNames.Add(property.Name);
            }
            currentModel = currentModel is ModelProvider model ? model.BaseModelProvider : ResolveMappedBaseProvider(currentModel);
        }
        return basePropertyNames;
    }

    private static TypeProvider? ResolveMappedBaseProvider(TypeProvider type)
    {
        return type.BaseType is { } baseType
            && ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(baseType, out var provider)
                ? provider
                : null;
    }

    private sealed class CustomCodeModelProvider : ModelProvider
    {
        private readonly TypeProvider _customCodeView;

        public CustomCodeModelProvider(TypeProvider customCodeView)
            : base(CreateInputModel(customCodeView))
        {
            _customCodeView = customCodeView;
        }

        protected override string BuildName() => _customCodeView.Name;

        protected override string BuildNamespace() => _customCodeView.Type.Namespace;

        protected override string BuildRelativeFilePath() => _customCodeView.RelativeFilePath;

        protected override CSharpType? BuildBaseType() => _customCodeView.BaseType;

        protected override PropertyProvider[] BuildProperties()
            => [.. _customCodeView.Properties.Select(CloneProperty)];

        protected override ConstructorProvider[] BuildConstructors() => _customCodeView.Constructors.ToArray();

        protected override MethodProvider[] BuildMethods() => _customCodeView.Methods.ToArray();

        private static InputModelType CreateInputModel(TypeProvider customCodeView)
            => new(
                customCodeView.Name,
                customCodeView.Type.Namespace,
                $"{customCodeView.Type.Namespace}.{customCodeView.Name}",
                "public",
                null,
                null,
                null,
                InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                [.. customCodeView.Properties.Select(CreateInputProperty).OfType<InputModelProperty>()],
                null,
                [],
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);

        private static InputModelProperty? CreateInputProperty(PropertyProvider property)
        {
            var serializedName = GetResourceMetadataSerializedName(property.Name);
            return serializedName is null
                ? null
                : new InputModelProperty(
                    property.Name,
                    property.Description?.ToString(),
                    property.Description?.ToString(),
                    InputPrimitiveType.String,
                    false,
                    true,
                    "public",
                    false,
                    serializedName,
                    false,
                    false,
                    null,
                    new InputSerializationOptions(),
                    null);
        }

        private PropertyProvider CloneProperty(PropertyProvider property)
        {
            var wireInfo = property.WireInfo ?? CreateResourceMetadataWireInfo(property);
            return new PropertyProvider(
                property.Description,
                property.Modifiers,
                property.Type,
                property.Name,
                new AutoPropertyBody(false),
                this,
                property.ExplicitInterface,
                wireInfo,
                property.IsRef,
                property.Attributes);
        }

        private static PropertyWireInformation? CreateResourceMetadataWireInfo(PropertyProvider property)
        {
            var serializedName = GetResourceMetadataSerializedName(property.Name);
            return serializedName is null
                ? null
                : new PropertyWireInformation(SerializationFormat.Default, false, true, property.Type.IsNullable, false, serializedName, false, false);
        }

        private static string? GetResourceMetadataSerializedName(string propertyName)
            => propertyName switch
            {
                "Id" => "id",
                "Name" => "name",
                "ResourceType" => "type",
                _ => null
            };
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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace Azure.Generator.Management.Visitors;

// TODO: Refactor or remove InheritableSystemObjectModelVisitor once SystemObjectModelProvider in MTG
// natively handles property filtering, serialization modifiers, and constructor updates.
internal class InheritableSystemObjectModelVisitor : ScmLibraryVisitor
{
    protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
    {
        if (type is SystemObjectModelProvider systemType)
        {
            UpdateNamespace(systemType);
            EnsureFrameworkTypeRegistered(systemType);
        }

        if (type is not SystemObjectModelProvider && type?.BaseModelProvider is SystemObjectModelProvider baseSystemType)
        {
            // Defer serialization update for discriminated models to avoid infinite recursion.
            // Accessing serializationTypeDefinition.Methods triggers building DerivedModels ->
            // CreateModel for derived types whose base model is not yet cached in TypeFactory.
            // Non-discriminated models must NOT defer because UpdateSerialization accesses .Methods
            // which lazily generates serialization code that depends on the model's pre-update state
            // (before properties and fields are modified later in Update).
            Update(baseSystemType, type, deferSerialization: model.DiscriminatorProperty != null);
        }
        else if (type is not SystemObjectModelProvider && type is not null && TryGetCustomInheritableSystemBase(type, out var customBaseClrType))
        {
            // Handle custom code overriding base type to a different known inheritable system type.
            // e.g., spec says ProxyResource (→ ResourceData) but custom code says : TrackedResourceData
            UpdateWithClrBase(customBaseClrType, type);
        }
        else if (type?.BaseModelProvider is not null && type is not SystemObjectModelProvider)
        {
            // Handle regular model inheritance where a non-system model extends another non-system model.
            // This fixes duplicate property generation when TypeSpec models redefine base model properties
            // (e.g., to add default values or change descriptions). Without this, properties with the 'new'
            // modifier would generate duplicates causing C# compilation errors.
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

        if (type is ModelProvider model && model is not SystemObjectModelProvider && model.BaseModelProvider is SystemObjectModelProvider baseSystemType)
        {
            Update(baseSystemType, model);
        }
        else if (type is ModelProvider model2 && model2 is not SystemObjectModelProvider && TryGetCustomInheritableSystemBase(model2, out var customBaseClrType))
        {
            UpdateWithClrBase(customBaseClrType, model2);
        }
        else if (type is ModelProvider model3 && model3.BaseModelProvider is not null && model3 is not SystemObjectModelProvider)
        {
            // Handle regular model inheritance where a non-system model extends another non-system model.
            // This fixes duplicate property generation when TypeSpec models redefine base model properties
            // (e.g., to add default values or change descriptions). Without this, properties with the 'new'
            // modifier would generate duplicates causing C# compilation errors.
            UpdateRegularModelInheritance(model3);
        }

        // Apply deferred serialization updates that were postponed from PreVisitModel
        // for discriminated models only (see comment in PreVisitModel).
        if (type is ModelProvider pendingModel && _pendingSerialization.Remove(pendingModel))
        {
            UpdateSerialization(pendingModel);
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

    private HashSet<ModelProvider> _updated = new();
    private HashSet<ModelProvider> _regularUpdated = new();
    private HashSet<ModelProvider> _pendingSerialization = new();
    private void Update(SystemObjectModelProvider baseSystemType, ModelProvider model, bool deferSerialization = false)
    {
        // Add cache to avoid duplicated update of PreVisitModel and VisitType
        if (_updated.Contains(model))
        {
            return;
        }

        // If the model property modifiers contain 'new', we should drop it because the base type already has it.
        // This must happen before UpdateFullConstructor to preserve constructor parameter ordering.
        model.Update(properties: model.Properties.Where(prop => !prop.Modifiers.HasFlag(MethodSignatureModifiers.New)).ToArray());

        var rawDataField = CreateRawDataField(model);

        // Update the full constructor before filtering properties to preserve the original parameter order.
        UpdateFullConstructor(model, rawDataField);

        // Filter out base class properties before accessing serialization methods.
        // UpdateSerialization accesses MrwSerializationTypeDefinition.Methods which triggers lazy evaluation
        // of serialization methods (including JsonModelWriteCore). If base class properties (e.g., Tags)
        // are still present on the model at that point, they will be redundantly serialized in the derived
        // class even though the base class already handles them.
        var baseSystemPropertyNames = EnumerateBaseModelProperties(baseSystemType);
        var properties = RemoveDuplicatePropertiesAndStripVirtual(model, baseSystemType, baseSystemPropertyNames);
        model.Update(properties: properties);

        if (deferSerialization)
        {
            // Defer to VisitType when all models are cached in TypeFactory to avoid infinite
            // recursion for discriminated models during PreVisitModel.
            _pendingSerialization.Add(model);
        }
        else
        {
            // Non-discriminated models: update serialization immediately, before model properties
            // and fields are modified below. The lazy serialization code generation depends on
            // the model's current state.
            UpdateSerialization(model);
        }

        model.Update(fields: [.. model.Fields, rawDataField]);

        _updated.Add(model);
    }

    private void UpdateRegularModelInheritance(ModelProvider model)
    {
        // Add cache to avoid duplicated updates
        if (_regularUpdated.Contains(model))
        {
            return;
        }

        var basePropertyNames = EnumerateRegularBaseModelProperties(model.BaseModelProvider!);
        var properties = RemoveDuplicatePropertiesAndStripVirtual(model, model.BaseModelProvider!, basePropertyNames);

        model.Update(properties: properties);

        _regularUpdated.Add(model);
    }

    private static readonly HashSet<string> _methodNamesToUpdate = new(){ "JsonModelCreateCore", "PersistableModelCreateCore", "PersistableModelWriteCore" };
    private static void UpdateSerialization(ModelProvider model)
    {
        var serializationProvider = model.SerializationProviders;
        foreach (var provider in model.SerializationProviders)
        {
            if (provider is MrwSerializationTypeDefinition serializationTypeDefinition)
            {
                foreach (var method in serializationTypeDefinition.Methods.Where(m => _methodNamesToUpdate.Contains(m.Signature.Name)))
                {
                    var modifiers = method.Signature.Modifiers | MethodSignatureModifiers.Virtual;
                    modifiers &= ~MethodSignatureModifiers.Override;
                    method.Signature.Update(modifiers: modifiers);
                }
            }
        }
    }

    private static void UpdateFullConstructor(ModelProvider model, FieldProvider rawDataField)
    {
        var signature = model.FullConstructor.Signature;
        var initializer = signature.Initializer;
        if (initializer is not null)
        {
            var updatedInitializer = new ConstructorInitializer(initializer.IsBase, initializer.Arguments.Where(arg => arg is VariableExpression variable && variable.Declaration.RequestedName != RawDataParameterName).ToArray());
            var updatedSignature = new ConstructorSignature(signature.Type, signature.Description, signature.Modifiers, signature.Parameters, signature.Attributes, updatedInitializer);
            model.FullConstructor.Update(signature: updatedSignature);
        }

        var body = model.FullConstructor.BodyStatements;
        var statement = rawDataField.Assign(model.FullConstructor.Signature.Parameters.Single(f => f.Name.Equals(RawDataParameterName))).Terminate();
        MethodBodyStatement[] updatedBody = [statement, .. body!];
        model.FullConstructor.Update(bodyStatements: updatedBody);
    }

    private const string RawDataParameterName = "additionalBinaryDataProperties";
    private static FieldProvider CreateRawDataField(ModelProvider model)
    {
        var modifiers = FieldModifiers.Private;
        if (!model.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Sealed) && !model.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Struct))
        {
            modifiers |= FieldModifiers.Protected;
        }
        modifiers |= FieldModifiers.ReadOnly;

        var rawDataField = new FieldProvider(
            modifiers: modifiers,
            type: typeof(IDictionary<string, BinaryData>),
            description: FromString("Keeps track of any properties unknown to the library."),
            name: $"_{RawDataParameterName}",
            enclosingType: model);

        return rawDataField;
    }

    [return: NotNullIfNotNull(nameof(s))]
    private static FormattableString? FromString(string? s) =>
        s is null ? null : s.Length == 0 ? (FormattableString)$"" : $"{s}";

    private static HashSet<string> EnumerateBaseModelProperties(SystemObjectModelProvider baseSystemModel)
    {
        var baseSystemPropertyNames = new HashSet<string>();
        ModelProvider? baseModel = baseSystemModel;
        while (baseModel != null)
        {
            foreach (var property in baseModel.Properties)
            {
                baseSystemPropertyNames.Add(property.Name);
            }
            baseModel = baseModel.BaseModelProvider;
        }
        return baseSystemPropertyNames;
    }

    private static HashSet<string> EnumerateRegularBaseModelProperties(ModelProvider baseModel)
    {
        var basePropertyNames = new HashSet<string>();
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

    /// <summary>
    /// Checks if a model's custom code overrides the base type to a known inheritable system type
    /// that differs from the spec-defined base. This handles scenarios like custom code declaring
    /// ": TrackedResourceData" when the spec says ProxyResource (→ ResourceData).
    /// </summary>
    private static bool TryGetCustomInheritableSystemBase(ModelProvider model, [MaybeNullWhen(false)] out Type clrType)
    {
        clrType = null;
        var customBaseType = model.CustomCodeView?.BaseType;
        if (customBaseType == null)
        {
            return false;
        }

        // Check if the custom base type matches a known inheritable system type
        if (!KnownManagementTypes.TryGetInheritableSystemTypeByName(customBaseType, out clrType))
        {
            return false;
        }

        // Only return false if the model already has a SystemObjectModelProvider
        // with the same CLR base type — otherwise treat the differing inheritable type as a custom override
        if (model.BaseModelProvider is SystemObjectModelProvider inheritableBase
            && inheritableBase.SystemType.FrameworkType == clrType)
        {
            return false;
        }

        return true;
    }

    private HashSet<ModelProvider> _customBaseUpdated = new();

    /// <summary>
    /// Applies the same system object model updates as Update(), but uses CLR type reflection
    /// to enumerate base properties when a SystemObjectModelProvider doesn't exist
    /// for the target type (e.g., TrackedResource not in the input model set).
    /// </summary>
    private void UpdateWithClrBase(Type baseClrType, ModelProvider model)
    {
        if (_customBaseUpdated.Contains(model))
        {
            return;
        }

        // If the model property modifiers contain 'new', we should drop it because the base type already has it.
        model.Update(properties: model.Properties.Where(prop => !prop.Modifiers.HasFlag(MethodSignatureModifiers.New)).ToArray());

        var rawDataField = CreateRawDataField(model);
        UpdateSerialization(model);

        UpdateFullConstructor(model, rawDataField);

        var basePropertyNames = EnumerateClrTypeProperties(baseClrType);
        var properties = model.Properties.Where(prop => !basePropertyNames.Contains(prop.Name));

        model.Update(properties: properties, fields: [.. model.Fields, rawDataField]);

        _customBaseUpdated.Add(model);
    }

    /// <summary>
    /// Enumerates public instance property names from a CLR type and all its base types.
    /// Used as a fallback when SystemObjectModelProvider doesn't exist.
    /// </summary>
    private static HashSet<string> EnumerateClrTypeProperties(Type type)
    {
        var propertyNames = new HashSet<string>();
        foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            propertyNames.Add(prop.Name);
        }
        return propertyNames;
    }

    /// <summary>
    /// Removes properties with 'new' modifier or matching base property names from the model,
    /// and strips orphaned virtual modifiers from corresponding base properties.
    /// </summary>
    private static PropertyProvider[] RemoveDuplicatePropertiesAndStripVirtual(
        ModelProvider model, ModelProvider baseModel, HashSet<string> basePropertyNames)
    {
        var removedPropertyNames = new HashSet<string>();
        var remainingProperties = new List<PropertyProvider>();

        foreach (var prop in model.Properties)
        {
            if (prop.Modifiers.HasFlag(MethodSignatureModifiers.New) || basePropertyNames.Contains(prop.Name))
            {
                removedPropertyNames.Add(prop.Name);
            }
            else
            {
                remainingProperties.Add(prop);
            }
        }

        StripOrphanedVirtualModifiers(baseModel, removedPropertyNames);
        return remainingProperties.ToArray();
    }

    /// <summary>
    /// Strips the virtual modifier from base model properties whose names match removed derived properties.
    /// When derived properties with new/override modifiers are removed, the corresponding base virtual
    /// modifier becomes orphaned and should be removed.
    /// </summary>
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

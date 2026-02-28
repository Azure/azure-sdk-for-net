// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
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

internal class InheritableSystemObjectModelVisitor : ScmLibraryVisitor
{
    protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
    {
        if (type is InheritableSystemObjectModelProvider systemType)
        {
            UpdateNamespace(systemType);
            EnsureFrameworkTypeRegistered(systemType);
        }

        if (type is not InheritableSystemObjectModelProvider && type?.BaseModelProvider is InheritableSystemObjectModelProvider baseSystemType)
        {
            Update(baseSystemType, type);
        }
        else if (type is not InheritableSystemObjectModelProvider && type is not null && TryGetCustomInheritableSystemBase(type, out var customBaseClrType))
        {
            // Handle custom code overriding base type to a different known inheritable system type.
            // e.g., spec says ProxyResource (→ ResourceData) but custom code says : TrackedResourceData
            UpdateWithClrBase(customBaseClrType, type);
        }
        else if (type?.BaseModelProvider is not null && type is not InheritableSystemObjectModelProvider)
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

        if (type is InheritableSystemObjectModelProvider systemType)
        {
            UpdateNamespace(systemType);
            EnsureFrameworkTypeRegistered(systemType);
        }

        if (type is ModelProvider model && model is not InheritableSystemObjectModelProvider && model.BaseModelProvider is InheritableSystemObjectModelProvider baseSystemType)
        {
            Update(baseSystemType, model);
        }
        else if (type is ModelProvider model2 && model2 is not InheritableSystemObjectModelProvider && TryGetCustomInheritableSystemBase(model2, out var customBaseClrType))
        {
            UpdateWithClrBase(customBaseClrType, model2);
        }
        else if (type is ModelProvider model3 && model3.BaseModelProvider is not null && model3 is not InheritableSystemObjectModelProvider)
        {
            // Handle regular model inheritance where a non-system model extends another non-system model.
            // This fixes duplicate property generation when TypeSpec models redefine base model properties
            // (e.g., to add default values or change descriptions). Without this, properties with the 'new'
            // modifier would generate duplicates causing C# compilation errors.
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

    private static void UpdateNamespace(InheritableSystemObjectModelProvider systemType)
    {
        // This is needed because we updated the namespace with NamespaceVisitor in Azure generator earlier
        systemType.Update(@namespace: systemType.ClrType.Namespace);
    }

    private HashSet<ModelProvider> _updated = new();
    private HashSet<ModelProvider> _regularUpdated = new();
    private void Update(InheritableSystemObjectModelProvider baseSystemType, ModelProvider model)
    {
        // Add cache to avoid duplicated update of PreVisitModel and VisitType
        if (_updated.Contains(model))
        {
            return;
        }

        // If the model property modifiers contain 'new', we should drop it because the base type already has it.
        model.Update(properties: model.Properties.Where(prop => !prop.Modifiers.HasFlag(MethodSignatureModifiers.New)).ToArray());

        var rawDataField = CreateRawDataField(model);
        UpdateSerialization(model);

        UpdateFullConstructor(model, rawDataField);

        var baseSystemPropertyNames = EnumerateBaseModelProperties(baseSystemType);
        var properties = model.Properties.Where(prop => !baseSystemPropertyNames.Contains(prop.Name));

        model.Update(properties: properties, fields: [.. model.Fields, rawDataField]);

        _updated.Add(model);
    }

    private void UpdateRegularModelInheritance(ModelProvider model)
    {
        // Add cache to avoid duplicated updates
        if (_regularUpdated.Contains(model))
        {
            return;
        }

        // If the model property modifiers contain 'new', we should drop it because the base type already has it.
        model.Update(properties: model.Properties.Where(prop => !prop.Modifiers.HasFlag(MethodSignatureModifiers.New)).ToArray());

        // Remove properties that have the same name as properties in the base model
        var basePropertyNames = EnumerateRegularBaseModelProperties(model.BaseModelProvider!);
        var properties = model.Properties.Where(prop => !basePropertyNames.Contains(prop.Name)).ToArray();

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

    private static HashSet<string> EnumerateBaseModelProperties(InheritableSystemObjectModelProvider baseSystemModel)
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
    /// This allows BuildBaseModelProvider() to find InheritableSystemObjectModelProvider when custom code
    /// uses a Roslyn-resolved framework CSharpType (which differs from the non-framework CSharpType
    /// created by InheritableSystemObjectModelProvider).
    /// </summary>
    private static void EnsureFrameworkTypeRegistered(InheritableSystemObjectModelProvider systemType)
    {
        var frameworkType = new CSharpType(systemType.ClrType);
        var typeMap = CodeModelGenerator.Instance.TypeFactory.CSharpTypeMap;
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

        // Only return false if the model already has an InheritableSystemObjectModelProvider
        // with the same CLR base type — otherwise treat the differing inheritable type as a custom override
        if (model.BaseModelProvider is InheritableSystemObjectModelProvider inheritableBase
            && inheritableBase.ClrType == clrType)
        {
            return false;
        }

        return true;
    }

    private HashSet<ModelProvider> _customBaseUpdated = new();

    /// <summary>
    /// Applies the same system object model updates as Update(), but uses CLR type reflection
    /// to enumerate base properties when an InheritableSystemObjectModelProvider doesn't exist
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
    /// Used as a fallback when InheritableSystemObjectModelProvider doesn't exist.
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
}

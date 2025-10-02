// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Primitives;
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

namespace Azure.Generator.Management.Visitors;

internal class InheritableSystemObjectModelVisitor : ScmLibraryVisitor
{
    protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
    {
        if (type is InheritableSystemObjectModelProvider systemType)
        {
            UpdateNamespace(systemType);
        }

        if (type is not InheritableSystemObjectModelProvider && type?.BaseModelProvider is InheritableSystemObjectModelProvider baseSystemType)
        {
            Update(baseSystemType, type);
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
        }

        if (type is ModelProvider model && model is not InheritableSystemObjectModelProvider && model.BaseModelProvider is InheritableSystemObjectModelProvider baseSystemType)
        {
            Update(baseSystemType, model);
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
        systemType.Update(@namespace: systemType._type.Namespace);
    }

    private HashSet<ModelProvider> _updated = new();
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
}

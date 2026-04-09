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

// TODO: Refactor or remove InheritableSystemObjectModelVisitor once SystemObjectModelProvider in MTG
// fully replaces InheritableSystemObjectModelProvider. The property filtering, virtual modifier stripping,
// and serialization update logic here should be revisited as part of that cleanup.
internal class InheritableSystemObjectModelVisitor : ScmLibraryVisitor
{
    protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
    {
        if (type is InheritableSystemObjectModelProvider { IsSystemBase: true } systemType)
        {
            UpdateNamespace(systemType);
        }

        if (type is not InheritableSystemObjectModelProvider { IsSystemBase: true } && type?.BaseModelProvider is InheritableSystemObjectModelProvider { IsSystemBase: true } baseSystemType)
        {
            // Defer serialization update for discriminated models to avoid infinite recursion.
            // Accessing serializationTypeDefinition.Methods triggers building DerivedModels ->
            // CreateModel for derived types whose base model is not yet cached in TypeFactory.
            // Non-discriminated models must NOT defer because UpdateSerialization accesses .Methods
            // which lazily generates serialization code that depends on the model's pre-update state
            // (before properties and fields are modified later in Update).
            Update(baseSystemType, type, deferSerialization: model.DiscriminatorProperty != null);
        }
        else if (type?.BaseModelProvider is not null && type is not InheritableSystemObjectModelProvider { IsSystemBase: true })
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

        if (type is InheritableSystemObjectModelProvider { IsSystemBase: true } systemType)
        {
            UpdateNamespace(systemType);
        }

        if (type is ModelProvider model && model is not InheritableSystemObjectModelProvider { IsSystemBase: true } && model.BaseModelProvider is InheritableSystemObjectModelProvider { IsSystemBase: true } baseSystemType)
        {
            Update(baseSystemType, model);
        }
        else if (type is ModelProvider model2 && model2.BaseModelProvider is not null && model2 is not InheritableSystemObjectModelProvider { IsSystemBase: true })
        {
            // Handle regular model inheritance where a non-system model extends another non-system model.
            // This fixes duplicate property generation when TypeSpec models redefine base model properties
            // (e.g., to add default values or change descriptions). Without this, properties with the 'new'
            // modifier would generate duplicates causing C# compilation errors.
            UpdateRegularModelInheritance(model2);
        }

        // Apply deferred serialization updates that were postponed from PreVisitModel
        // for discriminated models only (see comment in PreVisitModel).
        if (type is ModelProvider pendingModel && _pendingSerialization.Remove(pendingModel))
        {
            UpdateSerialization(pendingModel);
        }

        // Fix serialization override return types deferred from UpdateRegularModelInheritance.
        // Must run in VisitType (not PreVisitModel) because accessing serialization Methods
        // triggers lazy method building which can cause infinite recursion for discriminated models.
        if (type is ModelProvider pendingReturnTypeFix && _pendingSerializationReturnTypeFix.Remove(pendingReturnTypeFix))
        {
            FixSerializationReturnTypes(pendingReturnTypeFix);
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
    private HashSet<ModelProvider> _regularUpdated = new();
    private HashSet<ModelProvider> _pendingSerialization = new();
    private HashSet<ModelProvider> _pendingSerializationReturnTypeFix = new();
    private void Update(InheritableSystemObjectModelProvider baseSystemType, ModelProvider model, bool deferSerialization = false)
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

        // Fix raw data field reference mismatch: when the management generator adds a new
        // _additionalBinaryDataProperties field to a base model (in Update()), the constructor
        // parameter for this model may still reference the original field from a higher ancestor.
        // The serialization code's base-model field search finds the newly-added field, creating
        // two different FieldProvider objects for the same concept. This causes the code writer
        // to generate mismatched variable names (e.g., additionalBinaryDataProperties0 vs
        // additionalBinaryDataProperties). To fix, update the constructor parameter to reference
        // the same field the serialization code will find.
        FixRawDataFieldReference(model);

        // Defer serialization return type fixes to VisitType to avoid triggering lazy
        // serialization method building during PreVisitModel (which can cause infinite
        // recursion for discriminated models).
        _pendingSerializationReturnTypeFix.Add(model);

        _regularUpdated.Add(model);
    }

    private static void FixRawDataFieldReference(ModelProvider model)
    {
        // Find the raw data field that the serialization code's base-model search will find.
        FieldProvider? rawDataField = null;
        var baseModel = model.BaseModelProvider;
        while (baseModel != null)
        {
            rawDataField = baseModel.Fields.FirstOrDefault(
                f => f.Name == $"_{RawDataParameterName}");
            if (rawDataField != null)
            {
                break;
            }
            baseModel = baseModel.BaseModelProvider;
        }

        if (rawDataField == null)
        {
            return;
        }

        var signature = model.FullConstructor.Signature;
        var ctorParamIndex = -1;
        for (int i = 0; i < signature.Parameters.Count; i++)
        {
            if (signature.Parameters[i].Name.Equals(RawDataParameterName))
            {
                ctorParamIndex = i;
                break;
            }
        }

        if (ctorParamIndex < 0 || signature.Parameters[ctorParamIndex].Field == rawDataField)
        {
            return;
        }

        // Create a model-owned parameter that references the correct field.
        // IMPORTANT: Do NOT call ctorParam.Update(field:) on the existing parameter.
        // Constructor parameters are shared across sibling models because
        // BuildConstructorParameters copies references from the base constructor via
        // AddRange. Mutating a shared parameter would corrupt unrelated models.
        var newParam = rawDataField.AsParameter;

        // Replace the parameter in the constructor signature.
        var updatedParams = new List<ParameterProvider>(signature.Parameters);
        updatedParams[ctorParamIndex] = newParam;

        // Also update the base constructor initializer to use the new parameter's
        // variable expression so the code writer doesn't disambiguate with a "0" suffix.
        var initializer = signature.Initializer;
        if (initializer is not null)
        {
            var updatedArgs = initializer.Arguments.Select(
                arg => arg is VariableExpression ve && ve.Declaration.RequestedName == RawDataParameterName
                    ? (ValueExpression)newParam
                    : arg).ToArray();
            initializer = new ConstructorInitializer(initializer.IsBase, updatedArgs);
        }

        var updatedSignature = new ConstructorSignature(
            signature.Type,
            signature.Description,
            signature.Modifiers,
            updatedParams,
            signature.Attributes,
            initializer);
        model.FullConstructor.Update(signature: updatedSignature);
    }

    private const string JsonModelCreateCoreMethodName = "JsonModelCreateCore";
    private const string PersistableModelCreateCoreMethodName = "PersistableModelCreateCore";
    private const string PersistableModelWriteCoreMethodName = "PersistableModelWriteCore";

    private static readonly HashSet<string> _methodNamesToUpdate = new()
    {
        JsonModelCreateCoreMethodName,
        PersistableModelCreateCoreMethodName,
        PersistableModelWriteCoreMethodName
    };

    private static readonly HashSet<string> _methodNamesToFixReturnType = new()
    {
        JsonModelCreateCoreMethodName,
        PersistableModelCreateCoreMethodName
    };

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

    /// <summary>
    /// Fixes the return type of serialization override methods (PersistableModelCreateCore,
    /// JsonModelCreateCore) to use the system base type (e.g., ResourceData) instead of the
    /// immediate parent type. Without this, the framework generates overrides with
    /// model.Type.BaseType as the return type, which can produce a covariant return type
    /// (e.g., returning CustomPatchBase instead of ResourceData). Covariant returns are not
    /// supported on .NET Framework.
    ///
    /// Also fixes the explicit interface implementations (IJsonModel&lt;T&gt;.Create,
    /// IPersistableModel&lt;T&gt;.Create) that call these methods, adding a cast to the
    /// model type when the return type was changed. Without this cast, the implicit
    /// conversion from ResourceData to the model type would fail to compile.
    /// </summary>
    private void FixSerializationReturnTypes(ModelProvider model)
    {
        var systemBaseType = FindSystemBaseType(model);
        if (systemBaseType is null)
        {
            return;
        }

        foreach (var provider in model.SerializationProviders)
        {
            if (provider is MrwSerializationTypeDefinition serializationTypeDefinition)
            {
                bool returnTypeChanged = false;
                foreach (var method in serializationTypeDefinition.Methods.Where(
                    m => _methodNamesToFixReturnType.Contains(m.Signature.Name)
                         && m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Override)))
                {
                    var currentReturnType = method.Signature.ReturnType;
                    if (currentReturnType is not null && !currentReturnType.Equals(systemBaseType))
                    {
                        method.Signature.Update(returnType: systemBaseType);
                        returnTypeChanged = true;
                    }
                }

                // When the *Core methods' return type was changed to the system base type,
                // the explicit interface implementations that call them need a cast to the
                // model type (e.g., (PolyDeviceData)JsonModelCreateCore(ref reader, options)).
                if (returnTypeChanged)
                {
                    FixExplicitInterfaceCreateMethods(serializationTypeDefinition);
                }
            }
        }
    }

    /// <summary>
    /// Adds a cast to the explicit interface Create methods (IJsonModel&lt;T&gt;.Create,
    /// IPersistableModel&lt;T&gt;.Create) when their body expressions return the system base
    /// type (e.g., ResourceData) instead of the expected model type (e.g., PolyDeviceData).
    /// </summary>
    private static void FixExplicitInterfaceCreateMethods(MrwSerializationTypeDefinition serializationTypeDefinition)
    {
        foreach (var method in serializationTypeDefinition.Methods.Where(
            m => m.Signature.Name == "Create"
                 && m.Signature.ExplicitInterface is not null
                 && m.BodyExpression is not null))
        {
            // Cast to the method's declared return type (the discriminated base, e.g., PolyDeviceData)
            // rather than the model type (e.g., UnknownPolyDevice), because the deserialization
            // factory can return any derived type.
            var returnType = method.Signature.ReturnType;
            if (returnType is not null)
            {
                method.Update(bodyExpression: method.BodyExpression!.CastTo(returnType));
            }
        }
    }

    private readonly Dictionary<ModelProvider, CSharpType?> _systemBaseTypeCache = new();

    /// <summary>
    /// Walks up the model hierarchy to find the system base type (e.g., ResourceData)
    /// that the virtual serialization methods use as their return type.
    /// </summary>
    private CSharpType? FindSystemBaseType(ModelProvider model)
    {
        if (_systemBaseTypeCache.TryGetValue(model, out var cached))
        {
            return cached;
        }

        var current = model.BaseModelProvider;
        while (current is not null)
        {
            if (current is InheritableSystemObjectModelProvider { IsSystemBase: true } systemModel)
            {
                _systemBaseTypeCache[model] = systemModel.Type;
                return systemModel.Type;
            }
            current = current.BaseModelProvider;
        }
        _systemBaseTypeCache[model] = null;
        return null;
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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Azure.Generator.Management.Visitors;

internal class ResourceVisitor : ScmLibraryVisitor
{
    internal static void PreserveReadOnlyDictionaryPropertiesFromModelFactoryLastContract(ModelProvider model)
    {
        var modelFactory = ManagementClientGenerator.Instance.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().SingleOrDefault();
        _ = modelFactory?.Methods;
        var previousMethods = modelFactory?.LastContractView?.Methods;
        if (previousMethods is null || previousMethods.Count == 0)
        {
            return;
        }

        foreach (var previousMethod in previousMethods)
        {
            if (previousMethod.Signature.ReturnType is not { } returnType
                || !returnType.WithNullable(false).AreNamesEqual(model.Type.WithNullable(false)))
            {
                continue;
            }

            foreach (var parameter in previousMethod.Signature.Parameters)
            {
                if (!IsReadOnlyDictionary(parameter.Type))
                {
                    continue;
                }

                var matchingProperty = model.Properties.FirstOrDefault(property =>
                    IsDictionary(property.Type)
                    && string.Equals(property.Name, parameter.Name, StringComparison.OrdinalIgnoreCase));
                if (matchingProperty is null)
                {
                    continue;
                }

                UpdateDictionaryPropertyAndConstructorParameters(model, matchingProperty, new CSharpType(typeof(IReadOnlyDictionary<,>), matchingProperty.Type.Arguments));
            }
        }
    }

    protected override PropertyProvider? PreVisitProperty(InputProperty inputProperty, PropertyProvider? propertyProvider)
    {
        if (propertyProvider?.EnclosingType is ModelProvider modelProvider)
        {
            var resourceDataModel = modelProvider as ResourceDataModelProvider;
            var isResourceDataModel = resourceDataModel is not null || modelProvider.Name.EndsWith("Data", StringComparison.Ordinal);
            // Output-only resource data models represent service responses. Keep collection properties read-only
            // for GA compatibility, even when the TypeSpec property itself is not marked readonly.
            var shouldUseReadOnlyCollection = resourceDataModel is not null
                && (!resourceDataModel.InputModel.Usage.HasFlag(InputModelTypeUsage.Input) || inputProperty.IsReadOnly);
            if (propertyProvider.Type.IsList && shouldUseReadOnlyCollection)
            {
                propertyProvider.Update(type: new CSharpType(typeof(IReadOnlyList<>), propertyProvider.Type.Arguments));
            }
            else if (IsDictionary(propertyProvider.Type)
                && (shouldUseReadOnlyCollection
                    || (resourceDataModel is not null && HasExistingReadOnlyDictionaryProperty(resourceDataModel, propertyProvider))))
            {
                propertyProvider.Update(type: new CSharpType(typeof(IReadOnlyDictionary<,>), propertyProvider.Type.Arguments));
            }
        }

        return base.PreVisitProperty(inputProperty, propertyProvider);
    }

    private static bool HasExistingReadOnlyDictionaryProperty(ResourceDataModelProvider model, PropertyProvider property)
    {
        return HasMatchingReadOnlyDictionaryProperty(model.CustomCodeView?.Properties, property)
            || HasMatchingReadOnlyDictionaryProperty(model.LastContractView?.Properties, property);
    }

    private static bool HasMatchingReadOnlyDictionaryProperty(IReadOnlyList<PropertyProvider>? properties, PropertyProvider property)
    {
        return properties?.Any(p => p.Name == property.Name && IsReadOnlyDictionary(p.Type)) == true;
    }

    private static bool IsReadOnlyDictionary(CSharpType type)
        => IsDictionary(type, typeof(IReadOnlyDictionary<,>));

    private static bool IsDictionary(CSharpType type)
        => type.IsDictionary || IsDictionary(type, typeof(IDictionary<,>)) || IsDictionary(type, typeof(IReadOnlyDictionary<,>));

    private static bool IsDictionary(CSharpType type, Type dictionaryTypeDefinition)
    {
        if (type is not { IsFrameworkType: true, FrameworkType: not null })
        {
            return false;
        }

        var frameworkType = type.FrameworkType;
        if (frameworkType.IsGenericType && !frameworkType.IsGenericTypeDefinition)
        {
            frameworkType = frameworkType.GetGenericTypeDefinition();
        }

        return frameworkType == dictionaryTypeDefinition;
    }

    // Re-assert the namespace and fix serialization providers' file paths after Azure.Generator's
    // NamespaceVisitor (which runs in VisitType) has had a chance to override them.
    protected override TypeProvider? VisitType(TypeProvider type)
    {
        TransformNamespaceForResource(type);
        foreach (var serialization in type.SerializationProviders)
        {
            base.VisitType(serialization);
        }

        return base.VisitType(type);
    }

    protected override PropertyProvider? VisitProperty(PropertyProvider property)
    {
        if (property.EnclosingType is ResourceDataModelProvider resourceDataModel
            && IsDictionary(property.Type)
            && HasExistingReadOnlyDictionaryProperty(resourceDataModel, property))
        {
            UpdateDictionaryPropertyAndConstructorParameters(resourceDataModel, property, new CSharpType(typeof(IReadOnlyDictionary<,>), property.Type.Arguments));
        }

        if (TryGetResourceDataType(property.Type, out var resourceDataType))
        {
            property.Update(type: resourceDataType);
        }

        return base.VisitProperty(property);
    }

    protected override ConstructorProvider? VisitConstructor(ConstructorProvider constructor)
    {
        foreach (var parameter in constructor.Signature.Parameters)
        {
            UpdateResourceDataParameterType(parameter);
        }

        return base.VisitConstructor(constructor);
    }

    private static void UpdateDictionaryPropertyAndConstructorParameters(ModelProvider model, PropertyProvider property, CSharpType readOnlyDictionaryType)
    {
        property.Update(type: readOnlyDictionaryType);
        foreach (var constructor in model.Constructors)
        {
            foreach (var constructorParameter in constructor.Signature.Parameters)
            {
                if (IsDictionary(constructorParameter.Type)
                    && string.Equals(constructorParameter.Name, property.Name, StringComparison.OrdinalIgnoreCase))
                {
                    constructorParameter.Update(type: readOnlyDictionaryType);
                }
            }
        }
    }

    protected override MethodProvider? VisitMethod(MethodProvider method)
    {
        foreach (var parameter in method.Signature.Parameters)
        {
            UpdateResourceDataParameterType(parameter);
        }

        if (TryGetResourceDataType(method.Signature.ReturnType, out var resourceDataType))
        {
            var signature = method.Signature;
            method.Update(signature: new MethodSignature(
                signature.Name,
                signature.Description,
                signature.Modifiers,
                resourceDataType,
                signature.ReturnDescription,
                signature.Parameters,
                signature.Attributes,
                signature.GenericArguments,
                signature.GenericParameterConstraints,
                signature.ExplicitInterface,
                signature.NonDocumentComment));
        }

        return base.VisitMethod(method);
    }

    protected override VariableExpression VisitVariableExpression(VariableExpression variable, MethodProvider method)
    {
        if (IsDictionary(variable.Type)
            && TryGetReadOnlyDictionaryPropertyType(method.Signature.ReturnType, variable.Declaration.RequestedName, out var readOnlyDictionaryType))
        {
            variable.Update(type: readOnlyDictionaryType);
        }

        if (TryGetResourceDataType(variable.Type, out var resourceDataType))
        {
            variable.Update(type: resourceDataType);
        }

        return base.VisitVariableExpression(variable, method);
    }

    private static bool TryGetReadOnlyDictionaryPropertyType(CSharpType? modelType, string propertyName, out CSharpType readOnlyDictionaryType)
    {
        if (modelType is not null)
        {
            foreach (var resource in ManagementClientGenerator.Instance.OutputLibrary.ResourceProviders)
            {
                var model = resource.ResourceData;
                if (model.Type.AreNamesEqual(modelType)
                    && model.Properties.FirstOrDefault(property =>
                        string.Equals(property.Name, propertyName, StringComparison.OrdinalIgnoreCase)
                        && IsReadOnlyDictionary(property.Type)) is { } property)
                {
                    readOnlyDictionaryType = property.Type;
                    return true;
                }
            }
        }

        readOnlyDictionaryType = null!;
        return false;
    }

    protected override ValueExpression? VisitInvokeMethodExpression(InvokeMethodExpression expression, MethodProvider method)
    {
        if (TryGetResourceDataExpression(expression.InstanceReference, out var instanceReference))
        {
            expression.Update(instanceReference: instanceReference);
        }

        if (UpdateResourceDataExpressions(expression.Arguments) is { } arguments)
        {
            expression.Update(arguments: arguments);
        }

        if (expression.TypeArguments is not null &&
            UpdateResourceDataTypes(expression.TypeArguments) is { } updatedTypeArguments)
        {
            expression.Update(typeArguments: updatedTypeArguments);
        }

        if (TryGetResourceDataType(expression.ExtensionType, out var resourceDataType))
        {
            expression.Update(extensionType: resourceDataType);
        }

        return base.VisitInvokeMethodExpression(expression, method);
    }

    protected override ValueExpression? VisitMemberExpression(MemberExpression expression, MethodProvider method)
    {
        if (TryGetResourceDataExpression(expression.Inner, out var inner))
        {
            expression.Update(inner: inner);
        }

        return base.VisitMemberExpression(expression, method);
    }

    private void TransformNamespaceForResource(TypeProvider type)
    {
        if (type is ModelProvider model &&
            (model is ResourceDataModelProvider
                || IsOutputResourceDataModel(model)
                || ManagementClientGenerator.Instance.OutputLibrary.IsResourceModelType(model.Type)))
        {
            type.Update(@namespace: ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace);

            foreach (var serialization in type.SerializationProviders)
            {
                serialization.Update(
                    relativeFilePath: Path.Combine("src", "Generated", $"{model.Name}.Serialization.cs"),
                    @namespace: ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace);
            }
        }
    }

    // Some customized plain models intentionally inherit ResourceData. Only actual
    // resource data providers should be moved to the root namespace; checking the
    // base type here would incorrectly move those plain models out of .Models.
    private static bool IsOutputResourceDataModel(ModelProvider model)
        => ManagementClientGenerator.Instance.OutputLibrary.ResourceProviders.Any(resource => ReferenceEquals(resource.ResourceData, model));

    private static void UpdateResourceDataParameterType(ParameterProvider parameter)
    {
        if (TryGetResourceDataType(parameter.Type, out var resourceDataType))
        {
            parameter.Update(type: resourceDataType);
        }
    }

    private static IReadOnlyList<CSharpType>? UpdateResourceDataTypes(IReadOnlyList<CSharpType> types)
    {
        List<CSharpType>? updatedTypes = null;
        for (var i = 0; i < types.Count; i++)
        {
            var type = types[i];
            if (TryGetResourceDataType(type, out var resourceDataType))
            {
                updatedTypes ??= types.ToList();
                updatedTypes[i] = resourceDataType;
            }
        }

        return updatedTypes;
    }

    private static IReadOnlyList<ValueExpression>? UpdateResourceDataExpressions(IReadOnlyList<ValueExpression> expressions)
    {
        List<ValueExpression>? updatedExpressions = null;
        for (var i = 0; i < expressions.Count; i++)
        {
            if (TryGetResourceDataExpression(expressions[i], out var resourceDataExpression))
            {
                updatedExpressions ??= expressions.ToList();
                updatedExpressions[i] = resourceDataExpression;
            }
        }

        return updatedExpressions;
    }

    private static bool TryGetResourceDataExpression(ValueExpression? expression, out ValueExpression resourceDataExpression)
    {
        if (expression is TypeReferenceExpression { Type: { } type } &&
            TryGetResourceDataType(type, out var resourceDataType))
        {
            resourceDataExpression = resourceDataType;
            return true;
        }

        resourceDataExpression = null!;
        return false;
    }

    private static bool TryGetResourceDataType(CSharpType? type, out CSharpType resourceDataType)
    {
        if (type is not null)
        {
            var expectedModelsNamespace = $"{ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace}.Models";
            if (type.Namespace == expectedModelsNamespace && type.Name.EndsWith("Data", System.StringComparison.Ordinal))
            {
                foreach (var resource in ManagementClientGenerator.Instance.OutputLibrary.ResourceProviders)
                {
                    if (type.Name == resource.ResourceData.Type.Name)
                    {
                        resourceDataType = resource.ResourceData.Type;
                        return true;
                    }
                }
            }
        }

        resourceDataType = null!;
        return false;
    }
}

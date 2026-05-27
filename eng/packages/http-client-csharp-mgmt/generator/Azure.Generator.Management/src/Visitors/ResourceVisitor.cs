// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Azure.Generator.Management.Visitors;

internal class ResourceVisitor : ScmLibraryVisitor
{
    // Re-assert the namespace and fix serialization providers' file paths after Azure.Generator's
    // NamespaceVisitor (which runs in VisitType) has had a chance to override them.
    protected override TypeProvider? VisitType(TypeProvider type)
    {
        if (type is not null)
        {
            TransformNamespaceForResource(type);
        }
        return type;
    }

    protected override PropertyProvider? VisitProperty(PropertyProvider property)
    {
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
        if (TryGetResourceDataType(variable.Type, out var resourceDataType))
        {
            variable.Update(type: resourceDataType);
        }

        return base.VisitVariableExpression(variable, method);
    }

    protected override ValueExpression? VisitInvokeMethodExpression(InvokeMethodExpression expression, MethodProvider method)
    {
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

    private void TransformNamespaceForResource(TypeProvider type)
    {
        if (type is ModelProvider model && ManagementClientGenerator.Instance.OutputLibrary.IsResourceModelType(model.Type))
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

    private static bool TryGetResourceDataType(CSharpType? type, out CSharpType resourceDataType)
    {
        if (type is not null)
        {
            var expectedModelsNamespace = $"{ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace}.Models";
            if (type.Namespace == expectedModelsNamespace)
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

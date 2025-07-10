// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Azure.Core;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Azure.Generator.Management.Visitors;

internal class ResourceVisitor : ScmLibraryVisitor
{
    protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
    {
        if (type is not null)
        {
            TransformResource(model, type);
        }
        return type;
    }

    private void TransformResource(InputModelType model, TypeProvider type)
    {
        if (type is ModelProvider && ManagementClientGenerator.Instance.InputLibrary.IsResourceModel(model))
        {
            type.Update(
                relativeFilePath: TransformRelativeFilePath(type),
                name: TransformName(type));

            foreach (var serialization in type.SerializationProviders)
            {
                serialization.Update(
                    relativeFilePath: TransformRelativeFilePathForSerialization(serialization),
                    name: TransformName(serialization));
            }

            foreach (var constructor in type.Constructors)
            {
                if (constructor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal))
                {
                    // reorder the parameters: put the parameter "string name" right after the resource identifier parameter
                    ReorderConstructorParametersIfNecessary(constructor);
                }
            }
        }
    }

    // Because we have NamespaceVisitor with VisitType in Azure.Generater, we need to override the namespace with VisitType here
    protected override TypeProvider? VisitType(TypeProvider type)
    {
        if (type is not null)
        {
            TransformNamespaceForResource(type);
        }
        return type;
    }

    private void TransformNamespaceForResource(TypeProvider type)
    {
        if (type is ModelProvider model && ManagementClientGenerator.Instance.OutputLibrary.IsResourceModelType(model.Type))
        {
            type.Update(@namespace: ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace);

            foreach (var serialization in type.SerializationProviders)
            {
                serialization.Update(@namespace: ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace);
            }
        }
    }

    private static string TransformName(TypeProvider model) => $"{model.Name}Data";

    private static string TransformRelativeFilePath(TypeProvider model)
        => Path.Combine("src", "Generated", $"{TransformName(model)}.cs");

    private static string TransformRelativeFilePathForSerialization(TypeProvider model)
        => Path.Combine("src", "Generated", $"{TransformName(model)}.Serialization.cs");

    private static void ReorderConstructorParametersIfNecessary(ConstructorProvider constructor)
    {
        var parameters = constructor.Signature.Parameters;
        if (parameters.Count <= 1 || parameters[0].Type.FrameworkType != typeof(ResourceIdentifier))
            return;

        var nameParameterIndex = parameters.ToList().FindIndex(p => p.Name == "name" && p.Type.FrameworkType == typeof(string));

        // If no "name" parameter found or it's already in the second position, return
        if (nameParameterIndex == -1 || nameParameterIndex == 1)
            return;

        var reorderedParameters = new List<ParameterProvider>
        {
            parameters[0], // ResourceIdentifier
            parameters[nameParameterIndex] // "name" parameter
        };
        reorderedParameters.AddRange(parameters.Skip(1).Where((p, i) => i + 1 != nameParameterIndex));

        constructor.Signature.Update(parameters: reorderedParameters);
    }
}

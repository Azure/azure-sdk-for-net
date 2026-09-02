// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator.Input;
using System.Collections.Generic;

namespace Azure.Generator.Management.Utilities;

internal sealed class ResourceDataCustomizationResolver
{
    private IReadOnlyDictionary<string, ResourceDataTypeReference>? _resourceDataTypes;

    public ResourceDataTypeReference? GetResourceDataType(InputModelType resourceModel, string resourceName)
    {
        var resourceDataTypes = _resourceDataTypes ??= BuildResourceDataTypes();
        if (resourceDataTypes.TryGetValue(resourceName, out var resourceDataType))
        {
            return resourceDataType;
        }

        if (resourceDataTypes.TryGetValue($"{resourceName}Resource", out resourceDataType))
        {
            return resourceDataType;
        }

        return resourceDataTypes.TryGetValue(resourceModel.Name, out resourceDataType) ? resourceDataType : null;
    }

    private static IReadOnlyDictionary<string, ResourceDataTypeReference> BuildResourceDataTypes()
    {
        var customization = ManagementClientGenerator.Instance.SourceInputModel.Customization;
        if (customization is null)
        {
            return new Dictionary<string, ResourceDataTypeReference>();
        }

        var resourceDataTypes = new Dictionary<string, ResourceDataTypeReference>();
        foreach (var typeSymbol in customization.GlobalNamespace.GetNamespaceTypes())
        {
            foreach (var attributeData in typeSymbol.GetAttributes())
            {
                if (!IsCodeGenResourceDataAttribute(attributeData))
                {
                    continue;
                }

                if (TryGetDataType(attributeData, out var resourceDataType))
                {
                    resourceDataTypes[typeSymbol.Name] = resourceDataType;
                }
            }
        }

        return resourceDataTypes;
    }

    private static bool IsCodeGenResourceDataAttribute(AttributeData attributeData)
    {
        var attributeClass = attributeData.AttributeClass;
        return attributeClass?.Name == CodeGenResourceDataAttributeDefinition.AttributeName
            || attributeClass?.Name == "CodeGenResourceData";
    }

    private static bool TryGetDataType(AttributeData attributeData, out ResourceDataTypeReference dataType)
    {
        if (attributeData.ConstructorArguments.Length == 1 &&
            attributeData.ConstructorArguments[0].Kind == TypedConstantKind.Type &&
            attributeData.ConstructorArguments[0].Value is INamedTypeSymbol dataTypeSymbol)
        {
            dataType = new ResourceDataTypeReference(
                dataTypeSymbol.Name,
                dataTypeSymbol.ContainingNamespace?.ToDisplayString() ?? string.Empty);
            return true;
        }

        dataType = null!;
        return false;
    }

    internal sealed record ResourceDataTypeReference(string Name, string Namespace);
}

internal static class NamespaceSymbolExtensions
{
    public static IEnumerable<INamedTypeSymbol> GetNamespaceTypes(this INamespaceSymbol namespaceSymbol)
    {
        foreach (var typeSymbol in namespaceSymbol.GetTypeMembers())
        {
            yield return typeSymbol;
            foreach (var nestedType in GetNestedTypes(typeSymbol))
            {
                yield return nestedType;
            }
        }

        foreach (var childNamespace in namespaceSymbol.GetNamespaceMembers())
        {
            foreach (var childType in childNamespace.GetNamespaceTypes())
            {
                yield return childType;
            }
        }
    }

    private static IEnumerable<INamedTypeSymbol> GetNestedTypes(INamedTypeSymbol typeSymbol)
    {
        foreach (var nestedType in typeSymbol.GetTypeMembers())
        {
            yield return nestedType;
            foreach (var childType in GetNestedTypes(nestedType))
            {
                yield return childType;
            }
        }
    }
}

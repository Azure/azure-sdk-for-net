// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace Azure.Generator.Management.Utilities;

internal sealed class TagPatchHookCustomizationResolver
{
    private IReadOnlyDictionary<string, string>? _methodNames;

    public string? GetMethodName(string resourceTypeName)
    {
        var methodNames = _methodNames ??= BuildMethodNames();
        return methodNames.TryGetValue(resourceTypeName, out var methodName) ? methodName : null;
    }

    private static IReadOnlyDictionary<string, string> BuildMethodNames()
    {
        var customization = ManagementClientGenerator.Instance.SourceInputModel.Customization;
        if (customization is null)
        {
            return new Dictionary<string, string>();
        }

        var methodNames = new Dictionary<string, string>();
        foreach (var typeSymbol in customization.GlobalNamespace.GetNamespaceTypes())
        {
            foreach (var attributeData in typeSymbol.GetAttributes())
            {
                if (!IsCodeGenTagPatchHookAttribute(attributeData))
                {
                    continue;
                }

                if (TryGetMethodName(attributeData, out var methodName))
                {
                    methodNames[typeSymbol.Name] = methodName;
                }
            }
        }

        return methodNames;
    }

    private static bool IsCodeGenTagPatchHookAttribute(AttributeData attributeData)
    {
        var attributeClass = attributeData.AttributeClass;
        return attributeClass?.Name == CodeGenTagPatchHookAttributeDefinition.AttributeName
            || attributeClass?.Name == "CodeGenTagPatchHook";
    }

    private static bool TryGetMethodName(AttributeData attributeData, out string methodName)
    {
        if (attributeData.ConstructorArguments.Length == 1 &&
            attributeData.ConstructorArguments[0].Kind == TypedConstantKind.Primitive &&
            attributeData.ConstructorArguments[0].Value is string value)
        {
            methodName = value;
            return true;
        }

        methodName = null!;
        return false;
    }
}

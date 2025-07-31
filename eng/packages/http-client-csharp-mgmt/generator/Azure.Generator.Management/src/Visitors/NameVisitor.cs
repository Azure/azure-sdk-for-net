// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Generator.Management.Visitors;

internal class NameVisitor : ScmLibraryVisitor
{
    private const string ResourceTypeName = "ResourceType";
    private static readonly HashSet<string> _knownModels = new HashSet<string>()
        {
            "Sku",
            "SkuName",
            "SkuTier",
            "SkuFamily",
            "SkuInformation",
            "Plan",
            "Usage",
            "Kind",
            // Private endpoint definitions which are defined in swagger common-types/privatelinks.json and are used by RPs
            "PrivateEndpointConnection",
            "PrivateLinkResource",
            "PrivateLinkServiceConnectionState",
            "PrivateEndpointServiceConnectionStatus",
            "PrivateEndpointConnectionProvisioningState",
            // not defined in common-types, but common in various RP
            "PrivateLinkResourceProperties",
            "PrivateLinkServiceConnectionStateProperty",
            // internal, but could be public in the future, also make the names more consistent
            "PrivateEndpointConnectionListResult",
            "PrivateLinkResourceListResult"
        };

    private readonly HashSet<CSharpType> _resourceUpdateModelTypes = new();

    protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
    {
        var inputLibrary = ManagementClientGenerator.Instance.InputLibrary;
        if (type is null)
        {
            return null;
        }

        if (TryTransformUrlToUri(model.Name, out var newName))
        {
            type.Update(name: newName);
            UpdateSerialization(type, newName);
        }

        if (_knownModels.Contains(model.Name))
        {
            string prefix = TypeNameUtilities.GetResourceProviderName();
            var UpdatedName = $"{prefix}{model.Name}";
            type.Update(name: UpdatedName);
            UpdateSerialization(type, UpdatedName);
        }

        if (inputLibrary.TryFindEnclosingResourceNameForResourceUpdateModel(model, out var enclosingResourceName))
        {
            var newModelName = $"{enclosingResourceName}Patch";

            _resourceUpdateModelTypes.Add(type.Type);

            type.Update(name: newModelName);

            foreach (var serializationProvider in type.SerializationProviders)
            {
                serializationProvider.Update(name: newModelName);
                _resourceUpdateModelTypes.Add(serializationProvider.Type);
            }
        }
        return base.PreVisitModel(model, type);
    }

    private static void UpdateSerialization(ModelProvider type, string newName)
    {
        if (type.SerializationProviders.Count > 0)
        {
            foreach (var serializationProvider in type.SerializationProviders)
            {
                serializationProvider.Update(name: newName);
            }
        }
    }

    protected override PropertyProvider? PreVisitProperty(InputProperty property, PropertyProvider? propertyProvider)
    {
        DoPreVisitPropertyForResourceTypeName(property, propertyProvider);
        DoPreVisitPropertyForUrlPropertyName(property, propertyProvider);
        return base.PreVisitProperty(property, propertyProvider);
    }

    private void DoPreVisitPropertyForResourceTypeName(InputProperty property, PropertyProvider? propertyProvider)
    {
        if (propertyProvider == null || property is not InputModelProperty)
        {
            return;
        }
        var enclosingType = propertyProvider.EnclosingType;
        if (enclosingType is not InheritableSystemObjectModelProvider modelProvider
            || !modelProvider.CrossLanguageDefinitionId.Equals(KnownManagementTypes.ArmResourceId))
        {
            return;
        }
        // the Azure.ResourceManager.CommonTypes.Resource defines its `type` property as an optional `armResourceType`
        // therefore here we need to change it to required because our common types define it as required
        if (propertyProvider.Type.Equals(_nullableResourceType))
        {
            propertyProvider.Update(name: ResourceTypeName, type: typeof(ResourceType));
        }
    }

    private readonly CSharpType _nullableResourceType = new CSharpType(typeof(ResourceType), isNullable: true);

    private void DoPreVisitPropertyForUrlPropertyName(InputProperty property, PropertyProvider? propertyProvider)
    {
        if (propertyProvider != null && TryTransformUrlToUri(propertyProvider.Name, out var newPropertyName))
        {
            propertyProvider.Update(name: newPropertyName);
        }
    }

    protected override MethodProvider? VisitMethod(MethodProvider method)
    {
        var parameterUpdated = false;
        foreach (var parameter in method.Signature.Parameters)
        {
            if (_resourceUpdateModelTypes.Contains(parameter.Type))
            {
                parameter.Update(name: "patch");
                parameterUpdated = true;
            }
        }

        if (parameterUpdated)
        {
            // This is required as a workaround to update documentation for the method signature
            method.Update(signature: method.Signature);
        }
        return base.VisitMethod(method);
    }

    private bool TryTransformUrlToUri(string name, [MaybeNullWhen(false)] out string newName)
    {
        const char i = 'i';
        const string UrlSuffix = "Url";
        newName = null;
        if (name.Length < UrlSuffix.Length)
        {
            return false;
        }

        var span = name.AsSpan();
        // check if this ends with `Url`
        if (span.EndsWith(UrlSuffix.AsSpan(), StringComparison.Ordinal))
        {
            Span<char> newSpan = span.ToArray();
            newSpan[^1] = i;

            newName = new string(newSpan);
            return true;
        }

        return false;
    }
}

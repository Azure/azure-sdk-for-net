// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Providers;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
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
    private static readonly HashSet<string> _knownTypes = new HashSet<string>()
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

    protected override EnumProvider? PreVisitEnum(InputEnumType enumType, EnumProvider? type)
    {
        if (type is null)
        {
            return null;
        }

        if (_knownTypes.Contains(enumType.Name))
        {
            var newName = $"{ManagementClientGenerator.Instance.TypeFactory.ResourceProviderName}{enumType.Name}";
            type.Update(name: newName);
        }
        return base.PreVisitEnum(enumType, type);
    }

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
        }

        if (_knownTypes.Contains(model.Name))
        {
            newName = $"{ManagementClientGenerator.Instance.TypeFactory.ResourceProviderName}{model.Name}";
            type.Update(name: newName);
        }

        if (inputLibrary.TryFindEnclosingResourceNameForResourceUpdateModel(model, out var enclosingResourceName))
        {
            newName = $"{enclosingResourceName}Patch";
            type.Update(name: newName);
        }
        return base.PreVisitModel(model, type);
    }

    protected override PropertyProvider? PreVisitProperty(InputProperty property, PropertyProvider? propertyProvider)
    {
        DoPreVisitPropertyForResourceTypeName(property, propertyProvider);
        DoPreVisitPropertyForUrlPropertyName(property, propertyProvider);
        DoPreVisitPropertyForTimePropertyName(property, propertyProvider);
        DoPreVisitPropertyNameRenaming(property, propertyProvider);
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

    // Change the property name from XxxTime, XxxDate, XxxDateTime, XxxAt to XxxOn
    private static readonly Dictionary<string, string> _nounToVerbDicts = new()
        {
            {"Creation", "Created"},
            {"Deletion", "Deleted"},
            {"Expiration", "Expire"},
            {"Modification", "Modified"},
        };
    private void DoPreVisitPropertyForTimePropertyName(InputProperty property, PropertyProvider? propertyProvider)
    {
        if (propertyProvider != null && propertyProvider.Type.Equals(typeof(DateTimeOffset)))
        {
            var propertyName = propertyProvider.Name;
            // Skip properties that are not following the pattern we want to change
            if (propertyName.StartsWith("From", StringComparison.Ordinal) ||
                propertyName.StartsWith("To", StringComparison.Ordinal) ||
                propertyName.EndsWith("PointInTime", StringComparison.Ordinal))
            {
                return;
            }

            var lengthToCut = 0;
            if (propertyName.Length > 8 &&
                propertyName.EndsWith("DateTime", StringComparison.Ordinal))
            {
                lengthToCut = 8;
            }
            else if (propertyName.Length > 4 &&
                (propertyName.EndsWith("Time", StringComparison.Ordinal) ||
                propertyName.EndsWith("Date", StringComparison.Ordinal)))
            {
                lengthToCut = 4;
            }
            else if (propertyName.Length > 2 &&
                propertyName.EndsWith("At", StringComparison.Ordinal))
            {
                lengthToCut = 2;
            }
            if (lengthToCut > 0)
            {
                var prefix = propertyName.Substring(0, propertyName.Length - lengthToCut);
                var newPropertyName = (_nounToVerbDicts.TryGetValue(prefix, out var verb) ? verb : prefix) + "On";
                propertyProvider.Update(name: newPropertyName);
            }
        }
    }

    // Dictionary to hold property name renaming mappings
    private static readonly Dictionary<string, string> _propertyNameRenamingMap = new()
        {
            {"Etag", "ETag"}
        };

    private void DoPreVisitPropertyNameRenaming(InputProperty property, PropertyProvider? propertyProvider)
    {
        if (propertyProvider != null && _propertyNameRenamingMap.TryGetValue(propertyProvider.Name, out var newPropertyName))
        {
            propertyProvider.Update(name: newPropertyName);
        }
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

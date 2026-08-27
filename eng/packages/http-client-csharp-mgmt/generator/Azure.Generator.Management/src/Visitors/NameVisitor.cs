// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Primitives;
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

        type = base.PreVisitModel(model, type);
        if (type is null)
        {
            return null;
        }

        if (TryTransformUrlToUri(type.Name, out var newName))
        {
            type.Update(name: newName);
        }

        if (_knownTypes.Contains(model.Name))
        {
            // Compose with type.Name (not model.Name) so any prior provider-level rename
            // (e.g. ResourceDataModelProvider's "Data" suffix) is preserved.
            newName = $"{ManagementClientGenerator.Instance.TypeFactory.ResourceProviderName}{type.Name}";
            type.Update(name: newName);
        }

        if (inputLibrary.TryFindEnclosingResourceNameForResourceUpdateModel(model, out var enclosingResourceName, out var isAlsoUsedInCreate))
        {
            // Honor user-provided @@clientName(.., "csharp") only on the patch-only path.
            // When the same model is also used as the Create body we always rename to
            // {Resource}CreateOrUpdateContent to keep the Create/Update parameter type
            // consistent across the SDK surface.
            if (isAlsoUsedInCreate)
            {
                newName = $"{enclosingResourceName}CreateOrUpdateContent";
                type.Update(name: newName);
            }
            else if (!inputLibrary.ClientNameOverriddenModels.Contains(model))
            {
                // PATCH-only payloads use {Resource}Patch unless the service provided an explicit clientName.
                newName = $"{enclosingResourceName}Patch";
                type.Update(name: newName);
            }
        }
        return type;
    }

    protected override PropertyProvider? PreVisitProperty(InputProperty property, PropertyProvider? propertyProvider)
    {
        DoPreVisitPropertyForResourceTypeName(property, propertyProvider);
        DoPreVisitPropertyForUrlPropertyName(property, propertyProvider);
        DoPreVisitPropertyNameRenaming(property, propertyProvider);
        return base.PreVisitProperty(property, propertyProvider);
    }

    private static readonly HashSet<string> _mtgDateTimeVerbPrefixes = new(StringComparer.OrdinalIgnoreCase)
    {
        "Change",
        "Creation",
        "Deletion",
        "End",
        "Expiration",
        "Expire",
        "Modification",
        "Start",
    };

    internal static bool IsMtgRenamedDateTimeProperty(PropertyProvider? property)
    {
        if (property?.WireInfo is not { } wireInfo ||
            wireInfo.SerializationFormat is not (
                SerializationFormat.DateTime_RFC1123 or
                SerializationFormat.DateTime_RFC3339 or
                SerializationFormat.DateTime_RFC7231 or
                SerializationFormat.DateTime_ISO8601 or
                SerializationFormat.DateTime_Unix or
                SerializationFormat.Date_ISO8601))
        {
            return false;
        }

        var name = wireInfo.SerializedName;
        var suffixLength = GetMtgDateTimeSuffixLength(name);
        if (suffixLength == 0 || suffixLength == name.Length || HasExcludedMtgDateTimeComponent(name, suffixLength))
        {
            return false;
        }

        if (name.EndsWith("Timestamp", StringComparison.OrdinalIgnoreCase) ||
            name.EndsWith("TimeStamp", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        var prefix = name[..^suffixLength];
        foreach (var key in _mtgDateTimeVerbPrefixes)
        {
            if (prefix.Equals(key, StringComparison.OrdinalIgnoreCase) ||
                (prefix.Length > key.Length &&
                 prefix.EndsWith(key, StringComparison.OrdinalIgnoreCase) &&
                 char.IsUpper(prefix[^key.Length])))
            {
                return true;
            }
        }

        return false;
    }

    private static int GetMtgDateTimeSuffixLength(string name)
    {
        if (name.EndsWith("Timestamp", StringComparison.OrdinalIgnoreCase) ||
            name.EndsWith("TimeStamp", StringComparison.OrdinalIgnoreCase))
        {
            return "Timestamp".Length;
        }

        if (name.EndsWith("DateTime", StringComparison.OrdinalIgnoreCase))
        {
            return "DateTime".Length;
        }

        if (name.EndsWith("Time", StringComparison.OrdinalIgnoreCase) ||
            name.EndsWith("Date", StringComparison.OrdinalIgnoreCase))
        {
            return "Time".Length;
        }

        if (name.EndsWith("On", StringComparison.OrdinalIgnoreCase))
        {
            return "On".Length;
        }

        return name.EndsWith("At", StringComparison.OrdinalIgnoreCase) ? "At".Length : 0;
    }

    private static bool HasExcludedMtgDateTimeComponent(string name, int suffixLength)
    {
        var prefix = name[..^suffixLength];
        return prefix.Equals("First", StringComparison.OrdinalIgnoreCase) ||
            prefix.Equals("Last", StringComparison.OrdinalIgnoreCase) ||
            name.StartsWith("From", StringComparison.OrdinalIgnoreCase) ||
            name.StartsWith("To", StringComparison.OrdinalIgnoreCase) ||
            name.EndsWith("PointInTime", StringComparison.OrdinalIgnoreCase) ||
            name.Equals("StatusTimestamp", StringComparison.OrdinalIgnoreCase) ||
            name.Equals("StatusTimeStamp", StringComparison.OrdinalIgnoreCase);
    }

    private void DoPreVisitPropertyForResourceTypeName(InputProperty property, PropertyProvider? propertyProvider)
    {
        if (propertyProvider == null || property is not InputModelProperty)
        {
            return;
        }
        var enclosingType = propertyProvider.EnclosingType;
        if (enclosingType is not SystemObjectModelProvider modelProvider
            || modelProvider.CrossLanguageDefinitionId?.Equals(KnownManagementTypes.ArmResourceId) != true)
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

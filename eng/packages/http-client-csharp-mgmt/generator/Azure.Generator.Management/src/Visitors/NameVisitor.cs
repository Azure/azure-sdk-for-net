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
        DoPreVisitPropertyForTimePropertyName(property, propertyProvider);
        DoPreVisitPropertyNameRenaming(property, propertyProvider);
        return base.PreVisitProperty(property, propertyProvider);
    }

    protected override ClientProvider? Visit(InputClient client, ClientProvider? clientProvider)
    {
        foreach (var method in client.Methods)
        {
            var parameters = new HashSet<InputParameter>();
            foreach (var parameter in method.Parameters)
            {
                parameters.Add(parameter);
            }
            foreach (var parameter in method.Operation.Parameters)
            {
                parameters.Add(parameter);
            }
            foreach (var parameter in parameters)
            {
                DoPreVisitParameterForTimeName(parameter);
            }
        }
        return base.Visit(client, clientProvider);
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
        if (propertyProvider != null &&
            IsDateTimeInputType(property.Type) &&
            TryTransformDateTimeName(propertyProvider.Name, out var newPropertyName))
        {
            propertyProvider.Update(name: newPropertyName);
        }
    }

    private void DoPreVisitParameterForTimeName(InputParameter parameter)
    {
        if (IsDateTimeInputType(parameter.Type) &&
            TryTransformDateTimeName(parameter.Name, out var newParameterName))
        {
            parameter.Update(name: newParameterName);
        }
    }

    private static bool TryTransformDateTimeName(string name, [MaybeNullWhen(false)] out string newName)
    {
        newName = null;
        if (name.StartsWith("From", StringComparison.OrdinalIgnoreCase) ||
            name.StartsWith("To", StringComparison.OrdinalIgnoreCase) ||
            name.EndsWith("PointInTime", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        var lengthToCut = 0;
        if ((name.Length > 9 &&
            (name.EndsWith("Timestamp", StringComparison.Ordinal) ||
            name.EndsWith("TimeStamp", StringComparison.Ordinal))) ||
            name.Equals("Timestamp", StringComparison.OrdinalIgnoreCase))
        {
            lengthToCut = 9;
        }
        else if (name.Length > 8 &&
            name.EndsWith("DateTime", StringComparison.Ordinal))
        {
            lengthToCut = 8;
        }
        else if (name.Length > 4 &&
            (name.EndsWith("Time", StringComparison.Ordinal) ||
            name.EndsWith("Date", StringComparison.Ordinal)))
        {
            lengthToCut = 4;
        }
        else if (name.Equals("Date", StringComparison.OrdinalIgnoreCase))
        {
            lengthToCut = 4;
        }
        else if (name.Length > 2 &&
            name.EndsWith("At", StringComparison.Ordinal))
        {
            lengthToCut = 2;
        }

        if (lengthToCut == 0)
        {
            return false;
        }

        var prefix = name.Substring(0, name.Length - lengthToCut);
        newName = (_nounToVerbDicts.TryGetValue(prefix, out var verb) ? verb : prefix) +
            (prefix.Length == 0 && char.IsLower(name[0]) ? "on" : "On");
        return true;
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

    /// <summary>
    /// Checks the input type (rather than the C# type) to determine if it represents a date/time,
    /// so the rename logic works regardless of what C# type the downstream generator maps it to
    /// (e.g., DateTimeOffset, BicepValue&lt;DateTimeOffset&gt;, etc.).
    /// </summary>
    private static bool IsDateTimeInputType(InputType inputType) => inputType switch
    {
        InputDateTimeType => true,
        InputPrimitiveType { Kind: InputPrimitiveTypeKind.PlainDate } => true,
        InputNullableType nullableType => IsDateTimeInputType(nullableType.Type),
        _ => false
    };
}

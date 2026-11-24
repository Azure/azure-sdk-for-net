// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;

namespace Azure.Generator.Management.Primitives;

internal static class OperationStatusErrorModel
{
    internal static IReadOnlyList<InputModelType> AddStatusErrorModels(IReadOnlyList<InputModelType> models, IReadOnlyList<InputEnumType> enums)
    {
        List<InputModelType>? result = null;
        HashSet<string>? reservedNames = null;
        var scopedErrors = new Dictionary<(string Namespace, InputModelType Error), InputModelType>();
        foreach (var status in models.Where(model => model.CrossLanguageDefinitionId == KnownManagementTypes.OperationStatusResultModelId))
        {
            var property = status.Properties.FirstOrDefault(property => property.SerializedName == "error");
            if (UnwrapNullable(property?.Type) is not InputModelType error || error.CrossLanguageDefinitionId != KnownManagementTypes.ErrorDetailModelId)
            {
                continue;
            }

            // Keep the existing ResponseError mapping for exceptions and unrelated model
            // properties. Only the status payload uses a distinct, lossless error model.
            var key = (status.Namespace, error);
            if (!scopedErrors.TryGetValue(key, out var scopedError))
            {
                result ??= models.ToList();
                // MPG brings types from different input namespaces into the same output
                // namespace. Reserve names across both model and enum inventories.
                reservedNames ??= models.Select(model => model.Name.ToIdentifierName())
                    .Concat(enums.Select(type => type.Name.ToIdentifierName())).ToHashSet(System.StringComparer.OrdinalIgnoreCase);
                scopedError = CreateStatusError(error, status, result, reservedNames);
                scopedErrors.Add(key, scopedError);
            }
            property!.Update(type: ReplaceModel(property.Type, error, scopedError));
        }
        return result ?? models;
    }

    internal static bool HasPersistenceOnlyExtensions(InputModelType model)
        => model is ScopedErrorModel { HasPersistenceOnlyExtensions: true };

    internal static bool NeedsGeneratedName(InputModelType model)
        => model is ScopedErrorModel || (model.CrossLanguageDefinitionId == KnownManagementTypes.OperationStatusResultModelId
            && model.Name == "OperationStatusResult" && !model.IsExactName);

    internal static IReadOnlyDictionary<InputModelType, string> BuildOutputNames(InputNamespace input)
    {
        var generator = ManagementClientGenerator.Instance;
        var source = generator.SourceInputModel;
        var modelsNamespace = $"{generator.TypeFactory.PrimaryNamespace}.Models";
        // Unlike the input graph, this runs after the customization compilation is available.
        // Reserve actual source type names as well as schema names (including the normal
        // response-to-result transformation for generated model names).
        var reserved = input.Models.Where(model => model is not ScopedErrorModel)
            .Select(model => model.Name.ToIdentifierName())
            .Concat(input.Enums.Select(type => type.Name.ToIdentifierName()))
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
        foreach (var name in reserved.ToArray())
        {
            if (name.EndsWith("Response", StringComparison.Ordinal))
            {
                reserved.Add($"{name[..^"Response".Length]}Result");
            }
        }
        if (source.Customization is { } customization)
        {
            ReserveSourceNames(customization.Assembly.GlobalNamespace, reserved);
        }

        var names = new Dictionary<InputModelType, string>();
        foreach (var model in input.Models.Where(NeedsGeneratedName))
        {
            var preferred = model is ScopedErrorModel scoped
                ? scoped.PreferredName
                : $"{generator.TypeFactory.ResourceProviderName}OperationStatusResult";
            var candidate = preferred;
            for (var suffix = 2; reserved.Contains(candidate) || source.FindForTypeInCurrentCompilation(modelsNamespace, candidate) is not null; suffix++)
            {
                candidate = $"{preferred}{suffix}";
            }
            reserved.Add(candidate);
            names.Add(model, candidate);
        }
        return names;
    }

    private static void ReserveSourceNames(INamespaceSymbol ns, HashSet<string> reserved)
    {
        foreach (var type in ns.GetTypeMembers())
        {
            reserved.Add(type.Name);
        }
        foreach (var child in ns.GetNamespaceMembers())
        {
            ReserveSourceNames(child, reserved);
        }
    }

    internal static bool IsStatusPayloadModel(InputModelType model)
    {
        var visited = new HashSet<InputModelType>();
        for (InputModelType? current = model; current is not null && visited.Add(current); current = current.BaseModel)
        {
            if (current is ScopedErrorModel || current.CrossLanguageDefinitionId == KnownManagementTypes.OperationStatusResultModelId)
            {
                return true;
            }
        }
        return false;
    }

    private static InputModelType CreateStatusError(InputModelType error, InputModelType status,
        List<InputModelType> models, HashSet<string> reservedNames)
    {
        // Unlike the common ErrorDetail model, this is a regular JSON payload model.
        var usage = (status.Usage & (InputModelTypeUsage.Input | InputModelTypeUsage.Output)) | InputModelTypeUsage.Json;
        const string errorName = "OperationStatusError";
        var model = new ScopedErrorModel(error, status.Namespace, AllocateName(errorName, reservedNames), errorName,
            usage, error.AdditionalProperties ?? InputPrimitiveType.Any, hasPersistenceOnlyExtensions: error.AdditionalProperties is null);
        models.Add(model);

        var infoProperty = error.Properties.FirstOrDefault(property => property.SerializedName == "additionalInfo");
        var originalInfo = UnwrapNullable(infoProperty?.Type) is InputArrayType array ? UnwrapNullable(array.ValueType) as InputModelType : null;
        InputModelType? scopedInfo = null;
        if (originalInfo is not null)
        {
            const string infoName = "OperationStatusErrorAdditionalInfo";
            scopedInfo = new ScopedErrorModel(originalInfo, status.Namespace, AllocateName(infoName, reservedNames), infoName,
                usage, originalInfo.AdditionalProperties);
            scopedInfo.Update(properties: originalInfo.Properties.Select(property => CopyProperty(property,
                property.SerializedName == "info" && property.Type is not InputNullableType ? new InputNullableType(property.Type) : property.Type)));
            models.Add(scopedInfo);
        }

        model.Update(properties: error.Properties.Select(property => CopyProperty(property,
            scopedInfo is not null && ReferenceEquals(property, infoProperty)
                ? ReplaceModel(property.Type, originalInfo!, scopedInfo)
                : ReplaceModel(property.Type, error, model))));
        return model;
    }

    private static string AllocateName(string name, HashSet<string> reservedNames)
    {
        var candidate = name;
        for (var suffix = 2; !reservedNames.Add(candidate); suffix++)
        {
            candidate = $"{name}{suffix}";
        }
        return candidate;
    }

    private static InputModelProperty CopyProperty(InputModelProperty property, InputType type) => new(property.Name,
        property.Summary, property.Doc, type, property.IsRequired, property.IsReadOnly, property.Access, property.IsDiscriminator,
        property.SerializedName, property.IsHttpMetadata, property.IsApiVersion, property.DefaultValue, property.SerializationOptions!,
        property.Encode, property.ApiVersions);

    private static InputType? UnwrapNullable(InputType? type) => type is InputNullableType nullable ? nullable.Type : type;

    private static InputType ReplaceModel(InputType type, InputModelType original, InputModelType replacement) => type switch
    {
        InputNullableType nullable when ReplaceModel(nullable.Type, original, replacement) is var updated &&
            !ReferenceEquals(updated, nullable.Type) => new InputNullableType(updated),
        InputArrayType array when ReplaceModel(array.ValueType, original, replacement) is var updated &&
            !ReferenceEquals(updated, array.ValueType) => new InputArrayType(array.Name, array.CrossLanguageDefinitionId, updated),
        _ when ReferenceEquals(type, original) => replacement,
        _ => type,
    };

    private sealed class ScopedErrorModel(InputModelType source, string ns, string name, string preferredName,
        InputModelTypeUsage usage, InputType? additionalProperties, bool hasPersistenceOnlyExtensions = false)
        : InputModelType(name, ns, $"{ns}.{name}", source.Access, source.Deprecation, source.Summary, source.Doc, usage,
            [], null, [], null, null, new Dictionary<string, InputModelType>(), additionalProperties, false,
            source.SerializationOptions!, false, source.ApiVersions)
    {
        internal string PreferredName { get; } = preferredName;
        internal bool HasPersistenceOnlyExtensions { get; } = hasPersistenceOnlyExtensions;
    }
}

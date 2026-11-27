// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management.Visitors;

internal sealed class MtgDateTimePropertyMatcher
{
    private readonly Dictionary<PropertyProvider, InputProperty> _sourceProperties = new(ReferenceEqualityComparer.Instance);

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

    private static readonly string[] _mtgDateTimeSuffixes =
    [
        "Timestamp",
        "DateTime",
        "Time",
        "Date",
        "On",
        "At",
    ];

    private static readonly Dictionary<string, string> _mpgDateTimeNounToVerb = new(StringComparer.Ordinal)
    {
        ["Creation"] = "Created",
        ["Deletion"] = "Deleted",
        ["Expiration"] = "Expire",
        ["Modification"] = "Modified",
    };

    internal void RegisterSourceProperty(PropertyProvider propertyProvider, InputProperty inputProperty)
    {
        _sourceProperties[propertyProvider] = inputProperty;
    }

    internal void RegisterDerivedProperty(PropertyProvider propertyProvider, PropertyProvider sourceProperty)
    {
        if (_sourceProperties.TryGetValue(sourceProperty, out var inputProperty))
        {
            _sourceProperties[propertyProvider] = inputProperty;
        }
    }

    internal void RegisterCanonicalProperty(PropertyProvider property, ModelProvider model)
    {
        if (_sourceProperties.ContainsKey(property))
        {
            return;
        }

        // Canonical views can substitute a handwritten property for the input-backed provider. Use the
        // canonical wire identity rather than independently guessing MTG's name-precedence decisions.
        var visited = new HashSet<ModelProvider>(ReferenceEqualityComparer.Instance);
        ModelProvider? owner = model;
        while (owner is not null && visited.Add(owner))
        {
            if (owner.CustomCodeView?.Properties.Any(p => ReferenceEquals(p, property)) == true)
            {
                break;
            }
            owner = owner.BaseModelProvider;
        }
        if (owner is null || !visited.Contains(owner) || owner.CustomCodeView?.Properties.Any(p => ReferenceEquals(p, property)) != true)
        {
            return;
        }

        if (property.WireInfo is null || HasCustomSerialization(owner))
        {
            return;
        }

        var ownerTypes = new List<ModelProvider>();
        visited.Clear();
        for (var current = owner; current is not null && visited.Add(current); current = current.BaseModelProvider)
        {
            ownerTypes.Add(current);
        }
        var candidates = _sourceProperties.Where(pair =>
            ownerTypes.Any(candidate => pair.Key.EnclosingType.Type.AreNamesEqual(candidate.Type) &&
                (ReferenceEquals(candidate, owner) || pair.Value.EnclosingType?.External is not null)) &&
            pair.Value.SerializedName == property.WireInfo.SerializedName)
            .Select(pair => pair.Value).Distinct<InputProperty>(ReferenceEqualityComparer.Instance).ToArray();
        if (candidates.Length == 1)
        {
            _sourceProperties[property] = candidates[0];
        }
    }

    private static bool HasCustomSerialization(ModelProvider owner)
    {
        foreach (var attribute in owner.CustomCodeView?.Attributes ?? [])
        {
            try
            {
                if (attribute.Type.Name == "CodeGenSerializationAttribute")
                {
                    return true;
                }
            }
            catch
            {
                // An unresolved attribute could override the wire name, so it cannot establish identity.
                return true;
            }
        }
        return false;
    }

    internal InputProperty? GetSourceProperty(PropertyProvider property)
        => _sourceProperties.TryGetValue(property, out var inputProperty) ? inputProperty : null;

    internal bool IsMtgRenamedDateTimeProperty(PropertyProvider? property)
    {
        if (property is null ||
            !_sourceProperties.TryGetValue(property, out var inputProperty) ||
            !IsDateTimeInputType(inputProperty.Type))
        {
            return false;
        }

        var name = inputProperty.IsExactName ? inputProperty.Name : inputProperty.Name.ToIdentifierName();
        return IsMtgRenamedDateTimeName(name);
    }

    internal bool WasMtgRenamedDateTimePropertyBeforeIdentifierNormalization(PropertyProvider? property)
        => property is not null && _sourceProperties.TryGetValue(property, out var inputProperty) &&
            IsDateTimeInputType(inputProperty.Type) && IsMtgRenamedDateTimeName(inputProperty.Name);

    private static bool IsMtgRenamedDateTimeName(string name)
    {
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

    internal bool TryGetPreviousMpgDateTimePropertyName(PropertyProvider property, out string previousName)
    {
        previousName = string.Empty;
        if (!IsMtgRenamedDateTimeProperty(property) ||
            !_sourceProperties.TryGetValue(property, out var inputProperty))
        {
            return false;
        }

        var inputName = inputProperty.Name.ToIdentifierName();
        if (inputName.EndsWith("Timestamp", StringComparison.OrdinalIgnoreCase) ||
            inputName.EndsWith("TimeStamp", StringComparison.OrdinalIgnoreCase) ||
            inputName.EndsWith("On", StringComparison.OrdinalIgnoreCase))
        {
            previousName = inputName;
            return true;
        }

        var suffixLength = GetPreviousMpgDateTimeSuffixLength(inputName);
        if (suffixLength == 0 || suffixLength == inputName.Length)
        {
            return false;
        }

        var prefix = inputName[..^suffixLength];
        previousName = $"{(_mpgDateTimeNounToVerb.TryGetValue(prefix, out var verb) ? verb : prefix)}On";
        return true;
    }

    internal bool HasSameSourceProperty(PropertyProvider expectedProperty, PropertyProvider? candidateProperty)
        => candidateProperty is not null &&
            _sourceProperties.TryGetValue(expectedProperty, out var expectedInput) &&
            _sourceProperties.TryGetValue(candidateProperty, out var candidateInput) &&
            ReferenceEquals(expectedInput, candidateInput);

    internal bool HasSameSourceProperty(PropertyProvider expectedProperty, ValueExpression candidate)
    {
        if (candidate is not VariableExpression variable ||
            !_sourceProperties.TryGetValue(expectedProperty, out var expectedInput))
        {
            return false;
        }

        foreach (var (property, inputProperty) in _sourceProperties)
        {
            if (ReferenceEquals(expectedInput, inputProperty) &&
                ReferenceEquals(property.AsVariableExpression, variable))
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsDateTimeInputType(InputType inputType) => inputType switch
    {
        InputDateTimeType => true,
        InputPrimitiveType { Kind: InputPrimitiveTypeKind.PlainDate } => true,
        InputNullableType nullableType => IsDateTimeInputType(nullableType.Type),
        _ => false
    };

    private static int GetMtgDateTimeSuffixLength(string name)
    {
        foreach (var candidate in _mtgDateTimeSuffixes)
        {
            if (name.EndsWith(candidate, StringComparison.OrdinalIgnoreCase))
            {
                return candidate.Length;
            }
        }

        return 0;
    }

    private static int GetPreviousMpgDateTimeSuffixLength(string name)
    {
        if (name.Length > "DateTime".Length && name.EndsWith("DateTime", StringComparison.Ordinal))
        {
            return "DateTime".Length;
        }

        if (name.Length > "Time".Length &&
            (name.EndsWith("Time", StringComparison.Ordinal) || name.EndsWith("Date", StringComparison.Ordinal)))
        {
            return "Time".Length;
        }

        return name.Length > "At".Length && name.EndsWith("At", StringComparison.Ordinal)
            ? "At".Length
            : 0;
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
}

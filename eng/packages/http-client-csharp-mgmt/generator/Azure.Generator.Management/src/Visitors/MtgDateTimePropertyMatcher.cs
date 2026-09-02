// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;

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

    internal void RegisterSourceProperty(PropertyProvider propertyProvider, InputProperty inputProperty)
    {
        _sourceProperties[propertyProvider] = inputProperty;
    }

    internal bool IsMtgRenamedDateTimeProperty(PropertyProvider? property)
    {
        if (property is null ||
            !_sourceProperties.TryGetValue(property, out var inputProperty) ||
            !IsDateTimeInputType(inputProperty.Type))
        {
            return false;
        }

        var name = inputProperty.Name;
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

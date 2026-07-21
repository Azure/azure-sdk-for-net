// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Provisioning.Providers;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Provisioning.Utilities
{
    internal sealed class EnumValueCustomizationResolver
    {
        private IReadOnlyDictionary<(string EnumName, string MemberName), EnumValueCustomization>? _values;

        public EnumValueCustomization? GetValue(string enumName, string memberName)
        {
            var values = _values ??= BuildValues();
            return values.TryGetValue((enumName, memberName), out var value) ? value : null;
        }

        public IEnumerable<EnumValueCustomization> GetAdditionalValues(string enumName, HashSet<string> existingMemberNames)
        {
            var values = _values ??= BuildValues();
            foreach (var ((customizedEnumName, memberName), customization) in values)
            {
                if (customizedEnumName == enumName && !existingMemberNames.Contains(memberName))
                {
                    yield return customization;
                }
            }
        }

        public HashSet<int> GetReservedOrdinals(string enumName)
        {
            var values = _values ??= BuildValues();
            return values.Values
                .Where(value => value.EnumName == enumName)
                .Select(value => value.Value)
                .ToHashSet();
        }

        private static IReadOnlyDictionary<(string EnumName, string MemberName), EnumValueCustomization> BuildValues()
        {
            var customization = ProvisioningGenerator.Instance.SourceInputModel.Customization;
            if (customization is null)
            {
                return new Dictionary<(string, string), EnumValueCustomization>();
            }

            var values = new Dictionary<(string, string), EnumValueCustomization>();
            foreach (var attributeData in customization.Assembly.GetAttributes())
            {
                if (!IsCodeGenEnumValueAttribute(attributeData))
                {
                    continue;
                }

                if (TryGetValue(attributeData, out var value))
                {
                    if (values.ContainsKey((value.EnumName, value.MemberName)))
                    {
                        throw new InvalidOperationException($"Duplicate CodeGenEnumValue customization for {value.EnumName}.{value.MemberName}.");
                    }
                    var duplicate = values.Values.FirstOrDefault(existing => existing.EnumName == value.EnumName && existing.Value == value.Value);
                    if (duplicate != null)
                    {
                        throw new InvalidOperationException($"Duplicate CodeGenEnumValue ordinal {value.Value} for {value.EnumName}.{duplicate.MemberName} and {value.EnumName}.{value.MemberName}.");
                    }
                    values[(value.EnumName, value.MemberName)] = value;
                }
            }
            return values;
        }

        private static bool IsCodeGenEnumValueAttribute(AttributeData attributeData)
        {
            var attributeClass = attributeData.AttributeClass;
            return attributeClass?.ContainingNamespace.ToDisplayString() == "Microsoft.TypeSpec.Generator.Customizations"
                && (attributeClass.Name == CodeGenEnumValueAttributeDefinition.AttributeName
                    || attributeClass.Name == "CodeGenEnumValue");
        }

        private static bool TryGetValue(AttributeData attributeData, out EnumValueCustomization value)
        {
            if (attributeData.ConstructorArguments.Length == 3
                && attributeData.ConstructorArguments[0].Kind == TypedConstantKind.Primitive
                && attributeData.ConstructorArguments[0].Value is string enumNameValue
                && attributeData.ConstructorArguments[1].Kind == TypedConstantKind.Primitive
                && attributeData.ConstructorArguments[1].Value is string memberNameValue
                && attributeData.ConstructorArguments[2].Kind == TypedConstantKind.Primitive
                && attributeData.ConstructorArguments[2].Value is int ordinalValue)
            {
                string? wireName = null;
                foreach (var namedArgument in attributeData.NamedArguments)
                {
                    if (namedArgument.Key == nameof(EnumValueCustomization.WireName)
                        && namedArgument.Value.Kind == TypedConstantKind.Primitive
                        && namedArgument.Value.Value is string wireNameValue)
                    {
                        wireName = wireNameValue;
                    }
                }

                value = new EnumValueCustomization(enumNameValue, memberNameValue, ordinalValue, wireName);
                return true;
            }

            value = null!;
            return false;
        }

        internal sealed record EnumValueCustomization(string EnumName, string MemberName, int Value, string? WireName);
    }
}

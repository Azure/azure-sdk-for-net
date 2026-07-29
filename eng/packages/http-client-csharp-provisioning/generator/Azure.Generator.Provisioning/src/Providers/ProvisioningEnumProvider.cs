// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Provisioning.Providers
{
    /// <summary>
    /// Generates a simple C# enum from an InputEnumType.
    /// Provisioning enums are plain enums (not extensible structs) with optional
    /// [DataMember(Name = "...")] attributes when the serialized value differs
    /// from the C# member name.
    /// </summary>
    internal class ProvisioningEnumProvider : EnumProvider
    {
        private readonly EnumProvider _baseEnumProvider;

        public ProvisioningEnumProvider(InputEnumType inputEnum) : base(inputEnum)
        {
            _baseEnumProvider = EnumProvider.Create(inputEnum, null);
        }

        protected override string BuildName() => _baseEnumProvider.Name;

        protected override string BuildNamespace()
            => ProvisioningGenerator.Instance.TypeFactory.PrimaryNamespace;

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", "Models", $"{Name}.cs");

        protected override TypeSignatureModifiers BuildDeclarationModifiers()
            => TypeSignatureModifiers.Public | TypeSignatureModifiers.Enum;

        protected override bool GetIsEnum() => true;

        protected override FieldProvider[] BuildFields()
        {
            var baseEnumValues = _baseEnumProvider.EnumValues;
            var fields = new List<FieldProvider>(baseEnumValues.Count);
            var usedOrdinals = ProvisioningGenerator.Instance.EnumValueCustomizationResolver.GetReservedOrdinals(Name);
            var existingMemberNames = new HashSet<string>();
            int nextOrdinal = 0;

            for (int i = 0; i < baseEnumValues.Count; i++)
            {
                var baseEnumValue = baseEnumValues[i];
                var baseField = baseEnumValue.Field;
                var memberName = baseEnumValue.Name;
                var serializedValue = baseEnumValue.Value?.ToString();
                var customization = ProvisioningGenerator.Instance.EnumValueCustomizationResolver.GetValue(Name, memberName);
                var fieldOrdinal = customization?.Value ?? GetNextAvailableOrdinal(usedOrdinals, ref nextOrdinal);
                existingMemberNames.Add(memberName);
                var description = string.IsNullOrEmpty(baseField.Description?.ToString())
                    ? (FormattableString)$"{memberName}."
                    : baseField.Description;

                var field = CreateEnumField(memberName, serializedValue, fieldOrdinal, description, baseField.Attributes);

                fields.Add(field);
            }

            foreach (var customization in ProvisioningGenerator.Instance.EnumValueCustomizationResolver.GetAdditionalValues(Name, existingMemberNames))
            {
                fields.Add(CreateEnumField(
                    customization.MemberName,
                    customization.WireName,
                    customization.Value,
                    (FormattableString)$"{customization.MemberName}.",
                    []));
            }

            return [.. fields];
        }

        private FieldProvider CreateEnumField(string memberName, string? serializedValue, int fieldOrdinal, FormattableString description, IEnumerable<AttributeStatement> existingAttributes)
        {
            // Add [DataMember(Name = "...")] when the serialized value differs from the member name.
            IEnumerable<AttributeStatement>? attributes = existingAttributes;
            if (serializedValue != null && serializedValue != memberName)
            {
                attributes =
                [
                    .. existingAttributes,
                    new AttributeStatement(typeof(DataMemberAttribute),
                        [new KeyValuePair<string, ValueExpression>("Name", Literal(serializedValue))])
                ];
            }

            return new FieldProvider(
                FieldModifiers.Public,
                typeof(int), // placeholder — enum members don't need an explicit type
                memberName,
                this,
                description: description,
                initializationValue: Literal(fieldOrdinal),
                attributes: attributes);
        }

        private static int GetNextAvailableOrdinal(HashSet<int> usedOrdinals, ref int nextOrdinal)
        {
            while (usedOrdinals.Contains(nextOrdinal))
            {
                nextOrdinal++;
            }
            return nextOrdinal++;
        }

        protected override TypeProvider[] BuildSerializationProviders()
            => [];

        protected override IReadOnlyList<EnumTypeMember> BuildEnumValues()
        {
            var baseEnumValues = _baseEnumProvider.EnumValues;
            var members = new List<EnumTypeMember>(Fields.Count);
            for (int i = 0; i < baseEnumValues.Count; i++)
            {
                members.Add(new EnumTypeMember(Fields[i].Name, Fields[i], baseEnumValues[i].Value));
            }

            var existingMemberNames = baseEnumValues.Select(v => v.Name).ToHashSet();
            foreach (var customization in ProvisioningGenerator.Instance.EnumValueCustomizationResolver.GetAdditionalValues(Name, existingMemberNames))
            {
                var field = Fields.FirstOrDefault(f => f.Name == customization.MemberName);
                if (field != null)
                {
                    members.Add(new EnumTypeMember(field.Name, field, customization.WireName ?? customization.MemberName));
                }
            }

            return members;
        }
    }
}

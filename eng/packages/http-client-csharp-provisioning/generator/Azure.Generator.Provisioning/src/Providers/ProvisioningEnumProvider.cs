// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using System.IO;
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
            var fields = new FieldProvider[baseEnumValues.Count];

            for (int i = 0; i < baseEnumValues.Count; i++)
            {
                var baseEnumValue = baseEnumValues[i];
                var baseField = baseEnumValue.Field;
                var memberName = baseEnumValue.Name;
                var serializedValue = baseEnumValue.Value?.ToString();

                // Add [DataMember(Name = "...")] when the serialized value differs from the member name.
                IEnumerable<AttributeStatement>? attributes = baseField.Attributes;
                if (serializedValue != null && serializedValue != memberName)
                {
                    attributes =
                    [
                        .. baseField.Attributes,
                        new AttributeStatement(typeof(DataMemberAttribute),
                            [new KeyValuePair<string, ValueExpression>("Name", Literal(serializedValue))])
                    ];
                }

                var field = new FieldProvider(
                    FieldModifiers.Public,
                    typeof(int), // placeholder — enum members don't need an explicit type
                    memberName,
                    this,
                    description: baseField.Description,
                    attributes: attributes);

                fields[i] = field;
            }

            return fields;
        }

        protected override TypeProvider[] BuildSerializationProviders()
            => [];

        protected override IReadOnlyList<EnumTypeMember> BuildEnumValues()
        {
            var baseEnumValues = _baseEnumProvider.EnumValues;
            var members = new EnumTypeMember[baseEnumValues.Count];
            for (int i = 0; i < baseEnumValues.Count; i++)
            {
                members[i] = new EnumTypeMember(Fields[i].Name, Fields[i], baseEnumValues[i].Value);
            }
            return members;
        }
    }
}

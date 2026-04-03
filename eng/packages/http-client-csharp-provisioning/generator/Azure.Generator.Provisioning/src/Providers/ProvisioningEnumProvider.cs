// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
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
        private readonly InputEnumType _inputEnum;

        public ProvisioningEnumProvider(InputEnumType inputEnum) : base(inputEnum)
        {
            _inputEnum = inputEnum;
        }

        protected override string BuildName() => _inputEnum.Name.ToIdentifierName();

        protected override string BuildNamespace()
            => ProvisioningGenerator.Instance.TypeFactory.PrimaryNamespace;

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", "Models", $"{Name}.cs");

        protected override TypeSignatureModifiers BuildDeclarationModifiers()
            => TypeSignatureModifiers.Public | TypeSignatureModifiers.Enum;

        protected override FieldProvider[] BuildFields()
        {
            var fields = new List<FieldProvider>();

            foreach (var value in _inputEnum.Values)
            {
                var memberName = value.Name.ToIdentifierName();
                var serializedValue = value.Value?.ToString();

                // Add [DataMember(Name = "...")] when the serialized value differs from the member name
                List<AttributeStatement>? attributes = null;
                if (serializedValue != null && serializedValue != memberName)
                {
                    attributes =
                    [
                        new AttributeStatement(typeof(DataMemberAttribute),
                            [new KeyValuePair<string, ValueExpression>("Name", Literal(serializedValue))])
                    ];
                }

                var field = new FieldProvider(
                    FieldModifiers.Public,
                    typeof(int), // placeholder — enum members don't need an explicit type
                    memberName,
                    this,
                    description: (FormattableString)$"{value.Doc ?? $"{memberName}."}",
                    attributes: attributes);

                fields.Add(field);
            }

            return [.. fields];
        }

        protected override TypeProvider[] BuildSerializationProviders()
            => [];

        protected override IReadOnlyList<EnumTypeMember> BuildEnumValues()
        {
            var members = new List<EnumTypeMember>(_inputEnum.Values.Count);
            for (int i = 0; i < _inputEnum.Values.Count; i++)
            {
                var value = _inputEnum.Values[i];
                members.Add(new EnumTypeMember(value.Name.ToIdentifierName(), Fields[i], value.Value));
            }
            return members;
        }
    }
}

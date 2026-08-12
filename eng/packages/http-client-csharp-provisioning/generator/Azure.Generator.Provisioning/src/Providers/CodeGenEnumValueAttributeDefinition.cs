// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.IO;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Provisioning.Providers
{
    internal sealed class CodeGenEnumValueAttributeDefinition : CustomCodeAttributeDefinition
    {
        public const string AttributeName = "CodeGenEnumValueAttribute";

        private readonly FieldProvider _enumNameField;
        private readonly FieldProvider _memberNameField;
        private readonly FieldProvider _valueField;

        public CodeGenEnumValueAttributeDefinition()
        {
            _enumNameField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(string), "_enumName", this);
            _memberNameField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(string), "_memberName", this);
            _valueField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(int), "_value", this);
        }

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "Internal", $"{Name}.cs");

        protected override string BuildName() => AttributeName;

        protected override string BuildNamespace() => "Microsoft.TypeSpec.Generator.Customizations";

        protected override TypeSignatureModifiers BuildDeclarationModifiers() => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Class;

        protected override CSharpType[] BuildImplements() => [typeof(Attribute)];

        protected override FieldProvider[] BuildFields() => [_enumNameField, _memberNameField, _valueField];

        protected override PropertyProvider[] BuildProperties()
        {
            return
            [
                new PropertyProvider(null, MethodSignatureModifiers.Public, typeof(string), "EnumName", new ExpressionPropertyBody(_enumNameField), this),
                new PropertyProvider(null, MethodSignatureModifiers.Public, typeof(string), "MemberName", new ExpressionPropertyBody(_memberNameField), this),
                new PropertyProvider(null, MethodSignatureModifiers.Public, typeof(int), "Value", new ExpressionPropertyBody(_valueField), this),
                new PropertyProvider(null, MethodSignatureModifiers.Public, new CSharpType(typeof(string), isNullable: true), "WireName", new AutoPropertyBody(true), this)
            ];
        }

        protected override IReadOnlyList<AttributeStatement> BuildAttributes()
        {
            return [new AttributeStatement(typeof(AttributeUsageAttribute), [FrameworkEnumValue(AttributeTargets.Assembly)], [new KeyValuePair<string, ValueExpression>("AllowMultiple", Literal(true))])];
        }

        protected override ConstructorProvider[] BuildConstructors()
        {
            var enumNameParameter = new ParameterProvider("enumName", $"The generated enum type name.", typeof(string));
            var memberNameParameter = new ParameterProvider("memberName", $"The generated enum member name.", typeof(string));
            var valueParameter = new ParameterProvider("value", $"The explicit enum member value.", typeof(int));
            var ctorSignature = new ConstructorSignature(Type, null, MethodSignatureModifiers.Public, [enumNameParameter, memberNameParameter, valueParameter]);
            var body = new MethodBodyStatement[]
            {
                _enumNameField.Assign(enumNameParameter).Terminate(),
                _memberNameField.Assign(memberNameParameter).Terminate(),
                _valueField.Assign(valueParameter).Terminate()
            };
            return [new ConstructorProvider(ctorSignature, body, this)];
        }
    }
}

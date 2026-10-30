// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.IO;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;
using BicepIdentifierExpression = Azure.Provisioning.Expressions.IdentifierExpression;

namespace Azure.Generator.Provisioning.Providers
{
    internal sealed class ProvisioningResourceReferenceProvider : TypeProvider
    {
        private class Template<T> where T : ProvisionableResource { }

        private readonly CSharpType _resourceType = typeof(Template<>).GetGenericArguments()[0];
        private readonly FieldProvider _reference;
        private readonly FieldProvider _value;

        public ProvisioningResourceReferenceProvider()
        {
            _reference = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly,
                new CSharpType(typeof(BicepValue<>), typeof(string)), "_reference", this);
            _value = new FieldProvider(FieldModifiers.Private, _resourceType.WithNullable(true), "_value", this);
        }

        protected override string BuildName() => "ProvisioningResourceReference";

        protected override string BuildNamespace() => ProvisioningGenerator.Instance.TypeFactory.PrimaryNamespace;

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "Internal", $"{Name}.cs");

        protected override TypeSignatureModifiers BuildDeclarationModifiers()
            => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Sealed | TypeSignatureModifiers.Class;

        protected override CSharpType[] GetTypeArguments() => [_resourceType];

        protected override WhereExpression BuildWhereClause() => Where.Implements(_resourceType, typeof(ProvisionableResource));

        protected override FieldProvider[] BuildFields() => [_reference, _value];

        protected override ConstructorProvider[] BuildConstructors()
        {
            var reference = new ParameterProvider("reference", $"The underlying Bicep value.", _reference.Type);
            return
            [
                new ConstructorProvider(
                    new ConstructorSignature(Type, null, MethodSignatureModifiers.Internal, [reference]),
                    _reference.Assign(reference).Terminate(),
                    this)
            ];
        }

        protected override PropertyProvider[] BuildProperties()
        {
            MethodBodyStatement[] setter =
            [
                _value.Assign(Value).Terminate(),
                new IfElseStatement(
                    Value.Is(Null),
                    _reference.AsValueExpression.Invoke(nameof(BicepValue<string>.ClearValue)).Terminate(),
                    _reference.AsValueExpression.CastTo(typeof(IBicepValue)).Property(nameof(IBicepValue.Expression)).Assign(
                        New.Instance(typeof(BicepIdentifierExpression),
                            [Value.Property(nameof(ProvisionableResource.BicepIdentifier))])).Terminate())
            ];
            return
            [
                new PropertyProvider(null, MethodSignatureModifiers.Internal, _value.Type, "Value",
                    new MethodPropertyBody(Return(_value), setter), this)
            ];
        }
    }
}

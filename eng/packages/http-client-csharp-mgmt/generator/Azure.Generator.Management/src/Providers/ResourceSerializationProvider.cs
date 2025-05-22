// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.ClientModel.Primitives;
using System.IO;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal class ResourceSerializationProvider : TypeProvider
    {
        private readonly FieldProvider _dataField;
        private readonly CSharpType _resourceDataType;
        private readonly ResourceClientProvider _resoruce;
        public ResourceSerializationProvider(ResourceClientProvider resource)
        {
            _resoruce = resource;
            _resourceDataType = resource.ResourceData.Type;
            _dataField = new FieldProvider(FieldModifiers.Private | FieldModifiers.Static, _resourceDataType, "s_dataDeserializationInstance", this);
        }

        protected override string BuildName() => _resoruce.Name;

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", $"{Name}.Serialization.cs");

        protected override TypeSignatureModifiers BuildDeclarationModifiers()
            => TypeSignatureModifiers.Public | TypeSignatureModifiers.Partial;

        protected override CSharpType[] BuildImplements() => [new CSharpType(typeof(IJsonModel<>), _resourceDataType)];

        protected override FieldProvider[] BuildFields() => [_dataField];

        protected override PropertyProvider[] BuildProperties() =>
            [
                new PropertyProvider(null, MethodSignatureModifiers.Private | MethodSignatureModifiers.Static, _resourceDataType, "DataDeserializationInstance", new ExpressionPropertyBody(new AssignmentExpression(_dataField, New.Instance(_resourceDataType))), this)
            ];

        protected override MethodProvider[] BuildMethods() => [];
    }
}
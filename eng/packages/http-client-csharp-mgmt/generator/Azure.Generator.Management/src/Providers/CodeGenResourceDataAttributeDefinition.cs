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

namespace Azure.Generator.Management.Providers;

internal sealed class CodeGenResourceDataAttributeDefinition : CustomCodeAttributeDefinition
{
    public const string AttributeName = "CodeGenResourceDataAttribute";
    private readonly FieldProvider _dataTypeField;

    public CodeGenResourceDataAttributeDefinition()
    {
        _dataTypeField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(Type), "_dataType", this);
    }

    protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "Internal", $"{Name}.cs");

    protected override string BuildName() => AttributeName;

    protected override string BuildNamespace() => "Microsoft.TypeSpec.Generator.Customizations";

    protected override TypeSignatureModifiers BuildDeclarationModifiers() => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Class;

    protected override CSharpType[] BuildImplements() => [typeof(Attribute)];

    protected override FieldProvider[] BuildFields() => [_dataTypeField];

    protected override PropertyProvider[] BuildProperties()
    {
        return
        [
            new PropertyProvider(null, MethodSignatureModifiers.Public, typeof(Type), "DataType", new ExpressionPropertyBody(_dataTypeField), this)
        ];
    }

    protected override IReadOnlyList<AttributeStatement> BuildAttributes()
    {
        return [new AttributeStatement(typeof(AttributeUsageAttribute),
            [
                FrameworkEnumValue(AttributeTargets.Class),
            ])];
    }

    protected override ConstructorProvider[] BuildConstructors()
    {
        var dataTypeParameter = new ParameterProvider("dataType", $"The resource data type.", typeof(Type));
        var ctorSignature = new ConstructorSignature(Type, null, MethodSignatureModifiers.Public, [dataTypeParameter]);
        var ctor = new ConstructorProvider(ctorSignature, _dataTypeField.Assign(dataTypeParameter).Terminate(), this);

        return [ctor];
    }
}

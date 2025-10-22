// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.IO;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers;

internal sealed class WirePathAttributeDefinition : TypeProvider
{
    private readonly FieldProvider _wirePathField;
    public WirePathAttributeDefinition()
    {
        _wirePathField = new FieldProvider(FieldModifiers.Private, typeof(string), "_wirePath", this);
    }

    protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "Internal", $"{Name}.cs");

    protected override string BuildName() => "WirePathAttribute";

    protected override TypeSignatureModifiers BuildDeclarationModifiers() => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Class;

    protected override CSharpType[] BuildImplements() => [typeof(Attribute)];

    protected override IReadOnlyList<MethodBodyStatement> BuildAttributes()
    {
        return [new AttributeStatement(typeof(AttributeUsageAttribute),
            [
                FrameworkEnumValue(AttributeTargets.Property),
            ])];
    }

    protected override FieldProvider[] BuildFields() => [_wirePathField];

    protected override ConstructorProvider[] BuildConstructors()
    {
        var wirePathParameter = new ParameterProvider("wirePath", $"The wire path", typeof(string));
        var ctorSignature = new ConstructorSignature(Type, null, MethodSignatureModifiers.Public, [wirePathParameter]);
        var body = _wirePathField.Assign(wirePathParameter).Terminate();
        var ctor = new ConstructorProvider(ctorSignature, body, this);

        return [ctor];
    }
}

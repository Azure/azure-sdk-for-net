// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers;

internal sealed class CodeGenResourceDataAttributeDefinition : TypeProvider
{
    public const string AttributeName = "CodeGenResourceDataAttribute";

    public CodeGenResourceDataAttributeDefinition()
    {
        // Custom-code attribute providers are compiled before SourceInputModel is initialized.
        // Attribute definitions should not themselves participate in customization lookup.
        SuppressSourceInputView("_customCodeView");
        SuppressSourceInputView("_lastContractView");
    }

    protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "Internal", $"{Name}.cs");

    protected override string BuildName() => AttributeName;

    protected override TypeSignatureModifiers BuildDeclarationModifiers() => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Class;

    protected override CSharpType[] BuildImplements() => [typeof(Attribute)];

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
        var ctor = new ConstructorProvider(ctorSignature, MethodBodyStatement.Empty, this);

        return [ctor];
    }

    private void SuppressSourceInputView(string fieldName)
    {
        var currentType = typeof(TypeProvider);
        while (currentType is not null)
        {
            var field = currentType.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            if (field is not null)
            {
                field.SetValue(this, new Lazy<TypeProvider>(() => null!));
                return;
            }

            currentType = currentType.BaseType;
        }
    }
}

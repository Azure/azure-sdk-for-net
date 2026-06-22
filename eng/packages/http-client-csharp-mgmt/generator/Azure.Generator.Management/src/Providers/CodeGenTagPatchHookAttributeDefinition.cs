// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers;

internal sealed class CodeGenTagPatchHookAttributeDefinition : TypeProvider
{
    public const string AttributeName = "CodeGenTagPatchHookAttribute";
    private readonly FieldProvider _methodNameField;

    public CodeGenTagPatchHookAttributeDefinition()
    {
        _methodNameField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(string), "_methodName", this);
        // Custom-code attribute providers are compiled before SourceInputModel is initialized.
        // This generated attribute definition should not itself participate in customization lookup.
        SuppressSourceInputView("_customCodeView");
        SuppressSourceInputView("_lastContractView");
    }

    protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "Internal", $"{Name}.cs");

    protected override string BuildName() => AttributeName;

    protected override string BuildNamespace() => "Microsoft.TypeSpec.Generator.Customizations";

    protected override TypeSignatureModifiers BuildDeclarationModifiers() => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Class;

    protected override CSharpType[] BuildImplements() => [typeof(Attribute)];

    protected override FieldProvider[] BuildFields() => [_methodNameField];

    protected override PropertyProvider[] BuildProperties()
    {
        return
        [
            new PropertyProvider(null, MethodSignatureModifiers.Public, typeof(string), "MethodName", new ExpressionPropertyBody(_methodNameField), this)
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
        var methodNameParameter = new ParameterProvider("methodName", $"The tag patch hook method name.", typeof(string));
        var ctorSignature = new ConstructorSignature(Type, null, MethodSignatureModifiers.Public, [methodNameParameter]);
        var ctor = new ConstructorProvider(ctorSignature, _methodNameField.Assign(methodNameParameter).Terminate(), this);

        return [ctor];
    }

    private void SuppressSourceInputView(string fieldName)
    {
        // TODO: Remove this reflection workaround when the base generator provides a supported
        // source-input-view opt-out for contributed custom-code attribute providers.
        // https://github.com/microsoft/typespec/issues/10993
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

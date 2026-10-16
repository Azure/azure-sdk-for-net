// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace StorageMcp.Generator;

internal sealed class ContainerOptionsProvider(InputMethodParameter container)
    : McpProvider("GeneratedContainerCreateOptions")
{
    protected override PropertyProvider[] BuildProperties() =>
    [
        Option("Account", Literal("The name of the Azure Storage account. This is the unique name you chose for your storage account (e.g., 'mystorageaccount').")),
        Option("Container", Literal(container.Doc ?? container.Summary ?? "The container name.")),
        Option("Tenant", Static(ExistingType("Azure.Mcp.Core.Options", "OptionDescriptions")).Property("Tenant"))
    ];

    private PropertyProvider Option(string name, ValueExpression description) =>
        new(description: null, modifiers: MethodSignatureModifiers.Public, type: typeof(string), name: name,
            body: new AutoPropertyBody(HasSetter: true), enclosingType: this,
            attributes:
            [
                new AttributeStatement(ExistingType("Microsoft.Mcp.Core.Options", "OptionAttribute"),
                    [], [new KeyValuePair<string, ValueExpression>("Description", description)])
            ]);
}

// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using System.Globalization;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace StorageMcp.Generator;

internal sealed class ContainerCatalogProvider(ToolSelection selection, InputServiceMethod method)
    : McpProvider("ContainerCreateCatalog")
{
    protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
        TypeSignatureModifiers.Internal | TypeSignatureModifiers.Class | TypeSignatureModifiers.Static;

    protected override FieldProvider[] BuildFields()
    {
        var flags = selection.Safety.Apply(ToolSafety.FromHttpMethod(method.Operation.HttpMethod.ToString()));
        var command = ExistingType("Azure.Mcp.Tools.Storage.Commands.Blob.Container", "ContainerCreateCommand");
        return
        [
            Constant("Id", selection.Id),
            Constant("Name", selection.Name),
            Constant("Title", selection.Title),
            Constant("Path", string.Join(' ', selection.Group.Append(selection.Name))),
            Constant("OperationId", selection.OperationId),
            Constant("DraftDescription", method.Documentation ?? method.Summary ?? method.Name),
            new FieldProvider(FieldModifiers.Public | FieldModifiers.Const, typeof(string), "Description", this,
                initializationValue: selection.UseDescriptionOverride
                    ? Static(command).Property("CustomizedDescription")
                    : Literal(method.Documentation ?? method.Summary ?? method.Name)),
            Flag("Destructive", flags.Destructive),
            Flag("Idempotent", flags.Idempotent),
            Flag("ReadOnly", flags.ReadOnly),
            Flag("OpenWorld", flags.OpenWorld)
        ];
    }

    protected override MethodProvider[] BuildMethods()
    {
        var group = new ParameterProvider("group", $"The existing manifest-selected command group.",
            ExistingType("Microsoft.Mcp.Core.Commands", "CommandGroup"));
        var services = new ParameterProvider("services", $"The service provider.", typeof(IServiceProvider));
        var command = ExistingType("Azure.Mcp.Tools.Storage.Commands.Blob.Container", "ContainerCreateCommand");
        var status = new ParameterProvider("status", $"The HTTP status code.", typeof(int));
        var message = new ParameterProvider("message", $"The SDK error detail.", typeof(string));
        return
        [
            new MethodProvider(new MethodSignature("Register", $"Registers the curated operation.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static, null, null, [group, services]),
                ((ValueExpression)group).Invoke("AddCommand", [services], [command]).Terminate(), this),
            new MethodProvider(new MethodSignature("GetDefaultError", $"Formats the generated status-code error default.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static, typeof(string), null, [status, message]),
                Static(typeof(string)).Invoke("Format",
                    [Static(typeof(CultureInfo)).Property("InvariantCulture"),
                        Literal("Storage request failed (HTTP {0}): {1}"), status, message]), this)
        ];
    }

    private FieldProvider Constant(string name, string value) =>
        new(FieldModifiers.Public | FieldModifiers.Const, typeof(string), name, this, initializationValue: Literal(value));

    private FieldProvider Flag(string name, bool value) =>
        new(FieldModifiers.Public | FieldModifiers.Const, typeof(bool), name, this, initializationValue: Literal(value));
}

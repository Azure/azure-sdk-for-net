// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Globalization;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Microsoft.TypeSpec.Generator.Mcp;

internal sealed class CommandProvider : McpProvider
{
    private readonly CommandModel _model;
    private readonly TypeProvider _options;
    internal CommandResultProvider Result { get; }

    internal CommandProvider(McpManifest manifest, CommandModel model, TypeProvider options)
        : base(manifest, model.Selection.Prefix + "Command")
    {
        _model = model;
        _options = options;
        Result = new CommandResultProvider(manifest, this, model);
    }

    protected override string BuildNamespace() => _model.Selection.CommandType[.._model.Selection.CommandType.LastIndexOf('.')];
    protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
        TypeSignatureModifiers.Public | TypeSignatureModifiers.Sealed | TypeSignatureModifiers.Class | TypeSignatureModifiers.Partial;

    protected override CSharpType BuildBaseType() =>
        ExistingType("Microsoft.Mcp.Core.Commands", "AuthenticatedCommand`2").MakeGenericType(
            [_options.Type, new NestedResultReference(Manifest, _model.Selection).Type]);

    protected override TypeProvider[] BuildNestedTypes() => [Result];

    protected override AttributeStatement[] BuildAttributes()
    {
        var selection = _model.Selection;
        var flags = selection.Safety.Apply(ToolSafety.FromHttpMethod(_model.Operation.Operation.HttpMethod.ToString()));
        return
        [
            new AttributeStatement(ExistingType("Microsoft.Mcp.Core.Commands", "CommandMetadataAttribute"), [],
            [
                new("Id", Literal(selection.Id)),
                new("Name", Literal(selection.Path.Split(' ')[^1])),
                new("Title", Literal(selection.Title)),
                new("Description", CommandDescription(_model)),
                new("OperationPlane", Static(ExistingType("Microsoft.Mcp.Core.Commands", "ToolOperationPlane")).Property("Data")),
                new("Destructive", Literal(flags.Destructive)),
                new("Idempotent", Literal(flags.Idempotent)),
                new("OpenWorld", Literal(flags.OpenWorld)),
                new("ReadOnly", Literal(flags.ReadOnly)),
                new("Secret", False),
                new("LocalRequired", False)
            ])
        ];
    }

    internal static ValueExpression CommandDescription(CommandModel model) => model.Selection.Description is { } member
        ? Static(ResolveType(member.Type)).Property(member.Member)
        : Literal(model.Operation.Documentation ?? model.Operation.Summary ?? model.Operation.Name);

    protected override ConstructorProvider[] BuildConstructors() =>
    [
        new ConstructorProvider(new ConstructorSignature(Type, null, MethodSignatureModifiers.Public,
        [
            new ParameterProvider("logger", $"The command logger.",
                ExistingType("Microsoft.Extensions.Logging", "ILogger`1").MakeGenericType([Type])),
            new ParameterProvider("handler", $"The authenticated service handler.", _model.HandlerType)
        ]), new MethodBodyStatements([]), this)
    ];

    protected override MethodProvider[] BuildMethods()
    {
        var context = new ParameterProvider("context", $"The command context.",
            ExistingType("Microsoft.Mcp.Core.Models.Command", "CommandContext"));
        var options = new ParameterProvider("options", $"The bound command options.", _options.Type);
        var cancellation = new ParameterProvider("cancellationToken", $"The cancellation token.", typeof(CancellationToken));
        var handler = new VariableExpression(_model.HandlerType, "handler");
        var logger = new VariableExpression(ExistingType("Microsoft.Extensions.Logging", "ILogger`1").MakeGenericType([Type]), "logger");
        var arguments = _model.Options.Select(option => ((ValueExpression)options).Property(option.Name)).Append(cancellation).ToArray();
        var result = Declare("value", _model.ReturnType, handler.Invoke(_model.Selection.Handler.Member, arguments, true), out var value);
        var json = new ToolJsonContextProvider(Manifest, _model.Selection.Prefix + "JsonContext", Result);
        var serialized = Static(ExistingType("Microsoft.Mcp.Core.Models.Command", "ResponseResult")).Invoke("Create",
        [
            New.Instance(Result.Type, value),
            Static(json.Type).Property("Default").Property(Result.Name)
        ]);
        var response = ((ValueExpression)context).Property("Response");
        var declaration = new DeclarationExpression(typeof(Exception), "exception", out var exception);
        var execute = new MethodProvider(new MethodSignature("ExecuteAsync", $"Executes the selected service operation.",
            MethodSignatureModifiers.Public | MethodSignatureModifiers.Override | MethodSignatureModifiers.Async,
            new CSharpType(typeof(Task<>), ExistingType("Microsoft.Mcp.Core.Models.Command", "CommandResponse")), null,
            [context, options, cancellation]), new MethodBodyStatements(
            [
                new TryCatchFinallyStatement(new TryExpression(
                [
                    result,
                    response.Property("Results").Assign(serialized).Terminate()
                ]), new CatchExpression(declaration,
                [
                    Static(ExistingType("Microsoft.Extensions.Logging", "LoggerExtensions")).Invoke("LogError",
                        [logger, exception, Literal($"Error executing {_model.Selection.Path}.")]).Terminate(),
                    This.Invoke("HandleException", [context, exception]).Terminate()
                ])),
                Return(response)
            ]), this);
        return _model.Selection.ErrorPolicy is null && _model.Selection.ErrorMessage is null
            ? [execute]
            : [execute, BuildErrorMessage()];
    }

    private MethodProvider BuildErrorMessage()
    {
        var exception = new ParameterProvider("exception", $"The operation failure.", typeof(Exception));
        var statements = new List<MethodBodyStatement>();
        if (_model.Selection.ErrorPolicy is { } policy)
        {
            statements.Add(Declare("message", typeof(string),
                Static(ResolveType(policy.Type)).Invoke(policy.Member, [exception]), out var message));
            statements.Add(new IfStatement(message.NotEqual(Null)) { Return(message) });
        }
        if (_model.Selection.ErrorMessage is { } format)
        {
            var declaration = new DeclarationExpression(ExistingType("Azure", "RequestFailedException"), "request", out var request);
            statements.Add(new IfStatement(((ValueExpression)exception).Is(declaration))
            {
                Return(Static(typeof(string)).Invoke("Format",
                    [Static(typeof(CultureInfo)).Property("InvariantCulture"), Literal(format), request.Property("Status"), request.Property("Message")]))
            });
        }
        statements.Add(Return(Base.Invoke("GetErrorMessage", [exception])));
        return new MethodProvider(new MethodSignature("GetErrorMessage", $"Applies reviewed service error policy.",
            MethodSignatureModifiers.Protected | MethodSignatureModifiers.Override, typeof(string), null, [exception]),
            new MethodBodyStatements(statements), this);
    }
}

// A qualified reference avoids recursively building the enclosing command's generic base type.
internal sealed class NestedResultReference(McpManifest manifest, CommandSelection selection)
    : McpProvider(manifest, selection.Prefix + "Command." + selection.Prefix + "CommandResult")
{
    protected override string BuildNamespace() => selection.CommandType[..selection.CommandType.LastIndexOf('.')];
}

internal sealed class CommandResultProvider(McpManifest manifest, TypeProvider command, CommandModel model)
    : McpProvider(manifest, model.Selection.Prefix + "CommandResult")
{
    protected override TypeProvider BuildDeclaringTypeProvider() => command;
    protected override string BuildNamespace() => model.Selection.CommandType[..model.Selection.CommandType.LastIndexOf('.')];
    protected override PropertyProvider[] BuildProperties() =>
    [
        new PropertyProvider(null, MethodSignatureModifiers.Public, model.ReturnType, model.Selection.ResultName,
            new AutoPropertyBody(false), this)
    ];

    protected override ConstructorProvider[] BuildConstructors()
    {
        var parameter = new ParameterProvider("value", $"The service result.", model.ReturnType);
        return
        [
            new ConstructorProvider(new ConstructorSignature(Type, null, MethodSignatureModifiers.Public, [parameter]),
                This.Property(model.Selection.ResultName).Assign(parameter).Terminate(), this)
        ];
    }
}

internal sealed class CommandCatalogProvider(McpManifest manifest, CommandModel model, TypeProvider command)
    : McpProvider(manifest, model.Selection.Prefix + "Catalog")
{
    protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
        TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static | TypeSignatureModifiers.Class;

    protected override FieldProvider[] BuildFields()
    {
        var flags = model.Selection.Safety.Apply(ToolSafety.FromHttpMethod(model.Operation.Operation.HttpMethod.ToString()));
        return
        [
            Constant("Id", model.Selection.Id),
            Constant("Path", model.Selection.Path),
            Constant("OperationId", model.Selection.OperationId),
            new FieldProvider(FieldModifiers.Public | FieldModifiers.Const, typeof(string), "Description", this,
                initializationValue: CommandProvider.CommandDescription(model)),
            Flag("Destructive", flags.Destructive),
            Flag("Idempotent", flags.Idempotent),
            Flag("ReadOnly", flags.ReadOnly),
            Flag("OpenWorld", flags.OpenWorld)
        ];
    }

    protected override MethodProvider[] BuildMethods()
    {
        var group = new ParameterProvider("group", $"The selected command group.", ExistingType("Microsoft.Mcp.Core.Commands", "CommandGroup"));
        var services = new ParameterProvider("services", $"The service provider.", typeof(IServiceProvider));
        return
        [
            new MethodProvider(new MethodSignature("Register", $"Registers the generated command.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static, null, null, [group, services]),
                ((ValueExpression)group).Invoke("AddCommand", [services], [command.Type]).Terminate(), this)
        ];
    }

    private FieldProvider Constant(string name, string value) =>
        new(FieldModifiers.Public | FieldModifiers.Const, typeof(string), name, this, initializationValue: Literal(value));
    private FieldProvider Flag(string name, bool value) =>
        new(FieldModifiers.Public | FieldModifiers.Const, typeof(bool), name, this, initializationValue: Literal(value));
}

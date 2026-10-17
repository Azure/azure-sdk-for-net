// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using System.Text.Json.Serialization.Metadata;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Microsoft.TypeSpec.Generator.Mcp;

internal sealed class ArmCommandProvider(McpManifest manifest, ArmBinding binding, TypeProvider options,
    TypeProvider result, TypeProvider adapter, TypeProvider json) : McpProvider(manifest, binding.Prefix + "Command")
{
    protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
        TypeSignatureModifiers.Public | TypeSignatureModifiers.Sealed | TypeSignatureModifiers.Partial | TypeSignatureModifiers.Class;

    protected override CSharpType BuildBaseType() =>
        ExistingType("Azure.Mcp.Core.Commands.Subscription", "SubscriptionCommand`2").MakeGenericType([options.Type, result.Type]);

    protected override PropertyProvider[] BuildProperties() =>
    [
        new(null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
            new CSharpType(typeof(JsonTypeInfo<>), [result.Type]), "ResultTypeInfo",
            new ExpressionPropertyBody(Static(json.Type).Property("Default").Property(result.Name)), this)
    ];

    protected override ConstructorProvider[] BuildConstructors()
    {
        var resolver = new ParameterProvider("subscriptionResolver", $"The shared subscription resolver.",
            ExistingType("Azure.Mcp.Core.Services.Azure.Subscription", "ISubscriptionResolver"));
        return
        [
            new ConstructorProvider(new ConstructorSignature(Type, null, MethodSignatureModifiers.Public,
            [
                new ParameterProvider("logger", $"The command logger.",
                    ExistingType("Microsoft.Extensions.Logging", "ILogger`1").MakeGenericType([Type])),
                resolver,
                new ParameterProvider("getSubscription", $"The shared authenticated subscription hook.", binding.HookType),
                new ParameterProvider("getArmEndpoint", $"The shared configured ARM cloud endpoint hook.", new CSharpType(typeof(Func<>), [typeof(Uri)]))
            ], initializer: new ConstructorInitializer(true, [resolver])), new MethodBodyStatements([]), this)
        ];
    }

    protected override AttributeStatement[] BuildAttributes() =>
    [
        new AttributeStatement(ExistingType("Microsoft.Mcp.Core.Commands", "CommandMetadataAttribute"), [],
        [
            new("Id", Literal(binding.Selection.Id)),
            new("Name", Literal(binding.Selection.Path.Split(' ')[^1])),
            new("Title", Literal(binding.Selection.Title)),
            new("Description", Literal(binding.Target.ServiceMethod!.Documentation ?? binding.Selection.Title)),
            new("OperationPlane", Static(ExistingType("Microsoft.Mcp.Core.Commands", "ToolOperationPlane")).Property("Control")),
            new("Destructive", False), new("Idempotent", True), new("ReadOnly", True),
            new("OpenWorld", Literal(binding.Selection.Safety.Apply(ToolSafety.FromHttpMethod("GET")).OpenWorld)),
            new("Secret", False), new("LocalRequired", False)
        ])
    ];

    protected override MethodProvider[] BuildMethods()
    {
        var context = new ParameterProvider("context", $"The command context.",
            ExistingType("Microsoft.Mcp.Core.Models.Command", "CommandContext"));
        var input = new ParameterProvider("options", $"The bound tool options.", options.Type);
        var token = new ParameterProvider("cancellationToken", $"The cancellation token.", typeof(CancellationToken));
        var logger = new VariableExpression(ExistingType("Microsoft.Extensions.Logging", "ILogger`1").MakeGenericType([Type]), "logger");
        var hook = new VariableExpression(binding.HookType, "getSubscription");
        var endpoint = new VariableExpression(new CSharpType(typeof(Func<>), [typeof(Uri)]), "getArmEndpoint").Invoke("Invoke");
        var declaration = new DeclarationExpression(typeof(Exception), "exception", out var exception);
        var response = ((ValueExpression)context).Property("Response");
        return
        [
            new MethodProvider(new MethodSignature("ExecuteAsync", $"Calls the referenced ARM SDK for {binding.Selection.OperationId}.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Override | MethodSignatureModifiers.Async,
                new CSharpType(typeof(Task<>), [ExistingType("Microsoft.Mcp.Core.Models.Command", "CommandResponse")]),
                null, [context, input, token]), new MethodBodyStatements(
            [
                new TryCatchFinallyStatement(new TryExpression(
                [
                    Declare("value", result.Type, Static(adapter.Type).Invoke("ExecuteAsync", [input, hook, endpoint, token], true), out var value),
                    response.Property("Results").Assign(Static(ExistingType("Microsoft.Mcp.Core.Models.Command", "ResponseResult"))
                        .Invoke("Create", [value, Static(json.Type).Property("Default").Property(result.Name)])).Terminate()
                ]), new CatchExpression(declaration,
                [
                    Static(ExistingType("Microsoft.Extensions.Logging", "LoggerExtensions")).Invoke("LogError",
                        [logger, exception, Literal($"Error executing {binding.Selection.Path}.")]).Terminate(),
                    This.Invoke("HandleException", [context, exception]).Terminate()
                ])),
                Return(response)
            ]), this)
        ];
    }
}

internal sealed class ArmCatalogProvider(McpManifest manifest, ArmBinding binding, TypeProvider command)
    : McpProvider(manifest, binding.Prefix + "Catalog")
{
    protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
        TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static | TypeSignatureModifiers.Class;

    protected override FieldProvider[] BuildFields() =>
    [
        new(FieldModifiers.Public | FieldModifiers.Const, typeof(string), "Id", this, initializationValue: Literal(binding.Selection.Id)),
        new(FieldModifiers.Public | FieldModifiers.Const, typeof(string), "Path", this, initializationValue: Literal(binding.Selection.Path)),
        new(FieldModifiers.Public | FieldModifiers.Const, typeof(string), "OperationId", this, initializationValue: Literal(binding.Selection.OperationId))
    ];

    protected override MethodProvider[] BuildMethods()
    {
        var group = new ParameterProvider("group", $"The selected command group.", ExistingType("Microsoft.Mcp.Core.Commands", "CommandGroup"));
        var services = new ParameterProvider("services", $"The service provider.", typeof(IServiceProvider));
        return
        [
            new MethodProvider(new MethodSignature("Register", $"Registers the generated command.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static, null, null, [group, services]),
                ((ValueExpression)group).Invoke("AddCommand", [services], typeArgs: [command.Type]).Terminate(), this)
        ];
    }
}

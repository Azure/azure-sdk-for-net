// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.RegularExpressions;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Microsoft.TypeSpec.Generator.Mcp;

internal sealed class ArmResultProvider(McpManifest manifest, ArmBinding binding) : McpProvider(manifest, binding.Prefix + "Result")
{
    protected override PropertyProvider[] BuildProperties() =>
    [
        new(null, MethodSignatureModifiers.Public, binding.Paging ? typeof(JsonElement[]) : typeof(JsonElement),
            binding.Paging ? "Items" : "Data", new AutoPropertyBody(true), this),
        .. binding.Paging
            ? new[] { new PropertyProvider(null, MethodSignatureModifiers.Public, new CSharpType(typeof(string), true),
                "ContinuationToken", new AutoPropertyBody(true), this) }
            : []
    ];
}

internal sealed class ArmOptionsProvider(McpManifest manifest, ArmBinding binding) : McpProvider(manifest, binding.Prefix + "Options")
{
    internal static string RewriteSource(string source)
    {
        var root = CSharpSyntaxTree.ParseText(source).GetRoot();
        var type = root.DescendantNodes().OfType<ClassDeclarationSyntax>().Single();
        var declaration = type.WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SingletonSeparatedList<BaseTypeSyntax>(
            SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName("global::Azure.Mcp.Core.Options.ISubscriptionOption")))));
        return root.ReplaceNode(type, declaration).NormalizeWhitespace(eol: "\n").ToFullString() + "\n";
    }

    protected override CSharpType[] BuildImplements() =>
        [ExistingType("Azure.Mcp.Core.Options", "ISubscriptionOption")];

    protected override PropertyProvider[] BuildProperties() => binding.Options.Select(option =>
        new PropertyProvider(null, MethodSignatureModifiers.Public, typeof(string), option.Name,
            new AutoPropertyBody(true), this, attributes:
            [
                new AttributeStatement(ExistingType("Microsoft.Mcp.Core.Options", "OptionAttribute"), [],
                    [new("Description", Literal(option.Description!))])
            ])).ToArray();
}

internal sealed class ArmSdkAdapterProvider(McpManifest manifest, ArmBinding binding, TypeProvider options, TypeProvider result)
    : McpProvider(manifest, binding.Prefix + "SdkAdapter")
{
    protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
        TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static | TypeSignatureModifiers.Class;

    protected override MethodProvider[] BuildMethods()
    {
        var input = new ParameterProvider("options", $"The tool inputs.", options.Type);
        var hook = new ParameterProvider("getSubscription", $"The shared authenticated subscription hook.", binding.HookType);
        var endpoint = new ParameterProvider("armEndpoint", $"The shared configured ARM cloud endpoint.", typeof(Uri));
        var cancellation = new ParameterProvider("cancellationToken", $"The cancellation token.", typeof(CancellationToken));
        var statements = new List<MethodBodyStatement>();
        foreach (var option in binding.Options.Where(option => option.Required))
        {
            statements.Add(new IfStatement(Static(typeof(string)).Invoke("IsNullOrWhiteSpace", [input.Property(option.Name)]))
            {
                Throw(New.Instance(ExistingType("Microsoft.Mcp.Core.Commands", "CommandValidationException"),
                    Literal($"'{option.Name}' is required.")))
            });
        }
        foreach (var pair in binding.Selection.ParameterConstraints ?? [])
        {
            var option = binding.Options.SingleOrDefault(option => option.Name == binding.OptionFor(pair.Key));
            if (option is { Required: true })
            {
                if (pair.Value.MinLength is int min)
                {
                    statements.Add(Invalid(input.Property(option.Name).Property("Length").LessThan(Literal(min)), option.Name));
                }
                if (pair.Value.MaxLength is int max)
                {
                    statements.Add(Invalid(input.Property(option.Name).Property("Length").GreaterThan(Literal(max)), option.Name));
                }
                if (pair.Value.Pattern is { } pattern)
                {
                    statements.Add(Invalid(Static(typeof(Regex)).Invoke("IsMatch",
                        [input.Property(option.Name), Literal(pattern), Static(typeof(RegexOptions)).Property("CultureInvariant"),
                            Static(typeof(TimeSpan)).Invoke("FromSeconds", [Literal(1)])]).Equal(False), option.Name));
                }
            }
        }
        statements.Add(
            Declare("subscription", typeof(SubscriptionResource),
                ((ValueExpression)hook).Invoke("Invoke", [input.Property("Subscription"), input.Property("Tenant"), cancellation], true), out var subscription));
        var clientName = new CodeWriterDeclaration("client");
        statements.Add(Declare("armClient", typeof(ArmClient),
            subscription.Invoke("GetCachedClient", [new FuncExpression([clientName], new VariableExpression(typeof(ArmClient), clientName))]),
            out var client));
        ValueExpression receiver;
        if (binding.Identifier is { } identifier)
        {
            var id = Static(binding.Resource.Type).Invoke(identifier.Signature.Name,
                identifier.Signature.Parameters.Select(parameter => parameter.Name == "subscriptionId"
                    ? subscription.Property("Id").Property("SubscriptionId")
                    : input.Property(binding.OptionFor(parameter.Name))).ToArray());
            receiver = Static(binding.Navigation.EnclosingType.Type).Invoke(binding.Navigation.Signature.Name, [client, id]);
        }
        else if (binding.Navigation.Signature.Parameters.First().Type.Equals(typeof(ResourceGroupResource)))
        {
            var groupId = Static(typeof(ResourceGroupResource)).Invoke("CreateResourceIdentifier",
                [subscription.Property("Id").Property("SubscriptionId"), input.Property("ResourceGroup")]);
            var group = client.Invoke("GetResourceGroupResource", [groupId]);
            receiver = Static(binding.Navigation.EnclosingType.Type).Invoke(binding.Navigation.Signature.Name, [group]);
        }
        else
        {
            receiver = subscription;
        }
        if (!binding.Paging)
        {
            statements.Add(Declare("response", binding.Target.Signature.ReturnType!.Arguments.Single(),
                receiver.Invoke(binding.Target.Signature.Name, [cancellation], true), out var response));
            statements.Add(Return(New.Instance(result.Type, new Dictionary<ValueExpression, ValueExpression>
            {
                [new VariableExpression(typeof(JsonElement), "Data")] = Project(response.Property("Value").Property("Data"))
            })));
        }
        else
        {
            var paging = binding.Navigation.Signature.Parameters.First().Type.Equals(typeof(SubscriptionResource))
                ? Static(binding.Navigation.EnclosingType.Type).Invoke(binding.Navigation.Signature.Name, [receiver, cancellation])
                : receiver.Invoke(binding.Target.Signature.Name, [cancellation]);
            var scope = binding.ScopePath;
            var args = new List<ValueExpression>();
            foreach (var parameter in binding.Target.ServiceMethod!.Operation.Parameters.OfType<Microsoft.TypeSpec.Generator.Input.InputPathParameter>()
                .Where(parameter => parameter.Scope != Microsoft.TypeSpec.Generator.Input.InputParameterScope.Constant))
            {
                scope = scope.Replace("{" + parameter.Name + "}", "{" + args.Count + "}", StringComparison.Ordinal);
                args.Add(Static(typeof(Uri)).Invoke("EscapeDataString",
                    parameter.Name == "subscriptionId" ? subscription.Property("Id").Property("SubscriptionId") : input.Property(binding.OptionFor(parameter.Name))));
            }
            statements.Add(Declare("scopePath", typeof(string), Static(typeof(string)).Invoke("Format",
                new[] { (ValueExpression)Literal(scope) }.Concat(args).ToArray()), out var scopePath));
            var token = Static(new CSharpType(typeof(ArmToolPageToken))).Invoke("Resume",
                [input.Property("ContinuationToken"), Literal(binding.Selection.OperationId), scopePath, endpoint]);
            var pages = paging.Invoke("AsPages", [token]);
            var loop = new ForEachStatement(new CSharpType(typeof(Page<>), [binding.Resource.Type]), "page", pages, true, out var page);
            var itemName = new CodeWriterDeclaration("item");
            var projected = Static(typeof(Enumerable)).Invoke("Select", [page.Property("Values"),
                new FuncExpression([itemName],
                    Project(new VariableExpression(binding.Resource.Type, itemName).Property("Data")))]);
            loop.Add(Return(New.Instance(result.Type, new Dictionary<ValueExpression, ValueExpression>
            {
                [new VariableExpression(typeof(JsonElement[]), "Items")] = Static(typeof(Enumerable)).Invoke("ToArray", [projected]),
                [new VariableExpression(typeof(string), "ContinuationToken")] = Static(new CSharpType(typeof(ArmToolPageToken))).Invoke("Wrap",
                    [page.Property("ContinuationToken"), Literal(binding.Selection.OperationId), scopePath, endpoint])
            })));
            statements.Add(loop);
            statements.Add(Return(New.Instance(result.Type, new Dictionary<ValueExpression, ValueExpression>
            {
                [new VariableExpression(typeof(JsonElement[]), "Items")] = New.Array(typeof(JsonElement), [])
            })));
        }
        return [new MethodProvider(new MethodSignature("ExecuteAsync", $"Calls the stock ARM SDK binding for {binding.Selection.OperationId}.",
            MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Async,
            new CSharpType(typeof(Task<>), [result.Type]), null, [input, hook, endpoint, cancellation]),
            new MethodBodyStatements(statements), this)];
    }

    private ValueExpression Project(ValueExpression data) => Static(typeof(JsonElement)).Invoke("Parse",
        [data.CastTo(new CSharpType(typeof(IPersistableModel<>), [binding.DataType]))
            .Invoke("Write", [Static(typeof(ModelReaderWriterOptions)).Property("Json")]).Invoke("ToString")]);

    private IfStatement Invalid(ValueExpression condition, string name) => new(condition)
    {
        Throw(New.Instance(ExistingType("Microsoft.Mcp.Core.Commands", "CommandValidationException"),
            Literal($"'{name}' does not match the service name constraints.")))
    };
}

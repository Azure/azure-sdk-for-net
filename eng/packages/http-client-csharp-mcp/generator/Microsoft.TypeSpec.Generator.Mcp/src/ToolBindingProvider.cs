// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Microsoft.TypeSpec.Generator.Mcp;

internal sealed class ToolBindingProvider(McpManifest manifest, ToolSelection selection)
    : McpProvider(manifest, selection.Types.Binding)
{
    protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
        TypeSignatureModifiers.Internal | TypeSignatureModifiers.Class | TypeSignatureModifiers.Static;

    protected override MethodProvider[] BuildMethods()
    {
        var binding = selection.Binding;
        var parameters = binding.Parameters.Select(p => new ParameterProvider(
            p.Name, $"{p.Description}", ResolveType(p.Type))).ToArray();
        var variables = parameters.ToDictionary(p => p.Name, p => (ValueExpression)p, StringComparer.Ordinal);
        var statements = new List<MethodBodyStatement>();
        foreach (var call in binding.Calls)
        {
            var arguments = call.Arguments.Select(argument =>
            {
                var value = argument.Variable is { } variable ? variables[variable] :
                    argument.Member is { } member ? Static(ResolveType(member.Type)).Property(member.Member) :
                    LiteralValue(argument.Literal);
                return argument.Name is { } name ? PositionalReference(name, value) : value;
            }).ToArray();
            var invocation = variables[call.Target].Invoke(call.Method, arguments, call.Await);
            if (call.ResultName is { } result)
            {
                statements.Add(Declare(result, ResolveType(call.ResultType!), invocation, out VariableExpression local));
                variables.Add(result, local);
            }
            else
            {
                statements.Add(invocation.Terminate());
            }
        }
        statements.Add(Return(variables[binding.ReturnVariable]));
        return
        [
            new MethodProvider(new MethodSignature(binding.Method, $"{binding.Description}",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Async,
                new CSharpType(typeof(Task<>), ResolveType(binding.ReturnType)), null, parameters),
                new MethodBodyStatements(statements), this)
        ];
    }

    private static ValueExpression LiteralValue(JsonElement value) => value.ValueKind switch
    {
        JsonValueKind.String => Literal(value.GetString()!),
        JsonValueKind.True => Literal(true),
        JsonValueKind.False => Literal(false),
        JsonValueKind.Null => Null,
        JsonValueKind.Number when value.TryGetInt32(out var number) => Literal(number),
        JsonValueKind.Number when value.TryGetInt64(out var number) => Literal(number),
        JsonValueKind.Number => Literal(value.GetDouble()),
        _ => throw new InvalidOperationException("Unsupported SDK literal.")
    };
}

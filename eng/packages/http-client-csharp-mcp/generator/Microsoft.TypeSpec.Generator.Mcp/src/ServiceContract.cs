// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Microsoft.TypeSpec.Generator.Mcp;

internal sealed record ContractProperty(string Name, CSharpType Type, bool Required, string SerializedName,
    string? Description = null, ValueExpression? Default = null);

internal sealed record ServiceContract(DataContractProvider Request, DataContractProvider Response, ServiceProvider Service)
{
    internal static ServiceContract Create(McpManifest manifest, CommandSelection selection, InputClient client,
        InputServiceMethod method, ContractTypes types)
    {
        McpManifest.Require(method is not (InputLongRunningServiceMethod or InputLongRunningPagingServiceMethod or InputPagingServiceMethod),
            $"Paging and LRO command mappings are not supported for '{selection.OperationId}'.");
        var parameters = new Dictionary<string, InputParameter>(StringComparer.Ordinal);
        for (var ancestor = client; ancestor is not null; ancestor = ancestor.Parent)
        {
            foreach (var parameter in ancestor.Parameters)
            {
                parameters.TryAdd(parameter.Name, parameter);
            }
        }
        foreach (var parameter in method.Parameters)
        {
            McpManifest.Require(!parameters.ContainsKey(parameter.Name),
                $"Ambiguous client/method parameter '{parameter.Name}' in '{selection.OperationId}'.");
            parameters.Add(parameter.Name, parameter);
        }
        var request = new DataContractProvider(manifest, selection.Prefix + "Request", () =>
            parameters.Values.Where(parameter => parameter.Scope != InputParameterScope.Constant)
                .Select(parameter =>
                {
                    McpManifest.Require(parameter.Scope is InputParameterScope.Client or InputParameterScope.Method,
                        $"Unsupported parameter scope '{parameter.Scope}' for '{parameter.Name}'.");
                    return types.Property(parameter);
                }).ToArray());
        var response = new DataContractProvider(manifest, selection.Prefix + "Response", () =>
        [
            new("Status", typeof(int), true, "status", "The HTTP response status code."),
            new("Headers", new CSharpType(typeof(Dictionary<,>), [typeof(string), typeof(string)]), false,
                "headers", "The response headers, including headers from no-body operations."),
            .. method.Response.Type is { } body
                ? new[] { new ContractProperty("Body", types.Resolve(body), true, "body", "The operation response body.") }
                : []
        ]);
        return new(request, response, new ServiceProvider(manifest, selection, request, response));
    }
}

internal sealed class DataContractProvider(McpManifest manifest, string name, Func<ContractProperty[]> properties)
    : McpProvider(manifest, name)
{
    internal ContractProperty[] ContractProperties { get; private set; } = properties();

    internal void SetProperties(ContractProperty[] value) => ContractProperties = value;

    protected override PropertyProvider[] BuildProperties() => ContractProperties.Select(property =>
        new PropertyProvider(property.Description is { } description ? (FormattableString)$"{description}" : null,
            MethodSignatureModifiers.Public, property.Type, property.Name,
            new AutoPropertyBody(true, MethodSignatureModifiers.None, property.Default), this,
            attributes: [new AttributeStatement(typeof(JsonPropertyNameAttribute), [Literal(property.SerializedName)])])).ToArray();
}

internal sealed class ServiceProvider(McpManifest manifest, CommandSelection selection,
    DataContractProvider request, DataContractProvider response) : McpProvider(manifest, selection.ServiceName)
{
    protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
        TypeSignatureModifiers.Public | TypeSignatureModifiers.Partial | TypeSignatureModifiers.Class;

    protected override MethodProvider[] BuildMethods() =>
    [
        new MethodProvider(new MethodSignature(selection.HandlerName + "Async",
            $"Implements {selection.OperationId}; supply SDK calls and policy in a separate partial declaration.",
            MethodSignatureModifiers.Public | MethodSignatureModifiers.Partial,
            new CSharpType(typeof(Task<>), [response.Type]), null,
            [
                new ParameterProvider("request", $"The REST-shaped request.", request.Type),
                new ParameterProvider("cancellationToken", $"The cancellation token.", typeof(CancellationToken))
            ]), this)
    ];
}

internal sealed class ContractTypes(McpManifest manifest)
{
    private readonly Dictionary<InputModelType, DataContractProvider> _models = [];
    internal IEnumerable<DataContractProvider> Models => _models.Values;

    internal ContractProperty Property(InputProperty property) =>
        new(CommandSelection.Pascal(property.Name), Resolve(property.Type), property.IsRequired,
            property.SerializedName ?? property.Name, property.Doc ?? property.Summary, Default(property.DefaultValue));

    internal ContractProperty Property(InputParameter parameter) =>
        new(CommandSelection.Pascal(parameter.Name), Resolve(parameter.Type), parameter.IsRequired,
            parameter.Name, parameter.Doc ?? parameter.Summary, Default(parameter.DefaultValue));

    internal CSharpType Resolve(InputType input) => input switch
    {
        InputNullableType nullable => Resolve(nullable.Type).WithNullable(true),
        InputPrimitiveType primitive => primitive.Kind switch
        {
            InputPrimitiveTypeKind.Boolean => typeof(bool),
            InputPrimitiveTypeKind.String => typeof(string),
            InputPrimitiveTypeKind.Url => typeof(Uri),
            InputPrimitiveTypeKind.Bytes => typeof(byte[]),
            InputPrimitiveTypeKind.Int8 => typeof(sbyte),
            InputPrimitiveTypeKind.Int16 => typeof(short),
            InputPrimitiveTypeKind.Int32 => typeof(int),
            InputPrimitiveTypeKind.Int64 or InputPrimitiveTypeKind.SafeInt => typeof(long),
            InputPrimitiveTypeKind.UInt8 => typeof(byte),
            InputPrimitiveTypeKind.UInt16 => typeof(ushort),
            InputPrimitiveTypeKind.UInt32 => typeof(uint),
            InputPrimitiveTypeKind.UInt64 => typeof(ulong),
            InputPrimitiveTypeKind.Float32 => typeof(float),
            InputPrimitiveTypeKind.Float64 or InputPrimitiveTypeKind.Float => typeof(double),
            InputPrimitiveTypeKind.Decimal or InputPrimitiveTypeKind.Decimal128 => typeof(decimal),
            InputPrimitiveTypeKind.PlainDate => typeof(DateOnly),
            InputPrimitiveTypeKind.PlainTime => typeof(TimeOnly),
            _ => throw new InvalidOperationException($"Unsupported contract primitive '{primitive.Kind}'.")
        },
        InputDictionaryType dictionary => new CSharpType(typeof(Dictionary<,>), [typeof(string), Resolve(dictionary.ValueType)]),
        InputArrayType array => new CSharpType(typeof(List<>), [Resolve(array.ValueType)]),
        InputEnumType { IsExtensible: true } enumeration => Resolve(enumeration.ValueType),
        InputModelType model => Model(model).Type,
        _ => throw new InvalidOperationException($"Unsupported contract type '{input.Name}' ({input.GetType().Name}).")
    };

    private DataContractProvider Model(InputModelType input)
    {
        if (_models.TryGetValue(input, out var existing))
        {
            return existing;
        }
        McpManifest.Require(input.BaseModel is null && input.DiscriminatorProperty is null &&
            input.DerivedModels.Count == 0 && input.AdditionalProperties is null,
            $"Inherited, polymorphic, or open model '{input.Name}' is not supported by this prototype.");
        // Register the type before resolving properties so recursive model references can resolve it.
        var provider = new DataContractProvider(manifest with { Namespace = input.Namespace },
            CommandSelection.Pascal(input.Name), () => []);
        _models.Add(input, provider);
        provider.SetProperties(input.Properties.Select(property => Property(property)).ToArray());
        return provider;
    }

    private static ValueExpression? Default(InputConstant? constant) => constant?.Value switch
    {
        null => null,
        string value => Literal(value),
        bool value => Literal(value),
        int value => Literal(value),
        long value => Literal(value),
        float value => Literal(value),
        double value => Literal(value),
        decimal value => Literal(value),
        _ => throw new InvalidOperationException($"Unsupported contract default '{constant.Value}'.")
    };
}

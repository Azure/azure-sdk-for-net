// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;

namespace Microsoft.TypeSpec.Generator.Mcp;

public sealed record CommandSelection(
    string OperationId, string Namespace, string Name, string Id, string Path, string Title,
    SafetyOverrides Safety, string? InterfaceName = null)
{
    [JsonIgnore]
    public string Prefix => Pascal(InterfaceName ?? "") + Pascal(Name);
    [JsonIgnore]
    public string CommandType => Namespace + "." + Prefix + "Command";
    [JsonIgnore]
    internal string HandlerName => Pascal(Name) + Pascal(InterfaceName ?? "");
    [JsonIgnore]
    internal string ServiceName => Prefix + "Service";

    internal static string Pascal(string name) => string.Concat(Regex.Split(name, @"[^\p{L}\p{Nd}]+")
        .Where(part => part.Length > 0).Select(part => char.ToUpperInvariant(part[0]) + part[1..]));

    internal void Validate()
    {
        McpManifest.Require(Namespace is not null && Namespace.Split('.').All(McpManifest.IsIdentifier) &&
            !string.IsNullOrWhiteSpace(Name) && McpManifest.IsIdentifier(Prefix),
            "Service operation names must derive valid C# identifiers.");
        McpManifest.Require(OperationId == string.Join(".", new[] { Namespace, InterfaceName, Name }.Where(part => part is not null)) &&
            Guid.TryParse(Id, out _), "Commands require the original operation identity and a valid tool GUID.");
        McpManifest.Require(!string.IsNullOrWhiteSpace(Path) && Path.Split(' ').All(McpManifest.IsCommandSegment),
            "A command path must contain valid space-separated segments.");
        McpManifest.Require(!string.IsNullOrWhiteSpace(Title) && Safety is not null, "A title and safety annotations are required.");
    }
}

internal sealed record CommandModel(
    CommandSelection Selection, InputServiceMethod Operation, ServiceContract Contract, OptionMapping[] Options, string ResultName,
    StaticMember? Description, StaticMember? ErrorPolicy, string? ErrorMessage)
{
    internal CSharpType ReturnType => Contract.Response.Type;

    internal static CommandModel Create(CommandSelection selection, InputServiceMethod operation, ServiceContract contract)
    {
        McpManifest.Require(operation is not (InputLongRunningServiceMethod or InputLongRunningPagingServiceMethod or InputPagingServiceMethod),
            $"Paging and LRO command mappings are not supported for '{selection.OperationId}'.");
        var compilation = CodeModelGenerator.Instance.SourceInputModel.Customization
            ?? throw new InvalidOperationException("MCP generation requires a consumer compilation with framework references.");
        var customization = FindCustomization(selection, compilation);
        return new(selection, operation, contract,
            [new OptionMapping("Request", "string", true, $"JSON request matching {contract.Request.Name}.",
                Constant(compilation, customization, "RequestDescription"))],
            selection.InterfaceName is { Length: > 0 } resource ? CommandSelection.Pascal(resource) : "Value",
            Constant(compilation, customization, "Description"), Policy(compilation, customization),
            Constant(compilation, customization, "DefaultErrorMessage") is { } format
                ? (string)customization!.GetMembers(format.Member).OfType<IFieldSymbol>().Single().ConstantValue! : null);
    }

    internal static INamedTypeSymbol? FindCustomization(CommandSelection selection, Compilation compilation)
    {
        var types = SourceTypes(compilation.Assembly.GlobalNamespace).ToArray();
        var customizations = types.Where(type => type.Name == selection.Prefix + "Customization").ToArray();
        McpManifest.Require(customizations.Length <= 1, $"Customization '{selection.Prefix}Customization' must be unique.");
        var customization = customizations.SingleOrDefault();
        McpManifest.Require(customization is null || customization.IsStatic, "Command customizations must be static classes.");
        _ = Constant(compilation, customization, "Description");
        _ = Constant(compilation, customization, "RequestDescription");
        _ = Policy(compilation, customization);
        if (Constant(compilation, customization, "DefaultErrorMessage") is { } format)
        {
            _ = string.Format(System.Globalization.CultureInfo.InvariantCulture,
                (string)customization!.GetMembers(format.Member).OfType<IFieldSymbol>().Single().ConstantValue!, 500, "detail");
        }
        return customization;
    }

    private static IEnumerable<INamedTypeSymbol> SourceTypes(INamespaceSymbol ns) =>
        ns.GetTypeMembers().Where(type => type.DeclaringSyntaxReferences.Length > 0)
            .Concat(ns.GetNamespaceMembers().SelectMany(SourceTypes));

    private static StaticMember? Constant(Compilation compilation, INamedTypeSymbol? type, string name)
    {
        var members = type?.GetMembers(name) ?? [];
        if (members.IsEmpty)
        {
            return null;
        }
        McpManifest.Require(members is [IFieldSymbol { IsConst: true, Type.SpecialType: SpecialType.System_String, ConstantValue: string }] &&
            compilation.IsSymbolAccessibleWithin(members[0], compilation.Assembly),
            $"Customization '{type}.{name}' must be an accessible string constant.");
        return new StaticMember(type!.ToDisplayString(), name);
    }

    private static StaticMember? Policy(Compilation compilation, INamedTypeSymbol? type)
    {
        var members = type?.GetMembers("GetErrorMessage") ?? [];
        if (members.IsEmpty)
        {
            return null;
        }
        McpManifest.Require(members is [IMethodSymbol { IsStatic: true, IsGenericMethod: false,
            Parameters: [{ RefKind: RefKind.None, Type: { } argument }], ReturnType.SpecialType: SpecialType.System_String }] &&
            argument.ToDisplayString() == "System.Exception" && compilation.IsSymbolAccessibleWithin(members[0], compilation.Assembly),
            $"Customization '{type}.GetErrorMessage' must be an accessible static string-returning method accepting Exception.");
        return new StaticMember(type!.ToDisplayString(), "GetErrorMessage");
    }
}

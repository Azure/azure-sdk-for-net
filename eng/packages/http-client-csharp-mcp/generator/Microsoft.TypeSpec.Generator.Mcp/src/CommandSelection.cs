// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Linq;
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
    CommandSelection Selection, InputServiceMethod Operation, CSharpType HandlerType, CSharpType ReturnType,
    OptionMapping[] Options, StaticMember Handler, string ResultName,
    StaticMember? Description, StaticMember? ErrorPolicy, string? ErrorMessage)
{
    internal static CommandModel Create(CommandSelection selection, InputServiceMethod operation)
    {
        McpManifest.Require(operation is not (InputLongRunningServiceMethod or InputLongRunningPagingServiceMethod or InputPagingServiceMethod),
            $"Paging and LRO command mappings are not supported for '{selection.OperationId}'.");
        var compilation = CodeModelGenerator.Instance.SourceInputModel.Customization
            ?? throw new InvalidOperationException("Complete commands require an existing consumer source compilation.");
        var signature = InferHandler(selection, compilation, operation);
        var handler = signature.Method;
        var customization = signature.Customization;
        return new(selection, operation, McpProvider.ResolveType(handler.ContainingType.ToDisplayString()),
            McpProvider.ResolveType(signature.Result.ToDisplayString()), signature.Options,
            new StaticMember(handler.ContainingType.ToDisplayString(), handler.Name),
            selection.InterfaceName is { Length: > 0 } resource ? CommandSelection.Pascal(resource) : signature.Result.Name,
            Constant(compilation, customization, "Description"), Policy(compilation, customization),
            Constant(compilation, customization, "DefaultErrorMessage") is { } format
                ? (string)customization!.GetMembers(format.Member).OfType<IFieldSymbol>().Single().ConstantValue! : null);
    }

    internal static (IMethodSymbol Method, ITypeSymbol Result, OptionMapping[] Options, INamedTypeSymbol? Customization) InferHandler(
        CommandSelection selection, Compilation compilation, InputServiceMethod? operation = null)
    {
        var types = SourceTypes(compilation.Assembly.GlobalNamespace).ToArray();
        var methods = types.Where(type => type.TypeKind == TypeKind.Interface)
            .SelectMany(type => type.GetMembers().OfType<IMethodSymbol>())
            .Where(method => method.Name == selection.HandlerName || method.Name == selection.HandlerName + "Async").ToArray();
        McpManifest.Require(methods is [{ IsStatic: false, IsGenericMethod: false, DeclaredAccessibility: Accessibility.Public,
            ContainingType.IsGenericType: false }],
            $"Operation '{selection.OperationId}' requires exactly one nongeneric source-interface handler named " +
            $"'{selection.HandlerName}' or '{selection.HandlerName}Async'; found {methods.Length}.");
        var method = methods[0];
        McpManifest.Require(compilation.IsSymbolAccessibleWithin(method, compilation.Assembly),
            "The service handler must be accessible to the generated command.");
        McpManifest.Require(method.ReturnType is INamedTypeSymbol { Name: "Task", Arity: 1 } task &&
            task.ContainingNamespace.ToDisplayString() == "System.Threading.Tasks",
            $"A command handler must return Task<T>; '{method}' resolves to '{method.ReturnType.ToDisplayString()}'.");
        var result = ((INamedTypeSymbol)method.ReturnType).TypeArguments[0];
        McpManifest.Require(result is INamedTypeSymbol { IsGenericType: false, TypeKind: TypeKind.Class or TypeKind.Struct } &&
            result.NullableAnnotation != NullableAnnotation.Annotated,
            "A command handler must return a nonnullable, nongeneric result model.");
        var cancellation = method.Parameters.Where(parameter => parameter.Type.ToDisplayString() == "System.Threading.CancellationToken").ToArray();
        McpManifest.Require(cancellation.Length == 1 && SymbolEqualityComparer.Default.Equals(cancellation[0], method.Parameters.LastOrDefault()),
            "A command handler must accept exactly one CancellationToken as its final parameter.");
        McpManifest.Require(method.Parameters.All(parameter => parameter.RefKind == RefKind.None && !parameter.IsParams),
            "By-reference and params handler arguments are not supported.");
        var customizations = types.Where(type => type.Name == selection.Prefix + "Customization").ToArray();
        McpManifest.Require(customizations.Length <= 1, $"Customization '{selection.Prefix}Customization' must be unique.");
        var customization = customizations.SingleOrDefault();
        McpManifest.Require(customization is null || customization.IsStatic, "Command customizations must be static classes.");
        _ = Constant(compilation, customization, "Description");
        _ = Policy(compilation, customization);
        if (Constant(compilation, customization, "DefaultErrorMessage") is { } format)
        {
            _ = string.Format(System.Globalization.CultureInfo.InvariantCulture,
                (string)customization!.GetMembers(format.Member).OfType<IFieldSymbol>().Single().ConstantValue!, 500, "detail");
        }
        var docs = method.GetDocumentationCommentXml();
        var documentation = string.IsNullOrWhiteSpace(docs) ? null : XElement.Parse(docs);
        var options = method.Parameters[..^1].Select(parameter =>
        {
            var nullable = parameter.NullableAnnotation == NullableAnnotation.Annotated ||
                parameter.Type is INamedTypeSymbol { OriginalDefinition.SpecialType: SpecialType.System_Nullable_T };
            var parameterType = parameter.Type is INamedTypeSymbol { OriginalDefinition.SpecialType: SpecialType.System_Nullable_T } value
                ? value.TypeArguments[0] : parameter.Type;
            var type = parameterType.SpecialType switch
            {
                SpecialType.System_String => "string",
                SpecialType.System_Boolean => "bool",
                SpecialType.System_Int32 => "int",
                SpecialType.System_Int64 => "long",
                SpecialType.System_Single => "float",
                SpecialType.System_Double => "double",
                SpecialType.System_Decimal => "decimal",
                _ => throw new InvalidOperationException($"Unsupported command handler parameter '{parameter.Name}': only primitive options are supported.")
            };
            McpManifest.Require(McpManifest.IsIdentifier(parameter.Name) &&
                (!parameter.HasExplicitDefaultValue || parameter.ExplicitDefaultValue is null) &&
                (!parameter.IsOptional || nullable),
                $"Unsupported default for handler parameter '{parameter.Name}'; only nullable optional arguments are supported.");
            var name = char.ToUpperInvariant(parameter.Name[0]) + parameter.Name[1..];
            var description = Constant(compilation, customization, name + "Description");
            var text = documentation?.Elements("param").SingleOrDefault(element => element.Attribute("name")?.Value == parameter.Name)?.Value.Trim() ??
                operation?.Parameters.SingleOrDefault(input => input.Name == parameter.Name)?.Doc;
            McpManifest.Require(description is not null || !string.IsNullOrWhiteSpace(text),
                $"Handler option '{parameter.Name}' needs XML documentation or a '{name}Description' customization constant.");
            return new OptionMapping(name, type, !nullable, text, description);
        }).ToArray();
        McpManifest.Require(options.Select(option => option.Name).Distinct(StringComparer.OrdinalIgnoreCase).Count() == options.Length,
            "Handler parameter names collide after C# option-name normalization.");
        return (method, result, options, customization);
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

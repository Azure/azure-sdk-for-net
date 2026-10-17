// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;

namespace Microsoft.TypeSpec.Generator.Mcp;

public sealed record CommandSelection(
    string OperationId, string Id, string Path, string Title, string CommandType,
    StaticMember Handler, string ResultName, SafetyOverrides Safety,
    StaticMember? Description = null, StaticMember? ErrorPolicy = null,
    string? ErrorMessage = null, CommandOption[]? Options = null)
{
    [JsonIgnore]
    public string Prefix => CommandType[(CommandType.LastIndexOf('.') + 1)..^"Command".Length];

    internal void Validate()
    {
        McpManifest.Require(!string.IsNullOrWhiteSpace(OperationId) && Guid.TryParse(Id, out _),
            "Commands require an operation identity and valid tool GUID.");
        McpManifest.Require(!string.IsNullOrWhiteSpace(Path) && Path.Split(' ').All(McpManifest.IsCommandSegment),
            "A command path must contain valid space-separated segments.");
        McpManifest.Require(!string.IsNullOrWhiteSpace(Title) && McpManifest.IsTypeName(CommandType) &&
            CommandType.EndsWith("Command", StringComparison.Ordinal) && McpManifest.IsIdentifier(Prefix),
            "A command needs a title and qualified type ending in Command.");
        McpManifest.Require(Handler is not null && McpManifest.IsIdentifier(ResultName) && Safety is not null,
            "A typed handler, result property name, and reviewed safety are required.");
        McpManifest.ValidateMember(Handler);
        McpManifest.ValidateMember(Description);
        McpManifest.ValidateMember(ErrorPolicy);
        McpManifest.Require(Options is null || (Options.All(option => option is not null &&
            McpManifest.IsIdentifier(option.Name) && (option.Description is null) != (option.DescriptionMember is null)) &&
            Options.Select(option => option.Name).Distinct(StringComparer.Ordinal).Count() == Options.Length),
            "Option description overrides must be unique and specify exactly one description.");
        foreach (var option in Options ?? [])
        {
            McpManifest.ValidateMember(option.DescriptionMember);
        }
        if (ErrorMessage is not null)
        {
            _ = string.Format(System.Globalization.CultureInfo.InvariantCulture, ErrorMessage, 500, "detail");
        }
    }
}

public sealed record CommandOption(string Name, string? Description = null, StaticMember? DescriptionMember = null);

internal sealed record CommandModel(
    CommandSelection Selection, InputServiceMethod Operation, CSharpType HandlerType,
    CSharpType ReturnType, OptionMapping[] Options)
{
    internal static CommandModel Create(CommandSelection selection, InputServiceMethod operation)
    {
        McpManifest.Require(operation is not (InputLongRunningServiceMethod or InputLongRunningPagingServiceMethod or InputPagingServiceMethod),
            $"Paging and LRO command mappings are not supported for '{selection.OperationId}'.");
        var compilation = CodeModelGenerator.Instance.SourceInputModel.Customization
            ?? throw new InvalidOperationException("Complete commands require an existing consumer source compilation.");
        var signature = InferHandler(selection, compilation, operation);
        return new(selection, operation, McpProvider.ResolveType(selection.Handler.Type),
            McpProvider.ResolveType(signature.Result.ToDisplayString()), signature.Options);
    }

    internal static (IMethodSymbol Method, ITypeSymbol Result, OptionMapping[] Options) InferHandler(
        CommandSelection selection, Compilation compilation, InputServiceMethod? operation = null)
    {
        var handler = compilation.GetTypeByMetadataName(selection.Handler.Type);
        McpManifest.Require(handler is { TypeKind: TypeKind.Interface, IsGenericType: false },
            $"Handler '{selection.Handler.Type}' must resolve to an existing nongeneric interface.");
        var methods = handler.GetMembers(selection.Handler.Member).OfType<IMethodSymbol>().ToArray();
        McpManifest.Require(methods is [ { IsStatic: false, IsGenericMethod: false, DeclaredAccessibility: Accessibility.Public } ],
            $"Handler '{selection.Handler.Type}.{selection.Handler.Member}' must resolve to exactly one public instance method.");
        var method = methods[0];
        McpManifest.Require(method.ReturnType is INamedTypeSymbol { Name: "Task", Arity: 1 } task &&
            task.ContainingNamespace.ToDisplayString() == "System.Threading.Tasks",
            $"A command handler must return Task<T>; '{selection.Handler.Type}.{selection.Handler.Member}' resolves to '{method.ReturnType.ToDisplayString()}'.");
        var result = ((INamedTypeSymbol)method.ReturnType).TypeArguments[0];
        McpManifest.Require(result is INamedTypeSymbol { IsGenericType: false, TypeKind: TypeKind.Class or TypeKind.Struct } &&
            result.NullableAnnotation != NullableAnnotation.Annotated,
            "A command handler must return a nonnullable, nongeneric result model.");
        var cancellation = method.Parameters.Where(parameter => parameter.Type.ToDisplayString() == "System.Threading.CancellationToken").ToArray();
        McpManifest.Require(cancellation.Length == 1 && SymbolEqualityComparer.Default.Equals(cancellation[0], method.Parameters.LastOrDefault()),
            "A command handler must accept exactly one CancellationToken as its final parameter.");
        McpManifest.Require(method.Parameters.All(parameter => parameter.RefKind == RefKind.None && !parameter.IsParams),
            "By-reference and params handler arguments are not supported.");
        var parameters = method.Parameters[..^1];
        var overrides = selection.Options ?? [];
        McpManifest.Require(overrides.All(option => parameters.Any(parameter => parameter.Name == option.Name)),
            "Every option description override must name a handler parameter.");
        var docs = method.GetDocumentationCommentXml();
        var documentation = string.IsNullOrWhiteSpace(docs) ? null : XElement.Parse(docs);
        var options = parameters.Select(parameter =>
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
            var description = overrides.SingleOrDefault(option => option.Name == parameter.Name);
            var text = description?.Description ??
                documentation?.Elements("param").SingleOrDefault(element => element.Attribute("name")?.Value == parameter.Name)?.Value.Trim() ??
                operation?.Parameters.SingleOrDefault(input => input.Name == parameter.Name)?.Doc;
            McpManifest.Require(description?.DescriptionMember is not null || !string.IsNullOrWhiteSpace(text),
                $"Handler option '{parameter.Name}' needs documentation or a description override.");
            return new OptionMapping(char.ToUpperInvariant(parameter.Name[0]) + parameter.Name[1..], type,
                !nullable, Description: text, DescriptionMember: description?.DescriptionMember);
        }).ToArray();
        McpManifest.Require(options.Select(option => option.Name).Distinct(StringComparer.OrdinalIgnoreCase).Count() == options.Length,
            "Handler parameter names collide after C# option-name normalization.");
        ValidateStatic(compilation, selection.Description, isMethod: false);
        ValidateStatic(compilation, selection.ErrorPolicy, isMethod: true);
        foreach (var option in overrides)
        {
            ValidateStatic(compilation, option.DescriptionMember, isMethod: false);
        }
        return (method, result, options);
    }

    private static void ValidateStatic(Compilation compilation, StaticMember? reference, bool isMethod)
    {
        if (reference is null)
        {
            return;
        }
        var members = compilation.GetTypeByMetadataName(reference.Type)?.GetMembers(reference.Member) ?? [];
        McpManifest.Require(members.Length == 1 && compilation.IsSymbolAccessibleWithin(members[0], compilation.Assembly) && (isMethod
            ? members is [IMethodSymbol { IsStatic: true, IsGenericMethod: false, Parameters: [{ RefKind: RefKind.None, Type: { } type }], ReturnType.SpecialType: SpecialType.System_String }] &&
                type.ToDisplayString() == "System.Exception"
            : members is [IFieldSymbol { IsConst: true, Type.SpecialType: SpecialType.System_String, ConstantValue: string }]),
            $"Cannot resolve {(isMethod ? "error-policy method" : "description constant")} '{reference.Type}.{reference.Member}'.");
    }
}

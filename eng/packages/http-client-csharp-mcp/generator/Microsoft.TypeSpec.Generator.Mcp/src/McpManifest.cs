// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Microsoft.TypeSpec.Generator.Mcp;

public sealed record McpManifest(
    string Namespace,
    string[] MetadataReferences,
    ToolSelection[] Operations,
    CompositeSelection[] Composites,
    CommandSelection[]? Commands = null)
{
    [JsonIgnore]
    public CommandSelection[] CommandSelections => Commands ?? [];

    public static McpManifest Load(string path)
    {
        var manifest = JsonSerializer.Deserialize<McpManifest>(File.ReadAllText(path), new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
            RespectRequiredConstructorParameters = true,
            RespectNullableAnnotations = true,
            AllowDuplicateProperties = false
        }) ?? throw new InvalidOperationException("The MCP manifest cannot be null.");
        manifest.Validate();
        return manifest;
    }

    public void Validate()
    {
        Require(Namespace is not null && Namespace.Split('.').All(IsIdentifier), "A valid output namespace is required.");
        Require(MetadataReferences is not null && MetadataReferences.All(p =>
            !string.IsNullOrWhiteSpace(p) && !Path.IsPathRooted(p) && !p.Replace('\\', '/').Split('/').Contains("..")),
            "Metadata references must be paths relative to the emitter output directory.");
        Require(Operations is not null && Operations.Length + CommandSelections.Length > 0, "Select at least one operation.");
        var paths = new HashSet<string>(StringComparer.Ordinal);
        var ids = new HashSet<Guid>();
        var operationIds = new HashSet<string>(StringComparer.Ordinal);
        var typeNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var tool in Operations)
        {
            Require(tool is not null, "An operation cannot be null.");
            Require(!string.IsNullOrWhiteSpace(tool.OperationId) && operationIds.Add(tool.OperationId),
                "Selected operation IDs must be nonempty and unique.");
            Require(Guid.TryParse(tool.Id, out var id) && ids.Add(id), "Tool GUIDs must be valid and unique.");
            Require(!string.IsNullOrWhiteSpace(tool.Title), "A tool title is required.");
            Require(tool.Group is { Length: > 0 } && tool.Group.Append(tool.Name).All(IsCommandSegment) &&
                paths.Add(string.Join(' ', tool.Group.Append(tool.Name))), "Command paths must be valid and unique.");
            Require(tool.Types is not null, "Generated type names are required.");
            foreach (var name in tool.Types.All)
            {
                Require(IsIdentifier(name) && typeNames.Add(name), "Generated type names must be valid and unique.");
            }
            Require(IsTypeName(tool.CommandType), "A command type is required.");
            ValidateMember(tool.DescriptionOverride);
            Require(tool.Safety is not null, "Reviewed safety overrides are required.");
            Require(!string.IsNullOrWhiteSpace(tool.ErrorMessage), "A default error message format is required.");
            try
            {
                _ = string.Format(System.Globalization.CultureInfo.InvariantCulture, tool.ErrorMessage, 500, "detail");
            }
            catch (FormatException error)
            {
                throw new InvalidOperationException("Invalid default error message format.", error);
            }
            Require(tool.Wire is not null && !string.IsNullOrWhiteSpace(tool.Wire.Path) &&
                !string.IsNullOrWhiteSpace(tool.Wire.Uri) && tool.Wire.Constants is not null,
                "An explicit HTTP operation mapping is required.");
            _ = ToolSafety.FromHttpMethod(tool.Wire.Method);
            Require(tool.Wire.Constants.All(c => c is not null && !string.IsNullOrWhiteSpace(c.Name)) &&
                tool.Wire.Constants.Select(c => c.Name).Distinct(StringComparer.Ordinal).Count() == tool.Wire.Constants.Length,
                "Wire constants must have unique names.");
            Require(tool.Options is not null, "An explicit options mapping is required.");
            var options = new HashSet<string>(StringComparer.Ordinal);
            var sources = new HashSet<string>(StringComparer.Ordinal);
            foreach (var option in tool.Options)
            {
                Require(option is not null && IsIdentifier(option.Name) && options.Add(option.Name),
                    "Option property names must be valid and unique.");
                Require(PrimitiveTypes.Contains(option.Type), $"Unsupported option type '{option.Type}'.");
                Require(option.Source is null || (!string.IsNullOrWhiteSpace(option.Source) && sources.Add(option.Source)),
                    "An operation parameter can only be mapped once.");
                Require(option.Description is not null || option.DescriptionMember is not null || option.Source is not null,
                    "Ambient options require an explicit description.");
                Require(option.Description is null || option.DescriptionMember is null, "Use only one option description override.");
                ValidateMember(option.DescriptionMember);
            }
            Require(tool.Result is { Length: > 0 } && tool.Result.All(p =>
                p is not null && IsIdentifier(p.Name) && IsTypeName(p.Type)) &&
                tool.Result.Select(p => p.Name).Distinct(StringComparer.Ordinal).Count() == tool.Result.Length,
                "Result properties must have unique names and explicit types.");
            ValidateBinding(tool.Binding);
        }
        foreach (var command in CommandSelections)
        {
            Require(command is not null, "A command cannot be null.");
            command.Validate();
            Require(operationIds.Add(command.OperationId),
                $"Command operation '{command.OperationId}' is selected more than once.");
            Require(ids.Add(Guid.Parse(command.Id)), $"Command tool GUID '{command.Id}' is selected more than once: " +
                string.Join(", ", CommandSelections.Select(selection => selection.OperationId)));
            Require(paths.Add(command.Path), $"Command path '{command.Path}' is selected more than once.");
            foreach (var name in new[] { command.Prefix + "Command", command.Prefix + "Options", command.Prefix + "Catalog", command.Prefix + "JsonContext" })
            {
                Require(typeNames.Add(name), "Generated type names must be unique.");
            }
        }
        Require(Composites is not null && Composites.All(c => c is not null &&
            !string.IsNullOrWhiteSpace(c.Path) && !string.IsNullOrWhiteSpace(c.Reason) && paths.Add(c.Path)),
            "Handwritten exclusions require unique paths, reasons, and no generated-path collision.");
    }

    public void ValidateOperationIds(IEnumerable<string> availableIds)
    {
        var ids = availableIds.ToArray();
        foreach (var operationId in Operations.Select(tool => tool.OperationId).Concat(CommandSelections.Select(tool => tool.OperationId)))
        {
            var count = ids.Count(id => id == operationId);
            Require(count == 1, $"Selected operation '{operationId}' resolved {count} times; exactly one match is required.");
        }
    }

    private static void ValidateBinding(SdkBinding binding)
    {
        Require(binding is not null && IsIdentifier(binding.Method) && binding.Description is not null &&
            IsTypeName(binding.ReturnType), "An explicit SDK binding method and return type are required.");
        Require(binding.Parameters is { Length: > 0 } && binding.Calls is { Length: > 0 },
            "An SDK binding needs parameters and calls.");
        var variables = new HashSet<string>(StringComparer.Ordinal);
        foreach (var parameter in binding.Parameters)
        {
            Require(parameter is not null && IsIdentifier(parameter.Name) && IsTypeName(parameter.Type) &&
                variables.Add(parameter.Name), "SDK binding parameters require unique names and explicit types.");
        }
        Require(binding.Parameters.Any(p => p.Type == "System.Threading.CancellationToken"),
            "SDK bindings must accept a cancellation token.");
        var cancellationNames = binding.Parameters.Where(p => p.Type == "System.Threading.CancellationToken")
            .Select(p => p.Name).ToHashSet(StringComparer.Ordinal);
        foreach (var call in binding.Calls)
        {
            Require(call is not null && variables.Contains(call.Target) && IsIdentifier(call.Method) &&
                call.Arguments is not null, "SDK calls require a known target, method, and arguments.");
            var names = new HashSet<string>(StringComparer.Ordinal);
            var named = false;
            foreach (var argument in call.Arguments)
            {
                Require(argument is not null, "An SDK argument cannot be null.");
                var kinds = (argument.Variable is null ? 0 : 1) + (argument.Member is null ? 0 : 1) +
                    (argument.Literal.ValueKind == JsonValueKind.Undefined ? 0 : 1);
                Require(kinds == 1, "An SDK argument must select exactly one variable, static member, or primitive literal.");
                Require(argument.Variable is null || variables.Contains(argument.Variable), "Unknown SDK argument variable.");
                ValidateMember(argument.Member);
                Require(argument.Literal.ValueKind is JsonValueKind.Undefined or
                    JsonValueKind.Null or JsonValueKind.String or JsonValueKind.True or JsonValueKind.False or JsonValueKind.Number,
                    "SDK literal arguments must be primitive JSON values.");
                Require(argument.Name is null ? !named : IsIdentifier(argument.Name) && names.Add(argument.Name),
                    "Named SDK arguments must be unique and follow positional arguments.");
                named |= argument.Name is not null;
            }
            Require(!call.Await || call.Arguments.Any(a => a.Variable is not null && cancellationNames.Contains(a.Variable)),
                "Every asynchronous SDK call must forward a cancellation token.");
            Require((call.ResultName is null) == (call.ResultType is null), "SDK call results need both a name and a type.");
            Require(call.ResultName is null || (IsIdentifier(call.ResultName) && IsTypeName(call.ResultType) &&
                variables.Add(call.ResultName)), "SDK local variables require unique names and explicit types.");
        }
        Require(binding.Calls.Any(c => c.Await), "An async SDK binding must await at least one SDK call.");
        Require(variables.Contains(binding.ReturnVariable), "The SDK return variable must be declared.");
    }

    internal static readonly HashSet<string> PrimitiveTypes = new(StringComparer.Ordinal)
        { "string", "bool", "int", "long", "float", "double", "decimal" };

    internal static bool IsIdentifier(string? value) => !string.IsNullOrWhiteSpace(value) &&
        SyntaxFacts.IsValidIdentifier(value) && SyntaxFacts.GetKeywordKind(value) == SyntaxKind.None;

    internal static bool IsCommandSegment(string value) => !string.IsNullOrWhiteSpace(value) &&
        value.All(c => char.IsAsciiLetterOrDigit(c) || c == '-');

    internal static bool IsTypeName(string? value) => value is not null &&
        (PrimitiveTypes.Contains(value) || (value.Contains('.') && value.Split('.').All(IsIdentifier)));

    internal static void ValidateMember(StaticMember? member)
    {
        Require(member is null || (IsTypeName(member.Type) && IsIdentifier(member.Member)),
            "Static members need a qualified type and valid member name.");
    }

    internal static void Require([DoesNotReturnIf(false)] bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

public sealed record ToolSelection(
    string OperationId, string Id, string[] Group, string Name, string Title,
    GeneratedTypes Types, string CommandType,
    string ErrorMessage, WireMapping Wire, OptionMapping[] Options,
    SdkBinding Binding, ResultProperty[] Result, SafetyOverrides Safety, StaticMember? DescriptionOverride = null);

public sealed record GeneratedTypes(string Catalog, string Options, string Binding, string Result, string JsonContext)
{
    [JsonIgnore]
    public string[] All => [Catalog, Options, Binding, Result, JsonContext];
}

public sealed record StaticMember(string Type, string Member);
public sealed record WireMapping(string Method, string Path, string Uri, WireConstant[] Constants);
public sealed record WireConstant(string Name, JsonElement Value);
public sealed record OptionMapping(string Name, string Type, bool Required, string? Source = null,
    string? Description = null, StaticMember? DescriptionMember = null);
public sealed record ResultProperty(string Name, string Type);
public sealed record SdkBinding(string Method, string Description, string ReturnType,
    BindingParameter[] Parameters, SdkCall[] Calls, string ReturnVariable);
public sealed record BindingParameter(string Name, string Type, string Description);
public sealed record SdkCall(string Target, string Method, BindingArgument[] Arguments, bool Await,
    string? ResultName = null, string? ResultType = null);
public sealed record BindingArgument(string? Variable = null, StaticMember? Member = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)] JsonElement Literal = default, string? Name = null);

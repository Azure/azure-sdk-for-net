// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis.CSharp;

namespace Microsoft.TypeSpec.Generator.Mcp;

public sealed record McpManifest(string Namespace, CommandSelection[] Commands)
{
    public static McpManifest Load(string path)
    {
        var manifest = JsonSerializer.Deserialize<McpManifest>(File.ReadAllText(path), new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
            RespectRequiredConstructorParameters = true,
            RespectNullableAnnotations = true,
            AllowDuplicateProperties = false
        }) ?? throw new InvalidOperationException("The MCP code model cannot be null.");
        manifest.Validate();
        return manifest;
    }

    public void Validate()
    {
        Require(Namespace is not null && Namespace.Split('.').All(IsIdentifier), "A valid service namespace is required.");
        Require(Commands is { Length: > 0 }, "Select at least one operation.");
        var paths = new HashSet<string>(StringComparer.Ordinal);
        var ids = new HashSet<Guid>();
        var operations = new HashSet<string>(StringComparer.Ordinal);
        var outputs = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var command in Commands)
        {
            Require(command is not null, "A command cannot be null.");
            command.Validate();
            Require(command.Namespace == Namespace || command.Namespace.StartsWith(Namespace + ".", StringComparison.Ordinal),
                "Every selected operation must belong to the service namespace.");
            Require(operations.Add(command.OperationId), "Selected operation identities must be unique.");
            Require(ids.Add(Guid.Parse(command.Id)), "Tool GUIDs must be unique.");
            Require(paths.Add(command.Path), "Command paths must be unique.");
            Require(outputs.Add(command.Prefix), "Derived output filenames must be unique, including case.");
        }
    }

    public void ValidateOperationIds(IEnumerable<string> availableIds)
    {
        var ids = availableIds.ToArray();
        foreach (var command in Commands)
        {
            var count = ids.Count(id => id == command.OperationId);
            Require(count == 1, $"Selected operation '{command.OperationId}' resolved {count} times; exactly one match is required.");
        }
    }

    internal static bool IsIdentifier(string? value) => !string.IsNullOrWhiteSpace(value) &&
        SyntaxFacts.IsValidIdentifier(value) && SyntaxFacts.GetKeywordKind(value) == SyntaxKind.None;

    internal static bool IsCommandSegment(string value) => !string.IsNullOrWhiteSpace(value) &&
        value.All(c => char.IsAsciiLetterOrDigit(c) || c == '-');

    internal static void Require([DoesNotReturnIf(false)] bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

public sealed record StaticMember(string Type, string Member);
public sealed record OptionMapping(string Name, string Type, bool Required,
    string? Description = null, StaticMember? DescriptionMember = null);

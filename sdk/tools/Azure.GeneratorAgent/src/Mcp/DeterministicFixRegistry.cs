// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;

namespace Azure.GeneratorAgent.Mcp;

/// <summary>
/// A single rule that maps an error code + message pattern to a deterministic fix.
/// </summary>
public sealed class FixRule
{
    /// <summary>
    /// The C# error code this rule matches (e.g., "CS0246", "CS1061"). Null matches any code.
    /// </summary>
    public string? ErrorCode { get; init; }

    /// <summary>
    /// Regex pattern to match against the error message.
    /// </summary>
    public Regex MessagePattern { get; init; } = null!;

    /// <summary>
    /// The MCP tool name to invoke for this fix.
    /// </summary>
    public string ToolName { get; init; } = string.Empty;

    /// <summary>
    /// Human-readable description of what this rule fixes.
    /// </summary>
    public string Description { get; init; } = string.Empty;

    /// <summary>
    /// Function that extracts tool arguments from the error and regex match.
    /// </summary>
    public Func<BuildError, Match, Dictionary<string, string>> ExtractArgs { get; init; } = (_, _) => new();
}

/// <summary>
/// Static registry of deterministic fix rules. Each rule maps an error code + message pattern
/// to a specific tool invocation. Call <see cref="Classify"/> to check if an error has a
/// deterministic fix.
/// </summary>
public static class DeterministicFixRegistry
{
    /// <summary>
    /// Known type-to-namespace mappings for adding using directives.
    /// </summary>
    public static IReadOnlyDictionary<string, string> TypeToNamespace { get; } = new Dictionary<string, string>(StringComparer.Ordinal)
    {
        // Azure.Core.Pipeline
        ["HttpPipeline"] = "Azure.Core.Pipeline",
        ["HttpPipelineBuilder"] = "Azure.Core.Pipeline",
        ["DiagnosticScope"] = "Azure.Core.Pipeline",
        ["DiagnosticScopeFactory"] = "Azure.Core.Pipeline",

        // Azure.Core
        ["HttpMessage"] = "Azure.Core",
        ["Request"] = "Azure.Core",
        ["RequestContent"] = "Azure.Core",
        ["ResponseClassifier"] = "Azure.Core",
        ["TokenCredential"] = "Azure.Core",
        ["ResourceIdentifier"] = "Azure.Core",
        ["AzureLocation"] = "Azure.Core",
        ["RequestContext"] = "Azure.Core",
        ["ModelSerializationExtensions"] = "Azure.Core",

        // Azure
        ["Response"] = "Azure",
        ["RequestFailedException"] = "Azure",
        ["AzureKeyCredential"] = "Azure",
        ["AsyncPageable"] = "Azure",
        ["Pageable"] = "Azure",
        ["ETag"] = "Azure",
        ["Operation"] = "Azure",
        ["NullableResponse"] = "Azure",
        ["WaitUntil"] = "Azure",

        // System.ClientModel
        ["ClientResult"] = "System.ClientModel",
        ["CollectionResult"] = "System.ClientModel",
        ["AsyncCollectionResult"] = "System.ClientModel",
        ["ContinuationToken"] = "System.ClientModel",
        ["PageResult"] = "System.ClientModel",
        ["PageableCollection"] = "System.ClientModel",
        ["BinaryContent"] = "System.ClientModel",
        ["ApiKeyCredential"] = "System.ClientModel",
        ["ClientResultException"] = "System.ClientModel",

        // System.ClientModel.Primitives
        ["PipelineResponse"] = "System.ClientModel.Primitives",
        ["ClientPipeline"] = "System.ClientModel.Primitives",
        ["PipelinePolicy"] = "System.ClientModel.Primitives",
        ["PipelineMessage"] = "System.ClientModel.Primitives",
        ["ModelReaderWriterOptions"] = "System.ClientModel.Primitives",
        ["ModelReaderWriter"] = "System.ClientModel.Primitives",
        ["IJsonModel"] = "System.ClientModel.Primitives",
        ["IPersistableModel"] = "System.ClientModel.Primitives",

        // Azure.ResourceManager
        ["ArmOperation"] = "Azure.ResourceManager",
        ["ArmResource"] = "Azure.ResourceManager",
        ["ArmClient"] = "Azure.ResourceManager",

        // Microsoft.TypeSpec.Generator.Customizations (CodeGen attributes)
        ["CodeGenType"] = "Microsoft.TypeSpec.Generator.Customizations",
        ["CodeGenMember"] = "Microsoft.TypeSpec.Generator.Customizations",
        ["CodeGenSuppress"] = "Microsoft.TypeSpec.Generator.Customizations",
        ["CodeGenSerialization"] = "Microsoft.TypeSpec.Generator.Customizations",
        ["CodeGenVisibility"] = "Microsoft.TypeSpec.Generator.Customizations",
        ["CodeGenClient"] = "Microsoft.TypeSpec.Generator.Customizations",
    };

    /// <summary>
    /// Known field renames from old private-field style to new public-property style.
    /// </summary>
    public static IReadOnlyDictionary<string, string> FieldRenames { get; } = new Dictionary<string, string>(StringComparer.Ordinal)
    {
        ["_pipeline"] = "Pipeline",
        ["_clientDiagnostics"] = "ClientDiagnostics",
        ["_restClient"] = "RestClient",
        ["_endpoint"] = "Endpoint",
        ["_credential"] = "Credential",
        ["_apiVersion"] = "ApiVersion",
        ["_subscriptionId"] = "SubscriptionId",
        ["_diagnostics"] = "Diagnostics",
        ["_serializedAdditionalRawData"] = "_additionalBinaryDataProperties",
    };

    /// <summary>
    /// All registered fix rules, evaluated in order. Must be declared after TypeToNamespace and FieldRenames.
    /// </summary>
    public static IReadOnlyList<FixRule> Rules { get; } = BuildRules();

    /// <summary>
    /// Classifies a build error as deterministic (with tool + args) or requiring LLM reasoning.
    /// </summary>
    public static ClassifiedError Classify(BuildError error)
    {
        ArgumentNullException.ThrowIfNull(error);

        foreach (var rule in Rules)
        {
            if (rule.ErrorCode is not null && !string.Equals(rule.ErrorCode, error.Code, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var match = rule.MessagePattern.Match(error.Message);
            if (match.Success)
            {
                return new ClassifiedError
                {
                    Error = error,
                    IsDeterministic = true,
                    ToolName = rule.ToolName,
                    ToolArgs = rule.ExtractArgs(error, match),
                    Reason = rule.Description
                };
            }
        }

        return new ClassifiedError
        {
            Error = error,
            IsDeterministic = false,
            Reason = "No deterministic rule matched; requires LLM reasoning"
        };
    }

    private static List<FixRule> BuildRules()
    {
        var rules = new List<FixRule>();

        // --- Field rename rules (CS1061 / CS0103) ---
        foreach (var (oldName, newName) in FieldRenames)
        {
            var escapedOld = Regex.Escape(oldName);
            rules.Add(new FixRule
            {
                ErrorCode = null, // matches CS1061, CS0103, etc.
                MessagePattern = new Regex(
                    $@"'({escapedOld})'|does not contain a definition for '{escapedOld}'|The name '{escapedOld}' does not exist",
                    RegexOptions.Compiled),
                ToolName = "regex_replacement",
                Description = $"Rename field {oldName} → {newName}",
                ExtractArgs = (err, _) => new Dictionary<string, string>
                {
                    ["filePath"] = err.FilePath,
                    ["pattern"] = $@"\b{escapedOld}\b",
                    ["replacement"] = newName
                }
            });
        }

        // --- ResponseWithHeaders<T,H> → Response<T> ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS0246",
            MessagePattern = new Regex(
                @"type or namespace name 'ResponseWithHeaders<",
                RegexOptions.Compiled),
            ToolName = "regex_replacement",
            Description = "Replace ResponseWithHeaders<T,H> with Response<T>",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["pattern"] = @"ResponseWithHeaders<([^,>]+),\s*[^>]+>",
                ["replacement"] = "Response<$1>"
            }
        });

        // --- Rest.TypeName → TypeName (namespace prefix removal) ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS0246",
            MessagePattern = new Regex(
                @"type or namespace name 'Rest' .* does not exist in the namespace",
                RegexOptions.Compiled),
            ToolName = "regex_replacement",
            Description = "Remove Rest. namespace prefix",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["pattern"] = @"(?<!\w)Rest\.(\w+)",
                ["replacement"] = "$1"
            }
        });

        // --- Models.Models.X → Models.X (duplicate namespace) ---
        rules.Add(new FixRule
        {
            ErrorCode = null,
            MessagePattern = new Regex(
                @"'Models\.Models\.",
                RegexOptions.Compiled),
            ToolName = "regex_replacement",
            Description = "Fix duplicate Models.Models namespace",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["pattern"] = @"Models\.Models\.",
                ["replacement"] = "Models."
            }
        });

        // --- CodeGenModel → CodeGenType attribute rename (must be before generic CS0246) ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS0246",
            MessagePattern = new Regex(
                @"type or namespace name 'CodeGenModel(?:Attribute)?'",
                RegexOptions.Compiled),
            ToolName = "regex_replacement",
            Description = "Rename CodeGenModel attribute to CodeGenType",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["pattern"] = @"\bCodeGenModel\b",
                ["replacement"] = "CodeGenType"
            }
        });

        // --- MultipartFormDataRequestContent → MultiPartFormDataRequestContent (capitalization fix) ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS0246",
            MessagePattern = new Regex(
                @"type or namespace name 'MultipartFormDataRequestContent'",
                RegexOptions.Compiled),
            ToolName = "regex_replacement",
            Description = "Fix MultipartFormDataRequestContent capitalization → MultiPartFormDataRequestContent",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["pattern"] = @"\bMultipartFormDataRequestContent\b",
                ["replacement"] = "MultiPartFormDataRequestContent"
            }
        });

        // --- CanceledValue → CancelledValue (British spelling in generated enums) ---
        rules.Add(new FixRule
        {
            ErrorCode = null,
            MessagePattern = new Regex(
                @"'CanceledValue'|does not contain a definition for 'CanceledValue'",
                RegexOptions.Compiled),
            ToolName = "regex_replacement",
            Description = "Fix American spelling CanceledValue → CancelledValue",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["pattern"] = @"\bCanceledValue\b",
                ["replacement"] = "CancelledValue"
            }
        });

        // --- CancelingValue → CancellingValue (British spelling in generated enums) ---
        rules.Add(new FixRule
        {
            ErrorCode = null,
            MessagePattern = new Regex(
                @"'CancelingValue'|does not contain a definition for 'CancelingValue'",
                RegexOptions.Compiled),
            ToolName = "regex_replacement",
            Description = "Fix American spelling CancelingValue → CancellingValue",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["pattern"] = @"\bCancelingValue\b",
                ["replacement"] = "CancellingValue"
            }
        });

        // --- Mismatched ModelFactory type names (must be before generic CS0246 rule) ---
        rules.Add(new FixRule
        {
            ErrorCode = null,
            MessagePattern = new Regex(
                @"'(?<typeName>\w+ModelFactory)'",
                RegexOptions.Compiled),
            ToolName = "rename_codegen_type",
            Description = "Fix mismatched ModelFactory type name via [CodeGenType] attribute",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["projectPath"] = Path.GetDirectoryName(Path.GetDirectoryName(err.FilePath)) ?? err.FilePath,
                ["typeSuffix"] = "ModelFactory"
            }
        });

        // --- Mismatched ClientBuilderExtensions type names (must be before generic CS0246 rule) ---
        rules.Add(new FixRule
        {
            ErrorCode = null,
            MessagePattern = new Regex(
                @"'(?<typeName>\w+ClientBuilderExtensions)'",
                RegexOptions.Compiled),
            ToolName = "rename_codegen_type",
            Description = "Fix mismatched ClientBuilderExtensions type name via [CodeGenType] attribute",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["projectPath"] = Path.GetDirectoryName(Path.GetDirectoryName(err.FilePath)) ?? err.FilePath,
                ["typeSuffix"] = "ClientBuilderExtensions"
            }
        });

        // --- Obsolete Autorest using directives (CS0246: type 'Autorest' not found) ---
        // NOTE: Must come BEFORE the generic CS0246 add_using rule.
        rules.Add(new FixRule
        {
            ErrorCode = "CS0246",
            MessagePattern = new Regex(
                @"type or namespace name 'Autorest'",
                RegexOptions.Compiled),
            ToolName = "remove_using_directive",
            Description = "Remove obsolete Autorest using directive",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["namespacePattern"] = @"Autorest(?:\.\w+)*"
            }
        });

        // --- Missing using directives (CS0246: type or namespace name 'X' could not be found) ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS0246",
            MessagePattern = new Regex(
                @"type or namespace name '(?<typeName>\w+)(?:<[^>]*>)?' could not be found",
                RegexOptions.Compiled),
            ToolName = "add_using_directive",
            Description = "Add missing using directive for known type",
            ExtractArgs = (err, m) =>
            {
                var typeName = m.Groups["typeName"].Value;
                if (TypeToNamespace.TryGetValue(typeName, out var ns))
                {
                    return new Dictionary<string, string>
                    {
                        ["filePath"] = err.FilePath,
                        ["namespace"] = ns
                    };
                }
                return new Dictionary<string, string>();
            }
        });

        // --- FromCancellationToken replacement (CS0103: 'FromCancellationToken' does not exist) ---
        // NOTE: Must come before generic CS0103 rule to match CS0103 errors specifically.
        rules.Add(new FixRule
        {
            ErrorCode = null,
            MessagePattern = new Regex(
                @"'FromCancellationToken'|does not contain a definition for 'FromCancellationToken'",
                RegexOptions.Compiled),
            ToolName = "regex_replacement",
            Description = "Replace FromCancellationToken(ct) with ct.ToRequestContext()",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["pattern"] = @"FromCancellationToken\((\w+)\)",
                ["replacement"] = "$1.ToRequestContext()"
            }
        });

        // --- Fetch → FromLroResponse (CS0103/CS1061: 'Fetch' does not exist / not a definition) ---
        // NOTE: Must come before generic CS0103 rule to avoid false match on 'Fetch' as a type name.
        rules.Add(new FixRule
        {
            ErrorCode = null,
            MessagePattern = new Regex(
                @"does not contain a definition for 'Fetch'|The name 'Fetch' does not exist",
                RegexOptions.Compiled),
            ToolName = "fetch_to_fromlro",
            Description = "Replace Fetch(response) with ResponseModel.FromLroResponse(response) — run project-level tool",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["projectPath"] = Path.GetDirectoryName(Path.GetDirectoryName(err.FilePath)) ?? err.FilePath
            }
        });

        // --- Missing name (CS0103: The name 'X' does not exist in the current context) ---
        // NOTE: This generic rule MUST come AFTER all specific CS0103 patterns
        // (FromCancellationToken, Fetch) to avoid false matches.
        rules.Add(new FixRule
        {
            ErrorCode = "CS0103",
            MessagePattern = new Regex(
                @"The name '(?<typeName>\w+)' does not exist in the current context",
                RegexOptions.Compiled),
            ToolName = "add_using_directive",
            Description = "Add missing using directive for name not in context",
            ExtractArgs = (err, m) =>
            {
                var typeName = m.Groups["typeName"].Value;
                // Check field renames first
                if (FieldRenames.ContainsKey(typeName))
                {
                    return new Dictionary<string, string>
                    {
                        ["filePath"] = err.FilePath,
                        ["pattern"] = $@"\b{Regex.Escape(typeName)}\b",
                        ["replacement"] = FieldRenames[typeName]
                    };
                }
                if (TypeToNamespace.TryGetValue(typeName, out var ns))
                {
                    return new Dictionary<string, string>
                    {
                        ["filePath"] = err.FilePath,
                        ["namespace"] = ns
                    };
                }
                return new Dictionary<string, string>();
            }
        });

        // --- Obsolete Rest using directives (CS0234: namespace 'Rest' does not exist) ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS0234",
            MessagePattern = new Regex(
                @"type or namespace name 'Rest' does not exist in the namespace '(?<ns>[^']+)'",
                RegexOptions.Compiled),
            ToolName = "remove_using_directive",
            Description = "Remove obsolete .Rest using directive",
            ExtractArgs = (err, m) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["namespacePattern"] = $@"{Regex.Escape(m.Groups["ns"].Value)}\.Rest"
            }
        });

        // --- Obsolete Autorest.CSharp.* using directives ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS0234",
            MessagePattern = new Regex(
                @"does not exist in the namespace '(?<ns>Autorest(?:\.CSharp[^']*)?)'",
                RegexOptions.Compiled),
            ToolName = "remove_using_directive",
            Description = "Remove obsolete Autorest.CSharp.* using directive",
            ExtractArgs = (err, m) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["namespacePattern"] = $@"Autorest(?:\.CSharp[^;]*)?"
            }
        });

        // --- Nullable annotation CS8625 (Cannot convert null literal to non-nullable reference type) ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS8625",
            MessagePattern = new Regex(
                @"Cannot convert null literal to non-nullable reference type",
                RegexOptions.Compiled),
            ToolName = "nullable_annotation_fix",
            Description = "Add ? nullable annotation to fix CS8625",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["line"] = err.Line.ToString()
            }
        });

        // --- CS8600 (Converting null literal or possible null value to non-nullable type) ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS8600",
            MessagePattern = new Regex(
                @"Converting null literal or possible null value to non-nullable type",
                RegexOptions.Compiled),
            ToolName = "nullable_annotation_fix",
            Description = "Add ? nullable annotation to fix CS8600",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["line"] = err.Line.ToString()
            }
        });

        // --- ToRequestContent() removal (CS1061: does not contain a definition for 'ToRequestContent') ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS1061",
            MessagePattern = new Regex(
                @"does not contain a definition for 'ToRequestContent'",
                RegexOptions.Compiled),
            ToolName = "regex_replacement",
            Description = "Remove .ToRequestContent() call — input models now have implicit cast to RequestContent",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["pattern"] = @"\.ToRequestContent\(\)",
                ["replacement"] = ""
            }
        });

        // --- FromResponse method removal (CS0117: 'Type' does not contain a definition for 'FromResponse') ---
        rules.Add(new FixRule
        {
            ErrorCode = null,
            MessagePattern = new Regex(
                @"does not contain a definition for 'FromResponse'",
                RegexOptions.Compiled),
            ToolName = "regex_replacement",
            Description = "Replace ModelType.FromResponse(response) with (ModelType)response",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["pattern"] = @"(\w+)\.FromResponse\((\w+)\)",
                ["replacement"] = "($1)$2"
            }
        });

        // --- AZC0020: CancellationToken not propagated to RequestContext ---
        rules.Add(new FixRule
        {
            ErrorCode = "AZC0020",
            MessagePattern = new Regex(
                @"Method '(?<method>\w+)' accepts a CancellationToken but does not propagate it to the RequestContext",
                RegexOptions.Compiled),
            ToolName = "regex_replacement",
            Description = "Propagate CancellationToken to RequestContext in method call",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["pattern"] = @"new RequestContext\(\)",
                ["replacement"] = "new RequestContext { CancellationToken = cancellationToken }"
            }
        });

        // --- CS0104: Ambiguous reference (prefer System.* over Azure.Core shared sources) ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS0104",
            MessagePattern = new Regex(
                @"'(?<type>\w+)' is an ambiguous reference between '(?<ns1>[^']+)' and '(?<ns2>[^']+)'",
                RegexOptions.Compiled),
            ToolName = "regex_replacement",
            Description = "Resolve ambiguous type reference by fully qualifying",
            ExtractArgs = (err, m) =>
            {
                var type = m.Groups["type"].Value;
                var ns1 = m.Groups["ns1"].Value;
                var ns2 = m.Groups["ns2"].Value;
                // Prefer System.* namespace over Azure.Core shared source types
                var preferredFqn = ns1.StartsWith("System", StringComparison.Ordinal) ? ns1 :
                                   ns2.StartsWith("System", StringComparison.Ordinal) ? ns2 : ns1;
                return new Dictionary<string, string>
                {
                    ["filePath"] = err.FilePath,
                    ["pattern"] = $@"(?<![.\w]){Regex.Escape(type)}(?!\w)",
                    ["replacement"] = preferredFqn
                };
            }
        });

        return rules;
    }
}

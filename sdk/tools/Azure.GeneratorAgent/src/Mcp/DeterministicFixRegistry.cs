// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;

namespace Azure.GeneratorAgent.Mcp;

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

        // Azure.ResourceManager.Models
        ["SubResource"] = "Azure.ResourceManager.Models",
        ["TrackedResource"] = "Azure.ResourceManager.Models",
        ["ManagedServiceIdentity"] = "Azure.ResourceManager.Models",
        ["UserAssignedIdentity"] = "Azure.ResourceManager.Models",
        ["SystemData"] = "Azure.ResourceManager.Models",

        // Azure.Core (additional common types)
        ["Argument"] = "Azure.Core",
        ["ConnectionString"] = "Azure.Core",
        ["ResourceType"] = "Azure.Core",
        ["ContentType"] = "Azure.Core",
        ["RequestConditions"] = "Azure.Core",
        ["MatchConditions"] = "Azure.Core",
        ["RetryOptions"] = "Azure.Core",
        ["HttpAuthorization"] = "Azure.Core",
        ["HttpRange"] = "Azure.Core",

        // Azure (additional common types)
        ["AzureSasCredential"] = "Azure",
        ["ResponseError"] = "Azure",

        // Azure.Core.GeoJson
        ["GeoPosition"] = "Azure.Core.GeoJson",
        ["GeoPoint"] = "Azure.Core.GeoJson",
        ["GeoPolygon"] = "Azure.Core.GeoJson",
        ["GeoLineString"] = "Azure.Core.GeoJson",
        ["GeoBoundingBox"] = "Azure.Core.GeoJson",
        ["GeoObject"] = "Azure.Core.GeoJson",
        ["GeoCollection"] = "Azure.Core.GeoJson",

        // Azure.Core.Serialization
        ["DynamicData"] = "Azure.Core.Serialization",
        ["JsonObjectSerializer"] = "Azure.Core.Serialization",
        ["ObjectSerializer"] = "Azure.Core.Serialization",

        // Azure.Core.Expressions.DataFactory
        ["DataFactoryElement"] = "Azure.Core.Expressions.DataFactory",
        ["DataFactoryExpression"] = "Azure.Core.Expressions.DataFactory",

        // Azure.ResourceManager (additional types)
        ["ArmEnvironment"] = "Azure.ResourceManager",
        ["GenericResource"] = "Azure.ResourceManager",
        ["ResourceProviderData"] = "Azure.ResourceManager",

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
        ["_tokenCredential"] = "TokenCredential",
        ["_keyCredential"] = "KeyCredential",
        ["_cachedPipeline"] = "Pipeline",
        ["_serializedAdditionalRawData"] = "_additionalBinaryDataProperties",
    };

    /// <summary>
    /// All registered fix rules, evaluated in order. Must be declared after TypeToNamespace and FieldRenames.
    /// </summary>
    public static IReadOnlyList<FixRule> Rules { get; } = BuildRules();

    /// <summary>
    /// Classifies a build error using both static rules and a dynamic index built from Generated/ code.
    /// The index allows automatic resolution of CS0246 errors for types discovered in the generated output,
    /// without needing hardcoded TypeToNamespace entries.
    /// </summary>
    public static ClassifiedError Classify(BuildError error, GeneratedCodeIndex? index)
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
                var args = rule.ExtractArgs(error, match);

                // If a static rule matched but produced empty args for add_using_directive,
                // try the dynamic index as a fallback before giving up.
                if (rule.ToolName == "add_using_directive" && args.Count == 0 && index is not null)
                {
                    var resolved = TryResolveFromIndex(error, match, index);
                    if (resolved is not null)
                    {
                        return resolved;
                    }

                    // Type not found in static TypeToNamespace OR Generated/ code — it was
                    // likely renamed or removed by the new generator. Classify as non-deterministic
                    // so the LLM can reason about whether this is a rename, removal, or restructuring.
                    var missingType = match.Groups["typeName"].Success ? match.Groups["typeName"].Value : "unknown";
                    return new ClassifiedError
                    {
                        Error = error,
                        IsDeterministic = false,
                        Reason = $"Type '{missingType}' not found in static mappings or Generated/ code — likely renamed or removed. Requires reasoning to resolve."
                    };
                }

                // If add_using_directive matched but no index was provided and args are empty,
                // the type isn't in static mappings either — classify as non-deterministic.
                if (rule.ToolName == "add_using_directive" && args.Count == 0 && index is null)
                {
                    var missingType = match.Groups["typeName"].Success ? match.Groups["typeName"].Value : "unknown";
                    return new ClassifiedError
                    {
                        Error = error,
                        IsDeterministic = false,
                        Reason = $"Type '{missingType}' not found in static mappings (no Generated/ index available). Requires reasoning to resolve."
                    };
                }

                return new ClassifiedError
                {
                    Error = error,
                    IsDeterministic = rule.IsDeterministic,
                    ToolName = rule.ToolName,
                    ToolArgs = args,
                    Reason = rule.Description
                };
            }
        }

        // Last resort: if no static rule matched at all, try the dynamic index
        // for CS0246 errors with unknown types.
        if (index is not null)
        {
            var resolved = TryResolveFromIndex(error, null, index);
            if (resolved is not null)
            {
                return resolved;
            }
        }

        return new ClassifiedError
        {
            Error = error,
            IsDeterministic = false,
            Reason = "No deterministic rule matched; requires LLM reasoning"
        };
    }

    /// <summary>
    /// Attempts to resolve a type from the generated code index for CS0246/CS0103 errors.
    /// </summary>
    private static ClassifiedError? TryResolveFromIndex(BuildError error, Match? match, GeneratedCodeIndex index)
    {
        string? typeName = null;

        if (match is not null && match.Groups["typeName"].Success)
        {
            typeName = match.Groups["typeName"].Value;
        }
        else if (string.Equals(error.Code, "CS0246", StringComparison.OrdinalIgnoreCase))
        {
            // Try to extract type name from the message
            var m = s_typeNameFromMessage.Match(error.Message);
            if (m.Success)
            {
                typeName = m.Groups["typeName"].Value;
            }
        }
        else if (string.Equals(error.Code, "CS0103", StringComparison.OrdinalIgnoreCase))
        {
            var m = s_nameFromCS0103.Match(error.Message);
            if (m.Success)
            {
                typeName = m.Groups["typeName"].Value;
            }
        }

        if (typeName is null)
        {
            return null;
        }

        var ns = index.ResolveNamespace(typeName);
        if (ns is null)
        {
            return null;
        }

        return new ClassifiedError
        {
            Error = error,
            IsDeterministic = true,
            ToolName = "add_using_directive",
            ToolArgs = new Dictionary<string, string>
            {
                ["filePath"] = error.FilePath,
                ["namespace"] = ns
            },
            Reason = $"Add using directive for '{typeName}' (resolved from Generated/ code to namespace '{ns}')"
        };
    }

    private static readonly Regex s_typeNameFromMessage = new(
        @"type or namespace name '(?<typeName>\w+)(?:<[^>]*>)?' could not be found",
        RegexOptions.Compiled);

    private static readonly Regex s_nameFromCS0103 = new(
        @"The name '(?<typeName>\w+)' does not exist",
        RegexOptions.Compiled);

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

        // --- Mismatched *ClientOptions type names (must be before generic CS0246 rule) ---
        rules.Add(new FixRule
        {
            ErrorCode = null,
            MessagePattern = new Regex(
                @"'(?<typeName>\w+ClientOptions)'",
                RegexOptions.Compiled),
            ToolName = "rename_codegen_type",
            Description = "Fix mismatched ClientOptions type name via [CodeGenType] attribute",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["projectPath"] = Path.GetDirectoryName(Path.GetDirectoryName(err.FilePath)) ?? err.FilePath,
                ["typeSuffix"] = "ClientOptions"
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

        // --- CS0111: Duplicate member definition (custom + generated clash) ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS0111",
            MessagePattern = new Regex(
                @"Type '(?<typeName>[^']+)' already defines a member called '(?<memberName>[^']+)' with the same parameter types",
                RegexOptions.Compiled),
            ToolName = "add_codegen_suppress",
            Description = "Suppress duplicate generated member via [CodeGenSuppress] attribute",
            ExtractArgs = (err, m) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["memberName"] = m.Groups["memberName"].Value
            }
        });

        // --- CS0234: Generic sub-namespace removal ---
        // When a sub-namespace (e.g., .Models.Channels, .Models.Batch) no longer exists after migration,
        // the using directive referencing it should be removed.
        // NOTE: Must come AFTER the specific Rest and Autorest CS0234 rules.
        rules.Add(new FixRule
        {
            ErrorCode = "CS0234",
            MessagePattern = new Regex(
                @"type or namespace name '(?<subns>\w+)' does not exist in the namespace '(?<parentns>[^']+)'",
                RegexOptions.Compiled),
            ToolName = "remove_using_directive",
            Description = "Remove using directive for namespace that no longer exists after migration",
            ExtractArgs = (err, m) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["namespacePattern"] = $@"{Regex.Escape(m.Groups["parentns"].Value)}\.{Regex.Escape(m.Groups["subns"].Value)}"
            }
        });

        // --- CS8618: Non-nullable field/property must have non-null value when exiting constructor ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS8618",
            MessagePattern = new Regex(
                @"Non-nullable (?:field|property|variable) '(?<name>\w+)' must contain a non-null value",
                RegexOptions.Compiled),
            ToolName = "nullable_annotation_fix",
            Description = "Fix CS8618 by adding ? nullable annotation to the field or property",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["line"] = err.Line.ToString()
            }
        });

        // --- CS0115: No suitable method found to override ---
        // Common when a generated base class removes or renames a virtual/abstract method.
        rules.Add(new FixRule
        {
            ErrorCode = "CS0115",
            MessagePattern = new Regex(
                @"'(?<typeName>[^']+)\.(?<methodName>\w+)\([^)]*\)': no suitable method found to override",
                RegexOptions.Compiled),
            ToolName = "regex_replacement",
            Description = "Remove 'override' keyword: no suitable base method to override",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["pattern"] = @"\boverride\s+",
                ["replacement"] = "",
                ["singleLine"] = err.Line.ToString()
            }
        });

        // --- CS0506: Cannot override because it is not marked virtual, abstract, or override ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS0506",
            MessagePattern = new Regex(
                @"'(?<member>[^']+)': cannot override .* member .* because it is not marked virtual, abstract, or override",
                RegexOptions.Compiled),
            ToolName = "regex_replacement",
            Description = "Remove 'override' keyword: base member is not virtual/abstract",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["filePath"] = err.FilePath,
                ["pattern"] = @"\boverride\s+",
                ["replacement"] = "",
                ["singleLine"] = err.Line.ToString()
            }
        });

        // --- CS0433: Type exists in both assemblies ---
        // Common when shared source includes conflict with framework types.
        rules.Add(new FixRule
        {
            ErrorCode = "CS0433",
            MessagePattern = new Regex(
                @"type '(?<type>[^']+)' exists in both '(?<asm1>[^']+)' and '(?<asm2>[^']+)'",
                RegexOptions.Compiled),
            ToolName = "regex_replacement",
            Description = "Resolve type conflict between assemblies by fully qualifying the type reference",
            ExtractArgs = (err, m) =>
            {
                var fullType = m.Groups["type"].Value;
                var shortName = fullType.Contains('.') ? fullType[(fullType.LastIndexOf('.') + 1)..] : fullType;
                return new Dictionary<string, string>
                {
                    ["filePath"] = err.FilePath,
                    ["pattern"] = $@"(?<![.\w]){Regex.Escape(shortName)}(?!\w)",
                    ["replacement"] = fullType
                };
            }
        });

        // --- CS0029: Cannot implicitly convert type 'A' to 'B' ---
        // Non-deterministic hint with extracted types for LLM reasoning.
        rules.Add(new FixRule
        {
            ErrorCode = "CS0029",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"Cannot implicitly convert type '(?<fromType>[^']+)' to '(?<toType>[^']+)'",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "Type conversion mismatch. The return type or variable type may have changed after migration. " +
                          "Add an explicit cast, update the variable type, or use a conversion helper.",
            ExtractArgs = (err, m) => new Dictionary<string, string>
            {
                ["fromType"] = m.Groups["fromType"].Value,
                ["toType"] = m.Groups["toType"].Value
            }
        });

        // --- CS0266: Cannot implicitly convert type (explicit conversion exists) ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS0266",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"Cannot implicitly convert type '(?<fromType>[^']+)' to '(?<toType>[^']+)'\. An explicit conversion exists",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "Explicit conversion required. Cast the value or update the type. " +
                          "This often happens when return types change from concrete to interface types after migration.",
            ExtractArgs = (err, m) => new Dictionary<string, string>
            {
                ["fromType"] = m.Groups["fromType"].Value,
                ["toType"] = m.Groups["toType"].Value
            }
        });

        // --- CS7036: No argument given that corresponds to the required parameter ---
        // Constructor or method signature changed.
        rules.Add(new FixRule
        {
            ErrorCode = "CS7036",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"There is no argument given that corresponds to the required parameter '(?<paramName>\w+)' of '(?<member>[^']+)'",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "Constructor or method signature changed — a new required parameter was added. " +
                          "Add the missing argument, or if this is a constructor in a custom partial class, " +
                          "update to match the generated constructor signature.",
            ExtractArgs = (err, m) => new Dictionary<string, string>
            {
                ["paramName"] = m.Groups["paramName"].Value,
                ["member"] = m.Groups["member"].Value
            }
        });

        // --- CS1501: No overload for method takes N arguments ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS1501",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"No overload for method '(?<methodName>\w+)' takes (?<argCount>\d+) arguments",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "Method signature changed — the number of parameters has changed after migration. " +
                          "Check the generated method signature and update the call site.",
            ExtractArgs = (err, m) => new Dictionary<string, string>
            {
                ["methodName"] = m.Groups["methodName"].Value,
                ["argCount"] = m.Groups["argCount"].Value
            }
        });

        // --- CS0535: Does not implement interface member ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS0535",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"'(?<typeName>[^']+)' does not implement interface member '(?<member>[^']+)'",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "Interface member not implemented. The generated interface may have changed. " +
                          "Implement the missing member in a custom partial class, or update the interface reference.",
            ExtractArgs = (err, m) => new Dictionary<string, string>
            {
                ["typeName"] = m.Groups["typeName"].Value,
                ["member"] = m.Groups["member"].Value
            }
        });

        // --- CS0534: Does not implement inherited abstract member ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS0534",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"'(?<typeName>[^']+)' does not implement inherited abstract member '(?<member>[^']+)'",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "Abstract member not implemented. The generated base class added a new abstract member. " +
                          "Implement it in a custom partial class.",
            ExtractArgs = (err, m) => new Dictionary<string, string>
            {
                ["typeName"] = m.Groups["typeName"].Value,
                ["member"] = m.Groups["member"].Value
            }
        });

        // --- CS0012: Type defined in assembly that is not referenced ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS0012",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"type '(?<typeName>[^']+)' is defined in an assembly that is not referenced\. You must add a reference to assembly '(?<assembly>[^']+)'",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "Missing assembly reference. Add the assembly reference to the .csproj file, " +
                          "or if this is a shared source type (e.g., AzureKeyCredentialPolicy), " +
                          "add a <Compile Include> for the shared source file.",
            ExtractArgs = (err, m) => new Dictionary<string, string>
            {
                ["typeName"] = m.Groups["typeName"].Value,
                ["assembly"] = m.Groups["assembly"].Value
            }
        });

        // --- NU1100: Unable to resolve package ---
        rules.Add(new FixRule
        {
            ErrorCode = "NU1100",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"Unable to resolve '(?<package>[^']+)'",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "Missing NuGet package. Add the package reference to the .csproj and ensure " +
                          "a version entry exists in eng/Packages.Data.props.",
            ExtractArgs = (err, m) => new Dictionary<string, string>
            {
                ["package"] = m.Groups["package"].Value
            }
        });

        // --- CS0117: 'Type' does not contain a definition for 'Member' (static member access) ---
        // Catch-all for static member references that don't match more specific rules.
        rules.Add(new FixRule
        {
            ErrorCode = "CS0117",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"'(?<typeName>[^']+)' does not contain a definition for '(?<memberName>[^']+)'",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "Static member not found. The member may have been renamed or removed in the generated code. " +
                          "Check the generated type for the new member name.",
            ExtractArgs = (err, m) => new Dictionary<string, string>
            {
                ["typeName"] = m.Groups["typeName"].Value,
                ["memberName"] = m.Groups["memberName"].Value
            }
        });

        // --- CS0308: Non-generic type used with type arguments ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS0308",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"non-generic (?:type|method) '(?<name>[^']+)' cannot be used with type arguments",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "Type or method lost its generic parameters after migration. " +
                          "Remove the type arguments from the reference.",
            ExtractArgs = (err, m) => new Dictionary<string, string>
            {
                ["name"] = m.Groups["name"].Value
            }
        });

        // --- CS0305: Using generic type requires N type arguments ---
        rules.Add(new FixRule
        {
            ErrorCode = "CS0305",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"Using the generic type '(?<name>[^']+)' requires '?(?<count>\d+)'? type arguments",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "Generic type requires type arguments that are missing. " +
                          "Add the required type arguments to the reference.",
            ExtractArgs = (err, m) => new Dictionary<string, string>
            {
                ["name"] = m.Groups["name"].Value,
                ["count"] = m.Groups["count"].Value
            }
        });

        // =====================================================================
        // ApiCompat rules
        // These errors come from Microsoft.DotNet.ApiCompat.targets and appear
        // as codeless MSBuild errors (e.g., "error : CannotSealType : ...").
        // The BuildOutputParser extracts the rule name as the error code.
        // =====================================================================

        // --- MembersMustExist: IReadOnlyDictionary → IDictionary parameter type change ---
        // The new generator uses IDictionary for convenience method params where the old used
        // IReadOnlyDictionary. Fix by creating forwarding overloads in Custom/BackwardCompat/ClientMethodShims.cs
        // with IReadOnlyDictionary params that delegate to the new IDictionary methods.
        rules.Add(new FixRule
        {
            ErrorCode = "MembersMustExist",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"Member '.*IReadOnlyDictionary.*' does not exist in the implementation",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "ApiCompat: convenience method changed IReadOnlyDictionary<string,string> to IDictionary<string,string>. " +
                          "Create forwarding overloads in Custom/BackwardCompat/ClientMethodShims.cs with the old IReadOnlyDictionary " +
                          "parameter type that convert and delegate to the new IDictionary method. " +
                          "Add #pragma warning disable AZC0002 if overloads lack CancellationToken. " +
                          "For async forwarding methods, use ConfigureAwait(false) on the awaited call.",
            ExtractArgs = (err, m) => new Dictionary<string, string>()
        });

        // --- MembersMustExist: ModelFactory overload lost enum parameter ---
        // The new generator may remove enum-typed parameters from ModelFactory methods when the
        // enum type no longer exists (e.g., MessageDeltaChunkObject). Fix by creating forwarding
        // overloads in Custom/BackwardCompat/ModelFactoryBackwardCompat.cs that accept the old
        // enum parameter and delegate to the new method, discarding the removed parameter.
        rules.Add(new FixRule
        {
            ErrorCode = "MembersMustExist",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"Member '(?<fullType>[^']+ModelFactory)\.(?<method>[^(]+)\((?<params>[^)]*)\)' does not exist in the implementation",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "ApiCompat: ModelFactory method signature changed (usually a parameter was removed because its " +
                          "enum type no longer exists in the new generator). Create a forwarding overload in " +
                          "Custom/BackwardCompat/ModelFactoryBackwardCompat.cs with the old signature that accepts the " +
                          "removed parameter and delegates to the new method, discarding it. Mark with " +
                          "[EditorBrowsable(EditorBrowsableState.Never)]. If the removed parameter was an enum type " +
                          "that no longer exists, create a stub enum struct in Custom/BackwardCompat/MissingEnumTypes.cs.",
            ExtractArgs = (err, m) => new Dictionary<string, string>
            {
                ["factoryType"] = m.Groups["fullType"].Value,
                ["methodName"] = m.Groups["method"].Value,
                ["oldParams"] = m.Groups["params"].Value
            }
        });

        // --- MembersMustExist: SerializedAdditionalRawData field renamed ---
        // The new generator renames the protected field `SerializedAdditionalRawData` to
        // `_additionalBinaryDataProperties`. Fix by re-declaring the old field name in
        // Custom/BackwardCompat/SerializedAdditionalRawDataShims.cs.
        rules.Add(new FixRule
        {
            ErrorCode = "MembersMustExist",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"Member '(?<fullType>[^']+)\.SerializedAdditionalRawData' does not exist in the implementation",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "ApiCompat: protected field 'SerializedAdditionalRawData' was renamed to " +
                          "'_additionalBinaryDataProperties' by the new generator. Create a backward-compat shim in " +
                          "Custom/BackwardCompat/SerializedAdditionalRawDataShims.cs that re-declares the old field: " +
                          "#pragma warning disable SA1307 SA1401, then " +
                          "protected internal IDictionary<string, BinaryData> SerializedAdditionalRawData; " +
                          "#pragma warning restore. Mark the class as partial and use the correct namespace.",
            ExtractArgs = (err, m) =>
            {
                var fullType = m.Groups["fullType"].Value;
                var typeName = fullType.Contains('.') ? fullType[(fullType.LastIndexOf('.') + 1)..] : fullType;
                return new Dictionary<string, string>
                {
                    ["typeName"] = typeName,
                    ["fullTypeName"] = fullType
                };
            }
        });

        // --- CannotSealType + MembersMustExist: protected constructor removed ---
        // The new generator uses private protected ctors where the old used protected.
        // Fix: create a protected constructor shim in Custom/BackwardCompat/AbstractTypeConstructors.cs
        rules.Add(new FixRule
        {
            ErrorCode = "MembersMustExist",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"Member '(?<fullType>[^']+)\.\.ctor\((?<params>[^)]*)\)' does not exist in the implementation",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "ApiCompat: protected constructor missing. Create a protected constructor shim " +
                          "in Custom/BackwardCompat/AbstractTypeConstructors.cs. Never edit Generated/ files.",
            ExtractArgs = (err, m) => new Dictionary<string, string>()
        });

        rules.Add(new FixRule
        {
            ErrorCode = "CannotSealType",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"Type '(?<fullType>[^']+)' is effectively sealed",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "ApiCompat: type is effectively sealed (private constructor). Create a protected " +
                          "constructor shim in Custom/BackwardCompat/AbstractTypeConstructors.cs.",
            ExtractArgs = (err, m) => new Dictionary<string, string>()
        });

        // --- CannotMakeMemberNonVirtual: virtual → non-virtual on abstract type ---
        // Usually paired with CannotSealType. Same fix: add protected constructor shim.
        rules.Add(new FixRule
        {
            ErrorCode = "CannotMakeMemberNonVirtual",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"Member '(?<fullType>[^']+)\.(?<member>[^']+)' is virtual.*but non-virtual",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "ApiCompat: member lost 'virtual' modifier. Usually paired with CannotSealType. " +
                          "Fix by adding a protected constructor shim to keep the type inheritable.",
            ExtractArgs = (err, m) => new Dictionary<string, string>()
        });

        // --- CannotRemoveAttribute: attribute present in contract but not in implementation ---
        // Most commonly [Obsolete], [EditorBrowsable], or [CodeGenSerialization].
        // Fix: try adding the attribute back via customization. If that causes CS0618 in generated code,
        // add an ApiCompatBaseline.txt entry instead.
        rules.Add(new FixRule
        {
            ErrorCode = "CannotRemoveAttribute",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"Attribute '(?<attribute>[^']+)' exists on '(?<member>[^']+)' in the contract but not the implementation",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "ApiCompat: attribute was removed. Try re-adding via a custom partial class. " +
                          "If the attribute (e.g., [Obsolete]) causes CS0618 in generated code that references the type, " +
                          "add an ApiCompatBaseline.txt entry instead (see Azure.Identity/src/ApiCompatBaseline.txt for an example).",
            ExtractArgs = (err, m) => new Dictionary<string, string>
            {
                ["attribute"] = m.Groups["attribute"].Value,
                ["member"] = m.Groups["member"].Value,
                ["baselineEntry"] = err.Message
            }
        });

        // --- CannotChangeAttribute: attribute value differs between contract and implementation ---
        rules.Add(new FixRule
        {
            ErrorCode = "CannotChangeAttribute",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"Attribute '(?<attribute>[^']+)'.*has changed",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "ApiCompat: attribute value changed. Update the attribute via customization to match the contract, " +
                          "or add an ApiCompatBaseline.txt entry if the change is intentional.",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["baselineEntry"] = err.Message
            }
        });

        // --- TypesMustExist: type was removed entirely ---
        rules.Add(new FixRule
        {
            ErrorCode = "TypesMustExist",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @"Type '(?<fullType>[^']+)' does not exist in the implementation",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "ApiCompat: type was removed. This usually means a model or enum was renamed in the TypeSpec. " +
                          "Add a [CodeGenType(\"NewName\")] customization to preserve the old public type name, " +
                          "or add an ApiCompatBaseline.txt entry if the removal is intentional.",
            ExtractArgs = (err, m) =>
            {
                var fullType = m.Groups["fullType"].Value;
                var typeName = fullType.Contains('.') ? fullType[(fullType.LastIndexOf('.') + 1)..] : fullType;
                return new Dictionary<string, string>
                {
                    ["typeName"] = typeName,
                    ["fullTypeName"] = fullType
                };
            }
        });

        // --- Generic ApiCompat fallback for any unmatched ApiCompat error codes ---
        rules.Add(new FixRule
        {
            ErrorCode = "ApiCompat",
            IsDeterministic = false,
            MessagePattern = new Regex(
                @".+",
                RegexOptions.Compiled),
            ToolName = null,
            Description = "ApiCompat error. Review the error message and either fix via customization " +
                          "or add an ApiCompatBaseline.txt entry if the change is intentional.",
            ExtractArgs = (err, _) => new Dictionary<string, string>
            {
                ["baselineEntry"] = err.Message
            }
        });

        return rules;
    }
}

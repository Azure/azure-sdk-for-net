// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning;

public partial class Infrastructure : IJsonModel<Infrastructure>
{
    /// <summary>Parameterless constructor required by ModelReaderWriter source generator.</summary>
    public Infrastructure() : this("main") { }

    void IJsonModel<Infrastructure>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<Infrastructure>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(Infrastructure)} does not support writing '{format}' format.");
        }

        WriteJson(writer, options);
    }

    Infrastructure IJsonModel<Infrastructure>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<Infrastructure>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(Infrastructure)} does not support reading '{format}' format.");
        }

        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        var infras = DeserializeInfrastructure(document.RootElement);

        // Select the infra matching this instance's BicepName, or fall back to the first one
        string targetFile = BicepName + ".bicep";
        return infras.Find(i => i.BicepName + ".bicep" == targetFile) ?? infras[0];
    }

    BinaryData IPersistableModel<Infrastructure>.Write(ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<Infrastructure>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                return ModelReaderWriter.Write(this, options, AzureProvisioningContext.Default);
            case "bicep":
                {
                    ProvisioningPlan plan = Build();
                    IDictionary<string, string> compiled = plan.Compile();
                    // For a single module, return its bicep content directly
                    // For multiple modules, concatenate separated by blank lines
                    StringBuilder sb = new();
                    foreach (var kvp in compiled)
                    {
                        if (sb.Length > 0) sb.AppendLine();
                        sb.Append(kvp.Value);
                    }
                    return new BinaryData(sb.ToString());
                }
            default:
                throw new FormatException($"The model {nameof(Infrastructure)} does not support writing '{format}' format.");
        }
    }

    Infrastructure IPersistableModel<Infrastructure>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<Infrastructure>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(Infrastructure)} does not support reading '{format}' format.");
        }

        using JsonDocument document = JsonDocument.Parse(data);
        return DeserializeInfrastructure(document.RootElement)[0];
    }

    string IPersistableModel<Infrastructure>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    public override bool Equals(object? obj) => obj is Infrastructure other && Equals(other);

    public bool Equals(Infrastructure? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        // Use empty resolvers for comparison to avoid side effects
        var options = new ProvisioningBuildOptions();
        options.InfrastructureResolvers.Clear();
        var modules1 = CompileModules(options);

        var options2 = new ProvisioningBuildOptions();
        options2.InfrastructureResolvers.Clear();
        var modules2 = other.CompileModules(options2);

        if (modules1.Count != modules2.Count) return false;
        foreach (var kvp in modules1)
        {
            if (!modules2.TryGetValue(kvp.Key, out var otherStatements)) return false;
            var list1 = kvp.Value.ToList();
            var list2 = otherStatements.ToList();
            if (list1.Count != list2.Count) return false;
            for (int i = 0; i < list1.Count; i++)
            {
                if (!list1[i].Equals(list2[i])) return false;
            }
        }
        return true;
    }

    public override int GetHashCode() => BicepName.GetHashCode();

    internal void WriteJson(Utf8JsonWriter writer, ModelReaderWriterOptions? options = null)
    {
        ProvisioningBuildOptions buildOptions = new();
        IDictionary<string, IEnumerable<BicepStatement>> modules = CompileModules(buildOptions);

        writer.WriteStartObject();
        writer.WritePropertyName("infras");
        writer.WriteStartArray();

        foreach (KeyValuePair<string, IEnumerable<BicepStatement>> module in modules)
        {
            writer.WriteStartObject();
            writer.WriteString("fileName", $"{module.Key}.bicep");

            // Categorize statements
            string? targetScope = null;
            List<ResourceStatement> resources = new();
            List<ModuleStatement> moduleStatements = new();
            List<OutputStatement> outputs = new();
            List<ParameterStatement> parameters = new();
            List<VariableStatement> variables = new();

            foreach (BicepStatement statement in module.Value)
            {
                switch (statement)
                {
                    case TargetScopeStatement ts:
                        targetScope = ts.Scope.ToString().Trim('\'');
                        break;
                    case ResourceStatement rs:
                        resources.Add(rs);
                        break;
                    case ModuleStatement ms:
                        moduleStatements.Add(ms);
                        break;
                    case OutputStatement os:
                        outputs.Add(os);
                        break;
                    case ParameterStatement ps:
                        parameters.Add(ps);
                        break;
                    case VariableStatement vs:
                        variables.Add(vs);
                        break;
                    default:
                        throw new NotSupportedException(
                            $"Unsupported BicepStatement type '{statement.GetType().Name}' during JSON serialization.");
                }
            }

            if (targetScope != null && targetScope != "resourceGroup")
            {
                writer.WriteString("targetScope", targetScope);
            }

            // Write resources
            if (resources.Count > 0)
            {
                writer.WritePropertyName("resources");
                writer.WriteStartObject();
                foreach (ResourceStatement resource in resources)
                {
                    writer.WritePropertyName(resource.Name);
                    ((IJsonModel<BicepStatement>)resource).Write(writer, ModelReaderWriterOptions.Json);
                }
                writer.WriteEndObject();
            }

            // Write modules
            if (moduleStatements.Count > 0)
            {
                writer.WritePropertyName("modules");
                writer.WriteStartObject();
                foreach (ModuleStatement mod in moduleStatements)
                {
                    writer.WritePropertyName(mod.Name);
                    ((IJsonModel<BicepStatement>)mod).Write(writer, ModelReaderWriterOptions.Json);
                }
                writer.WriteEndObject();
            }

            // Write outputs
            if (outputs.Count > 0)
            {
                writer.WritePropertyName("outputs");
                writer.WriteStartObject();
                foreach (OutputStatement output in outputs)
                {
                    writer.WritePropertyName(output.Name);
                    ((IJsonModel<BicepStatement>)output).Write(writer, ModelReaderWriterOptions.Json);
                }
                writer.WriteEndObject();
            }

            // Write parameters
            if (parameters.Count > 0)
            {
                writer.WritePropertyName("parameters");
                writer.WriteStartObject();
                foreach (ParameterStatement param in parameters)
                {
                    writer.WritePropertyName(param.Name);
                    ((IJsonModel<BicepStatement>)param).Write(writer, ModelReaderWriterOptions.Json);
                }
                writer.WriteEndObject();
            }

            // Write variables
            if (variables.Count > 0)
            {
                writer.WritePropertyName("variables");
                writer.WriteStartObject();
                foreach (VariableStatement variable in variables)
                {
                    writer.WritePropertyName(variable.Name);
                    ((IJsonModel<BicepStatement>)variable).Write(writer, ModelReaderWriterOptions.Json);
                }
                writer.WriteEndObject();
            }

            writer.WriteEndObject();
        }

        writer.WriteEndArray();
        writer.WriteEndObject();
    }

    internal static List<Infrastructure> DeserializeInfrastructure(JsonElement element)
    {
        List<Infrastructure> modules = new();

        foreach (JsonElement bicepFile in element.GetProperty("infras").EnumerateArray())
        {
            string fileName = bicepFile.GetProperty("fileName").GetString()!;
            string moduleName = fileName.EndsWith(".bicep")
                ? fileName.Substring(0, fileName.Length - 6)
                : fileName;

            Infrastructure infra = new(moduleName);

            // Parse targetScope
            if (bicepFile.TryGetProperty("targetScope", out JsonElement scopeElement))
            {
                string scope = scopeElement.GetString()!;
                infra.TargetScope = scope switch
                {
                    "subscription" => DeploymentScope.Subscription,
                    "managementGroup" => DeploymentScope.ManagementGroup,
                    "tenant" => DeploymentScope.Tenant,
                    _ => null // resourceGroup is the default, no need to set
                };
            }

            // Parse parameters first (they may be referenced by resources/outputs)
            if (bicepFile.TryGetProperty("parameters", out JsonElement parametersElement))
            {
                foreach (JsonProperty paramProp in parametersElement.EnumerateObject())
                {
                    ParameterStatement stmt = ParameterStatement.DeserializeParameterStatement(paramProp.Value);
                    DeserializedParameter param = new(stmt);
                    infra.Add(param);
                }
            }

            // Parse resources
            if (bicepFile.TryGetProperty("resources", out JsonElement resourcesElement))
            {
                foreach (JsonProperty resProp in resourcesElement.EnumerateObject())
                {
                    ResourceStatement stmt = ResourceStatement.DeserializeResourceStatement(resProp.Value);
                    DeserializedResource resource = new(stmt);
                    infra.Add(resource);
                }
            }

            // Parse modules
            if (bicepFile.TryGetProperty("modules", out JsonElement modulesElement))
            {
                foreach (JsonProperty modProp in modulesElement.EnumerateObject())
                {
                    ModuleStatement stmt = ModuleStatement.DeserializeModuleStatement(modProp.Value);
                    DeserializedModule mod = new(stmt);
                    infra.Add(mod);
                }
            }

            // Parse outputs
            if (bicepFile.TryGetProperty("outputs", out JsonElement outputsElement))
            {
                foreach (JsonProperty outProp in outputsElement.EnumerateObject())
                {
                    OutputStatement stmt = OutputStatement.DeserializeOutputStatement(outProp.Value);
                    DeserializedOutput output = new(stmt);
                    infra.Add(output);
                }
            }

            // Parse variables
            if (bicepFile.TryGetProperty("variables", out JsonElement variablesElement))
            {
                foreach (JsonProperty varProp in variablesElement.EnumerateObject())
                {
                    VariableStatement stmt = VariableStatement.DeserializeVariableStatement(varProp.Value);
                    DeserializedVariable variable = new(stmt);
                    infra.Add(variable);
                }
            }

            modules.Add(infra);
        }

        return modules.Count > 0 ? modules : [new Infrastructure()];
    }

    /// <summary>
    /// Hydrates a typed resource's properties from a deserialized expression body.
    /// Recursively walks model sub-properties to avoid triggering ReadOnly cascading.
    /// Also transfers metadata (existing flag, decorators, condition) from the wrapper.
    /// </summary>
    internal static void HydrateResource(ProvisionableResource? resource, DeserializedResource wrapper)
    {
        if (resource == null) return;

        BicepExpression? body = wrapper.Body;
        if (body != null)
        {
            resource.EnsureInitialized();
            // first check if the body is if-condition, and if so, extract the inner body for property hydration and set the condition on BicepMetadata
            if (body is IfConditionExpression ifExpr)
            {
                var condition = ifExpr.Condition;
                resource.BicepMetadata.Condition = condition;
                body = ifExpr.Body;
            }
            // now the body should be the object expression with properties to hydrate
            if (body is ObjectExpression objExpr)
            {
                HydrateProperties(resource.ProvisionableProperties, objExpr);
            }
            else
            {
                throw new FormatException(
                    $"Expected resource body to be an ObjectExpression, but got {body.GetType().Name}.");
            }
        }

        // Fix #2: Transfer existing flag
        if (wrapper.IsExisting)
        {
            resource.SetExistingInternal();
        }

        // Fix #3: Transfer decorators → BicepMetadata
        foreach (var decorator in wrapper.Decorators)
        {
            if (decorator.Value is FunctionCallExpression funcCall &&
                funcCall.Function is IdentifierExpression id)
            {
                switch (id.Name)
                {
                    case "description" when funcCall.Arguments.Length == 1 && funcCall.Arguments[0] is StringLiteralExpression desc:
                        resource.BicepMetadata.Description = desc.Value;
                        break;
                    case "secure" when funcCall.Arguments.Length == 0:
                        // secure is typically on parameters, not resources — but transfer if present
                        break;
                    case "batchSize" when funcCall.Arguments.Length == 1 && funcCall.Arguments[0] is IntLiteralExpression batchSize:
                        resource.BicepMetadata.BatchSize = (uint)batchSize.Value;
                        break;
                    case "onlyIfNotExists" when funcCall.Arguments.Length == 0:
                        resource.BicepMetadata.OnlyIfNotExists = true;
                        break;
                }
            }
        }
    }

    /// <summary>
    /// Recursively hydrates properties from an ObjectExpression, walking into
    /// ProvisionableConstruct sub-properties instead of setting their Expression
    /// (which would trigger ReadOnly cascading).
    /// </summary>
    private static void HydrateProperties(IDictionary<string, IBicepValue> properties, ObjectExpression body)
    {
        foreach (KeyValuePair<string, IBicepValue> kvp in properties)
        {
            IBicepValue property = kvp.Value;
            if (property.IsOutput) continue;

            var path = property.Self?.BicepPath;
            if (path == null || path.Count == 0) continue;

            BicepExpression? value = FindExpressionAtPath(body, path);
            if (value == null) continue;

            // Fix #1: If the property is a ProvisionableConstruct (model type like StorageSku),
            // recurse into its sub-properties instead of setting Expression (which triggers ReadOnly).
            if (property is ProvisionableConstruct construct && value is ObjectExpression childObj)
            {
                construct.EnsureInitialized();
                HydrateProperties(construct.ProvisionableProperties, childObj);
            }
            else
            {
                property.Expression = value;
            }
        }
    }

    /// <summary>
    /// Navigates an ObjectExpression tree to find the expression at a given path.
    /// For path ["properties", "accessTier"], walks into the nested ObjectExpressions.
    /// </summary>
    private static BicepExpression? FindExpressionAtPath(BicepExpression body, IReadOnlyList<string> path)
    {
        BicepExpression? current = body;
        foreach (string segment in path)
        {
            if (current is ObjectExpression obj)
            {
                PropertyExpression? prop = obj.Properties.FirstOrDefault(p => p.Name == segment);
                current = prop?.Value;
            }
            else
            {
                return null;
            }
        }
        return current;
    }
}

/// <summary>
/// A lightweight resource wrapper used during deserialization.
/// Holds a pre-compiled ResourceStatement and replays it during compilation.
/// Can be upgraded to a typed resource via <see cref="ProvisionableCollection.OfType{T}"/>.
/// </summary>
internal class DeserializedResource : NamedProvisionableConstruct
{
    private readonly ResourceStatement _statement;

    internal DeserializedResource(ResourceStatement statement)
        : base(statement.Name)
    {
        _statement = statement;

        // Parse the ARM type and API version from the type string
        string typeString = statement.Type.ToString().Trim('\'');
        int atIndex = typeString.IndexOf('@');
        ArmType = atIndex >= 0 ? typeString.Substring(0, atIndex) : typeString;
        ApiVersion = atIndex >= 0 ? typeString.Substring(atIndex + 1) : "";
    }

    /// <summary>The ARM resource type (e.g. "Microsoft.Storage/storageAccounts").</summary>
    internal string ArmType { get; }

    /// <summary>The API version (e.g. "2024-01-01").</summary>
    internal string ApiVersion { get; }

    /// <summary>The deserialized expression body.</summary>
    internal BicepExpression? Body => _statement.Body;

    /// <summary>Whether this is an existing resource reference.</summary>
    internal bool IsExisting => _statement.Existing;

    /// <summary>The decorator expressions.</summary>
    internal IList<DecoratorExpression> Decorators => _statement.Decorators;

    protected internal override IEnumerable<BicepStatement> Compile()
    {
        yield return _statement;
    }
}

/// <summary>
/// A lightweight module wrapper used during deserialization.
/// Holds a pre-compiled ModuleStatement and replays it during compilation.
/// </summary>
internal class DeserializedModule : NamedProvisionableConstruct
{
    private readonly ModuleStatement _statement;

    internal DeserializedModule(ModuleStatement statement)
        : base(statement.Name)
    {
        _statement = statement;
    }

    protected internal override IEnumerable<BicepStatement> Compile()
    {
        yield return _statement;
    }
}

/// <summary>
/// A lightweight output wrapper used during deserialization.
/// Holds a pre-compiled OutputStatement and replays it during compilation.
/// </summary>
internal class DeserializedOutput : NamedProvisionableConstruct
{
    private readonly OutputStatement _statement;

    internal DeserializedOutput(OutputStatement statement)
        : base(statement.Name)
    {
        _statement = statement;
    }

    protected internal override IEnumerable<BicepStatement> Compile()
    {
        yield return _statement;
    }
}

/// <summary>
/// A lightweight parameter wrapper used during deserialization.
/// Holds a pre-compiled ParameterStatement and replays it during compilation.
/// </summary>
internal class DeserializedParameter : NamedProvisionableConstruct
{
    private readonly ParameterStatement _statement;

    internal DeserializedParameter(ParameterStatement statement)
        : base(statement.Name)
    {
        _statement = statement;
    }

    protected internal override IEnumerable<BicepStatement> Compile()
    {
        yield return _statement;
    }
}

/// <summary>
/// A lightweight variable wrapper used during deserialization.
/// Holds a pre-compiled VariableStatement and replays it during compilation.
/// </summary>
internal class DeserializedVariable : NamedProvisionableConstruct
{
    private readonly VariableStatement _statement;

    internal DeserializedVariable(VariableStatement statement)
        : base(statement.Name)
    {
        _statement = statement;
    }

    protected internal override IEnumerable<BicepStatement> Compile()
    {
        yield return _statement;
    }
}

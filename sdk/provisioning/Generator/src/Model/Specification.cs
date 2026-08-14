// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Azure.Provisioning.Generator.Model;

public abstract partial class Specification : ModelBase
{
    public Assembly ArmAssembly { get => ArmType!.Assembly; }

    // Flag indicating we don't need to clean the output directory
    // because it's merged with another spec that'll handle that for us
    public bool SkipCleaning { get; protected set; } = false;

    public bool ShouldGenerateSchema { get; set; } = true;

    public IList<Resource> Resources { get; private set; } = [];

    public IList<Role> Roles { get; private set; } = [];

    public XmlDocCommentReader DocComments { get; }

    public Dictionary<string, ModelBase> ModelNameMapping { get; } = [];
    public Dictionary<Type, ModelBase> ModelArmTypeMapping { get; } = [];

    internal bool IgnorePropertiesWithoutPath { get; }

    /// <summary>
    /// Additional assemblies whose types are allowed to be generated as models.
    /// Override in derived specifications when the ARM library depends on types
    /// from external assemblies (e.g., Azure.Core.Expressions.DataFactory).
    /// </summary>
    protected virtual IReadOnlyList<Assembly> AdditionalAllowedAssemblies { get; } = [];

    /// <summary>
    /// Resolves a generic type from an external assembly to its inner type.
    /// For example, <c>DataFactoryElement&lt;T&gt;</c> should be resolved to <c>T</c>.
    /// Return null if the type should not be unwrapped.
    /// </summary>
    protected internal virtual Type? ResolveExternalGenericType(Type armType) => null;

    /// <summary>
    /// The service directory under sdk/ where the generated library is placed.
    /// For example, "keyvault" places the library at sdk/keyvault/Azure.Provisioning.KeyVault/.
    /// </summary>
    internal string ServiceDirectory { get; }

    public Specification(string name, Type armEntryPoint, string serviceDirectory, bool ignorePropertiesWithoutPath = false)
        : base(
            name: name,
            ns: $"Azure.Provisioning.{name}",
            armType: armEntryPoint)
    {
        Spec = this;
        DocComments = new XmlDocCommentReader(armEntryPoint.Assembly);
        TypeRegistry.Register(this);
        IgnorePropertiesWithoutPath = ignorePropertiesWithoutPath;
        ServiceDirectory = serviceDirectory;
    }

    public override string ToString() => $"<Specification {Name}>";

    public void Build()
    {
        Analyze();
        Customize();
        RemovePropertiesWithoutPath();
        ResolveVersions();
        ResolveExperimentalFlags();
        Lint();
        ContextualException.WithContext(
            $"Generating all types for {Namespace}",
            () =>
            {
                // Delete any existing generated code
                string? path = GetGenerationPath();
                if (!SkipCleaning && path is not null && Directory.Exists(path)) { Directory.Delete(path, recursive: true); }

                // Regenerate each type
                HashSet<string> segments = new(Namespace!.Split('.'));
                foreach (ModelBase? type in ModelNameMapping.Values.Where(p => p is TypeModel || p is EnumModel))
                {
                    // Validate that we don't have type/namespace conflicts
                    if (segments.Contains(type.Name))
                    {
                        throw new InvalidOperationException($"Namespace {Namespace} conflicts with type {type.Name} / {type.ArmType!.FullName}");
                    }

                    type.Generate();
                }

                if (Roles.Count > 0)
                {
                    GenerateBuiltInRoles();
                }

                if (ShouldGenerateSchema)
                {
                    GenerateSchema();
                }
            });
    }

    /// <summary>
    /// Remove properties that were marked as needing a path during analysis
    /// but still have no path after customization.
    /// </summary>
    private void RemovePropertiesWithoutPath()
    {
        if (!IgnorePropertiesWithoutPath) { return; }
        foreach (TypeModel model in ModelNameMapping.Values.OfType<TypeModel>())
        {
            for (int i = model.Properties.Count - 1; i >= 0; i--)
            {
                if (model.Properties[i].Path is null)
                {
                    model.Properties.RemoveAt(i);
                }
            }
        }
    }

    /// <summary>
    /// Mark resources whose default API version is preview and models used exclusively
    /// by preview resources as experimental.
    /// </summary>
    private void ResolveExperimentalFlags()
    {
        // Mark resources whose default API version is a preview version as experimental
        foreach (Resource resource in Resources)
        {
            if (resource.DefaultResourceVersion is not null &&
                resource.DefaultResourceVersion.Contains("-preview", StringComparison.OrdinalIgnoreCase))
            {
                resource.IsExperimental = true;
            }
        }

        // Collect all models reachable from stable (non-experimental) resources
        HashSet<ModelBase> stableModels = [];
        foreach (Resource resource in Resources.Where(r => !r.IsExperimental))
        {
            CollectReachableModels(resource, stableModels);
        }

        // Collect all models reachable from experimental resources
        HashSet<ModelBase> experimentalModels = [];
        foreach (Resource resource in Resources.Where(r => r.IsExperimental))
        {
            CollectReachableModels(resource, experimentalModels);
        }

        // A model is experimental only if it is reachable from an experimental
        // resource and NOT reachable from any stable resource.
        foreach (ModelBase model in ModelNameMapping.Values)
        {
            if (model is Resource) { continue; } // Resources are already handled above
            if (experimentalModels.Contains(model) && !stableModels.Contains(model))
            {
                model.IsExperimental = true;
            }
        }
    }

    /// <summary>
    /// Recursively collect all model types reachable from a type's properties.
    /// </summary>
    private static void CollectReachableModels(ModelBase type, HashSet<ModelBase> visited)
    {
        if (!visited.Add(type)) { return; }

        if (type is TypeModel typeModel)
        {
            if (typeModel.BaseType is not null)
            {
                CollectReachableModels(typeModel.BaseType, visited);
            }
            foreach (Property property in typeModel.Properties)
            {
                if (property.PropertyType is not null)
                {
                    CollectReachableModels(property.PropertyType, visited);
                }
            }
        }
        else if (type is ListModel list)
        {
            if (list.ElementType is not null)
            {
                CollectReachableModels(list.ElementType, visited);
            }
        }
        else if (type is DictionaryModel dict)
        {
            if (dict.ElementType is not null)
            {
                CollectReachableModels(dict.ElementType, visited);
            }
        }
    }

    public override void Lint()
    {
        base.Lint();
        foreach (ModelBase model in ModelNameMapping.Values)
        {
            model.Lint();
        }
    }

    public override void Generate()
    {
        ContextualException.WithContext(
            $"Generating spec {Namespace}",
            () =>
            {
                // ...
            });
    }

    private void GenerateBuiltInRoles() =>
        ContextualException.WithContext(
            $"Generating built-in roles for {Name}",
            () =>
            {
                string name = $"{Name}BuiltInRole";
                IndentWriter writer = new();
                writer.WriteLine("// Copyright (c) Microsoft Corporation. All rights reserved.");
                writer.WriteLine("// Licensed under the MIT License.");
                writer.WriteLine();
                writer.WriteLine("// <auto-generated/>");
                writer.WriteLine();
                writer.WriteLine("#nullable enable");
                writer.WriteLine();
                writer.WriteLine("using System;");
                writer.WriteLine("using System.ComponentModel;");
                writer.WriteLine();
                writer.WriteLine($"namespace {Namespace};");
                writer.WriteLine();
                writer.WriteLine($"/// <summary>");
                writer.WriteWrapped($"Built-in {Name} roles that you can assign to users, groups, service principals, and managed identities.");
                writer.WriteLine($"/// </summary>");
                writer.WriteLine($"/// <param name=\"value\">The ID value of the role.</param>");
                writer.WriteLine($"public readonly struct {name}(string value) : IEquatable<{name}>");
                using (writer.Scope("{", "}"))
                {
                    writer.WriteLine($"private readonly string _value = value ?? throw new ArgumentNullException(nameof(value));");
                    foreach (Role role in Roles)
                    {
                        writer.WriteLine();
                        writer.WriteLine($"/// <summary>");
                        writer.WriteWrapped(role.Description);
                        writer.WriteLine($"/// </summary>");
                        writer.WriteLine($"public static {name} {role.Name} {{ get; }} = new({role.Name}Value);");
                        writer.WriteLine($"internal const string {role.Name}Value = \"{role.Value}\";");
                    }

                    writer.WriteLine();
                    writer.WriteLine($"/// <summary>");
                    writer.WriteWrapped($"Try to get the name of a built-in {Name} role from its ID value.");
                    writer.WriteLine($"/// </summary>");
                    writer.WriteLine($"/// <param name=\"value\">The role value.</param>");
                    writer.WriteLine($"/// <returns>");
                    writer.WriteLine($"/// The name of the built-in {Name} role if known, otherwise the ID will be returned.");
                    writer.WriteLine($"/// </returns>");
                    writer.WriteLine($"[EditorBrowsable(EditorBrowsableState.Never)]");
                    writer.WriteLine($"public static string GetBuiltInRoleName({name} value) =>");
                    using (writer.Scope())
                    {
                        writer.WriteLine($"value._value switch");
                        using (writer.Scope("{", "};"))
                        {
                            foreach (Role role in Roles)
                            {
                                writer.WriteLine($"{role.Name}Value => nameof({role.Name}),");
                            }
                            writer.WriteLine($"_ => value._value");
                        }
                    }

                    writer.WriteLine();
                    writer.WriteLine($"/// <summary>");
                    writer.WriteWrapped($"Determines if two {name} values are the same.");
                    writer.WriteLine($"/// </summary>");
                    writer.WriteLine($"/// <param name=\"left\">The first {name} to compare.</param>");
                    writer.WriteLine($"/// <param name=\"right\">The second {name} to compare.</param>");
                    writer.WriteLine($"/// <returns>True if <paramref name=\"left\"/> and <paramref name=\"right\"/> are the same; otherwise, false.</returns>");
                    writer.WriteLine($"public static bool operator ==({name} left, {name} right) => left.Equals(right);");

                    writer.WriteLine();
                    writer.WriteLine($"/// <summary>");
                    writer.WriteWrapped($"Determines if two {name} values are different.");
                    writer.WriteLine($"/// </summary>");
                    writer.WriteLine($"/// <param name=\"left\">The first {name} to compare.</param>");
                    writer.WriteLine($"/// <param name=\"right\">The second {name} to compare.</param>");
                    writer.WriteLine($"/// <returns>True if <paramref name=\"left\"/> and <paramref name=\"right\"/> are different; otherwise, false.</returns>");
                    writer.WriteLine($"public static bool operator !=({name} left, {name} right) => !left.Equals(right);");

                    writer.WriteLine();
                    writer.WriteLine($"/// <summary>");
                    writer.WriteLine($"/// Converts a string to a {name}.");
                    writer.WriteLine($"/// </summary>");
                    writer.WriteLine($"/// <param name=\"value\">The string value to convert.</param>");
                    writer.WriteLine($"public static implicit operator {name}(string value) => new(value);");

                    writer.WriteLine();
                    writer.WriteLine($"/// <inheritdoc/>");
                    writer.WriteLine($"[EditorBrowsable(EditorBrowsableState.Never)]");
                    writer.WriteLine($"public override bool Equals(object? obj) => obj is {name} other && Equals(other);");

                    writer.WriteLine();
                    writer.WriteLine($"/// <inheritdoc/>");
                    writer.WriteLine($"public bool Equals({name} other) => string.Equals(_value, other._value, StringComparison.Ordinal);");

                    writer.WriteLine();
                    writer.WriteLine($"/// <inheritdoc/>");
                    writer.WriteLine($"[EditorBrowsable(EditorBrowsableState.Never)]");
                    writer.WriteLine($"public override int GetHashCode() => _value?.GetHashCode() ?? 0;");

                    writer.WriteLine();
                    writer.WriteLine($"/// <inheritdoc/>");
                    writer.WriteLine($"public override string ToString() => _value;");

                }

                // Write out the model
                SaveFile($"{name}.cs", writer.ToString());
            });
}
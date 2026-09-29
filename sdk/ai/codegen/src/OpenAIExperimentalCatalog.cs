// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.TypeSpec.Generator;

namespace Extensions.Plugin;

/// <summary>
/// Builds and caches the set of fully-qualified type names for every type in the consumed OpenAI
/// assembly that is annotated with <see cref="System.Diagnostics.CodeAnalysis.ExperimentalAttribute"/>.
/// </summary>
/// <remarks>
/// Only membership matters: the visitor stamps its own <c>AAIP002</c> diagnostic id (meaning "experimental
/// because it exposes OpenAI-experimental surface") rather than propagating OpenAI's own id, so the specific
/// OpenAI id (<c>OPENAI001</c>, <c>OPENAICUA001</c>, …) is intentionally discarded here.
/// </remarks>
/// <remarks>
/// The set of experimental OpenAI types is derived at code-generation time directly from the
/// OpenAI assembly the SDK compiles against, so it is self-updating across OpenAI version bumps
/// and requires no hand-maintained list. The OpenAI assembly is not loaded into the generator
/// process; instead the catalog reads it as metadata through the Roslyn
/// <see cref="MetadataReference"/> set the generator already exposes via
/// <see cref="CodeModelGenerator.AdditionalMetadataReferences"/>.
/// </remarks>
internal sealed class OpenAIExperimentalCatalog
{
    private const string OpenAIAssemblyName = "OpenAI";
    private const string ExperimentalAttributeName = "ExperimentalAttribute";
    private const string ExperimentalAttributeNamespace = "System.Diagnostics.CodeAnalysis";

    private static readonly SymbolDisplayFormat s_fqnFormat = new(
        globalNamespaceStyle: SymbolDisplayGlobalNamespaceStyle.Omitted,
        typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
        genericsOptions: SymbolDisplayGenericsOptions.None);

    private readonly HashSet<string> _experimentalTypes;

    private OpenAIExperimentalCatalog(HashSet<string> experimentalTypes)
    {
        _experimentalTypes = experimentalTypes;
    }

    private static OpenAIExperimentalCatalog s_instance;

    /// <summary>Gets the lazily-built, process-wide catalog instance.</summary>
    public static OpenAIExperimentalCatalog Instance =>
        Volatile.Read(ref s_instance)
        ?? Interlocked.CompareExchange(ref s_instance, Build(), null)
        ?? s_instance;

    /// <summary>
    /// Returns <see langword="true"/> when the supplied fully-qualified type name corresponds to an
    /// experimental OpenAI type.
    /// </summary>
    public bool IsExperimental(string fullyQualifiedName)
    {
        if (string.IsNullOrEmpty(fullyQualifiedName))
        {
            return false;
        }
        return _experimentalTypes.Contains(Normalize(fullyQualifiedName));
    }

    /// <summary>Normalizes a fully-qualified name so catalog keys and query values compare equal.</summary>
    private static string Normalize(string fullyQualifiedName)
    {
        // Drop any constructed generic arguments (e.g. "IJsonModel<Foo>" -> "IJsonModel") and
        // metadata nested-type separators ('+') so the value matches the Roslyn display format
        // used to build the catalog keys.
        int angle = fullyQualifiedName.IndexOf('<');
        if (angle >= 0)
        {
            fullyQualifiedName = fullyQualifiedName.Substring(0, angle);
        }
        return fullyQualifiedName.Replace('+', '.').Trim();
    }

    private static OpenAIExperimentalCatalog Build()
    {
        // The generator exposes only the "additional" metadata references (OpenAI and a few of its
        // dependencies) — not the full framework closure. Roslyn needs the assembly that defines
        // ExperimentalAttribute (and System.String) available to decode the attribute's constructor
        // argument (the diagnostic id); otherwise the TypedConstant decodes as empty. Add the running
        // framework's assemblies so the closure is complete.
        var references = new List<MetadataReference>(CodeModelGenerator.Instance.AdditionalMetadataReferences);
        string frameworkDir = Path.GetDirectoryName(typeof(object).Assembly.Location);
        if (!string.IsNullOrEmpty(frameworkDir))
        {
            foreach (string dll in Directory.EnumerateFiles(frameworkDir, "*.dll"))
            {
                try
                {
                    references.Add(MetadataReference.CreateFromFile(dll));
                }
                catch
                {
                    // Skip files that are not valid managed assemblies.
                }
            }
        }

        CSharpCompilation compilation = CSharpCompilation.Create("OpenAIExperimentalCatalog", references: references);

        IAssemblySymbol openAiAssembly = compilation.SourceModule.ReferencedAssemblySymbols
            .FirstOrDefault(a => string.Equals(a.Name, OpenAIAssemblyName, StringComparison.OrdinalIgnoreCase));

        var experimentalTypes = new HashSet<string>(StringComparer.Ordinal);
        if (openAiAssembly is not null)
        {
            // When the consuming library does not reference OpenAI there is nothing to propagate, so the
            // catalog is simply empty and the visitor becomes a no-op rather than failing generation.
            CollectExperimentalTypes(openAiAssembly.GlobalNamespace, experimentalTypes);
        }
        return new OpenAIExperimentalCatalog(experimentalTypes);
    }

    private static void CollectExperimentalTypes(INamespaceSymbol ns, HashSet<string> experimentalTypes)
    {
        foreach (INamedTypeSymbol type in ns.GetTypeMembers())
        {
            CollectExperimentalTypes(type, experimentalTypes);
        }
        foreach (INamespaceSymbol child in ns.GetNamespaceMembers())
        {
            CollectExperimentalTypes(child, experimentalTypes);
        }
    }

    private static void CollectExperimentalTypes(INamedTypeSymbol type, HashSet<string> experimentalTypes)
    {
        if (IsExperimentalType(type))
        {
            experimentalTypes.Add(type.ToDisplayString(s_fqnFormat));
        }
        foreach (INamedTypeSymbol nested in type.GetTypeMembers())
        {
            CollectExperimentalTypes(nested, experimentalTypes);
        }
    }

    private static bool IsExperimentalType(ISymbol symbol)
    {
        foreach (AttributeData attribute in symbol.GetAttributes())
        {
            INamedTypeSymbol attributeClass = attribute.AttributeClass;
            if (attributeClass is null
                || !string.Equals(attributeClass.Name, ExperimentalAttributeName, StringComparison.Ordinal)
                || !string.Equals(attributeClass.ContainingNamespace?.ToDisplayString(), ExperimentalAttributeNamespace, StringComparison.Ordinal))
            {
                continue;
            }
            // A valid experimental marker carries a non-empty diagnostic id; the id value itself is not
            // retained because the visitor stamps its own AAIP002 id instead of OpenAI's.
            if (attribute.ConstructorArguments.Length >= 1
                && attribute.ConstructorArguments[0].Value is string id
                && !string.IsNullOrEmpty(id))
            {
                return true;
            }
        }
        return false;
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit
{
    internal static class CompilationHelper
    {
        private static readonly CSharpParseOptions s_defaultParseOptions = CreateParseOptions();

        private static readonly HashSet<string> s_noWarn = ["CS1701", "CS8019", "CS0311", "CS1702"];

        public record GeneratorResult
        {
            internal ModelReaderWriterContextGenerationSpec? GenerationSpec { get; set; }
            public ImmutableArray<Diagnostic> Diagnostics { get; set; }
        }

        public static CSharpParseOptions CreateParseOptions(
            LanguageVersion? version = null,
            DocumentationMode? documentationMode = null)
        {
            return new CSharpParseOptions(
                kind: SourceCodeKind.Regular,
                languageVersion: version ?? LanguageVersion.CSharp9, // C# 9 is the minimum supported lang version by the source generator.
                documentationMode: documentationMode ?? DocumentationMode.Parse);
        }

        public static Compilation CreateCompilation(
            string source,
            MetadataReference[]? additionalReferences = null,
            string assemblyName = "TestAssembly",
            bool includeSTJ = true,
            CSharpParseOptions? parseOptions = null,
            string contextName = "LocalContext",
            HashSet<string>? additionalSuppress = null)
            => CreateCompilation([source], additionalReferences, assemblyName, includeSTJ, parseOptions, contextName, additionalSuppress);

        public static Compilation CreateCompilation(
            IEnumerable<string> sources,
            MetadataReference[]? additionalReferences = null,
            string assemblyName = "TestAssembly",
            bool includeSTJ = true,
            CSharpParseOptions? parseOptions = null,
            string contextName = "LocalContext",
            HashSet<string>? additionalSuppress = null)
        {
            List<MetadataReference> references =
            [
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(ModelReaderWriter).Assembly.Location),
                MetadataReference.CreateFromFile(Path.Combine(typeof(object).Assembly.Location, "..", "System.Runtime.dll")),
                MetadataReference.CreateFromFile(typeof(JsonSerializer).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(BinaryData).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(ConcurrentDictionary<,>).Assembly.Location),
#if NETFRAMEWORK
                MetadataReference.CreateFromFile(Path.Combine(typeof(object).Assembly.Location, "..", "netstandard.dll")),
                MetadataReference.CreateFromFile(typeof(ReadOnlyMemory<>).Assembly.Location),
#endif
            ];

            parseOptions ??= new CSharpParseOptions(languageVersion: LanguageVersion.Latest);

            // Add additional references as needed.
            if (additionalReferences != null)
            {
                foreach (MetadataReference reference in additionalReferences)
                {
                    references.Add(reference);
                }
            }

            SyntaxTree[] syntaxTrees = sources.Select(source => CSharpSyntaxTree.ParseText(source, parseOptions)).ToArray();

            var compilation = CSharpCompilation.Create(
                assemblyName,
                syntaxTrees: syntaxTrees,
                references: references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
            );

            var compilationDiagnostics = compilation.GetDiagnostics()
                .Where(d => d.Severity == DiagnosticSeverity.Error);

            foreach (var diag in compilationDiagnostics)
            {
                // The TestAssemblyContext won't exist yet since the ContextGenerator hasn't run yet
                if (diag.ToString().EndsWith($"error CS0103: The name '{contextName}' does not exist in the current context", StringComparison.Ordinal) ||
                    diag.ToString().EndsWith($"error CS0117: '{contextName}' does not contain a definition for 'Default'", StringComparison.Ordinal))
                    continue;

                if (additionalSuppress is not null && additionalSuppress.Contains(diag.Id))
                    continue;

                Assert.Fail($"Compilation Error: {diag}");
            }

            return compilation;
        }

        public static GeneratorResult RunSourceGenerator(Compilation compilation, bool disableDiagnosticValidation = false)
            => RunSourceGenerator(compilation, out _, out _, disableDiagnosticValidation);

        public static GeneratorResult RunSourceGenerator(Compilation compilation, out Compilation newCompilation, bool disableDiagnosticValidation = false, HashSet<string>? additionalSuppress = null)
            => RunSourceGenerator(compilation, out newCompilation, out _, disableDiagnosticValidation, additionalSuppress);

        public static GeneratorResult RunSourceGenerator(Compilation compilation, out Compilation newCompilation, out ImmutableArray<GeneratedSourceResult> generatedSources, bool disableDiagnosticValidation = false, HashSet<string>? additionalSuppress = null)
        {
            ModelReaderWriterContextGenerationSpec? generatedSpecs = null;
            var generator = new ModelReaderWriterContextGenerator
            {
                OnSourceEmitting = specs => generatedSpecs = specs
            };

            CSharpGeneratorDriver driver = CreateJsonSourceGeneratorDriver(compilation, generator);
            var newDriver = driver.RunGeneratorsAndUpdateCompilation(compilation, out newCompilation, out ImmutableArray<Diagnostic> diagnostics);
            var runResult = newDriver.GetRunResult();
            var contextSourceGenerator = runResult.Results.First(runResult => runResult.Generator.GetGeneratorType().Equals(typeof(ModelReaderWriterContextGenerator)));
            generatedSources = contextSourceGenerator.GeneratedSources;

            var finalDiagnostics = newCompilation.GetDiagnostics().Where(d => !s_noWarn.Contains(d.Descriptor.Id));
            foreach (var diagnostic in finalDiagnostics)
            {
                var location = diagnostic.Location;
                if (location.IsInSource)
                {
                    var filePath = location.SourceTree?.FilePath;

                    foreach (var result in runResult.Results)
                    {
                        foreach (var generatedSource in result.GeneratedSources)
                        {
                            if (generatedSource.SyntaxTree.FilePath == filePath)
                            {
                                var code = generatedSource.SyntaxTree.ToString();
                                Assert.Fail($"Generated source file has errors: {diagnostic}{Environment.NewLine}Source:{Environment.NewLine}{code}");
                            }
                        }
                    }
                }

                if (additionalSuppress is not null && additionalSuppress.Contains(diagnostic.Id))
                    continue;

                Assert.Fail($"Compilation Error: {diagnostic}");
            }

            return new()
            {
                GenerationSpec = generatedSpecs,
                Diagnostics = diagnostics
            };
        }

        public static CSharpGeneratorDriver CreateJsonSourceGeneratorDriver(Compilation compilation, ModelReaderWriterContextGenerator? generator = null)
        {
            generator ??= new();
            CSharpParseOptions parseOptions = compilation.SyntaxTrees
                .OfType<CSharpSyntaxTree>()
                .Select(tree => tree.Options)
                .FirstOrDefault() ?? s_defaultParseOptions;

            return
                CSharpGeneratorDriver.Create(
                    generators: [generator.AsSourceGenerator()],
                    parseOptions: parseOptions,
                    driverOptions: new GeneratorDriverOptions(
                        disabledOutputs: IncrementalGeneratorOutputKind.None));
        }
    }
}

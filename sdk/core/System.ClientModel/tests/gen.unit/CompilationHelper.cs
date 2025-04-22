// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
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
            string contextName = "LocalContext")
        {
            List<MetadataReference> references =
            [
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(ModelReaderWriter).Assembly.Location),
                MetadataReference.CreateFromFile(Path.Combine(typeof(object).Assembly.Location, "..", "System.Runtime.dll")),
                MetadataReference.CreateFromFile(typeof(JsonSerializer).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(BinaryData).Assembly.Location),
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

            parseOptions ??= s_defaultParseOptions;
            SyntaxTree[] syntaxTrees =
            [
                CSharpSyntaxTree.ParseText(source, parseOptions),
            ];

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

                Assert.Fail($"Compilation Error: {diag}");
            }

            return compilation;
        }

        public static GeneratorResult RunSourceGenerator(Compilation compilation, bool disableDiagnosticValidation = false)
            => RunSourceGenerator(compilation, out _, disableDiagnosticValidation);

        public static GeneratorResult RunSourceGenerator(Compilation compilation, out Compilation newCompilation, bool disableDiagnosticValidation = false)
        {
            ModelReaderWriterContextGenerationSpec? generatedSpecs = null;
            var generator = new ModelReaderWriterContextGenerator
            {
                OnSourceEmitting = specs => generatedSpecs = specs
            };

            CSharpGeneratorDriver driver = CreateJsonSourceGeneratorDriver(compilation, generator);
            driver.RunGeneratorsAndUpdateCompilation(compilation, out newCompilation, out ImmutableArray<Diagnostic> diagnostics);

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

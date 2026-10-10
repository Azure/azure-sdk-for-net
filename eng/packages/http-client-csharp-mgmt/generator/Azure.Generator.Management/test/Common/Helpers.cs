// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.TypeSpec.Generator;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Azure.Generator.Management.Tests.Common
{
    /// <summary>
    /// Helper methods for Azure plugin tests
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Get expected content from file with naming convention
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="method"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetExpectedFromFile(
            string? parameters = null,
            [CallerMemberName] string method = "",
            [CallerFilePath] string filePath = "")
        {
            return File.ReadAllText(GetAssetFileOrDirectoryPath(true, parameters, method, filePath)).Replace("\r\n", "\n");
        }

        /// <summary>
        /// Builds a compilation from the last-contract C# sources stored under
        /// <c>TestData/&lt;CallingClass&gt;/&lt;method&gt;/</c> next to the calling test, mirroring the upstream
        /// generator's <c>GetCompilationFromDirectoryAsync</c>. The generator's internal <c>GeneratedCodeWorkspace</c>
        /// helper is not accessible here, so the source files are added to the workspace project directly.
        /// </summary>
        public static Compilation GetCompilationFromDirectory(
            string? parameters = null,
            [CallerMemberName] string method = "",
            [CallerFilePath] string filePath = "")
        {
            var directory = GetAssetFileOrDirectoryPath(false, parameters, method, filePath);
            var documents = Directory.EnumerateFiles(directory, "*.cs", SearchOption.AllDirectories)
                .Select(file => (Name: Path.GetFileName(file), Text: File.ReadAllText(file)));
            return BuildCompilation(documents);
        }

        /// <summary>
        /// Builds a Roslyn compilation from the supplied C# documents using the generator's curated metadata references
        /// (plus the Azure runtime assemblies the sources may depend on). Shared by the last-contract and custom-code
        /// compilations so both resolve types consistently.
        /// </summary>
        public static Compilation BuildCompilation(IEnumerable<(string Name, string Text)> documents)
        {
            var workspace = new AdhocWorkspace();
            var newOptionSet = workspace.Options.WithChangedOption(FormattingOptions.NewLine, LanguageNames.CSharp, "\n");
            workspace.TryApplyChanges(workspace.CurrentSolution.WithOptions(newOptionSet));
            var project = workspace.AddProject("ExistingCode", LanguageNames.CSharp);

            foreach (var (name, text) in documents)
            {
                project = project.AddDocument(name, text).Project;
            }

            project = project
                .AddMetadataReferences(
                [
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(Response).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(ResourceManager.ArmClient).Assembly.Location),
                    .. CodeModelGenerator.Instance.AdditionalMetadataReferences,
                ])
                .WithCompilationOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, nullableContextOptions: NullableContextOptions.Disable));

            var compilation = project.GetCompilationAsync().GetAwaiter().GetResult();
            Assert.That(compilation, Is.Not.Null);
            return compilation!;
        }

        private static string GetAssetFileOrDirectoryPath(
            bool isFile,
            string? parameters = null,
            [CallerMemberName] string method = "",
            [CallerFilePath] string filePath = "")
        {
            var callingClass = Path.GetFileName(filePath).Split('.').First();
            var paramString = parameters is null ? string.Empty : $"({parameters})";
            var extName = isFile ? ".cs" : string.Empty;

            return Path.Combine(Path.GetDirectoryName(filePath)!, "TestData", callingClass, $"{method}{paramString}{extName}");
        }
    }
}

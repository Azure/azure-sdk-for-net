// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.TypeSpec.Generator;
using NUnit.Framework;

namespace Azure.Generator.Tests.Common
{
    /// <summary>
    /// Helper methods for Auzre plugin tests
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

        public static async Task<Compilation> GetCompilationFromDirectoryAsync(
            string? parameters = null,
            [CallerMemberName] string method = "",
            [CallerFilePath] string filePath = "")
        {
            var directory = GetAssetFileOrDirectoryPath(false, parameters, method, filePath);
            var generatorDirectory = FindGeneratorDirectory(filePath);
            var sharedSourceDirectory = Path.Combine(
                Path.GetDirectoryName(typeof(AzureTypeFactory).Assembly.Location)!,
                "Shared",
                "Core");
            string[] sharedSourceFiles =
            [
                Path.Combine(sharedSourceDirectory, "AppContextSwitchHelper.cs"),
                Path.Combine(sharedSourceDirectory, "ClientDiagnostics.cs"),
                Path.Combine(sharedSourceDirectory, "DiagnosticScope.cs"),
                Path.Combine(sharedSourceDirectory, "DiagnosticScopeFactory.cs"),
                Path.Combine(sharedSourceDirectory, "HttpMessageSanitizer.cs")
            ];
            var codeGenAttributeDirectory = Path.Combine(
                generatorDirectory,
                "TestProjects",
                "Local",
                "Basic-TypeSpec",
                "src",
                "Generated",
                "Internal");
            var project = CreateExistingCodeProject(
                [directory, .. sharedSourceFiles, codeGenAttributeDirectory],
                Path.Combine(directory, "Generated"));
            var compilation = await project.GetCompilationAsync();
            Assert.IsNotNull(compilation);
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

        private static string FindGeneratorDirectory(string filePath)
        {
            var directory = new DirectoryInfo(Path.GetDirectoryName(filePath)!);
            while (directory is not null && directory.Name != "generator")
            {
                directory = directory.Parent;
            }

            return directory?.FullName
                ?? throw new DirectoryNotFoundException($"Could not locate the generator directory from '{filePath}'.");
        }

        private static Project CreateExistingCodeProject(IEnumerable<string> projectPaths, string generatedDirectory)
        {
            var workspace = new AdhocWorkspace();
            var newOptionSet = workspace.Options.WithChangedOption(FormattingOptions.NewLine, LanguageNames.CSharp, "\n");
            workspace.TryApplyChanges(workspace.CurrentSolution.WithOptions(newOptionSet));
            Project project = workspace.AddProject("ExistingCode", LanguageNames.CSharp);
            var generatedDirectoryPrefix =
                $"{Path.GetFullPath(generatedDirectory).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)}{Path.DirectorySeparatorChar}";

            foreach (var projectPath in projectPaths)
            {
                if (!Path.IsPathRooted(projectPath))
                {
                    continue;
                }

                var sourceFiles = Directory.Exists(projectPath)
                    ? Directory.EnumerateFiles(Path.GetFullPath(projectPath), "*.cs", SearchOption.AllDirectories)
                    : [projectPath];

                foreach (var sourceFile in sourceFiles)
                {
                    var fullSourcePath = Path.GetFullPath(sourceFile);
                    if (!fullSourcePath.StartsWith(generatedDirectoryPrefix, StringComparison.Ordinal))
                    {
                        project = project.AddDocument(
                            Path.GetFileName(fullSourcePath),
                            File.ReadAllText(fullSourcePath),
                            filePath: fullSourcePath).Project;
                    }
                }
            }

            return project
                .AddMetadataReferences([
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                    .. CodeModelGenerator.Instance.AdditionalMetadataReferences
                ])
                .WithCompilationOptions(new CSharpCompilationOptions(
                    OutputKind.DynamicallyLinkedLibrary,
                    nullableContextOptions: NullableContextOptions.Disable));
        }
    }
}

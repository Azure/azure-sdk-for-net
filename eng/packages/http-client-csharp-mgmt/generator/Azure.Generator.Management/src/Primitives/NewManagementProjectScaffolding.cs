// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Primitives;

namespace Azure.Generator.Management.Primitives
{
    internal class NewManagementProjectScaffolding : NewAzureProjectScaffolding
    {
        private const string ReadmeTemplateResourceName = "Azure.Generator.Management.Assets.README.md.template";
        private const string PackageNamePlaceholder = "{packageName}";

        protected override IReadOnlyList<CSharpProjectCompileInclude> BuildCompileIncludes()
            => Array.Empty<CSharpProjectCompileInclude>();

        /// <summary>
        /// Gets the content for the solution file. When generating into an SDK package
        /// directory, the solution also references the tests project alongside src.
        /// </summary>
        protected override string GetSolutionFileContent()
        {
            string outputDir = ManagementClientGenerator.Instance.Configuration.OutputDirectory;

            if (!IsUnderSdkDirectory(outputDir))
            {
                return base.GetSolutionFileContent();
            }

            string packageName = ManagementClientGenerator.Instance.Configuration.PackageName;
            return $$"""
                <Solution>
                  <Project Path="src/{{packageName}}.csproj" />
                  <Project Path="tests/{{packageName}}.Tests.csproj" />
                </Solution>
                """;
        }

        /// <summary>
        /// Writes additional scaffolding files. The base class writes README.md, CHANGELOG.md
        /// and Directory.Build.props. This override additionally writes the test project csproj
        /// under tests/ when the output is under the sdk/ directory.
        /// </summary>
        protected override async Task WriteAdditionalFiles()
        {
            await base.WriteAdditionalFiles();

            string outputDir = ManagementClientGenerator.Instance.Configuration.OutputDirectory;

            if (!IsUnderSdkDirectory(outputDir))
            {
                return;
            }

            string packageName = ManagementClientGenerator.Instance.Configuration.PackageName;
            string testCsprojPath = Path.Combine(outputDir, "tests", $"{packageName}.Tests.csproj");

            if (!File.Exists(testCsprojPath))
            {
                string? directory = Path.GetDirectoryName(testCsprojPath);
                if (directory != null && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllText(testCsprojPath, GetTestProjectContent(packageName));
            }
        }

        private static bool IsUnderSdkDirectory(string outputDir)
        {
            string normalized = outputDir.Replace('\\', '/');
            return normalized.Contains("/sdk/");
        }

        /// <summary>
        /// Gets the content for the management plane README.md file.
        /// The template is loaded from the embedded resource <c>Assets/README.md.template</c>
        /// to keep this class focused on scaffolding logic.
        /// </summary>
        protected override string GetReadmeContent(string packageName)
        {
            string template = ReadEmbeddedResource(ReadmeTemplateResourceName);
            return template.Replace(PackageNamePlaceholder, packageName, StringComparison.Ordinal);
        }

        /// <summary>
        /// Gets the content for the test project .csproj file.
        /// </summary>
        protected virtual string GetTestProjectContent(string packageName)
        {
            return $"""
                <Project Sdk="Microsoft.NET.Sdk">
                  <ItemGroup>
                    <ProjectReference Include="..\src\{packageName}.csproj" />
                  </ItemGroup>
                </Project>
                """;
        }

        private static string ReadEmbeddedResource(string resourceName)
        {
            Assembly assembly = typeof(NewManagementProjectScaffolding).Assembly;
            using Stream? stream = assembly.GetManifestResourceStream(resourceName);
            if (stream is null)
            {
                throw new InvalidOperationException($"Embedded resource '{resourceName}' was not found in assembly '{assembly.FullName}'.");
            }

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Primitives;

namespace Azure.Generator.Management.Primitives
{
    internal class NewManagementProjectScaffolding : NewAzureProjectScaffolding
    {
        protected override IReadOnlyList<CSharpProjectCompileInclude> BuildCompileIncludes()
            => Array.Empty<CSharpProjectCompileInclude>();

        /// <summary>
        /// Writes additional scaffolding files (README.md, CHANGELOG.md, Directory.Build.props)
        /// to the output directory when the output is under the sdk/ directory.
        /// Files are only written if they don't already exist, preventing
        /// overwriting of customized content.
        /// </summary>
        protected override async Task WriteAdditionalFiles()
        {
            await base.WriteAdditionalFiles();

            string outputDir = ManagementClientGenerator.Instance.Configuration.OutputDirectory;

            // Only generate scaffolding files for real SDK packages under the sdk/ directory
            if (!IsUnderSdkDirectory(outputDir))
            {
                return;
            }

            string packageName = ManagementClientGenerator.Instance.Configuration.PackageName;

            WriteFileIfNotExists(Path.Combine(outputDir, "README.md"), packageName, GetReadmeContent);
            WriteFileIfNotExists(Path.Combine(outputDir, "CHANGELOG.md"), packageName, GetChangelogContent);
            WriteFileIfNotExists(Path.Combine(outputDir, "Directory.Build.props"), packageName, GetDirectoryBuildPropsContent);
        }

        private static void WriteFileIfNotExists(string filePath, string packageName, Func<string, string> contentFactory)
        {
            if (!File.Exists(filePath))
            {
                string content = contentFactory(packageName);

                string? directory = Path.GetDirectoryName(filePath);
                if (directory != null && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllText(filePath, content);
            }
        }

        /// <summary>
        /// Determines whether the output directory is under the sdk/ directory.
        /// </summary>
        private static bool IsUnderSdkDirectory(string outputDir)
        {
            string normalized = outputDir.Replace('\\', '/');
            return normalized.Contains("/sdk/");
        }

        /// <summary>
        /// Gets the content for the README.md file.
        /// </summary>
        protected virtual string GetReadmeContent(string packageName)
        {
            return $"""
                # {packageName} management client library for .NET

                {packageName} is a management client library for developing .NET applications with rich experience.

                ## Getting started

                ### Install the package

                Install the client library for .NET with [NuGet](https://www.nuget.org/):

                ```dotnetcli
                dotnet add package {packageName} --prerelease
                ```

                ### Prerequisites

                - You must have a [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

                ## Key concepts

                ## Examples

                ## Troubleshooting

                ## Next steps

                ## Contributing

                This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

                When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (for example, label, comment). Follow the instructions provided by the bot. You'll only need to do this action once across all repositories using our CLA.

                This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any other questions or comments.
                """;
        }

        /// <summary>
        /// Gets the content for the CHANGELOG.md file.
        /// </summary>
        protected virtual string GetChangelogContent(string packageName)
        {
            return $"""
                # Release History

                ## 1.0.0-beta.1 (Unreleased)

                ### Features Added

                ### Breaking Changes

                ### Bugs Fixed

                ### Other Changes
                """;
        }

        /// <summary>
        /// Gets the content for the Directory.Build.props file.
        /// </summary>
        protected virtual string GetDirectoryBuildPropsContent(string packageName)
        {
            return """
                <Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
                  <!--
                    Add any shared properties you want for the projects under this package directory that need to be set before the auto imported Directory.Build.props
                  -->
                  <Import Project="$([MSBuild]::GetDirectoryNameOfFileAbove($(MSBuildThisFileDirectory).., Directory.Build.props))\Directory.Build.props" />
                </Project>
                """;
        }
    }
}

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
        /// Gets the content for the solution file.
        /// </summary>
        protected override string GetSolutionFileContent()
        {
            string packageName = ManagementClientGenerator.Instance.Configuration.PackageName;
            string outputDir = ManagementClientGenerator.Instance.Configuration.OutputDirectory;

            if (!IsUnderSdkDirectory(outputDir))
            {
                return base.GetSolutionFileContent();
            }

            return $$"""
                <Solution>
                  <Project Path="src/{{packageName}}.csproj" />
                  <Project Path="tests/{{packageName}}.Tests.csproj" />
                </Solution>
                """;
        }

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

            // Generate test project csproj
            string testsDir = Path.Combine(outputDir, "tests");
            string testCsprojPath = Path.Combine(testsDir, $"{packageName}.Tests.csproj");
            WriteFileIfNotExists(testCsprojPath, packageName, GetTestProjectContent);
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

                This library supports managing Microsoft Azure resources.

                This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

                    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
                    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
                    - HTTP pipeline with custom policies.
                    - Better error-handling.
                    - Support uniform telemetry across all languages.

                ## Getting started

                ### Install the package

                Install the {packageName} management library for .NET with [NuGet](https://www.nuget.org/):

                ```dotnetcli
                dotnet add package {packageName} --prerelease
                ```

                ### Prerequisites

                * You must have an [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

                ### Authenticate the Client

                To create an authenticated client and start interacting with Microsoft Azure resources, see the [quickstart guide here](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

                ## Key concepts

                Key concepts of the Microsoft Azure SDK for .NET can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html).

                ## Documentation

                Documentation is available to help you learn how to use this package:

                - [Quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).
                - [API References](https://learn.microsoft.com/dotnet/api/?view=azure-dotnet).
                - [Authentication](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).

                ## Examples

                Code samples for using the management library for .NET can be found in the following locations
                - [.NET Management Library Code Samples](https://aka.ms/azuresdk-net-mgmt-samples)

                ## Troubleshooting

                -   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
                -   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

                ## Next steps

                For more information about Microsoft Azure SDK, see [this website](https://azure.github.io/azure-sdk/).

                ## Contributing

                For details on contributing to this repository, see the [contributing
                guide][cg].

                This project welcomes contributions and suggestions. Most contributions
                require you to agree to a Contributor License Agreement (CLA) declaring
                that you have the right to, and actually do, grant us the rights to use
                your contribution. For details, visit <https://cla.microsoft.com>.

                When you submit a pull request, a CLA-bot will automatically determine
                whether you need to provide a CLA and decorate the PR appropriately
                (for example, label, comment). Follow the instructions provided by the
                bot. You'll only need to do this action once across all repositories
                using our CLA.

                This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
                more information, see the [Code of Conduct FAQ][coc_faq] or contact
                <opencode@microsoft.com> with any other questions or comments.

                <!-- LINKS -->
                [cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
                [coc]: https://opensource.microsoft.com/codeofconduct/
                [coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
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
    }
}

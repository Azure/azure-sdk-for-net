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
        /// </summary>
        protected override string GetReadmeContent(string packageName)
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

                * You must have a [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

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

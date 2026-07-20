// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Generator.Primitives
{
    /// <summary>
    /// Defines the new project scaffolding needed for an azure sdk.
    /// </summary>
    public class NewAzureProjectScaffolding : NewProjectScaffolding
    {
        private const string MSBuildThisFileDirectory = "$(MSBuildThisFileDirectory)";
        private const string RelativeCoreSegment = "sdk/core/Azure.Core/src/Shared/";
        private const string ParentDirectory = "../";
        private const string SharedSourceLinkBase = "Shared/Core";

        /// <inheritdoc/>
        protected override string GetSourceProjectFileContent()
        {
            var builder = new CSharpProjectWriter()
            {
                Description = $"This is the {AzureClientGenerator.Instance.Configuration.PackageName} client library for developing .NET applications with rich experience.",
                AssemblyTitle = $"SDK Code Generation {AzureClientGenerator.Instance.Configuration.PackageName}",
                Version = "1.0.0-beta.1",
                PackageTags = AzureClientGenerator.Instance.TypeFactory.PrimaryNamespace,
                GenerateDocumentationFile = true,
            };

            foreach (var packages in AzureClientGenerator.Instance.TypeFactory.AzureDependencyPackages)
            {
                builder.PackageReferences.Add(packages);
            }

            foreach (var compileInclude in CompileIncludes)
            {
                builder.CompileIncludes.Add(compileInclude);
            }

            return builder.Write();
        }

        private static readonly IReadOnlyList<string> _operationSharedFiles =
        [
            "RawRequestUriBuilder.cs",
            "TypeFormatters.cs",
            "RequestHeaderExtensions.cs",
            "AppContextSwitchHelper.cs",
            "ClientDiagnostics.cs",
            "DiagnosticScopeFactory.cs",
            "DiagnosticScope.cs",
            "HttpMessageSanitizer.cs",
            "TrimmingAttribute.cs"
        ];

        private static readonly IReadOnlyList<string> _lroSharedFiles =
        [
            "AsyncLockWithValue.cs",
            "FixedDelayWithNoJitterStrategy.cs",
            "HttpPipelineExtensions.cs",
            "IOperationSource.cs",
            "NextLinkOperationImplementation.cs",
            "OperationFinalStateVia.cs",
            "OperationInternal.cs",
            "OperationInternalBase.cs",
            "OperationInternalOfT.cs",
            "OperationPoller.cs",
            "ProtocolOperation.cs",
            "ProtocolOperationHelpers.cs",
            "SequentialDelayStrategy.cs",
            "TaskExtensions.cs",
            "VoidValue.cs"
        ];

        private static readonly IReadOnlyList<string> _xmlSerializationSharedFiles =
        [
            "IXmlSerializable.cs",
            "XmlWriterContent.cs",
        ];

        private static void TraverseInput(InputClient rootClient, ref bool hasOperation, ref bool hasLongRunningOperation)
        {
            if (hasOperation && hasLongRunningOperation)
            {
                return;
            }

            foreach (var method in rootClient.Methods)
            {
                hasOperation = true;
                if (method is InputLongRunningServiceMethod || method is InputLongRunningPagingServiceMethod)
                {
                    hasLongRunningOperation = true;
                    return;
                }
            }
            foreach (var inputClient in rootClient.Children)
            {
                TraverseInput(inputClient, ref hasOperation, ref hasLongRunningOperation);
            }
        }

        private static int GetPathSegmentCount()
        {
            ReadOnlySpan<char> text = AzureClientGenerator.Instance.Configuration.OutputDirectory.AsSpan();
            // we are either a spector project in the eng folder or a real sdk in the sdk folder
            int beginning = text.IndexOf("eng");
            if (beginning == -1)
            {
                beginning = text.IndexOf("sdk");
            }
            text = text.Slice(beginning);
            // starting with 2 to include eng at the beginning and src at the end
            int pathSegmentCount = 2 + text.Count('/');
            // count both path separators to normalize
            pathSegmentCount += text.Count('\\');
            return pathSegmentCount;
        }

        /// <summary>
        /// Constructs a relative path for a compile include file based on the project structure.
        /// </summary>
        /// <param name="fileName">The name of the file to include.</param>
        /// <param name="relativeSegment">The relative path segment to the shared source files (defaults to RelativeCoreSegment).</param>
        /// <returns>A relative path string for the compile include file.</returns>
        protected string GetCompileInclude(string fileName, string relativeSegment = RelativeCoreSegment)
        {
            // Use the AzureCoreSharedSources property for Core shared files
            if (relativeSegment == RelativeCoreSegment)
            {
                return $"$(AzureCoreSharedSources){fileName}";
            }

            return $"{MSBuildThisFileDirectory}{string.Concat(Enumerable.Repeat(ParentDirectory, GetPathSegmentCount()))}{relativeSegment}{fileName}";
        }

        /// <summary>
        /// Gets the list of required CompileInclude files based on the project's requirements.
        /// </summary>
        /// <returns>A list of CSharpProjectCompileInclude files that should be included in the project.</returns>
        protected override IReadOnlyList<CSharpProjectCompileInclude> BuildCompileIncludes()
        {
            var compileIncludes = new List<CSharpProjectCompileInclude>();

            // ExperimentalAttribute polyfill is needed for netstandard2.0 and pre-.NET 8 targets
            // since the generated code uses [Experimental] on Settings types and constructors.
            compileIncludes.Add(new CSharpProjectCompileInclude(GetCompileInclude("ExperimentalAttribute.cs"), SharedSourceLinkBase));

            // Add API key credential policy if API key authentication is configured
            if (AzureClientGenerator.Instance.InputLibrary.InputNamespace.Auth?.ApiKey is not null)
            {
                compileIncludes.Add(new CSharpProjectCompileInclude(GetCompileInclude("AzureKeyCredentialPolicy.cs"), SharedSourceLinkBase));
            }

            // Analyze clients to determine what shared files are needed
            bool hasOperation = false;
            bool hasLongRunningOperation = false;
            foreach (var client in AzureClientGenerator.Instance.InputLibrary.InputNamespace.Clients)
            {
                TraverseInput(client, ref hasOperation, ref hasLongRunningOperation);
            }

            // Add operation-related shared files if operations are present
            if (hasOperation)
            {
                foreach (var file in _operationSharedFiles)
                {
                    compileIncludes.Add(new CSharpProjectCompileInclude(GetCompileInclude(file), SharedSourceLinkBase));
                }
            }

            // Add long-running operation shared files if LRO operations are present
            if (hasLongRunningOperation)
            {
                foreach (var file in _lroSharedFiles)
                {
                    compileIncludes.Add(new CSharpProjectCompileInclude(GetCompileInclude(file), SharedSourceLinkBase));
                }
            }

            // Add TaskExtensions if there are multipart form data operations and it hasn't already been added for LRO
            if (!hasLongRunningOperation && AzureClientGenerator.Instance.InputLibrary.HasMultipartFormDataOperation)
            {
                compileIncludes.Add(new CSharpProjectCompileInclude(GetCompileInclude("TaskExtensions.cs"), SharedSourceLinkBase));
            }

            // Add IXmlSerializable if any model supports XML serialization
            if (AzureClientGenerator.Instance.InputLibrary.HasXmlModelSerialization)
            {
                foreach (var file in _xmlSerializationSharedFiles)
                {
                    compileIncludes.Add(new CSharpProjectCompileInclude(GetCompileInclude(file), SharedSourceLinkBase));
                }
            }

            return compileIncludes;
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

            string outputDir = AzureClientGenerator.Instance.Configuration.OutputDirectory;

            // Only generate scaffolding files for real SDK packages under the sdk/ directory
            if (!IsUnderSdkDirectory(outputDir))
            {
                return;
            }

            string packageName = AzureClientGenerator.Instance.Configuration.PackageName;

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
        /// <param name="outputDir">The output directory path.</param>
        /// <returns><c>true</c> if the output directory is under the sdk/ directory; otherwise, <c>false</c>.</returns>
        private static bool IsUnderSdkDirectory(string outputDir)
        {
            string normalized = outputDir.Replace('\\', '/');
            return normalized.Contains("/sdk/");
        }

        /// <summary>
        /// Gets the content for the README.md file.
        /// </summary>
        /// <param name="packageName">The name of the package.</param>
        /// <returns>The README.md content.</returns>
        protected virtual string GetReadmeContent(string packageName)
        {
            return $"""
                # {packageName} client library for .NET

                {packageName} is a client library for developing .NET applications with rich experience.

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
        /// <param name="packageName">The name of the package.</param>
        /// <returns>The CHANGELOG.md content.</returns>
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
        /// <param name="packageName">The name of the package.</param>
        /// <returns>The Directory.Build.props content.</returns>
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
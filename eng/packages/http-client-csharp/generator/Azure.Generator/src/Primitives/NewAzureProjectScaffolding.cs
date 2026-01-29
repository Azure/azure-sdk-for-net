// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

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

            return compileIncludes;
        }
    }
}
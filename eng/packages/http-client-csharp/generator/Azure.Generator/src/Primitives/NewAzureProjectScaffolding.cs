// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
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

        /// <inheritdoc/>
        protected override string GetSourceProjectFileContent()
        {
            var builder = new CSharpProjectWriter()
            {
                Description = $"This is the {AzureClientPlugin.Instance.TypeFactory.PrimaryNamespace} client library for developing .NET applications with rich experience.",
                AssemblyTitle = $"SDK Code Generation {AzureClientPlugin.Instance.TypeFactory.PrimaryNamespace}",
                Version = "1.0.0-beta.1",
                PackageTags = AzureClientPlugin.Instance.TypeFactory.PrimaryNamespace,
                GenerateDocumentationFile = true,
            };

            foreach (var packages in _azureDependencyPackages)
            {
                builder.PackageReferences.Add(packages);
            }

            int pathSegmentCount = GetPathSegmentCount();
            if (AzureClientPlugin.Instance.InputLibrary.InputNamespace.Auth?.ApiKey is not null)
            {
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("AzureKeyCredentialPolicy.cs", pathSegmentCount), "Shared/Core"));
            }

            TraverseInput(out bool hasOperation, out bool hasLongRunningOperation);
            if (hasOperation)
            {
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("RawRequestUriBuilder.cs", pathSegmentCount), "Shared/Core"));
            }

            if (hasLongRunningOperation)
            {
                foreach (var file in _lroSharedFiles)
                {
                    builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude(file, pathSegmentCount), "Shared/Core"));
                }
            }

            return builder.Write();
        }

        private static readonly IReadOnlyList<string> _lroSharedFiles =
        [
            "AppContextSwitchHelper.cs",
            "AsyncLockWithValue.cs",
            "FixedDelayWithNoJitterStrategy.cs",
            "ClientDiagnostics.cs",
            "DiagnosticScopeFactory.cs",
            "DiagnosticScope.cs",
            "HttpMessageSanitizer.cs",
            "IOperationSource.cs",
            "NextLinkOperationImplementation.cs",
            "OperationFinalStateVia.cs",
            "OperationInternal.cs",
            "OperationInternalBase.cs",
            "OperationInternalOfT.cs",
            "OperationPoller.cs",
            "SequentialDelayStrategy.cs",
            "TaskExtensions.cs",
            "TrimmingAttribute.cs",
            "VoidValue.cs"
        ];

        private static void TraverseInput(out bool hasOperation, out bool hasLongRunningOperation)
        {
            hasOperation = false;
            hasLongRunningOperation = false;
            foreach (var inputClient in AzureClientPlugin.Instance.InputLibrary.InputNamespace.Clients)
            {
                foreach (var operation in inputClient.Operations)
                {
                    hasOperation = true;
                    if (operation.LongRunning != null)
                    {
                        hasLongRunningOperation = true;
                        return;
                    }
                }
            }
        }

        private static int GetPathSegmentCount()
        {
            ReadOnlySpan<char> text = AzureClientPlugin.Instance.Configuration.OutputDirectory.AsSpan();
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

        private string GetCompileInclude(string fileName, int pathSegmentCount)
        {
            return $"{MSBuildThisFileDirectory}{string.Concat(Enumerable.Repeat(ParentDirectory, pathSegmentCount))}{RelativeCoreSegment}{fileName}";
        }

        private static readonly IReadOnlyList<CSharpProjectWriter.CSProjDependencyPackage> _azureDependencyPackages =
            AzureClientPlugin.Instance.IsAzureArm.Value == true
            ? [
                new("Azure.Core"),
                new("Azure.ResourceManager"),
                new("System.ClientModel"),
                new("System.Text.Json")
            ]
            : [
                new("Azure.Core"),
                new("System.ClientModel"),
                new("System.Text.Json")
            ];
    }
}

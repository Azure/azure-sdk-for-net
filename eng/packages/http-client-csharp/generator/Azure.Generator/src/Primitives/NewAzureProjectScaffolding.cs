// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

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
                Description = $"This is the {AzureClientGenerator.Instance.TypeFactory.PrimaryNamespace} client library for developing .NET applications with rich experience.",
                AssemblyTitle = $"SDK Code Generation {AzureClientGenerator.Instance.TypeFactory.PrimaryNamespace}",
                Version = "1.0.0-beta.1",
                PackageTags = AzureClientGenerator.Instance.TypeFactory.PrimaryNamespace,
                GenerateDocumentationFile = true,
            };

            foreach (var packages in AzureClientGenerator.Instance.TypeFactory.AzureDependencyPackages)
            {
                builder.PackageReferences.Add(packages);
            }

            int pathSegmentCount = GetPathSegmentCount();
            if (AzureClientGenerator.Instance.InputLibrary.InputNamespace.Auth?.ApiKey is not null)
            {
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("AzureKeyCredentialPolicy.cs", pathSegmentCount), SharedSourceLinkBase));
            }

            bool hasOperation = false;
            bool hasLongRunningOperation = false;
            foreach (var client in AzureClientGenerator.Instance.InputLibrary.InputNamespace.Clients)
            {
                TraverseInput(client, ref hasOperation, ref hasLongRunningOperation);
            }

            if (hasOperation)
            {
                foreach (var file in _operationSharedFiles)
                {
                    builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude(file, pathSegmentCount), SharedSourceLinkBase));
                }
            }

            if (hasLongRunningOperation)
            {
                foreach (var file in _lroSharedFiles)
                {
                    builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude(file, pathSegmentCount), SharedSourceLinkBase));
                }
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
            "TrimmingAttribute.cs",
            "NoValueResponseOfT.cs",
        ];

        private static readonly IReadOnlyList<string> _lroSharedFiles =
        [
            "AsyncLockWithValue.cs",
            "FixedDelayWithNoJitterStrategy.cs",
            "IOperationSource.cs",
            "NextLinkOperationImplementation.cs",
            "OperationFinalStateVia.cs",
            "OperationInternal.cs",
            "OperationInternalBase.cs",
            "OperationInternalOfT.cs",
            "OperationPoller.cs",
            "SequentialDelayStrategy.cs",
            "TaskExtensions.cs",
            "VoidValue.cs"
        ];

        private static void TraverseInput(InputClient rootClient, ref bool hasOperation, ref bool hasLongRunningOperation)
        {
            hasOperation = false;
            hasLongRunningOperation = false;
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

        private string GetCompileInclude(string fileName, int pathSegmentCount)
        {
            return $"{MSBuildThisFileDirectory}{string.Concat(Enumerable.Repeat(ParentDirectory, pathSegmentCount))}{RelativeCoreSegment}{fileName}";
        }
    }
}
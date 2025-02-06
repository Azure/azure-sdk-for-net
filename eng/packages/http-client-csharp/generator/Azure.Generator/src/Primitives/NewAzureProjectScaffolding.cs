// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp;
using Microsoft.Generator.CSharp.Primitives;
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
                Description = $"This is the {AzureClientPlugin.Instance.Configuration.RootNamespace} client library for developing .NET applications with rich experience.",
                AssemblyTitle = $"SDK Code Generation {AzureClientPlugin.Instance.Configuration.RootNamespace}",
                Version = "1.0.0-beta.1",
                PackageTags = AzureClientPlugin.Instance.Configuration.RootNamespace,
                GenerateDocumentationFile = true,
            };

            foreach (var packages in _azureDependencyPackages)
            {
                builder.PackageReferences.Add(packages);
            }

            int pathSegmentCount = GetPathSegmentCount();
            if (AzureClientPlugin.Instance.InputLibrary.InputNamespace.Auth.ApiKey is not null)
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
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("AppContextSwitchHelper.cs", pathSegmentCount), "Shared/Core"));
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("AsyncLockWithValue.cs", pathSegmentCount), "Shared/Core"));
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("FixedDelayWithNoJitterStrategy.cs", pathSegmentCount), "Shared/Core"));
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("ClientDiagnostics.cs", pathSegmentCount), "Shared/Core"));
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("DiagnosticScopeFactory.cs", pathSegmentCount), "Shared/Core"));
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("DiagnosticScope.cs", pathSegmentCount), "Shared/Core"));
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("HttpMessageSanitizer.cs", pathSegmentCount), "Shared/Core"));
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("IOperationSource.cs", pathSegmentCount), "Shared/Core"));
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("NextLinkOperationImplementation.cs", pathSegmentCount), "Shared/Core"));
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("OperationFinalStateVia.cs", pathSegmentCount), "Shared/Core"));
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("OperationInternal.cs", pathSegmentCount), "Shared/Core"));
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("OperationInternalBase.cs", pathSegmentCount), "Shared/Core"));
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("OperationInternalOfT.cs", pathSegmentCount), "Shared/Core"));
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("OperationPoller.cs", pathSegmentCount), "Shared/Core"));
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("SequentialDelayStrategy.cs", pathSegmentCount), "Shared/Core"));
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("TaskExtensions.cs", pathSegmentCount), "Shared/Core"));
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("TrimmingAttribute.cs", pathSegmentCount), "Shared/Core"));
                builder.CompileIncludes.Add(new CSharpProjectWriter.CSProjCompileInclude(GetCompileInclude("VoidValue.cs", pathSegmentCount), "Shared/Core"));
            }

            return builder.Write();
        }

        private void TraverseInput(out bool hasOperation, out bool hasLongRunningOperation)
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
                new("System.Text.Json"),
                new("System.ClientModel")
            ]
            : [
                new("Azure.Core"),
                new("System.Text.Json")
            ];

        private static readonly IReadOnlyList<CSharpProjectWriter.CSProjDependencyPackage> _brandedDependencyPackages =
            [
                new("Azure.Core"),
                new("System.Text.Json")
            ];

        /// <inheritdoc/>
        protected override string GetSolutionFileContent()
        {
            string slnContent = @"Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.10.35201.131
MinimumVisualStudioVersion = 10.0.40219.1
Project(""{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}"") = ""{0}"", ""src\{0}.csproj"", ""{{28FF4005-4467-4E36-92E7-DEA27DEB1519}}""
EndProject
Global
    GlobalSection(SolutionConfigurationPlatforms) = preSolution
        Debug|Any CPU = Debug|Any CPU
        Release|Any CPU = Release|Any CPU
    EndGlobalSection
    GlobalSection(ProjectConfigurationPlatforms) = postSolution
        {{28FF4005-4467-4E36-92E7-DEA27DEB1519}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        {{28FF4005-4467-4E36-92E7-DEA27DEB1519}}.Debug|Any CPU.Build.0 = Debug|Any CPU
        {{28FF4005-4467-4E36-92E7-DEA27DEB1519}}.Release|Any CPU.ActiveCfg = Release|Any CPU
        {{28FF4005-4467-4E36-92E7-DEA27DEB1519}}.Release|Any CPU.Build.0 = Release|Any CPU
    EndGlobalSection
    GlobalSection(SolutionProperties) = preSolution
        HideSolutionNode = FALSE
    EndGlobalSection
    GlobalSection(ExtensibilityGlobals) = postSolution
        SolutionGuid = {{A97F4B90-2591-4689-B1F8-5F21FE6D6CAE}}
    EndGlobalSection
EndGlobal
";
            return string.Format(slnContent, AzureClientPlugin.Instance.Configuration.RootNamespace);
        }
    }
}

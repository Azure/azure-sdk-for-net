// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Generator.Primitives;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Primitives;

namespace Azure.Generator.Provisioning.Primitives
{
    internal class NewProvisioningProjectScaffolding : NewAzureProjectScaffolding
    {
        protected override string GetSourceProjectFileContent()
        {
            string packageName = ProvisioningGenerator.Instance.Configuration.PackageName;
            var writer = new CSharpProjectWriter
            {
                Description = $"{packageName} simplifies declarative resource provisioning in .NET.",
                AssemblyTitle = $"SDK Code Generation {packageName}",
                Version = "1.0.0-beta.1",
                PackageTags = ProvisioningGenerator.Instance.TypeFactory.PrimaryNamespace,
                GenerateDocumentationFile = true,
            };
            writer.PackageReferences.Add(new("Azure.Provisioning"));
            foreach (var include in CompileIncludes)
            {
                writer.CompileIncludes.Add(include);
            }
            return writer.Write();
        }

        protected override IReadOnlyList<CSharpProjectCompileInclude> BuildCompileIncludes()
            => [];

        protected override string GetSolutionFileContent()
        {
            if (!IsUnderSdkDirectory())
            {
                return base.GetSolutionFileContent();
            }

            string packageName = ProvisioningGenerator.Instance.Configuration.PackageName;
            return $$"""
                <Solution>
                  <Project Path="src/{{packageName}}.csproj" />
                  <Project Path="tests/{{packageName}}.Tests.csproj" />
                </Solution>
                """;
        }

        protected override string GetTestProjectFileContent()
        {
            string packageName = ProvisioningGenerator.Instance.Configuration.PackageName;
            return $"""
                <Project Sdk="Microsoft.NET.Sdk">
                  <PropertyGroup>
                    <TargetFrameworks>$(RequiredTargetFrameworks)</TargetFrameworks>
                    <IsTestProject>true</IsTestProject>
                    <Nullable>enable</Nullable>
                  </PropertyGroup>
                  <ItemGroup>
                    <ProjectReference Include="$(AzureCoreTestFramework)" Condition="'$(IsMgmtLibrary)' != 'true'" />
                    <ProjectReference Include="{GetCompileInclude("Azure.Provisioning.csproj", "sdk/provisioning/Azure.Provisioning/src/")}" />
                    <ProjectReference Include="..\src\{packageName}.csproj" />
                    <ProjectReference Include="{GetCompileInclude("Azure.Provisioning.Deployment.csproj", "sdk/provisioning/Azure.Provisioning.Deployment/src/")}" />
                  </ItemGroup>
                  <ItemGroup>
                    <Compile Include="{GetCompileInclude("*.cs", "common/ProvisioningTestShared/")}" LinkBase="Shared/ProvisioningTestShared" />
                  </ItemGroup>
                  <ItemGroup Condition="'$(IsMgmtLibrary)' != 'true' and '$(IsStorageTest)' != 'true'">
                    <PackageReference Include="NUnit" />
                    <PackageReference Include="NUnit3TestAdapter" />
                    <PackageReference Include="Microsoft.NET.Test.Sdk" />
                    <PackageReference Include="Moq" />
                  </ItemGroup>
                </Project>
                """ + "\n";
        }

        protected override async Task WriteAdditionalFiles()
        {
            await base.WriteAdditionalFiles();
            string outputDir = ProvisioningGenerator.Instance.Configuration.OutputDirectory;
            string packageName = ProvisioningGenerator.Instance.Configuration.PackageName;
            if (!IsUnderSdkDirectory())
            {
                Directory.CreateDirectory(outputDir);
                File.WriteAllText(Path.Combine(outputDir, "Directory.Build.props"), GetDirectoryBuildPropsContent(packageName));
                return;
            }

            string testProjectPath = Path.Combine(outputDir, "tests", $"{packageName}.Tests.csproj");
            if (!File.Exists(testProjectPath))
            {
                Directory.CreateDirectory(Path.Combine(outputDir, "tests"));
                File.WriteAllText(testProjectPath, GetTestProjectFileContent());
            }
        }

        protected override string GetReadmeContent(string packageName)
        {
            const string resourceName = "Azure.Generator.Provisioning.Assets.README.md.template";
            using Stream? stream = typeof(NewProvisioningProjectScaffolding).Assembly.GetManifestResourceStream(resourceName);
            if (stream is null)
            {
                throw new InvalidOperationException($"Embedded resource '{resourceName}' was not found.");
            }
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd().Replace("{packageName}", packageName, StringComparison.Ordinal);
        }

        protected override string GetDirectoryBuildPropsContent(string packageName)
        {
            return """
                <Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
                  <Import Project="$([MSBuild]::GetDirectoryNameOfFileAbove($(MSBuildThisFileDirectory).., Directory.Build.props))\Directory.Build.props" />

                  <PropertyGroup>
                    <TargetFrameworks>$(RequiredTargetFrameworks)</TargetFrameworks>
                    <IsMgmtLibrary>true</IsMgmtLibrary>
                  </PropertyGroup>

                  <!--
                    Temporarily disable warnings from new analyzers:
                      AZC0034: Typename is already used in another library.
                      AZC0035: Missing model factory method

                      Tracked by # 51311
                  -->
                  <PropertyGroup>
                    <NoWarn>
                      $(NoWarn);
                      AZC0034;
                      AZC0035;
                    </NoWarn>
                  </PropertyGroup>

                  <ItemGroup>
                    <Compile Include="$(AzureCoreSharedSources)ExperimentalAttribute.cs" LinkBase="Shared\Core" />
                  </ItemGroup>
                  <ItemGroup>
                    <!--
                    Azure.Core isn't being found on builds with
                    dotnet build .\Azure.Provisioning.sln /p:UseProjectReferenceToAzureClients=true
                    for some reason.  Temporarily adding an explicit Azure.Core reference so
                    it's correctly replaced in all projects for those build targets.
                    -->
                    <PackageReference Include="Azure.Core" Condition="$(UseProjectReferenceToAzureClients) == 'true'" />
                  </ItemGroup>

                </Project>
                """ + "\n";
        }

        private static bool IsUnderSdkDirectory()
            => ProvisioningGenerator.Instance.Configuration.OutputDirectory.Replace('\\', '/').Contains("/sdk/");
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Provisioning.Generator.Model;

public abstract partial class Specification : ModelBase
{
    private string? _namespacePath = null;
    private string GetNamespacePath()
    {
        if (_namespacePath is not null) { return _namespacePath; }

        // TODO: This assumes we're always running in place, in the repo
        string? path = Environment.CurrentDirectory;
        while (path is not null && !Directory.Exists(Path.Combine(path, ".git")))
        {
            // Walk up a level
            path = Path.GetDirectoryName(path);
        }

        // If all else fails, just use the current directory
        path ??= Environment.CurrentDirectory;

        // Walk from the root of the repo into the provisioning folder
        path = Path.Combine(path, "sdk", "provisioning");
        if (!Directory.Exists(path))
        {
            throw new InvalidOperationException($"Directory {path} must exist to write {Namespace}!");
        }

        // Special case namespaces we're collapsing into the main Azure.Provisioning
        string? ns = Namespace switch
        {
            "Azure.Provisioning.Authorization" => "Azure.Provisioning",
            "Azure.Provisioning.Resources" => "Azure.Provisioning",
            "Azure.Provisioning.Roles" => "Azure.Provisioning",
            _ => Namespace
        };

        // Add on our namespace
        if (ns is not null)
        {
            path = Path.Combine(path, ns);
        }

        return _namespacePath = path;
    }

    private string? _generationPath = null;
    private string? GetGenerationPath()
    {
        if (_generationPath is not null) { return _generationPath; }

        // Bail out early if this path doesn't exist
        string? path = GetNamespacePath();
        if (!Directory.Exists(path))
        {
            return null;
        }

        // Move us into the generated dir
        path = Path.Combine(path, "src", "Generated");
        if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }

        return _generationPath = path;
    }

    public void SaveFile(string relativePath, string content)
    {
        string? path = GetGenerationPath();
        if (path is null)
        {
            // Generate an empty project if needed
            CreateStarterProject();

            // Try again now that all the dirs exist
            path = GetGenerationPath();
            if (path is null)
            {
                throw new InvalidOperationException($"Failed to generate starter project for {Namespace}!");
            }
        }

        // Add on the relative path (and make sure we generate a directory if needed)
        path = Path.Combine(path, relativePath);
        string dir = Path.GetDirectoryName(path)!;
        if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

        // Write out the file
        File.WriteAllText(path, content);
    }

    private void CreateStarterProject()
    {
        // Create the assembly dir
        string? path = GetNamespacePath();
        Directory.CreateDirectory(path);
        File.WriteAllText(Path.Combine(path, "Changelog.md"),
            $"""
                # Release History

                ## 1.0.0-beta.1 (Unreleased)

                ### Features Added

                - Initial beta release of new {Namespace}.
                """);
        File.WriteAllText(Path.Combine(path, "README.md"),
            $"""
                # {Namespace} client library for .NET

                {Namespace} simplifies declarative resource provisioning in .NET.

                ## Getting started

                ### Install the package

                Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

                ```dotnetcli
                dotnet add package {Namespace}
                ```

                ### Prerequisites

                > You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

                ### Authenticate the Client

                ## Key concepts

                This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

                ## Troubleshooting

                -   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
                -   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

                ## Next steps

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
                """);

        // Generate the source
        Directory.CreateDirectory(Path.Combine(path, "src"));
        File.WriteAllText(Path.Combine(path, "src", $"{Namespace}.csproj"),
            $"""
                <Project Sdk="Microsoft.NET.Sdk">

                  <PropertyGroup>
                    <Description>{Namespace} simplifies declarative resource provisioning in .NET.</Description>
                    <Version>1.0.0-beta.1</Version>
                    <TargetFrameworks>$(RequiredTargetFrameworks)</TargetFrameworks>
                    <LangVersion>12</LangVersion>

                    <!-- Disable warning CS1591: Missing XML comment for publicly visible type or member -->
                    <NoWarn>CS1591</NoWarn>
                  </PropertyGroup>

                  <!-- TODO: Consider adding DataPlane dependencies here like:
                  <ItemGroup>
                    <PackageReference Include="Azure.Storage.Blobs" />
                  </ItemGroup>
                  -->

                </Project>
                """);
        Directory.CreateDirectory(Path.Combine(path, "src", "Properties"));
        File.WriteAllText(Path.Combine(path, "src", "Properties", "AssemblyInfo.cs"),
            """
                // Copyright (c) Microsoft Corporation. All rights reserved.
                // Licensed under the MIT License.

                using System.Diagnostics.CodeAnalysis;

                [assembly: Experimental("AZPROVISION001")]
                """);

        // Generate the tests
        Directory.CreateDirectory(Path.Combine(path, "tests"));
        File.WriteAllText(Path.Combine(path, "tests", $"{Namespace}.Tests.csproj"),
            $"""
                <Project Sdk="Microsoft.NET.Sdk">
                  <PropertyGroup>
                    <LangVersion>12</LangVersion>
                  </PropertyGroup>
                  <ItemGroup>
                    <ProjectReference Include="..\..\..\core\Azure.Core.TestFramework\src\Azure.Core.TestFramework.csproj" />
                    <ProjectReference Include="..\src\{Namespace}.csproj" />
                  </ItemGroup>
                </Project>
                """);
        File.WriteAllText(Path.Combine(path, "tests", $"BasicTests.cs"),
            $$"""
                // Copyright (c) Microsoft Corporation. All rights reserved.
                // Licensed under the MIT License.

                using System;
                using Azure.Core;
                using Azure.Provisioning;
                using {{Namespace}};
                using Azure.Provisioning.Tests;
                using NUnit.Framework;

                namespace {{Namespace}}.Tests;

                public class BasicTests(bool async) : ProvisioningTestBase(async)
                {
                    [Test]
                    public void GetStarted()
                    {
                        Assert.Inconclusive("Implement me!");
                    }
                }
                """);
    }
}

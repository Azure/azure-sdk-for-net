// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Microsoft.TypeSpec.Generator.Mcp.Tests;

public sealed class ConsumerMetadataTests
{
    [TestCase(false)]
    [TestCase(true)]
    public void ReferencesComeFromEvaluatedProjectOutputNotHardcodedBuildPaths(bool azure)
    {
        var root = CreateProject();
        try
        {
            var output = Path.Combine(root, "custom-output");
            Directory.CreateDirectory(output);
            var core = Path.Combine(output, "Microsoft.Mcp.Core.dll");
            File.WriteAllText(core, "Reference discovery does not load this test file.");
            if (azure)
            {
                File.WriteAllText(Path.Combine(output, "Azure.Mcp.Core.dll"), "Optional framework.");
            }
            Assert.That(ConsumerMetadata.Resolve(root), Is.EqualTo(azure
                ? new[] { core, Path.Combine(output, "Azure.Mcp.Core.dll") } : new[] { core }));
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    [TestCase("missing-project", "exactly one")]
    [TestCase("multiple-projects", "exactly one")]
    [TestCase("missing-build", "baseline")]
    [TestCase("missing-core", "missing MCP framework")]
    [TestCase("invalid-project", "Cannot evaluate")]
    public void InvalidOrUnbuiltConsumerFailsExplicitly(string change, string message)
    {
        var root = CreateProject();
        try
        {
            var project = Path.Combine(root, "src", "Consumer.csproj");
            switch (change)
            {
                case "missing-project":
                    File.Delete(project);
                    break;
                case "multiple-projects":
                    File.Copy(project, Path.Combine(root, "src", "Other.csproj"));
                    break;
                case "missing-core":
                    Directory.CreateDirectory(Path.Combine(root, "custom-output"));
                    break;
                case "invalid-project":
                    File.WriteAllText(project, "<Project>");
                    break;
            }
            Assert.That(() => ConsumerMetadata.Resolve(root), Throws.InvalidOperationException.With.Message.Contains(message));
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    private static string CreateProject()
    {
        var root = Path.Combine(GenerationTests.FindPackage(), "temp", Guid.NewGuid().ToString("N"));
        var source = Path.Combine(root, "src");
        Directory.CreateDirectory(source);
        foreach (var file in new[] { "Directory.Build.props", "Directory.Build.targets", "Directory.Packages.props" })
        {
            File.WriteAllText(Path.Combine(root, file), "<Project />");
        }
        File.WriteAllText(Path.Combine(source, "Consumer.csproj"), """
            <Project Sdk="Microsoft.NET.Sdk">
              <PropertyGroup>
                <TargetFramework>net10.0</TargetFramework>
                <OutputPath>../custom-output/</OutputPath>
                <AppendTargetFrameworkToOutputPath>false</AppendTargetFrameworkToOutputPath>
              </PropertyGroup>
            </Project>
            """);
        return root;
    }
}

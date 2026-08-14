// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class CodeGenerationToolTests
{
    [Test]
    public void BuildArguments_NoLocalSpecs_ReturnsBaseArgs()
    {
        var args = CodeGenerationTool.BuildArguments(null);

        Assert.That(args, Is.EqualTo("build /t:generateCode"));
    }

    [Test]
    public void BuildArguments_EmptyLocalSpecs_ReturnsBaseArgs()
    {
        var args = CodeGenerationTool.BuildArguments("");

        Assert.That(args, Is.EqualTo("build /t:generateCode"));
    }

    [Test]
    public void BuildArguments_WhitespaceLocalSpecs_ReturnsBaseArgs()
    {
        var args = CodeGenerationTool.BuildArguments("   ");

        Assert.That(args, Is.EqualTo("build /t:generateCode"));
    }

    [Test]
    public void BuildArguments_WithLocalSpecs_IncludesLocalSpecRepo()
    {
        var specsPath = Path.Combine(Path.GetTempPath(), "azure-rest-api-specs");

        var args = CodeGenerationTool.BuildArguments(specsPath);

        Assert.Multiple(() =>
        {
            Assert.That(args, Does.StartWith("build /t:generateCode"));
            Assert.That(args, Does.Contain("/p:LocalSpecRepo="));
            Assert.That(args, Does.Contain("azure-rest-api-specs"));
        });
    }

    [Test]
    public void BuildArguments_WithLocalSpecs_NormalizesPath()
    {
        var specsPath = Path.Combine(Path.GetTempPath(), "specs", "..", "azure-rest-api-specs");

        var args = CodeGenerationTool.BuildArguments(specsPath);

        // Path should be normalized (no ".." segments)
        Assert.That(args, Does.Not.Contain(".."));
        Assert.That(args, Does.Contain("/p:LocalSpecRepo="));
    }

    [Test]
    public void ResolveLocalSpecsPath_NullInput_ReturnsNull()
    {
        var result = CodeGenerationTool.ResolveLocalSpecsPath(Path.GetTempPath(), null);
        Assert.That(result, Is.Null);
    }

    [Test]
    public void ResolveLocalSpecsPath_EmptyInput_ReturnsNull()
    {
        var result = CodeGenerationTool.ResolveLocalSpecsPath(Path.GetTempPath(), "");
        Assert.That(result, Is.Null);
    }

    [Test]
    public void ResolveLocalSpecsPath_DirectoryWithMainTsp_ReturnsDirectly()
    {
        // Create a temp directory with main.tsp to simulate a spec directory
        var tempDir = Path.Combine(Path.GetTempPath(), "resolve-test-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(tempDir);
        File.WriteAllText(Path.Combine(tempDir, "main.tsp"), "// test");

        try
        {
            var result = CodeGenerationTool.ResolveLocalSpecsPath(Path.GetTempPath(), tempDir);
            Assert.That(result, Is.EqualTo(Path.GetFullPath(tempDir)));
        }
        finally
        {
            Directory.Delete(tempDir, true);
        }
    }

    [Test]
    public void ResolveLocalSpecsPath_RepoRootWithTspLocation_ResolvesViaDirectory()
    {
        // Set up: repo root with spec subdirectory, project with tsp-location.yaml
        var tempRoot = Path.Combine(Path.GetTempPath(), "resolve-repo-test-" + Guid.NewGuid().ToString("N"));
        var repoRoot = Path.Combine(tempRoot, "repo");
        var specDir = Path.Combine(repoRoot, "specification", "myservice", "MyService");
        var projectDir = Path.Combine(tempRoot, "sdk", "myservice", "Azure.MyService");

        Directory.CreateDirectory(specDir);
        Directory.CreateDirectory(projectDir);

        // Create main.tsp in spec dir so we can verify resolution
        File.WriteAllText(Path.Combine(specDir, "main.tsp"), "// test");

        // Create tsp-location.yaml in project dir
        File.WriteAllText(Path.Combine(projectDir, "tsp-location.yaml"),
            "directory: specification/myservice/MyService\ncommit: abc123\nrepo: Azure/azure-rest-api-specs\n");

        try
        {
            var result = CodeGenerationTool.ResolveLocalSpecsPath(projectDir, repoRoot);
            Assert.That(result, Is.EqualTo(Path.GetFullPath(specDir)));
        }
        finally
        {
            Directory.Delete(tempRoot, true);
        }
    }

    [Test]
    public void ResolveLocalSpecsPath_RepoRootNoTspLocation_FallsBack()
    {
        // No tsp-location.yaml — should fall back to original path
        var tempDir = Path.Combine(Path.GetTempPath(), "resolve-fallback-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(tempDir);

        try
        {
            var result = CodeGenerationTool.ResolveLocalSpecsPath(Path.GetTempPath(), tempDir);
            Assert.That(result, Is.EqualTo(Path.GetFullPath(tempDir)));
        }
        finally
        {
            Directory.Delete(tempDir, true);
        }
    }

    [Test]
    public void ReadTspLocationDirectory_ValidFile_ReturnsDirectory()
    {
        var tempDir = Path.Combine(Path.GetTempPath(), "tsp-loc-test-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(tempDir);
        File.WriteAllText(Path.Combine(tempDir, "tsp-location.yaml"),
            "directory: specification/communication/Communication.Messages\ncommit: abc123\nrepo: Azure/azure-rest-api-specs\n");

        try
        {
            var result = CodeGenerationTool.ReadTspLocationDirectory(tempDir);
            Assert.That(result, Is.EqualTo("specification/communication/Communication.Messages"));
        }
        finally
        {
            Directory.Delete(tempDir, true);
        }
    }

    [Test]
    public void ReadTspLocationDirectory_MissingFile_ReturnsNull()
    {
        var result = CodeGenerationTool.ReadTspLocationDirectory(Path.GetTempPath());
        Assert.That(result, Is.Null);
    }
}

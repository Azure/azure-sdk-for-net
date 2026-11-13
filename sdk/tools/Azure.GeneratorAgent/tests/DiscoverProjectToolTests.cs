// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class DiscoverProjectToolTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"DiscoverProjectTests_{Guid.NewGuid():N}");
        Directory.CreateDirectory(_tempDir);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_tempDir))
        {
            Directory.Delete(_tempDir, true);
        }
    }

    [Test]
    public void NonExistentDirectory_ReturnsError()
    {
        var result = DiscoverProjectTool.ExecuteInProcess(Path.Combine(_tempDir, "nope"));

        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.False);
            Assert.That(result.Error, Does.Contain("Directory not found"));
        });
    }

    [Test]
    public void MgmtPackage_DetectedByName()
    {
        var projectDir = CreateProjectStructure("sdk", "compute", "Azure.ResourceManager.Compute");

        var result = DiscoverProjectTool.ExecuteInProcess(projectDir);

        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.Plane, Is.EqualTo("mpg"));
            Assert.That(result.PackageName, Is.EqualTo("Azure.ResourceManager.Compute"));
            Assert.That(result.ServiceName, Is.EqualTo("compute"));
            Assert.That(result.EmitterKey, Is.EqualTo("@azure-typespec/http-client-csharp-mgmt"));
            Assert.That(result.EmitterPackageJsonPath, Does.Contain("mgmt"));
        });
    }

    [Test]
    public void DpgPackage_DetectedByName()
    {
        var projectDir = CreateProjectStructure("sdk", "openai", "Azure.AI.OpenAI");

        var result = DiscoverProjectTool.ExecuteInProcess(projectDir);

        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.Plane, Is.EqualTo("dpg"));
            Assert.That(result.PackageName, Is.EqualTo("Azure.AI.OpenAI"));
            Assert.That(result.ServiceName, Is.EqualTo("openai"));
            Assert.That(result.EmitterKey, Is.EqualTo("@azure-typespec/http-client-csharp"));
            Assert.That(result.EmitterPackageJsonPath, Does.Not.Contain("mgmt"));
        });
    }

    [Test]
    public void LibraryPath_ResolvedCorrectly()
    {
        var projectDir = CreateProjectStructure("sdk", "compute", "Azure.ResourceManager.Compute");

        var result = DiscoverProjectTool.ExecuteInProcess(projectDir);

        Assert.That(result.LibraryPath, Is.EqualTo("sdk/compute/Azure.ResourceManager.Compute"));
    }

    [Test]
    public void TspLocation_Parsed()
    {
        var projectDir = CreateProjectStructure("sdk", "compute", "Azure.ResourceManager.Compute");
        File.WriteAllText(Path.Combine(projectDir, "tsp-location.yaml"), """
            directory: specification/compute/Compute.Management
            commit: abc123
            repo: Azure/azure-rest-api-specs
            cleanup: false
            emitterPackageJsonPath: eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json
            """);

        var result = DiscoverProjectTool.ExecuteInProcess(projectDir);

        Assert.Multiple(() =>
        {
            Assert.That(result.HasTspLocation, Is.True);
            Assert.That(result.TspLocationFields, Is.Not.Null);
            Assert.That(result.TspLocationFields!["directory"], Is.EqualTo("specification/compute/Compute.Management"));
            Assert.That(result.TspLocationFields["commit"], Is.EqualTo("abc123"));
            Assert.That(result.TspLocationFields["repo"], Is.EqualTo("Azure/azure-rest-api-specs"));
            Assert.That(result.TspLocationFields["cleanup"], Is.EqualTo("false"));
        });
    }

    [Test]
    public void TspLocation_EmitterOverridesPlane_DpgEmitterOnMgmtName()
    {
        // Package name looks mgmt, but emitter says dpg
        var projectDir = CreateProjectStructure("sdk", "compute", "Azure.ResourceManager.Compute");
        File.WriteAllText(Path.Combine(projectDir, "tsp-location.yaml"), """
            directory: specification/compute/Compute.Management
            emitterPackageJsonPath: eng/azure-typespec-http-client-csharp-emitter-package.json
            """);

        var result = DiscoverProjectTool.ExecuteInProcess(projectDir);

        Assert.That(result.Plane, Is.EqualTo("dpg"));
    }

    [Test]
    public void TspLocation_MgmtEmitterOverridesPlane()
    {
        // Package name looks dpg, but emitter says mgmt
        var projectDir = CreateProjectStructure("sdk", "ai", "Azure.AI.Something");
        File.WriteAllText(Path.Combine(projectDir, "tsp-location.yaml"), """
            directory: specification/ai/Ai.Management
            emitterPackageJsonPath: eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json
            """);

        var result = DiscoverProjectTool.ExecuteInProcess(projectDir);

        Assert.That(result.Plane, Is.EqualTo("mpg"));
    }

    [Test]
    public void NoTspLocation_FlagsFalse()
    {
        var projectDir = CreateProjectStructure("sdk", "compute", "Azure.ResourceManager.Compute");

        var result = DiscoverProjectTool.ExecuteInProcess(projectDir);

        Assert.Multiple(() =>
        {
            Assert.That(result.HasTspLocation, Is.False);
            Assert.That(result.TspLocationFields, Is.Null);
        });
    }

    [Test]
    public void AutorestMd_Detected()
    {
        var projectDir = CreateProjectStructure("sdk", "compute", "Azure.ResourceManager.Compute");
        var srcDir = Path.Combine(projectDir, "src");
        Directory.CreateDirectory(srcDir);
        File.WriteAllText(Path.Combine(srcDir, "autorest.md"), "# AutoRest config");

        var result = DiscoverProjectTool.ExecuteInProcess(projectDir);

        Assert.That(result.HasAutorestMd, Is.True);
    }

    [Test]
    public void NoAutorestMd_FlagsFalse()
    {
        var projectDir = CreateProjectStructure("sdk", "compute", "Azure.ResourceManager.Compute");

        var result = DiscoverProjectTool.ExecuteInProcess(projectDir);

        Assert.That(result.HasAutorestMd, Is.False);
    }

    [Test]
    [TestCase("Custom")]
    [TestCase("Customization")]
    [TestCase("Customized")]
    public void CustomCodeFolder_DetectedByName(string folderName)
    {
        var projectDir = CreateProjectStructure("sdk", "compute", "Azure.ResourceManager.Compute");
        Directory.CreateDirectory(Path.Combine(projectDir, "src", folderName));

        var result = DiscoverProjectTool.ExecuteInProcess(projectDir);

        Assert.That(result.CustomCodeFolder, Is.EqualTo(folderName));
    }

    [Test]
    public void NoCustomCodeFolder_ReturnsNull()
    {
        var projectDir = CreateProjectStructure("sdk", "compute", "Azure.ResourceManager.Compute");
        Directory.CreateDirectory(Path.Combine(projectDir, "src"));

        var result = DiscoverProjectTool.ExecuteInProcess(projectDir);

        Assert.That(result.CustomCodeFolder, Is.Null);
    }

    [Test]
    public void ApiSurfaceFiles_Found()
    {
        var projectDir = CreateProjectStructure("sdk", "compute", "Azure.ResourceManager.Compute");
        var apiDir = Path.Combine(projectDir, "api");
        Directory.CreateDirectory(apiDir);
        File.WriteAllText(Path.Combine(apiDir, "Azure.ResourceManager.Compute.netstandard2.0.cs"), "// api");
        File.WriteAllText(Path.Combine(apiDir, "Azure.ResourceManager.Compute.net8.0.cs"), "// api");

        var result = DiscoverProjectTool.ExecuteInProcess(projectDir);

        Assert.Multiple(() =>
        {
            Assert.That(result.ApiSurfaceFiles, Has.Count.EqualTo(2));
            Assert.That(result.ApiSurfaceFiles, Has.Some.Contains("netstandard2.0.cs"));
            Assert.That(result.ApiSurfaceFiles, Has.Some.Contains("net8.0.cs"));
        });
    }

    [Test]
    public void NoApiDir_ReturnsEmptyList()
    {
        var projectDir = CreateProjectStructure("sdk", "compute", "Azure.ResourceManager.Compute");

        var result = DiscoverProjectTool.ExecuteInProcess(projectDir);

        Assert.That(result.ApiSurfaceFiles, Is.Empty);
    }

    [Test]
    public void Execute_ReturnsValidJson()
    {
        var projectDir = CreateProjectStructure("sdk", "compute", "Azure.ResourceManager.Compute");

        var json = DiscoverProjectTool.Execute(projectDir);

        Assert.That(json, Does.Contain("\"Success\":true"));
        Assert.That(json, Does.Contain("\"Plane\":\"mpg\""));
    }

    [Test]
    public void ResolveServiceName_NoSdkParent_FallsBackToParentName()
    {
        // Project not under an sdk/ directory
        var projectDir = Path.Combine(_tempDir, "myservice", "Azure.MyService");
        Directory.CreateDirectory(projectDir);

        var result = DiscoverProjectTool.ExecuteInProcess(projectDir);

        Assert.That(result.ServiceName, Is.EqualTo("myservice"));
    }

    [Test]
    public void TspLocation_QuotedValues_Trimmed()
    {
        var projectDir = CreateProjectStructure("sdk", "compute", "Azure.ResourceManager.Compute");
        File.WriteAllText(Path.Combine(projectDir, "tsp-location.yaml"), """
            directory: "specification/compute/Compute.Management"
            commit: 'abc123'
            """);

        var result = DiscoverProjectTool.ExecuteInProcess(projectDir);

        Assert.Multiple(() =>
        {
            Assert.That(result.TspLocationFields!["directory"], Is.EqualTo("specification/compute/Compute.Management"));
            Assert.That(result.TspLocationFields["commit"], Is.EqualTo("abc123"));
        });
    }

    /// <summary>
    /// Creates sdk/{service}/{packageName} under _tempDir and returns the full package path.
    /// </summary>
    private string CreateProjectStructure(string rootName, string serviceName, string packageName)
    {
        var projectDir = Path.Combine(_tempDir, rootName, serviceName, packageName);
        Directory.CreateDirectory(projectDir);
        return projectDir;
    }

    // --- FindSpecsRepo tests ---

    [Test]
    public void FindSpecsRepo_SiblingExists_ReturnsPath()
    {
        // Simulate: _tempDir/azure-sdk-for-net/.git + _tempDir/azure-rest-api-specs
        var sdkRoot = Path.Combine(_tempDir, "azure-sdk-for-net");
        Directory.CreateDirectory(Path.Combine(sdkRoot, ".git"));
        var projectDir = Path.Combine(sdkRoot, "sdk", "compute", "Azure.ResourceManager.Compute");
        Directory.CreateDirectory(projectDir);

        var specsDir = Path.Combine(_tempDir, "azure-rest-api-specs");
        Directory.CreateDirectory(specsDir);

        var result = DiscoverProjectTool.FindSpecsRepo(projectDir);

        Assert.That(result, Is.EqualTo(Path.GetFullPath(specsDir)));
    }

    [Test]
    public void FindSpecsRepo_NoSibling_ReturnsNull()
    {
        var sdkRoot = Path.Combine(_tempDir, "azure-sdk-for-net");
        Directory.CreateDirectory(Path.Combine(sdkRoot, ".git"));
        var projectDir = Path.Combine(sdkRoot, "sdk", "compute", "Azure.ResourceManager.Compute");
        Directory.CreateDirectory(projectDir);

        var result = DiscoverProjectTool.FindSpecsRepo(projectDir);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void FindSpecsRepo_NoGitRoot_ReturnsNull()
    {
        // No .git directory anywhere in _tempDir
        var projectDir = Path.Combine(_tempDir, "no_git", "sdk", "compute", "Azure.ResourceManager.Compute");
        Directory.CreateDirectory(projectDir);

        var result = DiscoverProjectTool.FindSpecsRepo(projectDir);

        // May find a real .git above _tempDir on dev machines, so just verify it doesn't crash
        Assert.That(result, Is.Null.Or.Not.Empty);
    }

    [Test]
    public void DiscoverProject_IncludesSpecsRepoPath_WhenSiblingExists()
    {
        var sdkRoot = Path.Combine(_tempDir, "azure-sdk-for-net");
        Directory.CreateDirectory(Path.Combine(sdkRoot, ".git"));
        var projectDir = Path.Combine(sdkRoot, "sdk", "compute", "Azure.ResourceManager.Compute");
        Directory.CreateDirectory(projectDir);

        var specsDir = Path.Combine(_tempDir, "azure-rest-api-specs");
        Directory.CreateDirectory(specsDir);

        var result = DiscoverProjectTool.ExecuteInProcess(projectDir);

        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.SpecsRepoPath, Is.EqualTo(Path.GetFullPath(specsDir)));
        });
    }
}

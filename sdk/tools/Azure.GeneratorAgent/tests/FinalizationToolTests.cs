// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class FinalizationToolTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"FinalizationTests_{Guid.NewGuid():N}");
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

    // --- ResolveRepoPaths tests ---

    [Test]
    public void ResolveRepoPaths_ValidRepoStructure_ResolvesCorrectly()
    {
        // Create a mock repo root with eng/ and global.json
        Directory.CreateDirectory(Path.Combine(_tempDir, "eng"));
        File.WriteAllText(Path.Combine(_tempDir, "global.json"), "{}");

        // Create sdk/myservice/Azure.MyService
        var projectPath = Path.Combine(_tempDir, "sdk", "myservice", "Azure.MyService");
        Directory.CreateDirectory(projectPath);

        var (repoRoot, serviceDir) = FinalizationTool.ResolveRepoPaths(projectPath);

        Assert.Multiple(() =>
        {
            Assert.That(repoRoot, Is.EqualTo(_tempDir));
            Assert.That(serviceDir, Is.EqualTo("myservice"));
        });
    }

    [Test]
    public void ResolveRepoPaths_NoEngDir_ReturnsNull()
    {
        // No eng/ or global.json
        var projectPath = Path.Combine(_tempDir, "sdk", "compute", "Azure.Compute");
        Directory.CreateDirectory(projectPath);

        var (repoRoot, serviceDir) = FinalizationTool.ResolveRepoPaths(projectPath);

        Assert.Multiple(() =>
        {
            Assert.That(repoRoot, Is.Null);
            Assert.That(serviceDir, Is.Null);
        });
    }

    [Test]
    public void ResolveRepoPaths_ProjectNotUnderSdk_ReturnsNullServiceDir()
    {
        // Create repo root
        Directory.CreateDirectory(Path.Combine(_tempDir, "eng"));
        File.WriteAllText(Path.Combine(_tempDir, "global.json"), "{}");

        // Create a path NOT under sdk/
        var projectPath = Path.Combine(_tempDir, "other", "MyProject");
        Directory.CreateDirectory(projectPath);

        var (repoRoot, serviceDir) = FinalizationTool.ResolveRepoPaths(projectPath);

        Assert.Multiple(() =>
        {
            Assert.That(repoRoot, Is.EqualTo(_tempDir));
            Assert.That(serviceDir, Is.Null);
        });
    }

    [Test]
    public void ResolveRepoPaths_DeeplyNested_ResolvesCorrectly()
    {
        // Create repo root
        Directory.CreateDirectory(Path.Combine(_tempDir, "eng"));
        File.WriteAllText(Path.Combine(_tempDir, "global.json"), "{}");

        // Deep path under sdk
        var projectPath = Path.Combine(_tempDir, "sdk", "storage", "Azure.Storage.Blobs");
        Directory.CreateDirectory(projectPath);

        var (repoRoot, serviceDir) = FinalizationTool.ResolveRepoPaths(projectPath);

        Assert.Multiple(() =>
        {
            Assert.That(repoRoot, Is.EqualTo(_tempDir));
            Assert.That(serviceDir, Is.EqualTo("storage"));
        });
    }

    [Test]
    public async Task ExecuteInProcessAsync_NoRepoRoot_ReturnsError()
    {
        var projectPath = Path.Combine(_tempDir, "orphan");
        Directory.CreateDirectory(projectPath);

        var (success, _, error) = await FinalizationTool.ExecuteInProcessAsync(projectPath);

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.False);
            Assert.That(error, Does.Contain("Could not resolve"));
        });
    }

    [Test]
    public async Task ExecuteInProcessAsync_ScriptsMissing_SkipsGracefully()
    {
        // Create repo root without scripts
        Directory.CreateDirectory(Path.Combine(_tempDir, "eng"));
        File.WriteAllText(Path.Combine(_tempDir, "global.json"), "{}");

        var projectPath = Path.Combine(_tempDir, "sdk", "test", "Azure.Test");
        Directory.CreateDirectory(projectPath);

        var (success, output, error) = await FinalizationTool.ExecuteInProcessAsync(projectPath);

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(output, Does.Contain("not found"));
            Assert.That(error, Is.Null);
        });
    }
}

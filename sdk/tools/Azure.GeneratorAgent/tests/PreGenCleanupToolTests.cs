// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class PreGenCleanupToolTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"PreGenCleanupTests_{Guid.NewGuid():N}");
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
    public void ExecuteInProcess_RemovesIncludeAutorestDependency()
    {
        var srcDir = Path.Combine(_tempDir, "src");
        Directory.CreateDirectory(srcDir);

        var csprojPath = Path.Combine(srcDir, "TestProject.csproj");
        File.WriteAllText(csprojPath, """
            <Project Sdk="Microsoft.NET.Sdk">
              <PropertyGroup>
                <TargetFramework>net8.0</TargetFramework>
                <IncludeAutorestDependency>true</IncludeAutorestDependency>
              </PropertyGroup>
            </Project>
            """);

        var (success, filesModified, _) = PreGenCleanupTool.ExecuteInProcess(_tempDir);

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(filesModified, Is.EqualTo(1));
        });

        var content = File.ReadAllText(csprojPath);
        Assert.That(content, Does.Not.Contain("IncludeAutorestDependency"));
    }

    [Test]
    public void ExecuteInProcess_NoAutorestDependency_NoChanges()
    {
        var srcDir = Path.Combine(_tempDir, "src");
        Directory.CreateDirectory(srcDir);

        var csprojPath = Path.Combine(srcDir, "TestProject.csproj");
        File.WriteAllText(csprojPath, """
            <Project Sdk="Microsoft.NET.Sdk">
              <PropertyGroup>
                <TargetFramework>net8.0</TargetFramework>
              </PropertyGroup>
            </Project>
            """);

        var (success, filesModified, _) = PreGenCleanupTool.ExecuteInProcess(_tempDir);

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(filesModified, Is.EqualTo(0));
        });
    }

    [Test]
    public void ExecuteInProcess_NoCsprojFiles_NoChanges()
    {
        var srcDir = Path.Combine(_tempDir, "src");
        Directory.CreateDirectory(srcDir);

        var (success, filesModified, _) = PreGenCleanupTool.ExecuteInProcess(_tempDir);

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(filesModified, Is.EqualTo(0));
        });
    }

    [Test]
    public void ExecuteInProcess_NoSrcDir_ReturnsSuccessZero()
    {
        var (success, filesModified, _) = PreGenCleanupTool.ExecuteInProcess(Path.Combine(_tempDir, "subdir"));

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(filesModified, Is.EqualTo(0));
        });
    }

    [Test]
    public void ExecuteInProcess_MultipleCsproj_HandlesAll()
    {
        var srcDir = Path.Combine(_tempDir, "src");
        Directory.CreateDirectory(srcDir);

        var csproj1 = Path.Combine(srcDir, "Project1.csproj");
        var csproj2 = Path.Combine(srcDir, "Project2.csproj");

        var templateWithAutorest = """
            <Project Sdk="Microsoft.NET.Sdk">
              <PropertyGroup>
                <IncludeAutorestDependency>true</IncludeAutorestDependency>
              </PropertyGroup>
            </Project>
            """;

        File.WriteAllText(csproj1, templateWithAutorest);
        File.WriteAllText(csproj2, templateWithAutorest);

        var (success, filesModified, _) = PreGenCleanupTool.ExecuteInProcess(_tempDir);

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(filesModified, Is.EqualTo(2));
        });
    }
}

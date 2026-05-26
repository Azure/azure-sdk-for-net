// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class BuildAndClassifyToolTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"BuildAndClassifyTests_{Guid.NewGuid():N}");
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
    public async Task ExecuteInProcessAsync_SuccessfulBuild_ReturnsSuccess()
    {
        // Create a minimal .csproj that builds successfully
        File.WriteAllText(Path.Combine(_tempDir, "Test.csproj"), """
            <Project Sdk="Microsoft.NET.Sdk">
              <PropertyGroup>
                <TargetFramework>net10.0</TargetFramework>
              </PropertyGroup>
            </Project>
            """);
        File.WriteAllText(Path.Combine(_tempDir, "Program.cs"), """
            namespace Test;
            public class Program { }
            """);

        var (buildResult, classified) = await BuildAndClassifyTool.ExecuteInProcessAsync(_tempDir);

        Assert.Multiple(() =>
        {
            Assert.That(buildResult.Success, Is.True);
            Assert.That(buildResult.ExitCode, Is.EqualTo(0));
            Assert.That(buildResult.Errors, Is.Empty);
            Assert.That(classified, Is.Empty);
        });
    }

    [Test]
    public async Task ExecuteInProcessAsync_BuildWithErrors_ParsesAndClassifies()
    {
        // Create a .csproj that will have a compile error
        File.WriteAllText(Path.Combine(_tempDir, "Test.csproj"), """
            <Project Sdk="Microsoft.NET.Sdk">
              <PropertyGroup>
                <TargetFramework>net10.0</TargetFramework>
              </PropertyGroup>
            </Project>
            """);
        File.WriteAllText(Path.Combine(_tempDir, "Program.cs"), """
            namespace Test;
            public class Program
            {
                public void Method()
                {
                    HttpPipeline x = null;
                }
            }
            """);

        var (buildResult, classified) = await BuildAndClassifyTool.ExecuteInProcessAsync(_tempDir);

        Assert.Multiple(() =>
        {
            Assert.That(buildResult.Success, Is.False);
            Assert.That(buildResult.Errors, Is.Not.Empty);
            Assert.That(classified, Is.Not.Empty);
        });
    }

    [Test]
    public async Task ExecuteAsync_ReturnsValidJson()
    {
        // Create a minimal buildable project
        File.WriteAllText(Path.Combine(_tempDir, "Test.csproj"), """
            <Project Sdk="Microsoft.NET.Sdk">
              <PropertyGroup>
                <TargetFramework>net10.0</TargetFramework>
              </PropertyGroup>
            </Project>
            """);
        File.WriteAllText(Path.Combine(_tempDir, "Program.cs"), """
            namespace Test;
            public class Program { }
            """);

        var json = await BuildAndClassifyTool.ExecuteAsync(_tempDir);
        var result = JsonSerializer.Deserialize<JsonElement>(json);

        Assert.Multiple(() =>
        {
            Assert.That(result.GetProperty("success").GetBoolean(), Is.True);
            Assert.That(result.GetProperty("exitCode").GetInt32(), Is.EqualTo(0));
            Assert.That(result.GetProperty("totalErrors").GetInt32(), Is.EqualTo(0));
            Assert.That(result.GetProperty("deterministicCount").GetInt32(), Is.EqualTo(0));
            Assert.That(result.GetProperty("requiresReasoningCount").GetInt32(), Is.EqualTo(0));
        });
    }

    [Test]
    public async Task ExecuteAsync_NonExistentProject_ReturnsFailure()
    {
        var nonExistent = Path.Combine(_tempDir, "does_not_exist");
        Directory.CreateDirectory(nonExistent);

        // No .csproj file, dotnet build will fail
        var json = await BuildAndClassifyTool.ExecuteAsync(nonExistent);
        var result = JsonSerializer.Deserialize<JsonElement>(json);

        // Build should fail (no project file found)
        Assert.That(result.GetProperty("success").GetBoolean(), Is.False);
    }
}

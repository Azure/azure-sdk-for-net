// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class SampleMigrationToolTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"SampleMigrationTests_{Guid.NewGuid():N}");
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
    public void ExecuteInProcess_MovesSampleFiles()
    {
        // Create source: tests/Generated/Samples/
        var generatedSamplesDir = Path.Combine(_tempDir, "tests", "Generated", "Samples");
        Directory.CreateDirectory(generatedSamplesDir);
        File.WriteAllText(Path.Combine(generatedSamplesDir, "Sample1.cs"), "// sample 1");
        File.WriteAllText(Path.Combine(generatedSamplesDir, "Sample2.cs"), "// sample 2");

        // Create target dir
        var samplesDir = Path.Combine(_tempDir, "tests", "Samples");
        Directory.CreateDirectory(samplesDir);

        var (success, filesMoved, _) = SampleMigrationTool.ExecuteInProcess(_tempDir);

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(filesMoved, Is.EqualTo(2));
            Assert.That(File.Exists(Path.Combine(samplesDir, "Sample1.cs")), Is.True);
            Assert.That(File.Exists(Path.Combine(samplesDir, "Sample2.cs")), Is.True);
        });
    }

    [Test]
    public void ExecuteInProcess_NoGeneratedSamplesDir_NoChanges()
    {
        var testsDir = Path.Combine(_tempDir, "tests");
        Directory.CreateDirectory(testsDir);

        var (success, filesMoved, _) = SampleMigrationTool.ExecuteInProcess(_tempDir);

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(filesMoved, Is.EqualTo(0));
        });
    }

    [Test]
    public void ExecuteInProcess_CreatesTargetDirIfMissing()
    {
        var generatedSamplesDir = Path.Combine(_tempDir, "tests", "Generated", "Samples");
        Directory.CreateDirectory(generatedSamplesDir);
        File.WriteAllText(Path.Combine(generatedSamplesDir, "Sample.cs"), "// sample");

        var (success, filesMoved, _) = SampleMigrationTool.ExecuteInProcess(_tempDir);

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(filesMoved, Is.EqualTo(1));
            Assert.That(Directory.Exists(Path.Combine(_tempDir, "tests", "Samples")), Is.True);
        });
    }

    [Test]
    public void ExecuteInProcess_NoProjectDir_ReturnsSuccessZero()
    {
        var (success, filesMoved, _) = SampleMigrationTool.ExecuteInProcess(Path.Combine(_tempDir, "nonexistent"));

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(filesMoved, Is.EqualTo(0));
        });
    }
}

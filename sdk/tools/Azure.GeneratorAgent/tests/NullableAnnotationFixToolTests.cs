// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class NullableAnnotationFixToolTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"NullableFixTests_{Guid.NewGuid():N}");
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
    public void ExecuteInProcess_AddsNullableAnnotation()
    {
        var file = CreateTempFile("""
            public class MyClass
            {
                public string GetName()
                {
                    String value = null;
                    return value;
                }
            }
            """);

        var (success, modified, error) = NullableAnnotationFixTool.ExecuteInProcess(file, "5");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(modified, Is.True);

            var lines = File.ReadAllLines(file);
            Assert.That(lines[4], Does.Contain("String?"));
        });
    }

    [Test]
    public void ExecuteInProcess_AlreadyNullable_NoChange()
    {
        var file = CreateTempFile("""
            public class MyClass
            {
                public string? GetName()
                {
                    String? value = null;
                    return value;
                }
            }
            """);

        var (success, modified, error) = NullableAnnotationFixTool.ExecuteInProcess(file, "5");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(modified, Is.False);
        });
    }

    [Test]
    public void ExecuteInProcess_InvalidLine_ReturnsFalse()
    {
        var file = CreateTempFile("one line");
        var (success, modified, error) = NullableAnnotationFixTool.ExecuteInProcess(file, "0");

        Assert.That(success, Is.False);
        Assert.That(error, Does.Contain("Invalid line"));
    }

    [Test]
    public void ExecuteInProcess_LineExceedsFile_ReturnsFalse()
    {
        var file = CreateTempFile("one line");
        var (success, modified, error) = NullableAnnotationFixTool.ExecuteInProcess(file, "999");

        Assert.That(success, Is.False);
        Assert.That(error, Does.Contain("exceeds file length"));
    }

    [Test]
    public void ExecuteInProcess_FileNotFound_ReturnsFalse()
    {
        var (success, modified, error) = NullableAnnotationFixTool.ExecuteInProcess(
            Path.Combine(_tempDir, "nonexistent.cs"), "1");

        Assert.That(success, Is.False);
        Assert.That(error, Does.Contain("File not found"));
    }

    [Test]
    public void ExecuteInProcess_NonStringLine_NoMatch()
    {
        var file = CreateTempFile("""
            // just a comment
            """);

        var (success, modified, error) = NullableAnnotationFixTool.ExecuteInProcess(file, "1");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(modified, Is.False);
        });
    }

    [Test]
    public void ExecuteInProcess_LowercaseKeywordType_FixesNullable()
    {
        var file = CreateTempFile("    string value = null;");

        var (success, modified, error) = NullableAnnotationFixTool.ExecuteInProcess(file, "1");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(modified, Is.True);
        });

        var result = File.ReadAllText(file);
        Assert.That(result, Does.Contain("string?"));
    }

    private string CreateTempFile(string content)
    {
        var path = Path.Combine(_tempDir, $"{Guid.NewGuid():N}.cs");
        File.WriteAllText(path, content);
        return path;
    }

    private string CreateGeneratedFile(string content)
    {
        var genDir = Path.Combine(_tempDir, "Generated");
        Directory.CreateDirectory(genDir);
        var path = Path.Combine(genDir, $"{Guid.NewGuid():N}.cs");
        File.WriteAllText(path, content);
        return path;
    }

    [Test]
    public void ExecuteInProcess_GeneratedFile_Blocked()
    {
        var file = CreateGeneratedFile("    string value = null;");
        var originalContent = File.ReadAllText(file);

        var (success, modified, error) = NullableAnnotationFixTool.ExecuteInProcess(file, "1");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.False);
            Assert.That(modified, Is.False);
            Assert.That(error, Does.Contain("Refusing to modify"));
            Assert.That(File.ReadAllText(file), Is.EqualTo(originalContent), "File must remain unmodified");
        });
    }
}

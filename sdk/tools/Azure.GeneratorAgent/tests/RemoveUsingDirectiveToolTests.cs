// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class RemoveUsingDirectiveToolTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"RemoveUsingTests_{Guid.NewGuid():N}");
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
    public void ExecuteInProcess_RemovesMatchingUsing()
    {
        var file = CreateTempFile("""
            using System;
            using MyService.Rest;
            using System.Collections.Generic;

            namespace MyNamespace;
            """);

        var (success, count, error) = RemoveUsingDirectiveTool.ExecuteInProcess(file, @"MyService\.Rest");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(count, Is.EqualTo(1));

            var content = File.ReadAllText(file);
            Assert.That(content, Does.Not.Contain("MyService.Rest"));
            Assert.That(content, Does.Contain("using System;"));
            Assert.That(content, Does.Contain("using System.Collections.Generic;"));
        });
    }

    [Test]
    public void ExecuteInProcess_NoMatch_ReturnsZero()
    {
        var file = CreateTempFile("""
            using System;
            using Azure;

            namespace MyNamespace;
            """);

        var (success, count, error) = RemoveUsingDirectiveTool.ExecuteInProcess(file, @"MyService\.Rest");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(count, Is.EqualTo(0));
        });
    }

    [Test]
    public void ExecuteInProcess_MultipleRestUsings_RemovesAll()
    {
        var file = CreateTempFile("""
            using System;
            using MyService.Rest;
            using MyService.Models.Rest;

            namespace MyNamespace;
            """);

        var (success, count, error) = RemoveUsingDirectiveTool.ExecuteInProcess(file, @"[\w.]+\.Rest");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(count, Is.GreaterThanOrEqualTo(1));

            var content = File.ReadAllText(file);
            Assert.That(content, Does.Not.Contain(".Rest"));
        });
    }

    [Test]
    public void ExecuteInProcess_FileNotFound_ReturnsFalse()
    {
        var (success, count, error) = RemoveUsingDirectiveTool.ExecuteInProcess(
            Path.Combine(_tempDir, "nonexistent.cs"), @"Foo\.Rest");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.False);
            Assert.That(error, Does.Contain("File not found"));
        });
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
        var file = CreateGeneratedFile("""
            using System;
            using MyService.Rest;

            namespace MyNamespace;
            """);
        var originalContent = File.ReadAllText(file);

        var (success, count, error) = RemoveUsingDirectiveTool.ExecuteInProcess(file, @"MyService\.Rest");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.False);
            Assert.That(count, Is.EqualTo(0));
            Assert.That(error, Does.Contain("Refusing to modify"));
            Assert.That(File.ReadAllText(file), Is.EqualTo(originalContent), "File must remain unmodified");
        });
    }
}

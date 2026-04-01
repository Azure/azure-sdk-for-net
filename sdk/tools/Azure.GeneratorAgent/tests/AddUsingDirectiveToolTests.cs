// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class AddUsingDirectiveToolTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"AddUsingTests_{Guid.NewGuid():N}");
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
    public void ExecuteInProcess_AddsUsing_AfterExistingUsings()
    {
        var file = CreateTempFile("""
            using System;
            using System.Collections.Generic;

            namespace MyNamespace;
            """);

        var (success, added, error) = AddUsingDirectiveTool.ExecuteInProcess(file, "Azure.Core.Pipeline");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(added, Is.True);
            Assert.That(error, Is.Null);

            var content = File.ReadAllText(file);
            Assert.That(content, Does.Contain("using Azure.Core.Pipeline;"));
        });
    }

    [Test]
    public void ExecuteInProcess_AlreadyPresent_DoesNotDuplicate()
    {
        var file = CreateTempFile("""
            using System;
            using Azure.Core.Pipeline;

            namespace MyNamespace;
            """);

        var (success, added, error) = AddUsingDirectiveTool.ExecuteInProcess(file, "Azure.Core.Pipeline");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(added, Is.False);
        });
    }

    [Test]
    public void ExecuteInProcess_NoExistingUsings_AddsAfterCopyrightHeader()
    {
        var file = CreateTempFile("""
            // Copyright (c) Microsoft Corporation. All rights reserved.
            // Licensed under the MIT License.

            namespace MyNamespace;
            """);

        var (success, added, error) = AddUsingDirectiveTool.ExecuteInProcess(file, "Azure");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(added, Is.True);

            var content = File.ReadAllText(file);
            Assert.That(content, Does.Contain("using Azure;"));
        });
    }

    [Test]
    public void ExecuteInProcess_FileNotFound_ReturnsFalse()
    {
        var (success, added, error) = AddUsingDirectiveTool.ExecuteInProcess(
            Path.Combine(_tempDir, "nonexistent.cs"), "Azure");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.False);
            Assert.That(error, Does.Contain("File not found"));
        });
    }

    [TestCase("Azure.Core.Pipeline")]
    [TestCase("System.ClientModel")]
    [TestCase("Azure.ResourceManager")]
    public void ExecuteInProcess_VariousNamespaces_AllSucceed(string ns)
    {
        var file = CreateTempFile("""
            using System;

            namespace MyNamespace;
            """);

        var (success, added, error) = AddUsingDirectiveTool.ExecuteInProcess(file, ns);

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(added, Is.True);
            Assert.That(File.ReadAllText(file), Does.Contain($"using {ns};"));
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

            namespace MyNamespace;
            """);
        var originalContent = File.ReadAllText(file);

        var (success, added, error) = AddUsingDirectiveTool.ExecuteInProcess(file, "Azure.Core.Pipeline");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.False);
            Assert.That(added, Is.False);
            Assert.That(error, Does.Contain("Refusing to modify"));
            Assert.That(File.ReadAllText(file), Is.EqualTo(originalContent), "File must remain unmodified");
        });
    }
}

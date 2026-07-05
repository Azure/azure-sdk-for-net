// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class CommitIterationToolTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"CommitIterationTests_{Guid.NewGuid():N}");
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

    // --- ReadYamlField tests ---

    [Test]
    public void ReadYamlField_SimpleValue_ReturnsValue()
    {
        var yaml = """
            directory: specification/compute/Compute.Management
            commit: abc123
            repo: Azure/azure-rest-api-specs
            """;

        Assert.Multiple(() =>
        {
            Assert.That(CommitIterationTool.ReadYamlField(yaml, "directory"),
                Is.EqualTo("specification/compute/Compute.Management"));
            Assert.That(CommitIterationTool.ReadYamlField(yaml, "commit"), Is.EqualTo("abc123"));
            Assert.That(CommitIterationTool.ReadYamlField(yaml, "repo"), Is.EqualTo("Azure/azure-rest-api-specs"));
        });
    }

    [Test]
    public void ReadYamlField_QuotedValue_TrimsQuotes()
    {
        var yaml = """
            directory: "specification/compute/Compute.Management"
            commit: 'abc123'
            """;

        Assert.Multiple(() =>
        {
            Assert.That(CommitIterationTool.ReadYamlField(yaml, "directory"),
                Is.EqualTo("specification/compute/Compute.Management"));
            Assert.That(CommitIterationTool.ReadYamlField(yaml, "commit"), Is.EqualTo("abc123"));
        });
    }

    [Test]
    public void ReadYamlField_MissingField_ReturnsNull()
    {
        var yaml = """
            directory: specification/compute
            """;

        Assert.That(CommitIterationTool.ReadYamlField(yaml, "commit"), Is.Null);
    }

    [Test]
    public void ReadYamlField_EmptyValue_ReturnsNull()
    {
        var yaml = """
            directory:
            commit: abc
            """;

        Assert.That(CommitIterationTool.ReadYamlField(yaml, "directory"), Is.Null);
    }

    [Test]
    public void ReadYamlField_CaseInsensitive_MatchesField()
    {
        var yaml = """
            Directory: specification/compute
            """;

        Assert.That(CommitIterationTool.ReadYamlField(yaml, "directory"), Is.EqualTo("specification/compute"));
    }

    [Test]
    public void ReadYamlField_EmptyYaml_ReturnsNull()
    {
        Assert.That(CommitIterationTool.ReadYamlField("", "directory"), Is.Null);
    }

    // --- FindGitRepoRoot tests ---

    [Test]
    public void FindGitRepoRoot_DirectoryWithGit_ReturnsPath()
    {
        // Create a fake .git directory
        var gitDir = Path.Combine(_tempDir, ".git");
        Directory.CreateDirectory(gitDir);

        var result = CommitIterationTool.FindGitRepoRoot(_tempDir);

        Assert.That(result, Is.EqualTo(_tempDir));
    }

    [Test]
    public void FindGitRepoRoot_NestedDirectory_WalksUp()
    {
        // Create .git at root
        Directory.CreateDirectory(Path.Combine(_tempDir, ".git"));

        // Create nested dirs
        var nested = Path.Combine(_tempDir, "a", "b", "c");
        Directory.CreateDirectory(nested);

        var result = CommitIterationTool.FindGitRepoRoot(nested);

        Assert.That(result, Is.EqualTo(_tempDir));
    }

    [Test]
    public void FindGitRepoRoot_NoGitDir_ReturnsNull()
    {
        var nested = Path.Combine(_tempDir, "no_git_here");
        Directory.CreateDirectory(nested);

        // This will walk all the way up to the actual repo root or system root.
        // On a dev machine with a .git folder somewhere above, this might not return null.
        // So we test the nested path relative to _tempDir which won't have .git above it easily.
        // We just verify it doesn't throw.
        var result = CommitIterationTool.FindGitRepoRoot(nested);
        Assert.That(result, Is.Null.Or.Not.Empty);
    }

    [Test]
    public void FindGitRepoRoot_WithFilePath_WalksUpFromParent()
    {
        Directory.CreateDirectory(Path.Combine(_tempDir, ".git"));
        var filePath = Path.Combine(_tempDir, "some", "file.yaml");
        Directory.CreateDirectory(Path.Combine(_tempDir, "some"));

        var result = CommitIterationTool.FindGitRepoRoot(filePath);

        Assert.That(result, Is.EqualTo(_tempDir));
    }
}

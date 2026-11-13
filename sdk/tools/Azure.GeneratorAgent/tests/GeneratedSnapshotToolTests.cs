// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class GeneratedSnapshotToolTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"SnapshotTests_{Guid.NewGuid():N}");
        Directory.CreateDirectory(_tempDir);
    }

    [TearDown]
    public void TearDown()
    {
        GeneratedSnapshotTool.ClearSnapshot(_tempDir);
        if (Directory.Exists(_tempDir))
        {
            Directory.Delete(_tempDir, true);
        }
    }

    // ── Snapshot tests ───────────────────────────────────────────────────

    [Test]
    public void TakeSnapshot_NoGeneratedDirectory_ReturnsZeroFiles()
    {
        var result = GeneratedSnapshotTool.TakeSnapshotInProcess(_tempDir);

        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.FileCount, Is.EqualTo(0));
            Assert.That(result.Message, Does.Contain("No Generated/"));
        });
    }

    [Test]
    public void TakeSnapshot_WithGeneratedFiles_RecordsAllFiles()
    {
        CreateGeneratedStructure(("Models/MyModel.cs", "public class MyModel {}"),
                                 ("MyClient.cs", "public class MyClient {}"));

        var result = GeneratedSnapshotTool.TakeSnapshotInProcess(_tempDir);

        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.FileCount, Is.EqualTo(2));
            Assert.That(result.Message, Is.Null);
        });
    }

    [Test]
    public void TakeSnapshot_OverwritesPreviousSnapshot()
    {
        CreateGeneratedStructure(("A.cs", "class A {}"));
        GeneratedSnapshotTool.TakeSnapshotInProcess(_tempDir);

        // Add another file and re-snapshot
        CreateGeneratedFile("B.cs", "class B {}");
        var result = GeneratedSnapshotTool.TakeSnapshotInProcess(_tempDir);

        Assert.That(result.FileCount, Is.EqualTo(2));
    }

    // ── Verify: no violations ────────────────────────────────────────────

    [Test]
    public void Verify_NoChanges_ReportsClean()
    {
        CreateGeneratedStructure(("Model.cs", "public class Model {}"));
        GeneratedSnapshotTool.TakeSnapshotInProcess(_tempDir);

        var result = GeneratedSnapshotTool.VerifyInProcess(_tempDir, autoRevert: false);

        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.HasViolations, Is.False);
            Assert.That(result.Violations, Is.Empty);
            Assert.That(result.Message, Does.Contain("unchanged"));
        });
    }

    [Test]
    public void Verify_NoSnapshot_ReportsNoSnapshot()
    {
        var result = GeneratedSnapshotTool.VerifyInProcess(_tempDir, autoRevert: false);

        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.HasViolations, Is.False);
            Assert.That(result.Message, Does.Contain("No snapshot found"));
        });
    }

    // ── Verify: modified file ────────────────────────────────────────────

    [Test]
    public void Verify_ModifiedFile_ReportsViolation()
    {
        CreateGeneratedStructure(("Model.cs", "public class Model {}"));
        GeneratedSnapshotTool.TakeSnapshotInProcess(_tempDir);

        // Tamper with the generated file
        var generatedFile = Path.Combine(_tempDir, "src", "Generated", "Model.cs");
        File.WriteAllText(generatedFile, "public class Model { /* tampered */ }");

        var result = GeneratedSnapshotTool.VerifyInProcess(_tempDir, autoRevert: false);

        Assert.Multiple(() =>
        {
            Assert.That(result.HasViolations, Is.True);
            Assert.That(result.Violations, Has.Count.EqualTo(1));
            Assert.That(result.Violations[0].RelativePath, Does.Contain("Model.cs"));
            Assert.That(result.Violations[0].Type.ToString(), Is.EqualTo("Modified"));
        });
    }

    // ── Verify: deleted file ─────────────────────────────────────────────

    [Test]
    public void Verify_DeletedFile_ReportsViolation()
    {
        CreateGeneratedStructure(("Model.cs", "public class Model {}"));
        GeneratedSnapshotTool.TakeSnapshotInProcess(_tempDir);

        File.Delete(Path.Combine(_tempDir, "src", "Generated", "Model.cs"));

        var result = GeneratedSnapshotTool.VerifyInProcess(_tempDir, autoRevert: false);

        Assert.Multiple(() =>
        {
            Assert.That(result.HasViolations, Is.True);
            Assert.That(result.Violations, Has.Count.EqualTo(1));
            Assert.That(result.Violations[0].Type.ToString(), Is.EqualTo("Deleted"));
        });
    }

    // ── Verify: added file ───────────────────────────────────────────────

    [Test]
    public void Verify_NewFileAdded_ReportsViolation()
    {
        CreateGeneratedStructure(("Model.cs", "public class Model {}"));
        GeneratedSnapshotTool.TakeSnapshotInProcess(_tempDir);

        // Add a new file to Generated/
        CreateGeneratedFile("Rogue.cs", "public class Rogue {}");

        var result = GeneratedSnapshotTool.VerifyInProcess(_tempDir, autoRevert: false);

        Assert.Multiple(() =>
        {
            Assert.That(result.HasViolations, Is.True);
            Assert.That(result.Violations.Any(v => v.RelativePath.Contains("Rogue.cs")), Is.True);
            Assert.That(result.Violations.Any(v => v.Type.ToString() == "Added"), Is.True);
        });
    }

    // ── Verify: multiple violations ──────────────────────────────────────

    [Test]
    public void Verify_MultipleViolations_ReportsAll()
    {
        CreateGeneratedStructure(("A.cs", "class A {}"),
                                 ("B.cs", "class B {}"),
                                 ("C.cs", "class C {}"));
        GeneratedSnapshotTool.TakeSnapshotInProcess(_tempDir);

        // Modify one, delete another, add a new one
        File.WriteAllText(Path.Combine(_tempDir, "src", "Generated", "A.cs"), "class A { /* changed */ }");
        File.Delete(Path.Combine(_tempDir, "src", "Generated", "B.cs"));
        CreateGeneratedFile("D.cs", "class D {}");

        var result = GeneratedSnapshotTool.VerifyInProcess(_tempDir, autoRevert: false);

        Assert.Multiple(() =>
        {
            Assert.That(result.HasViolations, Is.True);
            Assert.That(result.Violations, Has.Count.EqualTo(3));
            Assert.That(result.Message, Does.Contain("3 violation(s)"));
        });
    }

    // ── Verify: unchanged file content is byte-identical ─────────────────

    [Test]
    public void Verify_IdenticalRewrite_NoViolation()
    {
        var content = "public class Model {}";
        CreateGeneratedStructure(("Model.cs", content));
        GeneratedSnapshotTool.TakeSnapshotInProcess(_tempDir);

        // Re-write the same content — should be hash-identical
        File.WriteAllText(Path.Combine(_tempDir, "src", "Generated", "Model.cs"), content);

        var result = GeneratedSnapshotTool.VerifyInProcess(_tempDir, autoRevert: false);
        Assert.That(result.HasViolations, Is.False);
    }

    // ── HasSnapshot / ClearSnapshot ──────────────────────────────────────

    [Test]
    public void HasSnapshot_ReturnsFalse_WhenNoSnapshot()
    {
        Assert.That(GeneratedSnapshotTool.HasSnapshot(_tempDir), Is.False);
    }

    [Test]
    public void HasSnapshot_ReturnsTrue_AfterTakingSnapshot()
    {
        CreateGeneratedStructure(("A.cs", "class A {}"));
        GeneratedSnapshotTool.TakeSnapshotInProcess(_tempDir);

        Assert.That(GeneratedSnapshotTool.HasSnapshot(_tempDir), Is.True);
    }

    [Test]
    public void ClearSnapshot_RemovesSnapshot()
    {
        CreateGeneratedStructure(("A.cs", "class A {}"));
        GeneratedSnapshotTool.TakeSnapshotInProcess(_tempDir);

        GeneratedSnapshotTool.ClearSnapshot(_tempDir);

        Assert.That(GeneratedSnapshotTool.HasSnapshot(_tempDir), Is.False);
    }

    // ── Non-cs files are also tracked ────────────────────────────────────

    [Test]
    public void TakeSnapshot_TracksAllFileTypes()
    {
        var genDir = Path.Combine(_tempDir, "src", "Generated");
        Directory.CreateDirectory(genDir);
        File.WriteAllText(Path.Combine(genDir, "Model.cs"), "class Model {}");
        File.WriteAllText(Path.Combine(genDir, "data.json"), "{}");

        var result = GeneratedSnapshotTool.TakeSnapshotInProcess(_tempDir);
        Assert.That(result.FileCount, Is.EqualTo(2));
    }

    // ── Helpers ──────────────────────────────────────────────────────────

    private void CreateGeneratedStructure(params (string relativePath, string content)[] files)
    {
        foreach (var (relativePath, content) in files)
        {
            CreateGeneratedFile(relativePath, content);
        }
    }

    private void CreateGeneratedFile(string relativePath, string content)
    {
        var fullPath = Path.Combine(_tempDir, "src", "Generated", relativePath);
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
        File.WriteAllText(fullPath, content);
    }
}

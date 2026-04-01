// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class RegexReplacementToolTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"RegexReplacementTests_{Guid.NewGuid():N}");
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
    public void ExecuteInProcess_FieldRename_ReplacesCorrectly()
    {
        var file = CreateTempFile("var x = _pipeline.Send(request);");
        var (success, count, error) = RegexReplacementTool.ExecuteInProcess(file, @"\b_pipeline\b", "Pipeline");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(count, Is.EqualTo(1));
            Assert.That(error, Is.Null);
            Assert.That(File.ReadAllText(file), Is.EqualTo("var x = Pipeline.Send(request);"));
        });
    }

    [Test]
    public void ExecuteInProcess_MultipleOccurrences_ReplacesAll()
    {
        var file = CreateTempFile("_endpoint = uri;\nvar url = _endpoint + path;");
        var (success, count, error) = RegexReplacementTool.ExecuteInProcess(file, @"\b_endpoint\b", "Endpoint");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(count, Is.EqualTo(2));
            Assert.That(File.ReadAllText(file), Does.Contain("Endpoint = uri;"));
            Assert.That(File.ReadAllText(file), Does.Contain("var url = Endpoint + path;"));
        });
    }

    [Test]
    public void ExecuteInProcess_NoMatch_NoChanges()
    {
        var content = "var x = Pipeline.Send(request);";
        var file = CreateTempFile(content);
        var (success, count, error) = RegexReplacementTool.ExecuteInProcess(file, @"\b_pipeline\b", "Pipeline");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(count, Is.EqualTo(0));
            Assert.That(File.ReadAllText(file), Is.EqualTo(content));
        });
    }

    [Test]
    public void ExecuteInProcess_ResponseWithHeaders_ReplacesWithCaptureGroup()
    {
        var file = CreateTempFile("public ResponseWithHeaders<MyResponse, MyHeaders> DoSomething()");
        var (success, count, error) = RegexReplacementTool.ExecuteInProcess(
            file,
            @"ResponseWithHeaders<([^,>]+),\s*[^>]+>",
            "Response<$1>");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(count, Is.EqualTo(1));
            Assert.That(File.ReadAllText(file), Is.EqualTo("public Response<MyResponse> DoSomething()"));
        });
    }

    [Test]
    public void ExecuteInProcess_DuplicateModelsNamespace_Fixes()
    {
        var file = CreateTempFile("var model = new Models.Models.SomeModel();");
        var (success, count, error) = RegexReplacementTool.ExecuteInProcess(file, @"Models\.Models\.", "Models.");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(count, Is.EqualTo(1));
            Assert.That(File.ReadAllText(file), Is.EqualTo("var model = new Models.SomeModel();"));
        });
    }

    [Test]
    public void ExecuteInProcess_RestNamespacePrefix_Removes()
    {
        var file = CreateTempFile("var client = new Rest.SomeClient();");
        var (success, count, error) = RegexReplacementTool.ExecuteInProcess(file, @"(?<!\w)Rest\.(\w+)", "$1");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(count, Is.EqualTo(1));
            Assert.That(File.ReadAllText(file), Is.EqualTo("var client = new SomeClient();"));
        });
    }

    [Test]
    public void ExecuteInProcess_FileNotFound_ReturnsFalse()
    {
        var (success, count, error) = RegexReplacementTool.ExecuteInProcess(
            Path.Combine(_tempDir, "nonexistent.cs"), @"\b_pipeline\b", "Pipeline");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.False);
            Assert.That(error, Does.Contain("File not found"));
        });
    }

    [Test]
    public void ExecuteInProcess_SingleLineMode_MatchesCrossLinePattern()
    {
        var content = """
            [CodeGenSerialization(nameof(Id),
                DeserializationValueHook = nameof(ReadId))]
            public partial class MyModel
            {
            }
            """;
        var file = CreateTempFile(content);
        // In Singleline mode, .* matches across newlines
        var (success, count, error) = RegexReplacementTool.ExecuteInProcess(
            file,
            @"\[CodeGenSerialization\([^\]]*\)\]\s*\r?\n",
            "",
            singleLine: true);

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(count, Is.EqualTo(1));
            var result = File.ReadAllText(file);
            Assert.That(result, Does.Not.Contain("CodeGenSerialization"));
            Assert.That(result, Does.Contain("public partial class MyModel"));
        });
    }

    [Test]
    public void ExecuteInProcess_DefaultMode_DoesNotMatchCrossLine()
    {
        var content = "[Attr(\n    arg)]\nclass Foo {}";
        var file = CreateTempFile(content);
        // Without singleLine, .* does NOT match newlines
        var (success, count, error) = RegexReplacementTool.ExecuteInProcess(
            file, @"\[Attr\(.*\)\]", "");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(count, Is.EqualTo(0)); // No match — pattern doesn't span lines
            Assert.That(File.ReadAllText(file), Is.EqualTo(content));
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
        var file = CreateGeneratedFile("var x = _pipeline.Send(request);");
        var (success, count, error) = RegexReplacementTool.ExecuteInProcess(file, @"\b_pipeline\b", "Pipeline");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.False);
            Assert.That(count, Is.EqualTo(0));
            Assert.That(error, Does.Contain("Refusing to modify"));
            Assert.That(File.ReadAllText(file), Does.Contain("_pipeline"), "File must remain unmodified");
        });
    }
}

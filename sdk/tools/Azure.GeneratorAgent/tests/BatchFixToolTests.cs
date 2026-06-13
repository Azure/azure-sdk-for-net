// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class BatchFixToolTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"BatchFixTests_{Guid.NewGuid():N}");
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
    public void ExecuteInProcess_EmptyList_ReturnsEmpty()
    {
        var results = BatchFixTool.ExecuteInProcess([]);

        Assert.That(results, Is.Empty);
    }

    [Test]
    public void ExecuteInProcess_RegexReplacement_AppliesFix()
    {
        var file = Path.Combine(_tempDir, "Test.cs");
        File.WriteAllText(file, "var x = _pipeline.Send(request);");

        var fixes = new List<FixOperation>
        {
            new()
            {
                ToolName = "regex_replacement",
                ToolArgs = new Dictionary<string, string>
                {
                    ["filePath"] = file,
                    ["pattern"] = @"\b_pipeline\b",
                    ["replacement"] = "Pipeline"
                }
            }
        };

        var results = BatchFixTool.ExecuteInProcess(fixes);

        Assert.Multiple(() =>
        {
            Assert.That(results, Has.Count.EqualTo(1));
            Assert.That(results[0].Success, Is.True);
            Assert.That(results[0].Tool, Is.EqualTo("regex_replacement"));
            Assert.That(File.ReadAllText(file), Is.EqualTo("var x = Pipeline.Send(request);"));
        });
    }

    [Test]
    public void ExecuteInProcess_AddUsingDirective_AppliesFix()
    {
        var file = Path.Combine(_tempDir, "Test.cs");
        File.WriteAllText(file, """
            using System;

            namespace MyNamespace;
            """);

        var fixes = new List<FixOperation>
        {
            new()
            {
                ToolName = "add_using_directive",
                ToolArgs = new Dictionary<string, string>
                {
                    ["filePath"] = file,
                    ["namespace"] = "Azure.Core"
                }
            }
        };

        var results = BatchFixTool.ExecuteInProcess(fixes);

        Assert.Multiple(() =>
        {
            Assert.That(results, Has.Count.EqualTo(1));
            Assert.That(results[0].Success, Is.True);
            Assert.That(File.ReadAllText(file), Does.Contain("using Azure.Core;"));
        });
    }

    [Test]
    public void ExecuteInProcess_RemoveUsingDirective_AppliesFix()
    {
        var file = Path.Combine(_tempDir, "Test.cs");
        File.WriteAllText(file, """
            using System;
            using MyService.Rest;

            namespace MyNamespace;
            """);

        var fixes = new List<FixOperation>
        {
            new()
            {
                ToolName = "remove_using_directive",
                ToolArgs = new Dictionary<string, string>
                {
                    ["filePath"] = file,
                    ["namespacePattern"] = @"MyService\.Rest"
                }
            }
        };

        var results = BatchFixTool.ExecuteInProcess(fixes);

        Assert.Multiple(() =>
        {
            Assert.That(results, Has.Count.EqualTo(1));
            Assert.That(results[0].Success, Is.True);
            Assert.That(File.ReadAllText(file), Does.Not.Contain("MyService.Rest"));
        });
    }

    [Test]
    public void ExecuteInProcess_NullableAnnotationFix_AppliesFix()
    {
        var file = Path.Combine(_tempDir, "Test.cs");
        File.WriteAllText(file, """
            public class MyClass
            {
                public String GetName()
                {
                    String value = null;
                    return value;
                }
            }
            """);

        var fixes = new List<FixOperation>
        {
            new()
            {
                ToolName = "nullable_annotation_fix",
                ToolArgs = new Dictionary<string, string>
                {
                    ["filePath"] = file,
                    ["line"] = "5"
                }
            }
        };

        var results = BatchFixTool.ExecuteInProcess(fixes);

        Assert.Multiple(() =>
        {
            Assert.That(results, Has.Count.EqualTo(1));
            Assert.That(results[0].Success, Is.True);
        });
    }

    [Test]
    public void ExecuteInProcess_UnknownTool_ReturnsFailure()
    {
        var fixes = new List<FixOperation>
        {
            new()
            {
                ToolName = "nonexistent_tool",
                ToolArgs = new Dictionary<string, string>()
            }
        };

        var results = BatchFixTool.ExecuteInProcess(fixes);

        Assert.Multiple(() =>
        {
            Assert.That(results, Has.Count.EqualTo(1));
            Assert.That(results[0].Success, Is.False);
            Assert.That(results[0].Message, Does.Contain("Unknown tool"));
        });
    }

    [Test]
    public void ExecuteInProcess_MultipleFixes_AppliesAll()
    {
        var file1 = Path.Combine(_tempDir, "File1.cs");
        File.WriteAllText(file1, "var x = _pipeline;");

        var file2 = Path.Combine(_tempDir, "File2.cs");
        File.WriteAllText(file2, """
            using System;

            namespace Test;
            """);

        var fixes = new List<FixOperation>
        {
            new()
            {
                ToolName = "regex_replacement",
                ToolArgs = new Dictionary<string, string>
                {
                    ["filePath"] = file1,
                    ["pattern"] = @"\b_pipeline\b",
                    ["replacement"] = "Pipeline"
                }
            },
            new()
            {
                ToolName = "add_using_directive",
                ToolArgs = new Dictionary<string, string>
                {
                    ["filePath"] = file2,
                    ["namespace"] = "Azure.Core"
                }
            }
        };

        var results = BatchFixTool.ExecuteInProcess(fixes);

        Assert.Multiple(() =>
        {
            Assert.That(results, Has.Count.EqualTo(2));
            Assert.That(results[0].Success, Is.True);
            Assert.That(results[1].Success, Is.True);
            Assert.That(File.ReadAllText(file1), Is.EqualTo("var x = Pipeline;"));
            Assert.That(File.ReadAllText(file2), Does.Contain("using Azure.Core;"));
        });
    }

    [Test]
    public void ExecuteInProcess_AddUsingWithEmptyNamespace_ReturnsFailure()
    {
        var file = Path.Combine(_tempDir, "Test.cs");
        File.WriteAllText(file, "using System;");

        var fixes = new List<FixOperation>
        {
            new()
            {
                ToolName = "add_using_directive",
                ToolArgs = new Dictionary<string, string>
                {
                    ["filePath"] = file,
                    ["namespace"] = ""
                }
            }
        };

        var results = BatchFixTool.ExecuteInProcess(fixes);

        Assert.Multiple(() =>
        {
            Assert.That(results, Has.Count.EqualTo(1));
            Assert.That(results[0].Success, Is.False);
            Assert.That(results[0].Message, Does.Contain("No namespace mapping"));
        });
    }

    [Test]
    public void Execute_EmptyJson_ReturnsSuccess()
    {
        var json = BatchFixTool.Execute("[]");

        Assert.That(json, Does.Contain("\"success\":true"));
        Assert.That(json, Does.Contain("\"applied\":0"));
    }

    [Test]
    public void Execute_InvalidJson_ReturnsError()
    {
        var json = BatchFixTool.Execute("not valid json");

        Assert.That(json, Does.Contain("\"success\":false"));
    }

    [Test]
    public void Execute_ValidFixOperations_ReturnsStructuredResult()
    {
        var file = Path.Combine(_tempDir, "Test.cs");
        File.WriteAllText(file, "var x = _endpoint;");

        var fixesJson = System.Text.Json.JsonSerializer.Serialize(new[]
        {
            new
            {
                toolName = "regex_replacement",
                toolArgs = new Dictionary<string, string>
                {
                    ["filePath"] = file,
                    ["pattern"] = @"\b_endpoint\b",
                    ["replacement"] = "Endpoint"
                }
            }
        });

        var json = BatchFixTool.Execute(fixesJson);

        Assert.That(json, Does.Contain("\"success\":true"));
        Assert.That(json, Does.Contain("\"applied\":1"));
    }
}

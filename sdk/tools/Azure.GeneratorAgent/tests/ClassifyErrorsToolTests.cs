// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.GeneratorAgent.Mcp;
using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class ClassifyErrorsToolTests
{
    [Test]
    public void Execute_KnownDeterministicError_ClassifiesCorrectly()
    {
        var errors = new[]
        {
            new BuildError
            {
                FilePath = @"C:\src\Test.cs",
                Line = 10,
                Code = "CS0246",
                Message = "The type or namespace name 'HttpPipeline' could not be found",
                Severity = "error"
            }
        };

        var json = ClassifyErrorsTool.Execute(JsonSerializer.Serialize(errors));
        var result = JsonSerializer.Deserialize<JsonElement>(json);

        Assert.Multiple(() =>
        {
            Assert.That(result.GetProperty("success").GetBoolean(), Is.True);
            Assert.That(result.GetProperty("total").GetInt32(), Is.EqualTo(1));
            Assert.That(result.GetProperty("deterministicCount").GetInt32(), Is.EqualTo(1));
            Assert.That(result.GetProperty("requiresReasoningCount").GetInt32(), Is.EqualTo(0));
        });
    }

    [Test]
    public void Execute_UnknownError_ClassifiesAsRequiresReasoning()
    {
        var errors = new[]
        {
            new BuildError
            {
                FilePath = @"C:\src\Test.cs",
                Line = 10,
                Code = "CS9999",
                Message = "Some completely unknown error",
                Severity = "error"
            }
        };

        var json = ClassifyErrorsTool.Execute(JsonSerializer.Serialize(errors));
        var result = JsonSerializer.Deserialize<JsonElement>(json);

        Assert.Multiple(() =>
        {
            Assert.That(result.GetProperty("success").GetBoolean(), Is.True);
            Assert.That(result.GetProperty("deterministicCount").GetInt32(), Is.EqualTo(0));
            Assert.That(result.GetProperty("requiresReasoningCount").GetInt32(), Is.EqualTo(1));
        });
    }

    [Test]
    public void Execute_MultipleErrors_CountsCorrectly()
    {
        var errors = new[]
        {
            new BuildError
            {
                FilePath = @"C:\src\Test.cs",
                Line = 10,
                Code = "CS0246",
                Message = "The type or namespace name 'HttpPipeline' could not be found",
                Severity = "error"
            },
            new BuildError
            {
                FilePath = @"C:\src\Test.cs",
                Line = 20,
                Code = "CS9999",
                Message = "Some completely unknown error",
                Severity = "error"
            },
            new BuildError
            {
                FilePath = @"C:\src\Test.cs",
                Line = 30,
                Code = "CS8625",
                Message = "Cannot convert null literal to non-nullable reference type",
                Severity = "error"
            }
        };

        var json = ClassifyErrorsTool.Execute(JsonSerializer.Serialize(errors));
        var result = JsonSerializer.Deserialize<JsonElement>(json);

        Assert.Multiple(() =>
        {
            Assert.That(result.GetProperty("success").GetBoolean(), Is.True);
            Assert.That(result.GetProperty("total").GetInt32(), Is.EqualTo(3));
            Assert.That(result.GetProperty("deterministicCount").GetInt32(), Is.EqualTo(2));
            Assert.That(result.GetProperty("requiresReasoningCount").GetInt32(), Is.EqualTo(1));
        });
    }

    [Test]
    public void Execute_EmptyArray_ReturnsZeroCounts()
    {
        var json = ClassifyErrorsTool.Execute("[]");
        var result = JsonSerializer.Deserialize<JsonElement>(json);

        Assert.Multiple(() =>
        {
            Assert.That(result.GetProperty("success").GetBoolean(), Is.True);
            Assert.That(result.GetProperty("total").GetInt32(), Is.EqualTo(0));
            Assert.That(result.GetProperty("deterministicCount").GetInt32(), Is.EqualTo(0));
        });
    }

    [Test]
    public void Execute_InvalidJson_ReturnsError()
    {
        var json = ClassifyErrorsTool.Execute("not valid json");
        var result = JsonSerializer.Deserialize<JsonElement>(json);

        Assert.That(result.GetProperty("success").GetBoolean(), Is.False);
        Assert.That(result.GetProperty("error").GetString(), Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public void Execute_NullDeserialize_ReturnsError()
    {
        var json = ClassifyErrorsTool.Execute("null");
        var result = JsonSerializer.Deserialize<JsonElement>(json);

        Assert.That(result.GetProperty("success").GetBoolean(), Is.False);
    }

    [Test]
    public void Execute_WithProjectPath_UsesGeneratedCodeIndex()
    {
        // Create a temp project with a Generated/ folder containing a type
        var tempDir = Path.Combine(Path.GetTempPath(), $"ClassifyErrorsTests_{Guid.NewGuid():N}");
        try
        {
            var generatedDir = Path.Combine(tempDir, "src", "Generated");
            Directory.CreateDirectory(generatedDir);
            File.WriteAllText(Path.Combine(generatedDir, "MyGeneratedType.cs"), """
                namespace MyService.Models;
                public class MyGeneratedType { }
                """);

            var errors = new[]
            {
                new BuildError
                {
                    FilePath = Path.Combine(tempDir, "src", "Custom", "MyFile.cs"),
                    Line = 5,
                    Code = "CS0246",
                    Message = "The type or namespace name 'MyGeneratedType' could not be found",
                    Severity = "error"
                }
            };

            var json = ClassifyErrorsTool.Execute(JsonSerializer.Serialize(errors), tempDir);
            var result = JsonSerializer.Deserialize<JsonElement>(json);

            Assert.Multiple(() =>
            {
                Assert.That(result.GetProperty("success").GetBoolean(), Is.True);
                Assert.That(result.GetProperty("deterministicCount").GetInt32(), Is.EqualTo(1));
            });
        }
        finally
        {
            if (Directory.Exists(tempDir))
                Directory.Delete(tempDir, true);
        }
    }

    [Test]
    public void Execute_FieldRenameError_ClassifiedAsDeterministic()
    {
        var errors = new[]
        {
            new BuildError
            {
                FilePath = @"C:\src\Client.cs",
                Line = 10,
                Code = "CS1061",
                Message = "'SomeClient' does not contain a definition for '_pipeline'",
                Severity = "error"
            }
        };

        var json = ClassifyErrorsTool.Execute(JsonSerializer.Serialize(errors));
        var result = JsonSerializer.Deserialize<JsonElement>(json);

        Assert.Multiple(() =>
        {
            Assert.That(result.GetProperty("success").GetBoolean(), Is.True);
            Assert.That(result.GetProperty("deterministicCount").GetInt32(), Is.EqualTo(1));
        });
    }
}

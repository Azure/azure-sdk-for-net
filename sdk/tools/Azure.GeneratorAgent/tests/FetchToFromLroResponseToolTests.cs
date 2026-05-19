// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp;
using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class FetchToFromLroResponseToolTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"FetchToFromLroTests_{Guid.NewGuid():N}");
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
    public void ReplaceFetchCalls_WithKnownType_ReplacesCorrectly()
    {
        var content = """
            MyResponseModel result = Fetch(response);
            """;

        var lroTypes = new Dictionary<string, string>
        {
            ["MyResponseModel"] = "MyResponseModel"
        };

        var result = FetchToFromLroResponseTool.ReplaceFetchCalls(content, lroTypes);

        Assert.That(result, Does.Contain("MyResponseModel.FromLroResponse(response)"));
        Assert.That(result, Does.Not.Contain("Fetch(response)"));
    }

    [Test]
    public void ReplaceFetchCalls_WithUnknownType_StillReplaces()
    {
        var content = """
            SomeModel result = Fetch(response);
            """;

        var lroTypes = new Dictionary<string, string>();

        var result = FetchToFromLroResponseTool.ReplaceFetchCalls(content, lroTypes);

        // Even without known types, if we can extract the type from the assignment, we use it
        Assert.That(result, Does.Contain("SomeModel.FromLroResponse(response)"));
    }

    [Test]
    public void ReplaceFetchCalls_WithVarType_SingleLroType_UsesDiscovered()
    {
        var content = """
            var result = Fetch(response);
            """;

        var lroTypes = new Dictionary<string, string>
        {
            ["MyModel"] = "MyModel"
        };

        var result = FetchToFromLroResponseTool.ReplaceFetchCalls(content, lroTypes);

        Assert.That(result, Does.Contain("MyModel.FromLroResponse(response)"));
    }

    [Test]
    public void ReplaceFetchCalls_WithVarType_MultipleLroTypes_LeavesAsIs()
    {
        var content = """
            var result = Fetch(response);
            """;

        var lroTypes = new Dictionary<string, string>
        {
            ["ModelA"] = "ModelA",
            ["ModelB"] = "ModelB"
        };

        var result = FetchToFromLroResponseTool.ReplaceFetchCalls(content, lroTypes);

        // Can't determine which type to use, so leave it for LLM
        Assert.That(result, Does.Contain("Fetch(response)"));
    }

    [Test]
    public void DiscoverLroResponseTypes_FindsTypes()
    {
        var generatedDir = Path.Combine(_tempDir, "Generated");
        Directory.CreateDirectory(generatedDir);

        File.WriteAllText(Path.Combine(generatedDir, "MyModel.cs"), """
            namespace Test.Generated;
            public partial class MyModel
            {
                public static MyModel FromLroResponse(Response response)
                {
                    return new MyModel();
                }
            }
            """);

        var types = FetchToFromLroResponseTool.DiscoverLroResponseTypes(generatedDir);

        Assert.That(types, Does.ContainKey("MyModel"));
    }

    [Test]
    public void DiscoverLroResponseTypes_EmptyDir_ReturnsEmpty()
    {
        var types = FetchToFromLroResponseTool.DiscoverLroResponseTypes(Path.Combine(_tempDir, "nonexistent"));

        Assert.That(types, Is.Empty);
    }

    [Test]
    public void ExecuteInProcess_ReplacesInCustomFiles()
    {
        var srcDir = Path.Combine(_tempDir, "src");
        var generatedDir = Path.Combine(srcDir, "Generated");
        Directory.CreateDirectory(generatedDir);
        Directory.CreateDirectory(srcDir);

        // Generated file with FromLroResponse
        File.WriteAllText(Path.Combine(generatedDir, "LroModel.cs"), """
            namespace Test.Generated;
            public partial class LroModel
            {
                public static LroModel FromLroResponse(Response response)
                {
                    return new LroModel();
                }
            }
            """);

        // Custom file with Fetch call
        File.WriteAllText(Path.Combine(srcDir, "CustomLro.cs"), """
            namespace Test;
            public partial class CustomLro
            {
                public void Process()
                {
                    LroModel result = Fetch(response);
                }
            }
            """);

        var (success, fixCount, _) = FetchToFromLroResponseTool.ExecuteInProcess(_tempDir);

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(fixCount, Is.EqualTo(1));
        });

        var content = File.ReadAllText(Path.Combine(srcDir, "CustomLro.cs"));
        Assert.That(content, Does.Contain("LroModel.FromLroResponse(response)"));
    }

    [Test]
    public void ExecuteInProcess_DoesNotModifyGeneratedFiles()
    {
        var srcDir = Path.Combine(_tempDir, "src");
        var generatedDir = Path.Combine(srcDir, "Generated");
        Directory.CreateDirectory(generatedDir);

        // Generated file that also contains Fetch — must not be modified
        var generatedContent = """
            namespace Test.Generated;
            public partial class Existing
            {
                LroModel result = Fetch(response);
            }
            """;
        File.WriteAllText(Path.Combine(generatedDir, "Existing.cs"), generatedContent);

        var (success, fixCount, _) = FetchToFromLroResponseTool.ExecuteInProcess(_tempDir);

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(fixCount, Is.EqualTo(0));
        });

        var content = File.ReadAllText(Path.Combine(generatedDir, "Existing.cs"));
        Assert.That(content, Is.EqualTo(generatedContent));
    }

    // --- Registry rule tests ---

    [Test]
    public void Classify_FetchNotExist_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\CustomLro.cs",
            Line = 20,
            Code = "CS0103",
            Message = "The name 'Fetch' does not exist in the current context",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("fetch_to_fromlro"));
        });
    }

    [Test]
    public void Classify_FetchNoDefinition_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\CustomLro.cs",
            Line = 25,
            Code = "CS1061",
            Message = "'SomeType' does not contain a definition for 'Fetch'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("fetch_to_fromlro"));
        });
    }

    [Test]
    public void Classify_ModelFactory_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\OldModelFactory.cs",
            Line = 10,
            Code = "CS0246",
            Message = "The type or namespace name 'OldServiceModelFactory' could not be found",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("rename_codegen_type"));
            Assert.That(result.ToolArgs!["typeSuffix"], Is.EqualTo("ModelFactory"));
        });
    }

    [Test]
    public void Classify_ClientBuilderExtensions_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Extensions.cs",
            Line = 15,
            Code = "CS0246",
            Message = "The type or namespace name 'OldClientBuilderExtensions' could not be found",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("rename_codegen_type"));
            Assert.That(result.ToolArgs!["typeSuffix"], Is.EqualTo("ClientBuilderExtensions"));
        });
    }
}

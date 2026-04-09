// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class AddCodeGenSuppressToolTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"CodeGenSuppressTests_{Guid.NewGuid():N}");
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

    // --- ParseParameterTypes tests ---

    [Test]
    public void ParseParameterTypes_EmptyString_ReturnsEmptyList()
    {
        var result = AddCodeGenSuppressTool.ParseParameterTypes("");
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void ParseParameterTypes_SingleSimpleParam_ReturnsType()
    {
        var result = AddCodeGenSuppressTool.ParseParameterTypes("string name");
        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0], Is.EqualTo("string"));
    }

    [Test]
    public void ParseParameterTypes_MultipleParams_ReturnsAllTypes()
    {
        var result = AddCodeGenSuppressTool.ParseParameterTypes("string name, int count, bool enabled");
        Assert.That(result, Has.Count.EqualTo(3));
        Assert.Multiple(() =>
        {
            Assert.That(result[0], Is.EqualTo("string"));
            Assert.That(result[1], Is.EqualTo("int"));
            Assert.That(result[2], Is.EqualTo("bool"));
        });
    }

    [Test]
    public void ParseParameterTypes_GenericType_PreservesAngleBrackets()
    {
        var result = AddCodeGenSuppressTool.ParseParameterTypes("IEnumerable<string> items, Dictionary<string, int> map");
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.Multiple(() =>
        {
            Assert.That(result[0], Is.EqualTo("IEnumerable<string>"));
            Assert.That(result[1], Is.EqualTo("Dictionary<string, int>"));
        });
    }

    [Test]
    public void ParseParameterTypes_NullableType_PreservesQuestionMark()
    {
        var result = AddCodeGenSuppressTool.ParseParameterTypes("string? name, int? value");
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.Multiple(() =>
        {
            Assert.That(result[0], Is.EqualTo("string?"));
            Assert.That(result[1], Is.EqualTo("int?"));
        });
    }

    [Test]
    public void ParseParameterTypes_DefaultValue_StripsDefault()
    {
        var result = AddCodeGenSuppressTool.ParseParameterTypes("string name = null, int count = 0");
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.Multiple(() =>
        {
            Assert.That(result[0], Is.EqualTo("string"));
            Assert.That(result[1], Is.EqualTo("int"));
        });
    }

    [Test]
    public void ParseParameterTypes_Modifiers_StripsModifiers()
    {
        var result = AddCodeGenSuppressTool.ParseParameterTypes("ref string name, out int value, params string[] args");
        Assert.That(result, Has.Count.EqualTo(3));
        Assert.Multiple(() =>
        {
            Assert.That(result[0], Is.EqualTo("string"));
            Assert.That(result[1], Is.EqualTo("int"));
            Assert.That(result[2], Is.EqualTo("string[]"));
        });
    }

    [Test]
    public void ParseParameterTypes_CancellationToken_Parsed()
    {
        var result = AddCodeGenSuppressTool.ParseParameterTypes("ChatCompletionsOptions options, ExtraParameters? extra, CancellationToken cancellationToken");
        Assert.That(result, Has.Count.EqualTo(3));
        Assert.Multiple(() =>
        {
            Assert.That(result[0], Is.EqualTo("ChatCompletionsOptions"));
            Assert.That(result[1], Is.EqualTo("ExtraParameters?"));
            Assert.That(result[2], Is.EqualTo("CancellationToken"));
        });
    }

    // --- FindGeneratedDirectory tests ---

    [Test]
    public void FindGeneratedDirectory_WithSrcGenerated_ReturnsPath()
    {
        var srcDir = Path.Combine(_tempDir, "src");
        var genDir = Path.Combine(srcDir, "Generated");
        Directory.CreateDirectory(genDir);
        var customFile = Path.Combine(srcDir, "Custom", "MyType.cs");
        Directory.CreateDirectory(Path.GetDirectoryName(customFile)!);
        File.WriteAllText(customFile, "class MyType {}");

        var result = AddCodeGenSuppressTool.FindGeneratedDirectory(customFile);
        Assert.That(result, Is.EqualTo(genDir));
    }

    [Test]
    public void FindGeneratedDirectory_NoGeneratedDir_ReturnsNull()
    {
        var srcDir = Path.Combine(_tempDir, "src");
        Directory.CreateDirectory(srcDir);
        var file = Path.Combine(srcDir, "MyType.cs");
        File.WriteAllText(file, "class MyType {}");

        var result = AddCodeGenSuppressTool.FindGeneratedDirectory(file);
        Assert.That(result, Is.Null);
    }

    // --- FindGeneratedMemberSignatures tests ---

    [Test]
    public void FindGeneratedMemberSignatures_MatchesCtor()
    {
        var genDir = Path.Combine(_tempDir, "Generated");
        Directory.CreateDirectory(genDir);
        File.WriteAllText(Path.Combine(genDir, "MyModel.cs"), """
            namespace MyService.Models
            {
                public partial class MyModel
                {
                    public MyModel(string name, int value)
                    {
                    }
                }
            }
            """);

        var sigs = AddCodeGenSuppressTool.FindGeneratedMemberSignatures(genDir, "MyModel", "MyModel");

        Assert.That(sigs, Has.Count.EqualTo(1));
        Assert.That(sigs[0].ParameterTypes, Has.Count.EqualTo(2));
        Assert.Multiple(() =>
        {
            Assert.That(sigs[0].ParameterTypes[0], Is.EqualTo("string"));
            Assert.That(sigs[0].ParameterTypes[1], Is.EqualTo("int"));
        });
    }

    [Test]
    public void FindGeneratedMemberSignatures_MatchesMethod()
    {
        var genDir = Path.Combine(_tempDir, "Generated");
        Directory.CreateDirectory(genDir);
        File.WriteAllText(Path.Combine(genDir, "MyClient.cs"), """
            namespace MyService
            {
                public partial class MyClient
                {
                    public virtual Response DoSomething(RequestContent content, RequestContext context)
                    {
                    }
                }
            }
            """);

        var sigs = AddCodeGenSuppressTool.FindGeneratedMemberSignatures(genDir, "MyClient", "DoSomething");

        Assert.That(sigs, Has.Count.EqualTo(1));
        Assert.That(sigs[0].ParameterTypes, Has.Count.EqualTo(2));
        Assert.Multiple(() =>
        {
            Assert.That(sigs[0].ParameterTypes[0], Is.EqualTo("RequestContent"));
            Assert.That(sigs[0].ParameterTypes[1], Is.EqualTo("RequestContext"));
        });
    }

    [Test]
    public void FindGeneratedMemberSignatures_NoMatch_ReturnsEmpty()
    {
        var genDir = Path.Combine(_tempDir, "Generated");
        Directory.CreateDirectory(genDir);
        File.WriteAllText(Path.Combine(genDir, "MyClient.cs"), """
            namespace MyService
            {
                public partial class MyClient
                {
                    public string Name { get; }
                }
            }
            """);

        var sigs = AddCodeGenSuppressTool.FindGeneratedMemberSignatures(genDir, "MyClient", "NonExistent");
        Assert.That(sigs, Is.Empty);
    }

    [Test]
    public void FindGeneratedMemberSignatures_MultipleOverloads_ReturnsAll()
    {
        var genDir = Path.Combine(_tempDir, "Generated");
        Directory.CreateDirectory(genDir);
        File.WriteAllText(Path.Combine(genDir, "MyClient.cs"), """
            namespace MyService
            {
                public partial class MyClient
                {
                    public virtual Response Send(string message)
                    {
                    }
                    public virtual Response Send(string message, CancellationToken token)
                    {
                    }
                }
            }
            """);

        var sigs = AddCodeGenSuppressTool.FindGeneratedMemberSignatures(genDir, "MyClient", "Send");
        Assert.That(sigs, Has.Count.EqualTo(2));
    }

    // --- Full ExecuteInProcess tests ---

    [Test]
    public void ExecuteInProcess_AddsSuppressAttribute()
    {
        // Set up project structure
        var srcDir = Path.Combine(_tempDir, "src");
        var genDir = Path.Combine(srcDir, "Generated");
        var customDir = Path.Combine(srcDir, "Custom");
        Directory.CreateDirectory(genDir);
        Directory.CreateDirectory(customDir);

        // Generated file with a constructor
        File.WriteAllText(Path.Combine(genDir, "MyModel.cs"), """
            namespace MyService.Models
            {
                public partial class MyModel
                {
                    public MyModel(string name, int value)
                    {
                    }
                }
            }
            """);

        // Custom file with a duplicate constructor
        var customFile = Path.Combine(customDir, "MyModel.cs");
        File.WriteAllText(customFile, """
            using Microsoft.TypeSpec.Generator.Customizations;

            namespace MyService.Models
            {
                public partial class MyModel
                {
                    public MyModel(string name, int value)
                    {
                        // Custom constructor
                    }
                }
            }
            """);

        var (success, result, error) = AddCodeGenSuppressTool.ExecuteInProcess(customFile, "MyModel");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(error, Is.Null);
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.AlreadyPresent, Is.False);
        });

        var content = File.ReadAllText(customFile);
        Assert.That(content, Does.Contain("[CodeGenSuppress(\"MyModel\", typeof(string), typeof(int))]"));
    }

    [Test]
    public void ExecuteInProcess_AlreadyPresent_DoesNotDuplicate()
    {
        var srcDir = Path.Combine(_tempDir, "src");
        var genDir = Path.Combine(srcDir, "Generated");
        var customDir = Path.Combine(srcDir, "Custom");
        Directory.CreateDirectory(genDir);
        Directory.CreateDirectory(customDir);

        File.WriteAllText(Path.Combine(genDir, "MyModel.cs"), """
            namespace MyService.Models
            {
                public partial class MyModel
                {
                    public MyModel(string name)
                    {
                    }
                }
            }
            """);

        var customFile = Path.Combine(customDir, "MyModel.cs");
        File.WriteAllText(customFile, """
            using Microsoft.TypeSpec.Generator.Customizations;

            namespace MyService.Models
            {
                [CodeGenSuppress("MyModel", typeof(string))]
                public partial class MyModel
                {
                }
            }
            """);

        var (success, result, error) = AddCodeGenSuppressTool.ExecuteInProcess(customFile, "MyModel");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(result!.AlreadyPresent, Is.True);
        });
    }

    [Test]
    public void ExecuteInProcess_FileNotFound_ReturnsFalse()
    {
        var (success, _, error) = AddCodeGenSuppressTool.ExecuteInProcess(
            Path.Combine(_tempDir, "nonexistent.cs"), "SomeMember");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.False);
            Assert.That(error, Does.Contain("File not found"));
        });
    }
}

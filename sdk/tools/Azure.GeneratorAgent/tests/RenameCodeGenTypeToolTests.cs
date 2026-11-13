// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp.Tools;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class RenameCodeGenTypeToolTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"RenameCodeGenTypeTests_{Guid.NewGuid():N}");
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
    public void ExecuteInProcess_FixesMismatchedModelFactory()
    {
        var srcDir = Path.Combine(_tempDir, "src");
        var generatedDir = Path.Combine(srcDir, "Generated");
        Directory.CreateDirectory(generatedDir);
        Directory.CreateDirectory(srcDir);

        // Generated type: NewServiceModelFactory
        File.WriteAllText(Path.Combine(generatedDir, "NewServiceModelFactory.cs"), """
            namespace Test.Generated;
            public static partial class NewServiceModelFactory
            {
                // generated factory
            }
            """);

        // Custom type: OldServiceModelFactory (mismatched name)
        File.WriteAllText(Path.Combine(srcDir, "OldServiceModelFactory.cs"), """
            namespace Test;
            public static partial class OldServiceModelFactory
            {
                // custom factory methods
            }
            """);

        var (success, fixes, _) = RenameCodeGenTypeTool.ExecuteInProcess(_tempDir, "ModelFactory");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(fixes, Has.Count.EqualTo(1));
            Assert.That(fixes[0].CustomTypeName, Is.EqualTo("OldServiceModelFactory"));
            Assert.That(fixes[0].GeneratedTypeName, Is.EqualTo("NewServiceModelFactory"));
        });

        var content = File.ReadAllText(Path.Combine(srcDir, "OldServiceModelFactory.cs"));
        Assert.That(content, Does.Contain("[CodeGenType(\"NewServiceModelFactory\")]"));
    }

    [Test]
    public void ExecuteInProcess_FixesMismatchedClientBuilderExtensions()
    {
        var srcDir = Path.Combine(_tempDir, "src");
        var generatedDir = Path.Combine(srcDir, "Generated");
        Directory.CreateDirectory(generatedDir);
        Directory.CreateDirectory(srcDir);

        File.WriteAllText(Path.Combine(generatedDir, "NewClientBuilderExtensions.cs"), """
            namespace Test.Generated;
            public static partial class NewClientBuilderExtensions
            {
            }
            """);

        File.WriteAllText(Path.Combine(srcDir, "OldClientBuilderExtensions.cs"), """
            namespace Test;
            public static partial class OldClientBuilderExtensions
            {
            }
            """);

        var (success, fixes, _) = RenameCodeGenTypeTool.ExecuteInProcess(_tempDir, "ClientBuilderExtensions");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(fixes, Has.Count.EqualTo(1));
            Assert.That(fixes[0].GeneratedTypeName, Is.EqualTo("NewClientBuilderExtensions"));
        });
    }

    [Test]
    public void ExecuteInProcess_UpdatesExistingCodeGenTypeAttribute()
    {
        var srcDir = Path.Combine(_tempDir, "src");
        var generatedDir = Path.Combine(srcDir, "Generated");
        Directory.CreateDirectory(generatedDir);
        Directory.CreateDirectory(srcDir);

        File.WriteAllText(Path.Combine(generatedDir, "UpdatedModelFactory.cs"), """
            namespace Test.Generated;
            public static partial class UpdatedModelFactory
            {
            }
            """);

        // Custom file already has a CodeGenType attribute pointing to wrong name
        File.WriteAllText(Path.Combine(srcDir, "MyModelFactory.cs"), """
            namespace Test;
            [CodeGenType("OldModelFactory")]
            public static partial class MyModelFactory
            {
            }
            """);

        var (success, fixes, _) = RenameCodeGenTypeTool.ExecuteInProcess(_tempDir, "ModelFactory");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(fixes, Has.Count.EqualTo(1));
        });

        var content = File.ReadAllText(Path.Combine(srcDir, "MyModelFactory.cs"));
        Assert.That(content, Does.Contain("[CodeGenType(\"UpdatedModelFactory\")]"));
        Assert.That(content, Does.Not.Contain("OldModelFactory"));
    }

    [Test]
    public void ExecuteInProcess_NoGeneratedTypes_NoChanges()
    {
        var srcDir = Path.Combine(_tempDir, "src");
        Directory.CreateDirectory(srcDir);

        File.WriteAllText(Path.Combine(srcDir, "MyModelFactory.cs"), """
            namespace Test;
            public static partial class MyModelFactory { }
            """);

        var (success, fixes, _) = RenameCodeGenTypeTool.ExecuteInProcess(_tempDir, "ModelFactory");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(fixes, Has.Count.EqualTo(0));
        });
    }

    [Test]
    public void ExecuteInProcess_MatchingNames_NoChanges()
    {
        var srcDir = Path.Combine(_tempDir, "src");
        var generatedDir = Path.Combine(srcDir, "Generated");
        Directory.CreateDirectory(generatedDir);
        Directory.CreateDirectory(srcDir);

        File.WriteAllText(Path.Combine(generatedDir, "SameModelFactory.cs"), """
            namespace Test.Generated;
            public static partial class SameModelFactory { }
            """);

        File.WriteAllText(Path.Combine(srcDir, "SameModelFactory.cs"), """
            namespace Test;
            public static partial class SameModelFactory { }
            """);

        var (success, fixes, _) = RenameCodeGenTypeTool.ExecuteInProcess(_tempDir, "ModelFactory");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(fixes, Has.Count.EqualTo(0));
        });
    }

    [Test]
    public void ExecuteInProcess_NoSrcDir_ReturnsSuccessEmpty()
    {
        var (success, fixes, _) = RenameCodeGenTypeTool.ExecuteInProcess(_tempDir, "ModelFactory");

        Assert.Multiple(() =>
        {
            Assert.That(success, Is.True);
            Assert.That(fixes, Has.Count.EqualTo(0));
        });
    }
}

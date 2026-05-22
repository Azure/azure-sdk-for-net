// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class GeneratedCodeIndexTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), "GeneratedCodeIndexTests_" + Guid.NewGuid().ToString("N")[..8]);
        Directory.CreateDirectory(_tempDir);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_tempDir))
        {
            Directory.Delete(_tempDir, recursive: true);
        }
    }

    [Test]
    public void Build_EmptyDirectory_ReturnsEmptyIndex()
    {
        var index = GeneratedCodeIndex.Build(_tempDir);

        Assert.That(index.TypeToNamespace, Is.Empty);
    }

    [Test]
    public void Build_NoGeneratedFolder_ReturnsEmptyIndex()
    {
        File.WriteAllText(Path.Combine(_tempDir, "SomeFile.cs"), "class Foo {}");

        var index = GeneratedCodeIndex.Build(_tempDir);

        Assert.That(index.TypeToNamespace, Is.Empty);
    }

    [Test]
    public void Build_DiscoversTypesFromGeneratedFolder()
    {
        var generatedDir = Path.Combine(_tempDir, "Generated");
        Directory.CreateDirectory(generatedDir);

        File.WriteAllText(Path.Combine(generatedDir, "MyModel.cs"), """
            namespace Azure.MyService.Models
            {
                public partial class MyModel
                {
                    public string Name { get; set; }
                }
            }
            """);

        var index = GeneratedCodeIndex.Build(_tempDir);

        Assert.That(index.TypeToNamespace, Does.ContainKey("MyModel"));
        Assert.That(index.TypeToNamespace["MyModel"], Is.EqualTo("Azure.MyService.Models"));
    }

    [Test]
    public void Build_DiscoversMultipleTypesInOneFile()
    {
        var generatedDir = Path.Combine(_tempDir, "Generated");
        Directory.CreateDirectory(generatedDir);

        File.WriteAllText(Path.Combine(generatedDir, "Models.cs"), """
            namespace Azure.MyService
            {
                public partial class ClientOptions { }
                public enum ServiceVersion { V1 }
                internal static class Helpers { }
                public partial struct MyStruct { }
                public partial interface IMyClient { }
            }
            """);

        var index = GeneratedCodeIndex.Build(_tempDir);

        Assert.Multiple(() =>
        {
            Assert.That(index.TypeToNamespace, Does.ContainKey("ClientOptions"));
            Assert.That(index.TypeToNamespace, Does.ContainKey("ServiceVersion"));
            Assert.That(index.TypeToNamespace, Does.ContainKey("Helpers"));
            Assert.That(index.TypeToNamespace, Does.ContainKey("MyStruct"));
            Assert.That(index.TypeToNamespace, Does.ContainKey("IMyClient"));
        });
    }

    [Test]
    public void Build_DiscoversTypesInSubdirectories()
    {
        var modelsDir = Path.Combine(_tempDir, "Generated", "Models");
        Directory.CreateDirectory(modelsDir);

        File.WriteAllText(Path.Combine(modelsDir, "InnerModel.cs"), """
            namespace Azure.MyService.Models
            {
                public partial class InnerModel { }
            }
            """);

        var index = GeneratedCodeIndex.Build(_tempDir);

        Assert.That(index.TypeToNamespace, Does.ContainKey("InnerModel"));
        Assert.That(index.TypeToNamespace["InnerModel"], Is.EqualTo("Azure.MyService.Models"));
    }

    [Test]
    public void Build_FindsGeneratedUnderSrc()
    {
        // Simulate project root with src/Generated/
        var srcDir = Path.Combine(_tempDir, "src", "Generated");
        Directory.CreateDirectory(srcDir);

        File.WriteAllText(Path.Combine(srcDir, "Client.cs"), """
            namespace Azure.MyService
            {
                public partial class MyServiceClient { }
            }
            """);

        var index = GeneratedCodeIndex.Build(_tempDir);

        Assert.That(index.TypeToNamespace, Does.ContainKey("MyServiceClient"));
    }

    [Test]
    public void ResolveNamespace_KnownType_ReturnsNamespace()
    {
        var generatedDir = Path.Combine(_tempDir, "Generated");
        Directory.CreateDirectory(generatedDir);

        File.WriteAllText(Path.Combine(generatedDir, "Foo.cs"), """
            namespace My.Custom.Namespace
            {
                public partial class FooBar { }
            }
            """);

        var index = GeneratedCodeIndex.Build(_tempDir);

        Assert.That(index.ResolveNamespace("FooBar"), Is.EqualTo("My.Custom.Namespace"));
    }

    [Test]
    public void ResolveNamespace_UnknownType_ReturnsNull()
    {
        var index = GeneratedCodeIndex.Build(_tempDir);

        Assert.That(index.ResolveNamespace("NonExistentType"), Is.Null);
    }

    [Test]
    public void Build_HandlesAbstractClasses()
    {
        var generatedDir = Path.Combine(_tempDir, "Generated");
        Directory.CreateDirectory(generatedDir);

        File.WriteAllText(Path.Combine(generatedDir, "BaseClass.cs"), """
            namespace Azure.MyService.Models
            {
                public abstract partial class NotificationContent { }
            }
            """);

        var index = GeneratedCodeIndex.Build(_tempDir);

        Assert.That(index.TypeToNamespace, Does.ContainKey("NotificationContent"));
    }
}

[TestFixture]
public class DynamicIndexClassificationTests
{
    private string _tempDir = null!;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), "DynClassifyTests_" + Guid.NewGuid().ToString("N")[..8]);
        var generatedDir = Path.Combine(_tempDir, "Generated");
        Directory.CreateDirectory(generatedDir);

        // Set up a realistic Generated/ folder
        File.WriteAllText(Path.Combine(generatedDir, "MessagesClient.cs"), """
            namespace Azure.Communication.Messages
            {
                public partial class MessagesClient { }
                public partial class MessagesClientOptions { }
            }
            """);

        File.WriteAllText(Path.Combine(generatedDir, "NotificationContent.cs"), """
            namespace Azure.Communication.Messages
            {
                public abstract partial class NotificationContent { }
                public partial class TextNotificationContent { }
                public partial class MediaNotificationContent { }
                public partial class TemplateNotificationContent { }
            }
            """);

        File.WriteAllText(Path.Combine(generatedDir, "MessageTemplate.cs"), """
            namespace Azure.Communication.Messages
            {
                public partial class MessageTemplate { }
                public partial class MessageTemplateValue { }
                public partial class MessageTemplateText { }
                public partial class MessageTemplateImage { }
                public partial class MessageTemplateDocument { }
                public partial class MessageTemplateVideo { }
                public partial class MessageTemplateQuickAction { }
                public partial class MessageTemplateLocation { }
            }
            """);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_tempDir))
        {
            Directory.Delete(_tempDir, recursive: true);
        }
    }

    [Test]
    public void Classify_WithIndex_ResolvesUnknownType_CS0246()
    {
        var index = GeneratedCodeIndex.Build(_tempDir);

        var error = new BuildError
        {
            FilePath = Path.Combine(_tempDir, "CustomClient.cs"),
            Line = 10,
            Code = "CS0246",
            Message = "The type or namespace name 'MessageTemplateQuickAction' could not be found (are you missing a using directive?)",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, index);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("add_using_directive"));
            Assert.That(result.ToolArgs!["namespace"], Is.EqualTo("Azure.Communication.Messages"));
            Assert.That(result.Reason, Does.Contain("Generated/"));
        });
    }

    [Test]
    public void Classify_WithIndex_ResolvesUnknownType_CS0103()
    {
        var index = GeneratedCodeIndex.Build(_tempDir);

        var error = new BuildError
        {
            FilePath = Path.Combine(_tempDir, "CustomClient.cs"),
            Line = 15,
            Code = "CS0103",
            Message = "The name 'TextNotificationContent' does not exist in the current context",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, index);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("add_using_directive"));
            Assert.That(result.ToolArgs!["namespace"], Is.EqualTo("Azure.Communication.Messages"));
        });
    }

    [Test]
    public void Classify_WithIndex_StaticRuleTakesPrecedence()
    {
        var index = GeneratedCodeIndex.Build(_tempDir);

        // Response is in the static TypeToNamespace map as "Azure"
        var error = new BuildError
        {
            FilePath = Path.Combine(_tempDir, "CustomClient.cs"),
            Line = 10,
            Code = "CS0246",
            Message = "The type or namespace name 'Response' could not be found",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, index);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("add_using_directive"));
            // Should use static map ("Azure"), not dynamic index
            Assert.That(result.ToolArgs!["namespace"], Is.EqualTo("Azure"));
        });
    }

    [Test]
    public void Classify_WithIndex_TypeNotInGenerated_IsNotDeterministic()
    {
        var index = GeneratedCodeIndex.Build(_tempDir);

        var error = new BuildError
        {
            FilePath = Path.Combine(_tempDir, "CustomClient.cs"),
            Line = 10,
            Code = "CS0246",
            Message = "The type or namespace name 'CompletelyMadeUpType' could not be found",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, index);

        // Type not in static mappings or Generated/ — classified as non-deterministic
        Assert.That(result.IsDeterministic, Is.False);
        Assert.That(result.Reason, Does.Contain("CompletelyMadeUpType"));
    }

    [Test]
    public void Classify_WithoutIndex_UnknownType_IsNotDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 10,
            Code = "CS0246",
            Message = "The type or namespace name 'MessageTemplateQuickAction' could not be found",
            Severity = "error"
        };

        // Without index (null), type not in static mappings — non-deterministic
        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.That(result.IsDeterministic, Is.False);
        Assert.That(result.Reason, Does.Contain("MessageTemplateQuickAction"));
    }

    [Test]
    public void Classify_WithIndex_GenericTypeResolved()
    {
        var index = GeneratedCodeIndex.Build(_tempDir);

        var error = new BuildError
        {
            FilePath = Path.Combine(_tempDir, "CustomClient.cs"),
            Line = 10,
            Code = "CS0246",
            Message = "The type or namespace name 'MessagesClient<T>' could not be found",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, index);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("add_using_directive"));
            Assert.That(result.ToolArgs!["namespace"], Is.EqualTo("Azure.Communication.Messages"));
        });
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Mcp;
using NUnit.Framework;

namespace Azure.GeneratorAgent.Tests;

[TestFixture]
public class DeterministicFixRegistryTests
{
    // --- Field rename rules ---

    [TestCase("_pipeline", "Pipeline")]
    [TestCase("_clientDiagnostics", "ClientDiagnostics")]
    [TestCase("_restClient", "RestClient")]
    [TestCase("_endpoint", "Endpoint")]
    [TestCase("_credential", "Credential")]
    [TestCase("_apiVersion", "ApiVersion")]
    [TestCase("_subscriptionId", "SubscriptionId")]
    [TestCase("_diagnostics", "Diagnostics")]
    public void Classify_FieldRename_CS1061_IsDeterministic(string oldName, string newName)
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 10,
            Code = "CS1061",
            Message = $"'SomeClient' does not contain a definition for '{oldName}'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
            Assert.That(result.ToolArgs, Does.ContainKey("replacement"));
            Assert.That(result.ToolArgs!["replacement"], Is.EqualTo(newName));
        });
    }

    [TestCase("_pipeline", "Pipeline")]
    [TestCase("_endpoint", "Endpoint")]
    public void Classify_FieldRename_CS0103_IsDeterministic(string oldName, string newName)
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 15,
            Code = "CS0103",
            Message = $"The name '{oldName}' does not exist in the current context",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.That(result.IsDeterministic, Is.True);
    }

    // --- ResponseWithHeaders rule ---

    [Test]
    public void Classify_ResponseWithHeaders_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 20,
            Code = "CS0246",
            Message = "The type or namespace name 'ResponseWithHeaders<SomeResponse, SomeHeaders>' could not be found",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
            Assert.That(result.ToolArgs!["pattern"], Does.Contain("ResponseWithHeaders"));
        });
    }

    // --- Rest namespace prefix rule ---

    [Test]
    public void Classify_RestNamespacePrefix_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 25,
            Code = "CS0246",
            Message = "The type or namespace name 'Rest' (used in 'Rest.SomeType') does not exist in the namespace 'MyService'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
        });
    }

    // --- Duplicate Models.Models rule ---

    [Test]
    public void Classify_DuplicateModelsNamespace_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 30,
            Code = "CS0246",
            Message = "The type or namespace name 'Models.Models.SomeModel' could not be found",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
            Assert.That(result.ToolArgs!["replacement"], Is.EqualTo("Models."));
        });
    }

    // --- Missing using directive rules (CS0246) ---

    [TestCase("HttpPipeline", "Azure.Core.Pipeline")]
    [TestCase("HttpPipelineBuilder", "Azure.Core.Pipeline")]
    [TestCase("DiagnosticScope", "Azure.Core.Pipeline")]
    [TestCase("DiagnosticScopeFactory", "Azure.Core.Pipeline")]
    [TestCase("RequestContext", "Azure.Core")]
    [TestCase("TokenCredential", "Azure.Core")]
    [TestCase("ResourceIdentifier", "Azure.Core")]
    [TestCase("AzureLocation", "Azure.Core")]
    [TestCase("HttpMessage", "Azure.Core")]
    [TestCase("RequestContent", "Azure.Core")]
    [TestCase("Response", "Azure")]
    [TestCase("RequestFailedException", "Azure")]
    [TestCase("AzureKeyCredential", "Azure")]
    [TestCase("AsyncPageable", "Azure")]
    [TestCase("Pageable", "Azure")]
    [TestCase("ETag", "Azure")]
    [TestCase("Operation", "Azure")]
    [TestCase("NullableResponse", "Azure")]
    [TestCase("ClientResult", "System.ClientModel")]
    [TestCase("CollectionResult", "System.ClientModel")]
    [TestCase("AsyncCollectionResult", "System.ClientModel")]
    [TestCase("ContinuationToken", "System.ClientModel")]
    [TestCase("PageResult", "System.ClientModel")]
    [TestCase("BinaryContent", "System.ClientModel")]
    [TestCase("ApiKeyCredential", "System.ClientModel")]
    [TestCase("ClientResultException", "System.ClientModel")]
    [TestCase("PipelineResponse", "System.ClientModel.Primitives")]
    [TestCase("ClientPipeline", "System.ClientModel.Primitives")]
    [TestCase("PipelinePolicy", "System.ClientModel.Primitives")]
    [TestCase("PipelineMessage", "System.ClientModel.Primitives")]
    [TestCase("ArmOperation", "Azure.ResourceManager")]
    [TestCase("ArmResource", "Azure.ResourceManager")]
    [TestCase("ArmClient", "Azure.ResourceManager")]
    public void Classify_MissingUsing_CS0246_IsDeterministic(string typeName, string expectedNamespace)
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 10,
            Code = "CS0246",
            Message = $"The type or namespace name '{typeName}' could not be found (are you missing a using directive or an assembly reference?)",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("add_using_directive"));
            Assert.That(result.ToolArgs, Does.ContainKey("namespace"));
            Assert.That(result.ToolArgs!["namespace"], Is.EqualTo(expectedNamespace));
        });
    }

    [Test]
    public void Classify_MissingUsing_GenericType_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 10,
            Code = "CS0246",
            Message = "The type or namespace name 'Response<SomeModel>' could not be found",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("add_using_directive"));
            Assert.That(result.ToolArgs!["namespace"], Is.EqualTo("Azure"));
        });
    }

    // --- Remove obsolete using rule (CS0234) ---

    [Test]
    public void Classify_ObsoleteRestUsing_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 5,
            Code = "CS0234",
            Message = "The type or namespace name 'Rest' does not exist in the namespace 'MyService.SomeNamespace' (are you missing an assembly reference?)",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("remove_using_directive"));
            Assert.That(result.ToolArgs, Does.ContainKey("namespacePattern"));
        });
    }

    // --- Nullable annotation rules ---

    [Test]
    public void Classify_CS8625_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 42,
            Code = "CS8625",
            Message = "Cannot convert null literal to non-nullable reference type",
            Severity = "warning"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("nullable_annotation_fix"));
            Assert.That(result.ToolArgs!["line"], Is.EqualTo("42"));
        });
    }

    [Test]
    public void Classify_CS8600_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 50,
            Code = "CS8600",
            Message = "Converting null literal or possible null value to non-nullable type",
            Severity = "warning"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("nullable_annotation_fix"));
            Assert.That(result.ToolArgs!["line"], Is.EqualTo("50"));
        });
    }

    // --- Non-deterministic errors ---

    [Test]
    public void Classify_UnknownError_IsNotDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 100,
            Code = "CS0535",
            Message = "'MyClass' does not implement interface member 'IFoo.Bar()'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.ToolName, Is.Null);
            Assert.That(result.Reason, Does.Contain("requires LLM reasoning"));
        });
    }

    [Test]
    public void Classify_UnknownType_CS0246_IsNotDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 10,
            Code = "CS0246",
            Message = "The type or namespace name 'SomeCompletelyUnknownType' could not be found",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        // Still deterministic because the add_using rule matches, but with empty args
        // since the type isn't in our mapping
        Assert.That(result.IsDeterministic, Is.True);
        Assert.That(result.ToolArgs, Is.Empty);
    }

    // --- Registry structure tests ---

    [Test]
    public void Rules_AreNotEmpty()
    {
        Assert.That(DeterministicFixRegistry.Rules, Is.Not.Empty);
    }

    [Test]
    public void TypeToNamespace_ContainsAllExpectedMappings()
    {
        var mapping = DeterministicFixRegistry.TypeToNamespace;

        Assert.Multiple(() =>
        {
            Assert.That(mapping, Does.ContainKey("HttpPipeline"));
            Assert.That(mapping, Does.ContainKey("Response"));
            Assert.That(mapping, Does.ContainKey("ClientResult"));
            Assert.That(mapping, Does.ContainKey("PipelineResponse"));
            Assert.That(mapping, Does.ContainKey("ArmOperation"));
        });
    }

    [Test]
    public void FieldRenames_ContainsAllExpectedMappings()
    {
        var renames = DeterministicFixRegistry.FieldRenames;

        Assert.Multiple(() =>
        {
            Assert.That(renames, Does.ContainKey("_pipeline"));
            Assert.That(renames, Does.ContainKey("_clientDiagnostics"));
            Assert.That(renames, Does.ContainKey("_restClient"));
            Assert.That(renames, Does.ContainKey("_endpoint"));
            Assert.That(renames, Does.ContainKey("_credential"));
            Assert.That(renames, Does.ContainKey("_apiVersion"));
            Assert.That(renames, Does.ContainKey("_subscriptionId"));
            Assert.That(renames, Does.ContainKey("_diagnostics"));
        });
    }

    [Test]
    public void Classify_NullError_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => DeterministicFixRegistry.Classify(null!));
    }

    // --- Migration pattern rules ---

    [Test]
    public void Classify_ToRequestContent_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 55,
            Code = "CS1061",
            Message = "'SomeModel' does not contain a definition for 'ToRequestContent'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
            Assert.That(result.ToolArgs!["pattern"], Does.Contain("ToRequestContent"));
        });
    }

    [Test]
    public void Classify_FromCancellationToken_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 60,
            Code = "CS1061",
            Message = "'SomeType' does not contain a definition for 'FromCancellationToken'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
            Assert.That(result.ToolArgs!["pattern"], Does.Contain("FromCancellationToken"));
        });
    }

    [Test]
    public void Classify_FromResponse_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 65,
            Code = "CS1061",
            Message = "'SomeModel' does not contain a definition for 'FromResponse'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
            Assert.That(result.ToolArgs!["pattern"], Does.Contain("FromResponse"));
        });
    }
}

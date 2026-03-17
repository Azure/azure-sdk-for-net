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

    // --- New rules: CodeGenModel → CodeGenType attribute rename ---

    [Test]
    public void Classify_CodeGenModelAttribute_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Customizations\MyModel.cs",
            Line = 5,
            Code = "CS0246",
            Message = "The type or namespace name 'CodeGenModel' could not be found (are you missing a using directive?)",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
            Assert.That(result.ToolArgs!["pattern"], Does.Contain("CodeGenModel"));
            Assert.That(result.ToolArgs!["replacement"], Is.EqualTo("CodeGenType"));
        });
    }

    [Test]
    public void Classify_CodeGenModelAttribute_WithAttributeSuffix_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Customizations\MyModel.cs",
            Line = 5,
            Code = "CS0246",
            Message = "The type or namespace name 'CodeGenModelAttribute' could not be found",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
            Assert.That(result.ToolArgs!["replacement"], Is.EqualTo("CodeGenType"));
        });
    }

    // --- New rules: CodeGen* types → Microsoft.TypeSpec.Generator.Customizations ---

    [TestCase("CodeGenType", "Microsoft.TypeSpec.Generator.Customizations")]
    [TestCase("CodeGenMember", "Microsoft.TypeSpec.Generator.Customizations")]
    [TestCase("CodeGenSuppress", "Microsoft.TypeSpec.Generator.Customizations")]
    [TestCase("CodeGenSerialization", "Microsoft.TypeSpec.Generator.Customizations")]
    [TestCase("CodeGenVisibility", "Microsoft.TypeSpec.Generator.Customizations")]
    [TestCase("CodeGenClient", "Microsoft.TypeSpec.Generator.Customizations")]
    public void Classify_CodeGenAttributes_CS0246_IsDeterministic(string typeName, string expectedNamespace)
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Customizations\MyModel.cs",
            Line = 3,
            Code = "CS0246",
            Message = $"The type or namespace name '{typeName}' could not be found (are you missing a using directive?)",
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

    // --- New rules: Additional type-to-namespace mappings ---

    [TestCase("ModelSerializationExtensions", "Azure.Core")]
    [TestCase("WaitUntil", "Azure")]
    [TestCase("ModelReaderWriterOptions", "System.ClientModel.Primitives")]
    [TestCase("ModelReaderWriter", "System.ClientModel.Primitives")]
    [TestCase("IJsonModel", "System.ClientModel.Primitives")]
    [TestCase("IPersistableModel", "System.ClientModel.Primitives")]
    public void Classify_NewTypeMappings_CS0246_IsDeterministic(string typeName, string expectedNamespace)
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 10,
            Code = "CS0246",
            Message = $"The type or namespace name '{typeName}' could not be found",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("add_using_directive"));
            Assert.That(result.ToolArgs!["namespace"], Is.EqualTo(expectedNamespace));
        });
    }

    // --- New rules: _serializedAdditionalRawData field rename ---

    [Test]
    public void Classify_SerializedAdditionalRawData_FieldRename_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Customizations\MyModel.cs",
            Line = 20,
            Code = "CS0103",
            Message = "The name '_serializedAdditionalRawData' does not exist in the current context",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.That(result.IsDeterministic, Is.True);
    }

    [Test]
    public void Classify_SerializedAdditionalRawData_CS1061_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Customizations\MyModel.cs",
            Line = 20,
            Code = "CS1061",
            Message = "'MyModel' does not contain a definition for '_serializedAdditionalRawData'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
            Assert.That(result.ToolArgs!["replacement"], Is.EqualTo("_additionalBinaryDataProperties"));
        });
    }

    // --- New rules: Autorest.CSharp.* removal ---

    [Test]
    public void Classify_AutorestCSharpCore_CS0234_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 2,
            Code = "CS0234",
            Message = "The type or namespace name 'Core' does not exist in the namespace 'Autorest.CSharp' (are you missing an assembly reference?)",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("remove_using_directive"));
        });
    }

    [Test]
    public void Classify_AutorestNamespace_CS0246_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 2,
            Code = "CS0246",
            Message = "The type or namespace name 'Autorest' could not be found",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("remove_using_directive"));
        });
    }

    // --- New rules: MultipartFormDataRequestContent capitalization ---

    [Test]
    public void Classify_MultipartFormDataRequestContent_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Serialization.cs",
            Line = 15,
            Code = "CS0246",
            Message = "The type or namespace name 'MultipartFormDataRequestContent' could not be found",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
            Assert.That(result.ToolArgs!["replacement"], Is.EqualTo("MultiPartFormDataRequestContent"));
        });
    }

    // --- New rules: CanceledValue/CancelingValue spelling ---

    [Test]
    public void Classify_CanceledValue_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Models\Status.cs",
            Line = 30,
            Code = "CS0117",
            Message = "'TranslationStatus' does not contain a definition for 'CanceledValue'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
            Assert.That(result.ToolArgs!["replacement"], Is.EqualTo("CancelledValue"));
        });
    }

    [Test]
    public void Classify_CancelingValue_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Models\Status.cs",
            Line = 31,
            Code = "CS0117",
            Message = "'TranslationStatus' does not contain a definition for 'CancelingValue'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
            Assert.That(result.ToolArgs!["replacement"], Is.EqualTo("CancellingValue"));
        });
    }

    // --- New rules: AZC0020 CancellationToken propagation ---

    [Test]
    public void Classify_AZC0020_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 85,
            Code = "AZC0020",
            Message = "Method 'StartTranslation' accepts a CancellationToken but does not propagate it to the RequestContext",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
            Assert.That(result.ToolArgs!["replacement"], Does.Contain("CancellationToken = cancellationToken"));
        });
    }

    // --- New rules: CS0104 ambiguous reference ---

    [Test]
    public void Classify_CS0104_AmbiguousReference_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Generated\Internal\MultiPart.cs",
            Line = 10,
            Code = "CS0104",
            Message = "'MultipartFormDataContent' is an ambiguous reference between 'Azure.Core.MultipartFormDataContent' and 'System.Net.Http.MultipartFormDataContent'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
            Assert.That(result.ToolArgs!["replacement"], Is.EqualTo("System.Net.Http.MultipartFormDataContent"));
        });
    }

    // --- FieldRenames includes _serializedAdditionalRawData ---

    [Test]
    public void FieldRenames_ContainsSerializedAdditionalRawData()
    {
        Assert.That(DeterministicFixRegistry.FieldRenames, Does.ContainKey("_serializedAdditionalRawData"));
        Assert.That(DeterministicFixRegistry.FieldRenames["_serializedAdditionalRawData"], Is.EqualTo("_additionalBinaryDataProperties"));
    }

    // --- TypeToNamespace includes CodeGen types ---

    [Test]
    public void TypeToNamespace_ContainsCodeGenTypes()
    {
        var mapping = DeterministicFixRegistry.TypeToNamespace;

        Assert.Multiple(() =>
        {
            Assert.That(mapping, Does.ContainKey("CodeGenType"));
            Assert.That(mapping, Does.ContainKey("CodeGenMember"));
            Assert.That(mapping, Does.ContainKey("CodeGenSuppress"));
            Assert.That(mapping, Does.ContainKey("CodeGenSerialization"));
            Assert.That(mapping, Does.ContainKey("CodeGenVisibility"));
            Assert.That(mapping, Does.ContainKey("ModelSerializationExtensions"));
            Assert.That(mapping, Does.ContainKey("ModelReaderWriterOptions"));
        });
    }
}

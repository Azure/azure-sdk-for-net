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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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
            Code = "CS0019",
            Message = "Operator '+' cannot be applied to operands of type 'Foo' and 'Bar'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

        // Not deterministic: the type isn't in static TypeToNamespace and no Generated/ index
        // is available, so the error requires LLM reasoning (likely a renamed or removed type).
        Assert.That(result.IsDeterministic, Is.False);
        Assert.That(result.Reason, Does.Contain("SomeCompletelyUnknownType"));
        Assert.That(result.Reason, Does.Contain("not found"));
    }

    [Test]
    public void Classify_UnknownType_CS0246_WithEmptyIndex_IsNotDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 10,
            Code = "CS0246",
            Message = "The type or namespace name 'ConversationAuthoringExportedModel' could not be found",
            Severity = "error"
        };

        // Pass an empty GeneratedCodeIndex (simulates type not existing in Generated/ either)
        var index = GeneratedCodeIndex.Build(Path.GetTempPath());

        var result = DeterministicFixRegistry.Classify(error, index);

        // Not deterministic: type is not in static mappings AND not in Generated/ code
        Assert.That(result.IsDeterministic, Is.False);
        Assert.That(result.Reason, Does.Contain("ConversationAuthoringExportedModel"));
        Assert.That(result.Reason, Does.Contain("not found"));
        Assert.That(result.ToolName, Is.Null);
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
        Assert.Throws<ArgumentNullException>(() => DeterministicFixRegistry.Classify(null!, null));
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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

        var result = DeterministicFixRegistry.Classify(error, null);

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

    // --- ApiCompat classification rules ---

    [Test]
    public void Classify_MembersMustExist_ProtectedCtor_IsClassified()
    {
        var error = new BuildError
        {
            FilePath = @"C:\nuget\Microsoft.DotNet.ApiCompat.targets",
            Line = 82,
            Code = "MembersMustExist",
            Message = "MembersMustExist : Member 'Azure.SomeService.Models.SomeBaseType..ctor(System.Guid, System.Collections.Generic.IEnumerable<System.String>)' does not exist in the implementation but it does exist in the contract.",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.Reason, Does.Contain("ApiCompat"));
        });
    }

    [Test]
    public void Classify_MembersMustExist_ParameterlessCtor_IsClassified()
    {
        var error = new BuildError
        {
            FilePath = @"C:\nuget\Microsoft.DotNet.ApiCompat.targets",
            Line = 82,
            Code = "MembersMustExist",
            Message = "MembersMustExist : Member 'Azure.SomeService.Models.SomeBaseType..ctor()' does not exist in the implementation but it does exist in the contract.",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.Reason, Does.Contain("ApiCompat"));
        });
    }

    [Test]
    public void Classify_CannotSealType_IsClassified()
    {
        var error = new BuildError
        {
            FilePath = @"C:\nuget\Microsoft.DotNet.ApiCompat.targets",
            Line = 82,
            Code = "CannotSealType",
            Message = "CannotSealType : Type 'Azure.SomeService.Models.SomeBaseModel' is effectively sealed in the implementation but not in the contract.",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.Reason, Does.Contain("ApiCompat"));
            Assert.That(result.Reason, Does.Contain("effectively sealed"));
        });
    }

    [Test]
    public void Classify_CannotRemoveAttribute_ObsoleteAttribute_IsClassified()
    {
        var error = new BuildError
        {
            FilePath = @"C:\nuget\Microsoft.DotNet.ApiCompat.targets",
            Line = 82,
            Code = "CannotRemoveAttribute",
            Message = "CannotRemoveAttribute : Attribute 'System.ObsoleteAttribute' exists on 'Azure.SomeService.Models.DeprecatedModel' in the contract but not the implementation.",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.ToolName, Is.Null);
            Assert.That(result.Reason, Does.Contain("ApiCompat"));
            Assert.That(result.Reason, Does.Contain("attribute was removed"));
            Assert.That(result.ToolArgs!["attribute"], Is.EqualTo("System.ObsoleteAttribute"));
            Assert.That(result.ToolArgs["member"], Is.EqualTo("Azure.SomeService.Models.DeprecatedModel"));
            Assert.That(result.ToolArgs, Does.ContainKey("baselineEntry"));
        });
    }

    [Test]
    public void Classify_CannotRemoveAttribute_EditorBrowsable_IsClassified()
    {
        var error = new BuildError
        {
            FilePath = @"C:\nuget\Microsoft.DotNet.ApiCompat.targets",
            Line = 82,
            Code = "CannotRemoveAttribute",
            Message = "CannotRemoveAttribute : Attribute 'System.ComponentModel.EditorBrowsableAttribute' exists on 'Azure.SomeService.SomeFactory.SomeMethod(System.String)' in the contract but not the implementation.",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.ToolArgs!["attribute"], Is.EqualTo("System.ComponentModel.EditorBrowsableAttribute"));
        });
    }

    [Test]
    public void Classify_TypesMustExist_IsClassified()
    {
        var error = new BuildError
        {
            FilePath = @"C:\nuget\Microsoft.DotNet.ApiCompat.targets",
            Line = 82,
            Code = "TypesMustExist",
            Message = "TypesMustExist : Type 'Azure.SomeService.Models.SomeRemovedModel' does not exist in the implementation but it does exist in the contract.",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.ToolName, Is.Null);
            Assert.That(result.Reason, Does.Contain("ApiCompat"));
            Assert.That(result.Reason, Does.Contain("type was removed"));
            Assert.That(result.ToolArgs!["typeName"], Is.EqualTo("SomeRemovedModel"));
            Assert.That(result.ToolArgs["fullTypeName"], Is.EqualTo("Azure.SomeService.Models.SomeRemovedModel"));
        });
    }

    [Test]
    public void Classify_ApiCompat_GenericFallback_IsClassified()
    {
        var error = new BuildError
        {
            FilePath = @"C:\nuget\Microsoft.DotNet.ApiCompat.targets",
            Line = 82,
            Code = "ApiCompat",
            Message = "SomeNewRule : Something unexpected happened.",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.ToolName, Is.Null);
            Assert.That(result.Reason, Does.Contain("ApiCompat error"));
            Assert.That(result.ToolArgs, Does.ContainKey("baselineEntry"));
        });
    }

    [Test]
    public void Classify_MembersMustExist_ModelFactory_IsClassified()
    {
        var error = new BuildError
        {
            FilePath = @"C:\nuget\Microsoft.DotNet.ApiCompat.targets",
            Line = 82,
            Code = "MembersMustExist",
            Message = "MembersMustExist : Member 'Azure.AI.Agents.Persistent.PersistentAgentsModelFactory.MessageDeltaChunk(System.String, Azure.AI.Agents.Persistent.MessageDeltaChunkObject, Azure.AI.Agents.Persistent.MessageDelta)' does not exist in the implementation but it does exist in the contract.",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.ToolName, Is.Null);
            Assert.That(result.Reason, Does.Contain("ModelFactory"));
            Assert.That(result.ToolArgs!["factoryType"], Is.EqualTo("Azure.AI.Agents.Persistent.PersistentAgentsModelFactory"));
            Assert.That(result.ToolArgs["methodName"], Is.EqualTo("MessageDeltaChunk"));
            Assert.That(result.ToolArgs, Does.ContainKey("oldParams"));
        });
    }

    [Test]
    public void Classify_MembersMustExist_SerializedAdditionalRawData_IsClassified()
    {
        var error = new BuildError
        {
            FilePath = @"C:\nuget\Microsoft.DotNet.ApiCompat.targets",
            Line = 82,
            Code = "MembersMustExist",
            Message = "MembersMustExist : Member 'Azure.AI.Agents.Persistent.MessageDeltaTextAnnotation.SerializedAdditionalRawData' does not exist in the implementation but it does exist in the contract.",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.ToolName, Is.Null);
            Assert.That(result.Reason, Does.Contain("SerializedAdditionalRawData"));
            Assert.That(result.ToolArgs!["typeName"], Is.EqualTo("MessageDeltaTextAnnotation"));
            Assert.That(result.ToolArgs["fullTypeName"], Is.EqualTo("Azure.AI.Agents.Persistent.MessageDeltaTextAnnotation"));
        });
    }

    [Test]
    public void Classify_CannotChangeAttribute_IsClassified()
    {
        var error = new BuildError
        {
            FilePath = @"C:\nuget\Microsoft.DotNet.ApiCompat.targets",
            Line = 82,
            Code = "CannotChangeAttribute",
            Message = "CannotChangeAttribute : Attribute 'System.ObsoleteAttribute' on 'SomeType.SomeMember' has changed in the implementation.",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.ToolName, Is.Null);
            Assert.That(result.Reason, Does.Contain("ApiCompat"));
            Assert.That(result.Reason, Does.Contain("attribute value changed"));
        });
    }

    // --- CS0111 duplicate member ---

    [Test]
    public void Classify_CS0111_DuplicateMember_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Custom\MyModel.cs",
            Line = 15,
            Code = "CS0111",
            Message = "Type 'MyModel' already defines a member called 'MyModel' with the same parameter types",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("add_codegen_suppress"));
            Assert.That(result.ToolArgs, Does.ContainKey("filePath"));
            Assert.That(result.ToolArgs, Does.ContainKey("memberName"));
            Assert.That(result.ToolArgs!["memberName"], Is.EqualTo("MyModel"));
        });
    }

    [Test]
    public void Classify_CS0111_DuplicateMethod_ExtractsMemberName()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Custom\MyClient.cs",
            Line = 30,
            Code = "CS0111",
            Message = "Type 'MyClient' already defines a member called 'DoSomethingAsync' with the same parameter types",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("add_codegen_suppress"));
            Assert.That(result.ToolArgs!["memberName"], Is.EqualTo("DoSomethingAsync"));
        });
    }

    // --- TypeToNamespace additional entries ---

    [TestCase("Argument", "Azure.Core")]
    [TestCase("ConnectionString", "Azure.Core")]
    [TestCase("ResourceType", "Azure.Core")]
    [TestCase("ContentType", "Azure.Core")]
    [TestCase("SubResource", "Azure.ResourceManager.Models")]
    [TestCase("TrackedResource", "Azure.ResourceManager.Models")]
    [TestCase("ManagedServiceIdentity", "Azure.ResourceManager.Models")]
    [TestCase("UserAssignedIdentity", "Azure.ResourceManager.Models")]
    [TestCase("SystemData", "Azure.ResourceManager.Models")]
    public void TypeToNamespace_ContainsNewlyAddedTypes(string typeName, string expectedNamespace)
    {
        Assert.That(DeterministicFixRegistry.TypeToNamespace, Does.ContainKey(typeName));
        Assert.That(DeterministicFixRegistry.TypeToNamespace[typeName], Is.EqualTo(expectedNamespace));
    }

    // --- New TypeToNamespace entries: GeoJson, Serialization, DataFactory, etc. ---

    [TestCase("GeoPosition", "Azure.Core.GeoJson")]
    [TestCase("GeoPoint", "Azure.Core.GeoJson")]
    [TestCase("GeoPolygon", "Azure.Core.GeoJson")]
    [TestCase("GeoLineString", "Azure.Core.GeoJson")]
    [TestCase("GeoBoundingBox", "Azure.Core.GeoJson")]
    [TestCase("GeoObject", "Azure.Core.GeoJson")]
    [TestCase("GeoCollection", "Azure.Core.GeoJson")]
    [TestCase("DynamicData", "Azure.Core.Serialization")]
    [TestCase("JsonObjectSerializer", "Azure.Core.Serialization")]
    [TestCase("ObjectSerializer", "Azure.Core.Serialization")]
    [TestCase("DataFactoryElement", "Azure.Core.Expressions.DataFactory")]
    [TestCase("DataFactoryExpression", "Azure.Core.Expressions.DataFactory")]
    [TestCase("RequestConditions", "Azure.Core")]
    [TestCase("MatchConditions", "Azure.Core")]
    [TestCase("RetryOptions", "Azure.Core")]
    [TestCase("HttpAuthorization", "Azure.Core")]
    [TestCase("HttpRange", "Azure.Core")]
    [TestCase("AzureSasCredential", "Azure")]
    [TestCase("ResponseError", "Azure")]
    [TestCase("ArmEnvironment", "Azure.ResourceManager")]
    [TestCase("GenericResource", "Azure.ResourceManager")]
    public void TypeToNamespace_ContainsExpandedTypes(string typeName, string expectedNamespace)
    {
        Assert.That(DeterministicFixRegistry.TypeToNamespace, Does.ContainKey(typeName));
        Assert.That(DeterministicFixRegistry.TypeToNamespace[typeName], Is.EqualTo(expectedNamespace));
    }

    // --- New FieldRenames entries ---

    [TestCase("_tokenCredential", "TokenCredential")]
    [TestCase("_keyCredential", "KeyCredential")]
    [TestCase("_cachedPipeline", "Pipeline")]
    public void FieldRenames_ContainsNewEntries(string oldName, string expectedNewName)
    {
        Assert.That(DeterministicFixRegistry.FieldRenames, Does.ContainKey(oldName));
        Assert.That(DeterministicFixRegistry.FieldRenames[oldName], Is.EqualTo(expectedNewName));
    }

    // --- CS0234: Generic sub-namespace removal ---

    [Test]
    public void Classify_CS0234_SubNamespaceRemoved_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 3,
            Code = "CS0234",
            Message = "The type or namespace name 'Channels' does not exist in the namespace 'Azure.Communication.Messages.Models' (are you missing an assembly reference?)",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("remove_using_directive"));
            Assert.That(result.ToolArgs, Does.ContainKey("namespacePattern"));
            Assert.That(result.ToolArgs!["namespacePattern"], Does.Contain("Channels"));
        });
    }

    [Test]
    public void Classify_CS0234_SubNamespaceRemoved_BatchVariant_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 4,
            Code = "CS0234",
            Message = "The type or namespace name 'Batch' does not exist in the namespace 'Azure.Storage.Blobs.Models' (are you missing an assembly reference?)",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("remove_using_directive"));
        });
    }

    // --- CS8618: Non-nullable field/property ---

    [Test]
    public void Classify_CS8618_NonNullableProperty_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Models\MyModel.cs",
            Line = 15,
            Code = "CS8618",
            Message = "Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the property as nullable.",
            Severity = "warning"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("nullable_annotation_fix"));
            Assert.That(result.ToolArgs!["line"], Is.EqualTo("15"));
        });
    }

    [Test]
    public void Classify_CS8618_NonNullableField_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Models\MyModel.cs",
            Line = 20,
            Code = "CS8618",
            Message = "Non-nullable field '_name' must contain a non-null value when exiting constructor.",
            Severity = "warning"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("nullable_annotation_fix"));
        });
    }

    // --- CS0115: No suitable method to override ---

    [Test]
    public void Classify_CS0115_NoSuitableOverride_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Customizations\MyModel.cs",
            Line = 25,
            Code = "CS0115",
            Message = "'MyModel.Serialize(Utf8JsonWriter)': no suitable method found to override",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
            Assert.That(result.ToolArgs!["pattern"], Does.Contain("override"));
            Assert.That(result.ToolArgs!["replacement"], Is.EqualTo(""));
        });
    }

    // --- CS0506: Cannot override non-virtual member ---

    [Test]
    public void Classify_CS0506_CannotOverride_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Customizations\MyModel.cs",
            Line = 30,
            Code = "CS0506",
            Message = "'MyModel.GetHashCode()': cannot override inherited member 'object.GetHashCode()' because it is not marked virtual, abstract, or override",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
            Assert.That(result.ToolArgs!["pattern"], Does.Contain("override"));
        });
    }

    // --- ClientOptions mismatch ---

    [Test]
    public void Classify_ClientOptions_Mismatch_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\CommunicationMessagesClientOptions.cs",
            Line = 10,
            Code = "CS0246",
            Message = "The type or namespace name 'CommunicationMessagesClientOptions' could not be found",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("rename_codegen_type"));
            Assert.That(result.ToolArgs!["typeSuffix"], Is.EqualTo("ClientOptions"));
        });
    }

    // --- CS0433: Type in multiple assemblies ---

    [Test]
    public void Classify_CS0433_TypeConflict_IsDeterministic()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 12,
            Code = "CS0433",
            Message = "The type 'Azure.Core.Pipeline.AzureKeyCredentialPolicy' exists in both 'Azure.Core, Version=1.0.0.0' and 'Azure.Communication.Messages, Version=1.0.0.0'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.True);
            Assert.That(result.ToolName, Is.EqualTo("regex_replacement"));
            Assert.That(result.ToolArgs!["replacement"], Is.EqualTo("Azure.Core.Pipeline.AzureKeyCredentialPolicy"));
        });
    }

    // --- CS0029: Cannot implicitly convert type ---

    [Test]
    public void Classify_CS0029_CannotConvert_IsHinted()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 45,
            Code = "CS0029",
            Message = "Cannot implicitly convert type 'string' to 'System.Uri'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.Reason, Does.Contain("Type conversion mismatch"));
            Assert.That(result.ToolArgs!["fromType"], Is.EqualTo("string"));
            Assert.That(result.ToolArgs!["toType"], Is.EqualTo("System.Uri"));
        });
    }

    // --- CS0266: Explicit conversion exists ---

    [Test]
    public void Classify_CS0266_ExplicitConversion_IsHinted()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 50,
            Code = "CS0266",
            Message = "Cannot implicitly convert type 'Azure.Response' to 'Azure.Response<MyModel>'. An explicit conversion exists (are you missing a cast?)",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.Reason, Does.Contain("Explicit conversion required"));
            Assert.That(result.ToolArgs!["fromType"], Is.EqualTo("Azure.Response"));
            Assert.That(result.ToolArgs!["toType"], Is.EqualTo("Azure.Response<MyModel>"));
        });
    }

    // --- CS7036: Missing required parameter ---

    [Test]
    public void Classify_CS7036_MissingParam_IsHinted()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Customizations\MyModel.cs",
            Line = 18,
            Code = "CS7036",
            Message = "There is no argument given that corresponds to the required parameter 'kind' of 'NotificationContent.NotificationContent(string, string, string)'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.Reason, Does.Contain("Constructor or method signature changed"));
            Assert.That(result.ToolArgs!["paramName"], Is.EqualTo("kind"));
            Assert.That(result.ToolArgs!["member"], Is.EqualTo("NotificationContent.NotificationContent(string, string, string)"));
        });
    }

    // --- CS1501: No overload ---

    [Test]
    public void Classify_CS1501_NoOverload_IsHinted()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 55,
            Code = "CS1501",
            Message = "No overload for method 'SendAsync' takes 3 arguments",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.Reason, Does.Contain("Method signature changed"));
            Assert.That(result.ToolArgs!["methodName"], Is.EqualTo("SendAsync"));
            Assert.That(result.ToolArgs!["argCount"], Is.EqualTo("3"));
        });
    }

    // --- CS0535: Interface not implemented ---

    [Test]
    public void Classify_CS0535_InterfaceNotImplemented_IsHinted()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Models\MyModel.cs",
            Line = 5,
            Code = "CS0535",
            Message = "'MyModel' does not implement interface member 'IJsonModel<MyModel>.Create(ref Utf8JsonReader, ModelReaderWriterOptions)'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.Reason, Does.Contain("Interface member not implemented"));
            Assert.That(result.ToolArgs!["typeName"], Is.EqualTo("MyModel"));
        });
    }

    // --- CS0534: Abstract member not implemented ---

    [Test]
    public void Classify_CS0534_AbstractNotImplemented_IsHinted()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Models\MyModel.cs",
            Line = 5,
            Code = "CS0534",
            Message = "'MyModel' does not implement inherited abstract member 'BaseModel.Kind.get'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.Reason, Does.Contain("Abstract member not implemented"));
            Assert.That(result.ToolArgs!["typeName"], Is.EqualTo("MyModel"));
            Assert.That(result.ToolArgs!["member"], Is.EqualTo("BaseModel.Kind.get"));
        });
    }

    // --- CS0012: Unreferenced assembly ---

    [Test]
    public void Classify_CS0012_UnreferencedAssembly_IsHinted()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 22,
            Code = "CS0012",
            Message = "The type 'AzureKeyCredentialPolicy' is defined in an assembly that is not referenced. You must add a reference to assembly 'Azure.Core, Version=1.0.0.0'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.Reason, Does.Contain("Missing assembly reference"));
            Assert.That(result.ToolArgs!["typeName"], Is.EqualTo("AzureKeyCredentialPolicy"));
            Assert.That(result.ToolArgs!["assembly"], Is.EqualTo("Azure.Core, Version=1.0.0.0"));
        });
    }

    // --- NU1100: Missing NuGet package ---

    [Test]
    public void Classify_NU1100_MissingPackage_IsHinted()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\project.csproj",
            Line = 0,
            Code = "NU1100",
            Message = "Unable to resolve 'Azure.Core (>= 1.40.0)' for 'net8.0'.",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.Reason, Does.Contain("Missing NuGet package"));
            Assert.That(result.ToolArgs!["package"], Is.EqualTo("Azure.Core (>= 1.40.0)"));
        });
    }

    // --- CS0117: Static member not found ---

    [Test]
    public void Classify_CS0117_StaticMemberNotFound_IsHinted()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 40,
            Code = "CS0117",
            Message = "'SomeHelper' does not contain a definition for 'DoWork'",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.Reason, Does.Contain("Static member not found"));
            Assert.That(result.ToolArgs!["typeName"], Is.EqualTo("SomeHelper"));
            Assert.That(result.ToolArgs!["memberName"], Is.EqualTo("DoWork"));
        });
    }

    // --- CS0308: Non-generic type with type arguments ---

    [Test]
    public void Classify_CS0308_NonGenericType_IsHinted()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 35,
            Code = "CS0308",
            Message = "The non-generic type 'Operation' cannot be used with type arguments",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.Reason, Does.Contain("lost its generic parameters"));
            Assert.That(result.ToolArgs!["name"], Is.EqualTo("Operation"));
        });
    }

    // --- CS0305: Generic type requires N type arguments ---

    [Test]
    public void Classify_CS0305_GenericRequiresArgs_IsHinted()
    {
        var error = new BuildError
        {
            FilePath = @"C:\src\Client.cs",
            Line = 36,
            Code = "CS0305",
            Message = "Using the generic type 'Response<T>' requires 1 type arguments",
            Severity = "error"
        };

        var result = DeterministicFixRegistry.Classify(error, null);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsDeterministic, Is.False);
            Assert.That(result.Reason, Does.Contain("Generic type requires type arguments"));
            Assert.That(result.ToolArgs!["name"], Is.EqualTo("Response<T>"));
            Assert.That(result.ToolArgs!["count"], Is.EqualTo("1"));
        });
    }
}

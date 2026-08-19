// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers
{
    internal class ResourceMethodSnippetsTests
    {
        [SetUp]
        public void SetUp()
        {
            ManagementMockHelpers.LoadMockPlugin();
        }

        [Test]
        public void CreateGenericResponsePipelineProcessing_WithListOfKnownManagementType_UsesContextModelReaderWriterPerElement()
        {
            // Arrange: IReadOnlyList<OperationStatusResult> — a list whose element is a *known* Azure.ResourceManager
            // framework type (not a locally generated model). The collection itself is built inline (no MRW on the
            // list), while each element is deserialized via the AOT-safe context ModelReaderWriter.Read<T> overload.
            var messageVar = new VariableExpression(typeof(Azure.Core.HttpMessage), "message");
            var contextVar = new VariableExpression(typeof(Azure.RequestContext), "context");
            CSharpType responseType = new CSharpType(typeof(IReadOnlyList<>), typeof(OperationStatusResult));

            // Act
            var statements = ResourceMethodSnippets.CreateGenericResponsePipelineProcessing(
                messageVar,
                contextVar,
                responseType,
                isAsync: false,
                out _);

            // Assert
            var code = string.Join("\n", statements.Select(s => s.ToDisplayString()));
            Assert.That(code, Does.Contain("JsonDocument.Parse(result.Content"),
                "The list response should be parsed inline with JsonDocument.");
            Assert.That(code, Does.Contain("EnumerateArray()"),
                "The list should be built by enumerating the JSON array.");
            Assert.That(code, Does.Not.Contain("ModelReaderWriter.Read<global::System.Collections.Generic.IReadOnlyList"),
                "The collection itself must not go through ModelReaderWriter.Read.");
            Assert.That(code, Does.Contain("ModelReaderWriter.Read<global::Azure.ResourceManager.Models.OperationStatusResult>"),
                "Each known-management-type element should be deserialized via ModelReaderWriter.Read<T>.");
            Assert.That(code, Does.Contain("Context.Default"),
                "Element deserialization must use the AOT-safe context overload.");
        }

        [Test]
        public void CreateGenericResponsePipelineProcessing_WithFrameworkType_DoesNotUseFromResponse()
        {
            // Arrange: OperationStatusResult is a framework/system type from Azure.ResourceManager
            // that does NOT have a static FromResponse method.
            var messageVar = new VariableExpression(typeof(Azure.Core.HttpMessage), "message");
            var contextVar = new VariableExpression(typeof(Azure.RequestContext), "context");
            CSharpType responseType = typeof(OperationStatusResult);
            Assert.That(responseType.IsFrameworkType, Is.True, "OperationStatusResult should be a framework type");

            // Act
            var statements = ResourceMethodSnippets.CreateGenericResponsePipelineProcessing(
                messageVar,
                contextVar,
                responseType,
                isAsync: false,
                out _);

            // Assert: the generated code should use ModelReaderWriter.Read, not FromResponse
            var code = string.Join("\n", statements.Select(s => s.ToDisplayString()));
            Assert.That(code, Does.Not.Contain(".FromResponse(result)"),
                "Framework/system types like OperationStatusResult should not use T.FromResponse(result) — they don't have that method.");
            Assert.That(code, Does.Contain("ModelReaderWriter"),
                "Framework/system model types should be deserialized using ModelReaderWriter.Read<T>.");
            Assert.That(code, Does.Not.Contain("ModelReaderWriter.Read<OperationStatusResult>(result.Content)"),
                "The contextless ModelReaderWriter.Read<T>(BinaryData) overload is AOT-incompatible (IL2026/IL3050); the context overload must be used.");
            Assert.That(code, Does.Contain("WireOptions"),
                "The AOT-safe ModelReaderWriter.Read overload requires ModelReaderWriterOptions (WireOptions).");
        }

        [Test]
        public void CreateGenericResponsePipelineProcessing_WithDictionaryOfBinaryData_UsesInlineJsonDeserialization()
        {
            // Arrange: IDictionary<string, BinaryData> is produced from a TypeSpec `Record<unknown>` body.
            // It is not IPersistableModel<T>, so ModelReaderWriter.Read<T> is both AOT-incompatible (IL2026/IL3050)
            // and incorrect at runtime. The generator must emit inline JSON deserialization instead.
            var messageVar = new VariableExpression(typeof(Azure.Core.HttpMessage), "message");
            var contextVar = new VariableExpression(typeof(Azure.RequestContext), "context");
            CSharpType responseType = new CSharpType(typeof(IDictionary<,>), typeof(string), typeof(BinaryData));

            // Act
            var statements = ResourceMethodSnippets.CreateGenericResponsePipelineProcessing(
                messageVar,
                contextVar,
                responseType,
                isAsync: false,
                out _);

            // Assert
            var code = string.Join("\n", statements.Select(s => s.ToDisplayString()));
            Assert.That(code, Does.Not.Contain("ModelReaderWriter"),
                "IDictionary<string, BinaryData> does not implement IPersistableModel<T>, so ModelReaderWriter.Read must not be used.");
            Assert.That(code, Does.Contain("JsonDocument.Parse(result.Content"),
                "Dictionary responses should be parsed inline with JsonDocument.");
            Assert.That(code, Does.Contain("EnumerateObject()"),
                "Dictionary responses should be built by enumerating the JSON object.");
            Assert.That(code, Does.Contain("BinaryData.FromString"),
                "Each Record<unknown> value should be materialized via BinaryData.FromString.");
        }

        [Test]
        public void CreateGenericResponsePipelineProcessing_WithListOfBinaryData_UsesInlineJsonDeserialization()
        {
            // Arrange: IReadOnlyList<BinaryData> (e.g. a `Record<unknown>[]`-shaped body) is not
            // IPersistableModel<T>; it must be built inline by enumerating the JSON array.
            var messageVar = new VariableExpression(typeof(Azure.Core.HttpMessage), "message");
            var contextVar = new VariableExpression(typeof(Azure.RequestContext), "context");
            CSharpType responseType = new CSharpType(typeof(IReadOnlyList<>), typeof(BinaryData));

            // Act
            var statements = ResourceMethodSnippets.CreateGenericResponsePipelineProcessing(
                messageVar,
                contextVar,
                responseType,
                isAsync: false,
                out _);

            // Assert
            var code = string.Join("\n", statements.Select(s => s.ToDisplayString()));
            Assert.That(code, Does.Not.Contain("ModelReaderWriter"),
                "IReadOnlyList<BinaryData> does not implement IPersistableModel<T>, so ModelReaderWriter.Read must not be used.");
            Assert.That(code, Does.Contain("JsonDocument.Parse(result.Content"),
                "List responses should be parsed inline with JsonDocument.");
            Assert.That(code, Does.Contain("EnumerateArray()"),
                "List responses should be built by enumerating the JSON array.");
            Assert.That(code, Does.Contain("BinaryData.FromString"),
                "Each list element should be materialized via BinaryData.FromString.");
        }

        [Test]
        public void CreateGenericResponsePipelineProcessing_WithNestedDictionaryOfList_UsesRecursiveInlineJsonDeserialization()
        {
            // Arrange: IDictionary<string, IList<BinaryData>> exercises the recursive deserializer
            // (object enumeration on the outside, array enumeration on the inside).
            var messageVar = new VariableExpression(typeof(Azure.Core.HttpMessage), "message");
            var contextVar = new VariableExpression(typeof(Azure.RequestContext), "context");
            CSharpType responseType = new CSharpType(
                typeof(IDictionary<,>),
                typeof(string),
                new CSharpType(typeof(IList<>), typeof(BinaryData)));

            // Act
            var statements = ResourceMethodSnippets.CreateGenericResponsePipelineProcessing(
                messageVar,
                contextVar,
                responseType,
                isAsync: false,
                out _);

            // Assert
            var code = string.Join("\n", statements.Select(s => s.ToDisplayString()));
            Assert.That(code, Does.Not.Contain("ModelReaderWriter"),
                "Nested framework collections do not implement IPersistableModel<T>, so ModelReaderWriter.Read must not be used.");
            Assert.That(code, Does.Contain("EnumerateObject()"),
                "The outer dictionary should be built by enumerating the JSON object.");
            Assert.That(code, Does.Contain("EnumerateArray()"),
                "The inner list should be built by enumerating the JSON array.");
            Assert.That(code, Does.Contain("BinaryData.FromString"),
                "Leaf BinaryData values should be materialized via BinaryData.FromString.");
        }

        [Test]
        public void CreateGenericResponsePipelineProcessing_WithStringType_DoesNotUseContextlessModelReaderWriterRead()
        {
            var messageVar = new VariableExpression(typeof(Azure.Core.HttpMessage), "message");
            var contextVar = new VariableExpression(typeof(Azure.RequestContext), "context");
            CSharpType responseType = typeof(string);

            var statements = ResourceMethodSnippets.CreateGenericResponsePipelineProcessing(
                messageVar,
                contextVar,
                responseType,
                isAsync: false,
                out _);

            var code = string.Join("\n", statements.Select(s => s.ToDisplayString()));
            Assert.That(code, Does.Not.Contain("ModelReaderWriter.Read<string>(result.Content)"));
            Assert.That(code, Does.Contain("JsonDocument.Parse(result.Content"));
            Assert.That(code, Does.Contain("ModelSerializationExtensions.JsonDocumentOptions"));
            Assert.That(code, Does.Contain("RootElement.GetString()"));
        }

        [Test]
        public void CreateGenericResponsePipelineProcessing_WithBinaryData_UsesResultContent()
        {
            // Arrange: BinaryData is the framework type used for `unknown`/bytes-bodied responses
            // (e.g. TypeSpec `Response = ArmResponse<unknown>`). It has no static FromResponse method
            // (causing CS0117) and does not implement IPersistableModel<BinaryData> (causing runtime
            // errors with ModelReaderWriter.Read<BinaryData>). The only correct emission is to use
            // result.Content directly, since the response content is already a BinaryData.
            var messageVar = new VariableExpression(typeof(Azure.Core.HttpMessage), "message");
            var contextVar = new VariableExpression(typeof(Azure.RequestContext), "context");
            CSharpType responseType = typeof(BinaryData);
            Assert.That(responseType.IsFrameworkType, Is.True, "BinaryData should be a framework type");

            // Act
            var statements = ResourceMethodSnippets.CreateGenericResponsePipelineProcessing(
                messageVar,
                contextVar,
                responseType,
                isAsync: false,
                out _);

            // Assert
            var code = string.Join("\n", statements.Select(s => s.ToDisplayString()));
            Assert.That(code, Does.Not.Contain("BinaryData.FromResponse(result)"),
                "BinaryData has no static FromResponse(Response) method — emitting it causes CS0117.");
            Assert.That(code, Does.Not.Contain("ModelReaderWriter"),
                "BinaryData does not implement IPersistableModel<BinaryData>, so ModelReaderWriter.Read<BinaryData> is wrong.");
            Assert.That(code, Does.Contain("result.Content"),
                "For BinaryData responses, the generator should use result.Content directly.");
        }
    }
}

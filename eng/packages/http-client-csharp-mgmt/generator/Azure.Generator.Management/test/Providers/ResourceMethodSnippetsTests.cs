// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
                "Framework/system types should be deserialized using ModelReaderWriter.Read<T>.");
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

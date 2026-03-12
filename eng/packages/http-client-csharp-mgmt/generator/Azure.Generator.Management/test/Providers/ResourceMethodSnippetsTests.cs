// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Snippets;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers
{
    internal class ResourceMethodSnippetsTests
    {
        [Test]
        public void CreateGenericResponsePipelineProcessing_WithFrameworkType_DoesNotUseFromResponse()
        {
            // Arrange: OperationStatusResult is a framework/system type from Azure.ResourceManager
            // that does NOT have a static FromResponse method.
            var messageVar = new VariableExpression(typeof(Azure.Core.HttpMessage), "message");
            var contextVar = new VariableExpression(typeof(Azure.RequestContext), "context");
            CSharpType responseType = typeof(OperationStatusResult);
            Assert.IsTrue(responseType.IsFrameworkType, "OperationStatusResult should be a framework type");

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
    }
}

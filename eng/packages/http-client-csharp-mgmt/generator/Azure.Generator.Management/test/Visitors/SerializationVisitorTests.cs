// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Visitors;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Text.Json;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Mgmt.Tests.Visitors
{
    public class SerializationVisitorTests
    {
        [Test]
        public void UserAssignedIdentityDeserializationUsesModelReaderWriter()
        {
            ManagementMockHelpers.LoadMockPlugin();
            var element = new ParameterProvider("element", $"", typeof(JsonElement)).AsVariable().As<JsonElement>();
            var options = new ParameterProvider("options", $"", typeof(ModelReaderWriterOptions)).AsVariable().As<ModelReaderWriterOptions>();
            var invalidGeneratedExpression = new InvokeMethodExpression(
                Static(typeof(UserAssignedIdentity)),
                "DeserializeUserAssignedIdentity",
                [element, options]);

            var rewrittenExpression = new TestSerializationVisitor().Visit(invalidGeneratedExpression);

            var code = rewrittenExpression!.ToDisplayString();
            Assert.That(code, Does.Contain("ModelReaderWriter.Read<global::Azure.ResourceManager.Models.UserAssignedIdentity>"));
            Assert.That(code, Does.Not.Contain("DeserializeUserAssignedIdentity"));
        }

        private class TestSerializationVisitor : SerializationVisitor
        {
            public ValueExpression? Visit(InvokeMethodExpression expression) => VisitInvokeMethodExpression(expression, null!);
        }
    }
}

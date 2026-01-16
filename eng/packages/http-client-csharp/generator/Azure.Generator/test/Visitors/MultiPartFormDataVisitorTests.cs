// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using NUnit.Framework;

namespace Azure.Generator.Tests.Visitors
{
    public class MultiPartFormDataVisitorTests
    {
        [Test]
        public void UpdatesWriteToMethod()
        {
            var operation = InputFactory.Operation("SomeOperation", requestMediaTypes: ["multipart/form-data"]);
            var serviceMethod = InputFactory.BasicServiceMethod("SomeOperation", operation);
            var client = InputFactory.Client("client", methods: [serviceMethod]);
            var plugin = MockHelpers.LoadMockGenerator(clients: () => [client]);

            var visitor = new TestMultiPartFormDataVisitor();
            visitor.InvokeVisitLibrary(plugin.Object.OutputLibrary);

            var multiPartFormData = plugin.Object.OutputLibrary.TypeProviders.OfType<MultiPartFormDataBinaryContentDefinition>().SingleOrDefault();

            Assert.That(multiPartFormData, Is.Not.Null);
            var writeToMethod = multiPartFormData!.Methods.SingleOrDefault(m => m.Signature.Name == "WriteTo");
            Assert.That(writeToMethod, Is.Not.Null);
            Assert.That(writeToMethod!.BodyStatements!.ToDisplayString(), Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        private class TestMultiPartFormDataVisitor : MultiPartFormDataVisitor
        {
            public void InvokeVisitLibrary(OutputLibrary library)
            {
                base.VisitLibrary(library);
            }
        }
    }
}
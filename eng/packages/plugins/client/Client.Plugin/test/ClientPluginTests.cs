// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator;
using Moq;
using NUnit.Framework;

namespace Client.Plugin.Tests
{
    public class ClientPluginTests
    {
        [Test]
        public void ExpectedVisitorsAreAdded()
        {
            var plugin = new ClientPlugin();
            var mockGenerator = new Mock<CodeModelGenerator>();
            mockGenerator.Setup(g => g.AddVisitor(It.IsAny<NamespaceVisitor>())).Verifiable();
            mockGenerator.Setup(g => g.AddVisitor(It.IsAny<ModelFactoryRenamerVisitor>())).Verifiable();
            mockGenerator.Setup(g => g.AddVisitor(It.IsAny<ClientRequestIdHeaderVisitor>())).Verifiable();
            plugin.Apply(mockGenerator.Object);

            mockGenerator.Verify(g => g.AddVisitor(It.IsAny<NamespaceVisitor>()), Times.Once);
            mockGenerator.Verify(g => g.AddVisitor(It.IsAny<ModelFactoryRenamerVisitor>()), Times.Once);
            mockGenerator.Verify(g => g.AddVisitor(It.IsAny<ClientRequestIdHeaderVisitor>()), Times.Once);
        }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Tests.Visitors
{
    public class ModelFactoryVisitorTests
    {
        [Test]
        public void DataPlaneModelFactoryIsNamedCorrectly()
        {
            var model = InputFactory.Model("SomeModel");
            var plugin = MockHelpers.LoadMockPlugin(inputModels: () => [model], configurationJson: "{ \"package-name\": \"Azure.Messaging.SomeService\" }");

            var visitor = new TestModelFactoryVisitor();
            visitor.InvokeVisitLibrary(plugin.Object.OutputLibrary);

            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().SingleOrDefault();

            Assert.IsNotNull(modelFactory);
            Assert.AreEqual("SomeServiceModelFactory", modelFactory!.Type.Name);
        }

        [Test]
        public void MgmtPlaneModelFactoryIsNamedCorrectly()
        {
            var model = InputFactory.Model("SomeModel");
            var plugin = MockHelpers.LoadMockPlugin(inputModels: () => [model], configurationJson: "{ \"package-name\": \"Azure.ResourceManager.SomeService\" }");

            var visitor = new TestModelFactoryVisitor();
            visitor.InvokeVisitLibrary(plugin.Object.OutputLibrary);

            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().SingleOrDefault();

            Assert.IsNotNull(modelFactory);
            Assert.AreEqual("SomeServiceModelFactory", modelFactory!.Type.Name);
        }

        [Test]
        public void GenericModelFactoryIsNamedCorrectly()
        {
            var model = InputFactory.Model("SomeModel");
            var plugin = MockHelpers.LoadMockPlugin(inputModels: () => [model], configurationJson: "{ \"package-name\": \"Samples\" }");

            var visitor = new TestModelFactoryVisitor();
            visitor.InvokeVisitLibrary(plugin.Object.OutputLibrary);

            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().SingleOrDefault();

            Assert.IsNotNull(modelFactory);
            Assert.AreEqual("SamplesModelFactory", modelFactory!.Type.Name);
        }

        private class TestModelFactoryVisitor : ModelFactoryVisitor
        {
            public void InvokeVisitLibrary(OutputLibrary library)
            {
                base.VisitLibrary(library);
            }
        }
    }
}
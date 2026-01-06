// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;

namespace Azure.Generator.Tests.Visitors
{
    public class ModelFactoryRenamerVisitorTests
    {
        [Test]
        public void DataPlaneModelFactoryIsNamedCorrectly()
        {
            var model = InputFactory.Model("SomeModel");
            var plugin = MockHelpers.LoadMockGenerator(inputModels: () => [model], configurationJson: "{ \"package-name\": \"Azure.Messaging.SomeService\" }");

            var visitor = new TestModelFactoryRenamerVisitor();
            visitor.InvokeVisitLibrary(plugin.Object.OutputLibrary);

            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().SingleOrDefault();

            Assert.That(modelFactory, Is.Not.Null);
            Assert.That(modelFactory!.Type.Name, Is.EqualTo("SomeServiceModelFactory"));
        }

        [Test]
        public void MgmtPlaneModelFactoryIsNamedCorrectly()
        {
            var model = InputFactory.Model("SomeModel");
            var plugin = MockHelpers.LoadMockGenerator(inputModels: () => [model], configurationJson: "{ \"package-name\": \"Azure.ResourceManager.SomeService\" }");

            var visitor = new TestModelFactoryRenamerVisitor();
            visitor.InvokeVisitLibrary(plugin.Object.OutputLibrary);

            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().SingleOrDefault();

            Assert.That(modelFactory, Is.Not.Null);
            Assert.That(modelFactory!.Type.Name, Is.EqualTo("ArmSomeServiceModelFactory"));
        }

        [Test]
        public void GenericModelFactoryIsNamedCorrectly()
        {
            var model = InputFactory.Model("SomeModel");
            var plugin = MockHelpers.LoadMockGenerator(inputModels: () => [model], configurationJson: "{ \"package-name\": \"Samples\" }");

            var visitor = new TestModelFactoryRenamerVisitor();
            visitor.InvokeVisitLibrary(plugin.Object.OutputLibrary);

            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().SingleOrDefault();

            Assert.That(modelFactory, Is.Not.Null);
            Assert.That(modelFactory!.Type.Name, Is.EqualTo("SamplesModelFactory"));
        }

        [Test]
        public void CachedMethodsAreResetAfterRenaming()
        {
            var model = InputFactory.Model("SomeModel");
            var plugin = MockHelpers.LoadMockGenerator(
                inputModels: () => [model],
                configurationJson: "{ \"package-name\": \"Azure.Messaging.SomeService\" }");

            var visitor = new TestModelRenamerVisitor();
            visitor.InvokeVisitLibrary(plugin.Object.OutputLibrary);

            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().SingleOrDefault();
            Assert.That(modelFactory, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(modelFactory!.Methods, Has.Count.EqualTo(1));
                Assert.That(modelFactory.Methods[0].Signature.Name, Is.EqualTo("RenamedModel"));
            });
        }

        private class TestModelRenamerVisitor : ModelFactoryRenamerVisitor
        {
            protected override TypeProvider? VisitType(TypeProvider type)
            {
                if (type is ModelProvider)
                {
                    type.Update(name: "RenamedModel");
                    return type;
                }

                return base.VisitType(type);
            }

            public void InvokeVisitLibrary(OutputLibrary library)
            {
                base.VisitLibrary(library);
            }
        }

        private class TestModelFactoryRenamerVisitor : ModelFactoryRenamerVisitor
        {
            public void InvokeVisitLibrary(OutputLibrary library)
            {
                base.VisitLibrary(library);
            }
        }
    }
}
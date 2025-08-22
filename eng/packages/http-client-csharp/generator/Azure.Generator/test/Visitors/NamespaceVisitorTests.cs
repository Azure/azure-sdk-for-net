// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;

namespace Azure.Generator.Tests.Visitors
{
    public class NamespaceVisitorTests
    {
        [Test]
        public void UpdatesNamespaceForModel()
        {
            MockHelpers.LoadMockGenerator(configurationJson: "{ \"package-name\": \"TestLibrary\", \"model-namespace\": true }");
            var visitor = new TestNamespaceVisitor();
            var inputType = InputFactory.Model("TestModel", "Samples");
            var model = new ModelProvider(inputType);
            var updatedModel = visitor.InvokePreVisitModel(inputType, model);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual("Samples.Models", updatedModel!.Type.Namespace);
        }

        [Test]
        public void DoesNotUseModelsNamespaceIfConfigSetToFalse()
        {
            MockHelpers.LoadMockGenerator(configurationJson: "{ \"package-name\": \"TestLibrary\", \"model-namespace\": false }");
            var visitor = new TestNamespaceVisitor();
            var inputType = InputFactory.Model("TestModel", "Samples");
            var model = new ModelProvider(inputType);
            var updatedModel = visitor.InvokePreVisitModel(inputType, model);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual("Samples", updatedModel!.Type.Namespace);
        }

        [Test]
        public void MovesModelsOutOfModelsDirectory()
        {
            MockHelpers.LoadMockGenerator(configurationJson: "{ \"package-name\": \"TestLibrary\", \"model-namespace\": false }");
            var visitor = new TestNamespaceVisitor();
            var inputType = InputFactory.Model("TestModel", "Samples");
            var model = new ModelProvider(inputType);
            var updatedModel = visitor.InvokePreVisitModel(inputType, model);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual(
                $"src{Path.DirectorySeparatorChar}Generated{Path.DirectorySeparatorChar}{updatedModel!.Name}.cs",
                updatedModel.RelativeFilePath);
        }

        [Test]
        public void DoesNotMoveModelIfNotInModelsDirectory()
        {
            MockHelpers.LoadMockGenerator(configurationJson: "{ \"package-name\": \"TestLibrary\", \"model-namespace\": false }");
            var visitor = new TestNamespaceVisitor();
            var inputType = InputFactory.Model("TestModels", "Samples");
            var model = new ModelProvider(inputType);

            model.Update(relativeFilePath: $"src{Path.DirectorySeparatorChar}Generated{Path.DirectorySeparatorChar}{model.Name}.cs");
            var updatedModel = visitor.InvokePreVisitModel(inputType, model);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual(
                $"src{Path.DirectorySeparatorChar}Generated{Path.DirectorySeparatorChar}{updatedModel!.Name}.cs",
                updatedModel.RelativeFilePath);
        }

        [Test]
        public void DoesNotChangeNamespaceOfCustomizedModel()
        {
            MockHelpers.LoadMockGenerator(configurationJson: "{ \"package-name\": \"TestLibrary\", \"model-namespace\": true }");
            var visitor = new TestNamespaceVisitor();
            var inputType = InputFactory.Model("TestModel", "Samples");
            var model = new ModelProvider(inputType);

            // simulate a customized model
            MockHelpers.SetCustomCodeView(model, new TestTypeProvider());
            var updatedModel = visitor.InvokePreVisitModel(inputType, model);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual("Samples", updatedModel!.Type.Namespace);
        }

        [Test]
        public void DoesNotUseModelsNamespaceIfConfigNotSet()
        {
            MockHelpers.LoadMockGenerator();
            var visitor = new TestNamespaceVisitor();
            var inputType = InputFactory.Model("TestModel", "Samples");
            var model = new ModelProvider(inputType);
            var updatedModel = visitor.InvokePreVisitModel(inputType, model);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual("Samples", updatedModel!.Type.Namespace);
        }

        private class TestNamespaceVisitor : NamespaceVisitor
        {
            public ModelProvider? InvokePreVisitModel(InputModelType inputType, ModelProvider? type)
            {
                return base.PreVisitModel(inputType, type);
            }
        }

        private class TestTypeProvider : TypeProvider
        {
            protected override string BuildNamespace() => "Samples";

            protected override string BuildRelativeFilePath() => $"{Name}.cs";

            protected override string BuildName() => "TestModel";
        }
    }
}
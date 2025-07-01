// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Client.Plugin.Tests.Common;
using Client.Plugin.Tests.TestHelpers;
using Client.Plugin.Visitors;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Client.Plugin.Tests.Visitors
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
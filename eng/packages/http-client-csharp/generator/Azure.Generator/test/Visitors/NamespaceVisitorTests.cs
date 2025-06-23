// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Tests.Visitors
{
    public class NamespaceVisitorTests
    {
        [Test]
        public void UpdatesNamespaceForModel()
        {
            MockHelpers.LoadMockPlugin(configurationJson: "{ \"package-name\": \"TestLibrary\", \"model-namespace\": true }");
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
            MockHelpers.LoadMockPlugin(configurationJson: "{ \"package-name\": \"TestLibrary\", \"model-namespace\": false }");
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
            MockHelpers.LoadMockPlugin(configurationJson: "{ \"package-name\": \"TestLibrary\", \"model-namespace\": true }");
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
            MockHelpers.LoadMockPlugin();
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
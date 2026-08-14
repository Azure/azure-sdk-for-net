// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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
        public void UpdatesNamespaceForEnum()
        {
            MockHelpers.LoadMockGenerator(configurationJson: "{ \"package-name\": \"TestLibrary\", \"model-namespace\": true }");
            var visitor = new TestNamespaceVisitor();
            List<string> valueList = ["foo", "bar"];
            var enumValues = valueList.Select(a => (a, a));
            var inputEnum = InputFactory.StringEnum(
                "TestEnum",
                values: enumValues,
                clientNamespace: "Samples");
            var enumProvider = EnumProvider.Create(inputEnum);
            var updatedEnum = visitor.InvokePreVisitEnum(inputEnum, enumProvider);

            Assert.IsNotNull(updatedEnum);
            Assert.AreEqual("Samples.Models", updatedEnum!.Type.Namespace);
        }

        [Test]
        public void DoNotUpdateNamespaceForEnumUsingVisitType()
        {
            MockHelpers.LoadMockGenerator(configurationJson: "{ \"package-name\": \"TestLibrary\", \"model-namespace\": true }");
            var visitor = new TestNamespaceVisitor();
            List<string> valueList = ["foo", "bar"];
            var enumValues = valueList.Select(a => (a, a));
            var inputEnum = InputFactory.StringEnum(
                "TestEnum",
                values: enumValues,
                clientNamespace: "Samples");
            var enumProvider = EnumProvider.Create(inputEnum);
            var updatedEnum = visitor.InvokeVisitType(enumProvider);

            Assert.IsNotNull(updatedEnum);
            Assert.AreEqual("Samples", updatedEnum!.Type.Namespace);
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
        public void DoesNotChangeNamespaceOfFormatEnum()
        {
            MockHelpers.LoadMockGenerator(configurationJson: "{ \"package-name\": \"TestLibrary\", \"model-namespace\": true }");
            var visitor = new TestNamespaceVisitor();
            var type = new SerializationFormatDefinition();

            var updatedType = visitor.InvokeVisitType(type);

            Assert.IsNotNull(updatedType);
            Assert.AreEqual("Samples", updatedType!.Type.Namespace);
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
        public void UpdatesNamespaceForModelInSubNamespace()
        {
            MockHelpers.LoadMockGenerator(configurationJson: "{ \"package-name\": \"TestLibrary\", \"model-namespace\": true }");
            var visitor = new TestNamespaceVisitor();
            var inputType = InputFactory.Model("TestModel", "Samples.SubNamespace");
            var model = new ModelProvider(inputType);
            var updatedModel = visitor.InvokePreVisitModel(inputType, model);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual("Samples.SubNamespace.Models", updatedModel!.Type.Namespace);
        }

        [Test]
        public void UpdatesNamespaceForEnumInSubNamespace()
        {
            MockHelpers.LoadMockGenerator(configurationJson: "{ \"package-name\": \"TestLibrary\", \"model-namespace\": true }");
            var visitor = new TestNamespaceVisitor();
            List<string> valueList = ["foo", "bar"];
            var enumValues = valueList.Select(a => (a, a));
            var inputEnum = InputFactory.StringEnum(
                "TestEnum",
                values: enumValues,
                clientNamespace: "Samples.SubNamespace");
            var enumProvider = EnumProvider.Create(inputEnum);
            var updatedEnum = visitor.InvokePreVisitEnum(inputEnum, enumProvider);

            Assert.IsNotNull(updatedEnum);
            Assert.AreEqual("Samples.SubNamespace.Models", updatedEnum!.Type.Namespace);
        }

        [Test]
        public void DoesNotAppendModelsIfNamespaceAlreadyEndsWithModels()
        {
            MockHelpers.LoadMockGenerator(configurationJson: "{ \"package-name\": \"TestLibrary\", \"model-namespace\": true }");
            var visitor = new TestNamespaceVisitor();
            var inputType = InputFactory.Model("TestModel", "Samples.Models");
            var model = new ModelProvider(inputType);
            var updatedModel = visitor.InvokePreVisitModel(inputType, model);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual("Samples.Models", updatedModel!.Type.Namespace);
        }

        [Test]
        public void DoesNotAppendModelsIfNamespaceAlreadyEndsWithModelsForEnum()
        {
            MockHelpers.LoadMockGenerator(configurationJson: "{ \"package-name\": \"TestLibrary\", \"model-namespace\": true }");
            var visitor = new TestNamespaceVisitor();
            List<string> valueList = ["foo", "bar"];
            var enumValues = valueList.Select(a => (a, a));
            var inputEnum = InputFactory.StringEnum(
                "TestEnum",
                values: enumValues,
                clientNamespace: "Samples.Models");
            var enumProvider = EnumProvider.Create(inputEnum);
            var updatedEnum = visitor.InvokePreVisitEnum(inputEnum, enumProvider);

            Assert.IsNotNull(updatedEnum);
            Assert.AreEqual("Samples.Models", updatedEnum!.Type.Namespace);
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

            public TypeProvider? InvokeVisitType(TypeProvider type)
            {
                return base.VisitType(type);
            }

            public EnumProvider? InvokePreVisitEnum(InputEnumType enumType, EnumProvider? type)
            {
                return base.PreVisitEnum(enumType, type);
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
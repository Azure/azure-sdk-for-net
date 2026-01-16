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

            Assert.That(updatedModel, Is.Not.Null);
            Assert.That(updatedModel!.Type.Namespace, Is.EqualTo("Samples.Models"));
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

            Assert.That(updatedEnum, Is.Not.Null);
            Assert.That(updatedEnum!.Type.Namespace, Is.EqualTo("Samples.Models"));
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

            Assert.That(updatedEnum, Is.Not.Null);
            Assert.That(updatedEnum!.Type.Namespace, Is.EqualTo("Samples"));
        }

        [Test]
        public void DoesNotUseModelsNamespaceIfConfigSetToFalse()
        {
            MockHelpers.LoadMockGenerator(configurationJson: "{ \"package-name\": \"TestLibrary\", \"model-namespace\": false }");
            var visitor = new TestNamespaceVisitor();
            var inputType = InputFactory.Model("TestModel", "Samples");
            var model = new ModelProvider(inputType);
            var updatedModel = visitor.InvokePreVisitModel(inputType, model);

            Assert.That(updatedModel, Is.Not.Null);
            Assert.That(updatedModel!.Type.Namespace, Is.EqualTo("Samples"));
        }

        [Test]
        public void DoesNotChangeNamespaceOfFormatEnum()
        {
            MockHelpers.LoadMockGenerator(configurationJson: "{ \"package-name\": \"TestLibrary\", \"model-namespace\": true }");
            var visitor = new TestNamespaceVisitor();
            var type = new SerializationFormatDefinition();

            var updatedType = visitor.InvokeVisitType(type);

            Assert.That(updatedType, Is.Not.Null);
            Assert.That(updatedType!.Type.Namespace, Is.EqualTo("Samples"));
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

            Assert.That(updatedModel, Is.Not.Null);
            Assert.That(updatedModel!.Type.Namespace, Is.EqualTo("Samples"));
        }

        [Test]
        public void DoesNotUseModelsNamespaceIfConfigNotSet()
        {
            MockHelpers.LoadMockGenerator();
            var visitor = new TestNamespaceVisitor();
            var inputType = InputFactory.Model("TestModel", "Samples");
            var model = new ModelProvider(inputType);
            var updatedModel = visitor.InvokePreVisitModel(inputType, model);

            Assert.That(updatedModel, Is.Not.Null);
            Assert.That(updatedModel!.Type.Namespace, Is.EqualTo("Samples"));
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
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Tests.Visitors
{
    public class SystemTextJsonConverterVisitorTests
    {
        [Test]
        public void AddsJsonConverterAttributeWhenDecoratorPresent()
        {
            // Arrange
            var visitor = new TestSystemTextJsonConverterVisitor();
            var decorator = new InputDecoratorInfo("Azure.ClientGenerator.Core.@useSystemTextJsonConverter", null);
            var inputModel = InputFactory.Model("TestModel", decorators: [decorator]);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            // Act
            var updatedModel = visitor.InvokePreVisitModel(inputModel, modelProvider);

            // Assert
            Assert.IsNotNull(updatedModel);
            var serializationProvider = updatedModel!.SerializationProviders[0];
            Assert.IsNotNull(serializationProvider);

            // Check that JsonConverter attribute is added
            var jsonConverterAttribute = serializationProvider.Attributes
                .FirstOrDefault(a => a.Type.Name == nameof(JsonConverter));
            Assert.IsNotNull(jsonConverterAttribute, "JsonConverter attribute should be added");

            // Check that converter type is added as nested type
            var converterType = serializationProvider.NestedTypes
                .FirstOrDefault(t => t.Name.EndsWith("Converter"));
            Assert.IsNotNull(converterType, "Converter type should be added as nested type");
            Assert.AreEqual($"{serializationProvider.Name}Converter", converterType!.Name);

            // Converter namespace should match the serialization provider's namespace
            Assert.AreEqual(serializationProvider.Type.Namespace, converterType.Type.Namespace,
                "Converter type should be in the same namespace as the serialization provider");

            // Converter should have the correct declaring type
            Assert.AreEqual(serializationProvider, converterType.DeclaringTypeProvider,
                "Converter type should be declared in the serialization provider");
        }

        [Test]
        public void DoesNotAddConverterWhenDecoratorAbsent()
        {
            // Arrange
            var visitor = new TestSystemTextJsonConverterVisitor();
            var inputModel = InputFactory.Model("TestModel"); // No decorator
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            // Act
            var updatedModel = visitor.InvokePreVisitModel(inputModel, modelProvider);

            // Assert
            Assert.IsNotNull(updatedModel);
            var serializationProvider = updatedModel!.SerializationProviders[0];

            // Check that JsonConverter attribute is not added
            var jsonConverterAttribute = serializationProvider.Attributes
                .FirstOrDefault(a => a.Type.Name == nameof(JsonConverter));
            Assert.IsNull(jsonConverterAttribute, "JsonConverter attribute should not be added without decorator");

            // Check that no converter type is added
            var converterType = serializationProvider.NestedTypes
                .FirstOrDefault(t => t.Name.EndsWith("Converter"));
            Assert.IsNull(converterType, "Converter type should not be added without decorator");
        }

        [Test]
        public void ConverterMethodsHaveCorrectSignatures()
        {
            // Arrange
            var visitor = new TestSystemTextJsonConverterVisitor();
            var decorator = new InputDecoratorInfo("Azure.ClientGenerator.Core.@useSystemTextJsonConverter", null);
            var inputModel = InputFactory.Model("TestModel", decorators: [decorator]);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            // Act
            var updatedModel = visitor.InvokePreVisitModel(inputModel, modelProvider);

            // Assert
            Assert.IsNotNull(updatedModel);
            var serializationProvider = updatedModel!.SerializationProviders[0];
            var converterType = serializationProvider.NestedTypes
                .FirstOrDefault(t => t.Name.EndsWith("Converter"));

            Assert.IsNotNull(converterType);

            // Check Write method signature
            var writeMethod = converterType!.Methods.FirstOrDefault(m => m.Signature.Name == "Write");
            Assert.IsNotNull(writeMethod);
            Assert.AreEqual(3, writeMethod!.Signature.Parameters.Count, "Write method should have 3 parameters");
            Assert.IsTrue(writeMethod.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public),
                "Write method should be public");
            Assert.IsTrue(writeMethod.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Override),
                "Write method should be override");

            // Check Read method signature
            var readMethod = converterType.Methods.FirstOrDefault(m => m.Signature.Name == "Read");
            Assert.IsNotNull(readMethod);
            Assert.AreEqual(3, readMethod!.Signature.Parameters.Count, "Read method should have 3 parameters");
            Assert.IsTrue(readMethod.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public),
                "Read method should be public");
            Assert.IsTrue(readMethod.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Override),
                "Read method should be override");
        }

        [Test]
        public void ReadConverterMethodHasCorrectBody()
        {
            // Arrange
            var visitor = new TestSystemTextJsonConverterVisitor();
            var decorator = new InputDecoratorInfo("Azure.ClientGenerator.Core.@useSystemTextJsonConverter", null);
            var inputModel = InputFactory.Model("TestModel", decorators: [decorator]);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            // Act
            var updatedModel = visitor.InvokePreVisitModel(inputModel, modelProvider);

            // Assert
            Assert.IsNotNull(updatedModel);
            var serializationProvider = updatedModel!.SerializationProviders[0];
            var converterType = serializationProvider.NestedTypes
                .FirstOrDefault(t => t.Name.EndsWith("Converter"));

            Assert.IsNotNull(converterType);

            var readMethod = converterType!.Methods.FirstOrDefault(m => m.Signature.Name == "Read");
            Assert.IsNotNull(readMethod);
            var readMethodBody = readMethod!.BodyStatements!.ToDisplayString();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), readMethodBody);
        }

        [Test]
        public void WriteConverterMethodHasCorrectBody()
        {
            // Arrange
            var visitor = new TestSystemTextJsonConverterVisitor();
            var decorator = new InputDecoratorInfo("Azure.ClientGenerator.Core.@useSystemTextJsonConverter", null);
            var inputModel = InputFactory.Model("TestModel", decorators: [decorator]);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            // Act
            var updatedModel = visitor.InvokePreVisitModel(inputModel, modelProvider);

            // Assert
            Assert.IsNotNull(updatedModel);
            var serializationProvider = updatedModel!.SerializationProviders[0];
            var converterType = serializationProvider.NestedTypes
                .FirstOrDefault(t => t.Name.EndsWith("Converter"));

            Assert.IsNotNull(converterType);

            var writeMethod = converterType!.Methods.FirstOrDefault(m => m.Signature.Name == "Write");
            Assert.IsNotNull(writeMethod);
            var writeMethodBody = writeMethod!.BodyStatements!.ToDisplayString();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), writeMethodBody);
        }

        [Test]
        public void TestMultipleModelsWithDecorator()
        {
            // Arrange
            var visitor = new TestSystemTextJsonConverterVisitor();
            var decorator = new InputDecoratorInfo("Azure.ClientGenerator.Core.@useSystemTextJsonConverter", null);
            var inputModel1 = InputFactory.Model("TestModel1", decorators: [decorator]);
            var inputModel2 = InputFactory.Model("TestModel2", decorators: [decorator]);
            var inputModel3 = InputFactory.Model("TestModel3"); // No decorator

            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel1, inputModel2, inputModel3]);

            var modelProvider1 = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel1);
            var modelProvider2 = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel2);
            var modelProvider3 = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel3);

            // Act
            var updatedModel1 = visitor.InvokePreVisitModel(inputModel1, modelProvider1);
            var updatedModel2 = visitor.InvokePreVisitModel(inputModel2, modelProvider2);
            var updatedModel3 = visitor.InvokePreVisitModel(inputModel3, modelProvider3);

            // Assert
            // Models with decorator should have converter
            Assert.IsTrue(updatedModel1!.SerializationProviders[0].NestedTypes
                .Any(t => t.Name.EndsWith("Converter")));
            Assert.IsTrue(updatedModel2!.SerializationProviders[0].NestedTypes
                .Any(t => t.Name.EndsWith("Converter")));

            // Model without decorator should not have converter
            Assert.IsFalse(updatedModel3!.SerializationProviders[0].NestedTypes
                .Any(t => t.Name.EndsWith("Converter")));
        }

        [Test]
        public void ConverterModelE2E()
        {
            // Arrange
            var decorator = new InputDecoratorInfo("Azure.ClientGenerator.Core.@useSystemTextJsonConverter", null);
            var inputModel = InputFactory.Model("TestModel", decorators: [decorator]);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            // Act
            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            // Assert
            var serializationProvider = modelProvider!.SerializationProviders[0];

            var writer = new TypeProviderWriter(serializationProvider);
            var file = writer.Write();

            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        private class TestSystemTextJsonConverterVisitor : SystemTextJsonConverterVisitor
        {
            public ModelProvider? InvokePreVisitModel(InputModelType inputType, ModelProvider? type)
            {
                return base.PreVisitModel(inputType, type);
            }
        }
    }
}
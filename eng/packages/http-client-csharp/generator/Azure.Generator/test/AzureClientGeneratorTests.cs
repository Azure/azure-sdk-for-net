// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Tests.TestHelpers;
using NUnit.Framework;
using Azure.Generator.Visitors;
using Azure.Generator.Tests.Common;
using Microsoft.TypeSpec.Generator.Input;

namespace Azure.Generator.Tests
{
    public class AzureClientGeneratorTests
    {
        [Test]
        public void RenamingVisitorsAreBeforeOtherVisitors()
        {
            var generator = MockHelpers.LoadMockGenerator();
            var visitors = generator.Object.Visitors;
            Assert.IsNotNull(visitors);

            Assert.IsInstanceOf<ModelFactoryRenamerVisitor>(visitors[0]);
        }

        [Test]
        public void HasDataFactoryElement_ReturnsTrueWhenModelHasDataFactoryElementProperty()
        {
            // Create a model with a property that has DataFactoryElement external type
            var externalType = new InputExternalTypeMetadata("Azure.Core.Expressions.DataFactoryElement", null, null);
            var dfeExpression = InputFactory.Model("DfeExpression");
            var stringType = InputFactory.Primitive.String();
            var unionType = InputFactory.Union("DfeString", [stringType, dfeExpression], externalType);

            var property = InputFactory.Property("TestProperty", unionType);
            var model = InputFactory.Model("TestModel", properties: [property]);

            var generator = MockHelpers.LoadMockGenerator(inputModels: () => [model]);

            Assert.IsTrue(generator.Object.HasDataFactoryElement);
        }

        [Test]
        public void HasDataFactoryElement_ReturnsFalseWhenNoModelHasDataFactoryElementProperty()
        {
            // Create models without DataFactoryElement properties
            var stringProperty = InputFactory.Property("Name", InputFactory.Primitive.String());
            var model = InputFactory.Model("TestModel", properties: [stringProperty]);

            var generator = MockHelpers.LoadMockGenerator(inputModels: () => [model]);

            Assert.IsFalse(generator.Object.HasDataFactoryElement);
        }
    }
}
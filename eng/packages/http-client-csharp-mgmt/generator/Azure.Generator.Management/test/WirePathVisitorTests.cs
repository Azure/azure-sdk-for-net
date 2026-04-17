// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Visitors;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;
using System.Linq;
using System.Reflection;

namespace Azure.Generator.Mgmt.Tests
{
    internal class WirePathVisitorTests
    {
        /// <summary>
        /// Verifies that the WirePathVisitor adds a WirePath attribute to AdditionalProperties
        /// when the model has additional properties (e.g. from ...Record&lt;unknown&gt; spread in TypeSpec),
        /// and that the wire path values are correct for both regular and additional properties.
        /// </summary>
        [Test]
        public void TestWirePathOnAdditionalProperties()
        {
            // Create a model with a regular property and additional properties
            var regularProperty = InputFactory.Property(
                "qnaRuntimeEndpoint",
                InputPrimitiveType.String,
                serializedName: "qnaRuntimeEndpoint");

            var model = InputFactory.Model(
                "ApiProperties",
                properties: [regularProperty],
                additionalProperties: InputPrimitiveType.Any);

            ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model]);

            var modelProvider = ManagementClientGenerator.Instance.TypeFactory.CreateModel(model);
            Assert.IsNotNull(modelProvider);

            // Run the WirePathVisitor on the model
            var wirePathVisitor = new WirePathVisitor();
            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(visitTypeCore, "Could not find LibraryVisitor.VisitTypeCore method");
            visitTypeCore!.Invoke(wirePathVisitor, [modelProvider]);

            // Verify the regular property has WirePath attribute with the serialized name
            var qnaProperty = modelProvider!.Properties.FirstOrDefault(p => p.Name == "QnaRuntimeEndpoint");
            Assert.IsNotNull(qnaProperty, "Expected to find QnaRuntimeEndpoint property");
            var qnaWirePathAttribute = GetWirePathAttribute(qnaProperty!);
            Assert.IsNotNull(qnaWirePathAttribute, "QnaRuntimeEndpoint should have WirePathAttribute");
            Assert.AreEqual(
                "qnaRuntimeEndpoint",
                GetWirePathValue(qnaWirePathAttribute!),
                "QnaRuntimeEndpoint should keep its serialized-name wire path");

            // Verify the AdditionalProperties property has WirePath attribute with the property name
            var additionalPropertiesProperty = modelProvider.Properties.FirstOrDefault(p => p.IsAdditionalProperties);
            Assert.IsNotNull(additionalPropertiesProperty, "Expected to find AdditionalProperties property");
            var additionalPropertiesWirePathAttribute = GetWirePathAttribute(additionalPropertiesProperty!);
            Assert.IsNotNull(additionalPropertiesWirePathAttribute, "AdditionalProperties should have WirePathAttribute");
            Assert.AreEqual(
                "AdditionalProperties",
                GetWirePathValue(additionalPropertiesWirePathAttribute!),
                "AdditionalProperties should use the property name as the wire path");
        }

        /// <summary>
        /// Verifies that the WirePathVisitor adds a WirePath attribute to regular properties
        /// that have WireInfo with the correct serialized name value.
        /// </summary>
        [Test]
        public void TestWirePathAddedToRegularPropertiesWithWireInfo()
        {
            // Create a simple model with a regular property
            var regularProperty = InputFactory.Property(
                "displayName",
                InputPrimitiveType.String,
                serializedName: "displayName");

            var model = InputFactory.Model(
                "TestModel",
                properties: [regularProperty]);

            ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model]);

            var modelProvider = ManagementClientGenerator.Instance.TypeFactory.CreateModel(model);
            Assert.IsNotNull(modelProvider);

            // Run the WirePathVisitor
            var wirePathVisitor = new WirePathVisitor();
            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(visitTypeCore, "Could not find LibraryVisitor.VisitTypeCore method");
            visitTypeCore!.Invoke(wirePathVisitor, [modelProvider]);

            // Verify that regular properties with WireInfo get the attribute with the correct value
            var displayNameProperty = modelProvider!.Properties.FirstOrDefault(p => p.Name == "DisplayName");
            Assert.IsNotNull(displayNameProperty);
            var wirePathAttribute = GetWirePathAttribute(displayNameProperty!);
            Assert.IsNotNull(wirePathAttribute, "DisplayName should have WirePathAttribute since it has WireInfo");
            Assert.AreEqual(
                "displayName",
                GetWirePathValue(wirePathAttribute!),
                "DisplayName should use its serialized name as the wire path");
        }

        private static AttributeStatement? GetWirePathAttribute(PropertyProvider property)
        {
            return property.Attributes.FirstOrDefault(a => a.Type.Name == "WirePathAttribute");
        }

        private static string GetWirePathValue(AttributeStatement attribute)
        {
            Assert.IsTrue(attribute.Arguments.Count > 0, "WirePathAttribute should have at least one argument");
            var argument = attribute.Arguments[0];

            // Snippet.Literal(string) returns ScopedApi<string> wrapping a LiteralExpression
            if (argument is ScopedApi scopedApi)
            {
                argument = scopedApi.Original;
            }

            Assert.IsInstanceOf<LiteralExpression>(argument, "WirePathAttribute argument should be a LiteralExpression");
            var literal = ((LiteralExpression)argument).Literal;
            Assert.IsInstanceOf<string>(literal, "WirePathAttribute argument should be a string literal");
            return (string)literal!;
        }
    }
}

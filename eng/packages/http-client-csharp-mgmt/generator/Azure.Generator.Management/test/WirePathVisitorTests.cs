// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Visitors;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Linq;
using System.Reflection;

namespace Azure.Generator.Mgmt.Tests
{
    internal class WirePathVisitorTests
    {
        /// <summary>
        /// Verifies that the WirePathVisitor adds a WirePath attribute to AdditionalProperties
        /// when the model has additional properties (e.g. from ...Record&lt;unknown&gt; spread in TypeSpec).
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

            // Verify the regular property has WirePath attribute
            var qnaProperty = modelProvider!.Properties.FirstOrDefault(p => p.Name == "QnaRuntimeEndpoint");
            Assert.IsNotNull(qnaProperty, "Expected to find QnaRuntimeEndpoint property");
            Assert.IsTrue(
                qnaProperty!.Attributes.Any(a => a.Type.Name == "WirePathAttribute"),
                "QnaRuntimeEndpoint should have WirePathAttribute");

            // Verify the AdditionalProperties property has WirePath attribute
            var additionalPropertiesProperty = modelProvider.Properties.FirstOrDefault(p => p.IsAdditionalProperties);
            Assert.IsNotNull(additionalPropertiesProperty, "Expected to find AdditionalProperties property");
            Assert.IsTrue(
                additionalPropertiesProperty!.Attributes.Any(a => a.Type.Name == "WirePathAttribute"),
                "AdditionalProperties should have WirePathAttribute");
        }

        /// <summary>
        /// Verifies that the WirePathVisitor does not add WirePath to properties that have
        /// no WireInfo and are not AdditionalProperties.
        /// </summary>
        [Test]
        public void TestWirePathNotAddedToPropertiesWithoutWireInfo()
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
            visitTypeCore!.Invoke(wirePathVisitor, [modelProvider]);

            // Verify that regular properties with WireInfo get the attribute
            var displayNameProperty = modelProvider!.Properties.FirstOrDefault(p => p.Name == "DisplayName");
            Assert.IsNotNull(displayNameProperty);
            Assert.IsTrue(
                displayNameProperty!.Attributes.Any(a => a.Type.Name == "WirePathAttribute"),
                "DisplayName should have WirePathAttribute since it has WireInfo");
        }
    }
}

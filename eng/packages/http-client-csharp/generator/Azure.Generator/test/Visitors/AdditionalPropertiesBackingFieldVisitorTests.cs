// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Tests.Visitors
{
    public class AdditionalPropertiesBackingFieldVisitorTests
    {
        [Test]
        public void AttachesBackingFieldForAdditionalPropertiesProperty()
        {
            // A model with `Record<unknown>` spread produces an additional-properties property
            // whose backing field is `_additionalBinaryDataProperties`. Simulate the bug
            // condition by clearing BackingField on that property and asserting the visitor
            // re-attaches it.
            var inputModel = InputFactory.Model(
                "TestModel",
                properties: [InputFactory.Property("Name", InputPrimitiveType.String)],
                additionalProperties: InputPrimitiveType.Any);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            var rawDataField = modelProvider!.Fields.FirstOrDefault(f => f.Name == "_additionalBinaryDataProperties");
            Assert.IsNotNull(rawDataField, "Expected a raw data field on a model with an additional-properties spread.");

            var additionalProperty = modelProvider.Properties.FirstOrDefault(p => p.IsAdditionalProperties);
            Assert.IsNotNull(additionalProperty, "Expected an additional-properties property.");

            // Clear the backing field to simulate the [CodeGenMember] customization scenario
            // where a user-provided property is merged in without a backing field reference.
            additionalProperty!.BackingField = null;

            var visitor = new TestAdditionalPropertiesBackingFieldVisitor();
            visitor.InvokeVisitLibrary(AzureClientGenerator.Instance.OutputLibrary);

            Assert.AreSame(
                rawDataField,
                additionalProperty.BackingField,
                "Visitor should re-attach the _additionalBinaryDataProperties field as the backing field.");
        }

        [Test]
        public void LeavesExistingBackingFieldUnchanged()
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                properties: [InputFactory.Property("Name", InputPrimitiveType.String)],
                additionalProperties: InputPrimitiveType.Any);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            var additionalProperty = modelProvider!.Properties.FirstOrDefault(p => p.IsAdditionalProperties);
            Assert.IsNotNull(additionalProperty);
            var originalBackingField = additionalProperty!.BackingField;
            Assert.IsNotNull(originalBackingField, "Expected the synthesized property to already have a backing field.");

            var visitor = new TestAdditionalPropertiesBackingFieldVisitor();
            visitor.InvokeVisitLibrary(AzureClientGenerator.Instance.OutputLibrary);

            Assert.AreSame(originalBackingField, additionalProperty.BackingField);
        }

        [Test]
        public void DeserializeMethodUsesConsistentVariableName()
        {
            // End-to-end check: when the backing field is missing on the additional-properties
            // property, the generated Deserialize method produces mismatched identifiers (the
            // local variable name is derived from the property while the catch-all add target
            // is derived from the field). After the visitor runs, both should use the same
            // identifier and the resulting method body should be compilable.
            var inputModel = InputFactory.Model(
                "TestModel",
                properties: [InputFactory.Property("Name", InputPrimitiveType.String)],
                additionalProperties: InputPrimitiveType.Any);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            var additionalProperty = modelProvider!.Properties.FirstOrDefault(p => p.IsAdditionalProperties);
            Assert.IsNotNull(additionalProperty);
            additionalProperty!.BackingField = null;

            var visitor = new TestAdditionalPropertiesBackingFieldVisitor();
            visitor.InvokeVisitLibrary(AzureClientGenerator.Instance.OutputLibrary);

            var serializationProvider = modelProvider.SerializationProviders[0];
            var deserializeMethod = serializationProvider.Methods.FirstOrDefault(m => m.Signature.Name == "DeserializeTestModel");
            Assert.IsNotNull(deserializeMethod, "Expected a DeserializeTestModel method.");

            var body = deserializeMethod!.BodyStatements!.ToDisplayString();

            // The local-variable identifier used for the additional properties bag must be the
            // same in the declaration and in the catch-all add. The bug produced
            // `additionalProperties = new ChangeTrackingDictionary<...>()` paired with
            // `additionalBinaryDataProperties.Add(...)` (CS0103). After the visitor runs, both
            // sites should agree.
            var declarationMatch = System.Text.RegularExpressions.Regex.Match(
                body,
                @"IDictionary<string,\s*global::System\.BinaryData>\s+(?<name>\w+)\s*=\s*new\s+global::[^()]+ChangeTrackingDictionary");
            Assert.IsTrue(declarationMatch.Success, $"Expected an additional-properties dictionary declaration. Body:\n{body}");
            var declarationName = declarationMatch.Groups["name"].Value;

            var addMatch = System.Text.RegularExpressions.Regex.Match(
                body,
                @"(?<name>\w+)\.Add\(prop\.Name,\s*global::System\.BinaryData\.FromString");
            Assert.IsTrue(addMatch.Success, $"Expected a catch-all Add call. Body:\n{body}");
            var addName = addMatch.Groups["name"].Value;

            Assert.AreEqual(
                declarationName,
                addName,
                $"Local declaration ({declarationName}) and catch-all add target ({addName}) must use the same identifier. Body:\n{body}");
        }

        private class TestAdditionalPropertiesBackingFieldVisitor : AdditionalPropertiesBackingFieldVisitor
        {
            public void InvokeVisitLibrary(OutputLibrary library)
            {
                base.VisitLibrary(library);
            }
        }
    }
}
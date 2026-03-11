// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;
using System.Reflection;

namespace Azure.Generator.Mgmt.Tests
{
    internal class FlattenPropertyVisitorTests
    {
        /// <summary>
        /// Verifies that flattening works correctly when the nested properties model
        /// has no public constructor (Output-only usage). Previously this crashed with
        /// "Sequence contains no matching element" because UpdatePublicConstructorBody
        /// unconditionally passed publicConstructor: true to BuildConstructorParameters.
        /// </summary>
        [Test]
        public void TestFlattenWithNoPublicConstructorOnNestedModel()
        {
            // Create a nested "properties" model with Output-only usage.
            // Output-only models don't get a public constructor — only an internal FullConstructor.
            var innerProperty = InputFactory.Property("displayName", InputPrimitiveType.String, isRequired: true, serializedName: "displayName");
            var propertiesModel = InputFactory.Model(
                "TestProperties",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties: [innerProperty]);

            // Create a property on the parent model referencing the properties model,
            // then apply the @flattenProperty decorator to it.
            var propertiesProperty = InputFactory.Property("properties", propertiesModel, isRequired: true, serializedName: "properties");
            ApplyFlattenDecorator(propertiesProperty);

            // Create the parent model with Input+Output usage so it gets a public constructor.
            var parentModel = InputFactory.Model(
                "TestResource",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [propertiesProperty]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [parentModel, propertiesModel]);

            // Create the model provider (this runs PreVisit* visitors only).
            var model = plugin.Object.TypeFactory.CreateModel(parentModel);
            Assert.IsNotNull(model);

            // Verify the Output-only nested model has no public constructor (precondition).
            var nestedModel = plugin.Object.TypeFactory.CreateModel(propertiesModel);
            Assert.IsNotNull(nestedModel);
            Assert.IsFalse(
                nestedModel!.Constructors.Any(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)),
                "Precondition: Output-only nested model should have no public constructor");

            // Now run the VisitType visitors on the parent model.
            // FlattenPropertyVisitor.VisitType() processes @flattenProperty decorators and
            // calls BuildConstructorParameters on the nested model. The fix checks whether
            // the nested model has a public constructor and falls back to FullConstructor
            // when it does not. Without the fix, this throws InvalidOperationException:
            // "Sequence contains no matching element" from .First().
            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(visitTypeCore, "Could not find LibraryVisitor.VisitTypeCore method");

            Assert.DoesNotThrow(() =>
            {
                foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
                {
                    visitTypeCore!.Invoke(visitor, [model]);
                }
            });
        }

        private static void ApplyFlattenDecorator(InputModelProperty property)
        {
            var decorator = new InputDecoratorInfo(
                "Azure.ResourceManager.@flattenProperty",
                new Dictionary<string, BinaryData>());
            var decoratorsProperty = typeof(InputModelProperty).GetProperty(
                nameof(InputModelProperty.Decorators),
                BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(decoratorsProperty, "Could not find InputModelProperty.Decorators property");
            decoratorsProperty!.SetValue(property, new[] { decorator });
        }
    }
}

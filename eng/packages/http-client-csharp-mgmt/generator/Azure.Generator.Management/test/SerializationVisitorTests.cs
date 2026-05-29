// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Reflection;
using Azure.Generator.Management;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests
{
    internal class SerializationVisitorTests
    {
        /// <summary>
        /// Regression test for https://github.com/Azure/azure-sdk-for-net/issues — derived
        /// generated models that inherit from another generated model must emit
        /// <c>internal static new T FromResponse(Response)</c>. Without the <c>new</c>
        /// modifier the C# compiler emits CS0108 (hides inherited member), which previously
        /// forced SDK-side <c>[CodeGenSuppress]</c> + custom partial workarounds (e.g.
        /// <c>CosmosDBAccountKeyList</c> hiding <c>CosmosDBAccountReadOnlyKeyList.FromResponse</c>).
        /// </summary>
        [Test]
        public void DerivedModelFromResponseUsesNewModifier()
        {
            // Arrange: base model + derived model. Both will be generated as
            // MrwSerializationTypeDefinitions emitting `internal static T FromResponse(Response)`.
            var baseProp = InputFactory.Property("primaryReadOnlyMasterKey", InputPrimitiveType.String);
            var baseModel = InputFactory.Model("CosmosDBAccountReadOnlyKeyList", properties: [baseProp]);

            var derivedProp = InputFactory.Property("primaryMasterKey", InputPrimitiveType.String);
            var derivedModel = InputFactory.Model(
                "CosmosDBAccountKeyList",
                properties: [derivedProp],
                baseModel: baseModel);

            // To force FromResponse generation, both models must be used as a service
            // operation response body.
            var pathParam = InputFactory.MethodParameter("name", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var baseOp = InputFactory.Operation(
                name: "getReadOnly",
                responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: baseModel)],
                parameters: [pathParam],
                path: "/providers/a/keys/{name}/readonly",
                decorators: []);
            var derivedOp = InputFactory.Operation(
                name: "get",
                responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: derivedModel)],
                parameters: [pathParam],
                path: "/providers/a/keys/{name}",
                decorators: []);
            var client = InputFactory.Client(
                "KeyClient",
                methods:
                [
                    InputFactory.BasicServiceMethod("GetReadOnly", baseOp, parameters: [pathParam]),
                    InputFactory.BasicServiceMethod("Get", derivedOp, parameters: [pathParam]),
                ],
                crossLanguageDefinitionId: "Test.KeyClient",
                decorators: []);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [baseModel, derivedModel],
                clients: () => [client]);

            // Act: build both models and run all library visitors over them so SerializationVisitor
            // executes on each MrwSerializationTypeDefinition's FromResponse helper.
            var baseType = plugin.Object.TypeFactory.CreateModel(baseModel);
            var derivedType = plugin.Object.TypeFactory.CreateModel(derivedModel);
            Assert.That(baseType, Is.Not.Null);
            Assert.That(derivedType, Is.Not.Null);

            RunAllVisitors(baseType!);
            RunAllVisitors(derivedType!);

            // Assert: base FromResponse has no `new`; derived FromResponse has `new`.
            var baseFromResponse = GetFromResponse(baseType!);
            Assert.That(baseFromResponse, Is.Not.Null, "Base model should emit a FromResponse helper.");
            Assert.That(
                baseFromResponse!.Signature.Modifiers.HasFlag(MethodSignatureModifiers.New),
                Is.False,
                "Base model's FromResponse must NOT carry the `new` modifier.");

            var derivedFromResponse = GetFromResponse(derivedType!);
            Assert.That(derivedFromResponse, Is.Not.Null, "Derived model should emit a FromResponse helper.");
            Assert.That(
                derivedFromResponse!.Signature.Modifiers.HasFlag(MethodSignatureModifiers.New),
                Is.True,
                "Derived model's FromResponse must carry the `new` modifier to suppress CS0108.");
        }

        /// <summary>
        /// Sanity check: when the base type is a framework type (no generated
        /// <c>FromResponse</c> helper), the derived model's FromResponse must remain unmodified.
        /// </summary>
        [Test]
        public void StandaloneModelFromResponseDoesNotUseNewModifier()
        {
            var standaloneModel = InputFactory.Model(
                "StandaloneSampleModel",
                properties: [InputFactory.Property("name", InputPrimitiveType.String)]);

            var pathParam = InputFactory.MethodParameter("name", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var op = InputFactory.Operation(
                name: "get",
                responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: standaloneModel)],
                parameters: [pathParam],
                path: "/providers/a/items/{name}",
                decorators: []);
            var client = InputFactory.Client(
                "SampleClient",
                methods: [InputFactory.BasicServiceMethod("Get", op, parameters: [pathParam])],
                crossLanguageDefinitionId: "Test.SampleClient",
                decorators: []);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [standaloneModel],
                clients: () => [client]);

            var type = plugin.Object.TypeFactory.CreateModel(standaloneModel);
            Assert.That(type, Is.Not.Null);
            RunAllVisitors(type!);

            var fromResponse = GetFromResponse(type!);
            Assert.That(fromResponse, Is.Not.Null);
            Assert.That(
                fromResponse!.Signature.Modifiers.HasFlag(MethodSignatureModifiers.New),
                Is.False,
                "Models with no generated base must not emit `new` on FromResponse.");
        }

        private static MethodProvider? GetFromResponse(ModelProvider model)
        {
            foreach (var provider in model.SerializationProviders)
            {
                if (provider is not MrwSerializationTypeDefinition)
                {
                    continue;
                }
                var method = provider.Methods.FirstOrDefault(
                    m => m.Signature.Name == "FromResponse" && m.Signature.Parameters.Count == 1);
                if (method is not null)
                {
                    return method;
                }
            }
            return null;
        }

        private static void RunAllVisitors(TypeProvider type)
        {
            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitTypeCore, Is.Not.Null, "Could not find LibraryVisitor.VisitTypeCore method");

            foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
            {
                visitTypeCore!.Invoke(visitor, [type]);
                foreach (var serialization in type.SerializationProviders)
                {
                    visitTypeCore.Invoke(visitor, [serialization]);
                }
            }
        }
    }
}

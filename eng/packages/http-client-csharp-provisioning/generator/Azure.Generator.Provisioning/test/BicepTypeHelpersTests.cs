// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Provisioning.Tests.TestHelpers;
using Azure.Generator.Provisioning.Utilities;
using Azure.Generator.Management.Models;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Provisioning.Tests
{
    /// <summary>
    /// Direct unit tests for <see cref="BicepTypeHelpers.IsResourceType"/> and
    /// <see cref="BicepTypeHelpers.BuildDefinePropertyArgs"/>, pinning the resource-typed-property
    /// behavior independently of the Provisioning-TypeSpec fixture regeneration.
    /// </summary>
    public class BicepTypeHelpersTests
    {
        private ProvisioningTypeFactory _factory = null!;
        private InputModelType _regularModel = null!;
        private InputModelType _baseResourceModel = null!;
        private InputModelType _derivedResourceModel = null!;
        private InputModelType _grandchildResourceModel = null!;

        [SetUp]
        public void SetUp()
        {
            _regularModel = CreateRegularModel();
            _baseResourceModel = CreateRegularModel("BaseResource");
            _derivedResourceModel = CreateDerivedModel("DerivedResource", "derived", _baseResourceModel);
            _grandchildResourceModel = CreateDerivedModel("GrandchildResource", "grandchild", _derivedResourceModel);

            var metadata = CreateMetadata(
                _baseResourceModel,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                [CreateMethod(ResourceOperationKind.Create, ResourceScope.ResourceGroup)]);

            _factory = ProvisioningMockHelpers.LoadMockPlugin(
                inputModels: () => [_regularModel, _baseResourceModel, _derivedResourceModel, _grandchildResourceModel],
                clients: () => metadata.Methods.Select(m => m.InputClient).Distinct().ToArray(),
                armProviderSchema: () => new ArmProviderSchema([metadata], []))
                .Object.TypeFactory;
        }

        [Test]
        public void FrameworkResourceTypeIsResourceType()
        {
            // ResourceGroup derives from ProvisionableResource.
            Assert.That(BicepTypeHelpers.IsResourceType(new CSharpType(typeof(ResourceGroup))), Is.True);
        }

        [Test]
        public void FrameworkNonResourceTypeIsNotResourceType()
        {
            // ManagedServiceIdentity derives from ProvisionableConstruct, not ProvisionableResource.
            Assert.That(BicepTypeHelpers.IsResourceType(new CSharpType(typeof(ManagedServiceIdentity))), Is.False);
        }

        [Test]
        public void GeneratedBaseResourceTypeIsResourceType()
        {
            var provider = _factory.CreateModel(_baseResourceModel);

            Assert.That(provider, Is.Not.Null);
            Assert.That(BicepTypeHelpers.IsResourceType(provider!.Type), Is.True);
        }

        [Test]
        public void GeneratedDerivedResourceTypeIsResourceType()
        {
            var provider = _factory.CreateModel(_derivedResourceModel);

            Assert.That(provider, Is.Not.Null);
            Assert.That(BicepTypeHelpers.IsResourceType(provider!.Type), Is.True);
        }

        [Test]
        public void GeneratedResourceTypeSeveralLevelsDownBaseChainIsResourceType()
        {
            // GrandchildResource -> DerivedResource -> BaseResource -> ProvisionableResource.
            var provider = _factory.CreateModel(_grandchildResourceModel);

            Assert.That(provider, Is.Not.Null);
            Assert.That(BicepTypeHelpers.IsResourceType(provider!.Type), Is.True);
        }

        [Test]
        public void GeneratedNonResourceModelIsNotResourceType()
        {
            var provider = _factory.CreateModel(_regularModel);

            Assert.That(provider, Is.Not.Null);
            Assert.That(BicepTypeHelpers.IsResourceType(provider!.Type), Is.False);
        }

        [Test]
        public void BuildDefinePropertyArgsForResourceTypeIncludesResourceInstanceInitializer()
        {
            var provider = _factory.CreateModel(_baseResourceModel);
            Assert.That(provider, Is.Not.Null);

            var args = BicepTypeHelpers.BuildDefinePropertyArgs(
                provider!.Type,
                "LatestRevision",
                ["latestRevision"],
                isOutput: true,
                isRequired: false);

            // nameof(LatestRevision), new [] { "latestRevision" }, new BaseResource("latestRevision"), isOutput: true
            Assert.That(args, Has.Length.EqualTo(4));
            var newInstance = args[2] as NewInstanceExpression;
            Assert.That(newInstance, Is.Not.Null);
            Assert.That(newInstance!.Type, Is.EqualTo(provider.Type));
            Assert.That(newInstance.Parameters, Has.Count.EqualTo(1));
            Assert.That(newInstance.Parameters[0].ToDisplayString(), Does.Contain("latestRevision"));
            Assert.That(args[3].ToDisplayString(), Does.Contain("isOutput"));
        }

        [Test]
        public void BuildDefinePropertyArgsForNonResourceTypeOmitsResourceInstanceInitializer()
        {
            var args = BicepTypeHelpers.BuildDefinePropertyArgs(
                new CSharpType(typeof(BicepValue<>), typeof(string)),
                "Name",
                ["name"],
                isOutput: false,
                isRequired: true);

            // nameof(Name), new [] { "name" }, isRequired: true — no resource instance initializer.
            Assert.That(args, Has.Length.EqualTo(3));
            Assert.That(args.OfType<NewInstanceExpression>(), Is.Empty);
            Assert.That(args[2].ToDisplayString(), Does.Contain("isRequired"));
        }

        [Test]
        public void BuildDefinePropertyArgsDerivesDistinctIdentifiersFromPropertyName()
        {
            var provider = _factory.CreateModel(_baseResourceModel);
            Assert.That(provider, Is.Not.Null);

            var firstArgs = BicepTypeHelpers.BuildDefinePropertyArgs(provider!.Type, "LatestRevision", ["latestRevision"], isOutput: true, isRequired: false);
            var secondArgs = BicepTypeHelpers.BuildDefinePropertyArgs(provider.Type, "PreviousRevision", ["previousRevision"], isOutput: true, isRequired: false);

            var firstIdentifier = ((NewInstanceExpression)firstArgs[2]).Parameters[0].ToDisplayString();
            var secondIdentifier = ((NewInstanceExpression)secondArgs[2]).Parameters[0].ToDisplayString();

            Assert.That(firstIdentifier, Is.Not.EqualTo(secondIdentifier));
        }

        [Test]
        public void BuildDefinePropertyArgsIncludesFormatsForCollectionTypes()
        {
            var listArgs = BicepTypeHelpers.BuildDefinePropertyArgs(
                new CSharpType(typeof(BicepList<>), typeof(string)),
                "Values",
                ["values"],
                isOutput: false,
                isRequired: false,
                format: "R");
            var dictionaryArgs = BicepTypeHelpers.BuildDefinePropertyArgs(
                new CSharpType(typeof(BicepDictionary<>), typeof(string)),
                "ValuesByName",
                ["valuesByName"],
                isOutput: false,
                isRequired: false,
                format: "P");

            Assert.Multiple(() =>
            {
                Assert.That(listArgs, Has.Length.EqualTo(3));
                Assert.That(dictionaryArgs, Has.Length.EqualTo(3));
                Assert.That(listArgs.Select(arg => arg.ToDisplayString()), Has.Some.Contain("format"));
                Assert.That(dictionaryArgs.Select(arg => arg.ToDisplayString()), Has.Some.Contain("format"));
            });
        }

        private static InputModelType CreateRegularModel(string name = "TestModel")
            => new(
                name,
                "Sample.Models",
                $"Sample.Models.{name}",
                "public",
                null,
                string.Empty,
                $"{name} model.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                [],
                null,
                [],
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);

        private static InputModelType CreateDerivedModel(string name, string discriminatorValue, InputModelType baseModel)
            => new(
                name,
                "Sample.Models",
                $"Sample.Models.{name}",
                "public",
                null,
                string.Empty,
                $"{name} model.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                [],
                baseModel,
                [],
                discriminatorValue,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);

        private static ArmResourceMetadata CreateMetadata(
            InputModelType model,
            string resourceIdPattern,
            string resourceType,
            ResourceScope scope,
            IReadOnlyList<string> apiVersions,
            IReadOnlyList<ResourceMethod> methods)
        {
            var path = new RequestPathPattern(resourceIdPattern);
            return new ArmResourceMetadata(
                path,
                model.Name,
                new ResourceTypePattern(resourceType),
                model,
                new ArmScopeInfo(scope, RequestPathPattern.GetFromScope(scope, path), null),
                methods,
                null,
                null,
                [],
                new ArmResourceNameConstraints(null, null, null),
                apiVersions,
                []);
        }

        private static ResourceMethod CreateMethod(ResourceOperationKind kind, ResourceScope scope)
        {
            var path = RequestPathPattern.GetFromScope(scope, new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}"));
            var methodName = $"{kind}Widget";
            var operation = new InputOperation(
                methodName,
                null,
                string.Empty,
                $"{methodName} description",
                null,
                "public",
                [],
                [new InputOperationResponse([200], null, [], false, ["application/json"])],
                kind == ResourceOperationKind.Read ? "GET" : "PUT",
                string.Empty,
                path.SerializedPath,
                null,
                null,
                false,
                true,
                true,
                $"Sample.{methodName}",
                "Sample");
            var method = new InputBasicServiceMethod(
                methodName,
                "public",
                [],
                null,
                null,
                operation,
                [],
                new InputServiceMethodResponse(null, null),
                null,
                false,
                true,
                true,
                operation.CrossLanguageDefinitionId);
            var client = new InputClient(
                "Widgets",
                "Sample",
                "Sample.Widgets",
                string.Empty,
                "Widgets description",
                isMultiServiceClient: false,
                [method],
                [],
                null,
                [],
                ["2024-01-01"]);
            return new ResourceMethod(kind, method, path, new ArmScopeInfo(scope, path, null), client);
        }
    }
}

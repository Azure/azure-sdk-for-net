// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Provisioning.Tests.TestHelpers;
using Azure.Generator.Management.Models;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.Generator.Provisioning.Tests
{
    public class ProvisioningTypeFactoryTests
    {
        private ProvisioningTypeFactory _factory = null!;
        private InputModelType _regularModel = null!;

        [SetUp]
        public void SetUp()
        {
            _regularModel = CreateRegularModel();
            var resourceModel = CreateWritableResourceModel(_regularModel);
            var metadata = CreateMetadata(
                resourceModel,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                [CreateMethod(ResourceOperationKind.Create, ResourceScope.ResourceGroup)]);
            _factory = ProvisioningMockHelpers.LoadMockPlugin(
                inputModels: () => [resourceModel, _regularModel],
                clients: () => metadata.Methods.Select(m => m.InputClient).Distinct().ToArray(),
                armProviderSchema: () => new ArmProviderSchema([metadata], []))
                .Object.TypeFactory;
        }

        [TestCaseSource(nameof(PrimitiveTypeCases))]
        public void PrimitiveTypeIsWrappedInBicepValue(InputPrimitiveType input, CSharpType expected, string expectedType)
        {
            var type = _factory.CreateCSharpType(input);

            // Expected: BicepValue<T>, with concrete T supplied by PrimitiveTypeCases.
            Assert.That(type, Is.EqualTo(expected), expectedType);
        }

        [Test]
        public void NullablePrimitiveTypeIsNotDoubleWrapped()
        {
            var type = _factory.CreateCSharpType(new InputNullableType(InputPrimitiveType.String));

            // Expected: BicepValue<string>?
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepValue<>), true, typeof(string))));
        }

        [Test]
        public void EnumTypeIsWrappedInBicepValue()
        {
            var input = CreateStringEnum();

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepValue<TestEnum>
            Assert.That(type, Is.Not.Null);
            Assert.That(type!.FrameworkType.GetGenericTypeDefinition(), Is.EqualTo(typeof(BicepValue<>)));
            Assert.That(type!.Arguments[0].Name, Is.EqualTo("TestEnum"));
            Assert.That(type.Arguments[0].Namespace, Is.EqualTo("Azure.Provisioning.Tests"));
        }

        [Test]
        public void NullableEnumTypeIsNotDoubleWrapped()
        {
            var input = new InputNullableType(CreateStringEnum());

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepValue<TestEnum>?
            Assert.That(type, Is.Not.Null);
            Assert.That(type!.FrameworkType.GetGenericTypeDefinition(), Is.EqualTo(typeof(BicepValue<>)));
            Assert.That(type.IsNullable, Is.True);
            Assert.That(type!.Arguments[0].Name, Is.EqualTo("TestEnum"));
            Assert.That(type.Arguments[0].Namespace, Is.EqualTo("Azure.Provisioning.Tests"));
        }

        [Test]
        public void ArrayTypeIsConvertedToBicepList()
        {
            var input = new InputArrayType("list", "list", InputPrimitiveType.String);

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepList<string>
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepList<>), typeof(string))));
        }

        [Test]
        public void NullableArrayTypeIsNotWrappedInBicepValue()
        {
            var input = new InputNullableType(new InputArrayType("list", "list", InputPrimitiveType.String));

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepList<string>?
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepList<>), true, typeof(string))));
        }

        [Test]
        public void DictionaryTypeIsConvertedToBicepDictionary()
        {
            var input = new InputDictionaryType("dictionary", InputPrimitiveType.String, InputPrimitiveType.String);

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepDictionary<string>
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepDictionary<>), typeof(string))));
        }

        [Test]
        public void NestedArrayTypeIsConvertedToNestedBicepList()
        {
            var input = new InputArrayType(
                "list",
                "list",
                new InputArrayType("list", "list", InputPrimitiveType.String));

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepList<BicepList<string>>
            Assert.That(type, Is.EqualTo(new CSharpType(
                typeof(BicepList<>),
                new CSharpType(typeof(BicepList<>), typeof(string)))));
        }

        [Test]
        public void NestedDictionaryTypeIsConvertedToNestedBicepDictionary()
        {
            var input = new InputDictionaryType(
                "dictionary",
                InputPrimitiveType.String,
                new InputDictionaryType("dictionary", InputPrimitiveType.String, InputPrimitiveType.String));

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepDictionary<BicepDictionary<string>>
            Assert.That(type, Is.EqualTo(new CSharpType(
                typeof(BicepDictionary<>),
                new CSharpType(typeof(BicepDictionary<>), typeof(string)))));
        }

        [Test]
        public void ArrayOfDictionaryTypePreservesNestedProvisioningType()
        {
            var input = new InputArrayType(
                "list",
                "list",
                new InputDictionaryType("dictionary", InputPrimitiveType.String, InputPrimitiveType.String));

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepList<BicepDictionary<string>>
            Assert.That(type, Is.EqualTo(new CSharpType(
                typeof(BicepList<>),
                new CSharpType(typeof(BicepDictionary<>), typeof(string)))));
        }

        [Test]
        public void NullableDictionaryTypeIsNotWrappedInBicepValue()
        {
            var input = new InputNullableType(new InputDictionaryType("dictionary", InputPrimitiveType.String, InputPrimitiveType.String));

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepDictionary<string>?
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepDictionary<>), true, typeof(string))));
        }

        [Test]
        public void KnownModelTypeUsesProvisioningFrameworkType()
        {
            var input = CreateKnownModel();

            var type = _factory.CreateCSharpType(input);

            // Expected: ManagedServiceIdentity
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(ManagedServiceIdentity))));
            Assert.That(type!.FrameworkType.Namespace, Is.EqualTo(typeof(ManagedServiceIdentity).Namespace));
        }

        [Test]
        public void RegularModelTypeIsNotWrappedInBicepValue()
        {
            var input = _regularModel;

            var type = _factory.CreateCSharpType(input);

            // Expected: TestModel : ProvisionableConstruct
            Assert.That(type, Is.Not.Null);
            Assert.That(type!.IsFrameworkType, Is.False);
            Assert.That(type.Name, Is.EqualTo("TestModel"));
            Assert.That(type.Namespace, Is.EqualTo("Azure.Provisioning.Tests"));
            Assert.That(type.BaseType, Is.EqualTo(new CSharpType(typeof(ProvisionableConstruct))));
        }

        [TestCase(null)]
        [TestCase("derived")]
        public void UnreachableModelIsNotCreated(string? discriminatorValue)
        {
            var input = CreateDerivedModel("UnreachableModel", discriminatorValue, _regularModel);

            var provider = _factory.CreateModel(input);

            Assert.That(provider, Is.Null);
        }

        [Test]
        public void DiscriminatedBaseModelDescriptionListsDerivedModels()
        {
            var discriminator = CreateProperty("kind", InputPrimitiveType.String, isDiscriminator: true);
            var baseModel = new InputModelType(
                "BaseModel",
                "Sample.Models",
                "Sample.Models.BaseModel",
                "public",
                null,
                string.Empty,
                "Base model.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                [discriminator],
                null,
                [],
                null,
                discriminator,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);
            var firstDerivedModel = CreateDerivedModel("FirstDerivedModel", "first", baseModel);
            var secondDerivedModel = CreateDerivedModel("SecondDerivedModel", "second", baseModel);
            var discriminatedSubtypes = (IDictionary<string, InputModelType>)baseModel.DiscriminatedSubtypes;
            discriminatedSubtypes.Add("first", firstDerivedModel);
            discriminatedSubtypes.Add("second", secondDerivedModel);
            var factory = ProvisioningMockHelpers.LoadMockPlugin(
                inputModels: () => [baseModel, firstDerivedModel, secondDerivedModel],
                armProviderSchema: () => new ArmProviderSchema([], []))
                .Object.TypeFactory;

            var provider = factory.CreateModel(baseModel);

            Assert.That(provider, Is.Not.Null);
            Assert.That(provider!.Description.ToString(), Does.StartWith("Base model.\nPlease note this is the base class."));
            Assert.That(provider.Description.ToString(), Does.Contain("FirstDerivedModel"));
            Assert.That(provider.Description.ToString(), Does.Contain("SecondDerivedModel"));
        }

        [Test]
        public void DiscriminatorPropertyIsInternalAndReadOnly()
        {
            var discriminatorEnum = CreateStringEnum();
            var discriminator = CreateProperty("kind", discriminatorEnum, isDiscriminator: true);
            var baseModel = new InputModelType(
                "BaseModel",
                "Sample.Models",
                "Sample.Models.BaseModel",
                "public",
                null,
                string.Empty,
                "Base model.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                [discriminator],
                null,
                [],
                null,
                discriminator,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);
            var derivedDiscriminator = CreateProperty(
                "kind",
                discriminatorEnum.Values.Single(value => Equals(value.Value, "derived")));
            var derivedModel = CreateDerivedModel(
                "DerivedModel",
                "derived",
                baseModel,
                properties: [derivedDiscriminator],
                includeInheritedDiscriminator: false);
            var discriminatedSubtypes = (IDictionary<string, InputModelType>)baseModel.DiscriminatedSubtypes;
            discriminatedSubtypes.Add("derived", derivedModel);
            var factory = ProvisioningMockHelpers.LoadMockPlugin(
                inputEnums: () => [discriminatorEnum],
                inputModels: () => [baseModel, derivedModel],
                armProviderSchema: () => new ArmProviderSchema([], []))
                .Object.TypeFactory;

            var provider = factory.CreateModel(baseModel);
            var property = provider!.Properties.Single();
            var derivedProvider = factory.CreateModel(derivedModel);
            var constructorBody = derivedProvider!.Constructors.Single().BodyStatements!.ToDisplayString();
            var methodBody = derivedProvider!.Methods
                .Single(method => method.Signature.Name == "DefineProvisionableProperties")
                .BodyStatements!
                .ToDisplayString();

            Assert.That(property.IsDiscriminator, Is.True);
            Assert.That(property.Modifiers.HasFlag(MethodSignatureModifiers.Internal), Is.True);
            Assert.That(property.Modifiers.HasFlag(MethodSignatureModifiers.Public), Is.False);
            Assert.That(property.Body.HasSetter, Is.False);
            Assert.That(property.Type.FrameworkType.GetGenericTypeDefinition(), Is.EqualTo(typeof(BicepValue<>)));
            Assert.That(property.Type.Arguments[0].Name, Is.EqualTo("TestEnum"));
            Assert.That(derivedProvider.Properties, Is.Empty);
            Assert.That(constructorBody, Does.Contain("TestEnum.Derived"));
            Assert.That(methodBody, Does.Not.Contain("nameof(Kind)"));
            Assert.That(constructorBody, Does.Not.Contain("defaultValue: \"derived\""));
        }

        [Test]
        public void DiscriminatorEnumIsInternalized()
        {
            var discriminatorEnum = CreateStringEnum("DiscriminatorKind", null);
            var discriminator = CreateProperty("kind", discriminatorEnum, isDiscriminator: true);
            var baseModel = new InputModelType(
                "BaseModel",
                "Sample.Models",
                "Sample.Models.BaseModel",
                "public",
                null,
                string.Empty,
                "Base model.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                [discriminator],
                null,
                [],
                null,
                discriminator,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);
            var derivedModel = CreateDerivedModel("DerivedModel", "derived", baseModel);
            ((IDictionary<string, InputModelType>)baseModel.DiscriminatedSubtypes).Add("derived", derivedModel);
            var generator = ProvisioningMockHelpers.LoadMockPlugin(
                inputEnums: () => [discriminatorEnum],
                inputModels: () => [baseModel, derivedModel],
                armProviderSchema: () => new ArmProviderSchema([], []));
            var providers = generator.Object.OutputLibrary.TypeProviders;
            var enumProvider = providers.Single(provider => provider.Name == discriminatorEnum.Name);
            var analyzer = typeof(CodeModelGenerator).Assembly.GetType(
                "Microsoft.TypeSpec.Generator.ProviderReferenceMapAnalyzer")!;
            var prepare = analyzer.GetMethod(
                "PrepareForGeneration",
                BindingFlags.Public | BindingFlags.Static)!;

            using var session = (IDisposable)prepare.Invoke(null, [providers])!;

            Assert.That(
                enumProvider.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Internal),
                Is.True);
        }

        [Test]
        public void MultiLevelDiscriminatorUsesCanonicalInternalEnum()
        {
            var discriminatorEnum = CreateStringEnum("DiscriminatorKind", null);
            var repeatedDiscriminatorEnum = CreateStringEnum("DiscriminatorKind", "public");
            var discriminator = CreateProperty("kind", discriminatorEnum, isDiscriminator: true);
            var baseModel = new InputModelType(
                "BaseModel",
                "Sample.Models",
                "Sample.Models.BaseModel",
                "public",
                null,
                string.Empty,
                "Base model.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                [discriminator],
                null,
                [],
                null,
                discriminator,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);
            var intermediateDiscriminator = CreateProperty(
                "kind",
                repeatedDiscriminatorEnum.Values.Single(value => Equals(value.Value, "derived")),
                isDiscriminator: true);
            var intermediateModel = CreateDerivedModel(
                "IntermediateModel",
                "derived",
                baseModel,
                properties: [intermediateDiscriminator],
                discriminatorProperty: intermediateDiscriminator,
                includeInheritedDiscriminator: false);
            var leafDiscriminator = CreateProperty(
                "kind",
                repeatedDiscriminatorEnum.Values.Single(value => Equals(value.Value, "One")),
                isDiscriminator: true);
            var leafModel = CreateDerivedModel(
                "LeafModel",
                "One",
                intermediateModel,
                properties: [leafDiscriminator],
                includeInheritedDiscriminator: false);
            ((IDictionary<string, InputModelType>)baseModel.DiscriminatedSubtypes).Add("derived", intermediateModel);
            ((IDictionary<string, InputModelType>)baseModel.DiscriminatedSubtypes).Add("One", leafModel);
            ((IDictionary<string, InputModelType>)intermediateModel.DiscriminatedSubtypes).Add("One", leafModel);
            var generator = ProvisioningMockHelpers.LoadMockPlugin(
                inputEnums: () => [discriminatorEnum],
                inputModels: () => [baseModel, intermediateModel, leafModel],
                armProviderSchema: () => new ArmProviderSchema([], []));
            var providers = generator.Object.OutputLibrary.TypeProviders;
            var enumProvider = providers.Single(provider => provider.Name == discriminatorEnum.Name);
            var intermediateProvider = generator.Object.TypeFactory.CreateModel(intermediateModel)!;
            var leafProvider = generator.Object.TypeFactory.CreateModel(leafModel)!;
            var analyzer = typeof(CodeModelGenerator).Assembly.GetType(
                "Microsoft.TypeSpec.Generator.ProviderReferenceMapAnalyzer")!;
            var prepare = analyzer.GetMethod(
                "PrepareForGeneration",
                BindingFlags.Public | BindingFlags.Static)!;

            using var session = (IDisposable)prepare.Invoke(null, [providers])!;

            Assert.That(enumProvider.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Internal), Is.True);
            Assert.That(
                intermediateProvider.Constructors.Single().BodyStatements!.ToDisplayString(),
                Does.Contain("DiscriminatorKind.Derived"));
            Assert.That(
                leafProvider.Constructors.Single().BodyStatements!.ToDisplayString(),
                Does.Contain("DiscriminatorKind.One"));
        }

        [Test]
        public void EnumUsedByPublicPropertyIsPublicized()
        {
            var inputEnum = CreateStringEnum("PublicKind", null);
            var model = new InputModelType(
                "PublicModel",
                "Sample.Models",
                "Sample.Models.PublicModel",
                "public",
                null,
                string.Empty,
                "Public model.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                [CreateProperty("kind", inputEnum)],
                null,
                [],
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);
            var generator = ProvisioningMockHelpers.LoadMockPlugin(
                inputEnums: () => [inputEnum],
                inputModels: () => [model],
                armProviderSchema: () => new ArmProviderSchema([], []));
            var providers = generator.Object.OutputLibrary.TypeProviders;
            var enumProvider = providers.Single(provider => provider.Name == inputEnum.Name);
            var analyzer = typeof(CodeModelGenerator).Assembly.GetType(
                "Microsoft.TypeSpec.Generator.ProviderReferenceMapAnalyzer")!;
            var prepare = analyzer.GetMethod(
                "PrepareForGeneration",
                BindingFlags.Public | BindingFlags.Static)!;

            using var session = (IDisposable)prepare.Invoke(null, [providers])!;

            Assert.That(
                enumProvider.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public),
                Is.True);
        }

        [Test]
        public void CustomBasePropertyDoesNotReplaceDiscriminator()
        {
            var discriminator = CreateProperty("kind", InputPrimitiveType.String, isDiscriminator: true);
            var baseModel = new InputModelType(
                "BaseModel",
                "Sample.Models",
                "Sample.Models.BaseModel",
                "public",
                null,
                string.Empty,
                "Base model.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                [discriminator],
                null,
                [],
                null,
                discriminator,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);
            var derivedModel = CreateDerivedModel("DerivedModel", "derived", baseModel);
            ((IDictionary<string, InputModelType>)baseModel.DiscriminatedSubtypes).Add("derived", derivedModel);
            var factory = ProvisioningMockHelpers.LoadMockPlugin(
                inputModels: () => [baseModel, derivedModel],
                armProviderSchema: () => new ArmProviderSchema([], []),
                customizationSources:
                [
                    """
                    namespace Azure.Provisioning.Tests
                    {
                        public class CustomBase
                        {
                            public BicepValue<string> Kind { get; }
                        }

                        public partial class BaseModel : CustomBase
                        {
                        }
                    }
                    """
                ])
                .Object.TypeFactory;

            var provider = factory.CreateModel(baseModel)!;
            var property = provider.Properties.Single();
            var derivedProvider = factory.CreateModel(derivedModel)!;
            var constructorBody = derivedProvider.Constructors.Single().BodyStatements!.ToDisplayString();

            Assert.That(provider.BaseType?.Name, Is.EqualTo("CustomBase"));
            Assert.That(property.Name, Is.EqualTo("@Kind"));
            Assert.That(property.IsDiscriminator, Is.True);
            Assert.That(property.Modifiers.HasFlag(MethodSignatureModifiers.Internal), Is.True);
            Assert.That(property.Modifiers.HasFlag(MethodSignatureModifiers.New), Is.True);
            Assert.That(derivedProvider.Properties, Is.Empty);
            Assert.That(constructorBody, Does.Contain("@Kind.Assign(\"derived\");"));
        }

        [Test]
        public void NestedDiscriminatorsDefineAndAssignEachLevel()
        {
            var kind = CreateProperty("kind", InputPrimitiveType.String, isDiscriminator: true);
            var baseModel = new InputModelType(
                "BaseModel",
                "Sample.Models",
                "Sample.Models.BaseModel",
                "public",
                null,
                string.Empty,
                "Base model.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                [kind],
                null,
                [],
                null,
                kind,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);
            var breed = CreateProperty("breed", InputPrimitiveType.String, isDiscriminator: true);
            var intermediateModel = CreateDerivedModel("IntermediateModel", "intermediate", baseModel, [breed], breed);
            var leafModel = CreateDerivedModel("LeafModel", "leaf", intermediateModel);
            ((IDictionary<string, InputModelType>)baseModel.DiscriminatedSubtypes).Add("intermediate", intermediateModel);
            ((IDictionary<string, InputModelType>)intermediateModel.DiscriminatedSubtypes).Add("leaf", leafModel);
            var factory = ProvisioningMockHelpers.LoadMockPlugin(
                inputModels: () => [baseModel, intermediateModel, leafModel],
                armProviderSchema: () => new ArmProviderSchema([], []))
                .Object.TypeFactory;

            var intermediateProvider = factory.CreateModel(intermediateModel)!;
            var leafProvider = factory.CreateModel(leafModel)!;
            var intermediateConstructorBody = intermediateProvider.Constructors.Single().BodyStatements!.ToDisplayString();
            var leafConstructorBody = leafProvider.Constructors.Single().BodyStatements!.ToDisplayString();
            var intermediateBody = intermediateProvider.Methods
                .Single(method => method.Signature.Name == "DefineProvisionableProperties")
                .BodyStatements!
                .ToDisplayString();
            var leafBody = leafProvider.Methods
                .Single(method => method.Signature.Name == "DefineProvisionableProperties")
                .BodyStatements!
                .ToDisplayString();

            Assert.That(intermediateProvider.Properties.Single().Name, Is.EqualTo("Breed"));
            Assert.That(intermediateProvider.Properties.Single().IsDiscriminator, Is.True);
            Assert.That(leafProvider.Properties, Is.Empty);
            Assert.That(intermediateConstructorBody, Does.Contain("Kind.Assign(\"intermediate\");"));
            Assert.That(intermediateBody, Does.Contain("nameof(Breed)"));
            Assert.That(leafConstructorBody, Does.Contain("Breed.Assign(\"leaf\");"));
            Assert.That(leafBody, Does.Not.Contain("nameof(Breed)"));
        }

        [Test]
        public void ArrayOfKnownModelTypeIsConvertedToBicepListOfModel()
        {
            var input = new InputArrayType("list", "list", CreateKnownModel());

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepList<ManagedServiceIdentity>
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepList<>), typeof(ManagedServiceIdentity))));
            Assert.That(type!.Arguments[0].FrameworkType.Namespace, Is.EqualTo(typeof(ManagedServiceIdentity).Namespace));
        }

        [Test]
        public void DictionaryOfKnownModelTypeIsConvertedToBicepDictionaryOfModel()
        {
            var input = new InputDictionaryType("dictionary", InputPrimitiveType.String, CreateKnownModel());

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepDictionary<ManagedServiceIdentity>
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepDictionary<>), typeof(ManagedServiceIdentity))));
            Assert.That(type!.Arguments[0].FrameworkType.Namespace, Is.EqualTo(typeof(ManagedServiceIdentity).Namespace));
        }

        [Test]
        public void ArrayOfRegularModelTypeIsConvertedToBicepListOfModel()
        {
            var input = new InputArrayType("list", "list", _regularModel);

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepList<TestModel>
            Assert.That(type, Is.Not.Null);
            Assert.That(type!.FrameworkType.GetGenericTypeDefinition(), Is.EqualTo(typeof(BicepList<>)));
            Assert.That(type.Arguments[0].IsFrameworkType, Is.False);
            Assert.That(type.Arguments[0].Name, Is.EqualTo("TestModel"));
            Assert.That(type.Arguments[0].Namespace, Is.EqualTo("Azure.Provisioning.Tests"));
        }

        [Test]
        public void DictionaryOfRegularModelTypeIsConvertedToBicepDictionaryOfModel()
        {
            var input = new InputDictionaryType("dictionary", InputPrimitiveType.String, _regularModel);

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepDictionary<TestModel>
            Assert.That(type, Is.Not.Null);
            Assert.That(type!.FrameworkType.GetGenericTypeDefinition(), Is.EqualTo(typeof(BicepDictionary<>)));
            Assert.That(type.Arguments[0].IsFrameworkType, Is.False);
            Assert.That(type.Arguments[0].Name, Is.EqualTo("TestModel"));
            Assert.That(type.Arguments[0].Namespace, Is.EqualTo("Azure.Provisioning.Tests"));
        }

        [Test]
        public void ArrayOfDictionaryOfRegularModelTypePreservesNestedProvisioningType()
        {
            var input = new InputArrayType(
                "list",
                "list",
                new InputDictionaryType("dictionary", InputPrimitiveType.String, _regularModel));

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepList<BicepDictionary<TestModel>>
            Assert.That(type, Is.Not.Null);
            Assert.That(type!.FrameworkType.GetGenericTypeDefinition(), Is.EqualTo(typeof(BicepList<>)));
            var dictionaryType = type.Arguments[0];
            Assert.That(dictionaryType.FrameworkType.GetGenericTypeDefinition(), Is.EqualTo(typeof(BicepDictionary<>)));
            Assert.That(dictionaryType.Arguments[0].IsFrameworkType, Is.False);
            Assert.That(dictionaryType.Arguments[0].Name, Is.EqualTo("TestModel"));
            Assert.That(dictionaryType.Arguments[0].Namespace, Is.EqualTo("Azure.Provisioning.Tests"));
        }

        [Test]
        public void BytesTypeIsWrappedInBicepValueOfBinaryData()
        {
            var type = _factory.CreateCSharpType(InputPrimitiveType.Base64);

            // Expected: BicepValue<BinaryData>
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepValue<>), typeof(BinaryData))));
        }

        [Test]
        public void UnknownTypeIsWrappedInBicepValueOfBinaryData()
        {
            var type = _factory.CreateCSharpType(InputPrimitiveType.Any);

            // Expected: BicepValue<BinaryData>
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepValue<>), typeof(BinaryData))));
        }

        private static InputModelType CreateKnownModel()
            => new(
                "ManagedServiceIdentity",
                "Azure.ResourceManager.CommonTypes",
                "Azure.ResourceManager.CommonTypes.ManagedServiceIdentity",
                "public",
                null,
                string.Empty,
                "Managed service identity.",
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

        private static InputModelType CreateRegularModel()
            => new(
                "TestModel",
                "Sample.Models",
                "Sample.Models.TestModel",
                "public",
                null,
                string.Empty,
                "Test model.",
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

        private static InputModelType CreateWritableResourceModel(InputModelType model)
            => new(
                "TestResource",
                "Sample.Models",
                "Sample.Models.TestResource",
                "public",
                null,
                string.Empty,
                "Test resource.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                [CreateProperty("Details", model)],
                null,
                [],
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);

        private static InputModelType CreateDerivedModel(
            string name,
            string? discriminatorValue,
            InputModelType baseModel,
            IReadOnlyList<InputModelProperty>? properties = null,
            InputModelProperty? discriminatorProperty = null,
            bool includeInheritedDiscriminator = true)
        {
            IReadOnlyList<InputModelProperty> modelProperties = properties ?? [];
            if (includeInheritedDiscriminator
                && baseModel.DiscriminatorProperty is { } inheritedDiscriminator)
            {
                modelProperties =
                [
                    CreateProperty(inheritedDiscriminator.Name, inheritedDiscriminator.Type, isDiscriminator: true),
                    .. modelProperties
                ];
            }

            return new(
                name,
                "Sample.Models",
                $"Sample.Models.{name}",
                "public",
                null,
                string.Empty,
                $"{name} model.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                modelProperties,
                baseModel,
                [],
                discriminatorValue,
                discriminatorProperty,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);
        }

        private static InputModelProperty CreateProperty(string name, InputType type, bool isDiscriminator = false)
            => new(
                name: name,
                summary: null,
                doc: $"Description for {name}",
                type: type,
                isRequired: false,
                isReadOnly: false,
                isApiVersion: false,
                defaultValue: null,
                isHttpMetadata: false,
                access: null,
                isDiscriminator: isDiscriminator,
                serializedName: name,
                serializationOptions: new(json: new(name)));

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

        private static IEnumerable<TestCaseData> PrimitiveTypeCases()
        {
            yield return new TestCaseData(InputPrimitiveType.String, new CSharpType(typeof(BicepValue<>), typeof(string)), "BicepValue<string>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_String");
            yield return new TestCaseData(InputPrimitiveType.Boolean, new CSharpType(typeof(BicepValue<>), typeof(bool)), "BicepValue<bool>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_Boolean");
            yield return new TestCaseData(InputPrimitiveType.Int32, new CSharpType(typeof(BicepValue<>), typeof(int)), "BicepValue<int>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_Int32");
            yield return new TestCaseData(InputPrimitiveType.Int64, new CSharpType(typeof(BicepValue<>), typeof(long)), "BicepValue<long>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_Int64");
            yield return new TestCaseData(InputPrimitiveType.Float32, new CSharpType(typeof(BicepValue<>), typeof(float)), "BicepValue<float>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_Float32");
            yield return new TestCaseData(InputPrimitiveType.Float64, new CSharpType(typeof(BicepValue<>), typeof(double)), "BicepValue<double>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_Float64");
            yield return new TestCaseData(InputPrimitiveType.PlainDate, new CSharpType(typeof(BicepValue<>), typeof(DateTimeOffset)), "BicepValue<DateTimeOffset>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_PlainDate");
            yield return new TestCaseData(InputPrimitiveType.PlainTime, new CSharpType(typeof(BicepValue<>), typeof(TimeSpan)), "BicepValue<TimeSpan>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_PlainTime");
            yield return new TestCaseData(InputPrimitiveType.Url, new CSharpType(typeof(BicepValue<>), typeof(Uri)), "BicepValue<Uri>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_Url");
        }

        private static InputEnumType CreateStringEnum(string name = "TestEnum", string? access = "public")
        {
            var values = new List<InputEnumTypeValue>();
            var enumType = new InputEnumType(
                name,
                "Sample.Models",
                $"Sample.Models.{name}",
                access,
                null,
                string.Empty,
                "Test enum.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                InputPrimitiveType.String,
                values,
                true);
            values.Add(new InputEnumTypeValue("One", "One", InputPrimitiveType.String, string.Empty, "One.", enumType));
            values.Add(new InputEnumTypeValue("Derived", "derived", InputPrimitiveType.String, string.Empty, "Derived.", enumType));
            return enumType;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Tests.Common;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Mgmt.Tests
{
    public class ManagementTypeFactoryTests
    {
        private static readonly InputPrimitiveType _armResourceIdentifier = new(InputPrimitiveTypeKind.String, "armResourceIdentifier", "Azure.Core.armResourceIdentifier");
        private static readonly InputPrimitiveType _armResourceType = new(InputPrimitiveTypeKind.String, "armResourceType", "Azure.Core.armResourceType");
        private static readonly InputPrimitiveType _azureLocation = new(InputPrimitiveTypeKind.String, "azureLocation", "Azure.Core.azureLocation");

        [TestCase("Azure.ResourceManager.Compute", ExpectedResult = "Compute")]
        [TestCase("Azure.ResourceManager.Storage", ExpectedResult = "Storage")]
        [TestCase("Azure.ResourceManager.Network", ExpectedResult = "Network")]
        [TestCase("Azure.ResourceManager.PostgreSql.FlexibleServers", ExpectedResult = "PostgreSqlFlexibleServers")]
        [TestCase("Azure.ResourceManager", ExpectedResult = "AzureResourceManager")] // not sure what we should expect on this since we did not get there yet.
        public string ValidateResourceProviderName(string primaryNamespace)
        {
            var plugin = ManagementMockHelpers.LoadMockPlugin(primaryNamespace: primaryNamespace);
            return plugin.Object.TypeFactory.ResourceProviderName;
        }

        [TestCase("Azure.ResourceManager.CommonTypes.ExtendedLocationType", typeof(ExtendedLocationType))]
        [TestCase("Azure.ResourceManager.CommonTypes.ManagedServiceIdentityType", typeof(ManagedServiceIdentityType))]
        public void EnumTypeIsReplacedWithSystemType(string crossLanguageDefinitionId, System.Type expectedType)
        {
            var enumType = new InputEnumType(
                "TestEnum",
                "Sample.Models",
                crossLanguageDefinitionId,
                "public",
                null,
                "",
                "TestEnum description",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                InputPrimitiveType.String,
                [],
                true);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputEnums: () => [enumType]);
            var result = plugin.Object.TypeFactory.CreateCSharpType(enumType);
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.FrameworkType, Is.EqualTo(expectedType));
        }

        [TestCase("Azure.ResourceManager.CommonTypes.ExtendedLocationType")]
        [TestCase("Azure.ResourceManager.CommonTypes.ManagedServiceIdentityType")]
        public void KnownSystemEnumTypeIsNotGenerated(string crossLanguageDefinitionId)
        {
            var enumType = new InputEnumType(
                "TestEnum",
                "Sample.Models",
                crossLanguageDefinitionId,
                "public",
                null,
                "",
                "TestEnum description",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                InputPrimitiveType.String,
                [],
                true);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputEnums: () => [enumType]);
            var result = plugin.Object.TypeFactory.CreateEnum(enumType, null);
            Assert.That(result, Is.Null);
        }

        [TestCase(typeof(ResourceData))]
        [TestCase(typeof(TrackedResourceData))]
        public void InheritableSystemTypesCanBeResolvedByClrType(System.Type frameworkType)
        {
            Assert.That(
                KnownManagementTypes.TryGetInheritableSystemType(new CSharpType(frameworkType), out var knownType),
                Is.True);
            Assert.That(knownType!.FrameworkType, Is.EqualTo(frameworkType));
            Assert.That(frameworkType.IsAbstract, Is.True,
                "Known ARM data bases are abstract marker classes without abstract members");
        }

        [Test]
        public void KnownLastContractTrackedResourceDataCreatesMappedProvider()
        {
            var currentBase = InputFactory.Model(
                "CurrentResource",
                properties:
                [
                    InputFactory.Property("id", _armResourceIdentifier, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", _armResourceType, isReadOnly: true),
                    InputFactory.Property("tags", new InputDictionaryType("tags", InputPrimitiveType.String, InputPrimitiveType.String)),
                    InputFactory.Property("location", _azureLocation)
                ]);
            var model = InputFactory.Model("WidgetData", properties: [], baseModel: currentBase);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [currentBase, model],
                primaryNamespace: "Azure.ResourceManager.Test",
                lastContractCompilation: () => Helpers.GetCompilationFromDirectory());

            var provider = plugin.Object.TypeFactory.CreateModel(model)!;
            var previousBase = provider.LastContractView!.BaseType!;
            Assert.That(
                KnownManagementTypes.TryGetInheritableSystemType(previousBase, out _),
                Is.True,
                $"Expected '{previousBase.FullyQualifiedName}' to resolve as a known inheritable management type");
            var mappedBase = provider.BaseModelProvider as SystemObjectModelProvider;

            Assert.Multiple(() =>
            {
                Assert.That(provider.BaseType?.Name, Is.EqualTo(nameof(TrackedResourceData)));
                Assert.That(mappedBase, Is.Not.Null);
                Assert.That(mappedBase!.SystemType.FrameworkType, Is.EqualTo(typeof(TrackedResourceData)));
                Assert.That(mappedBase.FullConstructor.Signature.Parameters.Select(parameter => parameter.Name),
                    Is.EqualTo(new[] { "id", "name", "resourceType", "systemData", "tags", "location" }));
                Assert.That(mappedBase.Properties.Select(property => property.Name),
                    Is.EqualTo(new[] { "Tags", "Location", "Id", "Name", "ResourceType", "SystemData" }));
            });
        }

        [Test]
        public void KnownLastContractResourceDataCreatesMappedProvider()
        {
            var currentBase = InputFactory.Model(
                "CurrentResource",
                properties:
                [
                    InputFactory.Property("id", _armResourceIdentifier, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", _armResourceType, isReadOnly: true)
                ]);
            var model = InputFactory.Model("WidgetData", properties: [], baseModel: currentBase);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [currentBase, model],
                primaryNamespace: "Azure.ResourceManager.Test",
                lastContractCompilation: () => Helpers.GetCompilationFromDirectory());

            var provider = plugin.Object.TypeFactory.CreateModel(model)!;
            var mappedBase = provider.BaseModelProvider as SystemObjectModelProvider;

            Assert.Multiple(() =>
            {
                Assert.That(provider.BaseType?.Name, Is.EqualTo(nameof(ResourceData)));
                Assert.That(mappedBase, Is.Not.Null);
                Assert.That(mappedBase!.SystemType.FrameworkType, Is.EqualTo(typeof(ResourceData)));
                Assert.That(mappedBase.FullConstructor.Signature.Parameters.Select(parameter => parameter.Name),
                    Is.EqualTo(new[] { "id", "name", "resourceType", "systemData" }));
                Assert.That(mappedBase.Properties.Select(property => property.Name),
                    Is.EqualTo(new[] { "Id", "Name", "ResourceType", "SystemData" }));
            });
        }

        [TestCase("id")]
        [TestCase("name")]
        [TestCase("type")]
        [TestCase("location")]
        [TestCase("tags")]
        public void IncompatibleLastContractPropertyTypeIsNotMapped(string wireName)
        {
            InputType propertyType = wireName == "tags"
                ? new InputDictionaryType("tags", InputPrimitiveType.String, InputPrimitiveType.Int32)
                : InputPrimitiveType.Int32;
            AssertIncompatibleLastContractPropertyIsNotMapped(
                InputFactory.Property(wireName, propertyType, isReadOnly: wireName is "id" or "name" or "type"));
        }

        [TestCase("id")]
        [TestCase("type")]
        [TestCase("location")]
        public void PlainStringLastContractPropertyIsNotConverted(string wireName)
        {
            AssertIncompatibleLastContractPropertyIsNotMapped(
                InputFactory.Property(wireName, InputPrimitiveType.String, isReadOnly: wireName != "location"));
        }

        [TestCase("name", false)]
        [TestCase("location", true)]
        public void IncompatibleLastContractPropertyAccessorIsNotMapped(string wireName, bool isReadOnly)
        {
            AssertIncompatibleLastContractPropertyIsNotMapped(
                InputFactory.Property(wireName, GetArmPropertyType(wireName), isReadOnly: isReadOnly));
        }

        [TestCase("type")]
        [TestCase("location")]
        public void NullableLastContractValuePropertyIsNotMapped(string wireName)
        {
            AssertIncompatibleLastContractPropertyIsNotMapped(
                InputFactory.Property(wireName, new InputNullableType(GetArmPropertyType(wireName)), isReadOnly: wireName == "type"));
        }

        [Test]
        public void ReadOnlyLastContractTagsAreNotMapped()
        {
            AssertIncompatibleLastContractPropertyIsNotMapped(
                InputFactory.Property("tags", new InputDictionaryType("tags", InputPrimitiveType.String, InputPrimitiveType.String), isReadOnly: true));
        }

        [TestCase(false, false, false, true)]
        [TestCase(false, false, true, false)]
        [TestCase(false, true, false, false)]
        [TestCase(false, true, true, false)]
        [TestCase(true, false, true, true)]
        [TestCase(true, false, false, false)]
        public void LastContractListPropertyUsesCollectionAccessorSemantics(
            bool isNullable, bool isReadOnly, bool hasSetter, bool expectedCompatible)
        {
            InputType listType = InputFactory.Array(InputPrimitiveType.String);
            if (isNullable)
            {
                listType = new InputNullableType(listType);
            }
            var inputProperty = InputFactory.Property("values", listType, isReadOnly: isReadOnly);
            var model = InputFactory.Model("CurrentResource", properties: [inputProperty]);
            ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var factory = new CompatibilityTypeFactory();
            // The known ARM bases currently expose only Tags. Exercise the compatibility hook
            // directly so the same collection semantics are covered for list-shaped properties.
            var previousProperty = new PropertyProvider(
                null, MethodSignatureModifiers.Public, new CSharpType(typeof(IList<string>), isNullable),
                "Values", new AutoPropertyBody(hasSetter), new ModelProvider(model));

            Assert.That(factory.IsCompatible(typeof(TrackedResourceData), inputProperty, previousProperty),
                Is.EqualTo(expectedCompatible));
        }

        private sealed class CompatibilityTypeFactory : ManagementTypeFactory
        {
            public bool IsCompatible(CSharpType mappedBase, InputModelProperty currentProperty, PropertyProvider previousProperty)
                => IsLastContractModelBasePropertyCompatibleCore(mappedBase, currentProperty, previousProperty);
        }

        [TestCase("id", typeof(ResourceIdentifier), false)]
        [TestCase("name", typeof(string), false)]
        [TestCase("type", typeof(ResourceType), false)]
        [TestCase("location", typeof(AzureLocation), true)]
        [TestCase("tags", typeof(IDictionary<string, string>), false)]
        [TestCase("systemData", typeof(SystemData), false)]
        public void LastContractSemanticPropertyPreservesWireMetadata(string wireName, Type frameworkType, bool hasSetter)
        {
            var inputProperty = InputFactory.Property(
                wireName, GetArmPropertyType(wireName), isReadOnly: wireName is "id" or "name" or "type" or "systemData");
            var currentBase = InputFactory.Model("CurrentResource", properties: [inputProperty]);
            var model = InputFactory.Model("WidgetData", properties: [], baseModel: currentBase);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [currentBase, model],
                primaryNamespace: "Azure.ResourceManager.Test",
                lastContractCompilation: () => Helpers.GetCompilationFromDirectory(
                    method: nameof(KnownLastContractTrackedResourceDataCreatesMappedProvider)));

            var provider = plugin.Object.TypeFactory.CreateModel(model)!;
            var mappedBase = provider.BaseModelProvider as SystemObjectModelProvider;

            Assert.That(mappedBase, Is.Not.Null);
            var property = mappedBase!.Properties.Single(property => property.WireInfo?.SerializedName == wireName);
            Assert.Multiple(() =>
            {
                Assert.That(property.Type, Is.EqualTo(new CSharpType(frameworkType)));
                Assert.That(property.Body.HasSetter, Is.EqualTo(hasSetter));
                Assert.That(property.WireInfo!.IsReadOnly, Is.EqualTo(inputProperty.IsReadOnly));
                Assert.That(property.WireInfo.IsRequired, Is.EqualTo(inputProperty.IsRequired));
                Assert.That(property.WireInfo.IsNullable, Is.False);
            });
        }

        [Test]
        public void LastContractGetterOnlyLocationRemainsCompatible()
        {
            var currentBase = InputFactory.Model("CurrentResource", properties:
                [InputFactory.Property("location", _azureLocation, isReadOnly: true)]);
            var model = InputFactory.Model("WidgetData", properties: [], baseModel: currentBase);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [currentBase, model],
                primaryNamespace: "Azure.ResourceManager.Test",
                lastContractCompilation: () => Helpers.GetCompilationFromDirectory());

            var provider = plugin.Object.TypeFactory.CreateModel(model)!;
            var mappedBase = provider.BaseModelProvider as SystemObjectModelProvider;

            Assert.That(mappedBase, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(mappedBase!.SystemType.FrameworkType, Is.EqualTo(typeof(TrackedResourceData)));
                Assert.That(mappedBase.Properties.Single(property => property.Name == nameof(TrackedResourceData.Location)).Body.HasSetter, Is.False);
            });
        }

        private static InputType GetArmPropertyType(string wireName) => wireName switch
        {
            "id" => _armResourceIdentifier,
            "type" => _armResourceType,
            "location" => _azureLocation,
            "tags" => new InputDictionaryType("tags", InputPrimitiveType.String, InputPrimitiveType.String),
            "systemData" => InputFactory.Model("Azure.ResourceManager.CommonTypes.SystemData", properties: []),
            _ => InputPrimitiveType.String
        };

        private static void AssertIncompatibleLastContractPropertyIsNotMapped(InputModelProperty property)
        {
            var currentBase = InputFactory.Model("CurrentResource", properties: [property]);
            var model = InputFactory.Model("WidgetData", properties: [], baseModel: currentBase);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [currentBase, model],
                primaryNamespace: "Azure.ResourceManager.Test",
                lastContractCompilation: () => Helpers.GetCompilationFromDirectory(
                    method: nameof(KnownLastContractTrackedResourceDataCreatesMappedProvider)));

            var provider = plugin.Object.TypeFactory.CreateModel(model)!;

            Assert.That(provider.BaseType?.Name, Is.EqualTo("CurrentResource"));
        }

        [Test]
        public void UnknownLastContractBaseIsNotMapped()
        {
            var currentBase = InputFactory.Model("CurrentResource", properties: []);
            var model = InputFactory.Model("WidgetData", properties: [], baseModel: currentBase);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [currentBase, model],
                primaryNamespace: "Azure.ResourceManager.Test",
                lastContractCompilation: () => Helpers.GetCompilationFromDirectory());

            var provider = plugin.Object.TypeFactory.CreateModel(model)!;

            Assert.That(provider.BaseType?.Name, Is.EqualTo("CurrentResource"));
        }

        [Test]
        public void ManagementModelUsesSharedProvider()
        {
            var model = InputFactory.Model("Widget");
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [model],
                primaryNamespace: "Azure.ResourceManager.Test");

            var provider = plugin.Object.TypeFactory.CreateModel(model);

            Assert.That(provider, Is.TypeOf<ManagementModelProvider>());
            Assert.That(provider, Is.InstanceOf<ScmModelProvider>());
            Assert.That(provider!.Type.Namespace, Is.EqualTo("Azure.ResourceManager.Test.Models"));
        }

        [Test]
        public void DynamicManagementModelHasPatchProperty()
        {
            var model = InputFactory.Model("DynamicWidget", isDynamicModel: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [model],
                primaryNamespace: "Azure.ResourceManager.Test");

            var provider = plugin.Object.TypeFactory.CreateModel(model);

            Assert.That(provider, Is.TypeOf<ManagementModelProvider>());
            Assert.That(provider, Is.InstanceOf<ScmModelProvider>());
            Assert.That(provider!.Type.Namespace, Is.EqualTo("Azure.ResourceManager.Test.Models"));
            Assert.That(provider.Properties.Count(p => p.Name == "Patch"), Is.EqualTo(1));
        }

        [Test]
        public void DynamicResourceModelUsesSharedProviderWithResourceIdentity()
        {
            var (client, models) = InputResourceData.ClientWithResource(isDynamicModel: true);
            var resourceModel = models.Single();
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [client],
                primaryNamespace: "Azure.ResourceManager.Test");

            var provider = plugin.Object.TypeFactory.CreateModel(resourceModel);

            Assert.That(provider, Is.TypeOf<ResourceDataModelProvider>());
            Assert.That(provider, Is.InstanceOf<ScmModelProvider>());
            Assert.That(provider!.Name, Is.EqualTo("ResponseTypeData"));
            Assert.That(provider.Type.Namespace, Is.EqualTo("Azure.ResourceManager.Test"));
            Assert.That(provider.Properties.Count(p => p.Name == "Patch"), Is.EqualTo(1));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void EnumPreservesShippedUrlMemberAndNormalizesNewMember(bool isExtensible)
        {
            var enumName = isExtensible ? "ExtensibleTestKind" : "FixedTestKind";
            var enumType = InputFactory.StringEnum(
                enumName,
                [("ExistingUrl", "ExistingUrl"), ("NewUrl", "NewUrl")],
                isExtensible: isExtensible,
                clientNamespace: "Samples.Models");
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputEnums: () => [enumType],
                lastContractCompilation: () => Helpers.GetCompilationFromDirectory());

            var provider = plugin.Object.TypeFactory.CreateEnum(enumType)!;
            var generatedNames = provider.EnumValues.Select(v => v.Name).ToArray();

            Assert.That(provider.LastContractView, Is.Not.Null);
            Assert.That(generatedNames, Does.Contain("ExistingUrl"));
            Assert.That(generatedNames, Does.Not.Contain("ExistingUri"));
            Assert.That(generatedNames, Does.Contain("NewUri"));
            Assert.That(generatedNames, Does.Not.Contain("NewUrl"));
        }

        [TestCase]
        public void UseManagedServiceIdentityV3_DetectsNoSpaceValue()
        {
            // v3/v5/v6 format: "SystemAssigned,UserAssigned" (no space)
            var enumValues = new List<InputEnumTypeValue>();
            var enumType = new InputEnumType(
                "ManagedServiceIdentityType",
                "Azure.ResourceManager.Models",
                "Azure.ResourceManager.CommonTypes.ManagedServiceIdentityType",
                "public",
                null,
                "",
                "ManagedServiceIdentityType description",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                InputPrimitiveType.String,
                enumValues,
                true);
            enumValues.Add(InputFactory.EnumMember.String("None", "None", enumType));
            enumValues.Add(InputFactory.EnumMember.String("SystemAssigned", "SystemAssigned", enumType));
            enumValues.Add(InputFactory.EnumMember.String("UserAssigned", "UserAssigned", enumType));
            enumValues.Add(InputFactory.EnumMember.String("SystemAssignedUserAssigned", "SystemAssigned,UserAssigned", enumType));

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputEnums: () => [enumType]);
            Assert.That(plugin.Object.TypeFactory.UseManagedServiceIdentityV3, Is.True);
        }

        [TestCase]
        public void UseManagedServiceIdentityV3_ReturnsFalseForV4SpaceValue()
        {
            // v4 format: "SystemAssigned, UserAssigned" (with space)
            var enumValues = new List<InputEnumTypeValue>();
            var enumType = new InputEnumType(
                "ManagedServiceIdentityType",
                "Azure.ResourceManager.Models",
                "Azure.ResourceManager.CommonTypes.ManagedServiceIdentityType",
                "public",
                null,
                "",
                "ManagedServiceIdentityType description",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                InputPrimitiveType.String,
                enumValues,
                true);
            enumValues.Add(InputFactory.EnumMember.String("None", "None", enumType));
            enumValues.Add(InputFactory.EnumMember.String("SystemAssigned", "SystemAssigned", enumType));
            enumValues.Add(InputFactory.EnumMember.String("UserAssigned", "UserAssigned", enumType));
            enumValues.Add(InputFactory.EnumMember.String("SystemAssignedUserAssigned", "SystemAssigned, UserAssigned", enumType));

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputEnums: () => [enumType]);
            Assert.That(plugin.Object.TypeFactory.UseManagedServiceIdentityV3, Is.False);
        }

        [TestCase]
        public void UseManagedServiceIdentityV3_ReturnsFalseWhenEnumAbsent()
        {
            // No ManagedServiceIdentityType enum at all
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputEnums: () => []);
            Assert.That(plugin.Object.TypeFactory.UseManagedServiceIdentityV3, Is.False);
        }
    }
}

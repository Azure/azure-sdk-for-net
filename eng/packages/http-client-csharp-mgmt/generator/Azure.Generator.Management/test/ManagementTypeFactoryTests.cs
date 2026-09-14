// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Tests.Common;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Mgmt.Tests
{
    public class ManagementTypeFactoryTests
    {
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

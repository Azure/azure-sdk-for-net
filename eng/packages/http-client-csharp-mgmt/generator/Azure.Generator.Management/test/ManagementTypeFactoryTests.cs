// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.TestHelpers;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;

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
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedType, result!.FrameworkType);
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
            Assert.IsNull(result);
        }
    }
}

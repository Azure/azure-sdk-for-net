// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Tests.Common;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using NUnit.Framework;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

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

        [TestCase("Azure.ResourceManager.CommonTypes.UserAssignedIdentity")]
        [TestCase("Azure.ResourceManager.Models.UserAssignedIdentity")]
        public void UserAssignedIdentityKnownTypeMapsToFrameworkType(string crossLanguageDefinitionId)
        {
            var userAssignedIdentity = CreateUserAssignedIdentity(crossLanguageDefinitionId, "Azure.ResourceManager.Models");
            var dictionary = new InputDictionaryType("dict", InputPrimitiveType.String, new InputNullableType(userAssignedIdentity));
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [userAssignedIdentity]);

            var actual = plugin.Object.TypeFactory.CreateCSharpType(dictionary);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual!.IsDictionary, Is.True);
            Assert.That(actual.ElementType.IsFrameworkType, Is.True);
            Assert.That(actual.ElementType.FrameworkType, Is.EqualTo(typeof(UserAssignedIdentity)));
        }

        [Test]
        public void UserAssignedIdentityDeserializationUsesModelReaderWriter()
        {
            var plugin = ManagementMockHelpers.LoadMockPlugin();
            var element = new ParameterProvider("element", $"", typeof(JsonElement)).AsVariable().As<JsonElement>();
            var data = new ParameterProvider("data", $"", typeof(BinaryData)).AsVariable().As<BinaryData>();
            var options = new ScopedApi<ModelReaderWriterOptions>(new VariableExpression(typeof(ModelReaderWriterOptions), "options"));

            var expression = plugin.Object.TypeFactory.DeserializeJsonValue(
                typeof(UserAssignedIdentity),
                element,
                data,
                options,
                SerializationFormat.Default);

            Assert.That(
                expression.ToDisplayString(),
                Is.EqualTo("global::System.ClientModel.Primitives.ModelReaderWriter.Read<global::Azure.ResourceManager.Models.UserAssignedIdentity>(new global::System.BinaryData(global::System.Text.Encoding.UTF8.GetBytes(element.GetRawText())), global::Samples.ModelSerializationExtensions.WireOptions, global::Samples.SamplesContext.Default)"));
        }

        [Test]
        public void ServiceLocalUserAssignedIdentityDeserializationUsesModelReaderWriter()
        {
            var plugin = ManagementMockHelpers.LoadMockPlugin();
            var element = new ParameterProvider("element", $"", typeof(JsonElement)).AsVariable().As<JsonElement>();
            var data = new ParameterProvider("data", $"", typeof(BinaryData)).AsVariable().As<BinaryData>();
            var options = new ScopedApi<ModelReaderWriterOptions>(new VariableExpression(typeof(ModelReaderWriterOptions), "options"));
            var serviceLocalUserAssignedIdentity = CreateNonFrameworkType("UserAssignedIdentity", "Azure.ResourceManager.EdgeOrder");

            var expression = plugin.Object.TypeFactory.DeserializeJsonValue(
                serviceLocalUserAssignedIdentity,
                element,
                data,
                options,
                SerializationFormat.Default);

            Assert.That(
                expression.ToDisplayString(),
                Is.EqualTo("global::System.ClientModel.Primitives.ModelReaderWriter.Read<global::Azure.ResourceManager.Models.UserAssignedIdentity>(new global::System.BinaryData(global::System.Text.Encoding.UTF8.GetBytes(element.GetRawText())), global::Samples.ModelSerializationExtensions.WireOptions, global::Samples.SamplesContext.Default)"));
        }

        [Test]
        public void ModelDictionaryOfNullableUserAssignedIdentityDeserializationUsesModelReaderWriter()
        {
            var userAssignedIdentity = CreateUserAssignedIdentity("Azure.ResourceManager.CommonTypes.UserAssignedIdentity", "Azure.ResourceManager.EdgeOrder");
            var identityProperty = InputFactory.Property(
                "userAssignedIdentities",
                new InputDictionaryType("dict", InputPrimitiveType.String, new InputNullableType(userAssignedIdentity)),
                serializedName: "userAssignedIdentities");
            var model = InputFactory.Model("IdentityModel", properties: [identityProperty]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [userAssignedIdentity, model]);

            var provider = plugin.Object.TypeFactory.CreateModel(model);
            var serializationProvider = provider!.SerializationProviders.Single();
            var deserializationMethod = serializationProvider.Methods.Single(m => m.Signature.Name.StartsWith("Deserialize"));
            var body = deserializationMethod.BodyStatements!.ToDisplayString();

            Assert.That(body, Does.Contain("ModelReaderWriter.Read<global::Azure.ResourceManager.Models.UserAssignedIdentity>"));
            Assert.That(body, Does.Not.Contain("DeserializeUserAssignedIdentity"));
        }

        private static InputModelType CreateUserAssignedIdentity(string crossLanguageDefinitionId, string @namespace)
            => new(
                "UserAssignedIdentity",
                @namespace,
                crossLanguageDefinitionId,
                "public",
                null,
                null,
                "User assigned identity.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                [],
                null,
                [],
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new(),
                false);

        private static CSharpType CreateNonFrameworkType(string name, string @namespace)
            => (CSharpType)Activator.CreateInstance(
                typeof(CSharpType),
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                binder: null,
                args:
                [
                    name,
                    @namespace,
                    false,
                    false,
                    null,
                    Array.Empty<CSharpType>(),
                    true,
                    false,
                    null,
                    null
                ],
                culture: null)!;
    }
}

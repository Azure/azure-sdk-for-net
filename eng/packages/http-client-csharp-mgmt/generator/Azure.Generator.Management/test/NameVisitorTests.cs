// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests
{
    internal class NameVisitorTests
    {
        private const string TestClientName = "TestClient";

        [Test]
        public void TestTransformUrlToUri()
        {
            const string testModelName = "TestModelUrl";
            const string testPropertyName = "TestPropertyUrl";
            var modelProperty = InputFactory.Property(testPropertyName, InputPrimitiveType.String, serializedName: "testName", isRequired: true);
            var model = InputFactory.Model(testModelName, properties: [modelProperty]);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: model);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var operation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [testNameParameter], path: "/providers/a/test/{testName}", decorators: []);

            var client = InputFactory.Client(
                TestClientName,
                methods: [InputFactory.BasicServiceMethod("Get", operation, parameters: [testNameParameter])],
                crossLanguageDefinitionId: $"Test.{TestClientName}",
                decorators: []);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model], clients: () => [client]);

            // PreVisitModel is called during the model creation
            var type = plugin.Object.TypeFactory.CreateModel(model);
            Assert.That(type?.Name, Is.EqualTo(testModelName.Replace("Url", "Uri")));
            Assert.That(type?.Properties[0].Name, Is.EqualTo(testPropertyName.Replace("Url", "Uri")));
        }

        [TestCase("StartTime", true)]
        [TestCase("EndTime", true)]
        [TestCase("ExpirationTime", true)]
        [TestCase("AccessTierChangeTime", true)]
        [TestCase("LastSyncTimestamp", true)]
        [TestCase("ExpireOn", true)]
        [TestCase("TestTime", false)]
        [TestCase("FromStartTime", false)]
        [TestCase("StatusTimestamp", false)]
        public void IdentifiesPropertiesWhoseMtgNameDiffersFromTheGaPattern(string propertyName, bool expected)
        {
            var dateTime = new InputDateTimeType(
                DateTimeKnownEncoding.Rfc3339,
                "utcDateTime",
                "TypeSpec.utcDateTime",
                InputPrimitiveType.String);
            var inputModel = InputFactory.Model(
                "TestModel",
                properties: [InputFactory.Property(propertyName, dateTime, isRequired: true)]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [inputModel]);
            var property = plugin.Object.TypeFactory.CreateModel(inputModel)!.Properties.Single();

            Assert.That(plugin.Object.DateTimePropertyMatcher.IsMtgRenamedDateTimeProperty(property), Is.EqualTo(expected));
        }

        [Test]
        public void DateTimePropertyRenamingIsOwnedByMtg()
        {
            var dateTime = new InputDateTimeType(
                DateTimeKnownEncoding.Rfc3339,
                "utcDateTime",
                "TypeSpec.utcDateTime",
                InputPrimitiveType.String);
            var inputProperty = InputFactory.Property("StartTime", dateTime, isRequired: true);
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!
                .SetValue(inputProperty, true);
            var inputModel = InputFactory.Model("TestModel", properties: [inputProperty]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [inputModel]);

            var property = plugin.Object.TypeFactory.CreateModel(inputModel)!.Properties.Single();

            Assert.That(property.Name, Is.EqualTo("StartTime"));
        }

        [TestCase("StartTime", "StartsOn")]
        [TestCase("EndTime", "EndsOn")]
        [TestCase("CreationTime", "CreatedOn")]
        [TestCase("ExpirationTime", "ExpiresOn")]
        [TestCase("ModificationTime", "ModifiedOn")]
        [TestCase("DeletionDate", "DeletedOn")]
        [TestCase("LastModifiedTime", "LastModifiedOn")]
        [TestCase("FirstSeenTime", "FirstSeenOn")]
        [TestCase("TestDate", "TestOn")]
        [TestCase("TestDateTime", "TestOn")]
        // Names that must be preserved: MTG excludes the From/To prefixes and the PointInTime suffix,
        // and bare "Time"/"Date" are too short to carry a prefix.
        [TestCase("FromTime", "FromTime")]
        [TestCase("ToTime", "ToTime")]
        [TestCase("RestorePointInTime", "RestorePointInTime")]
        [TestCase("Time", "Time")]
        [TestCase("Date", "Date")]
        public void DateTimePropertyUsesMtgName(string testPropertyName, string expectedPropertyName)
        {
            Assert.That(GetGeneratedDateTimePropertyName(testPropertyName, InputPrimitiveType.PlainDate), Is.EqualTo(expectedPropertyName));
        }

        // The rename keys off the input type rather than the mapped C# type, so utcDateTime must
        // produce exactly the same names as plainDate.
        [TestCase("StartTime", "StartsOn")]
        [TestCase("EndTime", "EndsOn")]
        [TestCase("CreationTime", "CreatedOn")]
        [TestCase("ExpirationTime", "ExpiresOn")]
        [TestCase("RestorePointInTime", "RestorePointInTime")]
        public void UtcDateTimePropertyUsesMtgName(string testPropertyName, string expectedPropertyName)
        {
            var utcDateTime = new InputDateTimeType(DateTimeKnownEncoding.Rfc3339, "utcDateTime", "TypeSpec.utcDateTime", InputPrimitiveType.String);
            Assert.That(GetGeneratedDateTimePropertyName(testPropertyName, utcDateTime), Is.EqualTo(expectedPropertyName));
        }

        [Test]
        public void TestNonDateTimePropertyNameIsNotTransformed()
        {
            Assert.That(GetGeneratedDateTimePropertyName("StartTime", InputPrimitiveType.String), Is.EqualTo("StartTime"));
        }

        private static string? GetGeneratedDateTimePropertyName(string testPropertyName, InputType propertyType)
        {
            const string testModelName = "TestModel";
            var modelProperty = InputFactory.Property(testPropertyName, propertyType, serializedName: "testName", isRequired: true);
            var model = InputFactory.Model(testModelName, properties: [modelProperty]);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: model);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var operation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [testNameParameter], path: "/providers/a/test/{testName}", decorators: []);

            var client = InputFactory.Client(
                TestClientName,
                methods: [InputFactory.BasicServiceMethod("Get", operation, parameters: [testNameParameter])],
                crossLanguageDefinitionId: $"Test.{TestClientName}",
                decorators: []);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model], clients: () => [client]);

            // PreVisitModel is called during the model creation
            var type = plugin.Object.TypeFactory.CreateModel(model);
            return type?.Properties[0].Name;
        }

        [Test]
        public void TestPrependResourceProviderNameForModel()
        {
            var skuModelName = "Sku";
            var modelProperty = InputFactory.Property("TestName", InputPrimitiveType.String, serializedName: "testName", isRequired: true);
            var model = InputFactory.Model(skuModelName, properties: [modelProperty]);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: model);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var operation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [testNameParameter], path: "/providers/a/test/{testName}", decorators: []);

            var client = InputFactory.Client(
                TestClientName,
                methods: [InputFactory.BasicServiceMethod("Get", operation, parameters: [testNameParameter])],
                crossLanguageDefinitionId: $"Test.{TestClientName}",
                decorators: []);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model], clients: () => [client]);

            // PreVisitModel is called during the model creation
            var type = plugin.Object.TypeFactory.CreateModel(model);
            var resourceProviderName = ManagementClientGenerator.Instance.TypeFactory.ResourceProviderName;
            var updatedSkuModelName = $"{resourceProviderName}{skuModelName}";
            Assert.That(updatedSkuModelName, Is.EqualTo(type?.Name));
            Assert.That($"{resourceProviderName}{skuModelName}", Is.EqualTo(type!.Constructors[0].Signature.Name));
            var serializationProvider = type?.SerializationProviders.SingleOrDefault();
            Assert.That(serializationProvider, Is.Not.Null);
            Assert.That(updatedSkuModelName, Is.EqualTo(serializationProvider!.Name));
            var deserializationMethod = serializationProvider.Methods.SingleOrDefault(m => m.Signature.Name.StartsWith("Deserialize"));
            Assert.That(deserializationMethod!.Signature.Name, Is.EqualTo("DeserializeSamplesSku"));
        }

        [Test]
        public void TestPrependResourceProviderNameForEnum()
        {
            var enumName = "PrivateEndpointServiceConnectionStatus";
            var stringEnum = InputFactory.StringEnum(enumName, [("a", "a"), ("b", "b")]);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: stringEnum);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var operation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [testNameParameter], path: "/providers/a/test/{testName}", decorators: []);

            var client = InputFactory.Client(
                TestClientName,
                methods: [InputFactory.BasicServiceMethod("Get", operation, parameters: [testNameParameter])],
                crossLanguageDefinitionId: $"Test.{TestClientName}",
                decorators: []);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputEnums: () => [stringEnum], clients: () => [client]);

            // PreVisitEnum is called during the enum creation
            var type = plugin.Object.TypeFactory.CreateEnum(stringEnum);
            var resourceProviderName = ManagementClientGenerator.Instance.TypeFactory.ResourceProviderName;
            var updatedSkuModelName = $"{resourceProviderName}{enumName}";
            Assert.That(updatedSkuModelName, Is.EqualTo(type?.Name));
        }

        [Test]
        public void TestTransformEtagToETag()
        {
            const string testModelName = "TestModel";
            const string testPropertyName = "Etag";
            var modelProperty = InputFactory.Property(testPropertyName, InputPrimitiveType.String, serializedName: "etag", isRequired: true);
            var model = InputFactory.Model(testModelName, properties: [modelProperty]);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: model);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var operation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [testNameParameter], path: "/providers/a/test/{testName}", decorators: []);

            var client = InputFactory.Client(
                TestClientName,
                methods: [InputFactory.BasicServiceMethod("Get", operation, parameters: [testNameParameter])],
                crossLanguageDefinitionId: $"Test.{TestClientName}",
                decorators: []);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model], clients: () => [client]);

            // PreVisitModel is called during the model creation
            var type = plugin.Object.TypeFactory.CreateModel(model);
            Assert.That(type?.Properties[0].Name, Is.EqualTo("ETag"));
        }

        [Test]
        public void TestPatchModelRenameRespectsResourceDerivedClientNameOverride()
        {
            var (client, models, patchModel) = InputResourceData.ClientWithResourcePatchBodyEquivalentModelInstance();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);

            var type = plugin.Object.TypeFactory.CreateModel(patchModel);

            Assert.That(type?.Name, Is.EqualTo("OperationSpecificUpdateShape"));
        }
    }
}

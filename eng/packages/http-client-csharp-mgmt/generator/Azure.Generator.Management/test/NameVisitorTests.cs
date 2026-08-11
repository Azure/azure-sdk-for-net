// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Visitors;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests
{
    internal class NameVisitorTests
    {
        private const string TestClientName = "TestClient";

        [TestCase("IpAddress", "IPAddress")]
        [TestCase("CosmosDbAccount", "CosmosDBAccount")]
        [TestCase("OsProfile", "OSProfile")]
        [TestCase("IpDbOsIpAddressDb", "IPDBOSIPAddressDB")]
        [TestCase("IPAddressCosmosDBOSProfile", "IPAddressCosmosDBOSProfile")]
        [TestCase("Oslo", "Oslo")]
        [TestCase("Ipsum", "Ipsum")]
        [TestCase("Osmosis", "Osmosis")]
        [TestCase("osmosis", "osmosis")]
        [TestCase("dbz", "dbz")]
        [TestCase("Ipv4Address", "IPv4Address")]
        [TestCase("Ipv6Address", "IPv6Address")]
        [TestCase("Ipv4AddressIpv6", "IPv4AddressIPv6")]
        [TestCase("Ipv4", "IPv4")]
        [TestCase("Ipv6", "IPv6")]
        [TestCase("Ipv4address", "Ipv4address")]
        [TestCase("Ipv42Address", "Ipv42Address")]
        [TestCase("IPV4Address", "IPV4Address")]
        [TestCase("IPV6Address", "IPV6Address")]
        [TestCase("IpV4Address", "IPv4Address")]
        [TestCase("IpV6Address", "IPv6Address")]
        public void TestNormalizeCompleteAcronymWords(string inputName, string expectedName)
        {
            Assert.That(NameVisitor.NormalizeAcronymCasing(inputName), Is.EqualTo(expectedName));
        }

        [TestCase("IpAddress", "IPAddress")]
        [TestCase("CosmosDbAccount", "CosmosDBAccount")]
        [TestCase("OsProfile", "OSProfile")]
        [TestCase("IpDbOsIpAddressDb", "IPDBOSIPAddressDB")]
        [TestCase("IPAddressCosmosDBOSProfile", "IPAddressCosmosDBOSProfile")]
        [TestCase("Ipv4AddressIpv6", "IPv4AddressIPv6")]
        public void TestNormalizeModelAcronymCasing(string inputName, string expectedName)
        {
            var model = InputFactory.Model(inputName);
            var client = CreateClient(model);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model], clients: () => [client]);

            var type = plugin.Object.TypeFactory.CreateModel(model);

            Assert.That(type?.Name, Is.EqualTo(expectedName));
        }

        [TestCase("IpAddress", "IPAddress")]
        [TestCase("CosmosDbAccount", "CosmosDBAccount")]
        [TestCase("OsProfile", "OSProfile")]
        [TestCase("IpDbOsIpAddressDb", "IPDBOSIPAddressDB")]
        [TestCase("IPAddressCosmosDBOSProfile", "IPAddressCosmosDBOSProfile")]
        [TestCase("Ipv4Address", "IPv4Address")]
        [TestCase("Ipv6Address", "IPv6Address")]
        public void TestNormalizePropertyAcronymCasing(string inputName, string expectedName)
        {
            var modelProperty = InputFactory.Property(inputName, InputPrimitiveType.String, serializedName: "testName", isRequired: true);
            var model = InputFactory.Model("TestModel", properties: [modelProperty]);
            var client = CreateClient(model);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model], clients: () => [client]);

            var type = plugin.Object.TypeFactory.CreateModel(model);

            Assert.That(type?.Properties[0].Name, Is.EqualTo(expectedName));
        }

        [TestCase(false, "CosmosDbOsIpKind", "CosmosDBOSIPKind")]
        [TestCase(true, "IpDbOsValue", "IPDBOSValue")]
        public void TestNormalizeEnumAndUnionTypeAcronymCasing(bool isExtensible, string inputName, string expectedName)
        {
            var inputEnum = InputFactory.StringEnum(inputName, [("IpValue", "ip")], isExtensible: isExtensible);
            var client = CreateClient(inputEnum);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputEnums: () => [inputEnum], clients: () => [client]);

            var type = plugin.Object.TypeFactory.CreateEnum(inputEnum);

            Assert.That(type?.Name, Is.EqualTo(expectedName));
        }

        [Test]
        public void TestTransformUrlToUri()
        {
            const string testModelName = "IpModelUrl";
            const string testPropertyName = "DbPropertyUrl";
            var modelProperty = InputFactory.Property(testPropertyName, InputPrimitiveType.String, serializedName: "testName", isRequired: true);
            var model = InputFactory.Model(testModelName, properties: [modelProperty]);
            var client = CreateClient(model);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model], clients: () => [client]);

            // PreVisitModel is called during the model creation
            var type = plugin.Object.TypeFactory.CreateModel(model);
            Assert.That(type?.Name, Is.EqualTo("IPModelUri"));
            Assert.That(type?.Properties[0].Name, Is.EqualTo("DBPropertyUri"));
        }

        [Test]
        public void TestTransformTimePropertyName()
        {
            const string testModelName = "TestModel";
            const string testPropertyName = "OsTime";
            var modelProperty = InputFactory.Property(testPropertyName, InputPrimitiveType.PlainDate, serializedName: "testName", isRequired: true);
            var model = InputFactory.Model(testModelName, properties: [modelProperty]);
            var client = CreateClient(model);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model], clients: () => [client]);

            // PreVisitModel is called during the model creation
            var type = plugin.Object.TypeFactory.CreateModel(model);
            Assert.That(type?.Properties[0].Name, Is.EqualTo("OSOn"));
        }

        [Test]
        public void TestPrependResourceProviderNameForModel()
        {
            var skuModelName = "Sku";
            var modelProperty = InputFactory.Property("TestName", InputPrimitiveType.String, serializedName: "testName", isRequired: true);
            var model = InputFactory.Model(skuModelName, properties: [modelProperty]);
            var client = CreateClient(model);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model], clients: () => [client], primaryNamespace: "IpSamples");

            // PreVisitModel is called during the model creation
            var type = plugin.Object.TypeFactory.CreateModel(model);
            const string resourceProviderName = "IPSamples";
            var updatedSkuModelName = $"{resourceProviderName}{skuModelName}";
            Assert.That(updatedSkuModelName, Is.EqualTo(type?.Name));
            Assert.That($"{resourceProviderName}{skuModelName}", Is.EqualTo(type!.Constructors[0].Signature.Name));
            var serializationProvider = type?.SerializationProviders.SingleOrDefault();
            Assert.That(serializationProvider, Is.Not.Null);
            Assert.That(updatedSkuModelName, Is.EqualTo(serializationProvider!.Name));
            var deserializationMethod = serializationProvider.Methods.SingleOrDefault(m => m.Signature.Name.StartsWith("Deserialize"));
            Assert.That(deserializationMethod!.Signature.Name, Is.EqualTo("DeserializeIPSamplesSku"));
        }

        [Test]
        public void TestPrependResourceProviderNameForEnum()
        {
            var enumName = "PrivateEndpointServiceConnectionStatus";
            var stringEnum = InputFactory.StringEnum(enumName, [("a", "a"), ("b", "b")]);
            var client = CreateClient(stringEnum);

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
            var client = CreateClient(model);

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

        private static InputClient CreateClient(InputType responseBodyType)
        {
            var response = InputFactory.OperationResponse(statusCodes: [200], bodytype: responseBodyType);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var operation = InputFactory.Operation(name: "get", responses: [response], parameters: [testNameParameter], path: "/providers/a/test/{testName}", decorators: []);
            return InputFactory.Client(
                TestClientName,
                methods: [InputFactory.BasicServiceMethod("Get", operation, parameters: [testNameParameter])],
                crossLanguageDefinitionId: $"Test.{TestClientName}",
                decorators: []);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Text.Json.Nodes;

namespace Azure.Generator.Mgmt.Tests
{
    internal class NameVisitorTests
    {
        private const string TestClientName = "TestClient";

        private static IEnumerable<TestCaseData> RequestModelNames()
        {
            (string Stem, string Expected)[] names =
            [
                ("IpAddress", "IPAddress"),
                ("Ipv4Address", "IPv4Address"),
                ("Ipv6Address", "IPv6Address"),
                ("IpV4Address", "IPv4Address"),
                ("IpV6Address", "IPv6Address"),
                ("DbAccount", "DBAccount"),
                ("OsImage", "OSImage"),
                ("PublicIp", "PublicIP"),
                ("IpIpDbDbOsOsIpv4Ipv4Ipv6Ipv6", "IPIPDBDBOSOSIPv4IPv4IPv6IPv6"),
                ("IPAddress", "IPAddress"),
                ("IPv4Address", "IPv4Address"),
                ("IPv6Address", "IPv6Address"),
                ("Iphone", "Iphone"),
                ("DbxAccount", "DbxAccount"),
                ("Osprey", "Osprey"),
                ("Ipv4address", "Ipv4address"),
                ("IpV6address", "IPV6address"),
                ("ipAddress", "ipAddress")
            ];
            foreach (var (stem, expected) in names)
            {
                foreach (var sharedBody in new[] { false, true })
                {
                    yield return new TestCaseData(stem, expected, sharedBody);
                }
            }
        }

        [TestCaseSource(nameof(RequestModelNames))]
        public void StructuralRequestModelNamesUseSharedAcronymRules(string stem, string expected, bool sharedBody)
        {
            var (client, models) = InputResourceData.ClientWithResourcePatchBodyWithoutTags(stem, sharedBody);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);

            var type = plugin.Object.TypeFactory.CreateModel(models[1])!;

            Assert.That(type.Name, Is.EqualTo(expected + (sharedBody ? "CreateOrUpdateContent" : "Patch")));
        }

        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public void StructuralRequestModelReferencesUseFinalName(bool sharedBody, bool clientNameOverride)
        {
            var (client, models) = InputResourceData.ClientWithResourcePatchBodyWithoutTags("IpAddress", sharedBody, clientNameOverride: clientNameOverride);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var type = plugin.Object.TypeFactory.CreateModel(models[1])!;
            var expected = clientNameOverride ? "PatchType" : "IPAddress" + (sharedBody ? "CreateOrUpdateContent" : "Patch");
            var modelText = plugin.Object.GetWriter(type).Write().Content;
            var serializationText = plugin.Object.GetWriter(type.SerializationProviders.Single()).Write().Content;
            var factory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var factoryText = plugin.Object.GetWriter(factory).Write().Content;

            Assert.Multiple(() =>
            {
                Assert.That(type.Constructors.Select(c => c.Signature.Type.Name), Is.All.EqualTo(expected));
                Assert.That(modelText, Does.Contain($"partial class {expected}"));
                Assert.That(serializationText, Does.Contain($"partial class {expected}"));
                Assert.That(serializationText, Does.Contain($"new global::Samples.Models.{expected}("));
                Assert.That(factory.Methods.Any(m => m.Signature.Name == expected && m.Signature.ReturnType!.Equals(type.Type)), Is.True);
                Assert.That(factoryText, Does.Contain(expected));
                Assert.That(modelText + serializationText + factoryText, Does.Not.Contain("IpAddress"));
            });
        }

        [TestCase(false)]
        [TestCase(true)]
        public void StructuralRequestModelPreservesExplicitResourceName(bool sharedBody)
        {
            var (client, models) = InputResourceData.ClientWithResourcePatchBodyWithoutTags("IpAddress", sharedBody, resourceNameIsExplicit: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);

            Assert.That(plugin.Object.InputLibrary.ResourceMetadatas.Single().ResourceNameIsExplicit, Is.True);
            Assert.That(plugin.Object.TypeFactory.CreateModel(models[1])!.Name,
                Is.EqualTo("IpAddress" + (sharedBody ? "CreateOrUpdateContent" : "Patch")));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void StructuralRequestModelDoesNotUseUnrelatedResourceNamingIntent(bool sharedBody)
        {
            var (client, models) = InputResourceData.ClientWithResourcePatchBodyWithoutTags("IpAddress", sharedBody);
            var arguments = client.Decorators.Single().Arguments!.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var resources = JsonNode.Parse(arguments["resources"].ToString())!.AsArray();
            var unrelated = resources[0]!.DeepClone();
            unrelated["resourceIdPattern"] = "/subscriptions/{subscriptionId}/providers/Microsoft.Tests/other/{otherName}";
            unrelated["resourceType"] = "Microsoft.Tests/other";
            unrelated["methods"] = new JsonArray();
            unrelated["resourceNameIsExplicit"] = true;
            resources.Add(unrelated);
            arguments["resources"] = BinaryData.FromString(resources.ToJsonString());
            var clientWithAdditionalResource = InputFactory.Client(TestClientName, methods: client.Methods,
                decorators: [new InputDecoratorInfo("Azure.ClientGenerator.Core.@armProviderSchema", arguments)]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [clientWithAdditionalResource]);

            Assert.That(plugin.Object.TypeFactory.CreateModel(models[1])!.Name,
                Is.EqualTo("IPAddress" + (sharedBody ? "CreateOrUpdateContent" : "Patch")));
        }

        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public void StructuralRequestModelPreservesExactNaming(bool sharedBody, bool exactResource)
        {
            var (client, models) = InputResourceData.ClientWithResourcePatchBodyWithoutTags("IpAddress", sharedBody);
            typeof(InputType).GetProperty(nameof(InputType.IsExactName))!
                .SetValue(models[exactResource ? 0 : 1], true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);

            Assert.That(plugin.Object.TypeFactory.CreateModel(models[1])!.Name,
                Is.EqualTo(exactResource ? "IpAddress" + (sharedBody ? "CreateOrUpdateContent" : "Patch") : "PatchType"));
        }

        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public void StructuralRequestModelPreservesExistingName(bool sharedBody, bool customCode)
        {
            var (client, models) = InputResourceData.ClientWithResourcePatchBodyWithoutTags("IpAddress", sharedBody);
            var expected = "IpAddress" + (sharedBody ? "CreateOrUpdateContent" : "Patch");
            var source = $"namespace Samples.Models {{ public partial class {expected} {{ }} }}";
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models, clients: () => [client],
                customizationSources: customCode ? [source] : null,
                lastContractCompilation: () => customCode ? null : Helpers.BuildCompilation([("Contract.cs", source)]));
            var type = plugin.Object.TypeFactory.CreateModel(models[1])!;

            Assert.That(type.Name, Is.EqualTo(expected));
            Assert.That(customCode ? type.CustomCodeView : type.LastContractView, Is.Not.Null);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void StructuralRequestModelPreservesClientNameOverride(bool sharedBody)
        {
            var (client, models) = InputResourceData.ClientWithResourcePatchBodyWithoutTags("IpAddress", sharedBody, clientNameOverride: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);

            Assert.That(plugin.Object.TypeFactory.CreateModel(models[1])!.Name,
                Is.EqualTo("PatchType"));
        }

        [TestCase("TestModelUrl", false)]
        [TestCase("TestModelUrl", true)]
        [TestCase("Sku", false)]
        [TestCase("Sku", true)]
        public void OrdinaryModelPreservesExplicitName(string name, bool exactName)
        {
            var model = InputFactory.Model(name, decorators: exactName
                ? []
                : [new InputDecoratorInfo("Azure.ResourceManager.@hasClientNameOverride", new Dictionary<string, BinaryData>())]);
            if (exactName)
            {
                typeof(InputType).GetProperty(nameof(InputType.IsExactName))!.SetValue(model, true);
            }
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model]);

            Assert.That(plugin.Object.TypeFactory.CreateModel(model)!.Name, Is.EqualTo(name));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void StructuralRequestModelNormalizedCustomizationWinsOverPreviousContract(bool sharedBody)
        {
            var (client, models) = InputResourceData.ClientWithResourcePatchBodyWithoutTags("IpAddress", sharedBody);
            var suffix = sharedBody ? "CreateOrUpdateContent" : "Patch";
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models, clients: () => [client],
                customizationSources: [$"namespace Samples.Models {{ public partial class IPAddress{suffix} {{ }} }}"],
                lastContractCompilation: () => Helpers.BuildCompilation([
                    ("Contract.cs", $"namespace Samples.Models {{ public partial class IpAddress{suffix} {{ }} }}")
                ]));

            var type = plugin.Object.TypeFactory.CreateModel(models[1])!;

            Assert.That(type.Name, Is.EqualTo("IPAddress" + suffix));
            Assert.That(type.CustomCodeView, Is.Not.Null);
        }

        [Test]
        public void ArmResourceTypePropertyUsesSharedProjection()
        {
            var resourceType = new InputPrimitiveType(InputPrimitiveTypeKind.String, "armResourceType", "Azure.Core.armResourceType");
            var inputProperty = InputFactory.Property("type", resourceType, isReadOnly: true);
            var model = InputFactory.Model(KnownManagementTypes.ArmResourceId, properties: [inputProperty]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var provider = new SystemObjectModelProvider(typeof(ResourceData), model);

            var property = plugin.Object.TypeFactory.CreateProperty(inputProperty, provider)!;

            Assert.Multiple(() =>
            {
                Assert.That(property.Name, Is.EqualTo(nameof(ResourceData.ResourceType)));
                Assert.That(property.Type, Is.EqualTo(new CSharpType(typeof(ResourceType))));
                Assert.That(property.WireInfo!.SerializedName, Is.EqualTo("type"));
            });
        }

        [TestCase("id")]
        [TestCase("type")]
        [TestCase("location")]
        public void ArmFrameworkStringPropertyIsNotBroadlyProjected(string wireName)
        {
            var inputProperty = InputFactory.Property("currentProperty", InputPrimitiveType.String, serializedName: wireName, isReadOnly: wireName != "location");
            var model = InputFactory.Model(KnownManagementTypes.ArmResourceId, properties: [inputProperty]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var provider = new SystemObjectModelProvider(typeof(TrackedResourceData), model);

            var property = plugin.Object.TypeFactory.CreateProperty(inputProperty, provider)!;

            Assert.Multiple(() =>
            {
                Assert.That(property.Name, Is.EqualTo("CurrentProperty"));
                Assert.That(property.Type, Is.EqualTo(new CSharpType(typeof(string), isNullable: true)));
                Assert.That(property.WireInfo!.SerializedName, Is.EqualTo(wireName));
            });
        }

        [Test]
        public void OrdinaryModelPropertyIsNotArmProjected()
        {
            var inputProperty = InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true);
            var model = InputFactory.Model("CurrentResource", properties: [inputProperty]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var provider = plugin.Object.TypeFactory.CreateModel(model)!;

            var property = plugin.Object.TypeFactory.CreateProperty(inputProperty, provider)!;

            Assert.Multiple(() =>
            {
                Assert.That(property.Name, Is.EqualTo("Type"));
                Assert.That(property.Type, Is.EqualTo(new CSharpType(typeof(string), isNullable: true)));
            });
        }

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
        public void SourcePropertyRegistrationDoesNotFreezeParameterType()
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [inputModel]);
            var property = plugin.Object.TypeFactory.CreateModel(inputModel)!.Properties.Single();

            property.Update(type: typeof(int));

            Assert.That(property.AsParameter.Type, Is.EqualTo(new CSharpType(typeof(int))));
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

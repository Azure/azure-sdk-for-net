// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class ResourceGuidCompatibilityTests
    {
        private const string PopulatedGuid = "12345678-1234-5678-9abc-123456789abc";
        private const string EmptyGuid = "00000000-0000-0000-0000-000000000000";

        // Network 1.15.0 preserves the nullable GUID; absence is distinct from an explicit Guid.Empty.
        [Test]
        public void FreshLoadBalancerResourceGuidIsNull()
        {
            Assert.IsNull(new LoadBalancerData().ResourceGuid);
        }

        [TestCase("{}", null)]
        [TestCase("{\"properties\":{}}", null)]
        [TestCase("{\"properties\":{\"resourceGuid\":null}}", null)]
        [TestCase("{\"properties\":{\"resourceGuid\":\"" + PopulatedGuid + "\"}}", PopulatedGuid)]
        [TestCase("{\"properties\":{\"resourceGuid\":\"" + EmptyGuid + "\"}}", EmptyGuid)]
        public void DeserializeLoadBalancerResourceGuidPreservesNullableValue(string json, string expected)
        {
            var data = ModelReaderWriter.Read<LoadBalancerData>(BinaryData.FromString(json));

            AssertResourceGuid(data, expected);
        }

        [TestCase(null, false)]
        [TestCase(PopulatedGuid, false)]
        [TestCase(EmptyGuid, false)]
        [TestCase(null, true)]
        [TestCase(PopulatedGuid, true)]
        [TestCase(EmptyGuid, true)]
        public void LoadBalancerFactoryResourceGuidPreservesNullableValue(string value, bool useLegacyOverload)
        {
            Guid? resourceGuid = value is null ? null : Guid.Parse(value);
            var data = useLegacyOverload
                ? ArmNetworkModelFactory.LoadBalancerData(resourceType: default, resourceGuid: resourceGuid)
                : ArmNetworkModelFactory.LoadBalancerData(mode: default, resourceGuid: resourceGuid);

            AssertResourceGuid(data, value);
        }

        [TestCase("flowLog", "targetResourceGuid")]
        [TestCase("virtualNetworkAppliance", "resourceGuid")]
        [TestCase("applicationGatewayEntra", "tenantId")]
        [TestCase("scopeConnection", "tenantId")]
        [TestCase("networkSecurityPerimeter", "perimeterGuid")]
        [TestCase("networkSecurityPerimeterLink", "remotePerimeterGuid")]
        [TestCase("networkSecurityPerimeterLinkReference", "remotePerimeterGuid")]
        public void NativeGuidFamiliesPreserveAbsentNullAndPopulatedValues(string model, string property)
        {
            Assert.IsNull(ReadGuid(model, "{}"));
            Assert.IsNull(ReadGuid(model, "{\"properties\":{}}"));
            Assert.IsNull(ReadGuid(model, $"{{\"properties\":{{\"{property}\":null}}}}"));
            Assert.AreEqual(Guid.Parse(PopulatedGuid), ReadGuid(model, $"{{\"properties\":{{\"{property}\":\"{PopulatedGuid}\"}}}}"));
            Assert.AreEqual(Guid.Empty, ReadGuid(model, $"{{\"properties\":{{\"{property}\":\"{EmptyGuid}\"}}}}"));
        }

        [Test]
        public void WritableNativeGuidPropertiesPreserveNullAndValues()
        {
            var entra = new ApplicationGatewayEntraJwtValidationConfig();
            var scope = new ScopeConnectionData();

            Assert.IsNull(entra.TenantId);
            Assert.IsNull(scope.TenantId);
            entra.TenantId = Guid.Empty;
            scope.TenantId = Guid.Parse(PopulatedGuid);
            Assert.AreEqual(Guid.Empty, entra.TenantId);
            Assert.AreEqual(Guid.Parse(PopulatedGuid), scope.TenantId);
            entra.TenantId = null;
            scope.TenantId = null;
            Assert.IsNull(entra.TenantId);
            Assert.IsNull(scope.TenantId);
        }

        [Test]
        public void NativeGuidFactoriesPreserveAllBackingFamilies()
        {
            Guid populated = Guid.Parse(PopulatedGuid);

            Assert.AreEqual(populated, ArmNetworkModelFactory.FlowLogData(@type: default, targetResourceGuid: populated).TargetResourceGuid);
            Assert.AreEqual(populated, ArmNetworkModelFactory.VirtualNetworkApplianceData(privateIPAddressVersion: default, resourceGuid: populated).ResourceGuid);
            Assert.AreEqual(populated, ArmNetworkModelFactory.ApplicationGatewayEntraJwtValidationConfig(@type: default, tenantId: populated).TenantId);
            Assert.AreEqual(populated, ArmNetworkModelFactory.ScopeConnectionData(resourceType: default, tenantId: populated).TenantId);
            Assert.AreEqual(populated, ArmNetworkModelFactory.NetworkSecurityPerimeterData(tags: default, perimeterGuid: populated).PerimeterGuid);
            Assert.AreEqual(populated, ArmNetworkModelFactory.NetworkSecurityPerimeterLinkData(id: default, remotePerimeterGuid: populated).RemotePerimeterGuid);
            Assert.AreEqual(populated, ArmNetworkModelFactory.NetworkSecurityPerimeterLinkReferenceData(id: default, remotePerimeterGuid: populated).RemotePerimeterGuid);
        }

        [Test]
        public void ReadOnlyResourceGuidPersistsButIsOmittedFromWireJson()
        {
            var data = ArmNetworkModelFactory.LoadBalancerData(mode: default, resourceGuid: Guid.Parse(PopulatedGuid));

            using var persisted = JsonDocument.Parse(ModelReaderWriter.Write(data).ToString());
            Assert.AreEqual(PopulatedGuid, persisted.RootElement.GetProperty("properties").GetProperty("resourceGuid").GetString());
            using var wire = JsonDocument.Parse(ModelReaderWriter.Write(data, new ModelReaderWriterOptions("W")).ToString());
            Assert.IsFalse(wire.RootElement.GetProperty("properties").TryGetProperty("resourceGuid", out _));
        }

        private static Guid? ReadGuid(string model, string json) => model switch
        {
            "flowLog" => ModelReaderWriter.Read<FlowLogData>(BinaryData.FromString(json)).TargetResourceGuid,
            "virtualNetworkAppliance" => ModelReaderWriter.Read<VirtualNetworkApplianceData>(BinaryData.FromString(json)).ResourceGuid,
            "applicationGatewayEntra" => ModelReaderWriter.Read<ApplicationGatewayEntraJwtValidationConfig>(BinaryData.FromString(json)).TenantId,
            "scopeConnection" => ModelReaderWriter.Read<ScopeConnectionData>(BinaryData.FromString(json)).TenantId,
            "networkSecurityPerimeter" => ModelReaderWriter.Read<NetworkSecurityPerimeterData>(BinaryData.FromString(json)).PerimeterGuid,
            "networkSecurityPerimeterLink" => ModelReaderWriter.Read<NetworkSecurityPerimeterLinkData>(BinaryData.FromString(json)).RemotePerimeterGuid,
            "networkSecurityPerimeterLinkReference" => ModelReaderWriter.Read<NetworkSecurityPerimeterLinkReferenceData>(BinaryData.FromString(json)).RemotePerimeterGuid,
            _ => throw new ArgumentOutOfRangeException(nameof(model)),
        };

        private static void AssertResourceGuid(LoadBalancerData data, string expected)
        {
            if (expected is null)
            {
                Assert.IsNull(data.ResourceGuid);
            }
            else
            {
                Assert.IsTrue(data.ResourceGuid.HasValue);
                Assert.AreEqual(Guid.Parse(expected), data.ResourceGuid.Value);
            }
        }
    }
}

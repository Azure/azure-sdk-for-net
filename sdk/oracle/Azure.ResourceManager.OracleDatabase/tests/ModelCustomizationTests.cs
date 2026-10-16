// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.OracleDatabase.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.OracleDatabase.Tests
{
    public class ModelCustomizationTests
    {
        [Test]
        public void CloudVmClusterHostnameV2RoundTripsIndependentlyOfLegacyHostname()
        {
            var model = ModelReaderWriter.Read<CloudVmClusterProperties>(BinaryData.FromString("{\"cloudExadataInfrastructureId\":\"/subscriptions/sub/resourceGroups/rg/providers/Oracle.Database/cloudExadataInfrastructures/infra\",\"sshPublicKeys\":[],\"vnetId\":\"/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/vnet\",\"subnetId\":\"/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/vnet/subnets/subnet\",\"hostname\":\"cloud-host\",\"scanDnsName\":\"scan.example.com\"}"));
            Assert.That(model.HostnameV2, Is.EqualTo("cloud-host"));
            Assert.That(model.Hostname, Is.Null);
            Assert.That(model.ScanDnsName, Is.EqualTo("scan.example.com"));
            model.Hostname = "legacy-host";
            Assert.That(model.HostnameV2, Is.EqualTo("cloud-host"));
            model.HostnameV2 = "updated-host";
            Assert.That(model.Hostname, Is.EqualTo("legacy-host"));
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model));
            Assert.That(json.RootElement.GetProperty("hostname").GetString(), Is.EqualTo("updated-host"));
            Assert.That(json.RootElement.GetProperty("scanDnsName").GetString(), Is.EqualTo("scan.example.com"));
            Assert.That(json.RootElement.TryGetProperty("hostnameV2", out _), Is.False);
        }

        [Test]
        public void ExadbVmClusterHostnameV2RoundTripsIndependentlyOfLegacyHostname()
        {
            var model = ModelReaderWriter.Read<ExadbVmClusterProperties>(BinaryData.FromString("{\"sshPublicKeys\":[],\"vnetId\":\"/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/vnet\",\"subnetId\":\"/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/vnet/subnets/subnet\",\"exascaleDbStorageVaultId\":\"/subscriptions/sub/resourceGroups/rg/providers/Oracle.Database/exascaleDbStorageVaults/vault\",\"hostname\":\"exadb-host\",\"scanDnsName\":\"scan.example.com\"}"));
            Assert.That(model.HostnameV2, Is.EqualTo("exadb-host"));
            Assert.That(model.Hostname, Is.Null);
            Assert.That(model.ScanDnsName, Is.EqualTo("scan.example.com"));
            model.Hostname = "legacy-host";
            Assert.That(model.HostnameV2, Is.EqualTo("exadb-host"));
            model.HostnameV2 = "updated-host";
            Assert.That(model.Hostname, Is.EqualTo("legacy-host"));
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model));
            Assert.That(json.RootElement.GetProperty("hostname").GetString(), Is.EqualTo("updated-host"));
            Assert.That(json.RootElement.GetProperty("scanDnsName").GetString(), Is.EqualTo("scan.example.com"));
            Assert.That(json.RootElement.TryGetProperty("hostnameV2", out _), Is.False);
        }

        [Test]
        public void ExadbConstructorAssignsAndValidatesHostname()
        {
            var vnet = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/vnet");
            var subnet = new ResourceIdentifier(vnet + "/subnets/subnet");
            var vault = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Oracle.Database/exascaleDbStorageVaults/vault");
            var storage = new ExadbVmClusterStorageDetails(100);
            var model = new ExadbVmClusterProperties(vnet, subnet, "cluster", 8, vault, hostname: "exadb-host", 2, "shape", new[] { "ssh-key" }, 16, storage);
            Assert.That(model.Hostname, Is.EqualTo("exadb-host"));
            Assert.That(model.HostnameV2, Is.Null);
            var error = Assert.Throws<ArgumentNullException>(() => new ExadbVmClusterProperties(vnet, subnet, "cluster", 8, vault, hostname: null, 2, "shape", new[] { "ssh-key" }, 16, storage));
            Assert.That(error.ParamName, Is.EqualTo("hostname"));
        }

        [Test]
        public void CloudVmClusterConstructorAssignsAndValidatesHostname()
        {
            var vnet = new ResourceIdentifier("/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/vnet");
            var subnet = new ResourceIdentifier(vnet + "/subnets/subnet");
            var infrastructure = new ResourceIdentifier("/subscriptions/sub/resourceGroups/rg/providers/Oracle.Database/cloudExadataInfrastructures/infra");
            var model = new CloudVmClusterProperties(hostname: "cloud-host", 8, infrastructure, new[] { "ssh-key" }, vnet, "23", subnet, "cluster");
            Assert.That(model.Hostname, Is.EqualTo("cloud-host"));
            Assert.That(model.HostnameV2, Is.Null);
            var error = Assert.Throws<ArgumentNullException>(() => new CloudVmClusterProperties(hostname: null, 8, infrastructure, new[] { "ssh-key" }, vnet, "23", subnet, "cluster"));
            Assert.That(error.ParamName, Is.EqualTo("hostname"));
        }

        [TestCase(nameof(ArmOracleDatabaseModelFactory.CloudVmClusterProperties))]
        [TestCase(nameof(ArmOracleDatabaseModelFactory.ExadbVmClusterProperties))]
        public void ModelFactoriesPreserveLegacyHostnameParameter(string methodName)
        {
            var methods = typeof(ArmOracleDatabaseModelFactory).GetMethods()
                .Where(method => method.Name == methodName && method.GetParameters().Any(parameter => parameter.Name == "hostname"))
                .ToArray();
            Assert.That(methods, Is.Not.Empty);
            foreach (var method in methods)
            {
                Assert.That(method.GetParameters().Any(parameter => parameter.Name == "hostname"), Is.True, method.ToString());
                Assert.That(method.GetParameters().Any(parameter => parameter.Name == "hostnameV2"), Is.False, method.ToString());
            }
        }

        [Test]
        public void CloudVmClusterFactoryInitializesHostnameV2IndependentlyOfLegacyHostname()
        {
            var model = ArmOracleDatabaseModelFactory.CloudVmClusterProperties(
                cloudVmClusterOcid: null, resourceAnchorId: null, networkAnchorId: null,
                listenerPort: null, nodeCount: null, storageSizeInGbs: null, fileSystemConfigurationDetails: null,
                dataStorageSizeInTbs: null, dbNodeStorageSizeInGbs: null, memorySizeInGbs: null,
                createdOn: null, lifecycleDetails: null, timeZone: null, zoneOcid: null, hostnameV2: "cloud-host");
            Assert.That(model.HostnameV2, Is.EqualTo("cloud-host"));
            Assert.That(model.Hostname, Is.Null);
        }

        [Test]
        public void LegacyModelFactoriesInitializeHostnameIndependentlyOfHostnameV2()
        {
            var cloud = ArmOracleDatabaseModelFactory.CloudVmClusterProperties(hostname: "legacy-cloud-host");
            Assert.That(cloud.Hostname, Is.EqualTo("legacy-cloud-host"));
            Assert.That(cloud.HostnameV2, Is.Null);
#pragma warning disable CS0618 // Exercise the legacy factory retained for compatibility.
            var exadb = ArmOracleDatabaseModelFactory.ExadbVmClusterProperties(hostname: "legacy-exadb-host");
#pragma warning restore CS0618
            Assert.That(exadb.Hostname, Is.EqualTo("legacy-exadb-host"));
            Assert.That(exadb.HostnameV2, Is.Null);
        }

        [Test]
        public void MongoDbConnectionPreservesWireValue()
        {
            Assert.That(ConnectionType.MongoDbConnection, Is.EqualTo(ConnectionType.MongoDBConnection));
            Assert.That(ConnectionType.MongoDbConnection.ToString(), Is.EqualTo("MONGODB"));
        }

        [Test]
        public void BaseFactoriesInitializeDefaultCollections()
        {
            var adb = ArmOracleDatabaseModelFactory.AutonomousDatabaseBaseProperties();
            Assert.That(adb.CustomerContacts, Is.Empty);
            Assert.That(adb.PeerDBIds, Is.Empty);
            Assert.That(adb.ScheduledOperationsList, Is.Empty);
            Assert.That(adb.WhitelistedIPs, Is.Empty);
            var db = ArmOracleDatabaseModelFactory.OracleDBSystemBaseProperties();
            Assert.That(db.ScanIPs, Is.Empty);
            Assert.That(db.SshPublicKeys, Is.Empty);
        }

        [TestCase(null, "unknown")]
        [TestCase("FutureDatabaseType", "FutureDatabaseType")]
        [TestCase("Regular", "Regular")]
        public void AutonomousBaseFactoryPreservesDiscriminatorAndProperties(string discriminator, string expected)
        {
            var model = ArmOracleDatabaseModelFactory.AutonomousDatabaseBaseProperties(dataBaseType: discriminator, displayName: "mock-adb", peerDBIds: new[] { "peer" });
            Assert.That(model.DisplayName, Is.EqualTo("mock-adb"));
            Assert.That(model.PeerDBIds, Is.EqualTo(new[] { "peer" }));
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model));
            Assert.That(json.RootElement.GetProperty("dataBaseType").GetString(), Is.EqualTo(expected));
            var roundTrip = ModelReaderWriter.Read<AutonomousDatabaseBaseProperties>(ModelReaderWriter.Write(model));
            Assert.That(roundTrip.DisplayName, Is.EqualTo("mock-adb"));
        }

        [TestCase(null, "unknown")]
        [TestCase("FutureSource", "FutureSource")]
        [TestCase("None", "None")]
        public void DBSystemBaseFactoryPreservesDiscriminatorAndProperties(string discriminator, string expected)
        {
            var model = ArmOracleDatabaseModelFactory.OracleDBSystemBaseProperties(source: discriminator, resourceAnchorId: new ResourceIdentifier("/subscriptions/sub/resourceGroups/rg/providers/Oracle.Database/resourceAnchors/anchor"), networkAnchorId: new ResourceIdentifier("/subscriptions/sub/resourceGroups/rg/providers/Oracle.Database/networkAnchors/anchor"), displayName: "mock-db", scanIPs: new[] { "10.0.0.1" }, dbSystemOptionsStorageManagement: new StorageManagementType("ASM"));
            Assert.That(model.DisplayName, Is.EqualTo("mock-db"));
            Assert.That(model.ScanIPs, Is.EqualTo(new[] { "10.0.0.1" }));
            Assert.That(model.DbSystemOptionsStorageManagement, Is.EqualTo(new StorageManagementType("ASM")));
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model));
            Assert.That(json.RootElement.GetProperty("source").GetString(), Is.EqualTo(expected));
            var roundTrip = ModelReaderWriter.Read<OracleDBSystemBaseProperties>(ModelReaderWriter.Write(model));
            Assert.That(roundTrip.DisplayName, Is.EqualTo("mock-db"));
        }
    }
}

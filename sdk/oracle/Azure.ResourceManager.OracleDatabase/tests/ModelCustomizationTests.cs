// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.OracleDatabase.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.OracleDatabase.Tests
{
    public class ModelCustomizationTests
    {
        [Test]
        public void CloudVmClusterHostnameV2RoundTripsWireHostname()
        {
            var model = ModelReaderWriter.Read<CloudVmClusterProperties>(BinaryData.FromString("{\"cloudExadataInfrastructureId\":\"/subscriptions/sub/resourceGroups/rg/providers/Oracle.Database/cloudExadataInfrastructures/infra\",\"sshPublicKeys\":[],\"vnetId\":\"/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/vnet\",\"subnetId\":\"/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/vnet/subnets/subnet\",\"hostname\":\"cloud-host\",\"scanDnsName\":\"scan.example.com\"}"));
            Assert.That(model.HostnameV2, Is.EqualTo("cloud-host"));
            Assert.That(model.ScanDnsName, Is.EqualTo("scan.example.com"));
            model.HostnameV2 = "updated-host";
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model));
            Assert.That(json.RootElement.GetProperty("hostname").GetString(), Is.EqualTo("updated-host"));
            Assert.That(json.RootElement.GetProperty("scanDnsName").GetString(), Is.EqualTo("scan.example.com"));
            Assert.That(json.RootElement.TryGetProperty("hostnameV2", out _), Is.False);
        }

        [Test]
        public void ExadbVmClusterHostnameV2RoundTripsWireHostname()
        {
            var model = ModelReaderWriter.Read<ExadbVmClusterProperties>(BinaryData.FromString("{\"sshPublicKeys\":[],\"vnetId\":\"/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/vnet\",\"subnetId\":\"/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/vnet/subnets/subnet\",\"exascaleDbStorageVaultId\":\"/subscriptions/sub/resourceGroups/rg/providers/Oracle.Database/exascaleDbStorageVaults/vault\",\"hostname\":\"exadb-host\",\"scanDnsName\":\"scan.example.com\"}"));
            Assert.That(model.HostnameV2, Is.EqualTo("exadb-host"));
            Assert.That(model.ScanDnsName, Is.EqualTo("scan.example.com"));
            model.HostnameV2 = "updated-host";
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model));
            Assert.That(json.RootElement.GetProperty("hostname").GetString(), Is.EqualTo("updated-host"));
            Assert.That(json.RootElement.GetProperty("scanDnsName").GetString(), Is.EqualTo("scan.example.com"));
            Assert.That(json.RootElement.TryGetProperty("hostnameV2", out _), Is.False);
        }

        [Test]
        public void ExadbConstructorAssignsAndValidatesHostnameV2()
        {
            var vnet = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/vnet");
            var subnet = new ResourceIdentifier(vnet + "/subnets/subnet");
            var vault = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Oracle.Database/exascaleDbStorageVaults/vault");
            var storage = new ExadbVmClusterStorageDetails(100);
            var model = new ExadbVmClusterProperties(vnet, subnet, "cluster", 8, vault, hostnameV2: "exadb-host", 2, "shape", new[] { "ssh-key" }, 16, storage);
            Assert.That(model.HostnameV2, Is.EqualTo("exadb-host"));
            var error = Assert.Throws<ArgumentNullException>(() => new ExadbVmClusterProperties(vnet, subnet, "cluster", 8, vault, hostnameV2: null, 2, "shape", new[] { "ssh-key" }, 16, storage));
            Assert.That(error.ParamName, Is.EqualTo("hostnameV2"));
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

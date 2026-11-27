// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.NetworkCloud.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.NetworkCloud.Tests
{
    public class NetworkCloudModelFactoryTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void ExistingClusterFactoryPreservesSupportExpiry(bool hasExpiry)
        {
            DateTimeOffset? expiry = hasExpiry ? new DateTimeOffset(2030, 1, 2, 0, 0, 0, TimeSpan.Zero) : null;
            var cluster = ArmNetworkCloudModelFactory.NetworkCloudClusterData(
                id: default,
                name: "cluster-name",
                resourceType: default,
                systemData: default,
                tags: default,
                location: default,
                aggregatorOrSingleRackDefinition: default,
                analyticsOutputSettings: default,
                analyticsWorkspaceId: default,
                clusterLocation: default,
                clusterServicePrincipal: default,
                clusterType: default,
                clusterVersion: default,
                commandOutputSettings: default,
                computeDeploymentThreshold: default,
                computeRackDefinitions: default,
                managedResourceGroupConfiguration: default,
                networkFabricId: default,
                runtimeProtectionConfiguration: default,
                secretArchive: default,
                secretArchiveSettings: default,
                updateStrategy: default,
                actionStates: default,
                availableUpgradeVersions: default,
                clusterCapacity: default,
                clusterConnectionStatus: default,
                clusterExtendedLocation: default,
                clusterManagerConnectionStatus: default,
                clusterManagerId: default,
                detailedStatus: default,
                detailedStatusMessage: default,
                hybridAksExtendedLocation: default,
                lastSuccessfulVersionUpdateOn: default,
                managedCredentials: default,
                manualActionCount: default,
                supportExpireOn: expiry,
                workloadResourceIds: default,
                provisioningState: default,
                vulnerabilityScanningContainerScan: default,
                eTag: default,
                extendedLocation: default,
                identity: default,
                kind: default);

            Assert.That(cluster.Name, Is.EqualTo("cluster-name"));
            Assert.That(cluster.SupportExpireOn, Is.EqualTo(expiry));
        }

        [Test]
        public void ClusterFactoriesAllowOptionalArgumentsAndNewFields()
        {
            Assert.That(ArmNetworkCloudModelFactory.NetworkCloudClusterManagerData(), Is.Not.Null);
            Assert.That(ArmNetworkCloudModelFactory.NetworkCloudClusterData(), Is.Not.Null);

            var manager = ArmNetworkCloudModelFactory.NetworkCloudClusterManagerData(rolloutRing: 3);
            var certificate = ArmNetworkCloudModelFactory.NetworkCloudCertificateInfo(value: "certificate");
            var cluster = ArmNetworkCloudModelFactory.NetworkCloudClusterData(edgeManagementServiceCACertificate: certificate);

            Assert.That(manager.RolloutRing, Is.EqualTo(3));
            Assert.That(cluster.EdgeManagementServiceCACertificate, Is.SameAs(certificate));
        }
    }
}

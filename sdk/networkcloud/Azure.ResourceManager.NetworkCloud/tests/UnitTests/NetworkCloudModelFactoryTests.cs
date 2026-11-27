// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.NetworkCloud.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.NetworkCloud.Tests
{
    public class NetworkCloudModelFactoryTests
    {
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

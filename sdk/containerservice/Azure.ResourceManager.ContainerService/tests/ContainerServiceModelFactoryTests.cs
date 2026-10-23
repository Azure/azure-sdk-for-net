// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.ContainerService.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerService.Tests
{
    public class ContainerServiceModelFactoryTests
    {
        [Test]
        public void AgentPoolUpgradeProfileDataDefaults()
        {
            var profile = ArmContainerServiceModelFactory.AgentPoolUpgradeProfileData();

            Assert.IsEmpty(profile.Upgrades);
            Assert.IsEmpty(profile.ComponentsByReleases);
            Assert.IsEmpty(profile.RecentlyUsedVersions);
        }

        [Test]
        public void AgentPoolUpgradeProfileDataPreservesSuppliedVersions()
        {
            var upgrade = ArmContainerServiceModelFactory.AgentPoolUpgradeProfilePropertiesUpgradesItem("1.35.1");
            var recentlyUsedVersion = ArmContainerServiceModelFactory.AgentPoolRecentlyUsedVersion("1.34.3");
            var profile = ArmContainerServiceModelFactory.AgentPoolUpgradeProfileData(
                kubernetesVersion: "1.35.0",
                osType: ContainerServiceOSType.Linux,
                upgrades: new[] { upgrade },
                recentlyUsedVersions: new[] { recentlyUsedVersion },
                latestNodeImageVersion: "AKSUbuntu-2204gen2containerd-202610.20.0");

            Assert.AreEqual("1.35.0", profile.KubernetesVersion);
            Assert.AreEqual(ContainerServiceOSType.Linux, profile.OSType);
            CollectionAssert.AreEqual(new[] { upgrade }, profile.Upgrades);
            CollectionAssert.AreEqual(new[] { recentlyUsedVersion }, profile.RecentlyUsedVersions);
            Assert.IsEmpty(profile.ComponentsByReleases);
            Assert.AreEqual("AKSUbuntu-2204gen2containerd-202610.20.0", profile.LatestNodeImageVersion);
        }

        [Test]
        public void LegacyGpuManagementModeUsesPreviewProfile()
        {
            var profile = ArmContainerServiceModelFactory.AgentPoolGpuProfile(
                AgentPoolGpuDriver.Install, GpuManagementMode.Managed);

            Assert.AreEqual(GpuManagementMode.Managed, profile.Nvidia.ManagementMode);
            Assert.AreEqual(GpuManagementMode.Managed, profile.NvidiaManagementMode);
            profile.Nvidia.ManagementMode = GpuManagementMode.Unmanaged;
            Assert.AreEqual(GpuManagementMode.Unmanaged, profile.NvidiaManagementMode);
            profile.NvidiaManagementMode = null;
            Assert.IsNull(profile.Nvidia.ManagementMode);
        }

        [Test]
        public void LegacyUpgradeOverrideSettingsUsesPreviewUpgradeSettings()
        {
            var cluster = new ContainerServiceManagedClusterData(Azure.Core.AzureLocation.EastUS);
            var settings = new UpgradeOverrideSettings();

            Assert.IsNull(cluster.UpgradeOverrideSettings);
            cluster.UpgradeOverrideSettings = settings;
            Assert.AreSame(settings, cluster.UpgradeSettings.OverrideSettings);
            Assert.AreSame(settings, cluster.UpgradeOverrideSettings);
            cluster.UpgradeOverrideSettings = null;
            Assert.IsNull(cluster.UpgradeSettings.OverrideSettings);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void LegacyVpaEnabledPreservesAddonAutoscaling(bool enabled)
        {
            var verticalPodAutoscaler = new ManagedClusterVerticalPodAutoscaler(true)
            {
                AddonAutoscaling = ManagedClusterAddonAutoscaling.Enabled
            };
            var profile = new ManagedClusterWorkloadAutoScalerProfile
            {
                VerticalPodAutoscaler = verticalPodAutoscaler
            };

            profile.IsVpaEnabled = enabled;

            Assert.AreSame(verticalPodAutoscaler, profile.VerticalPodAutoscaler);
            Assert.AreEqual(enabled, profile.VerticalPodAutoscaler.IsVpaEnabled);
            Assert.AreEqual(ManagedClusterAddonAutoscaling.Enabled, profile.VerticalPodAutoscaler.AddonAutoscaling);
        }

        [Test]
        public void LegacyVpaEnabledCreatesProfileWhenMissing()
        {
            var profile = new ManagedClusterWorkloadAutoScalerProfile();

            profile.IsVpaEnabled = false;

            Assert.IsNotNull(profile.VerticalPodAutoscaler);
            Assert.IsFalse(profile.VerticalPodAutoscaler.IsVpaEnabled);
        }

        [Test]
        public void LegacyVpaEnabledNullClearsProfile()
        {
            var profile = new ManagedClusterWorkloadAutoScalerProfile
            {
                VerticalPodAutoscaler = new ManagedClusterVerticalPodAutoscaler(true)
                {
                    AddonAutoscaling = ManagedClusterAddonAutoscaling.Enabled
                }
            };

            profile.IsVpaEnabled = null;

            Assert.IsNull(profile.VerticalPodAutoscaler);
            Assert.IsNull(profile.IsVpaEnabled);
        }

        [Test]
        public void CSharpNamingOverridesPreserveWireNames()
        {
            var costs = ArmContainerServiceModelFactory.ContainerServiceVmSkuCosts(meterId: "meter");
            using var costsJson = JsonDocument.Parse(ModelReaderWriter.Write(costs).ToString());
            Assert.AreEqual("meter", costs.MeterId);
            Assert.AreEqual("meter", costsJson.RootElement.GetProperty("meterID").GetString());

            var kubelet = ArmContainerServiceModelFactory.BootstrapKubeletConfig(clusterFqdn: "cluster.example.test");
            using var kubeletJson = JsonDocument.Parse(ModelReaderWriter.Write(kubelet).ToString());
            Assert.AreEqual("cluster.example.test", kubelet.ClusterFqdn);
            Assert.AreEqual("cluster.example.test", kubeletJson.RootElement.GetProperty("clusterFQDN").GetString());

            var network = new ContainerServiceNetworkProfile
            {
                ClusterApiConnectivityProfile = new ClusterApiConnectivityProfile()
            };
            using var networkJson = JsonDocument.Parse(ModelReaderWriter.Write(network).ToString());
            Assert.IsTrue(networkJson.RootElement.TryGetProperty("clusterAPIConnectivityProfile", out _));

            var disk = new ManagedClusterStorageProfileDiskCsiDriver
            {
                QuickAttachDetach = new ManagedClusterStorageProfileDiskCsiDriverQuickAttachDetach
                {
                    Enabled = true
                }
            };
            using var diskJson = JsonDocument.Parse(ModelReaderWriter.Write(disk).ToString());
            Assert.IsTrue(diskJson.RootElement.GetProperty("quickAttachDetach").GetProperty("enabled").GetBoolean());
        }
    }
}

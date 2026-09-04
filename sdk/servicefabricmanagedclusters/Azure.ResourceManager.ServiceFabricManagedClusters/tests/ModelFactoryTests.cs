// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Tests
{
    public class ModelFactoryTests
    {
        [Test]
        public void FaultSimulationFactoriesPreserveDiscriminator()
        {
            FaultSimulationContent genericContent = ArmServiceFabricManagedClustersModelFactory.FaultSimulationContent("Zone");
            ZoneFaultSimulationContent zoneContent = ArmServiceFabricManagedClustersModelFactory.ZoneFaultSimulationContent();

            Assert.That(ModelReaderWriter.Write(genericContent).ToString(), Does.Contain("\"faultKind\":\"Zone\""));
            Assert.That(ModelReaderWriter.Write(zoneContent).ToString(), Does.Contain("\"faultKind\":\"Zone\""));
        }

        [Test]
        public void InstanceMixAndDiskSettingsUseExpectedWireNames()
        {
            var vmSize = new SkuProfileVmSize("Standard_D4s_v5") { Rank = 1 };
            var dataDisk = new NodeTypeVmssDataDisk(1, 128, ServiceFabricManagedDataDiskType.PremiumLrs, "E")
            {
                Caching = DiskCachingType.ReadOnly,
                WriteAcceleratorEnabled = true,
                DiskIOPSReadWrite = 5000,
                DiskMBpsReadWrite = 200,
            };
            var data = new ServiceFabricManagedNodeTypeData
            {
                SkuProfile = new SkuProfile(new[] { vmSize })
                {
                    AllocationStrategy = AllocationStrategy.Prioritized,
                },
                DataDiskCaching = DiskCachingType.ReadWrite,
                DataDiskWriteAcceleratorEnabled = true,
                DataDiskIOPSReadWrite = 10000,
                DataDiskMBpsReadWrite = 400,
            };
            data.AdditionalDataDisks.Add(dataDisk);

            string json = ModelReaderWriter.Write(data).ToString();

            Assert.That(json, Does.Contain("\"skuProfile\":{\"vmSizes\":[{\"name\":\"Standard_D4s_v5\",\"rank\":1}],\"allocationStrategy\":\"Prioritized\"}"));
            Assert.That(json, Does.Contain("\"dataDiskCaching\":\"ReadWrite\""));
            Assert.That(json, Does.Contain("\"dataDiskWriteAcceleratorEnabled\":true"));
            Assert.That(json, Does.Contain("\"dataDiskIOPSReadWrite\":10000"));
            Assert.That(json, Does.Contain("\"dataDiskMBpsReadWrite\":400"));
            Assert.That(json, Does.Contain("\"caching\":\"ReadOnly\""));
            Assert.That(json, Does.Contain("\"writeAcceleratorEnabled\":true"));
            Assert.That(json, Does.Contain("\"diskIOPSReadWrite\":5000"));
            Assert.That(json, Does.Contain("\"diskMBpsReadWrite\":200"));
        }
    }
}

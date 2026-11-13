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
    }
}

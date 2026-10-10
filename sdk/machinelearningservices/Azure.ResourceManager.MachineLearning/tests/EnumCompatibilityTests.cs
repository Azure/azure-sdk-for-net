// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.MachineLearning.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearning.Tests
{
    public class EnumCompatibilityTests
    {
        [Test]
        public void LoadBalancerTypePreservesBothShippedSpellings()
        {
            Assert.That(MachineLearningLoadBalancerType.PublicIp, Is.EqualTo(MachineLearningLoadBalancerType.PublicIP));
            Assert.That(MachineLearningLoadBalancerType.PublicIp.ToString(), Is.EqualTo("PublicIp"));
        }

        [Test]
        public void ConnectionCategoryPreservesBothShippedSpellings()
        {
            Assert.That(MachineLearningConnectionCategory.AzureMySqlDb, Is.EqualTo(MachineLearningConnectionCategory.AzureMySqlDB));
            Assert.That(MachineLearningConnectionCategory.AzurePostgresDb, Is.EqualTo(MachineLearningConnectionCategory.AzurePostgresDB));
            Assert.That(MachineLearningConnectionCategory.AzureSqlDb, Is.EqualTo(MachineLearningConnectionCategory.AzureSqlDB));
            Assert.That(MachineLearningConnectionCategory.AzureMySqlDb.ToString(), Is.EqualTo("AzureMySqlDb"));
            Assert.That(MachineLearningConnectionCategory.AzurePostgresDb.ToString(), Is.EqualTo("AzurePostgresDb"));
            Assert.That(MachineLearningConnectionCategory.AzureSqlDb.ToString(), Is.EqualTo("AzureSqlDb"));
        }
    }
}

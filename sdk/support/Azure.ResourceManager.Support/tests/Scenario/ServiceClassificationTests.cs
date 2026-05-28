// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Support.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Support.Tests
{
    internal class ServiceClassificationTests : SupportManagementTestBase
    {
        private const string _resourceId = "/subscriptions/cca0326c-4c31-46d8-8fcb-c67023a46f4b/resourceGroups/rg_vm/providers/Microsoft.Compute/virtualMachines/vmtest";

        public ServiceClassificationTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

/*        [RecordedTest]
        public async Task ClassifyServices()
        {
            var serviceClassificationContent = new ServiceClassificationContent()
            {
                IssueSummary = "test",
                ResourceId = new Core.ResourceIdentifier(_resourceId),
            };
            var serviceClassificationOutput = await DefaultSubscription.ClassifyServicesServiceClassificationAsync(serviceClassificationContent);
            this.ValidateServiceClassification(serviceClassificationOutput.Value.ServiceClassificationResults.FirstOrDefault());
        }

        private void ValidateServiceClassification(ServiceClassificationAnswer serviceClassification)
        {
            Assert.IsNotNull(serviceClassification);
            Assert.IsNotEmpty(serviceClassification.ServiceId);
            Assert.IsNotEmpty(serviceClassification.DisplayName);
            Assert.NotZero(serviceClassification.ResourceTypes.Count);
        }*/
    }
}

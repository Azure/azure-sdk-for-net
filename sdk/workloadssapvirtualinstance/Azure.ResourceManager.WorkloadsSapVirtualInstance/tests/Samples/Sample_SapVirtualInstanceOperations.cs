// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.WorkloadsSapVirtualInstance.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.WorkloadsSapVirtualInstance.Tests.Samples
{
    public class Sample_SapVirtualInstanceOperations
    {
        private ResourceGroupResource _resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateSapVirtualInstance()
        {
            #region Snippet:WorkloadsSapVirtualInstance_CreateSapVirtualInstance
            SapVirtualInstanceCollection collection = _resourceGroup.GetSapVirtualInstances();

            string sapVirtualInstanceName = "X00";
            SapVirtualInstanceData data = new SapVirtualInstanceData(new AzureLocation("eastus2"))
            {
                Tags = { ["environment"] = "production" },
            };
            ArmOperation<SapVirtualInstanceResource> lro = await collection.CreateOrUpdateAsync(
                WaitUntil.Completed, sapVirtualInstanceName, data);

            SapVirtualInstanceResource sapVirtualInstance = lro.Value;
            Console.WriteLine($"Created SAP Virtual Instance: {sapVirtualInstance.Data.Id}");
            #endregion Snippet:WorkloadsSapVirtualInstance_CreateSapVirtualInstance
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetSapVirtualInstance()
        {
            #region Snippet:WorkloadsSapVirtualInstance_GetSapVirtualInstance
            SapVirtualInstanceCollection collection = _resourceGroup.GetSapVirtualInstances();

            string sapVirtualInstanceName = "X00";
            SapVirtualInstanceResource sapVirtualInstance = await collection.GetAsync(sapVirtualInstanceName);

            Console.WriteLine($"SAP Virtual Instance name: {sapVirtualInstance.Data.Name}");
            Console.WriteLine($"SAP Virtual Instance status: {sapVirtualInstance.Data.Status}");
            #endregion Snippet:WorkloadsSapVirtualInstance_GetSapVirtualInstance
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListSapVirtualInstances()
        {
            #region Snippet:WorkloadsSapVirtualInstance_ListSapVirtualInstances
            SapVirtualInstanceCollection collection = _resourceGroup.GetSapVirtualInstances();

            await foreach (SapVirtualInstanceResource item in collection.GetAllAsync())
            {
                Console.WriteLine($"SAP Virtual Instance: {item.Data.Name} - Status: {item.Data.Status}");
            }
            #endregion Snippet:WorkloadsSapVirtualInstance_ListSapVirtualInstances
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task StartSapVirtualInstance()
        {
            #region Snippet:WorkloadsSapVirtualInstance_StartSapVirtualInstance
            SapVirtualInstanceCollection collection = _resourceGroup.GetSapVirtualInstances();

            string sapVirtualInstanceName = "X00";
            SapVirtualInstanceResource sapVirtualInstance = await collection.GetAsync(sapVirtualInstanceName);

            ArmOperation<OperationStatusResult> lro = await sapVirtualInstance.StartAsync(WaitUntil.Completed);
            Console.WriteLine($"SAP Virtual Instance started. Status: {lro.Value.Status}");
            #endregion Snippet:WorkloadsSapVirtualInstance_StartSapVirtualInstance
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task StopSapVirtualInstance()
        {
            #region Snippet:WorkloadsSapVirtualInstance_StopSapVirtualInstance
            SapVirtualInstanceCollection collection = _resourceGroup.GetSapVirtualInstances();

            string sapVirtualInstanceName = "X00";
            SapVirtualInstanceResource sapVirtualInstance = await collection.GetAsync(sapVirtualInstanceName);

            ArmOperation<OperationStatusResult> lro = await sapVirtualInstance.StopAsync(WaitUntil.Completed);
            Console.WriteLine($"SAP Virtual Instance stopped. Status: {lro.Value.Status}");
            #endregion Snippet:WorkloadsSapVirtualInstance_StopSapVirtualInstance
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteSapVirtualInstance()
        {
            #region Snippet:WorkloadsSapVirtualInstance_DeleteSapVirtualInstance
            SapVirtualInstanceCollection collection = _resourceGroup.GetSapVirtualInstances();

            string sapVirtualInstanceName = "X00";
            SapVirtualInstanceResource sapVirtualInstance = await collection.GetAsync(sapVirtualInstanceName);

            await sapVirtualInstance.DeleteAsync(WaitUntil.Completed);
            Console.WriteLine("SAP Virtual Instance deleted successfully.");
            #endregion Snippet:WorkloadsSapVirtualInstance_DeleteSapVirtualInstance
        }
    }
}

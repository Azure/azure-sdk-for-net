// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;

namespace Azure.ResourceManager.Network.Tests.Helpers
{
    public static class Deployments
    {
        public static async Task CreateVm(
            ResourcesManagementClient resourcesClient,
            string resourceGroupName,
            string location,
            string virtualMachineName,
            string storageAccountName,
            string networkInterfaceName,
            string networkSecurityGroupName,
            string diagnosticsStorageAccountName,
            string deploymentName,
            string adminPassword)
        {
            string deploymentParams = "{" +
                "\"resourceGroupName\": {\"value\": \"" + resourceGroupName + "\"}," +
                "\"location\": {\"value\": \"" + location + "\"}," +
                "\"virtualMachineName\": { \"value\": \"" + virtualMachineName + "\"}," +
                "\"virtualMachineSize\": { \"value\": \"Standard_DS1_v2\"}," +
                "\"adminUsername\": { \"value\": \"netanalytics32\"}," +
                "\"storageAccountName\": { \"value\": \"" + storageAccountName + "\"}," +
                "\"routeTableName\": { \"value\": \"" + resourceGroupName + "RT\"}," +
                "\"virtualNetworkName\": { \"value\": \"" + resourceGroupName + "-vnet\"}," +
                "\"networkInterfaceName\": { \"value\": \"" + networkInterfaceName + "\"}," +
                "\"networkSecurityGroupName\": { \"value\": \"" + networkSecurityGroupName + "\"}," +
                "\"adminPassword\": { \"value\": \"" + adminPassword + "\"}," +
                "\"storageAccountType\": { \"value\": \"Premium_LRS\"}," +
                "\"diagnosticsStorageAccountName\": { \"value\": \"" + diagnosticsStorageAccountName + "\"}," +
                "\"diagnosticsStorageAccountId\": { \"value\": \"Microsoft.Storage/storageAccounts/" + diagnosticsStorageAccountName + "\"}," +
                "\"diagnosticsStorageAccountType\": { \"value\": \"Standard_LRS\"}," +
                "\"addressPrefix\": { \"value\": \"10.17.3.0/24\"}," +
                "\"subnetName\": { \"value\": \"default\"}, \"subnetPrefix\": { \"value\": \"10.17.3.0/24\"}," +
                "\"publicIpAddressName\": { \"value\": \"" + virtualMachineName + "-ip\"}," +
                "\"publicIpAddressType\": { \"value\": \"Dynamic\"}" +
                "}";
            string templateString = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestData", "DeploymentTemplate.json"));

            JsonElement jsonTemplate = JsonSerializer.Deserialize<JsonElement>(templateString);
            JsonElement jsonParameter = JsonSerializer.Deserialize<JsonElement>(deploymentParams);

            object template = jsonTemplate.GetObject();
            IDictionary<string, object> parameterDictionary = jsonParameter.GetObject() as IDictionary<string, object>;
            object parameter = parameterDictionary;

            DeploymentProperties deploymentProperties = new DeploymentProperties(DeploymentMode.Incremental)
            {
                Template = template.ToString(),
                Parameters = parameter.ToString(),
            };
            Deployment DeploymentModel = new Deployment(deploymentProperties);

            Operation<DeploymentExtended> deploymentWait = await resourcesClient.GetDeploymentsClient().StartCreateOrUpdateAsync(resourceGroupName, deploymentName, DeploymentModel);
            await deploymentWait.WaitForCompletionAsync();
        }
    }
}

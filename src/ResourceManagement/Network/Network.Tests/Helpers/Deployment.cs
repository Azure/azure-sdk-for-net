using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Tests.Helpers
{
    public static class Deployments
    {
        public static void CreateVm(
            ResourceManagementClient resourcesClient,
            string resourceGroupName,
            string location,
            string virtualMachineName,
            string storageAccountName,
            string networkInterfaceName,
            string networkSecurityGroupName,
            string diagnosticsStorageAccountName,
            string deploymentName)
        {
            string deploymentParams = @"{" +
                @"'resourceGroupName': {'value': '" + resourceGroupName + "'}," +
                @"'location': {'value': '" + location + "'}," +
                @"'virtualMachineName': { 'value': '" + virtualMachineName + "'}," +
                @"'virtualMachineSize': { 'value': 'Standard_DS1_v2'}," +
                @"'adminUsername': { 'value': 'netanalytics32'}," +
                @"'storageAccountName': { 'value': '" + storageAccountName + "'}," +
                @"'routeTableName': { 'value': '" + resourceGroupName + "RT'}," +
                @"'virtualNetworkName': { 'value': '" + resourceGroupName + "-vnet'}," +
                @"'networkInterfaceName': { 'value': '" + networkInterfaceName + "'}," +
                @"'networkSecurityGroupName': { 'value': '" + networkSecurityGroupName + "'}," +
                @"'adminPassword': { 'value': 'netanalytics-32!'}," +
                @"'storageAccountType': { 'value': 'Premium_LRS'}," +
                @"'diagnosticsStorageAccountName': { 'value': '" + diagnosticsStorageAccountName + "'}," +
                @"'diagnosticsStorageAccountId': { 'value': 'Microsoft.Storage/storageAccounts/" + diagnosticsStorageAccountName + "'}," +
                @"'diagnosticsStorageAccountType': { 'value': 'Standard_LRS'}," +
                @"'addressPrefix': { 'value': '10.17.3.0/24'}," +
                @"'subnetName': { 'value': 'default'}, 'subnetPrefix': { 'value': '10.17.3.0/24'}," +
                @"'publicIpAddressName': { 'value': '" + virtualMachineName + "-ip'}," +
                @"'publicIpAddressType': { 'value': 'Dynamic'}" +
                @"}";

            var deploymentProperties = new DeploymentProperties
            {
                Template = JObject.Parse(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "TestData", "DeploymentTemplate.json"))),
                Parameters = JObject.Parse(deploymentParams),
                Mode = DeploymentMode.Incremental
            };

            var deployment = resourcesClient.Deployments.CreateOrUpdate(resourceGroupName, deploymentName, new Deployment(deploymentProperties));
        }
    }
}

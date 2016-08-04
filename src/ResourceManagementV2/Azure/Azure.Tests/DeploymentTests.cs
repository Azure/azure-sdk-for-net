using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests
{
    public class DeploymentTests
    {
        private string rgName = "rgchash12";
        private string deploymentName1 = "deployment1";
        private string templateUri = "https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/101-vnet-two-subnets/azuredeploy.json";
        private string parametersUri = "https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/101-vnet-two-subnets/azuredeploy.parameters.json";
        private string updateTemplate = "{\"$schema\":\"https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#\",\"contentVersion\":\"1.0.0.0\",\"parameters\":{\"vnetName\":{\"type\":\"string\",\"defaultValue\":\"VNet2\",\"metadata\":{\"description\":\"VNet name\"}},\"vnetAddressPrefix\":{\"type\":\"string\",\"defaultValue\":\"10.0.0.0/16\",\"metadata\":{\"description\":\"Address prefix\"}},\"subnet1Prefix\":{\"type\":\"string\",\"defaultValue\":\"10.0.0.0/24\",\"metadata\":{\"description\":\"Subnet 1 Prefix\"}},\"subnet1Name\":{\"type\":\"string\",\"defaultValue\":\"Subnet1\",\"metadata\":{\"description\":\"Subnet 1 Name\"}},\"subnet2Prefix\":{\"type\":\"string\",\"defaultValue\":\"10.0.1.0/24\",\"metadata\":{\"description\":\"Subnet 2 Prefix\"}},\"subnet2Name\":{\"type\":\"string\",\"defaultValue\":\"Subnet222\",\"metadata\":{\"description\":\"Subnet 2 Name\"}}},\"variables\":{\"apiVersion\":\"2015-06-15\"},\"resources\":[{\"apiVersion\":\"[variables('apiVersion')]\",\"type\":\"Microsoft.Network/virtualNetworks\",\"name\":\"[parameters('vnetName')]\",\"location\":\"[resourceGroup().location]\",\"properties\":{\"addressSpace\":{\"addressPrefixes\":[\"[parameters('vnetAddressPrefix')]\"]},\"subnets\":[{\"name\":\"[parameters('subnet1Name')]\",\"properties\":{\"addressPrefix\":\"[parameters('subnet1Prefix')]\"}},{\"name\":\"[parameters('subnet2Name')]\",\"properties\":{\"addressPrefix\":\"[parameters('subnet2Prefix')]\"}}]}}]}";
        private string updateParameters = "{\"vnetAddressPrefix\":{\"value\":\"10.0.0.0/16\"},\"subnet1Name\":{\"value\":\"Subnet1\"},\"subnet1Prefix\":{\"value\":\"10.0.0.0/24\"}}";
        private string contentVersion = "1.0.0.0";

        [Fact]
        public void CanCreateVirtulaNetwork()
        {
            ApplicationTokenCredentails credentials = new ApplicationTokenCredentails(@"C:\my.azureauth");

            IResourceManager resourceManager = ResourceManager2.Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials)
                .WithSubscription(credentials.DefaultSubscriptionId);

            resourceManager.Deployments
                .Define(deploymentName1)
                .WithNewResourceGroup(rgName, Region.US_EAST)
                .WithTemplateLink(templateUri, contentVersion)
                .WithParametersLink(parametersUri, contentVersion)
                .WithMode(DeploymentMode.Complete)
                .Create();

            // List
            var deployments = resourceManager.Deployments.ListByGroup(rgName);
            var found = from dep in deployments
            where dep.Name.Equals(deploymentName1, StringComparison.OrdinalIgnoreCase)
            select dep;

            Assert.True(found != null);

            // Get
            var deployment = resourceManager.Deployments.GetByGroup(rgName, deploymentName1);
            Assert.True(deployment != null);

            Assert.True(deployment.ProvisioningState != null);
        }
    }
}

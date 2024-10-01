// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Terraform.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Terraform.E2etest
{
    public class ExportResourceGroupE2ETest
    {
        /*
            Exports resource group specified by the environment variable RESOURCE_GROUP, under SUBSCRIPTION_ID.
            This test be skipped unless environment variable RUN_E2E_TEST is set to "true"
        */
        [Test]
        public async Task exportResourceGroupE2ETest()
        {
            bool runTest = bool.Parse(Environment.GetEnvironmentVariable("RUN_E2E_TEST") ?? "false");
            if (!runTest)
            {
                Console.WriteLine("Environment variable RUN_E2E_TEST is not set to true, skipping test");
                return;
            }

            string resourceGroup = Environment.GetEnvironmentVariable("RESOURCE_GROUP") ?? throw new ValidationException($"Environment variable RESOURCE_GROUP is not set");
            string subscriptionId = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID") ?? throw new ValidationException($"Environment variable SUBSCRIPTION_ID is not set");
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);
            BaseExportModel exportParameter = new ExportResourceGroup(resourceGroup);

            ArmOperation armOperation = await subscriptionResource.ExportTerraformAzureTerraformClientAsync(WaitUntil.Completed, exportParameter);

            Response response = armOperation.WaitForCompletionResponse();

            Console.WriteLine(response.Content.ToString());
            string hcl = hclFromResponseContent(response.Content.ToString());

            Assert.That(hcl, Does.Contain("azurerm_resource_group"));
            Assert.That(hcl, Does.Contain(resourceGroup));
        }

        private string hclFromResponseContent(string responseContent)
        {
            try
            {
                using (JsonDocument doc = JsonDocument.Parse(responseContent))
                {
                    return doc.RootElement.GetProperty("properties").GetProperty("configuration").GetString();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing json string and accessing 'properties.configuration' path", e);
            }
        }
    }
}

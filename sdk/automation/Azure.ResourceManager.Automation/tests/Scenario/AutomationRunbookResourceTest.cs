// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Automation.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Automation.Tests
{
    public class AutomationRunbookResourceTest : AutomationManagementTestBase
    {
        public AutomationRunbookResourceTest(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task ReplaceContentRunbookDraft()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "test-automation-", AzureLocation.EastUS2);

            string automationAccountName = Recording.GenerateAssetName("testAutomationAccount-");
            AutomationAccountCreateOrUpdateContent accountContent = new AutomationAccountCreateOrUpdateContent()
            {
                Name = automationAccountName,
                Location = new AzureLocation("East US 2"),
                Sku = new AutomationSku(AutomationSkuName.Free),
            };
            ArmOperation<AutomationAccountResource> lro1 = await rg.GetAutomationAccounts().CreateOrUpdateAsync(WaitUntil.Completed, automationAccountName, accountContent);
            AutomationAccountResource automationAccount = lro1.Value;

            string runbookName = "Get-AzureVMTutorial";
            AutomationRunbookCreateOrUpdateContent runbookContent = new AutomationRunbookCreateOrUpdateContent(AutomationRunbookType.PowerShellWorkflow)
            {
                Name = "Get-AzureVMTutorial",
                Location = new AzureLocation("East US 2"),
                Tags =
                    {
                        ["tag01"] = "value01",
                        ["tag02"] = "value02",
                    },
                IsLogVerboseEnabled = false,
                IsLogProgressEnabled = true,
                PublishContentLink = new AutomationContentLink()
                {
                    Uri = new Uri("https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.automation/101-automation/scripts/AzureAutomationTutorial.ps1"),
                    ContentHash = new AutomationContentHash("SHA256", "115775B8FF2BE672D8A946BD0B489918C724DDE15A440373CA54461D53010A80"),
                },
                Description = "Description of the Runbook",
                LogActivityTrace = 1,
            };
            ArmOperation<AutomationRunbookResource> lro2 = await automationAccount.GetAutomationRunbooks().CreateOrUpdateAsync(WaitUntil.Completed, runbookName, runbookContent);
            AutomationRunbookResource automationRunbook = lro2.Value;

            string content = "<#\r\n        .DESCRIPTION\r\n            An example runbook which prints out the first10 Azure VMs in your subscription (ordered alphabetically).\r\n            For more information about how this runbook authenticates to your Azure subscription, see our documentation here: http: //aka.ms/fxu3mn\r\n\r\n        .NOTES\r\n            AUTHOR: Azure Automation Team\r\n            LASTEDIT: Feb 13,\r\n            2023\r\n    #>\r\n    workflow Get-AzureVMTutorial{\r\n        #The name of the Automation Credential Asset this runbook will use to authenticate to Azure.\r\n        $CredentialAssetName = 'DefaultAzureCredential'\r\n\r\n        #Get the credential with the above name from the Automation Asset store\r\n        $Cred = Get-AutomationPSCredential -Name $CredentialAssetName\r\n        if(!$Cred){\r\n            Throw\"Could not find an Automation Credential Asset named '${CredentialAssetName}'. Make sure you have created one in this Automation Account.\"\r\n                }\r\n\r\n        #Connect to your Azure Account\r\n        $Account = Add-AzureAccount -Credential $Cred\r\n        if(!$Account){\r\n            Throw\"Could not authenticate to Azure using the credential asset '${CredentialAssetName}'. Make sure the user name and password are correct.\"\r\n                }\r\n\r\n        #TODO (optional): pick the right subscription to use. Without this line, the default subscription for your Azure Account will be used.\r\n        #Select-AzureSubscription -SubscriptionName\"TODO: your Azure subscription name here\"\r\n        \r\n        #Get all the VMs you have in your Azure subscription\r\n        $VMs = Get-AzureVM\r\n\r\n        #Print out up to10 of those VMs\r\n        if(!$VMs){\r\n            Write-Output\"No VMs were found in your subscription.\"\r\n                } else{\r\n            Write-Output $VMs[0..9\r\n                    ]\r\n                }\r\n            }";
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                Assert.DoesNotThrowAsync(async () => await automationRunbook.ReplaceContentRunbookDraftAsync(WaitUntil.Completed, stream));
            }
        }
    }
}

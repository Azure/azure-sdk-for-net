// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests.Samples
{
    public partial class DiscoTemplatesSample : SamplesBase<EasmClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void discoTemplateScenario()
        {
            #region Snippet:Sample3_DiscoTemplates_Create_Client
            #if SNIPPET
            string endpoint = "https://<region>.easm.defender.microsoft.com/subscriptions/<Your_Subscription_Id>/resourceGroups/<Your_Resource_Group_Name>/workspaces/<Your_Workspace_Name>";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                            new DefaultAzureCredential());
            #else
            string endpoint = $"https://{TestEnvironment.Region}.easm.defender.microsoft.com/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroupName}/workspaces/{TestEnvironment.WorkspaceName}";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                TestEnvironment.Credential);
            #endif
            #endregion
            #region Snippet:Sample3_DiscoTemplates_Get_Templates
            #if SNIPPET
            string partialName = "<partial_name>";
            #else
            string partialName = TestEnvironment.PartialName;
            #endif
            var response = client.GetDiscoveryTemplates(partialName);
            foreach (DiscoveryTemplate template in response)
            {
                Console.WriteLine($"{template.Id}: {template.DisplayName}");
            }
            #endregion
            #region Snippet:Sample3_DiscoTemplates_Get_Template_Seeds
            #if SNIPPET
            string templateId = Console.ReadLine();
            #else
            string templateId = TestEnvironment.TemplateId;
            #endif
            var discoTemplateResponse = client.GetDiscoveryTemplate(templateId);
            DiscoveryTemplate discoTemplate = discoTemplateResponse.Value;
            Console.WriteLine($"Chosen template id: {discoTemplate.Id}");
            Console.WriteLine("The following names will be used:");
            foreach (DiscoverySource seed in discoTemplate.Seeds)
            {
                Console.WriteLine($"{seed.Kind}: {seed.Name}");
            }
            #endregion
            #region Snippet:Sample3_DiscoTemplates_Run_Disco_Group
            string groupName = "Discovery Group from Template";
            DiscoveryGroupPayload discoGroupRequest = new DiscoveryGroupPayload();
            discoGroupRequest.TemplateId = templateId;
            client.CreateOrReplaceDiscoveryGroup(groupName, discoGroupRequest);
            client.RunDiscoveryGroup(groupName);
            #endregion
        }
    }
}

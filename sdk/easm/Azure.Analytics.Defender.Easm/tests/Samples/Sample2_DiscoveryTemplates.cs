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
            #region MyRegion
            #if SNIPPET
            string endpoint = "https://<region>.easm.defender.microsoft.com";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                            "<Your_Subscription_Id>",
                            "<Your_Resource_Group_Name>",
                            "<Your_Workspace_Name>",
                            new DefaultAzureCredential());
            #else
            string endpoint = $"https://{TestEnvironment.Region}.easm.defender.microsoft.com";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                TestEnvironment.SubscriptionId,
                TestEnvironment.ResourceGroupName,
                TestEnvironment.WorkspaceName,
                TestEnvironment.Credential);
            #endif
            #endregion
            #region Snippet:Sample3_DiscoTemplates_Get_Templates
            #if SNIPPET
            string partialName = "<partial_name>";
            #else
            string partialName = TestEnvironment.PartialName;
            #endif
            var response = client.GetDiscoTemplates(partialName);
            foreach (DiscoTemplate template in response)
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
            var discoTemplateResponse = client.GetDiscoTemplate(templateId);
            DiscoTemplate discoTemplate = discoTemplateResponse.Value;
            Console.WriteLine($"Chosen template id: {discoTemplate.Id}");
            Console.WriteLine("The following names will be used:");
            foreach (DiscoSource seed in discoTemplate.Seeds)
            {
                Console.WriteLine($"{seed.Kind}: {seed.Name}");
            }
            #endregion
            #region Snippet:Sample3_DiscoTemplates_Run_Disco_Group
            string groupName = "Discovery Group from Template";
            DiscoGroupData discoGroupRequest = new DiscoGroupData();
            discoGroupRequest.TemplateId = templateId;
            client.CreateOrReplaceDiscoGroup(groupName, discoGroupRequest);
            client.RunDiscoGroup(groupName);
            #endregion
        }
    }
}


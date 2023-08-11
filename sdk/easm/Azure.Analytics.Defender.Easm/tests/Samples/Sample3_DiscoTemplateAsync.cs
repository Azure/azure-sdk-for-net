// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Analytics.Defender.Easm.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests.Samples
{
    public partial class DiscoTemplateSample : SamplesBase<EasmClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task discoTemplateScenarioAsync()
        {
            string endpoint = $"https://{TestEnvironment.Region}.easm.defender.microsoft.com";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                            TestEnvironment.SubscriptionId,
                            TestEnvironment.ResourceGroupName,
                            TestEnvironment.WorkspaceName,
                            TestEnvironment.Credential);

            string partialName = TestEnvironment.PartialName;

            Response<DiscoTemplatePageResult> response = await client.GetDiscoTemplatesAsync(partialName);
            foreach (DiscoTemplate template in response.Value.Value)
            {
                Console.WriteLine($"{template.Id}: {template.DisplayName}");
            }

            string templateId = TestEnvironment.TemplateId;

            Response<DiscoTemplate> discoTemplateResponse = await client.GetDiscoTemplateAsync(templateId);
            DiscoTemplate discoTemplate = discoTemplateResponse.Value;

            Console.WriteLine($"Chosen template id: {discoTemplate.Id}");
            Console.WriteLine("The following names will be used:");
            foreach (DiscoSource seed in discoTemplate.Seeds)
            {
                Console.WriteLine($"{seed.Kind}: {seed.Name}");
            }

            string groupName = "Discovery Group from Template";
            DiscoGroupData discoGroupRequest = new DiscoGroupData();
            discoGroupRequest.TemplateId = templateId;

            await client.PutDiscoGroupAsync(groupName, discoGroupRequest);

            await client.RunDiscoGroupAsync(groupName);
        }
    }
}

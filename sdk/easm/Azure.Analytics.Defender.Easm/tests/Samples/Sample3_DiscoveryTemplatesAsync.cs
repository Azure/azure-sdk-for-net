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
        [AsyncOnly]
        public async System.Threading.Tasks.Task discoTemplateScenarioasync()
        {
            string endpoint = $"https://{TestEnvironment.Region}.easm.defender.microsoft.com";
            EasmClient client = new EasmClient(new System.Uri(endpoint),
                TestEnvironment.SubscriptionId,
                TestEnvironment.ResourceGroupName,
                TestEnvironment.WorkspaceName,
                TestEnvironment.Credential);

            string partialName = TestEnvironment.PartialName;
            var response = client.GetDiscoTemplatesAsync(partialName);
            await foreach (DiscoTemplate template in response)
            {
                Console.WriteLine($"{template.Id}: {template.DisplayName}");
            }
            string templateId = TestEnvironment.TemplateId;
            var discoTemplateResponse = await client.GetDiscoTemplateAsync(templateId);
            var discoTemplate = discoTemplateResponse.Value;
            Console.WriteLine($"Chosen template id: {discoTemplate.Id}");
            Console.WriteLine("The following names will be used:");
            foreach (DiscoSource seed in discoTemplate.Seeds)
            {
                Console.WriteLine($"{seed.Kind}: {seed.Name}");
            }
            string groupName = "Discovery Group from Template";
            DiscoGroupData discoGroupRequest = new DiscoGroupData();
            discoGroupRequest.TemplateId = templateId;
            await client.CreateOrReplaceDiscoGroupAsync(groupName, discoGroupRequest);
            await client.RunDiscoGroupAsync(groupName);
        }
    }
}

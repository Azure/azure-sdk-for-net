// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Analytics.Synapse.Tests;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Artifacts.Samples
{
    public partial class Sample3_HelloWorldTrigger : SamplesBase<SynapseTestEnvironment>
    {
        [Test]
        public async Task TriggerSample()
        {
            #region Snippet:CreateTriggerClientPrep
#if SNIPPET
            // Replace the string below with your actual endpoint url.
            string endpoint = "<my-endpoint-url>";
#else
            string endpoint = TestEnvironment.EndpointUrl;
#endif
            string triggerName = "Test-Trigger";
            #endregion

            #region Snippet:CreateTriggerClient
            TriggerClient client = new TriggerClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
            #endregion

            #region Snippet:CreateTrigger
            TriggerResource triggerResource = new TriggerResource(new ScheduleTrigger(new ScheduleTriggerRecurrence()));
            TriggerCreateOrUpdateTriggerOperation operation = client.StartCreateOrUpdateTrigger(triggerName, triggerResource);
            Response<TriggerResource> createdTrigger = await operation.WaitForCompletionAsync();
            #endregion

            #region Snippet:RetrieveTrigger
            TriggerResource retrievedTrigger = client.GetTrigger(triggerName);
            #endregion

            #region Snippet:ListTriggers
            Pageable<TriggerResource> triggers = client.GetTriggersByWorkspace();
            foreach (TriggerResource trigger in triggers)
            {
                System.Console.WriteLine(trigger.Name);
            }
            #endregion

            #region Snippet:DeleteTrigger
            TriggerDeleteTriggerOperation deleteOperation = client.StartDeleteTrigger(triggerName);
            await deleteOperation.WaitForCompletionResponseAsync();
            #endregion
        }
    }
}

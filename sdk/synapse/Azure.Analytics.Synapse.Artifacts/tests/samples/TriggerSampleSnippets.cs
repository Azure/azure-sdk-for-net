// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Analytics.Synapse.Samples;
using Azure.Identity;
using NUnit.Framework;
using Azure.Analytics.Synapse.Artifacts.Models;

namespace Azure.Analytics.Synapse.Artifacts.Samples
{
    public partial class TriggerSnippets : SampleFixture
    {
        [Test]
        public void TriggerSample()
        {
            #region Snippet:CreateTriggerClient
            // Replace the string below with your actual workspace url.
            string workspaceUrl = "<my-workspace-url>";
            /*@@*/workspaceUrl = TestEnvironment.WorkspaceUrl;
            TriggerClient client = new TriggerClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());
            #endregion

            #region Snippet:CreateTrigger
            TriggerCreateOrUpdateTriggerOperation operation = client.StartCreateOrUpdateTrigger("MyTrigger", new TriggerResource(new ScheduleTrigger(new ScheduleTriggerRecurrence())));
            operation.WaitForCompletionAsync().ConfigureAwait(true).GetAwaiter().GetResult();
            #endregion

            #region Snippet:RetrieveTrigger
            TriggerResource trigger = client.GetTrigger("MyTrigger");
            #endregion

            #region Snippet:ListTriggers
            Pageable<TriggerResource> triggers = client.GetTriggersByWorkspace();
            foreach (TriggerResource trig in triggers)
            {
                System.Console.WriteLine(trig.Name);
            }
            #endregion

            #region Snippet:DeleteTrigger
            client.StartDeleteTrigger("MyTrigger");
            #endregion
        }
    }
}

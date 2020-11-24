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
        private TriggerClient TriggerClient;

        [OneTimeSetUp]
        public void CreateClient()
        {
            // Environment variable with the Synapse workspace endpoint.
            string workspaceUrl = TestEnvironment.WorkspaceUrl;

            #region Snippet:CreateTriggerClient
            // Create a new Trigger client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            TriggerClient client = new TriggerClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());
            #endregion

            this.TriggerClient = client;
        }

        [Test]
        public void CreateTrigger()
        {
            #region Snippet:CreateTrigger
            TriggerCreateOrUpdateTriggerOperation operation = TriggerClient.StartCreateOrUpdateTrigger("MyTrigger", new TriggerResource(new Trigger()));
            TriggerResource trigger = operation.WaitForCompletionAsync().ConfigureAwait(true).GetAwaiter().GetResult();
            #endregion
        }

        [Test]
        public void RetrieveTrigger()
        {
            #region Snippet:RetrieveTrigger
            TriggerResource trigger = TriggerClient.GetTrigger("MyTrigger");
            #endregion
        }

        [Test]
        public void ListTriggers()
        {
            #region Snippet:ListTriggers
            Pageable<TriggerResource> triggers = TriggerClient.GetTriggersByWorkspace();
            foreach (TriggerResource trigger in triggers)
            {
                System.Console.WriteLine(trigger.Name);
            }
            #endregion
        }

        [Test]
        public void DeleteTrigger()
        {
            #region Snippet:DeleteTrigger
            TriggerClient.StartDeleteTrigger("MyTrigger");
            #endregion
        }
    }
}

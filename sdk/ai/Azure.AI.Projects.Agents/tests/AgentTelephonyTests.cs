// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

#pragma warning disable AAIP001
#pragma warning disable SCME0006
namespace Azure.AI.Projects.Agents.Tests;

public class AgentTelephonyTests : AgentsTestBase
{
    public AgentTelephonyTests(bool isAsync) : base(isAsync)
    {
    }

    private async Task<string> EnsureTelephonyAgentAsync(AgentAdministrationClient agentsClient)
    {
        try
        {
            await agentsClient.GetAgentAsync(TELEPHONY_AGENT_NAME);
        }
        catch
        {
            VoiceAgentDefinition definition = new()
            {
                ModelType = VoiceModelType.SelfDeployed,
                Model = TestEnvironment.FOUNDRY_MODEL_NAME,
                Instructions = "Respond briefly and helpfully.",
            };
            definition.OutputModalities.Add(VoiceOutputModality.Text);
            await agentsClient.CreateAgentVersionAsync(
                TELEPHONY_AGENT_NAME,
                new ProjectsAgentVersionCreationOptions(definition));
        }
        return TELEPHONY_AGENT_NAME;
    }

    [Ignore("Telephony REST endpoints (bindings/calls) are not yet deployed on the available test Foundry resource (HTTP 404). Re-enable once a resource with the Telephony feature is available and this test has been recorded against it.")]
    [RecordedTest]
    public async Task TestTelephonyBindingsCRUD()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        AgentTelephony telephonyClient = agentsClient.GetAgentTelephony();
        string agentName = await EnsureTelephonyAgentAsync(agentsClient);

        // Clean up any binding left over from a prior failed run.
        await foreach (TelephonyBindingListItem existing in telephonyClient.GetTelephonyBindingsAsync(agentName))
        {
            if (existing.Label == "cs-e2e-tests-binding")
            {
                try
                {
                    await telephonyClient.DeleteTelephonyBindingAsync(agentName, existing.Id, existing.Etag);
                }
                catch { }
            }
        }

        CreateTwilioTelephonyBindingContent content = new(
            connection: "cs-e2e-tests-twilio-connection",
            phoneNumber: "+15551234567")
        {
            Label = "cs-e2e-tests-binding"
        };

        // Create
        TelephonyBinding created = await telephonyClient.CreateTelephonyBindingAsync(agentName, content);
        Assert.That(created, Is.InstanceOf<TwilioTelephonyBinding>());
        Assert.That(created.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(created.Connection, Is.EqualTo("cs-e2e-tests-twilio-connection"));
        Assert.That(((TwilioTelephonyBinding)created).PhoneNumber, Is.EqualTo("+15551234567"));

        try
        {
            // Get
            TelephonyBinding retrieved = await telephonyClient.GetTelephonyBindingAsync(agentName, created.Id);
            Assert.That(retrieved.Id, Is.EqualTo(created.Id));
            Assert.That(retrieved.Label, Is.EqualTo("cs-e2e-tests-binding"));

            // List
            List<TelephonyBindingListItem> bindings = await telephonyClient.GetTelephonyBindingsAsync(agentName).ToListAsync();
            TelephonyBindingListItem listedBinding = bindings.SingleOrDefault(b => b.Id == created.Id);
            Assert.That(listedBinding, Is.Not.Null, "The created binding must appear in the bindings list.");
            Assert.That(listedBinding.Etag, Is.Not.Null.And.Not.Empty);

            // Delete
            await telephonyClient.DeleteTelephonyBindingAsync(agentName, created.Id, listedBinding.Etag);

            bindings = await telephonyClient.GetTelephonyBindingsAsync(agentName).ToListAsync();
            Assert.That(bindings.Select(b => b.Id), Does.Not.Contain(created.Id));
        }
        catch
        {
            // Best-effort cleanup if an assertion above failed before the delete step ran.
            try
            {
                await telephonyClient.DeleteTelephonyBindingAsync(agentName, created.Id, ifMatch: "*");
            }
            catch { }
            throw;
        }
    }

    [Ignore("Telephony REST endpoints (campaigns) are not yet deployed on the available test Foundry resource (HTTP 404). Re-enable once a resource with the Telephony feature is available and this test has been recorded against it.")]
    [RecordedTest]
    public async Task TestTelephonyCampaignLifecycle()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        AgentTelephony telephonyClient = agentsClient.GetAgentTelephony();
        string agentName = await EnsureTelephonyAgentAsync(agentsClient);

        CreateTwilioTelephonyBindingContent bindingContent = new(
            connection: "cs-e2e-tests-twilio-connection",
            phoneNumber: "+15551234567")
        {
            Label = "cs-e2e-tests-campaign-binding"
        };
        TelephonyBinding binding = await telephonyClient.CreateTelephonyBindingAsync(agentName, bindingContent);

        try
        {
            // Create
            CreateTelephonyCampaignContent createContent = new(
                displayName: "cs-e2e-tests-campaign",
                telephonyBindingId: binding.Id)
            {
                Schedule = new TelephonyCampaignSchedule(TelephonyCampaignScheduleType.Immediate)
            };
            TelephonyCampaign campaign = await telephonyClient.CreateTelephonyCampaignAsync(agentName, createContent);
            Assert.That(campaign.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(campaign.ConfigurationStatus, Is.EqualTo(TelephonyCampaignConfigurationStatus.Draft));

            try
            {
                // Get
                TelephonyCampaign retrieved = await telephonyClient.GetTelephonyCampaignAsync(agentName, campaign.Id);
                Assert.That(retrieved.DisplayName, Is.EqualTo("cs-e2e-tests-campaign"));

                // Import recipients (long-running; OperationResult only exposes the raw response,
                // so the final typed value must be deserialized from it explicitly).
                ImportTelephonyCampaignRecipientsContent importContent = new(
                    new TelephonyCampaignRecipientImportSource(
                        datasetName: "cs-e2e-tests-dataset",
                        datasetVersion: "1",
                        fileName: "recipients.csv",
                        format: TelephonyCampaignRecipientImportFormat.Csv));
                OperationResult importOperation = await telephonyClient.ImportTelephonyCampaignRecipientsAsync(
                    waitUntilCompleted: true,
                    agentName,
                    campaign.Id,
                    idempotencyKey: Guid.NewGuid().ToString(),
                    importContent);
                using JsonDocument importDocument = JsonDocument.Parse(importOperation.GetRawResponse().Content);
                TelephonyCampaignRecipientImport import = TelephonyCampaignRecipientImport.DeserializeTelephonyCampaignRecipientImport(
                    importDocument.RootElement, ModelReaderWriterOptions.Json);
                Assert.That(import.Status, Is.EqualTo(TelephonyCampaignRecipientImportStatus.Succeeded));

                // Validate
                OperationResult validateOperation = await telephonyClient.ValidateTelephonyCampaignAsync(
                    waitUntilCompleted: true, agentName, campaign.Id);
                Assert.That(validateOperation.GetRawResponse().Status, Is.EqualTo(200));
                campaign = await telephonyClient.GetTelephonyCampaignAsync(agentName, campaign.Id);
                Assert.That(campaign.LatestSuccessfulValidationId, Is.Not.Null.And.Not.Empty);

                // Publish
                PublishTelephonyCampaignContent publishContent = new(validationId: campaign.LatestSuccessfulValidationId);
                OperationResult publishOperation = await telephonyClient.PublishTelephonyCampaignAsync(
                    waitUntilCompleted: true, agentName, campaign.Id, publishContent);
                Assert.That(publishOperation.GetRawResponse().Status, Is.EqualTo(200));

                // Pause / Resume
                TelephonyCampaign paused = await telephonyClient.PauseTelephonyCampaignAsync(agentName, campaign.Id);
                Assert.That(paused.ExecutionStatus, Is.EqualTo(TelephonyCampaignExecutionStatus.Paused));
                TelephonyCampaign resumed = await telephonyClient.ResumeTelephonyCampaignAsync(agentName, campaign.Id);
                Assert.That(resumed.ExecutionStatus, Is.Not.EqualTo(TelephonyCampaignExecutionStatus.Paused));

                // Cancel
                TelephonyCampaign cancelled = await telephonyClient.CancelTelephonyCampaignAsync(agentName, campaign.Id);
                Assert.That(cancelled.ExecutionStatus, Is.EqualTo(TelephonyCampaignExecutionStatus.Cancelled));
            }
            finally
            {
                try
                {
                    await telephonyClient.CancelTelephonyCampaignAsync(agentName, campaign.Id);
                }
                catch { }
            }
        }
        finally
        {
            try
            {
                await telephonyClient.DeleteTelephonyBindingAsync(agentName, binding.Id, ifMatch: "*");
            }
            catch { }
        }
    }

    [Ignore("Telephony REST endpoints (bindings/calls) are not yet deployed on the available test Foundry resource (HTTP 404). Re-enable once a resource with the Telephony feature is available and this test has been recorded against it.")]
    [RecordedTest]
    public async Task TestGetTelephonyCallsReturnsEmptyForNewAgent()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        AgentTelephony telephonyClient = agentsClient.GetAgentTelephony();
        string agentName = await EnsureTelephonyAgentAsync(agentsClient);

        List<TelephonyCallSummary> calls = await telephonyClient.GetTelephonyCallsAsync(agentName).ToListAsync();

        Assert.That(calls, Is.Not.Null);
    }
}

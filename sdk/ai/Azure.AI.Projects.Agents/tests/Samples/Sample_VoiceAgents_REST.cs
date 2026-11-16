// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Agents.Tests.Samples;

public class Sample_VoiceAgents_REST : SamplesBase
{
    public Sample_VoiceAgents_REST(bool isAsync) : base(isAsync)
    {
    }

    // These samples clean up their own exact-owned resources, not the generic test suite's fixtures.
    public override Task Cleanup() => Task.CompletedTask;

    [Test]
    [AsyncOnly]
    public async Task AdministerVoiceAgentAsync()
    {
        #region Snippet:Sample_VoiceAgents_REST_Admin
#if SNIPPET
        string projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        string modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_REALTIME_MODEL_NAME");
#else
        string projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string modelDeploymentName = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME;
#endif
        AgentAdministrationClient administration = new(
            new Uri(projectEndpoint),
            new DefaultAzureCredential());
        string agentName = $"voice-r-{Guid.NewGuid():N}";
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));

        VoiceAgentDefinition definition = new()
        {
            ModelType = VoiceModelType.SelfDeployed,
            Model = modelDeploymentName,
            Instructions = "Respond briefly and helpfully.",
            Store = true,
        };
        definition.OutputModalities.Add(VoiceOutputModality.Text);

        try
        {
            ClientResult<ProjectsAgentVersion> createResult =
                await administration.CreateAgentVersionAsync(
                    agentName,
                    new ProjectsAgentVersionCreationOptions(definition),
                    cancellationToken: timeout.Token);
            ProjectsAgentVersion created = createResult;
            if (created.Name != agentName || string.IsNullOrEmpty(created.Version))
            {
                throw new InvalidOperationException("The created agent did not have the requested name and a version.");
            }
            Console.WriteLine(
                $"Created voice agent '{created.Name}' version '{created.Version}' " +
                $"(HTTP {createResult.GetRawResponse().Status}).");

            ClientResult<ProjectsAgentVersion> readResult = await administration.GetAgentVersionAsync(
                agentName,
                created.Version,
                timeout.Token);
            ProjectsAgentVersion current = readResult;
            if (current.Name != agentName || current.Version != created.Version ||
                current.Definition is not VoiceAgentDefinition currentDefinition ||
                currentDefinition.Model != modelDeploymentName || currentDefinition.Store != true)
            {
                throw new InvalidOperationException("The stored voice agent configuration did not match the created version.");
            }
            Console.WriteLine(
                $"Voice model: {currentDefinition.Model}; configuration status: {current.Status}; " +
                $"HTTP {readResult.GetRawResponse().Status}");

            bool foundCreatedVersion = false;
            await foreach (ProjectsAgentVersion version in administration.GetAgentVersionsAsync(
                agentName,
                limit: 10,
                cancellationToken: timeout.Token))
            {
                foundCreatedVersion |= version.Version == created.Version;
                Console.WriteLine($"Version {version.Version}: {version.Status}");
            }
            if (!foundCreatedVersion)
            {
                throw new InvalidOperationException("The created voice agent version was not returned by the version list.");
            }
        }
        finally
        {
            using CancellationTokenSource cleanupTimeout = new(TimeSpan.FromSeconds(30));
            try
            {
                ClientResult deleted = await administration.DeleteAgentAsync(agentName, cleanupTimeout.Token);
                Console.WriteLine($"Deleted voice agent '{agentName}': HTTP {deleted.GetRawResponse().Status}");
            }
            catch (ClientResultException exception) when (exception.Status == 404)
            {
                Console.WriteLine($"Temporary voice agent '{agentName}' is already absent.");
            }
        }
        #endregion
        using CancellationTokenSource verificationTimeout = new(TimeSpan.FromSeconds(30));
        ClientResultException notFound = Assert.ThrowsAsync<ClientResultException>(async () =>
            await administration.GetAgentAsync(agentName, verificationTimeout.Token));
        Assert.That(notFound.Status, Is.EqualTo(404));
        Console.WriteLine($"Verified temporary voice agent '{agentName}' is absent: HTTP 404");
    }

    [Test]
    [AsyncOnly]
    public async Task ReadTelephonyResourcesAsync()
    {
        #region Snippet:Sample_VoiceAgents_REST_TelephonyReadOnly
#if SNIPPET
        string projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        string agentName = Environment.GetEnvironmentVariable("VOICE_AGENT_NAME");
        string bindingId = Environment.GetEnvironmentVariable("VOICE_TELEPHONY_BINDING_ID");
        string callId = Environment.GetEnvironmentVariable("VOICE_TELEPHONY_CALL_ID");
        string callJobId = Environment.GetEnvironmentVariable("VOICE_TELEPHONY_CALL_JOB_ID");
#else
        string projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string agentName = GetRequiredFixture("VOICE_AGENT_NAME");
        string bindingId = GetRequiredFixture("VOICE_TELEPHONY_BINDING_ID");
        string callId = GetRequiredFixture("VOICE_TELEPHONY_CALL_ID");
        string callJobId = GetRequiredFixture("VOICE_TELEPHONY_CALL_JOB_ID");
#endif
        AgentAdministrationClient administration = new(
            new Uri(projectEndpoint),
            new DefaultAzureCredential());
        BetaVoiceAgentsTelephony telephony = administration.GetBetaVoiceAgentTelephony();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(1));

        await foreach (TelephonyBindingListItem binding in telephony.GetTelephonyBindingsAsync(
            agentName,
            limit: 10,
            cancellationToken: timeout.Token))
        {
            Console.WriteLine($"Binding '{binding.Id}': {binding.Label}");
        }
        ClientResult<TelephonyBinding> bindingResult = await telephony.GetTelephonyBindingAsync(
            agentName, bindingId, timeout.Token);
        TelephonyBinding selectedBinding = bindingResult;
        if (selectedBinding.Id != bindingId)
        {
            throw new InvalidOperationException("The returned binding did not match the configured fixture.");
        }
        Console.WriteLine(
            $"Selected binding '{selectedBinding.Id}' uses connection '{selectedBinding.ConnectionName}'; " +
            $"HTTP {bindingResult.GetRawResponse().Status}");

        await foreach (TelephonyCallSummary call in telephony.GetTelephonyCallsAsync(
            agentName,
            (TelephonyProvider?)null,
            limit: 10,
            cancellationToken: timeout.Token))
        {
            Console.WriteLine($"Call '{call.Id}': {call.Status}, started {call.StartedOn:O}");
        }
        ClientResult<TelephonyCallRecord> callResult = await telephony.GetTelephonyCallAsync(
            agentName, callId, timeout.Token);
        TelephonyCallRecord selectedCall = callResult;
        if (selectedCall.Id != callId)
        {
            throw new InvalidOperationException("The returned call did not match the configured fixture.");
        }
        Console.WriteLine($"Selected call '{selectedCall.Id}': {selectedCall.Status}; HTTP {callResult.GetRawResponse().Status}");

        ClientResult<TelephonyCallJob> callJobResult = await telephony.GetTelephonyCallJobAsync(
            agentName, callJobId, timeout.Token);
        TelephonyCallJob callJob = callJobResult;
        if (callJob.Id != callJobId)
        {
            throw new InvalidOperationException("The returned call job did not match the configured fixture.");
        }
        Console.WriteLine(
            $"Call job '{callJob.Id}': {callJob.Status}; destination type: {callJob.Destination.GetType().Name}; " +
            $"HTTP {callJobResult.GetRawResponse().Status}");

        ClientResult<TelephonyTransferTargets> targetsResult =
            await telephony.GetTelephonyTransferTargetsAsync(agentName, timeout.Token);
        Console.WriteLine($"Read transfer targets: HTTP {targetsResult.GetRawResponse().Status}");
        foreach (TelephonyTransferTarget target in targetsResult.Value.TransferTargets)
        {
            Console.WriteLine($"Transfer target '{target.Name}': {target.Destination.Value}");
        }
        #endregion
    }

    [Test]
    [AsyncOnly]
    public async Task ReadTelephonyCampaignAsync()
    {
        #region Snippet:Sample_VoiceAgents_REST_CampaignReadOnly
#if SNIPPET
        string projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        string agentName = Environment.GetEnvironmentVariable("VOICE_AGENT_NAME");
        string campaignName = Environment.GetEnvironmentVariable("VOICE_TELEPHONY_CAMPAIGN_NAME");
        string operationId = Environment.GetEnvironmentVariable("VOICE_TELEPHONY_CAMPAIGN_OPERATION_ID");
#else
        string projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string agentName = GetRequiredFixture("VOICE_AGENT_NAME");
        string campaignName = GetRequiredFixture("VOICE_TELEPHONY_CAMPAIGN_NAME");
        string operationId = GetRequiredFixture("VOICE_TELEPHONY_CAMPAIGN_OPERATION_ID");
#endif
        AgentAdministrationClient administration = new(
            new Uri(projectEndpoint),
            new DefaultAzureCredential());
        TelephonyCampaigns campaigns = administration.GetBetaVoiceAgentTelephonyCampaigns();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(1));

        // Construct configuration only: submitting a campaign authorizes outbound calls.
        TelephonyCampaign proposedCampaign = new(
            connectionName: "project-telephony-connection",
            source: new PhoneNumber("+15555550100"));
        proposedCampaign.Recipients.Add(new TelephonyRecipient(new PhoneNumber("+15555550101")));
        TelephonyTransferTarget teamsTransfer = new(
            "Transfer to a Teams support account.",
            new TeamsAddress("11111111-2222-3333-4444-555555555555"))
        {
            Name= "teams-support"
        };
        TelephonyTransferTarget sipTransfer = new(
            "Transfer to a SIP support address.",
            new SipAddress("sip:support@contoso.com"))
        {
            Name = "sip-support"
        };
        Console.WriteLine(
            $"Prepared (but did not submit) {proposedCampaign.Recipients.Count} typed recipients.");
        Console.WriteLine($"Prepared transfer targets '{teamsTransfer.Name}' and '{sipTransfer.Name}' without submitting them.");

        ClientResult<TelephonyCampaign> campaignResult = await campaigns.GetAsync(
            agentName, campaignName, operationId, timeout.Token);
        TelephonyCampaign campaign = campaignResult;
        if (campaign.Name != campaignName)
        {
            throw new InvalidOperationException("The returned campaign did not match the configured fixture.");
        }
        Console.WriteLine(
            $"Campaign '{campaign.Name}': {campaign.Status}; operation '{campaign.OperationId}'; " +
            $"HTTP {campaignResult.GetRawResponse().Status}");
        if (campaign.Error is FoundryOpenAIError campaignError)
        {
            Console.WriteLine(
                $"Campaign error '{campaignError.Code}' ({campaignError.Type}): {campaignError.Message}");
        }

        ClientResult<TelephonyCampaignOperation> operationResult = await campaigns.GetOperationAsync(
            agentName, campaignName, operationId, timeout.Token);
        TelephonyCampaignOperation operation = operationResult;
        if (operation.Id != operationId)
        {
            throw new InvalidOperationException("The returned operation did not match the configured fixture.");
        }
        Console.WriteLine(
            $"Operation '{operation.Id}': {operation.Kind}, {operation.Status}; HTTP {operationResult.GetRawResponse().Status}");
        if (operation.Error is FoundryOpenAIError operationError)
        {
            Console.WriteLine($"Operation error '{operationError.Code}': {operationError.Message}");
        }

        await foreach (TelephonyCampaignValidationError validationError
            in campaigns.GetValidationErrorsAsync(
                agentName,
                campaignName,
                limit: 20,
                cancellationToken: timeout.Token))
        {
            FoundryOpenAIError error = validationError.Error;
            Console.WriteLine(
                $"Recipient row {validationError.RowNumber}: {error.Code} " +
                $"({error.Param}) - {error.Message}");
        }
        #endregion
    }

    private static string GetRequiredFixture(string name)
    {
        string value = Environment.GetEnvironmentVariable(name);
        Assume.That(value, Is.Not.Null.And.Not.Empty, $"Set {name} to run this read-only live sample.");
        return value;
    }
}

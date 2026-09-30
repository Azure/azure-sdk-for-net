// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

#pragma warning disable AAIP001
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
        catch (ClientResultException ex) when (ex.Status == 404)
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

    [Ignore("Verified live (2026-09-17) that the Telephony routes ARE now deployed on the test Foundry resource, but this specific test creates a real Twilio-provider binding, which needs a real Twilio connection configured on the project that this test environment does not have. Re-enable once such a connection is available and this test has been recorded against it.")]
    [RecordedTest]
    public async Task TestTelephonyBindingsCRUD()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        BetaVoiceAgentsTelephony telephonyClient = agentsClient.GetBetaVoiceAgentTelephony();
        string agentName = await EnsureTelephonyAgentAsync(agentsClient);

        // Clean up any binding left over from a prior failed run.
        await foreach (TelephonyBindingListItem existing in telephonyClient.GetTelephonyBindingsAsync(agentName))
        {
            if (existing.Label == "cs-e2e-tests-binding")
            {
                try
                {
                    await telephonyClient.DeleteTelephonyBindingAsync(agentName, existing.Id, existing.Etag, CancellationToken.None);
                }
                catch { }
            }
        }

        CreateTwilioTelephonyBindingContent content = new(
            connectionName: "cs-e2e-tests-twilio-connection",
            phoneNumber: "+15551234567")
        {
            Label = "cs-e2e-tests-binding"
        };

        // Create
        TelephonyBinding created = await telephonyClient.CreateTelephonyBindingAsync(agentName, content, CancellationToken.None);
        Assert.That(created, Is.InstanceOf<TwilioTelephonyBinding>());
        Assert.That(created.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(created.ConnectionName, Is.EqualTo("cs-e2e-tests-twilio-connection"));
        Assert.That(((TwilioTelephonyBinding)created).PhoneNumber, Is.EqualTo("+15551234567"));

        try
        {
            // Get
            TelephonyBinding retrieved = await telephonyClient.GetTelephonyBindingAsync(agentName, created.Id, CancellationToken.None);
            Assert.That(retrieved.Id, Is.EqualTo(created.Id));
            Assert.That(retrieved.Label, Is.EqualTo("cs-e2e-tests-binding"));

            // List
            List<TelephonyBindingListItem> bindings = await telephonyClient.GetTelephonyBindingsAsync(agentName).ToListAsync();
            TelephonyBindingListItem listedBinding = bindings.SingleOrDefault(b => b.Id == created.Id);
            Assert.That(listedBinding, Is.Not.Null, "The created binding must appear in the bindings list.");
            Assert.That(listedBinding.Etag, Is.Not.Null.And.Not.Empty);

            // Delete
            await telephonyClient.DeleteTelephonyBindingAsync(agentName, created.Id, listedBinding.Etag, CancellationToken.None);

            bindings = await telephonyClient.GetTelephonyBindingsAsync(agentName).ToListAsync();
            Assert.That(bindings.Select(b => b.Id), Does.Not.Contain(created.Id));
        }
        catch
        {
            // Best-effort cleanup if an assertion above failed before the delete step ran.
            try
            {
                await telephonyClient.DeleteTelephonyBindingAsync(agentName, created.Id, "*", CancellationToken.None);
            }
            catch { }
            throw;
        }
    }

    [RecordedTest]
    public async Task TestGetTelephonyCallsReturnsEmptyForNewAgent()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        BetaVoiceAgentsTelephony telephonyClient = agentsClient.GetBetaVoiceAgentTelephony();
        string agentName = await EnsureTelephonyAgentAsync(agentsClient);

        List<TelephonyCallSummary> calls = await telephonyClient.GetTelephonyCallsAsync(agentName, (TelephonyProvider?)null).ToListAsync();
        Console.WriteLine($"[REST] LIST telephony calls -> {calls.Count} call(s)");

        Assert.That(calls, Is.Not.Null);
    }

    // -----------------------------------------------------------------------
    // Round-trips the telephony transfer targets configured for a voice agent: empty on a fresh
    // agent -> replace with one PSTN target -> confirm persistence -> clear (empty array) -> confirm
    // empty again. Mirrors azure-ai-projects' (Python)
    // test_voice_agent_telephony.py::test_telephony_bindings_and_transfer_targets.
    // -----------------------------------------------------------------------
    [Ignore("Verified live (2026-09-17) that replace_transfer_targets with If-Match: * still surfaces a 409 conflict (\"changed after they were read\") on this shared test resource even with [NonParallelizable] applied, indicating something outside this test's own process is concurrently touching the same fixed agent name's transfer targets. Re-enable once run with CLIENTMODEL_TEST_MODE=Record against a resource/agent name not subject to that contention.")]
    [NonParallelizable]
    [RecordedTest]
    public async Task TestTelephonyTransferTargetsRoundTrip()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        BetaVoiceAgentsTelephony telephonyClient = agentsClient.GetBetaVoiceAgentTelephony();
        string agentName = await EnsureTelephonyAgentAsync(agentsClient);

        TelephonyTransferTargets targets = await telephonyClient.GetTelephonyTransferTargetsAsync(agentName, CancellationToken.None);
        Assert.That(targets.TransferTargets, Is.Empty, "A freshly created agent must have no configured transfer targets.");

        TelephonyTransferTarget newTarget = new(
            name: "sales_desk",
            description: "Transfers to the sales desk for pricing questions.",
            destination: new PSTNTelephonyTransferDestination("+14255550123"));

        TelephonyTransferTargets replaced = await telephonyClient.ReplaceTelephonyTransferTargetsAsync(agentName, "*", [newTarget], CancellationToken.None);
        Assert.That(replaced.TransferTargets, Has.Count.EqualTo(1));
        Assert.That(replaced.TransferTargets[0].Name, Is.EqualTo("sales_desk"));
        Assert.That(replaced.TransferTargets[0].Destination, Is.InstanceOf<PSTNTelephonyTransferDestination>());

        TelephonyTransferTargets confirmed = await telephonyClient.GetTelephonyTransferTargetsAsync(agentName, CancellationToken.None);
        Assert.That(confirmed.TransferTargets, Has.Count.EqualTo(1));
        Assert.That(confirmed.TransferTargets[0].Name, Is.EqualTo("sales_desk"));

        TelephonyTransferTargets cleared = await telephonyClient.ReplaceTelephonyTransferTargetsAsync(agentName, "*", Array.Empty<TelephonyTransferTarget>(), CancellationToken.None);
        Assert.That(cleared.TransferTargets, Is.Empty);
    }

    // -----------------------------------------------------------------------
    // Verifies get/update/delete of a nonexistent telephony binding each surface a 404, without
    // requiring a real Twilio/Teams-provider binding to exist (which needs real provider
    // credentials this test environment does not have -- see TestTelephonyBindingsCRUD's comment).
    // Mirrors azure-ai-projects' (Python) test_voice_agent_telephony.py's fake-binding-id assertions.
    // -----------------------------------------------------------------------
    [RecordedTest]
    public async Task TestTelephonyBindingNotFoundOperations()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        BetaVoiceAgentsTelephony telephonyClient = agentsClient.GetBetaVoiceAgentTelephony();
        string agentName = await EnsureTelephonyAgentAsync(agentsClient);
        const string fakeBindingId = "twilio:+10000000000";

        ClientResultException getException = Assert.ThrowsAsync<ClientResultException>(
            () => telephonyClient.GetTelephonyBindingAsync(agentName, fakeBindingId, CancellationToken.None));
        Console.WriteLine($"[REST] GET unknown telephony binding -> {getException.Status}");
        Assert.That(getException.Status, Is.EqualTo(404));

        BinaryContent updateContent = BinaryContent.Create(BinaryData.FromObjectAsJson(new { status = "suspended" }));
        ClientResultException updateException = Assert.ThrowsAsync<ClientResultException>(
            () => telephonyClient.UpdateTelephonyBindingAsync(agentName, fakeBindingId, "*", updateContent, new RequestOptions()));
        Console.WriteLine($"[REST] UPDATE unknown telephony binding -> {updateException.Status}");
        Assert.That(updateException.Status, Is.EqualTo(404));

        ClientResultException deleteException = Assert.ThrowsAsync<ClientResultException>(
            () => telephonyClient.DeleteTelephonyBindingAsync(agentName, fakeBindingId, "*", CancellationToken.None));
        Console.WriteLine($"[REST] DELETE unknown telephony binding -> {deleteException.Status}");
        Assert.That(deleteException.Status, Is.EqualTo(404));
    }

    // -----------------------------------------------------------------------
    // Verifies get/transfer/end of a nonexistent telephony call each surface a 404. Testing the
    // success path needs a real in-progress or historical inbound call, which this test environment
    // does not have (see TestTelephonyBindingsCRUD's comment).
    // -----------------------------------------------------------------------
    [RecordedTest]
    public async Task TestTelephonyCallNotFoundOperations()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        BetaVoiceAgentsTelephony telephonyClient = agentsClient.GetBetaVoiceAgentTelephony();
        string agentName = await EnsureTelephonyAgentAsync(agentsClient);
        const string fakeCallId = "cs-e2e-tests-nonexistent-call";

        ClientResultException getException = Assert.ThrowsAsync<ClientResultException>(
            () => telephonyClient.GetTelephonyCallAsync(agentName, fakeCallId, CancellationToken.None));
        Console.WriteLine($"[REST] GET unknown telephony call -> {getException.Status}");
        Assert.That(getException.Status, Is.EqualTo(404));

        ClientResultException transferException = Assert.ThrowsAsync<ClientResultException>(
            () => telephonyClient.TransferTelephonyCallAsync(agentName, fakeCallId, "nonexistent-target", CancellationToken.None));
        Console.WriteLine($"[REST] TRANSFER unknown telephony call -> {transferException.Status}");
        Assert.That(transferException.Status, Is.EqualTo(404));

        ClientResultException endException = Assert.ThrowsAsync<ClientResultException>(
            () => telephonyClient.EndTelephonyCallAsync(agentName, fakeCallId, CancellationToken.None));
        Console.WriteLine($"[REST] END unknown telephony call -> {endException.Status}");
        Assert.That(endException.Status, Is.EqualTo(404));
    }

    // -----------------------------------------------------------------------
    // Verifies get/cancel of a nonexistent telephony call job each surface a client error. Verified
    // live (2026-09-17) that a syntactically-plausible but nonexistent call-job id hits the
    // service's id-format validator and returns 400 "Invalid campaign outbound Call Job ID" rather
    // than a clean 404 -- a known, pre-existing service limitation also documented by
    // azure-ai-projects' (Python) test_voice_agent_telephony_call_job.py::test_telephony_call_job_not_found
    // (which observed 400 UnsupportedApiVersion for the same route); only asserting a client-error
    // status here, not a specific code, since testing the real 404 path needs a validly-formatted
    // id whose format isn't publicly documented. create_call_job is intentionally not exercised here
    // since it needs a real Twilio/Teams-provider connection this test environment does not have.
    // -----------------------------------------------------------------------
    [RecordedTest]
    public async Task TestTelephonyCallJobNotFoundOperations()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        BetaVoiceAgentsTelephony telephonyClient = agentsClient.GetBetaVoiceAgentTelephony();
        string agentName = await EnsureTelephonyAgentAsync(agentsClient);
        const string fakeCallJobId = "cs-e2e-tests-nonexistent-call-job";

        ClientResultException getException = Assert.ThrowsAsync<ClientResultException>(
            () => telephonyClient.GetTelephonyCallJobAsync(agentName, fakeCallJobId, CancellationToken.None));
        Console.WriteLine($"[REST] GET unknown telephony call job -> {getException.Status}");
        Assert.That(getException.Status, Is.EqualTo(400).Or.EqualTo(404));

        // cancel_call_job's ifMatch is a numeric call-job revision, not an opaque ETag -- the
        // service rejects an unconditional "*" for this endpoint, so a well-formed fake revision is
        // passed instead (matching azure-ai-projects' (Python) equivalent test).
        ClientResultException cancelException = Assert.ThrowsAsync<ClientResultException>(
            () => telephonyClient.CancelTelephonyCallJobAsync(agentName, fakeCallJobId, "0", CancellationToken.None));
        Console.WriteLine($"[REST] CANCEL unknown telephony call job -> {cancelException.Status}");
        Assert.That(cancelException.Status, Is.EqualTo(400).Or.EqualTo(404));
    }
}

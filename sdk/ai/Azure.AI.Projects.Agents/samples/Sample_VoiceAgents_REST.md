# Manage voice agents and inspect telephony resources with REST

This sample uses the `Azure.AI.Projects.Agents` REST clients to administer a voice agent and
inspect existing telephony resources. It does not need a WebSocket connection.

Realtime/cascaded voice administration and non-SIP telephony are GA. SIP models and telephony
campaigns remain preview; suppress diagnostic `AAIP001` for those parts of the sample. Each
example uses a bounded cancellation token; synchronous counterparts are also available.

## Prerequisites

- Set `FOUNDRY_PROJECT_ENDPOINT` to the Foundry project endpoint.
- Set `FOUNDRY_REALTIME_MODEL_NAME` to a deployed voice-compatible model for the administration example.
- Sign in with `az login`, or otherwise configure `DefaultAzureCredential`.
- For read-only telephony examples, configure the explicitly named fixture environment variables.
  The samples never modify a shared voice agent, binding, call, call job, or campaign.

## Administer a voice agent

This GA example needs no Voice Agents preview opt-in. It creates an agent with a unique name, reads its
typed `VoiceAgentDefinition`, lists its versions, and deletes only that agent in `finally`.

```C# Snippet:Sample_VoiceAgents_REST_Admin
string projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
string modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_REALTIME_MODEL_NAME");
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
```

## Inspect telephony bindings, calls, and call jobs

Set `VOICE_AGENT_NAME`, `VOICE_TELEPHONY_BINDING_ID`, `VOICE_TELEPHONY_CALL_ID`, and
`VOICE_TELEPHONY_CALL_JOB_ID` to existing resources. This example only invokes read operations.
It does not create or delete a provider binding, dial a number, send SMS or DTMF, transfer or end
a call, or enumerate internal call-job APIs.

Twilio and Teams Phone Extensibility reads require no preview opt-in. For conditional writes to
SIP resources, explicitly supply `Foundry-Features: VoiceAgents=V1Preview` using the request
options or a caller pipeline policy. Campaign operations always require preview; their client
adds the required header.

```C# Snippet:Sample_VoiceAgents_REST_TelephonyReadOnly
string projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
string agentName = Environment.GetEnvironmentVariable("VOICE_AGENT_NAME");
string bindingId = Environment.GetEnvironmentVariable("VOICE_TELEPHONY_BINDING_ID");
string callId = Environment.GetEnvironmentVariable("VOICE_TELEPHONY_CALL_ID");
string callJobId = Environment.GetEnvironmentVariable("VOICE_TELEPHONY_CALL_JOB_ID");
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
```

## Inspect a telephony campaign

Set `VOICE_AGENT_NAME`, `VOICE_TELEPHONY_CAMPAIGN_NAME`, and
`VOICE_TELEPHONY_CAMPAIGN_OPERATION_ID` to an existing campaign fixture. The example constructs
typed configuration in memory, then reads the configured campaign, its operation monitor,
typed `FoundryOpenAIError` details, and paged validation errors. Outbound campaign recipients
currently require `PhoneNumber`. The separate `TeamsAddress` and `SipAddress` examples are transfer
targets, not outbound recipients, and remain subject to provider-specific validation.

> **Warning:** Creating or replacing a campaign can immediately dispatch outbound calls. A future
> recipient timestamp is scheduling, not a dry run. This sample deliberately does not submit the
> constructed campaign and does not claim that campaign creation was live-validated.

```C# Snippet:Sample_VoiceAgents_REST_CampaignReadOnly
string projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
string agentName = Environment.GetEnvironmentVariable("VOICE_AGENT_NAME");
string campaignName = Environment.GetEnvironmentVariable("VOICE_TELEPHONY_CAMPAIGN_NAME");
string operationId = Environment.GetEnvironmentVariable("VOICE_TELEPHONY_CAMPAIGN_OPERATION_ID");
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
    "teams-support", "Transfer to a Teams support account.",
    new TeamsAddress("11111111-2222-3333-4444-555555555555"));
TelephonyTransferTarget sipTransfer = new(
    "sip-support", "Transfer to a SIP support address.",
    new SipAddress("sip:support@contoso.com"));
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
```

For realtime and GPT Live runtime scenarios, including audio and WebSocket sessions, use the
[`Azure.AI.Projects` voice agent REST/realtime sample](../../Azure.AI.Projects/samples/Sample_VoiceAgent.md)
and the [`Azure.AI.Projects` GPT Live sample](../../Azure.AI.Projects/samples/Sample_VoiceAgent_Live.md).

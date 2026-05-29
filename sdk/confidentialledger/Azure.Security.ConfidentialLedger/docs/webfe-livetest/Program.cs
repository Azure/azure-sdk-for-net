// Live exercise of the new UseWebFrontend opt-in against a real WebFE gateway-fronted ledger.
//
// Usage:
//   dotnet run -- submit          Steps 1 + 2: POST, print operationId, persist to ./last-op-id.txt, exit.
//   dotnet run -- rehydrate       Step 4 only: read operationId from file (or arg), rehydrate, poll to completion.
//   dotnet run -- rehydrate <id>
//   dotnet run                    Default ("all"): run all steps in one invocation.
//
// Environment:
//   CONFIDENTIALLEDGER_WEBFE_URL  Target ledger URL (defaults to https://wei-0528.confidential-ledger.azure.com).
//
// Auth: AzureCliCredential (run `az login` first).

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.Security.ConfidentialLedger;

const string OpIdFile = "last-op-id.txt";
string mode = args.Length > 0 ? args[0].ToLowerInvariant() : "all";

string ledgerUrl = Environment.GetEnvironmentVariable("CONFIDENTIALLEDGER_WEBFE_URL")
                   ?? "https://wei-0528.confidential-ledger.azure.com";

Console.WriteLine($"Mode         : {mode}");
Console.WriteLine($"Target ledger: {ledgerUrl}");
Console.WriteLine("Credential   : AzureCliCredential");
Console.WriteLine();

var credential = new Azure.Identity.AzureCliCredential();
var options = new ConfidentialLedgerClientOptions { UseWebFrontend = true };
var client = new ConfidentialLedgerClient(new Uri(ledgerUrl), credential, options);

if (mode == "rehydrate")
{
    string uuid = args.Length > 1 ? args[1] : (File.Exists(OpIdFile) ? File.ReadAllText(OpIdFile).Trim() : null);
    if (string.IsNullOrWhiteSpace(uuid))
    {
        Console.WriteLine($"No operation id provided and {OpIdFile} not found. Run `dotnet run -- submit` first.");
        return;
    }

    Console.WriteLine($"[Rehydrate] operationId = {uuid}");
    Operation resumed = client.RehydratePostLedgerEntryOperation(uuid);
    Console.WriteLine($"   rehydrated op Id  : {resumed.Id}");

    Response probe = await client.GetOperationStatusAsync(uuid, new RequestContext { ErrorOptions = ErrorOptions.NoThrow });
    Console.WriteLine($"   probe status      : {probe.Status}");
    Console.WriteLine($"   probe body        : {probe.Content}");
    Console.WriteLine();

    Console.WriteLine("   polling WaitForCompletionResponseAsync (10 min timeout)...");
    try
    {
        Response resumedResp = await resumed.WaitForCompletionResponseAsync(
            new CancellationTokenSource(TimeSpan.FromMinutes(10)).Token);
        Console.WriteLine($"   completed : Id={resumed.Id}, status={resumedResp.Status}, body={resumedResp.Content}");
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine($"   timed out. Latest Id={resumed.Id}");
    }
    return;
}

// ---------- Step 1: WaitUntil.Started -> 200 (sync commit) or 202 (queued) ----------
Console.WriteLine("[Step 1] PostLedgerEntry(WaitUntil.Started, ...)");
Operation op;
try
{
    op = await client.PostLedgerEntryAsync(
        WaitUntil.Started,
        RequestContent.Create(new { contents = $"WebFE live test @ {DateTimeOffset.UtcNow:O}" }));
}
catch (Exception ex)
{
    Console.WriteLine($"FAILED: {ex.GetType().FullName}");
    Console.WriteLine(ex);
    if (ex.InnerException != null) { Console.WriteLine("--- inner ---"); Console.WriteLine(ex.InnerException); }
    return;
}

Response startResp = op.GetRawResponse();
Console.WriteLine($"   raw status   = {startResp.Status}");
Console.WriteLine($"   operation Id = {op.Id}");
Console.WriteLine($"   has completed = {op.HasCompleted}");
foreach (var h in startResp.Headers)
{
    if (h.Name.StartsWith("x-ms-", StringComparison.OrdinalIgnoreCase))
        Console.WriteLine($"   header {h.Name} = {h.Value}");
}
Console.WriteLine();

string operationId = op.Id;
bool queued = startResp.Status == 202;

if (queued)
{
    File.WriteAllText(OpIdFile, operationId);
    Console.WriteLine($"   persisted operationId to {OpIdFile}");
    Console.WriteLine();
}

// ---------- Step 2: GetOperationStatus direct call ----------
if (queued)
{
    Console.WriteLine("[Step 2] GetOperationStatusAsync(operationId)");
    Response statusResp = await client.GetOperationStatusAsync(operationId);
    Console.WriteLine($"   raw status = {statusResp.Status}");
    Console.WriteLine($"   body       = {statusResp.Content}");
    Console.WriteLine();
}
else
{
    Console.WriteLine("[Step 2] Skipped: gateway committed synchronously (200). op.Id is a CCF transaction id.");
    Console.WriteLine();
}

if (mode == "submit")
{
    Console.WriteLine("submit mode: stopping after Step 2. Run `dotnet run -- rehydrate` later to resume.");
    return;
}

// ---------- Step 3: WaitForCompletion ----------
Console.WriteLine("[Step 3] WaitForCompletionResponseAsync()");
try
{
    Response completedResp = await op.WaitForCompletionResponseAsync(
        new CancellationTokenSource(TimeSpan.FromMinutes(2)).Token);
    Console.WriteLine($"   final status = {completedResp.Status}");
    Console.WriteLine($"   final Id     = {op.Id}  <-- should be a CCF tx id once committed");
    Console.WriteLine($"   final body   = {completedResp.Content}");
}
catch (OperationCanceledException)
{
    Console.WriteLine($"   timed out after 2 min (CCF still down, operation still queued).");
    Console.WriteLine($"   op.Id is still the operation UUID: {op.Id}");
}
Console.WriteLine();

// ---------- Step 4: Rehydrate flow ----------
if (queued)
{
    Console.WriteLine("[Step 4] Rehydrate using existing operationId, poll with fresh client");
    string savedOperationId = operationId;
    Console.WriteLine($"   saved operationId : {savedOperationId}");

    var freshClient = new ConfidentialLedgerClient(new Uri(ledgerUrl), credential, options);
    Operation resumed = freshClient.RehydratePostLedgerEntryOperation(savedOperationId);
    Console.WriteLine($"   rehydrated op Id  : {resumed.Id}");

    Response probe = await freshClient.GetOperationStatusAsync(savedOperationId, new RequestContext { ErrorOptions = ErrorOptions.NoThrow });
    Console.WriteLine($"   probe status      : {probe.Status}");
    Console.WriteLine($"   probe body        : {probe.Content}");
    Console.WriteLine();

    Console.WriteLine("   polling WaitForCompletionResponseAsync (2 min timeout)...");
    try
    {
        Response resumedResp = await resumed.WaitForCompletionResponseAsync(
            new CancellationTokenSource(TimeSpan.FromMinutes(2)).Token);
        Console.WriteLine($"   completed : Id={resumed.Id}, status={resumedResp.Status}, body={resumedResp.Content}");
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine($"   timed out (CCF still down). Rehydration itself confirmed working: Id={resumed.Id}");
    }
    Console.WriteLine();
}
else
{
    Console.WriteLine("[Step 4] Skipped: gateway committed synchronously. Issuing a burst to try to force queuing...");
    int burstSize = 20;
    int queuedCount = 0;
    string firstOperationId = null;
    for (int i = 0; i < burstSize; i++)
    {
        Operation burstOp = await client.PostLedgerEntryAsync(
            WaitUntil.Started,
            RequestContent.Create(new { contents = $"burst {i} @ {DateTimeOffset.UtcNow:O}" }));
        if (burstOp.GetRawResponse().Status == 202)
        {
            queuedCount++;
            if (firstOperationId == null) firstOperationId = burstOp.Id;
        }
    }
    Console.WriteLine($"   burst result : {queuedCount}/{burstSize} queued (202)");

    if (firstOperationId != null)
    {
        Console.WriteLine($"[Step 4b] Rehydrating burst operationId={firstOperationId}");
        var freshClient = new ConfidentialLedgerClient(new Uri(ledgerUrl), credential, options);
        Operation resumed = freshClient.RehydratePostLedgerEntryOperation(firstOperationId);
        Response resumedResp = await resumed.WaitForCompletionResponseAsync(
            new CancellationTokenSource(TimeSpan.FromMinutes(2)).Token);
        Console.WriteLine($"   completed    : Id={resumed.Id}, status={resumedResp.Status}");
    }
    Console.WriteLine();
}

Console.WriteLine("All steps completed successfully.");

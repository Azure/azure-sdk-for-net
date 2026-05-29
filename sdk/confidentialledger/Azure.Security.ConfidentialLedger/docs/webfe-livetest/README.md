# WebFE live-test harness

Hand-run console app that exercises the `UseWebFrontend = true` opt-in in
`Azure.Security.ConfidentialLedger` end-to-end against a real WebFE-fronted
Confidential Ledger.

This project intentionally lives under `docs/` and is **not** included in
`Azure.Security.ConfidentialLedger.sln` or any CI pipeline. It is meant to be
run by hand against a live ledger you control.

## What it validates

1. **Step 1** — `PostLedgerEntryAsync(WaitUntil.Started, ...)`: prints the raw
   status, `op.Id`, and any `x-ms-*` headers. Verifies `GetRawResponse()`
   returns the real initial response (not null) on the queued path.
2. **Step 2** — Direct `GetOperationStatusAsync(operationId)` call against
   `/app/operations/{id}` (queued path only).
3. **Step 3** — `WaitForCompletionResponseAsync` polls to completion;
   verifies `op.Id` flips from the operation UUID to the CCF transaction id
   once committed.
4. **Step 4** — Rehydration: reconstructs the LRO with a **fresh client** via
   `RehydratePostLedgerEntryOperation(operationId)` and polls to completion.
   Simulates a process restart. When the gateway commits synchronously,
   issues a burst of 20 to try to force at least one 202.

The `submit` / `rehydrate` split modes let you test the cross-process
recovery flow:

```bash
# CCF is down, gateway queues:
dotnet run -- submit         # gets 202, persists operationId to ./last-op-id.txt, exits

# ...bring CCF back up...

dotnet run -- rehydrate      # reads operationId, rehydrates, polls to completion
```

## Prerequisites

- **.NET 8 SDK** (or later — the project targets `net8.0`).
- **Azure CLI** and `az login` against a tenant that has `Reader` +
  `Contributor` on the target Confidential Ledger.
- A WebFE-enabled Confidential Ledger you can hit (default in this harness
  is `https://wei-0528.confidential-ledger.azure.com` — override with the
  `CONFIDENTIALLEDGER_WEBFE_URL` env var).

## Build from local SDK source

The `.csproj` has a `<ProjectReference>` to
`../../src/Azure.Security.ConfidentialLedger.csproj`, so a plain
`dotnet build` here always picks up the **current branch's** SDK code — no
NuGet package needed. (If you ever want to point at a published package
instead, delete the `<ProjectReference>` and add a `<PackageReference>`.)

```bash
cd sdk/confidentialledger/Azure.Security.ConfidentialLedger/docs/webfe-livetest

# Optional: pin the .NET SDK Copilot/dev machines use
export DOTNET_ROOT=/home/.dotnet
export PATH=$DOTNET_ROOT:$PATH

dotnet build
```

The first build will also build the SDK projects it depends on.

## Run

Pick a mode:

```bash
# Default — runs all 4 steps in one invocation. If the gateway commits
# synchronously (200), Step 4 fires a 20-entry burst to try to force a 202.
dotnet run

# Submit-only: useful when CCF is about to go down. Captures the 202
# operationId and persists it to ./last-op-id.txt.
dotnet run -- submit

# Rehydrate: re-attaches to the persisted operationId with a fresh client
# and polls until committed (10-min timeout). Use after CCF is back.
dotnet run -- rehydrate

# Or pass an explicit operationId:
dotnet run -- rehydrate 0e7439d4-5f99-4a5e-8671-242407be5e79
```

Target a specific ledger:

```bash
CONFIDENTIALLEDGER_WEBFE_URL=https://my-ledger.confidential-ledger.azure.com dotnet run
```

## Expected output (healthy ledger, sync commit path)

```
[Step 1] raw status = 200, operation Id = 2.42, x-ms-ccf-transaction-id = 2.42
[Step 2] Skipped: gateway committed synchronously (200)
[Step 3] final status = 200, final Id = 2.42, body = {"state":"Committed","transactionId":"2.42"}
[Step 4] Skipped: burst result : 0/20 queued (202)
All steps completed successfully.
```

## Expected output (CCF down → rehydrate path)

```
$ dotnet run -- submit
[Step 1] raw status = 202, operation Id = 0e7439d4-...,
         header x-ms-webfe-operation-id = 0e7439d4-...
   persisted operationId to last-op-id.txt
[Step 2] body = {"operationId":"0e7439d4-...","status":"queued"}

# ...CCF comes back up...

$ dotnet run -- rehydrate
[Rehydrate] operationId = 0e7439d4-...
   probe body = {"operationId":"0e7439d4-...","status":"committed","transactionId":"2.66",...}
   completed : Id=2.66, status=200, ...
```

## Troubleshooting

- **`CS0433: type 'AzureCliCredential' exists in both ...`** — happens if
  you add an explicit `Azure.Identity` `<PackageReference>` while the in-repo
  Azure.Core also defines it. Don't add `Azure.Identity` — the SDK's
  transitive reference is enough, and the code uses
  `new Azure.Identity.AzureCliCredential()` (fully qualified) on purpose.
- **`Azure.Identity.AuthenticationFailedException`** — run `az login` and
  confirm `az account show` returns the right tenant/subscription.
- **`429 QueueDraining`** for many requests in a row — gateway throttling
  while the queue drains. Wait a few minutes and retry.

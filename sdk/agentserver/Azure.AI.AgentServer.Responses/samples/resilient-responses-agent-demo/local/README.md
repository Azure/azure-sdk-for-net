# Run the resilient Responses agent locally (crash → recover)

This kit runs the .NET `resilient-responses-agent-demo` **entirely on your machine**
and demonstrates resilient crash-recovery — **without** the hosted Foundry task API.

> **Why local?** Resilient recovery normally relies on the hosted task-store
> `/tasks` API. Off-platform, the framework auto-selects a **file-backed** task
> store + response store, so the *exact same* recovery code path runs locally with
> no hosted dependency. The default `echo` mode needs **no Azure credentials and no
> model** — only the optional `research` mode calls your Foundry project.

## Prerequisites

- .NET 10 SDK
- Python 3.10+ *(only for the test driver `recovery_demo.py`; `run.sh` sets up a tiny venv for `httpx`)*
- For the optional `research` mode: `az login` + a Foundry **project endpoint** + a **model deployment**

## Quick start (automated demo — credential-free)

```bash
cd local
./setup.sh          # stages the NuGet package drop + builds the agent (Release)
./run.sh            # DEMO_ROUTE=echo (default): stream -> crash -> restart -> recover -> verify
```

`run.sh` drives the whole thing and prints a narrated, verified result. In the
default **`echo`** route it uses the `__ECHO_CRASH__` handler path (no LLM):

1. **Start** the agent as a local server (file-backed state store).
2. **Stream** a response that echoes `sha256(input)`, `Checkpoint()`s the item,
   then `Environment.Exit(137)`s mid-run → `out/sse_initial.txt`.
3. **Restart** → the startup recovery scan reclaims the in-progress task and
   re-invokes the handler (`context.IsRecovery == true`), seeding from the
   persisted response.
4. **Reconnect** with `GET …?stream=true&starting_after=<seq>` →
   `out/sse_resumed.txt`, and assert the recovered echo is **byte-identical** to
   the pre-crash echo.

Actual verified output:

```
[4/4] Reconnecting to the same response and verifying it completes across the crash
  » first resumed event: response.in_progress (carries 1 checkpointed item(s))
  » terminal event: response.completed with 2 total output item(s)

RESULT
{
  "route": "echo",
  "pre_crash_sha256": "94a1060a09f32a5e...4590e1",
  "recovered_sha256": "94a1060a09f32a5e...4590e1",
  "sha_match": true,
  "first_resumed_event": "response.in_progress",
  "terminal_event": "response.completed",
  "RECOVERED_IDENTICAL": true
}

✓ Resilient recovery succeeded — the response completed across a crash.
```

> **Note the first resumed event is `response.in_progress`, not
> `response.created`.** On recovery the framework suppresses the duplicate
> `response.created` (a client that reconnects must never see `created` twice);
> `response.in_progress` is the client-visible reset point. This matches the
> Python implementation and the Responses resilience contract.

### The real multi-phase research crash → recover (parity with hosted)

Needs Azure credentials + a model:

```bash
az login
export FOUNDRY_PROJECT_ENDPOINT=https://<account>.services.ai.azure.com/api/projects/<project>
export AZURE_AI_MODEL_DEPLOYMENT_NAME=gpt-5.4-nano   # a deployment in that project
DEMO_ROUTE=research ./run.sh
```

The `research` route runs a `NUM_PHASES`-phase plan (one resilient `OutputItem` +
`Checkpoint()` per sub-call), injects a `crash` after `CRASH_AFTER` checkpoints,
restarts, and asserts the response completes the full `NUM_PHASES * 4` item plan.

Tunables (env): `DEMO_ROUTE` (`echo`|`research`), `NUM_PHASES` (research, default 3
→ 12 sub-calls), `CRASH_AFTER` (research, default 5 checkpoints), `PORT` (default
8088), `TARGET_OUTPUT_TOKENS` (research, default 80).

## Manual exploration

Drive the agent yourself in two terminals.

**Terminal 1 — start the agent:**

```bash
cd local
./serve.sh                          # credential-free; DEMO_MODE=1, file-backed store
# for the research path also: az login + FOUNDRY_PROJECT_ENDPOINT + AZURE_AI_MODEL_DEPLOYMENT_NAME
```

**Terminal 2 — stream, crash, reconnect** (`SID` pins everything to one session):

```bash
SID=$(openssl rand -hex 16)

# 1) Start a streaming, background, stored response. Note the "id" (caresp_...)
#    and the highest "sequence_number" you see before you crash it.
#    (credential-free) use the __ECHO_CRASH__ route which self-crashes:
curl -N -s http://localhost:8088/responses \
  -H 'content-type: application/json' \
  -d "{\"model\":\"x\",\"input\":\"__ECHO_CRASH__ hello\",
       \"stream\":true,\"store\":true,\"background\":true,\"agent_session_id\":\"$SID\"}"

# The server process exits (137). Restart it in Terminal 1 (./serve.sh again,
# SAME resilient root). On startup it logs the recovery scan reclaiming the task.

# 2) Reconnect to the SAME response (use the id + last seq from step 1):
curl -N -s "http://localhost:8088/responses/<caresp_id>?stream=true&starting_after=<last_seq>"
# First event is response.in_progress carrying the already-checkpointed item;
# the recovered echo item follows; the stream ends with response.completed.
```

> For the LLM research path, replace the input with a real topic and add
> `-H "authorization: Bearer $(az account get-access-token --resource https://ai.azure.com --query accessToken -o tsv)"`.
> GET routes by `response_id` — you don't pass a session id on reconnect. For
> `POST /responses`, the session id goes in the **body** (`agent_session_id`).

## How it works locally

`serve.sh` / `run.sh` flip the framework into local mode by controlling these env vars:

| Env var | Effect |
|---------|--------|
| `FOUNDRY_HOSTING_ENVIRONMENT` (**unset**) | The SDK's `FoundryEnvironment.IsHosted` is false → it auto-selects the file-backed task + response + stream store instead of the hosted `/tasks` API. |
| `AGENTSERVER_STATE_ROOT=<dir>` | Where the resilient task store **and** response store live (`<dir>/tasks`, `<dir>/responses`, `<dir>/streams`). |
| `DEMO_MODE=1` | Enables the `"crash"` / `__ECHO_INPUT__` / `__ECHO_CRASH__` / `__FAIL__` input sentinels. |

> Unlike the Python kit, .NET does **not** use an `AGENTSERVER_TASKS_BACKEND`
> variable — local vs hosted is driven entirely by `FOUNDRY_HOSTING_ENVIRONMENT`.

Recovery works by restarting the process against the **same** `AGENTSERVER_STATE_ROOT`:
the startup scan finds the stale in-progress task, reclaims its lease, and
re-invokes the handler.

## Files

| File | Purpose |
|------|---------|
| `setup.sh` | Stage the NuGet package drop + `dotnet build -c Release`. |
| `run.sh` | One-command automated crash → recover → verify demo. |
| `serve.sh` | Start the agent locally for manual exploration. |
| `recovery_demo.py` | The orchestrator `run.sh` invokes (language-agnostic HTTP driver). |

The agent handler itself is `../src/resilient-responses-agent-demo/Program.cs`.

## Troubleshooting

**`Port … is already in use`** — a server is still running on the port. `run.sh`
auto-picks the next free port; for `serve.sh`, stop the old server (`Ctrl-C`) or
pick another port: `PORT=8090 ./serve.sh`.

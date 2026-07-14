# Run the resilient research agent locally (crash → recover)

This kit runs the .NET invocations `resilient-research-agent` **entirely on your
machine** and demonstrates resilient crash-recovery — **without** the hosted Foundry
task API and **without any Azure credentials or model**.

> **Why local?** Resilient recovery normally relies on the hosted task-store
> `/tasks` API. Off-platform, the framework auto-selects a **file-backed** task
> store, and the agent persists its per-turn event streams + checkpoints to disk —
> so the *exact same* recovery code path runs locally with no hosted dependency. By
> default the agent uses a **synthetic-token fake model** (`USE_FAKE_MODEL=1`), so
> the full run / crash / recover flow needs **no `az login` and no model**. Set
> `USE_FAKE_MODEL=0` (+ a Foundry endpoint) to exercise the real LLM path.

## Prerequisites

- .NET 10 SDK
- Python 3.10+ *(only for the test driver `recovery_demo.py`; `run.sh` sets up a tiny venv for `httpx`)*
- For the optional real-model path: `az login` + a Foundry **project endpoint** + a **model deployment**

## Quick start (automated demo — credential-free)

```bash
cd local
./setup.sh          # stages the NuGet package drop + builds the agent (Release)
./run.sh            # USE_FAKE_MODEL=1 (default): run -> crash -> restart -> recover -> verify
```

`run.sh` drives the whole thing and prints a narrated, verified result:

1. **Start** the agent as a local server (file-backed state store, synthetic model).
2. **`POST /invocations {"message":"<topic>"}`** starts a `NUM_PHASES`-phase research
   run (checkpoint per sub-call) and returns an `invocation_id`; the SSE from
   `GET /invocations/{id}` streams to `out/sse_initial.txt`.
3. **Crash** it after `CRASH_AFTER` phase checkpoints (`POST {"message":"crash"}`
   forces `Environment.Exit(137)`).
4. **Restart** → the startup recovery scan reclaims the in-progress task and
   re-invokes the handler (`EntryMode == Recovered`), reading the persisted phase
   watermark and resuming at the next un-finished sub-call.
5. **Reconnect** with `GET …?last_event_id=<seq>` → `out/sse_resumed.txt` (skips
   already-seen events), and assert the run emits `recovered` and reaches
   `run_complete` with all phases done.

Example tail:

```
[4/4] Reconnecting to the same invocation and verifying the run completes across the crash
  » recovery confirmed: handler re-invoked, 1 phase(s) already done
  » terminal event: run_complete (3 phases)

RESULT
{
  "pre_crash_checkpoints": 1,
  "recovered_event_completed_phases": 1,
  "terminal_event": "run_complete",
  "phases_completed": 3,
  "expected_phases": 3,
  "RECOVERED_FULL_PLAN": true
}

✓ Resilient recovery succeeded — the run completed all phases across a crash.
```

Tunables (env): `USE_FAKE_MODEL` (`1`|`0`, default `1`), `NUM_PHASES` (default 3),
`CRASH_AFTER` (default 1 phase checkpoint), `PORT` (default 8088),
`TARGET_OUTPUT_TOKENS` (default 80).

### The real multi-phase research crash → recover (parity with hosted)

Needs Azure credentials + a model:

```bash
az login
export FOUNDRY_PROJECT_ENDPOINT=https://<account>.services.ai.azure.com/api/projects/<project>
export AZURE_AI_MODEL_DEPLOYMENT_NAME=gpt-5.4-nano   # a deployment in that project
USE_FAKE_MODEL=0 ./run.sh
```

## Manual exploration

Drive the agent yourself in two terminals.

**Terminal 1 — start the agent:**

```bash
cd local
./serve.sh                          # credential-free (fake model); DEMO_MODE=1, file-backed store
# for the real model path also: USE_FAKE_MODEL=0 + az login + FOUNDRY_PROJECT_ENDPOINT + AZURE_AI_MODEL_DEPLOYMENT_NAME
```

**Terminal 2 — start, stream, crash, reconnect:**

```bash
# 1) Start a run. Capture the invocation_id from the response.
INV=$(curl -s http://localhost:8088/invocations \
  -H 'content-type: application/json' \
  -d '{"message":"renewable energy supply chains"}' \
  | python3 -c 'import sys,json;print(json.load(sys.stdin)["invocation_id"])')
echo "invocation_id=$INV"

# 2) Stream it. Note the highest "sequence_number" before you crash it,
#    and watch for "type":"phase_end" checkpoints.
curl -N -s "http://localhost:8088/invocations/$INV"

# 3) In a THIRD terminal, after a phase_end, crash the process:
curl -s http://localhost:8088/invocations \
  -H 'content-type: application/json' -d '{"message":"crash"}'

# The server exits (137). Restart it in Terminal 1 (./serve.sh again — SAME
# session id; serve.sh pins FOUNDRY_AGENT_SESSION_ID). On startup it logs
# "Reclaimed stale task ... Recovered task ... is now active".

# 4) Reconnect, skipping events you already saw (use the last seq from step 2):
curl -N -s "http://localhost:8088/invocations/$INV?last_event_id=<last_seq>"
# First you'll see a {"type":"recovered","completed_phases":N} event, then the
# remaining phases stream, ending with {"type":"run_complete"}.
```

> No auth is needed locally (fake model). The session is pinned by
> `FOUNDRY_AGENT_SESSION_ID` (set by `serve.sh`) — both the original run and the
> restarted process must agree on it for the recovery scan to find the in-progress
> task. This also simulates the hosted platform's session/sandbox routing: hosted,
> the platform pins the session per sandbox and routes GET/cancel by invocation id;
> locally there is no proxy, so we pin the env var instead.

### Testing steer / cancel locally

`steer` and `cancel` also work locally against the pinned session. Because there is
no platform proxy locally, drive them via the same session:

```bash
# start a run (session pinned by serve.sh: local-demo-session)
INV=$(curl -s "http://localhost:8088/invocations?agent_session_id=local-demo-session" \
  -H 'content-type: application/json' -d '{"message":"quantum computing"}' \
  | python3 -c 'import sys,json;print(json.load(sys.stdin)["invocation_id"])')

# steer: POST a new topic on the same session -> winds down, re-enters fresh at phase 1
curl -s "http://localhost:8088/invocations?agent_session_id=local-demo-session" \
  -H 'content-type: application/json' -d '{"message":"fusion energy"}'

# cancel: POST cancel by invocation id (server resolves the pinned session from env)
curl -s -X POST "http://localhost:8088/invocations/$INV/cancel" \
  -H 'content-type: application/json' -d '{}'
# -> {"status":"cancelled",...}; the stream shows winding_down cause=operator_cancel
```

## How it works locally

`serve.sh` / `run.sh` set the env vars that flip the framework into local mode:

| Env var | Effect |
|---------|--------|
| `FOUNDRY_HOSTING_ENVIRONMENT` (**unset**) | `FoundryEnvironment.IsHosted` is false → the SDK auto-selects the file-backed task + stream store instead of the hosted `/tasks` API. |
| `AGENTSERVER_STATE_ROOT=<dir>` | Where the resilient task store **and** streams live (`<dir>/tasks`, `<dir>/streams`). |
| `FOUNDRY_AGENT_SESSION_ID=<id>` | The session = the resilient task id. Must be identical across restarts (and matched by the client for steer/cancel). |
| `USE_FAKE_MODEL=1` | Synthetic-token model → credential-free. Set `0` for the real Foundry Responses model. |
| `DEMO_MODE=1` | Enables the `"crash"` message sentinel. |

> Unlike the Python kit, .NET does **not** use an `AGENTSERVER_TASKS_BACKEND`
> variable — local vs hosted is driven entirely by `FOUNDRY_HOSTING_ENVIRONMENT`.

Recovery works by restarting the process against the **same**
`AGENTSERVER_STATE_ROOT` + `FOUNDRY_AGENT_SESSION_ID`: the startup scan finds the
stale in-progress task, reclaims its lease, and re-invokes the handler.

## Files

| File | Purpose |
|------|---------|
| `setup.sh` | Stage the NuGet package drop + `dotnet build -c Release`. |
| `run.sh` | One-command automated crash → recover → verify demo. |
| `serve.sh` | Start the agent locally for manual exploration. |
| `recovery_demo.py` | The orchestrator `run.sh` invokes (language-agnostic HTTP driver). |

The agent handler itself is
`../src/resilient-research-agent/ResilientResearchHandler.cs` (+ `Program.cs` host).

## Troubleshooting

**`Port … is already in use`** — a server is still running on the port. `run.sh`
auto-picks the next free port; for `serve.sh`, stop the old server (`Ctrl-C`) or
pick another port: `PORT=8090 ./serve.sh`.

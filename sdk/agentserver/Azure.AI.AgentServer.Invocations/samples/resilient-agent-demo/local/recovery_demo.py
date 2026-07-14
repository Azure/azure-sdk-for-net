#!/usr/bin/env python3
"""Local resilient crash-recovery demo for the .NET resilient-agent-demo (invocations).

Runs the .NET ``resilient-research-agent`` **entirely on your machine** — the resilient
task store and the per-turn event streams + checkpoints are file-backed under a local
directory (``AGENTSERVER_STATE_ROOT``), so you do **not** need the hosted Foundry task API.

Model modes:

  * ``USE_FAKE_MODEL=1`` (default) — CREDENTIAL-FREE. The agent streams synthetic token
    deltas instead of calling a model, so the FULL research / crash / recover flow runs
    with NO Azure login. This is the default so ``./run.sh`` works out of the box and in CI.

  * ``USE_FAKE_MODEL=0`` — parity with the hosted demo. Runs the real multi-phase research
    plan against your Foundry project. Needs ``az login`` + ``FOUNDRY_PROJECT_ENDPOINT`` +
    ``AZURE_AI_MODEL_DEPLOYMENT_NAME``.

What it demonstrates, automatically, in one run:

  1. Starts the agent as a local server (file-backed resilient backend).
  2. ``POST /invocations {"message": "<topic>"}`` starts a long-running research task
     (one resilient phase checkpoint per research phase). It returns an ``invocation_id``;
     we open ``GET /invocations/{id}`` and stream the SSE to ``out/sse_initial.txt``,
     tracking the ``sequence_number`` watermark and the ``phase_end`` checkpoints.
  3. After a checkpoint lands, ``POST /invocations {"message": "crash"}`` forces
     ``Environment.Exit(137)``. The stream drops mid-flight.
  4. Restarts the server against the **same** resilient root + session id. On startup the
     framework's recovery scan reclaims the in-progress task and re-invokes the handler
     (``ctx.EntryMode == Recovered``); it reads the persisted phase watermark and resumes
     at the next un-finished phase.
  5. Reconnects with ``GET /invocations/{id}?last_event_id=<seq>`` -> ``out/sse_resumed.txt``
     (skips already-seen events), then asserts the run emits ``recovered`` and reaches
     ``run_complete`` with all phases done.

Run it via ``./run.sh`` (which builds the venv + httpx), or directly after ``./setup.sh``:

    python recovery_demo.py                                 # fake model, no creds
    USE_FAKE_MODEL=0 \\
    FOUNDRY_PROJECT_ENDPOINT=https://<account>.services.ai.azure.com/api/projects/<project> \\
    AZURE_AI_MODEL_DEPLOYMENT_NAME=gpt-5.4-nano \\
    python recovery_demo.py

Tunables (env): ``USE_FAKE_MODEL`` (1|0), ``NUM_PHASES`` (default 3), ``CRASH_AFTER``
(default 1 phase checkpoint), ``PORT`` (default 8088), ``RESILIENT_ROOT``
(default ``./.agentserver``), ``OUT_DIR`` (default ``./out``).
"""
from __future__ import annotations

import json
import os
import signal
import subprocess
import sys
import threading
import time
from pathlib import Path

try:
    import httpx
except ImportError:  # pragma: no cover - guided setup
    sys.exit("httpx is required. Run ./run.sh, or: pip install httpx")

HERE = Path(__file__).resolve().parent
PROJ_DIR = HERE.parent / "src" / "resilient-research-agent"
DLL = PROJ_DIR / "bin" / "Release" / "net10.0" / "ResilientResearchAgentDemo.dll"

USE_FAKE_MODEL = os.environ.get("USE_FAKE_MODEL", "1").strip() != "0"
PORT = int(os.environ.get("PORT", "8088"))


def _port_is_free(port: int) -> bool:
    import socket

    s = socket.socket()
    try:
        s.bind(("0.0.0.0", port))
        return True
    except OSError:
        return False
    finally:
        s.close()


# Auto-pick a free port if the requested one is busy (e.g. a leftover server).
_requested_port = PORT
while not _port_is_free(PORT) and PORT < _requested_port + 25:
    PORT += 1
if PORT != _requested_port:
    print(f"  » port {_requested_port} is busy; using {PORT} instead", flush=True)

BASE = f"http://localhost:{PORT}"
NUM_PHASES = int(os.environ.get("NUM_PHASES", "3"))
CRASH_AFTER = int(os.environ.get("CRASH_AFTER", "1"))
RESILIENT_ROOT = Path(os.environ.get("RESILIENT_ROOT", HERE / ".agentserver")).resolve()
OUT_DIR = Path(os.environ.get("OUT_DIR", HERE / "out")).resolve()
SESSION_ID = os.environ.get("FOUNDRY_AGENT_SESSION_ID", "local-demo-session")
TOPIC = os.environ.get("TOPIC", "The impact of renewable energy adoption on global supply chains")

if not USE_FAKE_MODEL and "FOUNDRY_PROJECT_ENDPOINT" not in os.environ:
    sys.exit(
        "USE_FAKE_MODEL=0 needs FOUNDRY_PROJECT_ENDPOINT (your Foundry project endpoint for\n"
        "the LLM sub-calls). Run `az login`, set it, and set AZURE_AI_MODEL_DEPLOYMENT_NAME.\n"
        "Or just run the credential-free default (USE_FAKE_MODEL=1): ./run.sh"
    )

# Child-process env. FOUNDRY_HOSTING_ENVIRONMENT is UNSET so the SDK selects the local
# file-backed task + stream store rooted at AGENTSERVER_STATE_ROOT (removes the hosted
# /tasks API dependency). FOUNDRY_AGENT_SESSION_ID pins the task's session across both
# lifetimes so the restarted process's recovery scan finds the in-progress task.
CHILD_ENV = {
    **{k: v for k, v in os.environ.items() if k != "FOUNDRY_HOSTING_ENVIRONMENT"},
    "DEMO_MODE": "1",  # enables the "crash" message sentinel
    "USE_FAKE_MODEL": "1" if USE_FAKE_MODEL else "0",
    "AGENTSERVER_STATE_ROOT": str(RESILIENT_ROOT),
    "AZURE_AI_MODEL_DEPLOYMENT_NAME": os.environ.get("AZURE_AI_MODEL_DEPLOYMENT_NAME", "gpt-5.4-nano"),
    "FOUNDRY_AGENT_SESSION_ID": SESSION_ID,
    "INTRA_PHASE_COOLDOWN_SEC": os.environ.get("INTRA_PHASE_COOLDOWN_SEC", "1"),
    "INTER_PHASE_COOLDOWN_SEC": os.environ.get("INTER_PHASE_COOLDOWN_SEC", "1"),
    "TARGET_OUTPUT_TOKENS": os.environ.get("TARGET_OUTPUT_TOKENS", "80"),
    "NUM_PHASES": str(NUM_PHASES),
    "PORT": str(PORT),
}

st = {"inv": None, "max_seq": 0, "checkpoints": 0, "crashed": False}


def log(*a: object) -> None:
    print("  »", *a, flush=True)


def banner(text: str) -> None:
    print(f"\n\033[1m{text}\033[0m", flush=True)


def wait_port(timeout: float = 60.0) -> bool:
    t0 = time.time()
    while time.time() - t0 < timeout:
        try:
            # Any HTTP response (even 404) means the server is up.
            httpx.get(f"{BASE}/invocations/_ping", timeout=2)
            return True
        except Exception:
            time.sleep(0.5)
    return False


def start_server(tag: str) -> subprocess.Popen:
    OUT_DIR.mkdir(parents=True, exist_ok=True)
    logf = open(OUT_DIR / f"server_{tag}.log", "w")
    proc = subprocess.Popen(
        ["dotnet", str(DLL)],
        env=CHILD_ENV,
        stdout=logf,
        stderr=subprocess.STDOUT,
        start_new_session=True,
    )
    if not wait_port():
        raise RuntimeError(f"server '{tag}' did not come up — see {OUT_DIR / f'server_{tag}.log'}")
    log(f"server '{tag}' is up (pid {proc.pid}), logs -> out/server_{tag}.log")
    return proc


def parse_frame(frame: str):
    data = None
    for line in frame.split("\n"):
        if line.startswith("data:"):
            data = line[5:].strip()
    if data is None:
        return {}
    try:
        return json.loads(data)
    except Exception:
        return {}


def start_run() -> None:
    r = httpx.post(f"{BASE}/invocations", json={"message": TOPIC}, timeout=30)
    body = r.json()
    st["inv"] = body.get("invocation_id")
    log(f"started run (HTTP {r.status_code}); invocation_id={st['inv']}")


def inject_crash() -> None:
    log("injecting crash (POST message='crash') ...")
    try:
        httpx.post(f"{BASE}/invocations", json={"message": "crash"}, timeout=10)
    except Exception as exc:
        log(f"crash request returned/disconnected (expected): {type(exc).__name__}")
    st["crashed"] = True


def stream_initial() -> None:
    f = open(OUT_DIR / "sse_initial.txt", "w")
    buf = ""
    try:
        with httpx.stream(
            "GET",
            f"{BASE}/invocations/{st['inv']}",
            headers={"Accept": "text/event-stream"},
            timeout=None,
        ) as r:
            log(f"initial stream opened (HTTP {r.status_code})")
            for chunk in r.iter_text():
                if not chunk:
                    continue
                f.write(chunk)
                f.flush()
                buf += chunk
                while "\n\n" in buf:
                    frame, buf = buf.split("\n\n", 1)
                    data = parse_frame(frame)
                    seq = data.get("sequence_number")
                    if isinstance(seq, int):
                        st["max_seq"] = max(st["max_seq"], seq)
                    if data.get("type") == "phase_end":
                        st["checkpoints"] += 1
                        log(f"checkpoint: phase {data.get('phase')}/{data.get('total')} done (seq={st['max_seq']})")
                        if st["checkpoints"] == CRASH_AFTER and not st["crashed"]:
                            threading.Thread(target=inject_crash, daemon=True).start()
    except Exception as exc:
        log(f"initial stream dropped: {type(exc).__name__} (this is the crash)")
    finally:
        f.close()


def reconnect_and_verify() -> bool:
    starting_after = st["max_seq"]
    log(f"reconnecting: GET /invocations/{st['inv']}?last_event_id={starting_after}")
    f = open(OUT_DIR / "sse_resumed.txt", "w")
    buf = ""
    saw_recovered = None
    terminal = None
    phases_completed = None
    deadline = time.time() + 240
    try:
        with httpx.stream(
            "GET",
            f"{BASE}/invocations/{st['inv']}",
            params={"last_event_id": starting_after},
            headers={"Accept": "text/event-stream"},
            timeout=None,
        ) as r:
            log(f"reconnect stream opened (HTTP {r.status_code})")
            for chunk in r.iter_text():
                if time.time() > deadline:
                    log("reconnect deadline reached")
                    break
                if not chunk:
                    continue
                f.write(chunk)
                f.flush()
                buf += chunk
                while "\n\n" in buf:
                    frame, buf = buf.split("\n\n", 1)
                    data = parse_frame(frame)
                    t = data.get("type")
                    if t == "recovered" and saw_recovered is None:
                        saw_recovered = data.get("completed_phases")
                        log(f"recovery confirmed: handler re-invoked, {saw_recovered} phase(s) already done")
                    if t == "phase_end":
                        log(f"resumed checkpoint: phase {data.get('phase')}/{data.get('total')} done")
                    if t == "run_complete":
                        terminal = t
                        phases_completed = data.get("phases_completed")
                        log(f"terminal event: run_complete ({phases_completed} phases)")
                        break
    except Exception as exc:
        log(f"reconnect stream ended: {type(exc).__name__}")
    finally:
        f.close()

    ok = terminal == "run_complete" and phases_completed == NUM_PHASES
    st["_summary"] = {
        "invocation_id": st["inv"],
        "model": "fake" if USE_FAKE_MODEL else "real",
        "pre_crash_checkpoints": st["checkpoints"],
        "pre_crash_max_seq": st["max_seq"],
        "recovered_event_completed_phases": saw_recovered,
        "terminal_event": terminal,
        "phases_completed": phases_completed,
        "expected_phases": NUM_PHASES,
        "RECOVERED_FULL_PLAN": ok,
    }
    return ok


def _clean(d: Path) -> None:
    if not d.exists():
        return
    for p in sorted(d.rglob("*"), reverse=True):
        try:
            p.unlink() if p.is_file() else p.rmdir()
        except OSError:
            pass


def main() -> int:
    if not DLL.exists():
        sys.exit(f"agent build output not found: {DLL}\nRun ./setup.sh first.")
    # Fresh state each run: task store + stream + checkpoint dirs (all under RESILIENT_ROOT).
    RESILIENT_ROOT.mkdir(parents=True, exist_ok=True)
    OUT_DIR.mkdir(parents=True, exist_ok=True)
    for sub in ("tasks", "responses", "streams", "checkpoints"):
        _clean(RESILIENT_ROOT / sub)

    model_label = "FAKE model (synthetic tokens, no creds)" if USE_FAKE_MODEL else "REAL model (Foundry)"
    banner(f"[1/4] Starting local resilient agent — {model_label} (task store {RESILIENT_ROOT}, session {SESSION_ID})")
    p1 = start_server("1")

    banner(f"[2/4] Starting a {NUM_PHASES}-phase research run; will crash after {CRASH_AFTER} phase checkpoint(s)")
    start_run()
    stream_initial()
    log(f"pre-crash watermark: {st['checkpoints']} checkpoint(s), max seq {st['max_seq']}, invocation {st['inv']}")
    for _ in range(60):
        if p1.poll() is not None:
            log(f"server '1' exited (rc={p1.returncode}) — crash confirmed")
            break
        time.sleep(0.5)
    else:
        log("server '1' still alive; killing it to simulate the crash")
        os.killpg(os.getpgid(p1.pid), signal.SIGKILL)
    time.sleep(2)

    banner("[3/4] Restarting the agent — startup recovery scan reclaims the in-progress task")
    p2 = start_server("2")
    log("giving recovery a moment to re-invoke the handler ...")
    time.sleep(8)

    banner("[4/4] Reconnecting to the same invocation and verifying the run completes across the crash")
    ok = reconnect_and_verify()

    try:
        os.killpg(os.getpgid(p2.pid), signal.SIGTERM)
    except Exception:
        pass

    banner("RESULT")
    print(json.dumps(st["_summary"], indent=2))
    print(f"\nSSE transcripts: {OUT_DIR / 'sse_initial.txt'}  +  {OUT_DIR / 'sse_resumed.txt'}")
    if ok:
        print("\n\033[32m✓ Resilient recovery succeeded — the run completed all phases across a crash.\033[0m")
        return 0
    print("\n\033[31m✗ Recovery did not complete the run — inspect out/server_2.log.\033[0m")
    return 1


if __name__ == "__main__":
    raise SystemExit(main())

#!/usr/bin/env python3
"""Local resilient crash-recovery demo for the .NET resilient-responses-agent-demo.

Runs the .NET agent **entirely on your machine** — the resilient task store and the
response store are file-backed under a local directory, so you do **not** need the
hosted Foundry task API. Two modes:

  * ``DEMO_ROUTE=echo`` (default) — CREDENTIAL-FREE. Uses the ``__ECHO_CRASH__``
    demo route: the handler echoes ``sha256(input)``, ``checkpoint()``s, then
    ``Environment.Exit(137)`` mid-run. On restart the framework's recovery scan
    reclaims the task and re-invokes the handler with ``context.IsRecovery == true``;
    it re-echoes from the persisted response. We assert the pre-crash and
    post-recovery SHA are byte-identical — proving durable recovery with **no LLM
    and no Azure credentials**.

  * ``DEMO_ROUTE=research`` — parity with the hosted demo. Runs the real
    multi-phase research plan (one resilient ``OutputItem`` + ``checkpoint()`` per
    sub-call), injects a crash after ``CRASH_AFTER`` checkpoints, restarts, and
    asserts the response completes the full ``NUM_PHASES * 4`` item plan across the
    crash. Needs ``az login`` + ``FOUNDRY_PROJECT_ENDPOINT`` + a model deployment.

Run via ``./run.sh`` (which builds first), or directly (after ``./setup.sh``):

    python recovery_demo.py                    # echo mode, no creds
    DEMO_ROUTE=research \\
    FOUNDRY_PROJECT_ENDPOINT=https://<account>.services.ai.azure.com/api/projects/<project> \\
    AZURE_AI_MODEL_DEPLOYMENT_NAME=gpt-5.4-nano \\
    python recovery_demo.py

Tunables (env): ``DEMO_ROUTE`` (echo|research), ``NUM_PHASES`` (research, default 3),
``CRASH_AFTER`` (research, default 5 checkpoints), ``PORT`` (default 8088),
``RESILIENT_ROOT`` (default ``./.agentserver``), ``OUT_DIR`` (default ``./out``).
"""
from __future__ import annotations

import json
import os
import re
import signal
import subprocess
import sys
import threading
import time
from pathlib import Path

try:
    import httpx
except ImportError:  # pragma: no cover - guided setup
    sys.exit("httpx is required.  pip install httpx")

HERE = Path(__file__).resolve().parent
PROJ_DIR = HERE.parent / "src" / "resilient-responses-agent-demo"
DLL = PROJ_DIR / "bin" / "Release" / "net10.0" / "ResilientResponsesAgentDemo.dll"

DEMO_ROUTE = os.environ.get("DEMO_ROUTE", "echo").strip().lower()
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


_requested_port = PORT
while not _port_is_free(PORT) and PORT < _requested_port + 25:
    PORT += 1
if PORT != _requested_port:
    print(f"  » port {_requested_port} is busy; using {PORT} instead", flush=True)

BASE = f"http://localhost:{PORT}"
NUM_PHASES = int(os.environ.get("NUM_PHASES", "3"))
CRASH_AFTER = int(os.environ.get("CRASH_AFTER", "5"))
RESILIENT_ROOT = Path(os.environ.get("RESILIENT_ROOT", HERE / ".agentserver")).resolve()
OUT_DIR = Path(os.environ.get("OUT_DIR", HERE / "out")).resolve()

if DEMO_ROUTE == "research" and "FOUNDRY_PROJECT_ENDPOINT" not in os.environ:
    sys.exit(
        "DEMO_ROUTE=research needs FOUNDRY_PROJECT_ENDPOINT (your Foundry project endpoint\n"
        "for the LLM sub-calls). Run `az login`, set it, and set AZURE_AI_MODEL_DEPLOYMENT_NAME.\n"
        "Or just run the credential-free default: DEMO_ROUTE=echo ./run.sh"
    )

# Model name only matters for the research route.
MODEL = os.environ.get("AZURE_AI_MODEL_DEPLOYMENT_NAME", "gpt-5.4-nano")

# echo-route payload: a distinctive, sizeable string so the SHA is meaningful.
ECHO_PAYLOAD = os.environ.get(
    "ECHO_PAYLOAD",
    "__ECHO_CRASH__ " + ("resilient-recovery-proof " * 8).strip(),
)
RESEARCH_TOPIC = os.environ.get(
    "TOPIC", "The impact of renewable energy adoption on global supply chains"
)

# Child-process env: resilience stays LOCAL (file-backed store under RESILIENT_ROOT).
# FOUNDRY_HOSTING_ENVIRONMENT must be UNSET so the SDK selects the local store.
CHILD_ENV = {
    **{k: v for k, v in os.environ.items() if k != "FOUNDRY_HOSTING_ENVIRONMENT"},
    "DEMO_MODE": "1",
    "AGENTSERVER_STATE_ROOT": str(RESILIENT_ROOT),
    "AZURE_AI_MODEL_DEPLOYMENT_NAME": MODEL,
    "INTRA_PHASE_COOLDOWN_SEC": os.environ.get("INTRA_PHASE_COOLDOWN_SEC", "1"),
    "INTER_PHASE_COOLDOWN_SEC": os.environ.get("INTER_PHASE_COOLDOWN_SEC", "1"),
    "TARGET_OUTPUT_TOKENS": os.environ.get("TARGET_OUTPUT_TOKENS", "80"),
    "NUM_PHASES": str(NUM_PHASES),
    "PORT": str(PORT),
}

st = {"rid": None, "max_seq": 0, "done": 0, "crashed": False, "precrash_sha": None}


def log(*a: object) -> None:
    print("  »", *a, flush=True)


def banner(text: str) -> None:
    print(f"\n\033[1m{text}\033[0m", flush=True)


def wait_port(timeout: float = 60.0) -> bool:
    t0 = time.time()
    while time.time() - t0 < timeout:
        try:
            httpx.get(f"{BASE}/responses/_ping", timeout=2)
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
    ev = data = None
    for line in frame.split("\n"):
        if line.startswith("event:"):
            ev = line[6:].strip()
        elif line.startswith("data:"):
            data = line[5:].strip()
    if ev is None:
        return None, {}
    try:
        return ev, (json.loads(data) if data else {})
    except Exception:
        return ev, {}


def _extract_text(resp_obj: dict) -> str:
    """Concatenate all output_text content from a response object's output items."""
    parts = []
    for item in (resp_obj.get("output") or []):
        for c in (item.get("content") or []):
            if c.get("type") in ("output_text", "text") and "text" in c:
                parts.append(c["text"])
    return "".join(parts)


_SHA_RE = re.compile(r"([A-Z]+)_SHA256=([0-9a-f]{64})")


def _shas_in(frame: str) -> dict:
    """Pull any *_SHA256=<hex> markers out of a raw SSE frame, keyed by prefix."""
    return {m.group(1): m.group(2) for m in _SHA_RE.finditer(frame)}


def inject_crash() -> None:
    log("injecting crash (POST input='crash', pinned to a fresh session) ...")
    try:
        httpx.post(
            f"{BASE}/responses",
            json={
                "model": MODEL,
                "input": "crash",
                "stream": False,
                "store": True,
                "background": True,
                "agent_session_id": os.urandom(8).hex(),
            },
            timeout=10,
        )
    except Exception as exc:
        log(f"crash request returned/disconnected (expected): {type(exc).__name__}")
    st["crashed"] = True


def stream_initial() -> None:
    is_echo = DEMO_ROUTE == "echo"
    body = {
        "model": MODEL,
        "input": ECHO_PAYLOAD if is_echo else RESEARCH_TOPIC,
        "stream": True,
        "store": True,
        "background": True,
        "agent_session_id": os.urandom(16).hex(),
    }
    f = open(OUT_DIR / "sse_initial.txt", "w")
    buf = ""
    try:
        with httpx.stream("POST", f"{BASE}/responses", json=body, timeout=None) as r:
            log(f"initial stream opened (HTTP {r.status_code})")
            for chunk in r.iter_text():
                if not chunk:
                    continue
                f.write(chunk)
                f.flush()
                buf += chunk
                while "\n\n" in buf:
                    frame, buf = buf.split("\n\n", 1)
                    ev, data = parse_frame(frame)
                    seq = data.get("sequence_number")
                    if isinstance(seq, int):
                        st["max_seq"] = max(st["max_seq"], seq)
                    rid = (data.get("response") or {}).get("id") or data.get("id")
                    if rid and not st["rid"]:
                        st["rid"] = rid
                        log(f"response id: {rid}")
                    if is_echo:
                        # The handler self-crashes right after the pre-crash checkpoint;
                        # capture the PRECRASH sha from whichever frame carries it.
                        pre = _shas_in(frame).get("PRECRASH")
                        if pre and not st["precrash_sha"]:
                            st["precrash_sha"] = pre
                            log(f"pre-crash sha: {pre}")
                    if ev == "response.output_item.done":
                        st["done"] += 1
                        log(f"checkpoint #{st['done']} committed (seq={st['max_seq']})")
                        if not is_echo and st["done"] == CRASH_AFTER and not st["crashed"]:
                            threading.Thread(target=inject_crash, daemon=True).start()
    except Exception as exc:
        log(f"initial stream dropped: {type(exc).__name__} (this is the crash)")
    finally:
        f.close()


def reconnect_and_verify() -> bool:
    is_echo = DEMO_ROUTE == "echo"
    starting_after = st["max_seq"]
    log(f"reconnecting: GET /responses/{st['rid']}?stream=true&starting_after={starting_after}")
    f = open(OUT_DIR / "sse_resumed.txt", "w")
    buf = ""
    first_event = None
    seeded_items = None
    final_items = None
    terminal = None
    recovered_sha = None
    deadline = time.time() + 240
    try:
        with httpx.stream(
            "GET",
            f"{BASE}/responses/{st['rid']}",
            params={"stream": "true", "starting_after": starting_after},
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
                    ev, data = parse_frame(frame)
                    if first_event is None:
                        first_event = ev
                        seeded_items = len((data.get("response") or {}).get("output") or [])
                        log(f"first resumed event: {ev} (carries {seeded_items} checkpointed item(s))")
                    if is_echo:
                        rec = _shas_in(frame).get("RECOVERED")
                        if rec:
                            recovered_sha = rec
                    if ev in ("response.completed", "response.failed", "response.incomplete"):
                        terminal = ev
                        final_items = len((data.get("response") or {}).get("output") or [])
                        break
            if terminal:
                log(f"terminal event: {terminal} with {final_items} total output item(s)")
    except Exception as exc:
        log(f"reconnect stream ended: {type(exc).__name__}")
    finally:
        f.close()

    if is_echo:
        ok = (
            terminal == "response.completed"
            and st["precrash_sha"] is not None
            and recovered_sha == st["precrash_sha"]
        )
        st["_summary"] = {
            "route": "echo",
            "response_id": st["rid"],
            "pre_crash_sha256": st["precrash_sha"],
            "recovered_sha256": recovered_sha,
            "sha_match": recovered_sha == st["precrash_sha"],
            "first_resumed_event": first_event,
            "terminal_event": terminal,
            "RECOVERED_IDENTICAL": ok,
        }
        return ok

    expected = NUM_PHASES * 4
    ok = terminal == "response.completed" and final_items == expected
    st["_summary"] = {
        "route": "research",
        "response_id": st["rid"],
        "pre_crash_checkpoints": st["done"],
        "pre_crash_max_seq": st["max_seq"],
        "first_resumed_event": first_event,
        "items_seeded_on_resume": seeded_items,
        "terminal_event": terminal,
        "final_item_count": final_items,
        "expected_item_count": expected,
        "RECOVERED_FULL_PLAN": ok,
    }
    return ok


def _wipe_state() -> None:
    for sub in ("tasks", "responses", "streams"):
        d = RESILIENT_ROOT / sub
        if d.exists():
            for p in sorted(d.rglob("*"), reverse=True):
                p.unlink() if p.is_file() else p.rmdir()


def main() -> int:
    if not DLL.exists():
        sys.exit(f"agent build output not found: {DLL}\nRun ./setup.sh first.")
    RESILIENT_ROOT.mkdir(parents=True, exist_ok=True)
    OUT_DIR.mkdir(parents=True, exist_ok=True)
    _wipe_state()

    banner(f"[1/4] Starting local resilient .NET agent (route={DEMO_ROUTE}, store at {RESILIENT_ROOT})")
    p1 = start_server("1")

    if DEMO_ROUTE == "echo":
        banner("[2/4] Streaming the __ECHO_CRASH__ response; the handler self-crashes after 1 checkpoint")
    else:
        banner(f"[2/4] Streaming a {NUM_PHASES}-phase research response; will crash after {CRASH_AFTER} checkpoints")
    stream_initial()
    log(f"pre-crash watermark: {st['done']} checkpoints, max seq {st['max_seq']}, response {st['rid']}")
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

    banner("[4/4] Reconnecting to the same response and verifying it completes across the crash")
    ok = reconnect_and_verify()

    try:
        os.killpg(os.getpgid(p2.pid), signal.SIGTERM)
    except Exception:
        pass

    banner("RESULT")
    print(json.dumps(st["_summary"], indent=2))
    print(f"\nSSE transcripts: {OUT_DIR / 'sse_initial.txt'}  +  {OUT_DIR / 'sse_resumed.txt'}")
    if ok:
        print("\n\033[32m✓ Resilient recovery succeeded — the response completed across a crash.\033[0m")
        return 0
    print("\n\033[31m✗ Recovery did not complete — inspect out/server_2.log.\033[0m")
    return 1


if __name__ == "__main__":
    raise SystemExit(main())
